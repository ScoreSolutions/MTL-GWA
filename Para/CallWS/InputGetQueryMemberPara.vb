Namespace CallWS
    Public Class InputGetQueryMemberPara
        Dim _p_in_grp_code As String = ""
        Dim _p_in_ac_code As String = ""
        Dim _p_in_pol_year As String = ""
        Dim _p_in_language As String = ""
        Dim _p_in_member_no As String = ""
        Dim _p_in_employee_no As String = ""
        Dim _p_in_hlt_card_no As String = ""
        Dim _p_in_mem_name As String = ""
        Dim _p_in_mem_surname As String = ""
        Dim _p_in_sec_code As String = ""

        Public Property P_IN_GRP_CODE() As String
            Get
                Return _p_in_grp_code.Trim
            End Get
            Set(ByVal value As String)
                _p_in_grp_code = value
            End Set
        End Property
        Public Property P_IN_AC_CODE() As String
            Get
                Return _p_in_ac_code.Trim
            End Get
            Set(ByVal value As String)
                _p_in_ac_code = value
            End Set
        End Property
        Public Property P_IN_POL_YEAR() As String
            Get
                Return _p_in_pol_year.Trim
            End Get
            Set(ByVal value As String)
                _p_in_pol_year = value
            End Set
        End Property
        Public Property P_IN_LANGUAGE() As String
            Get
                Return _p_in_language.Trim
            End Get
            Set(ByVal value As String)
                _p_in_language = value
            End Set
        End Property
        Public Property P_IN_MEMBER_NO() As String
            Get
                Return _p_in_member_no.Trim
            End Get
            Set(ByVal value As String)
                _p_in_member_no = value
            End Set
        End Property
        Public Property P_IN_EMPLOYEE_NO() As String
            Get
                Return _p_in_employee_no.Trim
            End Get
            Set(ByVal value As String)
                _p_in_employee_no = value
            End Set
        End Property
        Public Property P_IN_HLT_CARD_NO() As String
            Get
                Return _p_in_hlt_card_no.Trim
            End Get
            Set(ByVal value As String)
                _p_in_hlt_card_no = value
            End Set
        End Property
        Public Property P_IN_MEM_NAME() As String
            Get
                Return _p_in_mem_name.Trim
            End Get
            Set(ByVal value As String)
                _p_in_mem_name = value
            End Set
        End Property
        Public Property P_IN_MEM_SURNAME() As String
            Get
                Return _p_in_mem_surname.Trim
            End Get
            Set(ByVal value As String)
                _p_in_mem_surname = value
            End Set
        End Property
        Public Property P_IN_SEC_CODE() As String
            Get
                Return _p_in_sec_code.Trim
            End Get
            Set(ByVal value As String)
                _p_in_sec_code = value
            End Set
        End Property
    End Class
End Namespace

