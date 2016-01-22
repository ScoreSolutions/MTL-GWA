Namespace CallWS
    Public Class InputChangeUserProfilePara
        Dim _p_in_user_id As String = ""
        Dim _p_in_user_passwd As String = ""
        Dim _p_in_user_email As String = ""
        Dim _p_in_user_tel As String = ""

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
    End Class
End Namespace
