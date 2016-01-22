Imports Engine.Common
Imports Engine.UserProfile
Imports System.Data
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmMasterUsersSearch
    Inherits System.Web.UI.Page
    Const SessUsersList As String = "SessUsersList"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลพื้นฐาน >> รายชื่อผู้ใช้ระบบ"

        If IsPostBack = False Then
            cmbUserType.SetItemList("(Select)", "0")
            cmbUserType.SetItemList("HR", "H")
            cmbUserType.SetItemList("Broker", "B")
            cmbUserType.SetItemList("Agent", "A")
            cmbUserType.SetItemList("Member", "M")
            cmbUserType.SetItemList("Super User", "S")
            cmbUserType.SetItemList("User", "U")
            cmbUserType.SetItemList("Admin (IT)", "I")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchData()
        Config.SaveTransLog("ค้นหาข้อมูลผู้ใช้งานระบบ")
    End Sub

    Private Sub SearchData()
        Dim eng As New UsersENG
        Dim dt As DataTable = eng.SearchUsers(txtUserID.Text, cmbUserType.SelectedValue, ctlBrokerCode1.BrokerCode, ctlAccountCode1.AccountCode, txtUserNameThai.Text, txtUserNameEng.Text)
        If dt.Rows.Count > 0 Then
            Session(SessUsersList) = dt
            Config.BuildNoColumn(dt)
            pc1.Visible = True
            lblDisplayData.Visible = True
            pc1.SetMainGridView(gvUsersList)
            SetUserTypeDesc(dt)
            gvUsersList.DataSource = dt
            gvUsersList.DataBind()
            pc1.Update(dt.Rows.Count)
        Else
            pc1.Visible = False
            gvUsersList.DataSource = Nothing
            gvUsersList.DataBind()
            lblDisplayData.Visible = False
            pc1.Visible = False
        End If
    End Sub

    Protected Sub gvUsersList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvUsersList.Sorted
        For i As Integer = 0 To gvUsersList.Rows.Count - 1
            gvUsersList.Rows(i).Cells(1).Text = (gvUsersList.PageIndex * gvUsersList.PageSize) + (i + 1)
        Next
    End Sub

    Private Sub SetUserTypeDesc(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("user_type") = Config.GetUserTypeDesc(dt.Rows(i)("user_type").ToString)
            Next
        End If
    End Sub

    Protected Sub UsersList_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lik As LinkButton = sender
        Dim grv As GridViewRow = lik.Parent.Parent

        If Config.ChkPermit(15) = True Then
            Response.Redirect("../WebApp/frmMasterUsersForm.aspx?id=" & grv.Cells(0).Text & "&menuID=25" & "&rnd=" & DateTime.Now.Millisecond)
        Else
            Response.Redirect("frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond)
        End If

    End Sub

    Protected Sub DeleteUser_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent

        Dim eng As New UsersENG
        If eng.DeleteUserProfile(Convert.ToInt64(grv.Cells(0).Text)) = False Then
            Config.SetAlert(eng.ErrorMessage, Me, txtUserID.ClientID)
            'Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
            Config.SaveErrorLog(eng.ErrorMessage)
        Else
            SearchData()
        End If
    End Sub

    Protected Sub gvUsersList_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvUsersList.Sorting
        Dim dt As New DataTable
        dt = Session(SessUsersList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(gvUsersList, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(gvUsersList)
            gvUsersList.DataSource = dt
            gvUsersList.DataBind()
            pc1.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub pc1_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pc1.PageChange
        Dim dt As New DataTable
        dt = Session(SessUsersList)
        If dt.Rows.Count > 0 Then
            gvUsersList.PageIndex = pc1.SelectPageIndex
            pc1.SetMainGridView(gvUsersList)
            gvUsersList.DataSource = dt
            gvUsersList.DataBind()
            pc1.Update(dt.Rows.Count)

            For i As Integer = 0 To gvUsersList.Rows.Count - 1
                gvUsersList.Rows(i).Cells(1).Text = (gvUsersList.PageIndex * gvUsersList.PageSize) + (i + 1)
            Next
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        txtSortDir.Text = ""
        txtSortField.Text = ""
        txtUserID.Text = ""
        ctlBrokerCode1.SetBroker("", "")
        ctlAccountCode1.SetAccount("", "")
        cmbUserType.SelectedValue = "0"
        txtUserNameEng.Text = ""
        txtUserNameThai.Text = ""
        lblDisplayData.Visible = False
        pc1.Visible = False
        gvUsersList.DataSource = Nothing
        gvUsersList.DataBind()
    End Sub
End Class
