Namespace CallWS
    Public Class InputGetAccountDetailPara
        Dim _p_grp_code As String = ""
        Dim _p_ac_code As String = ""
        Dim _p_pol_year As String = ""
        Dim _p_language As String = ""

        Public Property P_GRP_CODE() As String
            Get
                Return _p_grp_code.Trim
            End Get
            Set(ByVal value As String)
                _p_grp_code = value
            End Set
        End Property
        Public Property P_AC_CODE() As String
            Get
                Return _p_ac_code.Trim
            End Get
            Set(ByVal value As String)
                _p_ac_code = value
            End Set
        End Property
        Public Property P_POL_YEAR() As String
            Get
                Return _p_pol_year.Trim
            End Get
            Set(ByVal value As String)
                _p_pol_year = value
            End Set
        End Property
        Public Property P_LANGUATE() As String
            Get
                Return _p_language.Trim
            End Get
            Set(ByVal value As String)
                _p_language = value
            End Set
        End Property
    End Class
End Namespace

