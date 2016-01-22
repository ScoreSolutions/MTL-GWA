Imports LinqWS
Imports Para.OutputWS
Imports Para.CallWS
Imports Engine.Common

Namespace Reports
    Public Class ReportsENG
        Public Const HealthClaimPaidByBenefit As String = "rptHltClmByBenefit"
        Public Const HealthClaimPaidByAccountAndEmployee As String = "rptHltClmByAccEmp"
        Public Const HealthClaimPaidByDiagnosis As String = "rptHltClmByDiag"
        Public Const HealthClaimPaidByHospital As String = "rptHltClmByHospital"
        Public Const HealthClaimPaidByPlanRelationship As String = "rptHltClmByPlanRelation"

        Dim _RetMsg As String = ""
        Public Property RETURN_MSG() As String
            Get
                Return _RetMsg
            End Get
            Set(ByVal value As String)
                _RetMsg = value
            End Set
        End Property

        Public Function GetUserJoinCaseDT(ByVal UserID As String) As DataTable
            Dim eng As New WebServiceENG
            Dim para As New InputGetUserJoinCasePara
            para.USER_ID = UserID
            Dim output As OutputGetUserJoinCasePara = eng.GetUserJoinCase(para)
            Dim dt As New DataTable
            If output.ISFOUND_CASE = "Y" Then
                dt = output.OUT_CASE_LIST
            End If

            Return dt
        End Function

#Region "ReportHealthClaimPaidByAccountAndEmployeeDS"
        Public Function GetHealthClaimPaidByAccountAndEmployeeDS(ByVal para As InputHltClmPaidByAcc_EmpPara) As DataSet
            Dim ret As New DataSet
            ret.DataSetName = "igl"
            'iga033tb  igb013t   igd007t   igd007t033 igd007t02
            ret.Tables.Add(Getigd007tDT())
            ret.Tables.Add(Getiga033tbDT())
            ret.Tables.Add(Getigb013tDT())
            ret.Tables.Add(Getigd007t022DT)
            ret.Tables.Add(Getigd007t02DT())
            ret.Tables.Add(Getigb006tDT())

            Return ret
        End Function
        Private Function Getigb006tDT() As DataTable
            Dim dt As New DataTable
            dt.TableName = "igb006t"
            dt.Columns.Add("sect_desc_t")

            Dim dr As DataRow = dt.NewRow
            dr("sect_desc_t") = "YYYY"
            dt.Rows.Add(dr)

            Return dt
        End Function
        Private Function Getigd007t022DT() As DataTable
            Dim dt As New DataTable
            dt.TableName = "igd007t022"
            dt.Columns.Add("rep_user_id")
            dt.Columns.Add("com_code")
            dt.Columns.Add("brch_code")
            dt.Columns.Add("grp_code")
            dt.Columns.Add("ac_code")
            dt.Columns.Add("pol_year", GetType(Double))
            dt.Columns.Add("mem_no1")
            dt.Columns.Add("mem_no2")
            dt.Columns.Add("claim_time_d", GetType(Double))
            dt.Columns.Add("claim_paid_d", GetType(Double))
            dt.Columns.Add("claim_time_i", GetType(Double))
            dt.Columns.Add("claim_paid_i", GetType(Double))
            dt.Columns.Add("claim_time_o", GetType(Double))
            dt.Columns.Add("claim_paid_o", GetType(Double))
            dt.Columns.Add("claim_time_m", GetType(Double))
            dt.Columns.Add("claim_paid_m", GetType(Double))
            dt.Columns.Add("sect_code")
            dt.Columns.Add("mem_name_t")
            dt.Columns.Add("type")

            Dim dr As DataRow = dt.NewRow
            dr("rep_user_id") = "XXXX"
            dr("com_code") = "XXXX"
            dr("brch_code") = "XXXX"
            dr("grp_code") = "G00-0126"
            dr("ac_code") = "A00-0239"
            dr("pol_year") = 28
            dr("mem_no1") = "0"
            dr("mem_no2") = "0"
            dr("claim_time_d") = 1
            dr("claim_paid_d") = 450
            dr("claim_time_i") = 1
            dr("claim_paid_i") = 450
            dr("claim_time_o") = 1
            dr("claim_paid_o") = 450
            dr("claim_time_m") = 1
            dr("claim_paid_m") = 450
            dr("sect_code") = "0000"
            dr("mem_name_t") = "AAAAAAAAAAAAAA"
            dr("type") = "1"
            dt.Rows.Add(dr)

            Return dt

        End Function
#End Region

#Region "ReportGetHealthClaimPaidByBenefitDS"
        Public Function GetHealthClaimPaidByBenefitDS() As DataSet
            Dim ret As New DataSet
            ret.DataSetName = "igl"
            'iga033tb  igb013t   igd007t   igd007t033 igd007t02
            ret.Tables.Add(Getigd007tDT())
            ret.Tables.Add(Getiga033tbDT())
            ret.Tables.Add(Getigb013tDT())
            ret.Tables.Add(Getigd007t033DT())
            ret.Tables.Add(Getigd007t02DT())

            Return ret
        End Function
        Private Function Getiga033tbDT() As DataTable
            Dim ret As New DataTable
            ret.TableName = "iga033tb"
            'ret.Columns.Add("com_code")
            'ret.Columns.Add("ben_code")
            'ret.Columns.Add("ben_desc_t")
            'ret.Columns.Add("ben_desc_e")
            ret.Columns.Add("ben_shtdesc_t")
            ret.Columns.Add("ben_shtdesc_e")
            'ret.Columns.Add("plan_type")

            Dim dr As DataRow = ret.NewRow
            dr("ben_shtdesc_t") = "ค่ารักษาฟัน"
            dr("ben_shtdesc_e") = "ค่ารักษาฟันE"
            ret.Rows.Add(dr)

            dr = ret.NewRow
            dr("ben_shtdesc_t") = "ค่ารักษาฟัน"
            dr("ben_shtdesc_e") = "ค่ารักษาฟันE"
            ret.Rows.Add(dr)

            dr = ret.NewRow
            dr("ben_shtdesc_t") = "ค่ารักษาฟัน"
            dr("ben_shtdesc_e") = "ค่ารักษาฟันE"
            ret.Rows.Add(dr)

            Return ret
        End Function
        Private Function Getigb013tDT() As DataTable
            Dim ret As New DataTable
            ret.TableName = "igb013t"
            ret.Columns.Add("pol_name_t")

            Dim dr As DataRow = ret.NewRow
            dr("pol_name_t") = "Dell Computer (Thailand) Company Limited"
            ret.Rows.Add(dr)

            Return ret
        End Function
        Private Function Getigd007t033DT() As DataTable
            Dim ret As New DataTable
            ret.TableName = "igd007t033"
            ret.Columns.Add("ben_code")
            ret.Columns.Add("claim_time_a", GetType(Double))
            ret.Columns.Add("claim_incur_a", GetType(Double))
            ret.Columns.Add("claim_paid_a", GetType(Double))
            ret.Columns.Add("claim_not_a", GetType(Double))
            ret.Columns.Add("claim_time_h", GetType(Double))
            ret.Columns.Add("claim_incur_h", GetType(Double))
            ret.Columns.Add("claim_paid_h", GetType(Double))
            ret.Columns.Add("claim_not_h", GetType(Double))

            Dim dr As DataRow = ret.NewRow
            dr("ben_code") = "SSS"
            dr("claim_time_a") = 0
            dr("claim_time_h") = 19
            dr("claim_incur_a") = 0
            dr("claim_incur_h") = 16414
            dr("claim_paid_a") = 0
            dr("claim_paid_h") = 13044
            dr("claim_not_a") = 0
            dr("claim_not_h") = 0
            ret.Rows.Add(dr)

            dr = ret.NewRow
            dr("ben_code") = "SSS"
            dr("claim_time_a") = 0
            dr("claim_time_h") = 19
            dr("claim_incur_a") = 0
            dr("claim_incur_h") = 16414
            dr("claim_paid_a") = 0
            dr("claim_paid_h") = 13044
            dr("claim_not_a") = 0
            dr("claim_not_h") = 0
            ret.Rows.Add(dr)

            dr = ret.NewRow
            dr("ben_code") = "SSS"
            dr("claim_time_a") = 0
            dr("claim_time_h") = 19
            dr("claim_incur_a") = 0
            dr("claim_incur_h") = 16414
            dr("claim_paid_a") = 0
            dr("claim_paid_h") = 13044
            dr("claim_not_a") = 0
            dr("claim_not_h") = 0
            ret.Rows.Add(dr)


            Return ret
        End Function
        Private Function Getigd007tDT() As DataTable
            Dim ret As New DataTable
            ret.TableName = "igd007t"
            ret.Columns.Add("com_code")
            ret.Columns.Add("brch_code")
            ret.Columns.Add("grp_code")
            ret.Columns.Add("ac_code")
            ret.Columns.Add("as_of_date", GetType(Date))
            ret.Columns.Add("pol_no")
            ret.Columns.Add("pol_year", GetType(Integer))
            ret.Columns.Add("ac_name_t")
            ret.Columns.Add("ac_name_e")
            ret.Columns.Add("start_date", GetType(Date))
            ret.Columns.Add("expire_date", GetType(Date))

            Dim dr As DataRow = ret.NewRow
            dr("com_code") = "XXXX"
            dr("brch_code") = "XXXX"
            dr("grp_code") = "G00-0126"
            dr("ac_code") = "A00-0239"
            dr("as_of_date") = New Date(2011, 1, 1)
            dr("pol_no") = "00111832"
            dr("pol_year") = 7
            dr("ac_name_t") = "Dell Corporation (Thailand) Co., Limited."
            dr("ac_name_e") = "Dell Corporation (Thailand) Co., Limited."
            dr("start_date") = New Date(2005, 1, 1)
            dr("expire_date") = New Date(2006, 3, 31)
            ret.Rows.Add(dr)

            Return ret
        End Function
        Private Function Getigd007t02DT() As DataTable
            Dim dt As New DataTable
            dt.TableName = "igd007t02"
            dt.Columns.Add("treat_group")
            dt.Columns.Add("net_approve_amt", GetType(Double))

            Dim dr As DataRow = dt.NewRow
            dr("treat_group") = "D"
            dr("net_approve_amt") = 500
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("treat_group") = "O"
            dr("net_approve_amt") = 10000
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("treat_group") = "I"
            dr("net_approve_amt") = 8500
            dt.Rows.Add(dr)

            Return dt
        End Function
#End Region


        Public Function GetHealthClaimPaidByAccountAndEmployee(ByVal para As InputHltClmPaidByAcc_EmpPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByAc_EmpPara = ws.HltClmPaidByAcc_Emp(para)
            Dim dt As DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.HLT_CLM_LIST

                ws.DelHltClmPaidByAcc_Emp(para.USER_ID)
            Else
                _RetMsg = oup.MSG
            End If
            Return dt
        End Function

        Public Function GetHealthClaimPaidByBenefit(ByVal para As InputHltClmPaidByBenefitPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByBenefitPara = ws.HltClmPaidByBenefit(para)
            Dim dt As New DataTable
            If oup.ISFOUND = "Y" Then
                'Table
                dt.Columns.Add("grp_code")
                dt.Columns.Add("pol_desc")
                dt.Columns.Add("pol_year")
                dt.Columns.Add("ac_desc")
                dt.Columns.Add("as_of_date")
                dt.Columns.Add("effect_date")
                dt.Columns.Add("grouprep")

                dt.Columns.Add("benefit")
                dt.Columns.Add("frequency_accident", GetType(Double))
                dt.Columns.Add("frequency_health", GetType(Double))
                dt.Columns.Add("incurred_amt_accident", GetType(Double))
                dt.Columns.Add("incurred_amt_health", GetType(Double))
                dt.Columns.Add("payment_accident", GetType(Double))
                dt.Columns.Add("payment_health", GetType(Double))
                dt.Columns.Add("not_cover_accident", GetType(Double))
                dt.Columns.Add("not_cover_health", GetType(Double))


                'Graph
                dt.Columns.Add("treatment_group")
                dt.Columns.Add("net_approve_amt", GetType(Double))
                'dt.Columns.Add("grouprep")

                Dim paraG As New InputHltClmPaidByBenefitGraphPara
                paraG.GRP_CODE = para.GRP_CODE
                paraG.AC_CODE = para.AC_CODE
                paraG.POL_YEAR = para.POL_YEAR
                paraG.POL_NO = para.POL_NO
                Dim dtG As New DataTable
                dtG = GetHealthClaimPaidByBenefitGraph(paraG)

                If oup.HLT_CLM_LIST IsNot Nothing Then
                    For Each drS As DataRow In oup.HLT_CLM_LIST.Rows
                        Dim dr As DataRow = dt.NewRow
                        dr("grp_code") = drS("grp_code")
                        dr("pol_desc") = drS("pol_desc")
                        dr("pol_year") = drS("pol_year")
                        dr("ac_desc") = drS("ac_desc")
                        dr("as_of_date") = drS("as_of_date")
                        dr("effect_date") = drS("effect_date")
                        dr("grouprep") = drS("grouprep")

                        dr("benefit") = drS("benefit")
                        dr("frequency_accident") = drS("frequency_accident")
                        dr("frequency_health") = drS("frequency_health")
                        dr("incurred_amt_accident") = drS("incurred_amt_accident")
                        dr("incurred_amt_health") = drS("incurred_amt_health")
                        dr("payment_accident") = drS("payment_accident")
                        dr("payment_health") = drS("payment_health")
                        dr("not_cover_accident") = drS("not_cover_accident")
                        dr("not_cover_health") = drS("not_cover_health")
                        dt.Rows.Add(dr)
                    Next

                    For i As Integer = 0 To dtG.Rows.Count - 1
                        Dim dr As DataRow = dt.NewRow
                        Dim vTrement As String = ""
                        If dtG(i)("treatment_group") = "D" Then
                            vTrement = "Dental"
                        ElseIf dtG(i)("treatment_group") = "I" Then
                            vTrement = "IPD"
                        ElseIf dtG(i)("treatment_group") = "O" Then
                            vTrement = "OPD"
                        ElseIf dtG(i)("treatment_group") = "M" Then
                            vTrement = "Maternity"
                        End If
                        dr("treatment_group") = vTrement
                        dr("net_approve_amt") = dtG(i)("net_approve_amt")
                        dr("grouprep") = dtG(i)("grouprep")
                        dt.Rows.Add(dr)
                    Next
                End If

                Dim delPara As New InputDelHltClmPaidByBenefitPara
                delPara.USER_ID = para.USER_ID
                ws.DelHltClmPaidByBenefit(delPara)
            Else
                _RetMsg = ws.ErrorMessage
            End If

            Return dt
        End Function

        Public Function GetHealthClaimPaidByBenefitGraph(ByVal para As InputHltClmPaidByBenefitGraphPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByBenefitGraphPara = ws.HltClmPaidByBenefitGraph(para)
            Dim dt As DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.CLM_BY_TREAT_GRP_LIST
            End If
            Return dt
        End Function

        Public Function GetHealthClaimPaidByDiagnosis(ByVal para As InputHltClmPaidByDiagnosePara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByDiagnosePara = ws.HltClmPaidByDiagnose(para)
            Dim dt As DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.HLT_CLM_LIST
                ws.DelHltClmPaidByDiagnose(para.USER_ID)
            Else
                _RetMsg = ws.ErrorMessage
            End If

            Return dt
        End Function

        Public Function GetHealthClaimPaidByHospital(ByVal para As InputHltClmPaidByHospitalPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByHospitalPara = ws.HltClmPaidByHospital(para)
            Dim dt As DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.HLT_CLM_LIST
                ws.DelHltClmPaidByHospital(para.USER_ID)
            Else
                _RetMsg = ws.ErrorMessage
            End If
            Return dt
        End Function

        Public Function GetHealthClaimPaidByPlanRelation(ByVal para As InputHltClmPaidByPlanRelationPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputHltClmPaidByPlanRelationPara = ws.HltClmByPlanRelation(para)
            Dim dt As DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.HLT_CLM_LIST

                Dim inpG As New InputHltClmPaidByPlanRelation_GraphPara
                inpG.GRP_CODE = para.GRP_CODE
                inpG.AC_CODE = para.AC_CODE
                inpG.POL_YEAR = para.POL_YEAR
                Dim outG As OutputHltClmPaidByPlanRelation_GraphPara = ws.HltClmPaidByPlanRelation_Graph(inpG)
                If outG.ISFOUND = "Y" Then
                    Dim dtG As DataTable = outG.CLM_BY_TREAT_GRP_LIST
                    If dtG IsNot Nothing Then
                        For Each drG As DataRow In dtG.Rows
                            If Convert.IsDBNull(drG("treament_group")) = False Then
                                Dim dr As DataRow = dt.NewRow
                                dr("plan_code") = drG("plan_code")
                                dr("treament_group") = drG("treament_group")
                                dr("treament_value") = drG("treament_value")
                                dt.Rows.Add(dr)
                            End If
                        Next
                    End If
                End If

                ws.DelHltClmPaidByPlanRelation(para.USER_ID)
            Else
                _RetMsg = ws.ErrorMessage
            End If
            Return dt
        End Function
    End Class
End Namespace
