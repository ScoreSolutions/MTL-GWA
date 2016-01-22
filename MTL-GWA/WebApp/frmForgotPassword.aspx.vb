Imports Engine.Common
Imports Engine.Auth
Imports Para.TABLE
Imports System.Web.Mail
Imports Para.Common.Utilities


Partial Class WebApp_frmForgotPassword
    Inherits System.Web.UI.Page

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If txtUserID.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ User ID(Please enter User ID)", Me, txtUserID.ClientID)
        ElseIf txtMail.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ E-Mail (Please enter E-Mail)", Me, txtMail.ClientID)
        End If
        Return ret
    End Function
    Protected Sub btnForgotPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnForgotPassword.Click
        If Valid() = True Then
            Dim ret As Boolean = True
            Dim eng As New LogInENG
            ret = eng.ChkForgotPassword(txtUserID.Text.Trim, txtMail.Text.Trim)
            If ret = True Then
                If SendMail(eng.UserProfilePara()) = True Then
                    lblUserEMail.Text = txtMail.Text
                    lblUserEmailEng.Text = txtMail.Text
                    tbForgotPassword.Visible = False
                    tbSendMailError.Visible = False
                    tbSendMailComplete.Visible = True
                End If
            Else
                'tbForgotPassword.Visible = False
                'tbSendMailComplete.Visible = False
                'tbSendMailError.Visible = True
                'LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                'lblErrMessage.Text = eng.ErrorMessage
                Config.SetAlert(eng.ErrorMessage, Me)
            End If
        End If
    End Sub

    Private Function SendMail(ByVal uPara As UsersPara) As Boolean
        Dim ret As Boolean = True
        Try
            Dim mail As New MailMessage()
            mail.From = Config.GetConfigValue("MailFrom")
            mail.To = uPara.USER_EMAIL
            mail.Subject = "รหัสผ่านสำหรับ MTL Group Insurance Web Access"
            mail.BodyFormat = MailFormat.Text
            mail.Body = CreateMailBody(uPara)
            SmtpMail.SmtpServer = Config.GetConfigValue("MailServer")
            SmtpMail.Send(mail)


            'Dim mail As New MailMessage()
            'mail.From = "akkarawatp@hotmail.com"
            'mail.To = uPara.USER_EMAIL
            'mail.Subject = "รหัสผ่านสำหรับ MTL Group Insurance Web Access"
            'mail.BodyFormat = MailFormat.Text
            'mail.Body = CreateMailBody(uPara)
            'SmtpMail.SmtpServer = "webmail.scoresolutions.co.th"
            'SmtpMail.Send(mail)

        Catch ex As HttpException
            ret = False
            LogENG.SaveErrorLog(ex.Message, Config.GetLogOnUser)
            Config.SetAlert(ex.Message, Me)
        Catch ex As Exception
            ret = False
            LogENG.SaveErrorLog(ex.Message, Config.GetLogOnUser)
            Config.SetAlert(ex.Message, Me)
        End Try

        Return ret
    End Function
    Private Function CreateMailBody(ByVal uPara As UsersPara) As String
        Dim ret As String = ""
        ret += "เรียน " & uPara.USER_NAME_T & vbNewLine
        ret += "รหัสผ่านของคุณคือ " & ConfigENG.DeCripPwd(uPara.USER_PASSWD) & vbNewLine
        ret += "หากไม่สามารถเข้าสู่ระบบได้ กรุณาติดต่อเจ้าหน้าที่" & vbNewLine

        Return ret
    End Function

    Protected Sub likLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likLogin.Click
        Response.Redirect("frmLogin.aspx")

    End Sub

    Protected Sub likLogin2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likLogin2.Click
        Response.Redirect("frmLogin.aspx")
    End Sub

    Protected Sub likForgotPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likForgotPassword.Click
        tbForgotPassword.Visible = True
        tbSendMailError.Visible = False
        tbSendMailComplete.Visible = False
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        Response.Redirect("frmLogin.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
