Imports Para.Common.Utilities

Partial Class Reports_frmHealthClaimPaidByBenefit
    Inherits System.Web.UI.Page

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "รายงานการจ่ายค่าสินไหมตามตารางผลประโยชน์(Health Claim by Benefit)"

        'If IsPostBack = False Then
        '    cmbReportType.SetItemList("PDF", Constant.ReportType.PDF)
        '    cmbReportType.SetItemList("Microsoft Word", Constant.ReportType.WORD)
        '    cmbReportType.SetItemList("Microsoft Excel", Constant.ReportType.EXCEL)
        '    cmbReportType.SetItemList("Crystal Reports", Constant.ReportType.CRYSTAL)
        'End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        incCriteria1.ClearAll()
        'cmbReportType.SelectedValue = Constant.ReportType.PDF
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = incCriteria1.Valid
        Return ret
    End Function
End Class
