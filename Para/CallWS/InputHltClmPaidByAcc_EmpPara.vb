Namespace CallWS
    Public Class InputHltClmPaidByAcc_EmpPara
        Dim _grp_code As String = ""
        Dim _ac_code As String = ""
        Dim _pol_no As String = ""
        Dim _pol_year As String = ""
        Dim _language As String = ""
        Dim _user_id As String = ""
        Dim _section_code As String = ""
        Dim _section_name As String = ""
        Dim _top_level As String = ""
        Dim _sort_type As String = ""

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
        Public Property LANGUAGE() As String
            Get
                Return _language
            End Get
            Set(ByVal value As String)
                _language = value
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
        Public Property SECTION_CODE() As String
            Get
                Return _section_code
            End Get
            Set(ByVal value As String)
                _section_code = value
            End Set
        End Property
        Public Property SECTION_NAME() As String
            Get
                Return _section_name.Trim()
            End Get
            Set(ByVal value As String)
                _section_name = value
            End Set
        End Property
        Public Property TOP_LEVEL() As String
            Get
                Return _top_level
            End Get
            Set(ByVal value As String)
                _top_level = value
            End Set
        End Property
        Public Property SORT_TYPE() As String
            Get
                Return _sort_type.Trim
            End Get
            Set(ByVal value As String)
                _sort_type = value
            End Set
        End Property

    End Class
End Namespace

