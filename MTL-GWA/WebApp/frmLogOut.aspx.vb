Imports Engine.Common
Partial Class WebApp_frmLogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("logout") = "Y" Then
            Dim eng As New LogENG
            eng.SaveLogout(Config.GetLogOnUser)
            Session.Abandon()
            Session.RemoveAll()
            'HttpContext.Current.Response.Cookies.Clear()

            'delect cookies by TonG
            Dim ck As New System.Web.HttpCookie(".MTLGWA")
            For Each key As String In Request.Cookies.AllKeys
                Dim cookie As New HttpCookie(key)
                cookie.Expires = DateTime.Now.AddMinutes(-1) 'DateTime.UtcNow.AddDays(-7)
                Response.Cookies.Add(cookie)
            Next
            Response.Redirect("frmLogin.aspx")
        End If
    End Sub
End Class
