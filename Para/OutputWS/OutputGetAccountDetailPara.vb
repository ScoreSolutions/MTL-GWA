
Namespace OutputWS
    Public Class OutputGetAccountDetailPara
        Dim _p_out_pol_name As String = ""
        Dim _p_out_payment_mode As String = ""
        Dim _p_out_account_sts As String = ""
        Dim _p_out_address As String = ""
        Dim _p_out_fcl_amt As String = ""
        Dim _p_out_health_card As String = ""
        Dim _p_out_head_flag As String = ""
        Dim _p_out_min_age As String = ""
        Dim _p_out_max_age As String = ""
        Dim _p_out_contact_person As String = ""
        Dim _p_out_plan As String = ""
        Dim _p_out_plan_list As DataTable
        Dim _p_out_isfound_detail As String = ""

        Public Property POL_NAME() As String
            Get
                Return _p_out_pol_name.Trim
            End Get
            Set(ByVal value As String)
                _p_out_pol_name = value
            End Set
        End Property
        Public Property ACCOUNT_STS() As String
            Get
                Return _p_out_account_sts.Trim
            End Get
            Set(ByVal value As String)
                _p_out_account_sts = value
            End Set
        End Property
        Public Property PAYMENT_MODE() As String
            Get
                Return _p_out_payment_mode.Trim
            End Get
            Set(ByVal value As String)
                _p_out_payment_mode = value
            End Set
        End Property
        Public Property ADDRESS() As String
            Get
                Return _p_out_address.Trim
            End Get
            Set(ByVal value As String)
                _p_out_address = value
            End Set
        End Property
        Public Property FCL_AMT() As String
            Get
                Return _p_out_fcl_amt.Trim
            End Get
            Set(ByVal value As String)
                _p_out_fcl_amt = value
            End Set
        End Property
        Public Property HEALTH_CARD() As String
            Get
                Return _p_out_health_card.Trim
            End Get
            Set(ByVal value As String)
                _p_out_health_card = value
            End Set
        End Property
        Public Property HEAD_FLAG() As String
            Get
                Return _p_out_head_flag
            End Get
            Set(ByVal value As String)
                _p_out_head_flag = value
            End Set
        End Property
        Public Property MIN_AGE() As String
            Get
                Return _p_out_min_age.Trim
            End Get
            Set(ByVal value As String)
                _p_out_min_age = value
            End Set
        End Property
        Public Property MAX_AGE() As String
            Get
                Return _p_out_max_age.Trim
            End Get
            Set(ByVal value As String)
                _p_out_max_age = value
            End Set
        End Property
        Public Property CONTACT_PERSON() As String
            Get
                Return _p_out_contact_person.Trim
            End Get
            Set(ByVal value As String)
                _p_out_contact_person = value
            End Set
        End Property
        Public Property PLAN() As String
            Get
                Return _p_out_plan.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan = value
            End Set
        End Property
        Public Property PLAN_LIST() As DataTable
            Get
                Return _p_out_plan_list
            End Get
            Set(ByVal value As DataTable)
                _p_out_plan_list = value
            End Set
        End Property
        Public Property ISFOUND_DETAIL() As String
            Get
                Return _p_out_isfound_detail.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound_detail = value
            End Set
        End Property
    End Class
End Namespace

