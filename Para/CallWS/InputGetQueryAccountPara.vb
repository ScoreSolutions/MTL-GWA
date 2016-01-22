Namespace CallWS
    Public Class InputGetQueryAccountPara
        Dim _USER_ID As String = ""
        Dim _GROUP_CODE As String = ""
        Dim _POLICY_NO As String = ""
        Dim _ACCOUNT_CODE As String = ""
        Dim _ACCOUNT_NAME As String = ""

        Public Property USER_ID() As String
            Get
                Return _USER_ID
            End Get
            Set(ByVal value As String)
                _USER_ID = value
            End Set
        End Property
        Public Property GROUP_CODE() As String
            Get
                Return _GROUP_CODE
            End Get
            Set(ByVal value As String)
                _GROUP_CODE = value
            End Set
        End Property
        Public Property POLICY_NO() As String
            Get
                Return _POLICY_NO
            End Get
            Set(ByVal value As String)
                _POLICY_NO = value
            End Set
        End Property

        Public Property ACCOUNT_CODE() As String
            Get
                Return _ACCOUNT_CODE
            End Get
            Set(ByVal value As String)
                _ACCOUNT_CODE = value
            End Set
        End Property

        Public Property ACCOUNT_NAME() As String
            Get
                Return _ACCOUNT_NAME
            End Get
            Set(ByVal value As String)
                _ACCOUNT_NAME = value
            End Set
        End Property
    End Class
End Namespace

