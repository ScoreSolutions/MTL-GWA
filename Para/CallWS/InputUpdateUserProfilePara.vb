Namespace CallWS
    Public Class InputUpdateUserProfilePara
        Dim _p_in_user_id As String = ""
        Dim _p_in_user_type As String = ""
        Dim _p_in_user_name_t As String = ""
        Dim _p_in_user_name_e As String = ""
        Dim _p_in_broker_code As String = ""
        Dim _p_in_ac_code As String = ""
        Dim _p_in_company_name As String = ""
        Dim _p_in_passwd_date As String = ""
        Dim _p_in_user_s_date As String = ""
        Dim _p_in_user_e_date As String = ""
        Dim _p_in_user_level As String = ""
        Dim _p_in_user_email As String = ""
        Dim _p_in_user_tel As String = ""
        Dim _p_in_market_email As String = ""
        Dim _p_in_market_cc_email As String = ""
        Dim _p_in_claim_email As String = ""
        Dim _p_in_claim_cc_email As String = ""
        Dim _p_in_disc_reason As String = ""
        Dim _p_in_user_status As String = ""
        Dim _p_in_input_person As String = ""
        Dim _p_in_mnt_dttm As String = ""

        Public Property USER_ID() As String
            Get
                Return _p_in_user_id
            End Get
            Set(ByVal value As String)
                _p_in_user_id = value
            End Set
        End Property
        Public Property USER_TYPE() As String
            Get
                Return _p_in_user_type.Trim
            End Get
            Set(ByVal value As String)
                _p_in_user_type = value
            End Set
        End Property
        Public Property USER_NAME_T() As String
            Get
                Return _p_in_user_name_t
            End Get
            Set(ByVal value As String)
                _p_in_user_name_t = value
            End Set
        End Property
        Public Property USER_NAME_E() As String
            Get
                Return _p_in_user_name_e
            End Get
            Set(ByVal value As String)
                _p_in_user_name_e = value
            End Set
        End Property

        Public Property BROKER_CODE() As String
            Get
                Return _p_in_broker_code
            End Get
            Set(ByVal value As String)
                _p_in_broker_code = value
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
        Public Property COMPANY_NAME() As String
            Get
                Return _p_in_company_name
            End Get
            Set(ByVal value As String)
                _p_in_company_name = value
            End Set
        End Property
        Public Property PASSWD_DATE() As String
            Get
                Return _p_in_passwd_date
            End Get
            Set(ByVal value As String)
                _p_in_passwd_date = value
            End Set
        End Property
        Public Property USER_S_DATE() As String
            Get
                Return _p_in_user_s_date
            End Get
            Set(ByVal value As String)
                _p_in_user_s_date = value
            End Set
        End Property
        Public Property USER_E_DATE() As String
            Get
                Return _p_in_user_e_date
            End Get
            Set(ByVal value As String)
                _p_in_user_e_date = value
            End Set
        End Property
        Public Property USER_LEVEL() As String
            Get
                Return _p_in_user_level
            End Get
            Set(ByVal value As String)
                _p_in_user_level = value
            End Set
        End Property
        Public Property USER_EMAIL() As String
            Get
                Return _p_in_user_email
            End Get
            Set(ByVal value As String)
                _p_in_user_email = value
            End Set
        End Property
        Public Property USER_TEL() As String
            Get
                Return _p_in_user_tel
            End Get
            Set(ByVal value As String)
                _p_in_user_tel = value
            End Set
        End Property
        Public Property MARKET_EMAIL() As String
            Get
                Return _p_in_market_email
            End Get
            Set(ByVal value As String)
                _p_in_market_email = value
            End Set
        End Property
        Public Property MARKET_CC_EMAIL() As String
            Get
                Return _p_in_market_cc_email
            End Get
            Set(ByVal value As String)
                _p_in_market_cc_email = value
            End Set
        End Property
        Public Property CLAIM_EMAIL() As String
            Get
                Return _p_in_claim_email
            End Get
            Set(ByVal value As String)
                _p_in_claim_email = value
            End Set
        End Property
        Public Property CLAIM_CC_EMAIL() As String
            Get
                Return _p_in_claim_cc_email
            End Get
            Set(ByVal value As String)
                _p_in_claim_cc_email = value
            End Set
        End Property
        Public Property DISC_REASON() As String
            Get
                Return _p_in_disc_reason
            End Get
            Set(ByVal value As String)
                _p_in_disc_reason = value
            End Set
        End Property
        Public Property USER_STATUS() As String
            Get
                Return _p_in_user_status.Trim
            End Get
            Set(ByVal value As String)
                _p_in_user_status = value
            End Set
        End Property
        Public Property INPUT_PERSON() As String
            Get
                Return _p_in_input_person
            End Get
            Set(ByVal value As String)
                _p_in_input_person = value
            End Set
        End Property
        Public Property MNT_DTTM() As String
            Get
                Return _p_in_mnt_dttm
            End Get
            Set(ByVal value As String)
                _p_in_mnt_dttm = value
            End Set
        End Property
    End Class
End Namespace

