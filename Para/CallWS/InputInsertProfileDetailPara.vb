Namespace CallWS
    Public Class InputInsertProfileDetailPara
        Dim _user_id As String = ""
        Dim _grp_code As String = ""
        Dim _ac_code As String = ""
        Dim _pol_year As Int16 = 0
        Dim _pol_no As String = ""
        Dim _user_gpo_id As String = ""
        Dim _language As String = ""
        Dim _input_person As String = ""
        Dim _create_dttm As String = ""
        Dim _mnt_dttm As String = ""

        Public Property USER_ID() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
            End Set
        End Property
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
        Public Property POL_YEAR() As String
            Get
                Return _pol_year
            End Get
            Set(ByVal value As String)
                _pol_year = value
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
        Public Property USER_GPO_ID() As String
            Get
                Return _user_gpo_id
            End Get
            Set(ByVal value As String)
                _user_gpo_id = value
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
        Public Property INPUT_PERSON() As String
            Get
                Return _input_person
            End Get
            Set(ByVal value As String)
                _input_person = value
            End Set
        End Property
        Public Property CREATE_DTTM() As String
            Get
                Return _create_dttm
            End Get
            Set(ByVal value As String)
                _create_dttm = value
            End Set
        End Property
        Public Property MNT_DTTM() As String
            Get
                Return _mnt_dttm
            End Get
            Set(ByVal value As String)
                _mnt_dttm = value
            End Set
        End Property
    End Class
End Namespace

