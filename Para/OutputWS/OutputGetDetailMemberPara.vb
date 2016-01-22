Namespace OutputWS
    Public Class OutputGetDetailMemberPara
        Dim _p_out_effect_date As String = ""
        Dim _p_out_plan_e_date As String = ""
        Dim _p_out_benefit_sts As String = ""
        Dim _p_out_mem_dob As String = ""
        Dim _p_out_mem_age As String = ""
        Dim _p_out_mem_sex As String = ""
        Dim _p_out_mem_sect As String = ""
        Dim _p_out_mem_bkac_no As String = ""
        Dim _p_out_plan_hlt_card As String = ""
        Dim _p_out_consider As String = ""
        Dim _p_out_plan_notepad1 As String = ""
        Dim _p_out_plan_notepad2 As String = ""
        Dim _p_out_plan_nonhlt As String = ""
        Dim _p_out_plan_nonth_list As DataTable
        Dim _p_out_plan_code_h1 As String = ""
        Dim _p_out_plan_code_h2 As String = ""
        Dim _p_out_plan_hlt1 As String = ""
        Dim _p_out_plan_hlt2 As String = ""
        Dim _p_out_plan_hlt_list1 As DataTable
        Dim _p_out_plan_hlt_list2 As DataTable
        Dim _p_out_isfound_det As String = ""

        Public Property EFFECT_DATE() As String
            Get
                Return _p_out_effect_date.Trim
            End Get
            Set(ByVal value As String)
                _p_out_effect_date = value
            End Set
        End Property
        Public Property PLAN_E_DATE() As String
            Get
                Return _p_out_plan_e_date.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan_e_date = value
            End Set
        End Property
        Public Property BENEFIT_STS() As String
            Get
                Return _p_out_benefit_sts.Trim
            End Get
            Set(ByVal value As String)
                _p_out_benefit_sts = value
            End Set
        End Property
        Public Property MEM_DOB() As String
            Get
                Return _p_out_mem_dob.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_dob = value
            End Set
        End Property
        Public Property MEM_AGE() As String
            Get
                Return _p_out_mem_age.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_age = value
            End Set
        End Property
        Public Property MEM_SEX() As String
            Get
                Return _p_out_mem_sex.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_sex = value
            End Set
        End Property
        Public Property MEM_SECT() As String
            Get
                Return _p_out_mem_sect.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_sect = value
            End Set
        End Property
        Public Property MEM_BKAC_NO() As String
            Get
                Return _p_out_mem_bkac_no.Trim
            End Get
            Set(ByVal value As String)
                _p_out_mem_bkac_no = value
            End Set
        End Property
        Public Property HLT_CARD() As String
            Get
                Return _p_out_plan_hlt_card.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan_hlt_card = value
            End Set
        End Property
        Public Property CONSIDER() As String
            Get
                Return _p_out_consider.Trim
            End Get
            Set(ByVal value As String)
                _p_out_consider = value
            End Set
        End Property
        Public Property PLAN_NOTEPAD1() As String
            Get
                Return _p_out_plan_notepad1
            End Get
            Set(ByVal value As String)
                _p_out_plan_notepad1 = value
            End Set
        End Property
        Public Property PLAN_NOTEPAD2() As String
            Get
                Return _p_out_plan_notepad2
            End Get
            Set(ByVal value As String)
                _p_out_plan_notepad2 = value
            End Set
        End Property
        Public Property PLAN_NONHLT() As String
            Get
                Return _p_out_plan_nonhlt.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan_nonhlt = value
            End Set
        End Property
        Public Property PLAN_NONHLT_LIST() As DataTable
            Get
                Return _p_out_plan_nonth_list
            End Get
            Set(ByVal value As DataTable)
                _p_out_plan_nonth_list = value
            End Set
        End Property
        Public Property PLAN_CODE_H1() As String
            Get
                Return _p_out_plan_code_h1.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan_code_h1 = value
            End Set
        End Property
        Public Property PLAN_CODE_H2() As String
            Get
                Return _p_out_plan_code_h2
            End Get
            Set(ByVal value As String)
                _p_out_plan_code_h2 = value
            End Set
        End Property
        Public Property PLAN_HLT1() As String
            Get
                Return _p_out_plan_hlt1.Trim
            End Get
            Set(ByVal value As String)
                _p_out_plan_hlt1 = value
            End Set
        End Property
        Public Property PLAN_HLT2() As String
            Get
                Return _p_out_plan_hlt2
            End Get
            Set(ByVal value As String)
                _p_out_plan_hlt2 = value
            End Set
        End Property
        Public Property PLAN_HLT_LIST1() As DataTable
            Get
                Return _p_out_plan_hlt_list1
            End Get
            Set(ByVal value As DataTable)
                _p_out_plan_hlt_list1 = value
            End Set
        End Property
        Public Property PLAN_HLT_LIST2() As DataTable
            Get
                Return _p_out_plan_hlt_list2
            End Get
            Set(ByVal value As DataTable)
                _p_out_plan_hlt_list2 = value
            End Set
        End Property
        Public Property ISFOUND_DET() As String
            Get
                Return _p_out_isfound_det.Trim
            End Get
            Set(ByVal value As String)
                _p_out_isfound_det = value
            End Set
        End Property

    End Class
End Namespace
