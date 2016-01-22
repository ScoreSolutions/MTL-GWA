Imports Engine.FAQ
Imports System.Data
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmFAQPreview
    Inherits System.Web.UI.Page

    Const SessSearchQuestionList As String = "SessSearchQuestionList"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim uPara As UserProfilePara = Config.GetLogOnUser
        If uPara.USER_PARA Is Nothing Then
            Response.Redirect("frmLogin.aspx")
        End If

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "คำถามที่พบบ่อย(Frequency Asked Questions)"

        If IsPostBack = False Then
            If Request("ShowSearch") = "Y" Then
                likMoreQuestion_Click(sender, e)
            Else
                SetTabDisable()
                btnTabPolicyService.ActiveTab = True
                SetPolicyService(Constant.PolicyServiceType.POLICY)
            End If
        End If
    End Sub
    Private Sub SetPolicyService(ByVal vServiceTypeID As Long)
        Dim ret As String = ""
        ret += "<div class='arrowlistmenu' align='left' style='width:100%' >"
        Dim eng As New FAQFormENG
        Dim dt As DataTable = eng.GetFAQPreviewList(vServiceTypeID)
        Dim dtF As DataTable = eng.GetFAQFile()
        ret += "    <table border='0' cellpadding='0' cellspacing='0' width='100%' >"
        If dt.Rows.Count > 0 Then
            Dim j As Integer = 0
            For Each dr As DataRow In dt.Rows
                If j Mod 2 = 0 Then
                    ret += "    <tr>"
                Else
                    ret += "    <tr style='background-color: #E8E8E8;'>"
                End If
                ret += "    <td>"
                ret += "        <table border='0' cellpadding='5' cellspacing='0' width='100%' >"
                ret += "            <tr>"
                ret += "                <td width='10px'>&nbsp;</td>"
                ret += "                <td style='color: #2f3e74;font-weight:bold;'>Q " & dr("question") & "</td>"
                ret += "            </tr>"
                ret += "            <tr>"
                ret += "                <td width='10px'>&nbsp;</td>"
                ret += "                <td style='color: #ec008c;' >"
                ret += "                    &nbsp;&nbsp;"
                ret += "                    A " & dr("answer") & "<br />"
                dtF.DefaultView.RowFilter = "faq_id = " & dr("id")
                If dtF.DefaultView.Count > 0 Then
                    ret += "        <b><font color='blue'>เอกสารแนบ&nbsp;</font></b>"
                    For i As Integer = 0 To dtF.DefaultView.Count - 1
                        Dim drF As DataRowView = dtF.DefaultView.Item(i)
                        ret += "        <a href='" & Config.GetFileURL(Request) & Constant.FilePrefix.FAQ & drF("id") & drF("file_ext") & "' target='_blank' >" & drF("file_desc") & ";</a>&nbsp;"
                    Next
                End If
                ret += "                </td>"
                ret += "            </tr>"
                ret += "        </table>"
                ret += "    <br />"
                ret += "    </td>"
                ret += "    </tr>"
                j += 1
            Next
        Else
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr>"
            ret += "            <td align='center' >อยู่ระหว่างการปรับปรุง (Under Construction)</td>"
            ret += "        </tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
        End If
        ret += "    </table>"
        ret += "</div>"
        lblFAQList.Text = ret
    End Sub

    Protected Sub btnTabPolicyService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabPolicyService.Click
        SetTabDisable()
        btnTabPolicyService.ActiveTab = True
        SetPolicyService(Constant.PolicyServiceType.POLICY)
        Config.SaveTransLog("แสดงแท็บ บริการกรมธรรม์")
    End Sub

    Private Sub SetTabDisable()
        btnTabHealthClaimService.ActiveTab = False
        btnTabLifeClaimService.ActiveTab = False
        btnTabPolicyService.ActiveTab = False
    End Sub

    Protected Sub btnTabHealthClaimService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabHealthClaimService.Click
        SetTabDisable()
        btnTabHealthClaimService.ActiveTab = True
        SetPolicyService(Constant.PolicyServiceType.HEALTH)
        Config.SaveTransLog("แสดงแท็บ บริการสินไหมประกันสุขภาพ")
    End Sub

    Protected Sub btnTabLifeClaimService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabLifeClaimService.Click
        SetTabDisable()
        btnTabLifeClaimService.ActiveTab = True
        SetPolicyService(Constant.PolicyServiceType.LIFE)
        Config.SaveTransLog("แสดงแท็บ บริการสินไหมประกันชีวิต")
    End Sub

    Protected Sub GetQuestionDetail(ByVal sender As Object, ByVal e As EventArgs)

        Dim lik As LinkButton = sender
        Dim grv As GridViewRow = lik.Parent.Parent
        Config.SaveTransLog("แสดงรายละเอียด FAQ ID=" & grv.Cells(0).Text)
        Response.Redirect("frmFAQDetail.aspx?id=" & grv.Cells(0).Text & "&rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub likMoreQuestion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likMoreQuestion.Click
        lblFAQList.Visible = False
        likMoreQuestion.Visible = False
        pnlMoreQuestion.Visible = True
        trTab.Visible = False
        tbMain.Attributes.Remove("class")
        tbMain.Style.Clear()

        Dim fnc As New FAQFormENG
        cmbPolicyServiceTypeID.SetItemList(fnc.GetServiceTypeList(), "policy_service_name", "id")

        SetQuestionList()
        Config.SaveTransLog("คลิกปุ่ม More Question")
    End Sub

    Private Sub SetQuestionList()
        Dim eng As New FAQFormENG
        Dim dt As DataTable = eng.GetFaqSearch(cmbPolicyServiceTypeID.SelectedValue, txtQuestion.Text, "Y")
        If dt.Rows.Count > 0 Then
            Session(SessSearchQuestionList) = dt
            pcTop.Visible = True
            pcTop.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            pcTop.Visible = False
            gvQuestionList.DataSource = Nothing
            gvQuestionList.DataBind()
            Session(SessSearchQuestionList) = Nothing
            lblDisplayData.Visible = False
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        tbMain.Attributes.Remove("class")
        SetQuestionList()
        Config.SaveTransLog("ค้นหารายการ FAQ")
    End Sub

    'Protected Sub gvQuestionList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuestionList.Sorted
    '    For i As Integer = 0 To gvQuestionList.Rows.Count - 1
    '        gvQuestionList.Rows(i).Cells(0).Text = (gvQuestionList.PageIndex * gvQuestionList.PageSize) + (i + 1)
    '    Next
    'End Sub

    Protected Sub gvQuestionList_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvQuestionList.Sorting
        Dim dt As New DataTable
        dt = Session(SessSearchQuestionList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(gvQuestionList, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        tbMain.Attributes.Remove("class")
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = Session(SessSearchQuestionList)
        If dt.Rows.Count > 0 Then
            gvQuestionList.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(gvQuestionList)
            gvQuestionList.DataSource = dt
            gvQuestionList.DataBind()
            pcTop.Update(dt.Rows.Count)

            'For i As Integer = 0 To gvQuestionList.Rows.Count - 1
            '    gvQuestionList.Rows(i).Cells(0).Text = (gvQuestionList.PageIndex * gvQuestionList.PageSize) + (i + 1)
            'Next
        End If
        tbMain.Attributes.Remove("class")
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        txtQuestion.Text = ""
        cmbPolicyServiceTypeID.SelectedValue = "0"
        tbMain.Attributes.Remove("class")
        Config.SaveTransLog("คลิกปุ่ม ยกเลิก")
    End Sub
End Class
