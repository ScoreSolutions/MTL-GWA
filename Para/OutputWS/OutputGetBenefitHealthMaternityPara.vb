﻿Namespace OutputWS
    Public Class OutputGetBenefitHealthMaternityPara
        Dim _sub_ins_type As String = ""
        Dim _benefit As String = ""
        Dim _benefit_list As DataTable
        Dim _isFound_mater As String = ""

        Public Property SUB_INS_TYPE() As String
            Get
                Return _sub_ins_type
            End Get
            Set(ByVal value As String)
                _sub_ins_type = value
            End Set
        End Property
        Public Property BENEFIT() As String
            Get
                Return _benefit
            End Get
            Set(ByVal value As String)
                _benefit = value
            End Set
        End Property
        Public Property BENEFIT_LIST() As DataTable
            Get
                Return _benefit_list
            End Get
            Set(ByVal value As DataTable)
                _benefit_list = value
            End Set
        End Property
        Public Property ISFOUND_MASTER() As String
            Get
                Return _isFound_mater
            End Get
            Set(ByVal value As String)
                _isFound_mater = value
            End Set
        End Property
    End Class
End Namespace

