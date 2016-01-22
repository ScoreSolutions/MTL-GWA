Imports Engine.Common
Imports Engine.FAQ
Imports Para.TABLE
Imports System.Data
Imports System.IO
Imports Para.Common
Imports Para.Common.Utilities

Partial Class WebApp_frmFAQForm
    Inherits System.Web.UI.Page

    Const SessFaqFileList As String = "SessFaqFileList"
    Const SessFaqKeywordList As String = "SessFaqKeywordList"


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Valid() = True Then
            Dim para As New FaqPara
            para.ID = txtID.Text
            para.POLICY_SERVICE_TYPE_ID = cmbPolicyServiceTypeID.SelectedValue
            para.QUESTION_DATE = DateTime.Now
            para.QUESTION = txtQuestion.Text
            para.ANSWER = txtAnswer.Text
            para.ORDER_SEQ = txtOrderSeq.Text
            para.ACTIVE = IIf(chkActive.Checked = True, "Y", "N")

            Dim eng As New FAQFormENG
            If eng.SeperateOrderSeq(Config.GetUserID, cmbPolicyServiceTypeID.SelectedValue, txtOrderSeq.Text, lblOrderSeq1.Text) = True Then
                Dim trans As New DbTrans
                trans.CreateTransaction()
                Dim ret As Boolean = eng.SaveFAQ(Config.GetUserID, para, trans)
                If ret = True Then
                    ret = eng.SaveAttachFile(eng.FAQ_ID, Config.GetUserID, Session(SessFaqFileList), trans)
                    If ret = True Then
                        ret = eng.SaveKeyword(eng.FAQ_ID, Config.GetUserID, Session(SessFaqKeywordList), trans)
                        If ret = True Then
                            trans.CommitTransaction()
                            txtID.Text = eng.FAQ_ID
                            eng.RunOrderSeq(Config.GetUserID, cmbPolicyServiceTypeID.SelectedValue)
                            SetForm(eng.FAQ_ID)
                            Config.SaveTransLog("บันทึกข้อมูล FAQ ID=" & txtID.Text)
                            Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
                        Else
                            trans.RollbackTransaction()
                            Config.SaveErrorLog(eng.ErrorMessage)
                            Config.SetAlert(eng.ErrorMessage, Me)
                        End If
                    Else
                        trans.RollbackTransaction()
                        Config.SaveErrorLog(eng.ErrorMessage)
                        Config.SetAlert(eng.ErrorMessage, Me)
                    End If
                Else
                    trans.RollbackTransaction()
                    Config.SaveErrorLog(eng.ErrorMessage)
                    Config.SetAlert(eng.ErrorMessage, Me)
                End If
            End If
        End If
    End Sub
    Private Sub BuildFileDT()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("import_date", GetType(DateTime))
        dt.Columns.Add("file_desc")
        dt.Columns.Add("file_ext")
        dt.Columns.Add("order_seq")
        dt.Columns.Add("active")
        dt.Columns.Add("active_name")
        dt.Columns.Add("row_index")
        dt.Columns.Add("TmpFileUploadPara", GetType(Para.Common.TmpFileUploadPara))

        Session(SessFaqFileList) = dt
    End Sub


    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If cmbPolicyServiceTypeID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกหมวดหมู่คำถาม", Me, cmbPolicyServiceTypeID.ClientID)
        ElseIf txtQuestion.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุคำถาม", Me, txtQuestion.ClientID)
        ElseIf txtAnswer.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุคำตอบ", Me, txtAnswer.ClientID)
        ElseIf txtOrderSeq.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุลำดับการแสดงผล", Me, txtOrderSeq.ClientID)
        ElseIf txtQuestion.Text.Length > 500 Then
            ret = False
            Config.SetAlert("คำถามจะต้องไม่ยาวเกิน 500 ตัวอักษร", Me, txtQuestion.ClientID)
        ElseIf txtAnswer.Text.Length > 500 Then
            ret = False
            Config.SetAlert("คำตอบจะต้องไม่ยาวเกิน 500 ตัวอักษร", Me, txtAnswer.ClientID)
        End If

        Return ret
    End Function

    Protected Sub btnAddFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddFile.Click
        'Dim dt As New DataTable
        'dt.Columns.Add("id")
        'dt.Columns.Add("file_desc")

        'For i As Integer = 0 To 2
        '    Dim dr As DataRow = dt.NewRow
        '    dr("id") = (i + 1)
        '    'dr("file_name") = "<a href='#' >File_" & (i + 1) & ".jpg </a>"
        '    dr("file_desc") = "File Description"
        '    dt.Rows.Add(dr)
        'Next

        If FileValid() = True Then
            Dim dt As DataTable
            If Session(SessFaqFileList) Is Nothing Then
                BuildFileDT()
            End If
            dt = Session(SessFaqFileList)

            Dim dr As DataRow = dt.NewRow
            dr("id") = txtFaqFileID.Text
            dr("import_date") = DateTime.Now
            dr("file_desc") = txtFileDesc.Text
            dr("file_ext") = ctlFileUpload.TmpFileUploadPara.FileExtent
            dr("order_seq") = 0
            dr("active") = "Y"
            dr("active_name") = "แสดง"
            dr("row_index") = dt.Rows.Count
            dr("TmpFileUploadPara") = ctlFileUpload.TmpFileUploadPara
            dt.Rows.Add(dr)

            SetFileListGV(dt)
            ClearAttachFile()
            Config.SaveTransLog("เพิ่มเอกสารแนบ")
        End If
    End Sub

    Private Sub SetFileListGV(ByVal dt As DataTable)
        Config.BuildNoColumn(dt)
        Session(SessFaqFileList) = dt
        gvFileList.DataSource = dt
        gvFileList.DataBind()
    End Sub

    Private Sub ClearAttachFile()
        txtFaqFileID.Text = "0"
        txtFileDesc.Text = ""
        ctlFileUpload.ClearFile()
    End Sub

    Private Function FileValid() As Boolean
        Dim ret As Boolean = True
        If ctlFileUpload.HasFile = False Then
            If txtFaqFileID.Text.Trim = "0" Then
                ctlFileUpload.ClearFile()
                Config.SetAlert("คุณยังไม่เลือกไฟล์ที่ต้องการนำเข้า หรือ ไฟล์ที่ต้องการนำเข้ามีขนาดมากกว่า 5 MB", Me)
                Return False
            End If
        Else
            Select Case ctlFileUpload.TmpFileUploadPara.FileExtent.ToUpper
                Case ".DOC", ".DOCX", ".XLS", ".XLSX", ".PDF"

                Case Else
                    Config.SetAlert("ระบบไม่รองรับไฟล์ที่เลือก", Me)
                    Return False
            End Select
        End If
        If txtFileDesc.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรายละเอียดไฟล์", Me, txtFileDesc.ClientID)
        End If

        Return ret
    End Function
    Protected Sub btnUserViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUserViewer.Click
        Config.SaveTransLog("คลิกปุ่ม ดูในมุมมองผู้ใช้งาน")
        Response.Redirect("frmFAQPreview.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "คำถามที่พบบ่อย >> เพิ่มคำถามที่พบบ่อย"

        If IsPostBack = False Then
            SetServiceTypeCombo()
            Panel1.Visible = False
            If Request("vID") IsNot Nothing Then
                SetForm(Request("vID"))
            Else
                SetDefault(0)
            End If
        End If
    End Sub

    Private Sub SetForm(ByVal vID As Long)
        Dim eng As New FAQFormENG
        Dim para As FaqPara = eng.GetFAQPara(vID)
        If para.ID <> 0 Then
            txtID.Text = para.ID
            cmbPolicyServiceTypeID.SelectedValue = para.POLICY_SERVICE_TYPE_ID
            txtQuestion.Text = para.QUESTION
            txtAnswer.Text = para.ANSWER
            txtOrderSeq.Text = para.ORDER_SEQ
            lblOrderSeq1.Text = para.ORDER_SEQ

            ctlFileUpload.ClearFile()
            txtFileDesc.Text = ""
            txtFaqFileID.Text = "0"
            BuildFileDT()
            If para.CHILD_FAQ_FILE_faq_id.Rows.Count > 0 Then
                Dim dt As DataTable = Session(SessFaqFileList)
                For Each CHILD_dr As DataRow In para.CHILD_FAQ_FILE_faq_id.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = CHILD_dr("id")
                    dr("import_date") = CHILD_dr("import_date")
                    dr("file_desc") = CHILD_dr("file_desc")
                    dr("file_ext") = CHILD_dr("file_ext")
                    dr("order_seq") = CHILD_dr("order_seq")
                    dr("active") = CHILD_dr("active")
                    dr("active_name") = IIf(CHILD_dr("active") = "Y", "แสดง", "ไม่แสดง")
                    dr("row_index") = dt.Rows.Count
                    dr("TmpFileUploadPara") = GetTmpFileByID(CHILD_dr)
                    dt.Rows.Add(dr)
                Next
                SetFileListGV(dt)
            Else
                SetFileListGV(Session(SessFaqFileList))
            End If

            BuildKeywordDT()
            If para.CHILD_FAQ_KEYWORD_faq_id.Rows.Count > 0 Then
                Dim dt As DataTable = Session(SessFaqKeywordList)
                For Each CHILD_dr As DataRow In para.CHILD_FAQ_KEYWORD_faq_id.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = CHILD_dr("id")
                    dr("keyword") = CHILD_dr("keyword")
                    dr("row_index") = dt.Rows.Count
                    dt.Rows.Add(dr)
                Next
                SetKeywordListGV(dt)
            Else
                SetKeywordListGV(Session(SessFaqKeywordList))
            End If
            Config.SaveTransLog("แสดงรายละเอียด FAQ ID=" & para.ID)
        End If
    End Sub

    Private Function GetTmpFileByID(ByVal dr As DataRow) As TmpFileUploadPara
        Dim fileName As String = Constant.FilePrefix.FAQ & dr("id") & dr("file_ext")
        Dim ret As New TmpFileUploadPara
        If File.Exists(Config.GetUploadPath & fileName) = True Then
            ret.TmpFileByte = File.ReadAllBytes(Config.GetUploadPath & fileName)
        End If
        ret.FileExtent = dr("file_ext")
        Return ret
    End Function

    Private Sub SetDefault(ByVal ServiceTypeID As Long)
        txtID.Text = "0"
        cmbPolicyServiceTypeID.SelectedValue = ServiceTypeID
        txtQuestion.Text = ""
        txtAnswer.Text = ""
        chkActive.Checked = True
        txtOrderSeq.Text = ""

        ctlFileUpload.ClearFile()
        txtFileDesc.Text = ""
        txtFaqFileID.Text = "0"

        txtFaqKeywordID.Text = "0"
        txtKeyword.Text = ""

        Session.Remove(SessFaqFileList)
        Session.Remove(SessFaqKeywordList)

        gvFileList.DataSource = Nothing
        gvFileList.DataBind()
        gvKeywordList.DataSource = Nothing
        gvKeywordList.DataBind()
    End Sub
    Private Function GetNextSeq(ByVal vPolicyServiceTypeID As Long) As String
        Dim ret As Long = 0
        Dim eng As New FAQFormENG
        ret = eng.GetNextSeq(vPolicyServiceTypeID)
        Return ret
    End Function

    Private Sub SetServiceTypeCombo()
        Dim fnc As New FAQFormENG
        cmbPolicyServiceTypeID.SetItemList(fnc.GetServiceTypeList(), "policy_service_name", "id")
    End Sub

    Protected Sub gvFileList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvFileList.RowCommand
        If e.CommandName = "DeleteFile" Then
            Dim FileID As Long = e.CommandArgument
            Dim eng As New FAQFormENG

            If txtID.Text.Trim <> 0 Then
                If eng.DeleteFile(FileID) = True Then
                    Config.SaveTransLog("ลบเอกสารแนบ FAQ ID=" & txtID.Text)
                    SetForm(txtID.Text)
                Else
                    Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
                    Dim index As Integer = gvRow.RowIndex
                    Dim dt As DataTable = Session(SessFaqFileList)
                    dt.Rows.RemoveAt(index)
                    SetFileListGV(dt)
                    Config.SaveTransLog("ลบเอกสารแนบ ยังไม่บันทึก ที่รายการเอกสาร")
                End If
            Else
                Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
                Dim index As Integer = gvRow.RowIndex
                Dim dt As DataTable = Session(SessFaqFileList)
                dt.Rows.RemoveAt(index)
                SetFileListGV(dt)
                Config.SaveTransLog("ลบเอกสารแนบ ยังไม่บันทึก")
            End If
        End If
    End Sub

    Private Sub BuildKeywordDT()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("keyword")
        dt.Columns.Add("row_index")
        Session(SessFaqKeywordList) = dt
    End Sub

    Protected Sub btnAddKeyword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddKeyword.Click
        If ValidKeyword() = True Then
            Dim dt As DataTable
            If Session(SessFaqKeywordList) Is Nothing Then
                BuildKeywordDT()
            End If
            dt = Session(SessFaqKeywordList)

            Dim dr As DataRow = dt.NewRow
            dr("id") = txtFaqFileID.Text
            dr("keyword") = txtKeyword.Text.Trim
            dr("row_index") = dt.Rows.Count
            dt.Rows.Add(dr)

            SetKeywordListGV(dt)

            txtKeyword.Text = ""
            txtFaqKeywordID.Text = "0"

            Config.SaveTransLog("เพิ่มคำค้น FAQ")
        End If
    End Sub

    Private Sub SetKeywordListGV(ByVal dt As DataTable)
        Config.BuildNoColumn(dt)
        Session(SessFaqKeywordList) = dt
        gvKeywordList.DataSource = dt
        gvKeywordList.DataBind()
    End Sub

    Private Function ValidKeyword() As Boolean
        Dim ret As Boolean = True
        If txtKeyword.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุคำค้น", Me, txtKeyword.ClientID)
        Else
            Dim eng As New FAQFormENG
            Dim IsDup = eng.ChkDupKeyword(txtKeyword.Text, txtID.Text, txtFaqKeywordID.Text)
            If IsDup = True Then
                ret = False
                Config.SetAlert("คำค้นซ้ำ", Me, txtKeyword.ClientID)
            End If
        End If

        Return ret
    End Function

    Protected Sub gvKeywordList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKeywordList.RowCommand
        If e.CommandName = "DeleteKeyword" Then
            Dim KeywordID As Long = e.CommandArgument
            Dim eng As New FAQFormENG

            If txtID.Text.Trim <> 0 Then
                If KeywordID <> 0 Then
                    If eng.DeleteKeyword(KeywordID) = True Then
                        SetForm(txtID.Text)
                        Config.SaveTransLog("ลบคำค้น FAQ ID=" & txtID.Text)
                    End If
                Else
                    Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
                    Dim index As Integer = gvRow.RowIndex
                    Dim dt As DataTable = Session(SessFaqKeywordList)
                    dt.Rows.RemoveAt(index)
                    SetKeywordListGV(dt)
                    Config.SaveTransLog("ลบคำค้น FAQ ยังไม่บันทึก")
                End If
            Else
                Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
                Dim index As Integer = gvRow.RowIndex
                Dim dt As DataTable = Session(SessFaqKeywordList)
                dt.Rows.RemoveAt(index)
                SetKeywordListGV(dt)
                Config.SaveTransLog("ลบคำค้น FAQ ยังไม่บันทึก")
            End If
        End If
    End Sub

    Protected Sub cmbPolicyServiceTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPolicyServiceTypeID.SelectedIndexChanged
        SetDefault(cmbPolicyServiceTypeID.SelectedValue)
        If cmbPolicyServiceTypeID.SelectedValue <> "0" Then
            txtOrderSeq.Text = GetNextSeq(cmbPolicyServiceTypeID.SelectedValue)
            lblOrderSeq1.Text = txtOrderSeq.Text
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Panel2.Visible = True
        Panel1.Visible = False
        ImageButton1.ImageUrl = "~/Images/bg/search-1.png"
        ImageButton2.ImageUrl = "~/Images/bg/attached.png"
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Panel2.Visible = False
        Panel1.Visible = True
        ImageButton1.ImageUrl = "~/Images/bg/search.png"
        ImageButton2.ImageUrl = "~/Images/bg/attached-1.png"
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        If txtID.Text = "" Or txtID.Text = "0" Then
            SetDefault(0)
        Else
            SetForm(txtID.Text)
        End If
    End Sub
End Class
