Namespace OutputWS
    Public Class OutputHltClmPaidByHospitalPara
        Dim _as_of_date As String = ""
        Dim _pol_name As String = ""
        Dim _ac_name As String = ""
        Dim _effect_date As String = ""
        Dim _expire_date As String = ""
        Dim _hlt_clm1 As String = ""
        Dim _hlt_clm2 As String = ""
        Dim _hlt_clm3 As String = ""
        Dim _hlt_clm_list As DataTable
        Dim _isfound As String = ""

        Public Property AS_OF_DATE() As String
            Get
                Return _as_of_date.Trim
            End Get
            Set(ByVal value As String)
                _as_of_date = value
            End Set
        End Property
        Public Property POL_NAME() As String
            Get
                Return _pol_name.Trim
            End Get
            Set(ByVal value As String)
                _pol_name = value
            End Set
        End Property
        Public Property AC_NAME() As String
            Get
                Return _ac_name.Trim
            End Get
            Set(ByVal value As String)
                _ac_name = value
            End Set
        End Property
        Public Property EFFECT_DATE() As String
            Get
                Return _effect_date.Trim
            End Get
            Set(ByVal value As String)
                _effect_date = value
            End Set
        End Property
        Public Property EXPIRE_DATE() As String
            Get
                Return _expire_date.Trim
            End Get
            Set(ByVal value As String)
                _expire_date = value
            End Set
        End Property
        Public Property HLT_CLM1() As String
            Get
                Return _hlt_clm1.Trim
            End Get
            Set(ByVal value As String)
                _hlt_clm1 = value
            End Set
        End Property
        Public Property HLT_CLM2() As String
            Get
                Return _hlt_clm2
            End Get
            Set(ByVal value As String)
                _hlt_clm2 = value
            End Set
        End Property
        Public Property HLT_CLM3() As String
            Get
                Return _hlt_clm3
            End Get
            Set(ByVal value As String)
                _hlt_clm3 = value
            End Set
        End Property
        Public Property HLT_CLM_LIST() As DataTable
            Get
                Return _hlt_clm_list
            End Get
            Set(ByVal value As DataTable)
                _hlt_clm_list = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _isfound.Trim
            End Get
            Set(ByVal value As String)
                _isfound = value
            End Set
        End Property
    End Class
End Namespace

