Imports System.Data
Imports Engine.UserProfile
Imports Para.Common
Imports Para.Common.Utilities

Partial Class WebApp_frmUsersLoginHistory
    Inherits System.Web.UI.Page
    Const SessHistoryList As String = "SessHistoryList"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Dim dt As New DataTable
        'dt.Columns.Add("login_date")
        'dt.Columns.Add("login_time")
        'dt.Columns.Add("logout_time")

        'For i As Integer = 0 To 5
        '    Dim dr As DataRow = dt.NewRow
        '    dr("login_date") = Today.ToString("dd/MM/yyyy")
        '    dr("login_time") = Today.Now.ToString("HH:mm")
        '    dr("logout_time") = Today.Now.ToString("HH:mm")
        '    dt.Rows.Add(dr)
        'Next

        Config.SaveTransLog("ค้นหาประวัติการเข้าใช้งาน")
        Session.Remove(SessHistoryList)
        If txtUserID.Text.Trim <> "" Then
            Dim uPara As UserProfilePara = Config.GetLogOnUser()
            Dim sql As String = " select user_id, login_time login_date, login_time, logout_time "
            sql += " from login_history "
            sql += " where user_id = '" & txtUserID.Text.Trim & "'"
            If txtDateFrom.DateValue.Year <> 1 Then
                sql += " and convert(varchar(10),login_time,112) >= '" & txtDateFrom.GetDateCondition & "'"
            End If
            If txtDateTo.DateValue.Year <> 1 Then
                sql += " and convert(varchar(10),login_time,112) <= '" & txtDateTo.GetDateCondition & "'"
            End If
            sql += " order by login_time desc"

            Dim eng As New LoginHistoryENG
            Dim dt As DataTable = eng.GetLoginHistory(sql)

            If dt.Rows.Count > 0 Then
                Config.BuildNoColumn(dt)
                Session(SessHistoryList) = dt
                GridView1.PageSize = 20
                GridView1.PageIndex = 0
                pcTop.SetMainGridView(GridView1)
                GridView1.DataSource = dt
                GridView1.DataBind()
                pcTop.Update(dt.Rows.Count)
                lblDisplayData.Visible = True
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                pcTop.Visible = False
                lblDisplayData.Visible = False
                Config.SetAlert("ไม่พบข้อมูล (No data found)", Me, txtUserID.ClientID)
            End If
        Else
            Config.SetAlert("กรุณาระบุ User ID", Me, txtUserID.ClientID)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลส่วนตัว >> ประวัติการเข้าใช้งาน(Login History)"

        txtUserID.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        If Config.ChkPermit(Request.QueryString("menuID")) = False Then
            Response.Redirect("../frmLogin.aspx")
        Else
            If IsPostBack = False Then
                Dim vUserType As String = Config.GetLogOnUser.USER_PARA.USER_TYPE
                Select Case vUserType
                    Case Constant.UserType.HR, Constant.UserType.BROKER, Constant.UserType.AGENT, Constant.UserType.MEMBER, Constant.UserType.USER, Constant.UserType.SUPER_USER
                        txtUserID.Visible = False
                        lblUserID1.Visible = True
                    Case Else
                        txtUserID.Visible = True
                        lblUserID1.Visible = False
                End Select
                txtUserID.Text = Config.GetUserID
                lblUserID1.Text = Config.GetUserID
            End If
        End If

    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessHistoryList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = Session(SessHistoryList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        txtDateFrom.DateValue = New Date()
        txtDateTo.DateValue = New Date()

        Dim vUserType As String = Config.GetLogOnUser.USER_PARA.USER_TYPE
        Select Case vUserType
            Case Constant.UserType.HR, Constant.UserType.BROKER, Constant.UserType.AGENT, Constant.UserType.MEMBER, Constant.UserType.USER, Constant.UserType.SUPER_USER
                txtUserID.Visible = False
                lblUserID1.Visible = True
            Case Else
                txtUserID.Visible = True
                lblUserID1.Visible = False
        End Select
        txtUserID.Text = Config.GetUserID
        lblUserID1.Text = Config.GetUserID
        lblDisplayData.Visible = False
        pcTop.Visible = False
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Config.SaveTransLog("คลิกปุ่มยกเลิก")

    End Sub
End Class
