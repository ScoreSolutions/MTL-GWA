Namespace OutputWS
    Public Class OutputGetBenefitNonHealthPara
        Dim _ins_type As String = ""
        Dim _benefit As String = ""
        Dim _benefit_list As DataTable
        Dim _add_risk_flag As String = ""
        Dim _add_risk As String = ""
        Dim _remark As String = ""
        Dim _isFound_non_health As String = ""

        Public Property INS_TYPE() As String
            Get
                Return _ins_type
            End Get
            Set(ByVal value As String)
                _ins_type = value
            End Set
        End Property
        Public Property BENEFIT() As String
            Get
                Return _benefit
            End Get
            Set(ByVal value As String)
                _benefit = value
            End Set
        End Property
        Public Property BENEFIT_LIST() As DataTable
            Get
                Return _benefit_list
            End Get
            Set(ByVal value As DataTable)
                _benefit_list = value
            End Set
        End Property
        Public Property ADD_RISK_FLAG() As String
            Get
                Return _add_risk_flag
            End Get
            Set(ByVal value As String)
                _add_risk_flag = value
            End Set
        End Property
        Public Property ADD_RISK() As String
            Get
                Return _add_risk
            End Get
            Set(ByVal value As String)
                _add_risk = value
            End Set
        End Property

        Public Property REMARKS() As String
            Get
                Return _remark
            End Get
            Set(ByVal value As String)
                _remark = value
            End Set
        End Property
        Public Property ISFOUND_NON_HEALTH() As String
            Get
                Return _isFound_non_health
            End Get
            Set(ByVal value As String)
                _isFound_non_health = value
            End Set
        End Property
    End Class
End Namespace

