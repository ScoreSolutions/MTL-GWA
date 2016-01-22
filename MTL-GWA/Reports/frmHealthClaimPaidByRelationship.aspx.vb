
Partial Class Reports_frmHealthClaimPaidByRelationship
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "รายงานการจ่ายค่าสินไหมตามความสัมพันธ์(Health Claim by Relationship)"

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        incCriteria1.ClearAll()
    End Sub
End Class
