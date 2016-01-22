Namespace CallWS
    Public Class InputGetBrokerNamePara
        Dim _broker_code As String = ""
        Dim _language As String = ""

        Public Property LANGUAGE() As String
            Get
                Return _language
            End Get
            Set(ByVal value As String)
                _language = value
            End Set
        End Property
        Public Property BROKER_CODE() As String
            Get
                Return _broker_code
            End Get
            Set(ByVal value As String)
                _broker_code = value
            End Set
        End Property
    End Class
End Namespace

