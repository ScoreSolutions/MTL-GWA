Namespace CallWS
    Public Class InputHltClmPaidByBenefitPara
        Dim _grp_code As String = ""
        Dim _ac_code As String = ""
        Dim _pol_no As String = ""
        Dim _pol_year As String = ""
        Dim _user_id As String = ""
        Dim _language As String = ""

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
        Public Property POL_NO() As String
            Get
                Return _pol_no
            End Get
            Set(ByVal value As String)
                _pol_no = value
            End Set
        End Property
        Public Property POL_YEAR() As String
            Get
                Return _pol_year
            End Get
            Set(ByVal value As String)
                _pol_year = value
            End Set
        End Property
        Public Property USER_ID() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
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
    End Class
End Namespace

