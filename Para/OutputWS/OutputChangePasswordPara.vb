Namespace OutputWS
    Public Class OutputChangePasswordPara
        Dim _p_out_ack As String = ""
        Public Property OUT_ACK() As String
            Get
                Return _p_out_ack.Trim
            End Get
            Set(ByVal value As String)
                _p_out_ack = value
            End Set
        End Property
    End Class
End Namespace

