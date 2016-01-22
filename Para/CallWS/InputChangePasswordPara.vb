Namespace CallWS
    Public Class InputChangePasswordPara
        Dim _p_in_user_id As String = ""
        Dim _p_in_user_passwd As String = ""
        Dim _p_in_pass_date As String = ""
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
        Public Property USER_PASSWORD() As String
            Get
                Return _p_in_user_passwd
            End Get
            Set(ByVal value As String)
                _p_in_user_passwd = value
            End Set
        End Property
        Public Property PASS_DATE() As String
            Get
                Return _p_in_pass_date
            End Get
            Set(ByVal value As String)
                _p_in_pass_date = value
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

