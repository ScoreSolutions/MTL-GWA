Namespace CallWS
    Public Class InputGetBrokerNameListPara
        Dim _broker_code As String = ""
        Dim _broker_name As String = ""
        Dim _language As String = ""

        Public Property BROKER_CODE() As String
            Get
                Return _broker_code
            End Get
            Set(ByVal value As String)
                _broker_code = value
            End Set
        End Property
        Public Property BROKER_NAME() As String
            Get
                Return _broker_name
            End Get
            Set(ByVal value As String)
                _broker_name = value
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

