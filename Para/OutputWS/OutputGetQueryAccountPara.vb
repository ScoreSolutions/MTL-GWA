Namespace OutputWS
    Public Class OutputGetQueryAccountPara
        Dim _p_out_account As String = ""
        Dim _p_out_isfound_ac As String = ""
        Dim _p_out_account_list As DataTable

        Public Property ACCOUNT() As String
            Get
                Return _p_out_account.Trim
            End Get
            Set(ByVal value As String)
                _p_out_account = value
            End Set
        End Property
        Public Property ISFOUND_AC() As String
            Get
                Return _p_out_isfound_ac.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound_ac = value
            End Set
        End Property
        Public Property ACCOUNT_LIST() As DataTable
            Get
                Return _p_out_account_list
            End Get
            Set(ByVal value As DataTable)
                _p_out_account_list = value
            End Set
        End Property

        'Dim _p_out_pol_no As String = ""
        'Dim _p_out_grp_code As String = ""
        'Dim _p_out_ac_code As String = ""
        'Dim _p_out_ac_name As String = ""
        'Dim _p_out_effect_date As String = ""
        'Dim _p_out_expire_date As String = ""
        'Dim _p_out_account As String = ""
        'Dim _p_out_isFound_ac As String = ""

        'Public Property P_OUT_POL_NO() As String
        '    Get
        '        Return _p_out_pol_no.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_pol_no = value
        '    End Set
        'End Property
        'Public Property P_OUT_GRP_CODE() As String
        '    Get
        '        Return _p_out_grp_code.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_grp_code = value
        '    End Set
        'End Property
        'Public Property P_OUT_AC_CODE() As String
        '    Get
        '        Return _p_out_ac_code.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_ac_code = value
        '    End Set
        'End Property
        'Public Property P_OUT_AC_NAME() As String
        '    Get
        '        Return _p_out_ac_name.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_ac_name = value
        '    End Set
        'End Property

        'Public Property P_OUT_EFFECT_DATE() As String
        '    Get
        '        Return _p_out_effect_date.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_effect_date = value
        '    End Set
        'End Property

        'Public Property P_OUT_EXPIRE_DATE() As String
        '    Get
        '        Return _p_out_expire_date.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_expire_date = value
        '    End Set
        'End Property
        'Public Property P_OUT_ACCOUNT() As String
        '    Get
        '        Return _p_out_account.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_account = value
        '    End Set
        'End Property
        'Public Property P_OUT_ISFOUND_AC() As String
        '    Get
        '        Return _p_out_isFound_ac.Trim
        '    End Get
        '    Set(ByVal value As String)
        '        _p_out_isFound_ac = value
        '    End Set
        'End Property

    End Class
End Namespace
