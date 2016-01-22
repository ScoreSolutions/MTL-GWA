Imports LinqDB.TABLE
Imports Para.TABLE
Imports Engine.Common

Namespace UserProfile
    Public Class LoginHistoryENG
        Public Function GetLoginHistory(ByVal sql As String) As DataTable
            Dim dt As DataTable
            'Dim whText As String = ""
            'whText += ""
            Dim lnq As New LoginHistoryLinqDB
            dt = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function
    End Class
End Namespace

