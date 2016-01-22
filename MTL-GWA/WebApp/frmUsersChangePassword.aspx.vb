Imports Para.Common.Utilities
Imports Engine.Common
Imports Engine.UserProfile
Imports Para.TABLE
Imports Para.Common

Partial Class WebApp_frmUsersChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm1 As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm1.FindControl("lblPageName")
        lblPageName.Text = "เปลี่ยนรหัสผ่าน (Change Password)"

        If IsPostBack = False Then
            If Session(Constant.ForceChangePasswordSession) = "Y" Then 'เป็นการบังคับให้เปลี่ยนรหัสผ่าน ต้องไม่แสดงเมนู
                Dim mFrm As MasterPage = Me.Master
                Dim lblMenu As Label = mFrm.FindControl("lblMenu")
                Dim lblLastLogin As Label = mFrm.FindControl("lblLastLogin")
                Dim lblNoMenu As Label = mFrm.FindControl("lblNoMenu")
                lblMenu.Visible = False
                lblNoMenu.Visible = True
                lblLastLogin.Visible = False

                'Session(Constant.ForceChangePasswordSession) = "N"
            End If
            txtUserName.Text = Config.GetUserID
        End If

        txtOldPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtOldPassword.ClientID & "');")
        txtNewPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtNewPassword.ClientID & "');")
        txtConfirmPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtConfirmPassword.ClientID & "');")

        txtOldPassword.Attributes.Add("OnKeypress", "return clickButton(event,'" + btnChangePassword.ClientID + "') ")
        txtNewPassword.Attributes.Add("OnKeypress", "return clickButton(event,'" + btnChangePassword.ClientID + "') ")
        txtConfirmPassword.Attributes.Add("OnKeypress", "return clickButton(event,'" + btnChangePassword.ClientID + "') ")

        txtOldPassword.Attributes.Add("OnKeyDown", "ValidPwdKeyDown(event);")
        txtNewPassword.Attributes.Add("OnKeyDown", "ValidPwdKeyDown(event);")
        txtConfirmPassword.Attributes.Add("OnKeyDown", "ValidPwdKeyDown(event);")

        txtOldPassword.Attributes.Add("OnKeyUp", "ValidPwdKeyUp(event,'" & txtOldPassword.ClientID & "');")
        txtNewPassword.Attributes.Add("OnKeyUp", "ValidPwdKeyUp(event,'" & txtNewPassword.ClientID & "');")
        txtConfirmPassword.Attributes.Add("OnKeyUp", "ValidPwdKeyUp(event,'" & txtConfirmPassword.ClientID & "');")

        txtOldPassword.Attributes.Add("OnMouseDown", "ValidRightClick(event)")
        txtNewPassword.Attributes.Add("OnMouseDown", "ValidRightClick(event)")
        txtConfirmPassword.Attributes.Add("OnMouseDown", "ValidRightClick(event)")
    End Sub

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If Valid() = True Then
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim para As New UsersPara
            para.USER_PASSWD = ConfigENG.EnCripPwd(txtNewPassword.Text)
            para.LOGIN_FAIL_COUNT = 0
            para.IS_FIRST_LOGIN = "N"
            para.PASSWD_DATE = DateTime.Now.Date.AddDays(-1).AddDays(90)

            Dim eng As New UsersENG
            Dim ret As Boolean = eng.ChangePassword(txtUserName.Text, para, trans)
            If ret = True Then
                trans.CommitTransaction()
                LogENG.SaveTransLog("เปลี่ยนรหัสผ่าน", Config.GetLogOnUser)
                Session(Constant.ForceChangePasswordSession) = "N"
                'Config.SetAlert("เปลี่ยนรหัสผ่านเรียบร้อย กรุณาเข้าสู่ระบบอีกครั้งด้วยรหัสผ่านใหม่", Me)
                'Response.Redirect("../frmLogOut.aspx?logout=Y")


                Dim popupScript = "<script language='javascript'> " & _
                                        " alert('เปลี่ยนรหัสผ่านเรียบร้อย กรุณาเข้าสู่ระบบอีกครั้งด้วยรหัสผ่านใหม่ \r\n ( Password changed already. Please login again with your new password.)'); " & _
                                        " window.open('../WebApp/frmLogOut.aspx?logout=Y', '_self','');" & _
                                        " </script>"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "MTL-GWA", popupScript, False)

            Else
                trans.RollbackTransaction()
                LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                'Config.SetAlert(eng.ErrorMessage, Me)
                Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
            End If
        End If
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If txtOldPassword.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรหัสผ่านเดิม \r\n ( Please input your Old password. )", Me, txtOldPassword.ClientID)
        ElseIf txtNewPassword.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรหัสผ่านใหม่ \r\n ( Please specify a new password. )", Me, txtNewPassword.ClientID)
        ElseIf txtNewPassword.Text.Trim <> txtConfirmPassword.Text.Trim Then
            ret = False
            Config.SetAlert("การยืนยันรหัสผ่านไม่ถูกต้อง \r\n ( The password is incorrect. )", Me, txtNewPassword.ClientID)
        Else
            Dim eng As New UsersENG
            If eng.CheckPassword(txtUserName.Text.Trim, ConfigENG.EnCripPwd(txtOldPassword.Text.Trim)) = False Then
                ret = False
                Config.SetAlert("รหัสผ่านเดิมไม่ถูกต้อง \r\n ( The old password is incorrect.)", Me, txtOldPassword.ClientID)
            ElseIf eng.CheckPasswordHistory(txtUserName.Text.Trim, ConfigENG.EnCripPwd(txtNewPassword.Text.Trim)) = True Then
                ret = False
                Config.SetAlert("รหัสผ่านต้องไม่ซ้ำกัน " & Config.GetConfigValue(Constant.SystemConfig.PwdHisLimit) & " ครั้งก่อนหน้านี้ที่กำหนดมาแล้ว  \r\n (New passwords must be differred from previous " & Config.GetConfigValue(Constant.SystemConfig.PwdHisLimit) & " password.)", Me)
            End If
        End If
        Return ret
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            SetDefault()
        End If
    End Sub

    Private Sub SetDefault()
        txtOldPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtOldPassword.ClientID & "');")
        txtOldPassword.Attributes.Add("OnKeyPress", "ValidPasswordKeyPress(event,'" & txtOldPassword.ClientID & "');")

        txtNewPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtNewPassword.ClientID & "');")
        txtNewPassword.Attributes.Add("OnKeyPress", "ValidPasswordKeyPress(event,'" & txtNewPassword.ClientID & "');")

        txtConfirmPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtConfirmPassword.ClientID & "');")
        txtConfirmPassword.Attributes.Add("OnKeyPress", "ValidPasswordKeyPress(event,'" & txtConfirmPassword.ClientID & "');")

    End Sub
End Class
