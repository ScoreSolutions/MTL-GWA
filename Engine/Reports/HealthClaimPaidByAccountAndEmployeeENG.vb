Imports System.Data

Namespace Reports
    Public Class HealthClaimPaidByAccountAndEmployeeENG

        Private Function Getigd007tDT() As DataTable
            Dim ret As New DataTable
            ret.TableName = "igd007t"
            ret.Columns.Add("com_code")
            ret.Columns.Add("brch_code")
            ret.Columns.Add("grp_code")
            ret.Columns.Add("ac_code")
            ret.Columns.Add("as_of_date", GetType(Date))
            ret.Columns.Add("pol_no")
            ret.Columns.Add("pol_year", GetType(Integer))
            ret.Columns.Add("ac_name_t")
            ret.Columns.Add("ac_name_e")
            ret.Columns.Add("start_date", GetType(Date))
            ret.Columns.Add("expire_date", GetType(Date))

            Dim dr As DataRow = ret.NewRow
            dr("com_code") = "XXXX"
            dr("brch_code") = "XXXX"
            dr("grp_code") = "G00-0126"
            dr("ac_code") = "A00-0239"
            dr("as_of_date") = New Date(2011, 1, 1)
            dr("pol_no") = "00111832"
            dr("pol_year") = 7
            dr("ac_name_t") = "Dell Corporation (Thailand) Co., Limited."
            dr("ac_name_e") = "Dell Corporation (Thailand) Co., Limited."
            dr("start_date") = New Date(2005, 1, 1)
            dr("expire_date") = New Date(2006, 3, 31)
            ret.Rows.Add(dr)

            Return ret
        End Function
    End Class
End Namespace

