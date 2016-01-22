Imports Engine.Common
Imports System.Data
Partial Class Test_frmQuery
    Inherits System.Web.UI.Page


    Protected Sub btnExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim trans As New LinqDB.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim dt As New DataTable
        dt = ConfigENG.ExecuteSQL(txtTextCommand.Text, trans)
        trans.CommitTransaction()

        If ConfigENG.ErrorMessage <> "" Then
            lblMsg.Text = ConfigENG.ErrorMessage
        End If

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub btnEncrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        Response.Redirect("../Test/frmTestEncryptText.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
