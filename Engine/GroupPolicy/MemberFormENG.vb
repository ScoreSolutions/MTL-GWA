Imports System.Data

Namespace GroupPolicy
    Public Class MemberFormENG
        Public Function GetPlanLife() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("no")
            dt.Columns.Add("plan")
            dt.Columns.Add("benefit")
            dt.Columns.Add("money_amt")
            dt.Columns.Add("remarks")

            Dim dr As DataRow = dt.NewRow
            dr("no") = 1
            dr("plan") = "PL001"
            dr("benefit") = "การประกันชีวิต"
            dr("money_amt") = "200,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 2
            dr("plan") = "PA001"
            dr("benefit") = "การประกันอุบัติเหตุ(อบก.1)"
            dr("money_amt") = "24 เท่าของเงินเดือน"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 3
            dr("plan") = "PT001"
            dr("benefit") = "การประกันทุพพลภาพ(TPI)"
            dr("money_amt") = "200,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 4
            dr("plan") = "PE001"
            dr("benefit") = "ค่ารักษาพยาบาลเนื่องจากอุบัติเหตุ"
            dr("money_amt") = "20,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            Return dt

        End Function

        Public Function GetPlanHealth() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("no")
            dt.Columns.Add("benefit")
            dt.Columns.Add("money_amt")
            dt.Columns.Add("remarks")


            Dim dr As DataRow = dt.NewRow
            dr("no") = 1
            dr("benefit") = "ค่าห้องและค่าอาหาร วันละ(สูงสุด 31 วันต่อการเจ็บป่วย / อุบัติเหตุแต่ละครั้ง)"
            dr("money_amt") = "2,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 2
            dr("benefit") = "ค่าห้อง ไอซียู (สูงสุด 7 วันต่อการเจ็บป่วย / อุบัติเหตุแต่ละครั้ง)"
            dr("money_amt") = "4,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 3
            dr("benefit") = "ค่าใช้จ่ายและค่าบริการทั่วไป (สูงสุดต่อการเจ็บป่วย / อุบัติเหตุแต่ละครั้ง)"
            dr("money_amt") = "30,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("no") = 4
            dr("benefit") = "ค่าธรรมเนียมแพทย์ผ่าตัด (จ่ายให้ตามตารางการผ่าตัด)"
            dr("money_amt") = "20,000"
            dr("remarks") = ""
            dt.Rows.Add(dr)

            Return dt
        End Function
    End Class
End Namespace

