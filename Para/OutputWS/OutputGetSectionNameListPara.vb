Namespace OutputWS
    Public Class OutputGetSectionNameListPara
        Dim _sec_search As String = ""
        Dim _sec_search_list As DataTable
        Dim _isfound As String = ""

        Public Property SEC_SEARCH() As String
            Get
                Return _sec_search
            End Get
            Set(ByVal value As String)
                _sec_search = value
            End Set
        End Property
        Public Property SEC_SEARCH_LIST() As DataTable
            Get
                Return _sec_search_list
            End Get
            Set(ByVal value As DataTable)
                _sec_search_list = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _isfound
            End Get
            Set(ByVal value As String)
                _isfound = value
            End Set
        End Property
    End Class
End Namespace

