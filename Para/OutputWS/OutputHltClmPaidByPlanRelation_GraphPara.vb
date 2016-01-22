Namespace OutputWS
    Public Class OutputHltClmPaidByPlanRelation_GraphPara
        Dim _clm_by_treat_grp As String = ""
        Dim _clm_by_treat_grp_list As DataTable
        Dim _isfound As String = ""

        Public Property CLM_BY_TREAT_GRP() As String
            Get
                Return _clm_by_treat_grp
            End Get
            Set(ByVal value As String)
                _clm_by_treat_grp = value
            End Set
        End Property
        Public Property CLM_BY_TREAT_GRP_LIST() As DataTable
            Get
                Return _clm_by_treat_grp_list
            End Get
            Set(ByVal value As DataTable)
                _clm_by_treat_grp_list = value
            End Set
        End Property
        Public Property ISFOUND() As String
            Get
                Return _isfound
            End Get
            Set(ByVal value As String)
                _isfound = value
            End Set
        End Property
    End Class
End Namespace

