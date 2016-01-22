Imports System.Data
Imports LinqWS
Imports Para.CallWS

Namespace GroupPolicy
    Public Class GroupPolicySearchENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public Function SearchFromWS(ByVal para As InputGetQueryAccountPara) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("group_code")
            dt.Columns.Add("policy_no")
            dt.Columns.Add("account_code")
            dt.Columns.Add("account_name")
            dt.Columns.Add("policy_year")
            dt.Columns.Add("ef_date")
            dt.Columns.Add("ep_date")
            dt.Columns.Add("CommandArgument")

            For i As Integer = 0 To 50
                Dim dr As DataRow = dt.NewRow
                dr("group_code") = "Gxx-xxxx" & (i + 1)
                dr("policy_no") = "00xxxxxx" & (i + 1)
                dr("account_code") = "A00-0000" & (i + 1)
                dr("account_name") = "xxxxxxxxxxxxxxxxxxxxx" & (i + 1)
                dr("policy_year") = 1
                dr("ef_date") = "dd/MM/yyyy"
                dr("ep_date") = "dd/MM/yyyy"
                dr("CommandArgument") = dr("group_code") & "##" & dr("account_code") & "##" & dr("policy_year") & "##T"
                dt.Rows.Add(dr)
            Next

            Return dt
        End Function

    End Class
End Namespace

