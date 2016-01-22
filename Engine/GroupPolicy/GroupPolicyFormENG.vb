Imports System.Data

Namespace GroupPolicy
    Public Class GroupPolicyFormENG
        Public Function GetBenefitPlanList() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("benefit_plan")
            dt.Columns.Add("benefit_type")
            dt.Columns.Add("money_amt")
            dt.Columns.Add("benefit_table_code")
            dt.Columns.Add("benefit_table_start_date")
            dt.Columns.Add("endorse_no")
            dt.Columns.Add("remarks")
            dt.Columns.Add("CommandArgument")

            Dim dr As DataRow = dt.NewRow
            dr("benefit_plan") = "PL001"
            dr("benefit_type") = "การประกันชีวิต"
            dr("money_amt") = "200,000"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PL001"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PL002"
            dr("benefit_type") = "การประกันชีวิต"
            dr("money_amt") = "24 เท่าของเงินเดือน"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PL002"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PA001"
            dr("benefit_type") = "การประกันอุบัติเหตุ (อบก.1)"
            dr("money_amt") = "200,000"
            dr("CommandArgument") = "PA001"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PA002"
            dr("benefit_type") = "การประกันอุบัติเหตุ (อบก.1)"
            dr("money_amt") = "24 เท่าของเงินเดือน"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PA002"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PT001"
            dr("benefit_type") = "การประกันทุพพลภาพ (TPI)"
            dr("money_amt") = "200,000"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PT001"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PT002"
            dr("benefit_type") = "การประกันทุพพลภาพ (TPI)"
            dr("money_amt") = "24 เท่าของเงินเดือน"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PT002"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PE001"
            dr("benefit_type") = "ค่ารักษาพยาบาลเนื่องจากอุบัติเหตุ"
            dr("money_amt") = "20,000"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PE001"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PE002"
            dr("benefit_type") = "ค่ารักษาพยาบาลเนื่องจากอุบัติเหตุ"
            dr("money_amt") = "40,000"
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PE002"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PH001"
            dr("benefit_type") = "การประกันสุขภาพ"
            dr("money_amt") = ""
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PH001"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("benefit_plan") = "PH002"
            dr("benefit_type") = "การประกันสุขภาพ"
            dr("money_amt") = ""
            dr("benefit_table_code") = "BH001"
            dr("CommandArgument") = "PH002"
            dt.Rows.Add(dr)

            Return dt
        End Function
    End Class
End Namespace
