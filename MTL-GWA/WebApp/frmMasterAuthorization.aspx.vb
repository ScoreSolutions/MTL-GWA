Imports System.Data
Imports Para.Common.Utilities
Imports Engine.Auth
Imports Engine.Common
Imports Para.Common

Partial Class WebApp_frmMasterAuthorization
    Inherits System.Web.UI.Page

    Const SessNoSelectGV As String = "SessNoSelectGV"
    Const SessSelectedGV As String = "SessSelectedGV"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลพื้นฐาน >> กำหนดสิทธิ์การใช้งาน"

        SetGridview()
    End Sub

    Private Sub SetGridview()
        Dim dt As New DataTable
        dt.Columns.Add("no")
        dt.Columns.Add("user_type_name")
        dt.Columns.Add("user_type_code")

        Dim dr As DataRow = dt.NewRow
        dr("no") = 1
        dr("user_type_name") = "HR"
        dr("user_type_code") = "H"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 2
        dr("user_type_name") = "Broker"
        dr("user_type_code") = "B"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 3
        dr("user_type_name") = "Agent"
        dr("user_type_code") = "A"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 4
        dr("user_type_name") = "Member"
        dr("user_type_code") = "M"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 5
        dr("user_type_name") = "Super User"
        dr("user_type_code") = "S"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 6
        dr("user_type_name") = "User"
        dr("user_type_code") = "U"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("no") = 7
        dr("user_type_name") = "Admin (IT)"
        dr("user_type_code") = "I"
        dt.Rows.Add(dr)

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "AuthList" Then
            Dim uType As String = e.CommandArgument
            Dim vTypeName As String = ""
            If uType = Constant.UserType.HR Then
                vTypeName = "HR"
            ElseIf uType = Constant.UserType.BROKER Then
                vTypeName = "Broker"
            ElseIf uType = Constant.UserType.MEMBER Then
                vTypeName = "Member"
            ElseIf uType = Constant.UserType.AGENT Then
                vTypeName = "Agent"
            ElseIf uType = Constant.UserType.SUPER_USER Then
                vTypeName = "Super User"
            ElseIf uType = Constant.UserType.USER Then
                vTypeName = "User"
            ElseIf uType = Constant.UserType.ADMIN Then
                vTypeName = "Admin (IT)"
            End If
            txtUserType.Text = uType
            lblHeader.Text = "สิทธิ์การใช้งานสำหรับ " & vTypeName
            SetNoSelectGV(uType)
            SetSelectedGV(uType)
            zPop.Show()
        End If
    End Sub

    Private Sub SetNoSelectGV(ByVal uType As String)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New AuthenENG
        Dim dt As DataTable = eng.GetMenuList("rs.id is null", "module_order_seq, menu_order_seq", uType, trans)
        If dt.Rows.Count > 0 Then
            gvNoSelect.DataSource = dt
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = dt
        Else
            gvNoSelect.DataSource = Nothing
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = Nothing
        End If
        trans.CommitTransaction()

    End Sub

    Private Sub SetSelectedGV(ByVal uType As String)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New AuthenENG
        Dim dt As DataTable = eng.GetMenuList("rs.id is not null", "module_order_seq, menu_order_seq", uType, trans)
        If dt.Rows.Count > 0 Then
            gvSelected.DataSource = dt
            gvSelected.DataBind()
            Session(SessSelectedGV) = dt
        Else
            gvSelected.DataSource = Nothing
            gvSelected.DataBind()
            Session(SessSelectedGV) = Nothing
        End If
        trans.CommitTransaction()
    End Sub
    Protected Sub chkH_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkH As CheckBox = sender
        Dim grv As GridViewRow = chkH.Parent.Parent
        Dim gv As GridView = grv.Parent.Parent
        For i As Integer = 0 To gv.Rows.Count - 1
            Dim chk As CheckBox = gv.Rows(i).Cells(0).FindControl("chk")
            chk.Checked = chkH.Checked
        Next

        zPop.Show()
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim dtS As DataTable = Session(SessSelectedGV)
        Dim dtN As DataTable = Session(SessNoSelectGV)

        If dtS Is Nothing Then
            dtS = New DataTable
            dtS.Columns.Add("module_id")
            dtS.Columns.Add("module_name")
            dtS.Columns.Add("menu_id")
            dtS.Columns.Add("menu_name")
        End If
        If dtN Is Nothing Then
            dtN = New DataTable
            dtN.Columns.Add("module_id")
            dtN.Columns.Add("module_name")
            dtN.Columns.Add("menu_id")
            dtN.Columns.Add("menu_name")
        End If


        'Add Row to dt
        For Each gv As GridViewRow In gvNoSelect.Rows
            Dim chk As CheckBox = gv.Cells(0).FindControl("chk")
            If chk.Checked Then
                Dim dr As DataRow = dtS.NewRow
                dr("module_id") = gv.Cells(3).Text
                dr("module_name") = gv.Cells(1).Text
                If gv.Cells(4).Text.Trim <> "&nbsp;" Then
                    dr("menu_id") = gv.Cells(4).Text
                    dr("menu_name") = gv.Cells(2).Text
                End If
                dtS.Rows.Add(dr)
            End If
        Next

        'Delete Selected Row
        For i As Integer = gvNoSelect.Rows.Count - 1 To 0 Step -1
            Dim chk As CheckBox = gvNoSelect.Rows(i).Cells(0).FindControl("chk")
            If chk.Checked Then
                dtN.Rows.RemoveAt(i)
            End If
        Next

        If dtS IsNot Nothing Then
            gvSelected.DataSource = dtS
            gvSelected.DataBind()
            Session(SessSelectedGV) = dtS
        Else
            gvSelected.DataSource = Nothing
            gvSelected.DataBind()
            Session(SessSelectedGV) = Nothing
        End If

        If dtN IsNot Nothing Then
            gvNoSelect.DataSource = dtN
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = dtN
        Else
            gvNoSelect.DataSource = Nothing
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = Nothing
        End If
        zPop.Show()
    End Sub

    Protected Sub btnNoSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoSelect.Click
        Dim dtN As DataTable = Session(SessNoSelectGV)
        Dim dtS As DataTable = Session(SessSelectedGV)

        If dtN Is Nothing Then
            dtN = New DataTable
            dtN.Columns.Add("module_id")
            dtN.Columns.Add("module_name")
            dtN.Columns.Add("menu_id")
            dtN.Columns.Add("menu_name")
        End If
        If dtS Is Nothing Then
            dtS = New DataTable
            dtS.Columns.Add("module_id")
            dtS.Columns.Add("module_name")
            dtS.Columns.Add("menu_id")
            dtS.Columns.Add("menu_name")
        End If

        For Each gv In gvSelected.Rows
            Dim chk As CheckBox = gv.Cells(0).FindControl("chk")
            If chk.Checked Then
                Dim dr As DataRow = dtN.NewRow
                dr("module_id") = gv.Cells(3).Text
                dr("module_name") = gv.Cells(1).Text
                If gv.Cells(4).Text.trim <> "&nbsp;" Then
                    dr("menu_id") = gv.Cells(4).Text
                    dr("menu_name") = gv.Cells(2).Text
                End If
                dtN.Rows.Add(dr)
            End If
        Next

        'Delete Selected Row
        For i As Integer = gvSelected.Rows.Count - 1 To 0 Step -1
            Dim chk As CheckBox = gvSelected.Rows(i).Cells(0).FindControl("chk")
            If chk.Checked Then
                dtS.Rows.RemoveAt(i)
            End If
        Next

        If dtS IsNot Nothing Then
            gvSelected.DataSource = dtS
            gvSelected.DataBind()
            Session(SessSelectedGV) = dtS
        Else
            gvSelected.DataSource = Nothing
            gvSelected.DataBind()
            Session(SessSelectedGV) = Nothing
        End If

        If dtN IsNot Nothing Then
            gvNoSelect.DataSource = dtN
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = dtN
        Else
            gvNoSelect.DataSource = Nothing
            gvNoSelect.DataBind()
            Session(SessNoSelectGV) = Nothing
        End If


        'Dim trans As New DbTrans
        'trans.CreateTransaction()

        'Dim ret As Boolean = True
        'Dim _err As String = ""
        'For Each gv As GridViewRow In gvSelected.Rows
        '    Dim chk As CheckBox = gv.Cells(0).FindControl("chk")
        '    If chk.Checked Then
        '        Dim eng As New AuthenENG
        '        ret = eng.DeleteMenuAuth(Convert.ToInt64(gv.Cells(5).Text), trans)
        '        If ret = False Then
        '            _err = eng.ErrorMessage
        '            Exit For
        '        End If
        '    End If
        'Next

        'If ret = True Then
        '    trans.CommitTransaction()
        '    SetNoSelectGV(txtUserType.Text)
        '    SetSelectedGV(txtUserType.Text)
        '    LogENG.SaveTransLog("ยกเลิกสิทธิ์การใช้งานของผู้ใช้", Config.GetLogOnUser)
        'Else
        '    trans.RollbackTransaction()
        '    LogENG.SaveErrorLog(_err, Config.GetLogOnUser)
        '    Config.SetAlert(_err, Me)
        'End If
        zPop.Show()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Dim dt As DataTable = Session(SessSelectedGV)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New AuthenENG
        If eng.SaveMenuAuth(Config.GetUserID, dt, txtUserType.Text.Trim, trans) = True Then
            trans.CommitTransaction()
            SetNoSelectGV(txtUserType.Text)
            SetSelectedGV(txtUserType.Text)
            LogENG.SaveTransLog("เพิ่มสิทธิ์การใช้งานให้กับผู้ใช้", Config.GetLogOnUser)
            Config.SetAlert("บันทึกข้อมูลเรียบร้อย (Save complete)", Me)
        Else
            trans.RollbackTransaction()
            LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
            Config.SetAlert(eng.ErrorMessage, Me)
        End If
        zPop.Show()
    End Sub
End Class
