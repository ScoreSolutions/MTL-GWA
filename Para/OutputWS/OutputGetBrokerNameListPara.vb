Namespace OutputWS
    Public Class OutputGetBrokerNameListPara
        Dim _broker_search As String = ""
        Dim _broker_search_list As DataTable
        Dim _isFound As String = ""

        Public Property BROKER_SEARCH() As String
            Get
                Return _broker_search.Trim
            End Get
            Set(ByVal value As String)
                _broker_search = value
            End Set
        End Property

        Public Property BROKER_SEARCH_LIST() As DataTable
            Get
                Return _broker_search_list
            End Get
            Set(ByVal value As DataTable)
                _broker_search_list = value
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

