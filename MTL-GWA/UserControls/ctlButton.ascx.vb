
Partial Class UserControls_ctlButton
    Inherits System.Web.UI.UserControl


    Public Event Click(ByVal sender As Object, ByVal e As EventArgs)

    
    Public Property Text() As String
        Get
            Return likLink1.Text
        End Get
        Set(ByVal value As String)
            likLink1.Text = value
        End Set
    End Property

    Protected Sub likLink1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likLink1.Click
        RaiseEvent Click(sender, e)
    End Sub
End Class
