Namespace OutputWS
    Public Class OutputInsertUserProfileDetailPara
        Dim _ack As String = ""
        Public Property ACK() As String
            Get
                Return _ack.Trim
            End Get
            Set(ByVal value As String)
                _ack = value
            End Set
        End Property
    End Class
End Namespace

