Imports Resources
Imports Para.Common.Utilities
Imports System.Data
Imports Engine.GroupPolicy
Imports Para.CallWS
Imports Engine.Common
Imports Para.OutputWS
Imports Para.Common

Partial Class WebApp_frmGroupPolicySearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        txtGroupCode.Focus()

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลกรมธรรม์ >> ค้นหาข้อมูลบริษัทผู้เอาประกัน(Policy Search)"

        If IsPostBack = False Then
            '    SetGroupCodeCombo()
            SearchData()

            If Config.GetLogOnUser.USER_ID = "SYSTEM" Then
                btnQuery.Visible = True
            End If
        End If
    End Sub

    'Private Sub SetGroupCodeCombo()
    '    Dim eng As New WebServiceENG
    '    Dim oup As OutputGetUserJoinCasePara = Session(Constant.UserJoinCaseSession)
    '    If oup IsNot Nothing Then
    '        Dim dt As DataTable = eng.BuiltGroupCode(oup)
    '        If dt IsNot Nothing Then
    '            cmbGroupCode.SetItemList(dt, "grp_code", "grp_code")
    '        End If
    '    End If
    'End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'SetAllLabel()
        txtAccountCode.Text = ""
        txtAccountName.Text = ""
        txtPolicyNo.Text = ""
        'SetGroupCodeCombo()
        txtGroupCode.Text = ""
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        pc1.Visible = False
        lblDisplayData.Visible = False
    End Sub

    Const SessGroupPolicyList As String = "SessGroupPolicyList"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'If Valid() = True Then
        Config.SaveTransLog("ค้นหาข้อมูลบริษัท")
        Session.Remove(SessGroupPolicyList)

        ''Demo Data
        'Dim eng As New GroupPolicySearchENG
        'Dim dt As DataTable = eng.SearchFromWS(para)

        ''Call WebService
        'Dim para As New InputGetQueryAccountPara
        'para.USER_ID = Config.GetUserID
        'para.GROUP_CODE = cmbGroupCode.SelectedValue
        'para.POLICY_NO = txtPolicyNo.Text
        'para.ACCOUNT_CODE = txtAccountCode.Text
        'para.ACCOUNT_NAME = txtAccountName.Text
        'Dim eng As New WebServiceENG
        'Dim dt As DataTable = eng.GetQueryAccount(para)
        'If dt IsNot Nothing Then
        '    Config.BuildNoColumn(dt)
        '    Session(SessGroupPolicyList) = dt
        '    pc1.Visible = True
        '    pc1.SetMainGridView(GridView1)
        '    GridView1.DataSource = dt
        '    GridView1.DataBind()
        '    pc1.Update(dt.Rows.Count)
        'Else
        '    GridView1.DataSource = Nothing
        '    GridView1.DataBind()
        '    pc1.Visible = False
        '    Engine.Common.LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
        '    Config.SetAlert(eng.ErrorMessage, Me)
        'End If

        SearchData()

    End Sub

    Private Sub SearchData()
        ''Call Session
        'Dim eng As New WebServiceENG
        If Session(Constant.UserJoinCaseSession) IsNot Nothing Then
            Dim whText As String = "1=1 "
            If txtGroupCode.Text.Trim <> "" Then
                whText += " and grp_code like '%" & txtGroupCode.Text.Trim & "%' "
            End If
            If txtPolicyNo.Text.Trim <> "" Then
                whText += " and pol_no like '%" & txtPolicyNo.Text.Trim & "%' "
            End If
            If txtAccountCode.Text.Trim <> "" Then
                whText += " and account_code like '%" & txtAccountCode.Text.Trim & "%' "
            End If
            If txtAccountName.Text.Trim <> "" Then
                whText += " and account_name like '%" & txtAccountName.Text.Trim & "%' "
            End If

            Dim output As New OutputGetUserJoinCasePara
            output = Session(Constant.UserJoinCaseSession)
            If output.ISFOUND_CASE = "Y" Then
                Dim dt As New DataTable
                If output.OUT_CASE_LIST IsNot Nothing Then
                    dt = output.OUT_CASE_LIST
                    dt.DefaultView.RowFilter = whText
                    dt = dt.DefaultView.ToTable
                    Config.BuildNoColumn(dt)
                    Session(SessGroupPolicyList) = dt
                    pc1.Visible = True
                    pc1.SetMainGridView(GridView1)

                    If dt.Rows.Count > 0 Then
                        lblDisplayData.Visible = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        pc1.Update(dt.Rows.Count)
                    Else
                        lblDisplayData.Visible = False
                        GridView1.DataSource = Nothing
                        GridView1.DataBind()
                        pc1.Visible = False
                        Config.SetAlert("ไม่พบข้อมูลที่ค้นหา \r\n ( Data not found. )", Me)
                    End If
                Else
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                    pc1.Visible = False
                    lblDisplayData.Visible = False
                    'Engine.Common.LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                    'Config.SetAlert(eng.ErrorMessage, Me)
                    If IsPostBack = True Then
                        Engine.Common.LogENG.SaveErrorLog("Session has expired", Config.GetLogOnUser)
                        Config.SetAlert("Session has expired", Me)
                    End If
                End If
            Else
                Engine.Common.LogENG.SaveErrorLog("frmGroupPolicySearch_SearchData_ไม่พบข้อมูลที่ค้นหา", Config.GetLogOnUser)
                If IsPostBack = True Then
                    Config.SetAlert("ไม่พบข้อมูลที่ค้นหา \r\n ( Data not found. )", Me)
                End If
            End If
        Else
            Engine.Common.LogENG.SaveErrorLog("frmGroupPolicySearch_SearchData_ Session Constant.UserJoinCaseSession Expire", Config.GetLogOnUser)
        End If
    End Sub

    Protected Sub GetAccountDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim keyID() As String = Split(sender.CommandArgument.ToString, "##")
        Dim dt As DataTable = Session(SessGroupPolicyList)
        dt.DefaultView.RowFilter = "CommandArgument = '" & sender.CommandArgument & "'"
        Dim dr As DataRowView = dt.DefaultView(0)
        Session("GetAccountDetailPara") = dr

        Response.Redirect("frmGroupPolicyForm.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub pc1_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pc1.PageChange
        Dim dt As New DataTable
        dt = Session(SessGroupPolicyList)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pc1.SelectPageIndex
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
            For i As Integer = 0 To GridView1.Rows.Count - 1
                GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
            Next
        End If
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessGroupPolicyList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Response.Redirect("../Test/frmQuery.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
