Namespace CallWS
    Public Class InputDelHltClmPaidByBenefitPara
        Dim _user_id As String = ""
        Public Property USER_ID() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
            End Set
        End Property
    End Class
End Namespace

