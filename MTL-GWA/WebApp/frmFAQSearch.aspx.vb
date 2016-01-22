Imports System.Data
Imports Engine.FAQ
Imports Engine.Common
Imports Para.TABLE
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmFAQSearch
    Inherits System.Web.UI.Page
    Const SessQuestionSearchList As String = "SessQuestionSearchList"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Dim dt As New DataTable
        'dt.Columns.Add("id")
        'dt.Columns.Add("question_category")
        'dt.Columns.Add("question")
        'dt.Columns.Add("order_seq")
        'dt.Columns.Add("is_file")
        'dt.Columns.Add("active_status")
        'dt.Columns.Add("input_date")

        'For i As Integer = 0 To 5
        '    Dim dr As DataRow = dt.NewRow
        '    dr("id") = (i + 1)
        '    dr("question_category") = "บริการกรมธรรม์"
        '    dr("question") = "xxxxxxxxxxxxxxxx"
        '    dr("order_seq") = (i + 1)
        '    dr("is_file") = "มี"
        '    dr("active_status") = "แสดง"
        '    dr("input_date") = DateTime.Now.ToString("dd/MM/yyyy")
        '    dt.Rows.Add(dr)
        'Next

        'gvQuestionList.DataSource = dt
        'gvQuestionList.DataBind()

        SearchFAQ()
        Config.SaveTransLog("ค้นหาข้อมูลคำถามที่พบบ่อย")

    End Sub

    Private Sub SearchFAQ()
        Dim eng As New FAQFormENG
        Dim dt As DataTable = eng.GetFaqSearch(cmbPolicyServiceTypeID.SelectedValue, txtQuestion.Text, "")
        If dt.Rows.Count > 0 Then
            Session(SessQuestionSearchList) = dt
            pc1.Visible = True
            pc1.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pc1.Update(dt.Rows.Count)
        Else
            pc1.Visible = False
            gvQuestionList.DataSource = Nothing
            gvQuestionList.DataBind()
        End If
    End Sub

    Protected Sub GetQuestionDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim lik As LinkButton = sender
        Dim grv As GridViewRow = lik.Parent.Parent
        Response.Redirect("frmFAQForm.aspx?vID=" & grv.Cells(0).Text & "&rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub lnkOrderSeq(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "คำถามที่พบบ่อย >> รายการคำถามที่พบบ่อย"

        If IsPostBack = False Then
            Dim fnc As New FAQFormENG
            cmbPolicyServiceTypeID.SetItemList(fnc.GetServiceTypeList(), "policy_service_name", "id")
        End If
    End Sub

    Const CellID As Integer = 0
    Const CellIndexOrderSeq As Integer = 1

    Protected Sub btnSaveOrderSeq_Click(ByVal sender As Object, ByVal e As EventArgs)
        'เข้ามาทำเมื่อมีการกดปุ่มบันทึกในคอลัมน์ลำดับการแสดง
        Dim btn As Button = sender
        Dim grv As GridViewRow = btn.Parent.Parent
        Dim vID As Integer = grv.Cells(CellID).Text
        Dim NewSeq As UserControls_txtAutoComplete = grv.Cells(CellIndexOrderSeq).FindControl("txtOrderSeq")
        Dim OldSeq As LinkButton = grv.Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
        If NewSeq.Text.Trim <> "" Then
            Dim eng As New FAQFormENG
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim para As FaqPara = eng.GetFAQPara(vID)
            para.ORDER_SEQ = NewSeq.Text
            If eng.SeperateOrderSeq(Config.GetUserID, Val(para.POLICY_SERVICE_TYPE_ID), NewSeq.Text, OldSeq.Text) = True Then
                If eng.SaveFAQ(Config.GetUserID, para, trans) = True Then
                    trans.CommitTransaction()
                    eng.RunOrderSeq(Config.GetUserID, Val(para.POLICY_SERVICE_TYPE_ID))
                    SearchFAQ()
                    Config.SaveTransLog("เปลี่ยนลำดับการแสดง FAQ")
                    Config.SetAlert("เปลื่ยนลำดับการแสดงเรียบร้อย", Me)
                End If
            End If
        End If
    End Sub
    Protected Sub gvQuestionList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuestionList.RowCommand
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

    Protected Sub gvQuestionList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuestionList.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn As Button = e.Row.Cells(CellIndexOrderSeq).FindControl("btnSaveOrderSeq")
            Dim lbl As LinkButton = e.Row.Cells(CellIndexOrderSeq).FindControl("lnkOrderSeq")
            btn.CommandArgument = e.Row.RowIndex
            lbl.CommandArgument = e.Row.RowIndex

        End If
    End Sub

    Protected Sub btnUserViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUserViewer.Click
        Config.SaveTransLog("คลิกปุ่ม ดูในมุมมองผู้ใช้งาน")
        Response.Redirect("../WebApp/frmFAQPreview.aspx?rng=" & DateTime.Now.Millisecond)
    End Sub

    'Protected Sub gvQuestionList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuestionList.Sorted
    '    For i As Integer = 0 To gvQuestionList.Rows.Count - 1
    '        gvQuestionList.Rows(i).Cells(0).Text = (gvQuestionList.PageIndex * gvQuestionList.PageSize) + (i + 1)
    '    Next
    'End Sub

    Protected Sub gvQuestionList_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvQuestionList.Sorting
        Dim dt As New DataTable
        dt = Session(SessQuestionSearchList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(gvQuestionList, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pc1.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub pc1_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pc1.PageChange
        Dim dt As New DataTable
        dt = Session(SessQuestionSearchList)
        If dt.Rows.Count > 0 Then
            'gvQuestionList.PageIndex = pc1.SelectPageIndex
            Config.GridViewSorting(gvQuestionList, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pc1.Update(dt.Rows.Count)

            'For i As Integer = 0 To gvQuestionList.Rows.Count - 1
            '    gvQuestionList.Rows(i).Cells(0).Text = (gvQuestionList.PageIndex * gvQuestionList.PageSize) + (i + 1)
            'Next
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        Config.SaveTransLog("เคลียร์หน้าจอ")
        txtQuestion.Text = ""
        cmbPolicyServiceTypeID.SelectedValue = "0"
    End Sub
End Class
