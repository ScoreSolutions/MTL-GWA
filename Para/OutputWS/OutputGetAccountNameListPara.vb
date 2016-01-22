Namespace OutputWS
    Public Class OutputGetAccountNameListPara
        Dim _ac_search As String = ""
        Dim _ac_search_list As DataTable
        Dim _isFound As String = ""

        Public Property AC_SEARCH() As String
            Get
                Return _ac_search.Trim
            End Get
            Set(ByVal value As String)
                _ac_search = value
            End Set
        End Property
        Public Property AC_SEARCH_LIST() As DataTable
            Get
                Return _ac_search_list
            End Get
            Set(ByVal value As DataTable)
                _ac_search_list = value
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

