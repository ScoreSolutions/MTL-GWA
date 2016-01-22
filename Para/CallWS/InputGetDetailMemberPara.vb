Namespace CallWS
    Public Class InputGetDetailMember
        Dim _p_in_grp_code As String = ""
        Dim _p_in_ac_code As String = ""
        Dim _p_in_pol_year As String = ""
        Dim _p_in_language As String = ""
        Dim _p_in_member_no As String = ""

        Public Property GRP_CODE() As String
            Get
                Return _p_in_grp_code
            End Get
            Set(ByVal value As String)
                _p_in_grp_code = value
            End Set
        End Property
        Public Property AC_CODE() As String
            Get
                Return _p_in_ac_code
            End Get
            Set(ByVal value As String)
                _p_in_ac_code = value
            End Set
        End Property
        Public Property POL_YEAR() As String
            Get
                Return _p_in_pol_year
            End Get
            Set(ByVal value As String)
                _p_in_pol_year = value
            End Set
        End Property
        Public Property LANGUAGE() As String
            Get
                Return _p_in_language
            End Get
            Set(ByVal value As String)
                _p_in_language = value
            End Set
        End Property
        Public Property MEMBER_NO() As String
            Get
                Return _p_in_member_no
            End Get
            Set(ByVal value As String)
                _p_in_member_no = value
            End Set
        End Property
    End Class
End Namespace

