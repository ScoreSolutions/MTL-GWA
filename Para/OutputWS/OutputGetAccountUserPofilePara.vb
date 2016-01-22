Namespace OutputWS
    Public Class OutputGetAccountUserPofilePara
        Dim _grp_code As String = ""
        Dim _ac_name As String = ""
        Dim _pol_no As String = ""
        Dim _pol_year As Int16
        Dim _user_gpo_id As String = ""
        Dim _language As String = ""
        Dim _isfound As String = ""

        Public Property GRP_CODE() As String
            Get
                Return _grp_code.Trim
            End Get
            Set(ByVal value As String)
                _grp_code = value
            End Set
        End Property
        Public Property AC_NAME() As String
            Get
                Return _ac_name.Trim
            End Get
            Set(ByVal value As String)
                _ac_name = value
            End Set
        End Property
        Public Property POL_NO() As String
            Get
                Return _pol_no.Trim
            End Get
            Set(ByVal value As String)
                _pol_no = value
            End Set
        End Property
        Public Property POL_YEAR() As Int16
            Get
                Return _pol_year
            End Get
            Set(ByVal value As Int16)
                _pol_year = value
            End Set
        End Property
        Public Property USER_GPO_ID() As String
            Get
                Return _user_gpo_id.Trim
            End Get
            Set(ByVal value As String)
                _user_gpo_id = value
            End Set
        End Property
        Public Property LANGUAGE() As String
            Get
                Return _language.Trim
            End Get
            Set(ByVal value As String)
                _language = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _isfound
            End Get
            Set(ByVal value As String)
                _isfound = value
            End Set
        End Property
    End Class
End Namespace

