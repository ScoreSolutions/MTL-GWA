Namespace OutputWS
    Public Class OutputGetAccountNamePara
        Dim _ac_name As String = ""
        Dim _isFound As String = ""

        Public Property AC_NAME() As String
            Get
                Return _ac_name.Trim
            End Get
            Set(ByVal value As String)
                _ac_name = value
            End Set
        End Property

        Public Property ISFOUND() As String
            Get
                Return _isFound.Trim
            End Get
            Set(ByVal value As String)
                _isFound = value
            End Set
        End Property
    End Class
End Namespace

