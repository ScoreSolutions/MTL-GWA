Namespace CallWS
    Public Class InputDeleteUserProfileDetailPara
        Dim _user_id As String = ""
        Dim _group_code As String = ""
        Dim _ac_code As String = ""

        Public Property USER_ID() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
            End Set
        End Property
        Public Property GROUP_CODE() As String
            Get
                Return _group_code
            End Get
            Set(ByVal value As String)
                _group_code = value
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
    End Class
End Namespace

