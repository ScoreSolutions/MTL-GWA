Namespace CallWS
    Public Class InputDeleteUserProfilePara
        Dim _p_in_user_id As String
        Public Property USER_ID() As String
            Get
                Return _p_in_user_id
            End Get
            Set(ByVal value As String)
                _p_in_user_id = value
            End Set
        End Property
    End Class
End Namespace
