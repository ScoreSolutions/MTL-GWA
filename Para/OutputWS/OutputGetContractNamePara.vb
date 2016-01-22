
Namespace OutputWS
    Public Class OutputGetContractNamePara
        Dim _p_out_gpo_name As String = ""
        Dim _p_out_gpo_email As String = ""
        Dim _p_out_gpo_tel As String = ""
        Dim _p_out_gpo_cc_email As String = ""
        Dim _p_out_isfound As String = ""

        Public Property GPO_NAME() As String
            Get
                Return _p_out_gpo_name.Trim
            End Get
            Set(ByVal value As String)
                _p_out_gpo_name = value
            End Set
        End Property
        Public Property GPO_EMAIL() As String
            Get
                Return _p_out_gpo_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_gpo_email = value
            End Set
        End Property
        Public Property GPO_TEL() As String
            Get
                Return _p_out_gpo_tel.Trim
            End Get
            Set(ByVal value As String)
                _p_out_gpo_tel = value
            End Set
        End Property
        Public Property GPO_CC_EMAIL() As String
            Get
                Return _p_out_gpo_cc_email.Trim
            End Get
            Set(ByVal value As String)
                _p_out_gpo_cc_email = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _p_out_isfound.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound = value
            End Set
        End Property
    End Class
End Namespace

