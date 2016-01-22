Imports System.Data
Imports Engine.Download
Imports Engine.Common
Imports Para.TABLE
Imports Para.Common.Utilities
Imports System.IO
Imports Para.Common

Partial Class WebApp_frmDownloadAdminImportFile
    Inherits System.Web.UI.Page

    Const CellID As Long = 0
    Const SessFileList As String = "SessFileList"

    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim vID As Long = sender.CommandArgument
        Dim eng As New DownloadENG
        Dim para As DownloadPara = eng.GetDownloadPara(vID, trans)
        If eng.DeleteDownloadRecord(vID, trans) = True Then
            trans.CommitTransaction()
            If File.Exists(Config.GetUploadPath() & Constant.FilePrefix.DOWNLOAD & vID & para.FILE_EXT) Then
                File.Delete(Config.GetUploadPath() & Constant.FilePrefix.DOWNLOAD & vID & para.FILE_EXT)
            End If
            SetFileList(cmbFileCategory.SelectedValue)
            Config.SaveTransLog("ลบไฟล์เอกสาร ID = " & Config.GetUploadPath() & Constant.FilePrefix.DOWNLOAD & vID & para.FILE_EXT)
        Else
            trans.RollbackTransaction()
            Config.SaveErrorLog(eng.ErrorMessage)
            Config.SetAlert(eng.ErrorMessage, Me)
        End If
    End Sub

    Private Sub FillData(ByVal vID As Long)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New DownloadENG
        Dim para As DownloadPara = eng.GetDownloadPara(vID, trans)
        trans.CommitTransaction()

        cmbFileCategory.SelectedValue = para.DOWNLOAD_TYPE_ID
        txtID.Text = para.ID
        ctlFileUpload.GetFile(Constant.FilePrefix.DOWNLOAD & para.ID & para.FILE_EXT)
        txtFileDesc.Text = para.FILE_DESC
        rdiStdType.SelectedValue = para.DOCUMENT_TYPE
        If rdiStdType.SelectedValue = "1" Then
            txtAccountCode.Enabled = False
        Else
            txtAccountCode.Enabled = True
            txtAccountCode.Text = para.ACCOUNT_CODE
        End If
        chkActive.Checked = (para.ACTIVE = "Y")
        Config.SaveTransLog("แสดงรายละเอียดเอกสาร " & para.FILE_DESC & "  ID=" & para.ID)
    End Sub

    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As ImageButton = sender
        Dim grv As GridViewRow = lnk.Parent.Parent
        FillData(grv.Cells(CellID).Text)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Valid() = True Then
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim para As New DownloadPara
            para.ID = txtID.Text
            para.DOWNLOAD_TYPE_ID = cmbFileCategory.SelectedValue
            para.IMPORT_DATE = DateTime.Now
            para.FILE_DESC = txtFileDesc.Text
            para.FILE_EXT = ctlFileUpload.TmpFileUploadPara.FileExtent
            para.DOCUMENT_TYPE = rdiStdType.SelectedValue
            para.ACCOUNT_CODE = txtAccountCode.Text
            para.ORDER_SEQ = 0
            para.ACTIVE = Convert.ToChar(IIf(chkActive.Checked = True, "Y", "N"))

            Dim eng As New DownloadENG

            If para.ID <> 0 Then
                Dim oldPara As DownloadPara = eng.GetDownloadPara(para.ID, trans)
                If File.Exists(Config.GetUploadPath & Constant.FilePrefix.DOWNLOAD & oldPara.ID & oldPara.FILE_EXT) Then
                    File.Delete(Config.GetUploadPath & Constant.FilePrefix.DOWNLOAD & oldPara.ID & oldPara.FILE_EXT)
                End If
            End If

            If eng.SaveDownload(Config.GetUserID, para, trans) = True Then
                If txtID.Text = 0 Then
                    ctlFileUpload.SaveFile(Constant.FilePrefix.DOWNLOAD & eng.DownloadID & ctlFileUpload.TmpFileUploadPara.FileExtent)
                Else
                    If ctlFileUpload.HasFile = True Then
                        ctlFileUpload.SaveFile(Constant.FilePrefix.DOWNLOAD & eng.DownloadID & ctlFileUpload.TmpFileUploadPara.FileExtent)
                    End If
                End If

                trans.CommitTransaction()
                txtID.Text = eng.DownloadID
                SetFileList(cmbFileCategory.SelectedValue)
                Config.SaveTransLog("บันทึกเอกสาร ID=" & eng.DownloadID)
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                Config.SaveErrorLog(eng.ErrorMessage)
                Config.SetAlert(eng.ErrorMessage, Me)
            End If
        End If
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If ctlFileUpload.HasFile = False Then
            Config.SetAlert("คุณยังไม่เลือกไฟล์ที่ต้องการนำเข้า หรือ ไฟล์ที่ต้องการนำเข้ามีขนาดมากกว่า 5 MB", Me)
            ctlFileUpload.ClearFile()
            Return False
        Else
            Select Case ctlFileUpload.TmpFileUploadPara.FileExtent.ToUpper
                Case ".DOC", ".DOCX", ".XLS", ".XLSX", ".PDF"

                Case Else
                    Config.SetAlert("ระบบไม่รองรับไฟล์ที่เลือก", Me)
                    Return False
            End Select
        End If

        If cmbFileCategory.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกหมวดหมู่", Me, cmbFileCategory.ClientID)
        ElseIf txtFileDesc.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรายละเอียด", Me, txtFileDesc.ClientID)
        Else
            If rdiStdType.SelectedValue = "2" Then
                If txtAccountCode.Text.Trim = "" Then
                    ret = False
                    Config.SetAlert("กรุณาระบุรหัสบริษัท", Me, txtAccountCode.ClientID)
                End If
            End If
        End If

        Return ret
    End Function

    Private Sub SetCategoryCombo()
        Dim eng As New DownloadENG
        Dim dt As DataTable = eng.GetDownloadTypeList()
        If dt.Rows.Count > 0 Then
            cmbFileCategory.SetItemList(dt, "type_name", "id")
        End If

        'cmbFileCategory.SetItemList(cmbFileCategory.DefaultDisplay, cmbFileCategory.DefaultValue)
        'cmbFileCategory.SetItemList("คู่มือประกันกลุ่ม", 1)
        'cmbFileCategory.SetItemList("แบบฟอร์ม", 2)
        'cmbFileCategory.SetItemList("เอกสารอื่นๆ", 3)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ดาวน์โหลด  >> นำเข้าเอกสาร"

        If IsPostBack = False Then
            SetCategoryCombo()
            SetFileList(cmbFileCategory.SelectedValue)
        End If
    End Sub

    Private Sub SetFileList(ByVal CategoryID As String)
        ''Demo
        'Dim dt As New DataTable
        'dt.Columns.Add("id")
        'dt.Columns.Add("file_category")
        'dt.Columns.Add("file_name")
        'dt.Columns.Add("file_desc")
        'dt.Columns.Add("active_name")
        'dt.Columns.Add("import_date")

        'For i As Integer = 0 To 2
        '    Dim dr As DataRow = dt.NewRow
        '    dr("id") = (i + 1)
        '    dr("file_category") = "คู่มือประกันกลุ่ม"
        '    dr("file_desc") = "xxxxxxxxxxxx"
        '    dr("active_name") = "แสดง"
        '    dr("import_date") = DateTime.Now.ToString("dd/MM/yyyy")
        '    dt.Rows.Add(dr)
        'Next
        'For i As Integer = 2 To 4
        '    Dim dr As DataRow = dt.NewRow
        '    dr("id") = (i + 1)
        '    dr("file_category") = "แบบฟอร์ม"
        '    dr("file_desc") = "xxxxxxxxxxxx"
        '    dr("active_name") = "แสดง"
        '    dr("import_date") = DateTime.Now.ToString("dd/MM/yyyy")
        '    dt.Rows.Add(dr)
        'Next

        '''#######
        Dim eng As New DownloadENG
        Dim dt As DataTable = eng.GetAllFileList(CategoryID)

        If dt.Rows.Count > 0 Then
            pcTop.SetMainGridView(gvFileList)
            Session(SessFileList) = dt
            gvFileList.DataSource = dt
            gvFileList.DataBind()
            lblDisplayData.Visible = True
            pcTop.Update(dt.Rows.Count)
        Else
            gvFileList.DataSource = Nothing
            gvFileList.DataBind()
            pcTop.Visible = False
            lblDisplayData.Visible = False
            Session(SessFileList) = Nothing
        End If
    End Sub

    Protected Sub rdiStdType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdiStdType.SelectedIndexChanged
        If rdiStdType.SelectedValue = "2" Then
            txtAccountCode.IsNotNull = True
            txtAccountCode.Enabled = True
        Else
            txtAccountCode.Text = ""
            txtAccountCode.Enabled = False
            txtAccountCode.IsNotNull = False
        End If
    End Sub

    Protected Sub btnUserViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUserViewer.Click
        Config.SaveTransLog("คลิกปุ่ม ดูในมุมมองผู้ใช้งาน")
        Response.Redirect("../WebApp/frmDownload.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub gvFileList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvFileList.Sorted
        For i As Integer = 0 To gvFileList.Rows.Count - 1
            gvFileList.Rows(i).Cells(0).Text = (gvFileList.PageIndex * gvFileList.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub gvFileList_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvFileList.Sorting
        Dim dt As DataTable = Session(SessFileList)
        Config.GridViewSorting(gvFileList, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
        pcTop.SetMainGridView(gvFileList)
        gvFileList.DataSource = dt
        gvFileList.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        gvFileList.PageIndex = pcTop.SelectPageIndex
        Dim dt As DataTable = Session(SessFileList)
        pcTop.SetMainGridView(gvFileList)
        gvFileList.DataSource = dt
        gvFileList.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        If txtID.Text = "0" Or txtID.Text.Trim = "" Then
            cmbFileCategory.SelectedValue = "0"
            txtID.Text = "0"
            ctlFileUpload.ClearFile()
            txtFileDesc.Text = ""
            rdiStdType.SelectedValue = "1"
            txtAccountCode.Text = ""
            chkActive.Checked = False
        Else
            FillData(txtID.Text)
        End If
        Config.SaveTransLog("คลิกปุ่มยกเลิก")
        SetFileList(cmbFileCategory.SelectedValue)
    End Sub

    Protected Sub cmbFileCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFileCategory.SelectedIndexChanged
        txtID.Text = "0"
        ctlFileUpload.ClearFile()
        txtFileDesc.Text = ""
        rdiStdType.SelectedValue = "1"
        txtAccountCode.Text = ""
        chkActive.Checked = False
        txtAccountCode.Enabled = False
        txtAccountCode.IsNotNull = False

        SetFileList(cmbFileCategory.SelectedValue)
    End Sub
End Class
