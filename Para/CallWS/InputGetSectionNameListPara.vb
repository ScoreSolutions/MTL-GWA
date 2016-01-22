Namespace CallWS
    Public Class InputGetSectionNameListPara
        Dim _grp_code As String = ""
        Dim _ac_code As String = ""
        Dim _sect_code As String = ""
        Dim _sect_name As String = ""
        Dim _language As String = ""

        Public Property GRP_CODE() As String
            Get
                Return _grp_code
            End Get
            Set(ByVal value As String)
                _grp_code = value
            End Set
        End Property
        Public Property AC_CODE() As String
            Get
                Return _ac_code
            End Get
            Set(ByVal value As String)
                _ac_code = value
            End Set
        End Property
        Public Property SECT_CODE() As String
            Get
                Return _sect_code
            End Get
            Set(ByVal value As String)
                _sect_code = value
            End Set
        End Property
        Public Property SECT_NAME() As String
            Get
                Return _sect_name
            End Get
            Set(ByVal value As String)
                _sect_name = value
            End Set
        End Property
        Public Property LANGUAGE() As String
            Get
                Return _language
            End Get
            Set(ByVal value As String)
                _language = value
            End Set
        End Property
    End Class
End Namespace

