﻿Namespace CallWS
    Public Class InputGetUserProfilePara
        Dim _p_in_user_id As String = ""
        Dim _p_in_user_passwd As String = ""

        Public Property USER_ID() As String
            Get
                Return _p_in_user_id
            End Get
            Set(ByVal value As String)
                _p_in_user_id = value
            End Set
        End Property

        Public Property USER_PASSWD() As String
            Get
                Return _p_in_user_passwd
            End Get
            Set(ByVal value As String)
                _p_in_user_passwd = value
            End Set
        End Property
    End Class
End Namespace
