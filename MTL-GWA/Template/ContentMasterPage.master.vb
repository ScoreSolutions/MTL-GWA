Imports Engine.Common
Imports Para.Common
Imports Para.Common.Utilities
Imports Engine.Auth
Imports Para.OutputWS
Imports System.Data

Partial Class Template_ContentMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub btnChangeLangEN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeLangEN.Click
        ChangeLangEN()
        Dim uPara As UserProfilePara = Config.GetLogOnUser
        lblUser.Text = uPara.USER_PARA.USER_NAME_E
        lblLastLogin.Text = "Latest Login : " & uPara.USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy HH:mm")
    End Sub
    Protected Sub btnChangeLangTH_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnChangeLangTH.Click
        ChangeLangTH()
        Dim uPara As UserProfilePara = Config.GetLogOnUser
        lblUser.Text = uPara.USER_PARA.USER_NAME_T
        lblLastLogin.Text = "คุณใช้งานล่าสุดเมื่อ : " & uPara.USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy HH:mm")
    End Sub

    Private Sub ChangeLangEN()
        MessageResources.CultureName = Constant.CultureName.Eng
        'btnChangeLangEN.Enabled = False
        SetMenuList(True)
    End Sub
    Private Sub ChangeLangTH()
        MessageResources.CultureName = Constant.CultureName.Thai
        'btnChangeLangTH.Enabled = False
        SetMenuList(True)
    End Sub

    Protected Sub likEN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likEN.Click
        ChangeLangEN()
        Dim uPara As UserProfilePara = Config.GetLogOnUser
        lblUser.Text = uPara.USER_PARA.USER_NAME_E
        lblLastLogin.Text = "Latest Login : " & uPara.USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy HH:mm")
    End Sub

    Protected Sub likTH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likTH.Click
        ChangeLangTH()
        Dim uPara As UserProfilePara = Config.GetLogOnUser
        lblUser.Text = uPara.USER_PARA.USER_NAME_T
        lblLastLogin.Text = "คุณใช้งานล่าสุดเมื่อ : " & uPara.USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy HH:mm")
    End Sub

    Public Sub SetMenuList(ByVal IsGetNew As Boolean)
        
        Dim uData As New OutputGetUserProfilePara
        If IsGetNew = True Then
            lblMenu.Text = GetModuleList(uData)
            Session(Constant.UserMenuSession) = lblMenu.Text
        Else
            If Session(Constant.UserMenuSession) IsNot Nothing Then
                lblMenu.Text = Session(Constant.UserMenuSession)
            Else
                lblMenu.Text = GetModuleList(uData)
                Session(Constant.UserMenuSession) = lblMenu.Text
            End If
        End If
    End Sub


    Public Function GetModuleList(ByVal inp As OutputGetUserProfilePara) As String
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim ret As String = ""

        Dim eng As New LogInENG
        Dim dtM As DataTable = eng.GetModuleList("rs.user_type= '" & Config.GetLogOnUser.USER_PARA.USER_TYPE & "' and m.active = 'Y' and rs.active='Y' ", trans)

        ret += "<table border='0' cellpadding='0' cellspacing='0'  >" & vbNewLine
        ret += "    <tr style='height:24px;'>" & vbNewLine
        ret += "        <td nowrap='nowrap' vlign='middle' > " & vbNewLine
        ret += "            <div class='navbar' style='overflow:none'>" & vbNewLine
        ret += "                <ul id='nav'>" & vbNewLine
        Dim dtS As DataTable = eng.GetScreenList("1=1", trans)
        If dtM.Rows.Count > 0 Then
            For Each drM As DataRow In dtM.Rows
                If MessageResources.CultureName = Constant.CultureName.Eng Then
                    'Englist Menu
                    If IsDBNull(drM("SCREEN_ID")) = False Then
                        dtS.DefaultView.RowFilter = "id=" & drM("SCREEN_ID")
                        If dtS.DefaultView.Count > 0 Then
                            Dim drS As DataRowView = dtS.DefaultView(0)
                            ret += "                <li><a id='MODULE_" & drM("MODULE_CODE") & "' href='" & drS("SCREEN_URL") & "?rnd=" & DateTime.Now.Millisecond & "' title='" & drM("MODULE_DESC_ENG") & "' OnClick=""SaveTransLog(" & Chr(39) & "โมดูล" & drM("MODULE_NAME_ENG") & Chr(39) & ");"" >" & vbNewLine
                            ret += "                        " & drM("MODULE_NAME_ENG") & vbNewLine
                            ret += "                    </a>" & vbNewLine
                        End If
                    Else
                        ret += "                <li><a href='#' >" & drM("MODULE_NAME_ENG") & "</a>" & vbNewLine
                    End If
                    ret += "                " + GetMenuList(drM("id"), 0, trans)
                    ret += "                </li>" & vbNewLine
                Else
                    'Thai Menu
                    If IsDBNull(drM("SCREEN_ID")) = False Then
                        dtS.DefaultView.RowFilter = "id=" & drM("SCREEN_ID")
                        If dtS.DefaultView.Count > 0 Then
                            Dim drS As DataRowView = dtS.DefaultView(0)
                            ret += "                <li><a id='MODULE_" & drM("MODULE_CODE") & "' href='" & drS("SCREEN_URL") & "?rnd=" & DateTime.Now.Millisecond & "' title='" & drM("MODULE_DESC_THAI") & "' OnClick=""SaveTransLog(" & Chr(39) & "โมดูล" & drM("MODULE_NAME_THAI") & Chr(39) & ");"" >" & vbNewLine
                            ret += "                        " & drM("MODULE_NAME_THAI") & vbNewLine
                            ret += "                    </a>" & vbNewLine
                        End If
                    Else
                        ret += "                <li><a href='#' >" & drM("MODULE_NAME_THAI") & "</a>" & vbNewLine
                    End If

                    ret += "                " + GetMenuList(drM("id"), 0, trans)
                    ret += "                </li>" & vbNewLine
                End If
            Next
        Else
            ret += ""
        End If

        If MessageResources.CultureName = Constant.CultureName.Eng Then
            ret += "                    <li><a id='module_logout' href='../WebApp/frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond & "' title='Logout' OnClick=""SaveTransLog(" & Chr(39) & "Logout" & Chr(39) & ");"" >Logout</a></li>" & vbNewLine
        Else
            ret += "                    <li><a id='module_logout' href='../WebApp/frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond & "' title='ออกจากระบบ' OnClick=""SaveTransLog(" & Chr(39) & "ออกจากระบบ" & Chr(39) & ");"" >ออกจากระบบ</a></li>" & vbNewLine
        End If
        ret += "                </ul>" & vbNewLine
        ret += "            </div>" & vbNewLine
        ret += "        </td>" & vbNewLine
        ret += "    </tr>" & vbNewLine
        ret += "</table>" & vbNewLine

        trans.CommitTransaction()

        Return ret
    End Function

    Private Function GetMenuList(ByVal ModuleID As Long, ByVal RefMenuID As Long, ByVal trans As Engine.Common.DbTrans) As String
        Dim ret As String = ""
        Dim eng As New LogInENG
        Dim dtE As DataTable = eng.GetMenuList("ml.module_id = " & ModuleID & " and ml.ref_menu_id = " & RefMenuID & " and rs.user_type = '" & Config.GetLogOnUser.USER_PARA.USER_TYPE & "'" & " and ml.menu_active='Y' ", trans)

        Dim dtS As DataTable = eng.GetScreenList("1=1", trans)
        If dtE.Rows.Count > 0 Then
            ret += "<ul>" & vbNewLine
            For Each drE As DataRow In dtE.Rows
                dtS.DefaultView.RowFilter = "id=" & drE("SCREEN_MENU_ID")
                If dtS.DefaultView.Count > 0 Then
                    Dim drS As DataRowView = dtS.DefaultView(0)
                    ret += "<li>" & vbNewLine
                    If RefMenuID <> 0 Then
                        If MessageResources.CultureName = Constant.CultureName.Eng Then
                            ret += "    <a id='MENU_" & drE("menu_code") & "' class='fly' " & IIf(drE("module_id").ToString = 10, "target='_blank'", "") & " href='" & drS("SCREEN_URL") & "?menuID=" & drE("menu_id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_eng") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_eng") & Chr(39) & ");"" >" & drE("menu_name_eng") & "</a>" & vbNewLine
                        Else
                            ret += "    <a id='MENU_" & drE("menu_code") & "' class='fly' " & IIf(drE("module_id").ToString = 10, "target='_blank'", "") & " href='" & drS("SCREEN_URL") & "?menuID=" & drE("menu_id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_thai") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_thai") & Chr(39) & ");"" >" & drE("menu_name_thai") & "</a>" & vbNewLine
                        End If
                    Else
                        If MessageResources.CultureName = Constant.CultureName.Eng Then
                            ret += "    <a id='MENU_" & drE("menu_code") & "' class='fly break' " & IIf(drE("module_id").ToString = 10, "target='_blank'", "") & " href='" & drS("SCREEN_URL") & "?menuID=" & drE("menu_id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_eng") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_eng") & Chr(39) & ");"" >" & drE("menu_name_eng") & "</a>" & vbNewLine
                        Else
                            ret += "    <a id='MENU_" & drE("menu_code") & "' class='fly break' " & IIf(drE("module_id").ToString = 10, "target='_blank'", "") & " href='" & drS("SCREEN_URL") & "?menuID=" & drE("menu_id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_thai") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_thai") & Chr(39) & ");"" >" & drE("menu_name_thai") & "</a>" & vbNewLine
                        End If
                    End If
                    ret += "    " + GetMenuList(ModuleID, drE("menu_id"), trans)
                    ret += "</li>" & vbNewLine
                End If
            Next
            ret += "</ul>" & vbNewLine
        End If
        Return ret
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uPara As UserProfilePara = Config.GetLogOnUser
        If uPara.USER_ID <> "SYSTEM" Then
            If CType(Session(Constant.UserJoinCaseSession), Para.OutputWS.OutputGetUserJoinCasePara).ISFOUND_CASE = "" Then
                'If Config.GetUserID Is Nothing Then
                Response.Redirect("../WebApp/frmLogin.aspx?rnd=" & DateTime.Now.Millisecond)
            End If
        End If
        If IsPostBack = False Then
            'Dim uPara As UserProfilePara = Config.GetLogOnUser
            If uPara.USER_PARA IsNot Nothing Then
                ' set lblUser to Eng And Thai
                lblUser.Text = uPara.USER_PARA.USER_NAME_T
                lblLastLogin.Text = "คุณใช้งานล่าสุดเมื่อ : " & uPara.USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy HH:mm")
            Else
                Response.Redirect("../WebApp/frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond)
            End If
            SetMenuList(False)
        End If
    End Sub


    'Public Function GetModuleList(ByVal inp As OutputGetUserProfilePara) As String
    '    Dim trans As New DbTrans
    '    trans.CreateTransaction()
    '    Dim ret As String = ""

    '    Dim eng As New LogInENG
    '    Dim dtM As DataTable = eng.GetModuleList("active = 'Y' ", trans)

    '    Dim dtS As DataTable = eng.GetScreenList("1=1", trans)
    '    If dtM.Rows.Count > 0 Then
    '        'ret += "<table border='0' cellpadding='0' cellspacing='0'  >" & vbNewLine
    '        'ret += "    <tr style='height:24px;'>" & vbNewLine
    '        'ret += "        <td nowrap='nowrap' vlign='middle' > " & vbNewLine
    '        ret += "            <div id='ja-mainnav' >" & vbNewLine
    '        ret += "                <ul id='ja-cssmenu' class='clearfix' >" & vbNewLine
    '        For Each drM As DataRow In dtM.Rows
    '            If MessageResources.CultureName = Constant.CultureName.Eng Then
    '                'Englist Menu
    '                If IsDBNull(drM("SCREEN_ID")) = False Then
    '                    dtS.DefaultView.RowFilter = "id=" & drM("SCREEN_ID")
    '                    If dtS.DefaultView.Count > 0 Then
    '                        Dim drS As DataRowView = dtS.DefaultView(0)
    '                        ret += "                <li><a id='MODULE_" & drM("MODULE_CODE") & "' href='" & drS("SCREEN_URL") & "?rnd=" & DateTime.Now.Millisecond & "' title='" & drM("MODULE_DESC_ENG") & "' OnClick=""SaveTransLog(" & Chr(39) & "โมดูล" & drM("MODULE_NAME_ENG") & Chr(39) & ");"" >" & vbNewLine
    '                        ret += "                        <span class='menu-title' >" & drM("MODULE_NAME_ENG") & "</span>" & vbNewLine
    '                        ret += "                    </a>" & vbNewLine
    '                    End If
    '                Else
    '                    ret += "                <li><a href='#' ><span class='menu-title' >" & drM("MODULE_NAME_ENG") & "</span></a>" & vbNewLine
    '                End If
    '                ret += "                " + GetMenuList(drM("id"), 0, trans)
    '                ret += "                </li>" & vbNewLine
    '            Else
    '                'Thai Menu
    '                If IsDBNull(drM("SCREEN_ID")) = False Then
    '                    dtS.DefaultView.RowFilter = "id=" & drM("SCREEN_ID")
    '                    If dtS.DefaultView.Count > 0 Then
    '                        Dim drS As DataRowView = dtS.DefaultView(0)
    '                        ret += "                <li><a id='MODULE_" & drM("MODULE_CODE") & "' href='" & drS("SCREEN_URL") & "?rnd=" & DateTime.Now.Millisecond & "' title='" & drM("MODULE_DESC_THAI") & "' OnClick=""SaveTransLog(" & Chr(39) & "โมดูล" & drM("MODULE_NAME_THAI") & Chr(39) & ");"" >" & vbNewLine
    '                        ret += "                        <span class='menu-title' >" & drM("MODULE_NAME_THAI") & "</span>" & vbNewLine
    '                        ret += "                    </a>" & vbNewLine
    '                    End If
    '                Else
    '                    ret += "                <li><a href='#' ><span class='menu-title' >" & drM("MODULE_NAME_THAI") & "</span></a>" & vbNewLine
    '                End If

    '                ret += "                " + GetMenuList(drM("id"), 0, trans)
    '                ret += "                </li>" & vbNewLine
    '            End If
    '        Next
    '        If MessageResources.CultureName = Constant.CultureName.Eng Then
    '            ret += "                    <li><a id='module_logout' href='frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond & "' title='Logout' OnClick=""SaveTransLog(" & Chr(39) & "Logout" & Chr(39) & ");"" >Logout</a></li>" & vbNewLine
    '        Else
    '            ret += "                    <li><a id='module_logout' href='frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond & "' title='ออกจากระบบ' OnClick=""SaveTransLog(" & Chr(39) & "ออกจากระบบ" & Chr(39) & ");"" >ออกจากระบบ</a></li>" & vbNewLine
    '        End If

    '        ret += "                </ul>" & vbNewLine
    '        ret += "            </div>" & vbNewLine
    '        'ret += "        </td>" & vbNewLine
    '        'ret += "    </tr>" & vbNewLine
    '        'ret += "</table>" & vbNewLine
    '    Else
    '        ret = "&nbsp;"
    '    End If
    '    trans.CommitTransaction()

    '    Return ret
    'End Function
    'Private Function GetMenuList(ByVal ModuleID As Long, ByVal RefMenuID As Long, ByVal trans As Engine.Common.DbTrans) As String
    '    Dim ret As String = ""
    '    Dim eng As New LogInENG
    '    Dim dtE As DataTable = eng.GetMenuList("module_id = " & ModuleID & " and ref_menu_id = " & RefMenuID & " and active='Y' ", trans)

    '    Dim dtS As DataTable = eng.GetScreenList("1=1", trans)
    '    If dtE.Rows.Count > 0 Then
    '        ret += "<ul>" & vbNewLine
    '        For Each drE As DataRow In dtE.Rows
    '            dtS.DefaultView.RowFilter = "id=" & drE("SCREEN_ID")
    '            If dtS.DefaultView.Count > 0 Then
    '                Dim drS As DataRowView = dtS.DefaultView(0)
    '                ret += "<li>" & vbNewLine
    '                If RefMenuID <> 0 Then
    '                    If MessageResources.CultureName = Constant.CultureName.Eng Then
    '                        ret += "    <a id='MENU_" & drE("menu_code") & "' href='" & drS("SCREEN_URL") & "?menuID=" & drE("id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_eng") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_eng") & Chr(39) & ");"" >" & drE("menu_name_eng") & "</a>" & vbNewLine
    '                    Else
    '                        ret += "    <a id='MENU_" & drE("menu_code") & "' href='" & drS("SCREEN_URL") & "?menuID=" & drE("id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_thai") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_thai") & Chr(39) & ");"" >" & drE("menu_name_thai") & "</a>" & vbNewLine
    '                    End If
    '                Else
    '                    If MessageResources.CultureName = Constant.CultureName.Eng Then
    '                        ret += "    <a id='MENU_" & drE("menu_code") & "' href='" & drS("SCREEN_URL") & "?menuID=" & drE("id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_eng") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_eng") & Chr(39) & ");"" >" & drE("menu_name_eng") & "</a>" & vbNewLine
    '                    Else
    '                        ret += "    <a id='MENU_" & drE("menu_code") & "' href='" & drS("SCREEN_URL") & "?menuID=" & drE("id") & "&rnd=" & DateTime.Now.Millisecond & "' title='" & drE("menu_desc_thai") & "' OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & drE("menu_name_thai") & Chr(39) & ");"" >" & drE("menu_name_thai") & "</a>" & vbNewLine
    '                    End If
    '                End If
    '                ret += "    " + GetMenuList(ModuleID, drE("id"), trans)
    '                ret += "</li>" & vbNewLine
    '            End If
    '        Next
    '        ret += "</ul>" & vbNewLine
    '    End If
    '    Return ret
    'End Function
    

End Class

