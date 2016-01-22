Namespace OutputWS
    <Serializable()> Public Class OutputGetUserJoinCasePara
        Dim _p_out_case As String = ""
        Dim _p_out_case2 As String = ""
        Dim _p_out_case3 As String = ""
        Dim _p_out_case4 As String = ""
        Dim _p_out_case5 As String = ""
        Dim _p_out_case6 As String = ""
        Dim _p_out_case7 As String = ""
        Dim _p_out_case8 As String = ""
        Dim _p_out_case9 As String = ""
        Dim _p_out_case10 As String = ""
        Dim _p_out_msg_data_over As String = ""
        Dim _p_out_case_list As DataTable
        Dim _p_out_isfound_case As String = ""


        Public Property OUT_CASE() As String
            Get
                Return _p_out_case.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case = value
            End Set
        End Property
        Public Property OUT_CASE2() As String
            Get
                Return _p_out_case2.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case2 = value
            End Set
        End Property
        Public Property OUT_CASE3() As String
            Get
                Return _p_out_case3.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case3 = value
            End Set
        End Property
        Public Property OUT_CASE4() As String
            Get
                Return _p_out_case4.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case4 = value
            End Set
        End Property
        Public Property OUT_CASE5() As String
            Get
                Return _p_out_case5.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case5 = value
            End Set
        End Property
        Public Property OUT_CASE6() As String
            Get
                Return _p_out_case6.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case6 = value
            End Set
        End Property
        Public Property OUT_CASE7() As String
            Get
                Return _p_out_case7.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case7 = value
            End Set
        End Property
        Public Property OUT_CASE8() As String
            Get
                Return _p_out_case8.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case8 = value
            End Set
        End Property
        Public Property OUT_CASE9() As String
            Get
                Return _p_out_case9.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case9 = value
            End Set
        End Property
        Public Property OUT_CASE10() As String
            Get
                Return _p_out_case10.Trim
            End Get
            Set(ByVal value As String)
                _p_out_case10 = value
            End Set
        End Property
        Public Property OUT_CASE_LIST() As DataTable
            Get
                Return _p_out_case_list
            End Get
            Set(ByVal value As DataTable)
                _p_out_case_list = value
            End Set
        End Property
        Public Property MSG_DATE_OVER() As String
            Get
                Return _p_out_msg_data_over.Trim
            End Get
            Set(ByVal value As String)
                _p_out_msg_data_over = value
            End Set
        End Property
        Public Property ISFOUND_CASE() As String
            Get
                Return _p_out_isfound_case.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound_case = value
            End Set
        End Property
    End Class
End Namespace

