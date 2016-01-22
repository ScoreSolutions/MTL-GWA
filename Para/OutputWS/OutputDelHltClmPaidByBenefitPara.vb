Namespace OutputWS
    Public Class OutputDelHltClmPaidByBenefitPara
        Dim _ack As String = ""
        Public Property ACK() As String
            Get
                Return _ack
            End Get
            Set(ByVal value As String)
                _ack = value
            End Set
        End Property
    End Class
End Namespace

