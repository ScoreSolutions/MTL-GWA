Imports System.Data
Imports System.Web.Mail

Partial Class Test_frmTestTab
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str() As String = "1234|5678|90".Split("|")
        Dim dt As New DataTable
        dt.Columns.Add("a")
        dt.Columns.Add("b")
        dt.Columns.Add("c")
        dt.Columns.Add("d")

        Dim dr As DataRow = dt.NewRow
        dr("a") = str(0)
        dr("b") = str(1)
        dr("c") = str(2)
        dr("d") = str(3)
    End Sub

    Protected Sub TestMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TestMail.Click
        Dim ret As Boolean = True
        Try
            'For i As Integer = 0 To 100000
            Dim mail As New MailMessage()
            'mail.To = "akkarawatp@hotmail.com"
            mail.To = testSendMail.Text
            mail.Cc = testMailCC.Text
            'mail.From = "sakthanungern@scoresolutions.co.th"
            mail.From = Config.GetConfigValue("MailFrom")
            mail.Subject = "ทดสอบการส่งเมล์ไปหาหลายๆ คน"
            mail.BodyFormat = MailFormat.Text
            mail.Body = "รายละเอียดของเมล์ที่ส่งมา"
            mail.Headers.Add("Reply-To", "akkarawatp@yahoo.com;akkarawat@scoresolutions.co.th")
            'mail.Attachments.Add(New System.Web.Mail.MailAttachment(Server.MapPath("3-12-2554 11-14-36.png")))
            'mail.Attachments.Add(New System.Web.Mail.MailAttachment(Server.MapPath("3-12-2554 11-20-28.png")))
            'SmtpMail.SmtpServer = "mail.scoresolutions.co.th"
            SmtpMail.SmtpServer = "10.1.0.10"
            SmtpMail.Send(mail)
            'Next
        Catch ex As HttpException
            ret = False
            Config.SetAlert("HTTP Exception :" & ex.Message, Me)
        Catch ex As Exception
            ret = False
            Config.SetAlert("Exception : " & ex.Message, Me)
        End Try
    End Sub
End Class
