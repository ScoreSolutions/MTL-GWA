Namespace CallWS
    Public Class InputGetAccountUserPofilePara
        Dim _ac_code As String = ""
        Public Property AC_CODE() As String
            Get
                Return _ac_code
            End Get
            Set(ByVal value As String)
                _ac_code = value
            End Set
        End Property
    End Class
End Namespace

