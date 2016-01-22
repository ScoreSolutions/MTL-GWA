Namespace CallWS
    Public Class InputGetAccountNameListPara
        Dim _ac_code As String = ""
        Dim _ac_name As String = ""
        Dim _language As String = ""

        Public Property AC_CODE() As String
            Get
                Return _ac_code
            End Get
            Set(ByVal value As String)
                _ac_code = value
            End Set
        End Property
        Public Property AC_NAME() As String
            Get
                Return _ac_name
            End Get
            Set(ByVal value As String)
                _ac_name = value
            End Set
        End Property
        Public Property LANGUAGE() As String
            Get
                Return _language
            End Get
            Set(ByVal value As String)
                _language = value
            End Set
        End Property
    End Class
End Namespace

