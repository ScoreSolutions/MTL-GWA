
Partial Class UserControls_ctlTab
    Inherits System.Web.UI.UserControl


    Public Event Click(ByVal sender As Object, ByVal e As EventArgs)

    Public WriteOnly Property ActiveTab() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then
                tL.Src = "../Images/tSL.png"
                tS.Attributes.Add("style", "background-image: url(../Images/tS.png);background-repeat:repeat-x;")
                tR.Src = "../Images/tSR.png"
                libLink1.ForeColor = Drawing.ColorTranslator.FromHtml("#FFFFFF")
            Else
                tL.Src = "../Images/tSLN.png"
                tS.Attributes.Add("style", "background-image: url(../Images/tSN.png);background-repeat:repeat-x;")
                tR.Src = "../Images/tSRN.png"
                libLink1.ForeColor = Drawing.ColorTranslator.FromHtml("#2f3e74")
            End If
            _ActiveTab.Value = value
        End Set
    End Property

    Public WriteOnly Property TabText() As String
        Set(ByVal value As String)
            libLink1.Text = value
        End Set
    End Property

    Protected Sub libLink1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles libLink1.Click
        ActiveTab = True
        RaiseEvent Click(sender, e)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
