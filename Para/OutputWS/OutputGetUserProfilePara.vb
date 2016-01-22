
Namespace OutputWS
    <Serializable()> Public Class OutputGetUserProfilePara
        Dim _p_out_user_type As String = ""
        Dim _p_out_user_name_t As String = ""
        Dim _p_out_user_name_e As String = ""
        Dim _p_out_broker_code As String = ""
        Dim _p_out_ac_code As String = ""
        Dim _p_out_company_name As String = ""
        Dim _p_out_passwd_date As String = ""
        Dim _p_out_user_s_date As String = ""
        Dim _p_out_user_e_date As String = ""
        Dim _p_out_user_level As String = ""
        Dim _p_out_user_email As String = ""
        Dim _p_out_user_tel As String = ""
        Dim _p_out_market_email As String = ""
        Dim _p_out_market_cc_email As String = ""
        Dim _p_out_claim_email As String = ""
        Dim _p_out_claim_cc_email As String = ""
        Dim _p_out_disc_reason As String = ""
        Dim _p_out_is_first_login As String = ""
        Dim _p_out_login_fail_count As String = ""
        Dim _p_out_input_person As String = ""
        Dim _p_out_mnt_dttm As String = ""
        Dim _p_out_isfound As String = ""



        Public Property USER_TYPE() As String
            Get
                Return _p_out_user_type.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_type = value
            End Set
        End Property
        Public Property USER_NAME_T() As String
            Get
                Return _p_out_user_name_t.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_name_t = value
            End Set
        End Property
        Public Property USER_NAME_E() As String
            Get
                Return _p_out_user_name_e.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_name_e = value
            End Set
        End Property
        Public Property BROKER_CODE() As String
            Get
                Return _p_out_broker_code.Trim
            End Get
            Set(ByVal value As String)
                _p_out_broker_code = value
            End Set
        End Property
        Public Property AC_CODE() As String
            Get
                Return _p_out_ac_code.Trim
            End Get
            Set(ByVal value As String)
                _p_out_ac_code = value
            End Set
        End Property
        Public Property COMPANY_NAME() As String
            Get
                Return _p_out_company_name.Trim
            End Get
            Set(ByVal value As String)
                _p_out_company_name = value
            End Set
        End Property
        Public Property PASSWD_DATE() As String
            Get
                Return _p_out_passwd_date.Trim
            End Get
            Set(ByVal value As String)
                _p_out_passwd_date = value
            End Set
        End Property
        Public Property USER_S_DATE() As String
            Get
                Return _p_out_user_s_date.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_s_date = value
            End Set
        End Property
        Public Property USER_E_DATE() As String
            Get
                Return _p_out_user_e_date.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_e_date = value
            End Set
        End Property
        Public Property USER_LEVEL() As String
            Get
                Return _p_out_user_level.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_level = value
            End Set
        End Property
        Public Property USER_EMAIL() As String
            Get
                Return _p_out_user_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_email = value
            End Set
        End Property
        Public Property USER_TEL() As String
            Get
                Return _p_out_user_tel.Trim
            End Get
            Set(ByVal value As String)
                _p_out_user_tel = value
            End Set
        End Property
        Public Property MARKET_EMAIL() As String
            Get
                Return _p_out_market_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_market_email = value
            End Set
        End Property
        Public Property MARKET_CC_EMAIL() As String
            Get
                Return _p_out_market_cc_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_market_cc_email = value
            End Set
        End Property
        Public Property CLAIM_EMAIL() As String
            Get
                Return _p_out_claim_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_claim_email = value
            End Set
        End Property
        Public Property CLAIM_CC_EMAIL() As String
            Get
                Return _p_out_claim_cc_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_claim_cc_email = value
            End Set
        End Property
        Public Property DISC_REASON() As String
            Get
                Return _p_out_disc_reason.Trim
            End Get
            Set(ByVal value As String)
                _p_out_disc_reason = value
            End Set
        End Property
        Public Property IS_FIRST_LOGIN() As String
            Get
                Return _p_out_is_first_login.Trim
            End Get
            Set(ByVal value As String)
                _p_out_is_first_login = value
            End Set
        End Property
        Public Property LOGIN_FAIL_COUNT() As String
            Get
                Return _p_out_login_fail_count.Trim
            End Get
            Set(ByVal value As String)
                _p_out_login_fail_count = value
            End Set
        End Property
        Public Property INPUT_PERSON() As String
            Get
                Return _p_out_input_person.Trim
            End Get
            Set(ByVal value As String)
                _p_out_input_person = value
            End Set
        End Property
        Public Property MNT_DTTM() As String
            Get
                Return _p_out_mnt_dttm.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mnt_dttm = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _p_out_isfound.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound = value
            End Set
        End Property
    End Class
End Namespace

