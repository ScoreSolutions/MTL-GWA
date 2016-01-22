
Partial Class Reports_frmHealthClaimPaidByAccountAndEmployee
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "รายงานการจ่ายค่าสินไหมตามบริษัทและพนักงาน(Health Claim by Account and Employee)"
    End Sub

    Protected Sub incCriteria1_SelectedAccount() Handles incCriteria1.SelectedAccount
        txtSectionCode.InitialAccount(incCriteria1.GroupCode.Text, incCriteria1.AccountCode.Text)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        incCriteria1.ClearAll()
        txtSectionCode.InitialAccount("", "")
        txtSectionCode.ClearSection()
        txtTopLevel.Text = ""
        rdiSortType.SelectedValue = "A"
    End Sub
End Class
