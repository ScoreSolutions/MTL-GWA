Namespace CallWS
    Public Class InputGetContractNamePara
        Dim _p_in_gpo_user_id As String
        Dim _p_in_language As String

        Public Property GPO_USER_ID() As String
            Get
                Return _p_in_gpo_user_id
            End Get
            Set(ByVal value As String)
                _p_in_gpo_user_id = value
            End Set
        End Property

        Public Property LANGUAGE() As String
            Get
                Return _p_in_language
            End Get
            Set(ByVal value As String)
                _p_in_language = value
            End Set
        End Property
    End Class
End Namespace

