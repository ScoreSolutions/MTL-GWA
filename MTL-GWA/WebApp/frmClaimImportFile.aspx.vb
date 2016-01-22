Imports System.Data
Imports Engine.Common
Imports Para.TABLE
Imports Engine.Claim
Imports Para.Common
Imports Para.Common.Utilities
Imports System.IO

Partial Class WebApp__frmClaimImportFile
    Inherits System.Web.UI.Page

    Const SessClaimImportFile As String = "SessClaimImportFile"
    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim vID As Long = sender.CommandArgument
        Dim eng As New ImportFileENG
        Dim para As ClaimAttachFilePara = eng.GetClaimAttachFilePara(vID, trans)
        If eng.DeleteClaimAttachFile(vID, trans) = True Then
            trans.CommitTransaction()
            If File.Exists(Config.GetUploadPath() & Constant.FilePrefix.CLAIM & vID & para.FILE_EXT) Then
                File.Delete(Config.GetUploadPath() & Constant.FilePrefix.CLAIM & vID & para.FILE_EXT)
            End If
            eng.RunOrderSeq(Config.GetUserID, Val(para.SERVICE_TYPE))
            SetFileList(rdiServiceCategory.SelectedValue)
            GenNextOrderSeq()
            Config.SaveTransLog("ลบไฟล์ " & Config.GetUploadPath() & Constant.FilePrefix.CLAIM & vID & para.FILE_EXT)
        Else
            trans.RollbackTransaction()
            Config.SaveErrorLog(eng.ErrorMessage)
            Config.SetAlert(eng.ErrorMessage, Me)
        End If
    End Sub

    Private Sub FillData(ByVal vId As Long)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New ImportFileENG
        Dim para As ClaimAttachFilePara = eng.GetClaimAttachFilePara(vID, trans)

        If para IsNot Nothing Then
            txtID.Value = para.ID
            txtFileDesc.Text = para.FILE_DESC
            txtOrderSeq.Text = para.ORDER_SEQ
            rdiServiceCategory.SelectedValue = para.SERVICE_TYPE
            chkActive.Checked = IIf(para.ACTIVE = "Y", True, False)
            txtOrderSeqTmp.Value = para.ORDER_SEQ
            ctlFileUpload.GetFile(Constant.FilePrefix.CLAIM & para.ID & para.FILE_EXT)
            Config.SaveTransLog("แก้ไขข้อมูลการนำเข้าเอกสาร ID=" & para.ID)
        End If
        trans.CommitTransaction()
    End Sub

    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        FillData(sender.CommandArgument)


        'Dim trans As New DbTrans
        'trans.CreateTransaction()
        'Dim vID As Long = sender.CommandArgument
        'Dim eng As New ImportFileENG
        'Dim para As ClaimAttachFilePara = eng.GetClaimAttachFilePara(vID, trans)

        'If para IsNot Nothing Then
        '    txtID.Value = para.ID
        '    txtFileDesc.Text = para.FILE_DESC
        '    txtOrderSeq.Text = para.ORDER_SEQ
        '    rdiServiceCategory.SelectedValue = para.SERVICE_TYPE
        '    chkActive.Checked = IIf(para.ACTIVE = "Y", True, False)
        '    txtOrderSeqTmp.Value = para.ORDER_SEQ
        '    ctlFileUpload.GetFile(Constant.FilePrefix.CLAIM & para.ID & para.FILE_EXT)
        '    Config.SaveTransLog("แก้ไขข้อมูลการนำเข้าเอกสาร ID=" & para.ID)
        'End If
        'trans.CommitTransaction()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "บริการด้านสินไหม >> นำเข้าเอกสาร"

        If IsPostBack = False Then
            SetFileList(1)
            GenNextOrderSeq()
        End If
    End Sub

    Private Sub SetFileList(ByVal ServiceTypeID As String)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New ImportFileENG
        Dim dt As DataTable = eng.SetFileList(ServiceTypeID, trans)
        If dt.Rows.Count > 0 Then
            Session(SessClaimImportFile) = dt
            gvFileList.PageSize = 20
            pcTop.SetMainGridView(gvFileList)
            gvFileList.DataSource = dt
            gvFileList.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            pcTop.Visible = False
            gvFileList.DataSource = Nothing
            gvFileList.DataBind()
        End If
        trans.CommitTransaction()
    End Sub

    Const CellIndexOrderSeq As Int16 = 1
    Const CellID As Long = 0
    Protected Sub gvFileList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvFileList.RowCommand
        Dim gv As GridView = sender
        If e.CommandName = "lblOrderSeqClick" Then
            Dim rowIndex As Int16 = e.CommandArgument
            For i As Integer = 0 To gv.Rows.Count - 1
                Dim iText As UserControls_txtAutoComplete = gv.Rows(i).Cells(CellIndexOrderSeq).FindControl("txtOrderSeq")
                Dim iLbl As LinkButton = gv.Rows(i).Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
                Dim iButton As Button = gv.Rows(i).Cells(CellIndexOrderSeq).FindControl("btnSaveOrderSeq")

                iText.Visible = False
                iButton.Visible = False

                If iLbl.Visible = False Then
                    iLbl.Visible = True
                End If
            Next

            Dim txt As UserControls_txtAutoComplete = gv.Rows(rowIndex).Cells(CellIndexOrderSeq).FindControl("txtOrderSeq")
            txt.Visible = True

            Dim btn As Button = gv.Rows(rowIndex).Cells(CellIndexOrderSeq).FindControl("btnSaveOrderSeq")
            btn.Visible = True

            Dim lbl As LinkButton = gv.Rows(rowIndex).Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
            lbl.Visible = False
        End If

    End Sub



    Protected Sub gvFileList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvFileList.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn As Button = e.Row.Cells(CellIndexOrderSeq).FindControl("btnSaveOrderSeq")
            Dim lbl As LinkButton = e.Row.Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
            btn.CommandArgument = e.Row.RowIndex
            lbl.CommandArgument = e.Row.RowIndex
        End If
    End Sub
    Protected Sub btnSaveOrderSeq_Click(ByVal sender As Object, ByVal e As EventArgs)
        'เข้ามาทำเมื่อมีการกดปุ่มบันทึกในคอลัมน์ลำดับการแสดง
        Dim btn As Button = sender
        Dim grv As GridViewRow = btn.Parent.Parent
        Dim vID As Integer = grv.Cells(CellID).Text
        Dim NewSeq As UserControls_txtAutoComplete = grv.Cells(CellIndexOrderSeq).FindControl("txtOrderSeq")
        Dim OldSeq As LinkButton = grv.Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
        If NewSeq.Text.Trim <> "" Then
            Dim eng As New ImportFileENG
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim para As ClaimAttachFilePara = eng.GetClaimAttachFilePara(vID, trans)
            para.ORDER_SEQ = NewSeq.Text
            If eng.SeperateOrderSeq(Config.GetUserID, Val(para.SERVICE_TYPE), Val(NewSeq.Text), OldSeq.Text) = True Then
                If eng.SaveClaimAttachFile(Config.GetUserID, para, trans) = True Then
                    trans.CommitTransaction()
                    eng.RunOrderSeq(Config.GetUserID, Val(para.SERVICE_TYPE))
                    Dim vServiceType As String = rdiServiceCategory.SelectedValue
                    SetFileList(vServiceType)
                    Config.SaveTransLog("เปลื่ยนลำดับการแสดง")
                    Config.SetAlert("เปลื่ยนลำดับการแสดงเรียบร้อย", Me)
                Else
                    Config.SaveErrorLog(eng.ErrorMessage)
                End If
            Else
                Config.SaveErrorLog(eng.ErrorMessage)
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Valid() = True Then
            Dim para As New ClaimAttachFilePara
            para.ID = txtID.Value
            para.SERVICE_TYPE = rdiServiceCategory.SelectedValue
            para.FILE_DESC = txtFileDesc.Text
            para.FILE_EXT = ctlFileUpload.TmpFileUploadPara.FileExtent
            para.ORDER_SEQ = txtOrderSeq.Text
            para.ACTIVE = IIf(chkActive.Checked, "Y", "N")

            Dim ResponseMsg As String = ""
            'Dim uData As UserProfilePara = Config.GetLogOnUser()
            Dim UserID As String = Config.GetUserID
            Dim eng As New ImportFileENG
            If eng.SeperateOrderSeq(Config.GetUserID, rdiServiceCategory.SelectedValue, txtOrderSeq.Text, txtOrderSeqTmp.Value) = True Then
                Dim trans As New DbTrans
                trans.CreateTransaction()

                Dim oldPara As ClaimAttachFilePara = eng.GetClaimAttachFilePara(para.ID, trans)
                Dim ret As Boolean = eng.SaveClaimAttachFile(UserID, para, trans)
                If ret = True Then
                    'ลบไฟล์เดิมออกก่อน
                    If File.Exists(Config.GetUploadPath & Constant.FilePrefix.CLAIM & eng.ID & oldPara.FILE_EXT) Then
                        File.Delete(Config.GetUploadPath & Constant.FilePrefix.CLAIM & eng.ID & oldPara.FILE_EXT)
                    End If

                    If txtID.Value = 0 Then
                        ctlFileUpload.SaveFile(Constant.FilePrefix.CLAIM & eng.ID & ctlFileUpload.TmpFileUploadPara.FileExtent)
                    Else
                        If ctlFileUpload.HasFile = True Then
                            ctlFileUpload.SaveFile(Constant.FilePrefix.CLAIM & eng.ID & ctlFileUpload.TmpFileUploadPara.FileExtent)
                        End If
                    End If
                    trans.CommitTransaction()
                    eng.RunOrderSeq(UserID, rdiServiceCategory.SelectedValue)
                    ClearScreen(rdiServiceCategory.SelectedValue)
                    SetFileList(rdiServiceCategory.SelectedValue)
                    Config.SaveTransLog("นำเข้าเอกสารการเคลม ID=" & eng.ID)
                    Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
                Else
                    trans.RollbackTransaction()
                    Config.SaveErrorLog(eng.ErrorMessage)
                    Config.SetAlert(eng.ErrorMessage, Me)
                End If
            End If
        End If
    End Sub
    Private Sub ClearScreen(ByVal ServiceID As Long)
        txtID.Value = 0
        ctlFileUpload.ClearFile()
        txtFileDesc.Text = ""
        rdiServiceCategory.SelectedValue = ServiceID
        GenNextOrderSeq()
        chkActive.Checked = False
    End Sub

    Private Sub GenNextOrderSeq()
        Dim NextOrderSeq As String = ""
        Dim eng As New ImportFileENG
        NextOrderSeq = eng.GenNextOrderSeq(rdiServiceCategory.SelectedValue)
        txtOrderSeq.Text = NextOrderSeq
        txtOrderSeqTmp.Value = NextOrderSeq
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

        If txtFileDesc.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุรายละเอียด", Me, txtFileDesc.ClientID)
            ret = False
        ElseIf txtOrderSeq.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุลำดับการแสดง", Me, txtOrderSeq.ClientID)
            ret = False
        End If

        Return ret
    End Function

    'Protected Sub gvFileList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvFileList.Sorted
    '    For i As Integer = 0 To gvFileList.Rows.Count - 1
    '        gvFileList.Rows(i).Cells(0).Text = (gvFileList.PageIndex * gvFileList.PageSize) + (i + 1)
    '    Next
    'End Sub

    Protected Sub gvFileList_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvFileList.Sorting
        Dim dt As DataTable = Session(SessClaimImportFile)
        Config.GridViewSorting(gvFileList, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
        pcTop.SetMainGridView(gvFileList)
        gvFileList.DataSource = dt
        gvFileList.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        gvFileList.PageIndex = pcTop.SelectPageIndex
        Dim dt As DataTable = Session(SessClaimImportFile)
        pcTop.SetMainGridView(gvFileList)
        gvFileList.DataSource = dt
        gvFileList.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub rdiServiceCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdiServiceCategory.SelectedIndexChanged
        ClearScreen(rdiServiceCategory.SelectedValue)
        GenNextOrderSeq()
        SetFileList(rdiServiceCategory.SelectedValue)
    End Sub

    Protected Sub btnUserViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUserViewer.Click
        Config.SaveTransLog("คลิกปุ่ม ดูในมุมมองผู้ใช้งาน")
        If rdiServiceCategory.SelectedValue = "1" Then
            Response.Redirect("../WebApp/frmClaimHealthClaim.aspx?rnd=" & DateTime.Now.Millisecond)
        ElseIf rdiServiceCategory.SelectedValue = "2" Then
            Response.Redirect("../WebApp/frmClaimLifeClaim.aspx?rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        If txtID.Value = "0" Then
            ClearScreen(1)
        Else
            FillData(txtID.Value)
        End If
    End Sub
End Class
