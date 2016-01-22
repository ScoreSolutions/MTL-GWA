Namespace OutputWS
    Public Class OutputGetBrokerNamePara
        Dim _broker_name As String = ""
        Dim _isFound As String = ""

        Public Property BROKER_NAME() As String
            Get
                Return _broker_name.Trim
            End Get
            Set(ByVal value As String)
                _broker_name = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _isFound.Trim
            End Get
            Set(ByVal value As String)
                _isFound = value
            End Set
        End Property
    End Class
End Namespace

