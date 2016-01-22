
Partial Class Test_frmTestEncryptText
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = Engine.Common.ConfigENG.EnCripPwd(TextBox1.Text)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = Engine.Common.ConfigENG.DeCripPwd(TextBox2.Text)
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Response.Redirect("../Test/frmQuery.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
