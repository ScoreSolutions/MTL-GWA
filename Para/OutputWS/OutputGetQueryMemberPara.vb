Namespace OutputWS
    Public Class OutputGetQueryMemberPara
        Dim _p_out_mem_search As String = ""
        Dim _p_out_mem_search2 As String = ""
        Dim _p_out_mem_search3 As String = ""
        Dim _p_out_msg_data_over As String = ""
        Dim _p_out_isfound_mem As String = ""
        Dim _p_out_mem_list As DataTable

        Public Property MEMBER_SEARCH() As String
            Get
                Return _p_out_mem_search.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_search = value
            End Set
        End Property
        Public Property MEMBER_SEARCH2() As String
            Get
                Return _p_out_mem_search2.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_search2 = value
            End Set
        End Property
        Public Property MEMBER_SEARCH3() As String
            Get
                Return _p_out_mem_search3.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_search3 = value
            End Set
        End Property
        Public Property MSG_DATA_OVER() As String
            Get
                Return _p_out_msg_data_over.Trim
            End Get
            Set(ByVal value As String)
                _p_out_msg_data_over = value
            End Set
        End Property

        Public Property ISFOUND_MEM() As String
            Get
                Return _p_out_isfound_mem.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound_mem = value
            End Set
        End Property

        Public Property MEMBER_LIST() As DataTable
            Get
                Return _p_out_mem_list
            End Get
            Set(ByVal value As DataTable)
                _p_out_mem_list = value
            End Set
        End Property
    End Class
End Namespace

