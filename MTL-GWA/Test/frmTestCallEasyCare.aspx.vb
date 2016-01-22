Imports Para.CallWS
Partial Class Test_frmTestCallEasyCare
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim eng As New Engine.CallEasyCareENG

        'GridView1.DataSource = eng.GetEasyCare
        'GridView1.DataBind()

        Dim para As New InputGetUserProfilePara
        para.USER_ID = "007473"
        para.USER_PASSWD = "007473"

        Dim eng As New Engine.Auth.LogInENG
        eng.ChkLogin(para)
    End Sub
End Class
