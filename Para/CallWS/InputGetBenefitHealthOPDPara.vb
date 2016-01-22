Namespace CallWS
    Public Class InputGetBenefitHealthOPDPara
        Dim _grp_code As String = ""
        Dim _ac_code As String = ""
        Dim _ben_tab_code As String = ""
        Dim _ben_tab_s_date As String = ""
        Dim _ben_tab_end_no As String = ""
        Dim _language As String = ""
        Dim _benefit_type As String

        Public Property GRP_CODE() As String
            Get
                Return _grp_code
            End Get
            Set(ByVal value As String)
                _grp_code = value
            End Set
        End Property
        Public Property AC_CODE() As String
            Get
                Return _ac_code
            End Get
            Set(ByVal value As String)
                _ac_code = value
            End Set
        End Property
        Public Property BEN_TAB_CODE() As String
            Get
                Return _ben_tab_code
            End Get
            Set(ByVal value As String)
                _ben_tab_code = value
            End Set
        End Property
        Public Property BEN_TAB_S_DATE() As String
            Get
                Return _ben_tab_s_date
            End Get
            Set(ByVal value As String)
                _ben_tab_s_date = value
            End Set
        End Property
        Public Property BEN_TAB_END_NO() As String
            Get
                Return _ben_tab_end_no
            End Get
            Set(ByVal value As String)
                _ben_tab_end_no = value
            End Set
        End Property
        Public Property LANGUAGE() As String
            Get
                Return _language
            End Get
            Set(ByVal value As String)
                _language = value
            End Set
        End Property
        Public Property BENEFIT_TYPE() As String
            Get
                Return _benefit_type
            End Get
            Set(ByVal value As String)
                _benefit_type = value
            End Set
        End Property
    End Class
End Namespace

