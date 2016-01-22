Imports Para.CallWS
Imports Para.OutputWS
Imports Para.TABLE

Public Class WebGroupLinqWS
    Dim _err As String = ""
    Dim _user_id As String = ""
    Dim _isFound_userProfile As String = ""

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _err
        End Get
    End Property
    Public ReadOnly Property USER_ID() As String
        Get
            Return _user_id
        End Get
    End Property
    Public ReadOnly Property ISFOUND_USERPROFILE() As String
        Get
            Return _isFound_userProfile
        End Get
    End Property

    Public Function GetQueryAccount(ByVal inp As InputGetQueryAccountPara) As OutputGetQueryAccountPara
        Dim output As New OutputGetQueryAccountPara

        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetQueryAccount(inp.USER_ID, inp.GROUP_CODE, inp.POLICY_NO, inp.ACCOUNT_CODE, inp.ACCOUNT_NAME, output.ACCOUNT, output.ISFOUND_AC)
            If output.ISFOUND_AC = "Y" Then
                If output.ACCOUNT.Trim <> "" Then
                    Dim strRow() As String = Split(output.ACCOUNT.Trim(), "##")
                    If strRow.Length > 0 Then
                        output.ACCOUNT_LIST = New DataTable
                        output.ACCOUNT_LIST.Columns.Add("group_code")
                        output.ACCOUNT_LIST.Columns.Add("policy_no")
                        output.ACCOUNT_LIST.Columns.Add("account_code")
                        output.ACCOUNT_LIST.Columns.Add("account_name")
                        output.ACCOUNT_LIST.Columns.Add("ef_date")
                        output.ACCOUNT_LIST.Columns.Add("ep_date")
                        output.ACCOUNT_LIST.Columns.Add("policy_year")
                        output.ACCOUNT_LIST.Columns.Add("mtl_user_id")
                        output.ACCOUNT_LIST.Columns.Add("lang")
                        output.ACCOUNT_LIST.Columns.Add("CommandArgument")

                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.ACCOUNT_LIST.NewRow
                                    dr("group_code") = strField(0)
                                    dr("policy_no") = strField(1)
                                    dr("account_code") = strField(2)
                                    dr("account_name") = strField(3)
                                    dr("ef_date") = strField(4)
                                    dr("ep_date") = strField(5)
                                    dr("policy_year") = strField(6)
                                    dr("mtl_user_id") = strField(7)
                                    dr("lang") = strField(8)
                                    dr("CommandArgument") = strField(0) & "##" & strField(2) & "##" & strField(6) & "##" & strField(8)
                                    output.ACCOUNT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                        'output.ACCOUNT_LIST = dt
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = ex.Message
        Catch ex As IndexOutOfRangeException
            _err = ex.Message
        Catch ex As Exception
            _err = "ไม่สามารถเชื่อมต่อกับ Web Service : " & ex.Message
        End Try
        
        Return output
    End Function
    Public Function GetAccountDetail(ByVal inp As InputGetAccountDetailPara) As OutputGetAccountDetailPara
        Dim output As New OutputGetAccountDetailPara

        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetAccountDetail(inp.P_GRP_CODE, inp.P_AC_CODE, inp.P_POL_YEAR, inp.P_LANGUATE, output.POL_NAME, output.PAYMENT_MODE, output.ACCOUNT_STS, output.ADDRESS, output.FCL_AMT, output.HEALTH_CARD, output.HEAD_FLAG, output.MIN_AGE, output.MAX_AGE, output.CONTACT_PERSON, output.PLAN, output.ISFOUND_DETAIL)
            If output.ISFOUND_DETAIL = "Y" Then
                If output.PLAN <> "" Then
                    output.PLAN_LIST = New DataTable
                    output.PLAN_LIST.Columns.Add("benefit_plan")
                    output.PLAN_LIST.Columns.Add("benefit_type")
                    output.PLAN_LIST.Columns.Add("plan_type")
                    output.PLAN_LIST.Columns.Add("benefit_table_code")
                    output.PLAN_LIST.Columns.Add("benefit_table_start_date")
                    output.PLAN_LIST.Columns.Add("endorse_no")
                    output.PLAN_LIST.Columns.Add("money_amt")
                    output.PLAN_LIST.Columns.Add("remarks")
                    output.PLAN_LIST.Columns.Add("CommandArgument")

                    Dim strRow() As String = Split(output.PLAN.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.PLAN_LIST.NewRow
                                    dr("benefit_plan") = strField(0)
                                    dr("benefit_type") = strField(1)
                                    dr("plan_type") = strField(2)
                                    dr("benefit_table_code") = strField(3)
                                    dr("benefit_table_start_date") = strField(4)
                                    dr("endorse_no") = strField(5)
                                    dr("money_amt") = strField(6)
                                    dr("remarks") = strField(7)
                                    dr("CommandArgument") = strField(2)
                                    output.PLAN_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = ex.Message
        Catch ex As IndexOutOfRangeException
            _err = ex.Message
        Catch ex As Exception
            _err = ex.Message
        End Try

        Return output
    End Function

    Public Function GetBenefitNonHealth(ByVal inp As InputGetBenefitNonHealthPara) As OutputGetBenefitNonHealthPara
        Dim output As New OutputGetBenefitNonHealthPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitNonHealth(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.INS_TYPE, output.BENEFIT, output.ADD_RISK_FLAG, output.ADD_RISK, output.REMARKS, output.ISFOUND_NON_HEALTH)
            If output.ISFOUND_NON_HEALTH = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function
    Public Function GetBenefitHealthIPD(ByVal inp As InputGetBenefitHealthIPDPara) As OutputGetBenefitHealthIPDPara
        Dim output As New OutputGetBenefitHealthIPDPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitHealthIPD(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.SUB_INS_TYPE, output.BENEFIT, output.ISFOUND_IPD)
            If output.ISFOUND_IPD = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")
                    output.BENEFIT_LIST.Columns.Add("remarks")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    dr("remarks") = strField(2)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function
    Public Function GetBenefitHealthOPD(ByVal inp As InputGetBenefitHealthOPDPara) As OutputGetBenefitHealthOPDPara
        Dim output As New OutputGetBenefitHealthOPDPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitHealthOPD(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.SUB_INS_TYPE, output.BENEFIT, output.ISFOUND_OPD)
            If output.ISFOUND_OPD = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")
                    output.BENEFIT_LIST.Columns.Add("remarks")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    dr("remarks") = strField(2)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function

    Public Function GetBenefitHealthDental(ByVal inp As InputGetBenefitHealthDentalPara) As OutputGetBenefitHealthDentalPara
        Dim output As New OutputGetBenefitHealthDentalPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitHealthDental(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.SUB_INS_TYPE, output.BENEFIT, output.ISFOUND_DENTAL)
            If output.ISFOUND_DENTAL = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")
                    output.BENEFIT_LIST.Columns.Add("remarks")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    dr("remarks") = strField(2)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function

    Public Function GetBenefitHealthMajorMed(ByVal inp As InputGetBenefitHealthMajorMedPara) As OutputGetBenefitHealthMajorMedPara
        Dim output As New OutputGetBenefitHealthMajorMedPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitHealthMajorMed(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.SUB_INS_TYPE, output.BENEFIT, output.ISFOUND_MAJOR)
            If output.ISFOUND_MAJOR = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")
                    output.BENEFIT_LIST.Columns.Add("remarks")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    dr("remarks") = strField(2)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function

    Public Function GetBenefitHealthMaternity(ByVal inp As InputGetBenefitHealthMaternityPara) As OutputGetBenefitHealthMaternityPara
        Dim output As New OutputGetBenefitHealthMaternityPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '##### Call WS
            ws.GetBenefitHealthMaternity(inp.GRP_CODE, inp.AC_CODE, inp.BEN_TAB_CODE, inp.BEN_TAB_S_DATE, inp.BEN_TAB_END_NO, inp.LANGUAGE, output.SUB_INS_TYPE, output.BENEFIT, output.ISFOUND_MASTER)
            If output.ISFOUND_MASTER = "Y" Then
                If output.BENEFIT <> "" Then
                    output.BENEFIT_LIST = New DataTable
                    output.BENEFIT_LIST.Columns.Add("benefit")
                    output.BENEFIT_LIST.Columns.Add("money_amt")
                    output.BENEFIT_LIST.Columns.Add("remarks")

                    Dim strRow() As String = Split(output.BENEFIT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.BENEFIT_LIST.NewRow
                                    dr("benefit") = strField(0)
                                    dr("money_amt") = strField(1)
                                    dr("remarks") = strField(2)
                                    output.BENEFIT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetQueryMember(ByVal inp As InputGetQueryMemberPara) As OutputGetQueryMemberPara
        Dim output As New OutputGetQueryMemberPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '### Call WS
            ws.GetQueryMember(inp.P_IN_GRP_CODE, inp.P_IN_AC_CODE, inp.P_IN_POL_YEAR, inp.P_IN_SEC_CODE, inp.P_IN_LANGUAGE, inp.P_IN_MEMBER_NO, inp.P_IN_EMPLOYEE_NO, inp.P_IN_HLT_CARD_NO, inp.P_IN_MEM_NAME, inp.P_IN_MEM_SURNAME, output.MEMBER_SEARCH, output.MEMBER_SEARCH2, output.MEMBER_SEARCH3, output.MSG_DATA_OVER, output.ISFOUND_MEM)
            If output.ISFOUND_MEM = "Y" Then
                If output.MSG_DATA_OVER = "" Then
                    If output.MEMBER_SEARCH.Trim <> "" Then
                        output.MEMBER_LIST = New DataTable
                        output.MEMBER_LIST.Columns.Add("employee_no")
                        output.MEMBER_LIST.Columns.Add("member_no")
                        output.MEMBER_LIST.Columns.Add("member_name")
                        output.MEMBER_LIST.Columns.Add("relation")
                        output.MEMBER_LIST.Columns.Add("remarks")
                        output.MEMBER_LIST.Columns.Add("CommandArgument")
                        CreateMemberList(output.MEMBER_SEARCH, output.MEMBER_LIST, inp.P_IN_LANGUAGE)

                        If output.MEMBER_SEARCH2.Trim <> "" Then
                            CreateMemberList(output.MEMBER_SEARCH2, output.MEMBER_LIST, inp.P_IN_LANGUAGE)
                        End If
                        If output.MEMBER_SEARCH3.Trim <> "" Then
                            CreateMemberList(output.MEMBER_SEARCH3, output.MEMBER_LIST, inp.P_IN_LANGUAGE)
                        End If
                    End If
                Else
                    _err = "ข้อมูลที่ค้นหาได้มีปริมาณมากเกินไป กรุณากรอกข้อมูลเพิ่มเติมให้ชัดเจนมากกว่านี้ \n"
                    _err += "(Too much information to display, please indicate more information)"
                End If
            Else
                _err = "ไม่พบข้อมูล \r\n (Data not found)"
            End If
        Catch ex As TimeoutException
            output.ISFOUND_MEM = "N"
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            output.ISFOUND_MEM = "N"
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            output.ISFOUND_MEM = "N"
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ \n\r (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Private Sub CreateMemberList(ByVal MemberSearch As String, ByVal dt As DataTable, ByVal lang As String)
        Dim strRow() As String = Split(MemberSearch.Trim(), "##")
        If strRow.Length > 0 Then
            For Each Str As String In strRow
                If Str.Trim <> "" Then
                    Dim strField() As String = Str.Split("|")
                    If strField.Length > 0 Then
                        Dim dr As DataRow = dt.NewRow
                        dr("employee_no") = strField(0)
                        dr("member_no") = strField(1)
                        dr("member_name") = strField(2)

                        Dim relCode As String = Right(strField(1), 2)
                        If lang = "T" Then
                            dr("relation") = IIf(Left(relCode, 1) = "0", "พนักงาน", IIf(Left(relCode, 1) = "1", "คู่สมรส", "บุตร"))
                        ElseIf lang = "E" Then
                            dr("relation") = IIf(Left(relCode, 1) = "0", "Employee", IIf(Left(relCode, 1) = "1", "Spouse", "Child"))
                        End If

                        dr("remarks") = ""
                        dr("CommandArgument") = strField(0) & "##" & strField(1) & "##" & strField(2) & "##" & dr("relation")
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
        End If
    End Sub

    Public Function GetDetailMember(ByVal Inp As InputGetDetailMember) As OutputGetDetailMemberPara
        Dim output As New OutputGetDetailMemberPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '### Call WS
            ws.GetDetailMember(Inp.GRP_CODE, Inp.AC_CODE, Inp.POL_YEAR, Inp.LANGUAGE, Inp.MEMBER_NO, output.EFFECT_DATE, output.PLAN_E_DATE, output.BENEFIT_STS, output.MEM_DOB, output.MEM_AGE, output.MEM_SEX, output.MEM_SECT, output.MEM_BKAC_NO, output.HLT_CARD, output.CONSIDER, output.PLAN_NOTEPAD1, output.PLAN_NOTEPAD2, output.PLAN_NONHLT, output.PLAN_CODE_H1, output.PLAN_CODE_H2, output.PLAN_HLT1, output.PLAN_HLT2, output.ISFOUND_DET)
            If output.ISFOUND_DET = "Y" Then
                'LIFE
                If output.PLAN_NONHLT.Trim <> "" Then
                    output.PLAN_NONHLT_LIST = New DataTable
                    output.PLAN_NONHLT_LIST.Columns.Add("seq")
                    output.PLAN_NONHLT_LIST.Columns.Add("plan")
                    output.PLAN_NONHLT_LIST.Columns.Add("benefit")
                    output.PLAN_NONHLT_LIST.Columns.Add("money_amt")
                    output.PLAN_NONHLT_LIST.Columns.Add("remarks")
                    Dim strRow() As String = Split(output.PLAN_NONHLT.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.PLAN_NONHLT_LIST.NewRow
                                    dr("seq") = strField(0)
                                    dr("plan") = strField(1)
                                    dr("benefit") = strField(2)
                                    dr("money_amt") = strField(3)
                                    dr("remarks") = strField(4)
                                    output.PLAN_NONHLT_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If

                'HEALTH1
                If output.PLAN_HLT1.Trim <> "" Then
                    output.PLAN_HLT_LIST1 = New DataTable
                    output.PLAN_HLT_LIST1.Columns.Add("seq")
                    output.PLAN_HLT_LIST1.Columns.Add("benefit")
                    output.PLAN_HLT_LIST1.Columns.Add("money_amt")
                    output.PLAN_HLT_LIST1.Columns.Add("remarks")
                    Dim strRow() As String = Split(output.PLAN_HLT1.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.PLAN_HLT_LIST1.NewRow
                                    dr("seq") = strField(0)
                                    dr("benefit") = strField(1)
                                    dr("money_amt") = strField(2)
                                    dr("remarks") = strField(3)
                                    output.PLAN_HLT_LIST1.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If

                'HEALTH2
                If output.PLAN_HLT2.Trim <> "" Then
                    output.PLAN_HLT_LIST2 = New DataTable
                    output.PLAN_HLT_LIST2.Columns.Add("seq")
                    output.PLAN_HLT_LIST2.Columns.Add("benefit")
                    output.PLAN_HLT_LIST2.Columns.Add("money_amt")
                    output.PLAN_HLT_LIST2.Columns.Add("remarks")
                    Dim strRow() As String = Split(output.PLAN_HLT2.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Str.Split("|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.PLAN_HLT_LIST2.NewRow
                                    dr("seq") = strField(0)
                                    dr("benefit") = strField(1)
                                    dr("money_amt") = strField(2)
                                    dr("remarks") = strField(3)
                                    output.PLAN_HLT_LIST2.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service (GetDetailMember)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function

    Public Function GetUserProfile(ByVal Inp As InputGetUserProfilePara) As OutputGetUserProfilePara
        Dim Oup As New OutputGetUserProfilePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetUserProfile(Inp.USER_ID, Inp.USER_PASSWD, Oup.USER_TYPE, Oup.USER_NAME_T, Oup.USER_NAME_E, Oup.BROKER_CODE, Oup.AC_CODE, Oup.COMPANY_NAME, Oup.PASSWD_DATE, Oup.USER_S_DATE, Oup.USER_E_DATE, Oup.USER_LEVEL, Oup.USER_EMAIL, Oup.USER_TEL, Oup.MARKET_EMAIL, Oup.MARKET_CC_EMAIL, Oup.CLAIM_EMAIL, Oup.CLAIM_CC_EMAIL, Oup.DISC_REASON, Oup.IS_FIRST_LOGIN, Oup.LOGIN_FAIL_COUNT, Oup.INPUT_PERSON, Oup.MNT_DTTM, Oup.ISFOUND)
            If Oup.ISFOUND = "N" Then
                _err = "Web Service Error : ชื่อเข้าระบบหรือรหัสผ่านไม่ถูกต้อง"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return Oup
    End Function

    Public Function GetContractName(ByVal Inp As InputGetContractNamePara) As OutputGetContractNamePara
        Dim output As New OutputGetContractNamePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetContactName(Inp.GPO_USER_ID, Inp.LANGUAGE, output.GPO_NAME, output.GPO_EMAIL, output.GPO_TEL, output.GPO_CC_EMAIL, output.ISFOUND)
            If output.ISFOUND = "N" Then
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function

    Public Function ChangeUserProfile(ByVal Inp As InputChangeUserProfilePara) As Boolean
        Dim ret As Boolean = False
        Dim output As New OutputChangeUserProfilePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.ChangeUserProfile(Inp.USER_ID, Inp.USER_PASSWORD, Inp.USER_EMAIL, Inp.USER_TEL, output.OUT_ACK)
            If output.OUT_ACK = "Y" Then
                ret = True
            Else
                _err = "Web Service Error : ไม่สามารถแก้ไขข้อมูลได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return (output.OUT_ACK = "Y")
    End Function

    Public Function ChangePassword(ByVal Inp As InputChangePasswordPara) As Boolean
        Dim ret As Boolean = False
        Dim output As New OutputChangePasswordPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.ChangePassword(Inp.USER_ID, Inp.USER_PASSWORD, Inp.PASS_DATE, Inp.INPUT_PERSON, Inp.MNT_DTTM, output.OUT_ACK)
            If output.OUT_ACK = "Y" Then
                ret = True
            Else
                _err = "Web Service Error : ไม่สามารถเปลี่ยนรหัสผ่านได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return (output.OUT_ACK = "Y")
    End Function

    Public Function GetUserJoinCase(ByVal Inp As InputGetUserJoinCasePara) As OutputGetUserJoinCasePara
        Dim output As New OutputGetUserJoinCasePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '### Call WS
            ws.GetUserJoinCase(Inp.USER_ID, output.OUT_CASE, output.OUT_CASE2, output.OUT_CASE3, output.OUT_CASE4, output.OUT_CASE5, output.OUT_CASE6, output.OUT_CASE7, output.OUT_CASE8, output.OUT_CASE9, output.OUT_CASE10, output.MSG_DATE_OVER, output.ISFOUND_CASE)
            If output.ISFOUND_CASE = "Y" Then
                If output.MSG_DATE_OVER = "" Then
                    If output.OUT_CASE.Trim <> "" Then
                        output.OUT_CASE_LIST = New DataTable
                        output.OUT_CASE_LIST.Columns.Add("grp_code")
                        output.OUT_CASE_LIST.Columns.Add("pol_no")
                        output.OUT_CASE_LIST.Columns.Add("account_code")
                        output.OUT_CASE_LIST.Columns.Add("account_name")
                        output.OUT_CASE_LIST.Columns.Add("effect_date")
                        output.OUT_CASE_LIST.Columns.Add("expire_date")
                        output.OUT_CASE_LIST.Columns.Add("pol_year")
                        output.OUT_CASE_LIST.Columns.Add("mtl_user_id")
                        output.OUT_CASE_LIST.Columns.Add("language")
                        output.OUT_CASE_LIST.Columns.Add("CommandArgument")

                        CreateUserJoinCase(output.OUT_CASE, output.OUT_CASE_LIST)

                        If output.OUT_CASE2.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE2, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE3.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE3, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE4.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE4, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE5.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE5, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE6.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE6, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE7.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE7, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE8.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE8, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE9.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE9, output.OUT_CASE_LIST)
                        End If
                        If output.OUT_CASE10.Trim <> "" Then
                            CreateUserJoinCase(output.OUT_CASE10, output.OUT_CASE_LIST)
                        End If
                    End If
                Else
                    _err = output.MSG_DATE_OVER
                End If
                'Else
                '    _err = "การเชื่อมต่อขัดข้อง \n\r (Connect failure)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ \n\r (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Private Sub CreateUserJoinCase(ByVal OutCase As String, ByVal dt As DataTable)
        Dim strRow() As String = Split(OutCase.Trim(), "##")
        If strRow.Length > 0 Then
            For Each Str As String In strRow
                If Str.Trim <> "" Then
                    Dim strField() As String = Str.Split("|")
                    If strField.Length > 0 Then
                        Dim dr As DataRow = dt.NewRow
                        dr("grp_code") = strField(0)
                        dr("pol_no") = strField(1)
                        dr("account_code") = strField(2)
                        dr("account_name") = strField(3)
                        dr("effect_date") = strField(4)
                        dr("expire_date") = strField(5)
                        dr("pol_year") = strField(6)
                        dr("mtl_user_id") = strField(7)
                        dr("language") = strField(8)
                        dr("CommandArgument") = strField(0) & "##" & strField(2) & "##" & strField(6) & "##" & strField(8)
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
        End If
    End Sub

    Public Function InsertUserProfile(ByVal para As UsersPara) As OutputInsertUserProfilePara
        Dim output As New OutputInsertUserProfilePara

        'ข้อมูลใน WS เก็บ Format ไม่เหมือนกับใน ฐานข้อมูล ดังนั้นจึงต้องมีการแปลงข้อมูลก่อน
        Dim inp As New InputInsertUserProfilePara
        inp.USER_ID = para.USER_ID
        inp.USER_PASSWD = para.USER_PASSWD
        inp.USER_TYPE = para.USER_TYPE
        inp.USER_NAME_T = para.USER_NAME_T
        inp.USER_NAME_E = para.USER_NAME_E
        inp.BROKER_CODE = para.BROKER_CODE
        inp.AC_CODE = para.AC_CODE
        inp.COMPANY_NAME = para.COMPANY_NAME
        inp.PASSWD_DATE = para.PASSWD_DATE.ToString("MM/dd") & "/" & para.PASSWD_DATE.Year
        inp.USER_S_DATE = para.USER_S_DATE.ToString("MM/dd") & "/" & para.USER_S_DATE.Year
        inp.USER_E_DATE = para.USER_E_DATE.Value.ToString("MM/dd") & "/" & para.USER_E_DATE.Value.Year
        inp.USER_LEVEL = para.USER_LEVEL.ToString()
        inp.USER_EMAIL = para.USER_EMAIL
        inp.USER_TEL = para.USER_TEL
        inp.MARKET_EMAIL = para.MARKET_EMAIL
        inp.MARKET_CC_EMAIL = para.MARKET_CC_EMAIL
        inp.CLAIM_EMAIL = para.CLAIM_EMAIL
        inp.CLAIM_CC_EMAIL = para.CLAIM_CC_EMAIL
        inp.DISC_REASON = para.DISC_REASON
        inp.USER_STATUS = "A"
        inp.IS_FIRST_LOGIN = para.IS_FIRST_LOGIN
        inp.LOGIN_FAIL_COUNT = para.LOGIN_FAIL_COUNT
        inp.INPUT_PERSON = para.INPUT_PERSON
        inp.CREATE_DTTM = DateTime.Now.Year & "-" & DateTime.Now.ToString("MM-dd HH:mm:ss")
        inp.MNT_DTTM = DateTime.Now.Year & "-" & DateTime.Now.ToString("MM-dd HH:mm:ss")

        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.InsertUserProfile(inp.USER_ID, inp.USER_PASSWD, inp.USER_TYPE, inp.USER_NAME_T, inp.USER_NAME_E, inp.BROKER_CODE, inp.AC_CODE, inp.COMPANY_NAME, inp.PASSWD_DATE, inp.USER_S_DATE, inp.USER_E_DATE, inp.USER_LEVEL, inp.USER_EMAIL, inp.USER_TEL, inp.MARKET_EMAIL, inp.MARKET_CC_EMAIL, inp.CLAIM_EMAIL, inp.CLAIM_CC_EMAIL, inp.DISC_REASON, inp.USER_STATUS, inp.IS_FIRST_LOGIN, inp.LOGIN_FAIL_COUNT, inp.INPUT_PERSON, inp.CREATE_DTTM, inp.MNT_DTTM, output.ACK)
            If output.ACK = "Y" Then
                _user_id = para.USER_ID
            Else
                _err = "Web Service Error : ไม่สามารถเพิ่มข้อมูลผู้ใช้ระบบได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function UpdateUserProfile(ByVal para As UsersPara) As OutputUpdateUserProfilePara
        Dim output As New OutputUpdateUserProfilePara

        'ข้อมูลใน WS เก็บ Format ไม่เหมือนกับใน ฐานข้อมูล ดังนั้นจึงต้องมีการแปลงข้อมูลก่อน
        Dim inp As New InputUpdateUserProfilePara
        inp.USER_ID = para.USER_ID
        inp.USER_TYPE = para.USER_TYPE
        inp.USER_NAME_T = Para.USER_NAME_T
        inp.USER_NAME_E = Para.USER_NAME_E
        inp.BROKER_CODE = Para.BROKER_CODE
        inp.AC_CODE = Para.AC_CODE
        inp.COMPANY_NAME = Para.COMPANY_NAME
        inp.PASSWD_DATE = para.PASSWD_DATE.ToString("MM/dd") & "/" & para.PASSWD_DATE.Year
        inp.USER_S_DATE = para.USER_S_DATE.ToString("MM/dd") & "/" & para.USER_S_DATE.Year
        inp.USER_E_DATE = para.USER_E_DATE.Value.ToString("MM/dd") & "/" & para.USER_E_DATE.Value.Year
        inp.USER_LEVEL = Para.USER_LEVEL.ToString()
        inp.USER_EMAIL = Para.USER_EMAIL
        inp.USER_TEL = Para.USER_TEL
        inp.MARKET_EMAIL = Para.MARKET_EMAIL
        inp.MARKET_CC_EMAIL = Para.MARKET_CC_EMAIL
        inp.CLAIM_EMAIL = Para.CLAIM_EMAIL
        inp.CLAIM_CC_EMAIL = Para.CLAIM_CC_EMAIL
        inp.DISC_REASON = para.DISC_REASON
        inp.USER_STATUS = "A"

        inp.INPUT_PERSON = para.INPUT_PERSON
        inp.MNT_DTTM = DateTime.Now.Year & "-" & DateTime.Now.ToString("MM-dd HH:mm:ss")

        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.UpdateUserProfile(inp.USER_ID, inp.USER_TYPE, inp.USER_NAME_T, inp.USER_NAME_E, inp.BROKER_CODE, inp.AC_CODE, inp.COMPANY_NAME, inp.PASSWD_DATE, inp.USER_S_DATE, inp.USER_E_DATE, inp.USER_LEVEL, inp.USER_EMAIL, inp.USER_TEL, inp.MARKET_EMAIL, inp.MARKET_CC_EMAIL, inp.CLAIM_EMAIL, inp.CLAIM_CC_EMAIL, inp.DISC_REASON, inp.USER_STATUS, inp.INPUT_PERSON, inp.MNT_DTTM, output.ACK)
            If output.ACK = "Y" Then
                _user_id = Para.USER_ID
            Else
                output.ACK = "N"
                '_err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่\n\r(Connection failed; Please try again or contact our staff.)"
            End If
        Catch ex As TimeoutException
            output.ACK = "N"
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            output.ACK = "N"
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            output.ACK = "N"
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่\n\r(Connection failed; Please try again or contact our staff.)"
        End Try

        Return output

    End Function

    Public Function DeleteUserProfile(ByVal inp As InputDeleteUserProfilePara) As Boolean
        Dim output As New OutputDeleteUserProfilePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DeleteUserProfile(inp.USER_ID, output.ACK)
            If output.ACK = "N" Then
                _err = "Web Service Error : ไม่สามารถลบข้อมูลผู้ใช้ระบบได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try

        Return (output.ACK = "Y")
    End Function


    Public Function InsertUserProfileDetail(ByVal para As UsersResponseCompanyPara) As Boolean
        Dim output As New OutputInsertUserProfileDetailPara
        Try
            Dim inp As New InputInsertProfileDetailPara
            inp.USER_ID = para.USER_ID
            inp.GRP_CODE = para.GRP_CODE
            inp.AC_CODE = para.AC_CODE
            inp.POL_YEAR = para.POL_YEAR
            inp.POL_NO = para.POL_NO
            inp.USER_GPO_ID = para.USER_GPO_ID
            inp.LANGUAGE = para.LANGUAGE
            inp.INPUT_PERSON = para.INPUT_PERSON
            inp.CREATE_DTTM = para.CREATE_DTTM.Year & "-" & para.CREATE_DTTM.ToString("MM-dd HH:mm:ss")
            inp.MNT_DTTM = para.MNT_DTTM.Value.Year & "-" & para.MNT_DTTM.Value.ToString("MM-dd HH:mm:ss")

            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.InsertUserProfileDetail(inp.USER_ID, inp.GRP_CODE, inp.AC_CODE, inp.POL_YEAR, inp.POL_NO, inp.USER_GPO_ID, inp.LANGUAGE, inp.INPUT_PERSON, inp.CREATE_DTTM, inp.MNT_DTTM, output.ACK)
            If output.ACK = "N" Then
                _err = "Web Service Error : ไม่สามารถเพิ่มชื่อบริษัทที่รับผิดชอบได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return (output.ACK = "Y")
    End Function

    Public Function DeleteUserProfileDetail(ByVal inp As InputDeleteUserProfileDetailPara) As Boolean
        Dim output As New OutputDeleteUserProfileDetailPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DeleteUserProfileDetail(inp.USER_ID, inp.GROUP_CODE, inp.AC_CODE, output.ACK)
            If output.ACK = "N" Then
                _err = "Web Service Error : ไม่สามารถลบข้อมูลบริษัทที่รับผิดชอบได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ \n\r (Connection failed; Please try again or contact our staff.)"
        End Try
        Return (output.ACK = "Y")
    End Function

    Public Function GetBrokerName(ByVal inp As InputGetBrokerNamePara) As OutputGetBrokerNamePara
        Dim output As New OutputGetBrokerNamePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetBrokerName(inp.BROKER_CODE, inp.LANGUAGE, output.BROKER_NAME, output.ISFOUND)
            If output.ISFOUND = "N" Then
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetBrokerNameList(ByVal inp As InputGetBrokerNameListPara) As OutputGetBrokerNameListPara
        Dim output As New OutputGetBrokerNameListPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetBrokerNameList(inp.BROKER_CODE, inp.BROKER_NAME, inp.LANGUAGE, output.BROKER_SEARCH, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.BROKER_SEARCH.Trim <> "" Then
                    output.BROKER_SEARCH_LIST = New DataTable
                    output.BROKER_SEARCH_LIST.Columns.Add("broker_code")
                    output.BROKER_SEARCH_LIST.Columns.Add("broker_name")
                    Dim strRow() As String = Split(output.BROKER_SEARCH.Trim(), "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            Dim strField() As String = Str.Split("|")
                            If strField.Length > 0 Then
                                Dim dr As DataRow = output.BROKER_SEARCH_LIST.NewRow
                                dr("broker_code") = strField(0)
                                dr("broker_name") = strField(1)
                                output.BROKER_SEARCH_LIST.Rows.Add(dr)
                            End If
                        Next
                    End If
                Else
                    _err = "ไม่พบข้อมูลจาก Web Service"
                End If
            Else
                _err = "ไม่พบข้อมูล Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetAccountName(ByVal inp As InputGetAccountNamePara) As OutputGetAccountNamePara
        Dim output As New OutputGetAccountNamePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetAccountName(inp.AC_CODE, inp.LANGUAGE, output.AC_NAME, output.ISFOUND)
            If output.ISFOUND = "N" Then
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetAccountNameList(ByVal inp As InputGetAccountNameListPara) As OutputGetAccountNameListPara
        Dim output As New OutputGetAccountNameListPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetAccountNameList(inp.AC_CODE, inp.AC_NAME, inp.LANGUAGE, output.AC_SEARCH, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.AC_SEARCH.Trim <> "" Then
                    output.AC_SEARCH_LIST = New DataTable
                    output.AC_SEARCH_LIST.Columns.Add("ac_code")
                    output.AC_SEARCH_LIST.Columns.Add("ac_name")

                    Dim strRow() As String = Split(output.AC_SEARCH, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.AC_SEARCH_LIST.NewRow
                                    dr("ac_code") = strField(0)
                                    dr("ac_name") = strField(1)
                                    output.AC_SEARCH_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                Else
                    _err = "ไม่พบข้อมูลจาก Web Service"
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetAccountUserProfile(ByVal inp As InputGetAccountUserPofilePara) As OutputGetAccountUserPofilePara
        Dim output As New OutputGetAccountUserPofilePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.GetAccountUserProfile(inp.AC_CODE, output.GRP_CODE, output.AC_NAME, output.POL_NO, output.POL_YEAR, output.USER_GPO_ID, output.LANGUAGE, output.ISFOUND)
            If output.ISFOUND = "N" Then
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try

        Return output
    End Function

    Public Function GetSectionNameList(ByVal inp As InputGetSectionNameListPara) As OutputGetSectionNameListPara
        Dim output As New OutputGetSectionNameListPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            '####Call WS
            ws.GetSectionNameList(inp.GRP_CODE, inp.AC_CODE, inp.SECT_CODE, inp.SECT_NAME, inp.LANGUAGE, output.SEC_SEARCH, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.SEC_SEARCH.Trim <> "" Then
                    output.SEC_SEARCH_LIST = New DataTable
                    output.SEC_SEARCH_LIST.Columns.Add("sect_code")
                    output.SEC_SEARCH_LIST.Columns.Add("sect_name")

                    Dim strRow() As String = Split(output.SEC_SEARCH.Trim, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.SEC_SEARCH_LIST.NewRow
                                    dr("sect_code") = strField(0)
                                    dr("sect_name") = strField(1)
                                    output.SEC_SEARCH_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                Else
                    _err = "ไม่พบข้อมูลแผนก \r\n(Data not found)"
                End If
            Else
                _err = "ไม่พบข้อมูลแผนก \r\n(Data not found)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ \n\r (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Public Function HltClmPaidByBenefit(ByVal inp As InputHltClmPaidByBenefitPara) As OutputHltClmPaidByBenefitPara
        Dim output As New OutputHltClmPaidByBenefitPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByBenefit(inp.GRP_CODE, inp.AC_CODE, inp.POL_NO, inp.POL_YEAR, inp.USER_ID, inp.LANGUAGE, output.AS_OF_DATE, output.EFFECT_DATE, output.EXPIRE_DATE, output.POL_NAME, output.AC_NAME, output.HLT_CLM, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.HLT_CLM.Trim <> "" Then
                    output.HLT_CLM_LIST = New DataTable

                    output.HLT_CLM_LIST.Columns.Add("grp_code")
                    output.HLT_CLM_LIST.Columns.Add("pol_desc")
                    output.HLT_CLM_LIST.Columns.Add("pol_year")
                    output.HLT_CLM_LIST.Columns.Add("ac_desc")
                    output.HLT_CLM_LIST.Columns.Add("as_of_date")
                    output.HLT_CLM_LIST.Columns.Add("effect_date")
                    output.HLT_CLM_LIST.Columns.Add("grouprep")

                    output.HLT_CLM_LIST.Columns.Add("benefit")
                    output.HLT_CLM_LIST.Columns.Add("frequency_accident", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_health", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("incurred_amt_accident", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("incurred_amt_health", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_accident", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_health", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_accident", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_health", GetType(Double))

                    Dim strRow() As String = Split(output.HLT_CLM.Trim, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.HLT_CLM_LIST.NewRow
                                    dr("grp_code") = inp.GRP_CODE
                                    dr("pol_desc") = inp.POL_NO & " : " & output.POL_NAME
                                    dr("pol_year") = inp.POL_YEAR
                                    dr("ac_desc") = inp.AC_CODE & " : " & output.AC_NAME
                                    dr("as_of_date") = ConvertDateFromWS(output.AS_OF_DATE).ToString("dd/MM/yyyy")
                                    dr("effect_date") = ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy") & " - " & ConvertDateFromWS(output.EXPIRE_DATE).ToString("dd/MM/yyyy")
                                    dr("grouprep") = inp.POL_NO & inp.AC_CODE & inp.POL_YEAR

                                    dr("benefit") = strField(0)
                                    dr("frequency_accident") = strField(1)
                                    dr("frequency_health") = strField(2)
                                    dr("incurred_amt_accident") = strField(3)
                                    dr("incurred_amt_health") = strField(4)
                                    dr("payment_accident") = strField(5)
                                    dr("payment_health") = strField(6)
                                    dr("not_cover_accident") = strField(7)
                                    dr("not_cover_health") = strField(8)
                                    output.HLT_CLM_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                Else
                    _err = "ไม่พบข้อมูลจาก Web Service"
                End If
            Else
                _err = "ไม่พบข้อมูล (No Data Found)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Public Function HltClmPaidByBenefitGraph(ByVal inp As InputHltClmPaidByBenefitGraphPara) As OutputHltClmPaidByBenefitGraphPara
        Dim output As New OutputHltClmPaidByBenefitGraphPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByBenefit_Graph(inp.GRP_CODE, inp.AC_CODE, inp.POL_YEAR, output.CLM_BY_TREAT_GRP, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.CLM_BY_TREAT_GRP.Trim <> "" Then
                    output.CLM_BY_TREAT_GRP_LIST = New DataTable
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("treatment_group")
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("net_approve_amt", GetType(Double))
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("grouprep")

                    Dim strRow() As String = Split(output.CLM_BY_TREAT_GRP.Trim, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.CLM_BY_TREAT_GRP_LIST.NewRow
                                    dr("treatment_group") = strField(0)
                                    dr("net_approve_amt") = strField(1)
                                    dr("grouprep") = inp.POL_NO & inp.AC_CODE & inp.POL_YEAR
                                    output.CLM_BY_TREAT_GRP_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                Else
                    _err = "ไม่พบข้อมูลจาก Web Service"
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่  (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function
    Public Function DelHltClmPaidByBenefit(ByVal inp As InputDelHltClmPaidByBenefitPara) As OutputDelHltClmPaidByBenefitPara
        Dim output As New OutputDelHltClmPaidByBenefitPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DelHltClmPaidByBenefit(inp.USER_ID, output.ACK)
            If output.ACK = "N" Then
                _err = "ไม่สามารถลบข้อมูลผ่าน Web Service ได้ (DelHltClmPaidByBenefit)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่  (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    
    Public Function HltClmPaidByAcc_Emp(ByVal inp As InputHltClmPaidByAcc_EmpPara) As OutputHltClmPaidByAc_EmpPara
        Dim output As New OutputHltClmPaidByAc_EmpPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByAcc_Emp(inp.GRP_CODE, inp.AC_CODE, inp.POL_NO, inp.POL_YEAR, inp.USER_ID, inp.LANGUAGE, inp.SECTION_CODE, inp.SORT_TYPE, inp.TOP_LEVEL, output.AS_OF_DATE, output.EFFECT_DATE, output.EXPIRE_DATE, output.POL_NAME, output.AC_NAME, output.HLT_CLM, output.HLT_CLM2, output.HLT_CLM3, output.OUT_TYPE, output.MSG, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.HLT_CLM.Trim <> "" Then
                    output.HLT_CLM_LIST = New DataTable
                    output.HLT_CLM_LIST.Columns.Add("group_code")
                    output.HLT_CLM_LIST.Columns.Add("pol_no")
                    output.HLT_CLM_LIST.Columns.Add("pol_year")
                    output.HLT_CLM_LIST.Columns.Add("pol_desc")
                    output.HLT_CLM_LIST.Columns.Add("as_of_date")
                    output.HLT_CLM_LIST.Columns.Add("effect_date")
                    output.HLT_CLM_LIST.Columns.Add("ac_code")
                    output.HLT_CLM_LIST.Columns.Add("ac_name")
                    output.HLT_CLM_LIST.Columns.Add("ac_desc")
                    output.HLT_CLM_LIST.Columns.Add("top_claim")
                    output.HLT_CLM_LIST.Columns.Add("out_type")
                    output.HLT_CLM_LIST.Columns.Add("section_desc")

                    output.HLT_CLM_LIST.Columns.Add("emp_name")
                    output.HLT_CLM_LIST.Columns.Add("emp_type")
                    output.HLT_CLM_LIST.Columns.Add("claim_time_d", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_paid_d", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_time_i", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_paid_i", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_time_o", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_paid_o", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_time_m", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("claim_paid_m", GetType(Double))

                    CreateHltClmPaidByAccEmp(output.HLT_CLM, output, inp, output.HLT_CLM_LIST)

                    If output.HLT_CLM2.Trim <> "" Then
                        CreateHltClmPaidByAccEmp(output.HLT_CLM2, output, inp, output.HLT_CLM_LIST)
                    End If
                    If output.HLT_CLM3.Trim <> "" Then
                        CreateHltClmPaidByAccEmp(output.HLT_CLM3, output, inp, output.HLT_CLM_LIST)
                    End If
                Else
                    _err = "ไม่พบข้อมูล (Data Not Found!)"
                    output.MSG = "ไม่พบข้อมูล (Data Not Found!)"
                End If
            Else
                _err = output.MSG
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            output.MSG = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Private Sub CreateHltClmPaidByAccEmp(ByVal HltClm As String, ByVal output As OutputHltClmPaidByAc_EmpPara, ByVal inp As InputHltClmPaidByAcc_EmpPara, ByVal dt As DataTable)
        Dim strRow() As String = Split(HltClm.Trim, "##")
        If strRow.Length > 0 Then
            For Each Str As String In strRow
                If Str.Trim <> "" Then
                    Dim strField() As String = Split(Str, "|")
                    If strField.Length > 0 Then
                        Dim dr As DataRow = dt.NewRow

                        dr("group_code") = inp.GRP_CODE
                        dr("pol_no") = inp.POL_NO
                        dr("pol_year") = inp.POL_YEAR
                        dr("pol_desc") = inp.POL_NO & " : " & output.POL_NAME
                        dr("as_of_date") = ConvertDateFromWS(output.AS_OF_DATE).ToString("dd/MM/yyyy")
                        dr("effect_date") = ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy") & " - " & ConvertDateFromWS(output.EXPIRE_DATE).ToString("dd/MM/yyyy")
                        dr("ac_code") = inp.AC_CODE
                        dr("ac_name") = output.AC_NAME
                        dr("ac_desc") = inp.AC_CODE & " : " & output.AC_NAME
                        dr("top_claim") = inp.TOP_LEVEL
                        dr("out_type") = output.OUT_TYPE.Trim
                        If inp.SECTION_CODE.Trim = "" And inp.SECTION_NAME.Trim = "" Then
                            dr("section_desc") = ""
                        Else
                            dr("section_desc") = inp.SECTION_CODE & " : " & inp.SECTION_NAME
                        End If

                        dr("emp_name") = strField(0)
                        dr("emp_type") = strField(1)
                        If dr("out_type") = "" Then
                            dr("claim_time_d") = 0
                            dr("claim_paid_d") = 0
                            dr("claim_time_i") = strField(2)
                            dr("claim_paid_i") = strField(3)
                            dr("claim_time_o") = strField(4)
                            dr("claim_paid_o") = strField(5)
                            dr("claim_time_m") = 0
                            dr("claim_paid_m") = 0
                        ElseIf dr("out_type") = "1" Then
                            dr("claim_time_d") = strField(2)
                            dr("claim_paid_d") = strField(3)
                            dr("claim_time_i") = strField(4)
                            dr("claim_paid_i") = strField(5)
                            dr("claim_time_o") = strField(6)
                            dr("claim_paid_o") = strField(7)
                            dr("claim_time_m") = 0
                            dr("claim_paid_m") = 0
                        ElseIf dr("out_type") = "2" Then
                            dr("claim_time_d") = strField(2)
                            dr("claim_paid_d") = strField(3)
                            dr("claim_time_i") = strField(4)
                            dr("claim_paid_i") = strField(5)
                            dr("claim_time_o") = strField(6)
                            dr("claim_paid_o") = strField(7)
                            dr("claim_time_m") = strField(8)
                            dr("claim_paid_m") = strField(9)
                        ElseIf dr("out_type") = "3" Then
                            dr("claim_time_d") = 0
                            dr("claim_paid_d") = 0
                            dr("claim_time_i") = strField(2)
                            dr("claim_paid_i") = strField(3)
                            dr("claim_time_o") = strField(4)
                            dr("claim_paid_o") = strField(5)
                            dr("claim_time_m") = strField(6)
                            dr("claim_paid_m") = strField(7)
                        End If
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
        End If
    End Sub

    Public Function DelHltClmPaidByAcc_Emp(ByVal UserID As String) As Boolean
        Dim ret As String = ""
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DelHltClmPaidByAcc_Emp(UserID, ret)
            If ret = "N" Then
                _err = "ไม่สามารถลบข้อมูลผ่าน Web Service ได้ (DelHltClmPaidByAcc_Emp)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try

        Return (ret = "Y")
    End Function

    Public Function HltClmPaidByDiagnose(ByVal inp As InputHltClmPaidByDiagnosePara) As OutputHltClmPaidByDiagnosePara
        Dim output As New OutputHltClmPaidByDiagnosePara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByDiagnose(inp.GRP_CODE, inp.AC_CODE, inp.POL_NO, inp.POL_YEAR, inp.USER_ID, inp.SORT_TYPE, inp.TOP_LEVEL, inp.LANGUAGE, output.AS_OF_DATE, output.POL_NAME, output.AC_NAME, output.EFFECT_DATE, output.EXPIRE_DATE, output.HLT_CLM1, output.HLT_CLM2, output.HLT_CLM3, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.HLT_CLM1.Trim <> "" Then
                    output.HLT_CLM_LIST = New DataTable
                    output.HLT_CLM_LIST.Columns.Add("grp_code")
                    output.HLT_CLM_LIST.Columns.Add("pol_no")
                    output.HLT_CLM_LIST.Columns.Add("pol_name")
                    output.HLT_CLM_LIST.Columns.Add("pol_desc")
                    output.HLT_CLM_LIST.Columns.Add("ac_code")
                    output.HLT_CLM_LIST.Columns.Add("ac_name")
                    output.HLT_CLM_LIST.Columns.Add("ac_desc")
                    output.HLT_CLM_LIST.Columns.Add("pol_year")
                    output.HLT_CLM_LIST.Columns.Add("effect_date")
                    output.HLT_CLM_LIST.Columns.Add("as_of_date")
                    output.HLT_CLM_LIST.Columns.Add("top_claim")

                    output.HLT_CLM_LIST.Columns.Add("type")
                    output.HLT_CLM_LIST.Columns.Add("seq")
                    output.HLT_CLM_LIST.Columns.Add("diagnosis")
                    output.HLT_CLM_LIST.Columns.Add("diag_code")
                    output.HLT_CLM_LIST.Columns.Add("frequency_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_maternity", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_maternity", GetType(Double))

                    CreateHltClmByDiagnose(output.HLT_CLM1, output.HLT_CLM_LIST, inp, output)

                    If output.HLT_CLM2.Trim <> "" Then
                        CreateHltClmByDiagnose(output.HLT_CLM2, output.HLT_CLM_LIST, inp, output)
                    End If
                    If output.HLT_CLM3.Trim <> "" Then
                        CreateHltClmByDiagnose(output.HLT_CLM3, output.HLT_CLM_LIST, inp, output)
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function
    Private Sub CreateHltClmByDiagnose(ByVal HltClm As String, ByVal dt As DataTable, ByVal inp As InputHltClmPaidByDiagnosePara, ByVal output As OutputHltClmPaidByDiagnosePara)
        Dim strRow() As String = Split(HltClm.Trim, "##")
        If strRow.Length > 0 Then
            For Each Str As String In strRow
                If Str.Trim <> "" Then
                    Dim strField() As String = Split(Str, "|")
                    If strField.Length > 0 Then
                        Dim dr As DataRow = dt.NewRow
                        dr("grp_code") = inp.GRP_CODE
                        dr("pol_no") = inp.POL_NO
                        dr("pol_name") = output.POL_NAME
                        dr("pol_desc") = inp.POL_NO & " : " & output.POL_NAME
                        dr("ac_code") = inp.AC_CODE
                        dr("ac_name") = output.AC_NAME
                        dr("ac_desc") = inp.AC_CODE & " : " & output.AC_NAME
                        dr("pol_year") = inp.POL_YEAR
                        dr("effect_date") = ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy") & " - " & ConvertDateFromWS(output.EXPIRE_DATE).ToString("dd/MM/yyyy")
                        dr("as_of_date") = ConvertDateFromWS(output.AS_OF_DATE).ToString("dd/MM/yyyy")

                        dr("top_claim") = inp.TOP_LEVEL

                        dr("type") = strField(0)
                        dr("seq") = strField(1)
                        dr("diagnosis") = strField(2)
                        dr("diag_code") = strField(3)
                        If dr("type") = "" Then
                            dr("frequency_dental") = 0
                            dr("payment_dental") = 0
                            dr("frequency_ipd") = strField(4)
                            dr("payment_ipd") = strField(5)
                            dr("frequency_opd") = strField(6)
                            dr("payment_opd") = strField(7)
                            dr("frequency_maternity") = 0
                            dr("payment_maternity") = 0
                        ElseIf dr("type") = "1" Then
                            dr("frequency_dental") = strField(4)
                            dr("payment_dental") = strField(5)
                            dr("frequency_ipd") = strField(6)
                            dr("payment_ipd") = strField(7)
                            dr("frequency_opd") = strField(8)
                            dr("payment_opd") = strField(9)
                            dr("frequency_maternity") = 0
                            dr("payment_maternity") = 0
                        ElseIf dr("type") = "2" Then
                            dr("frequency_dental") = strField(4)
                            dr("payment_dental") = strField(5)
                            dr("frequency_ipd") = strField(6)
                            dr("payment_ipd") = strField(7)
                            dr("frequency_opd") = strField(8)
                            dr("payment_opd") = strField(9)
                            dr("frequency_maternity") = strField(10)
                            dr("payment_maternity") = strField(11)
                        ElseIf dr("type") = "3" Then
                            dr("frequency_dental") = strField(4)
                            dr("payment_dental") = strField(5)
                            dr("frequency_ipd") = strField(6)
                            dr("payment_ipd") = strField(7)
                            dr("frequency_opd") = strField(8)
                            dr("payment_opd") = strField(9)
                            dr("frequency_maternity") = strField(10)
                            dr("payment_maternity") = strField(11)
                        End If
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
        End If
    End Sub


    Public Function DelHltClmPaidByDiagnose(ByVal UserID As String) As Boolean
        Dim ret As String = ""
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DelHltClmPaidByDiagnose(UserID, ret)
            If ret = "N" Then
                _err = "ไม่สามารถลบข้อมูลผ่าน Web Service ได้ (DelHltClmPaidByDiagnose)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return (ret = "Y")
    End Function

    Public Function HltClmPaidByHospital(ByVal inp As InputHltClmPaidByHospitalPara) As OutputHltClmPaidByHospitalPara
        Dim output As New OutputHltClmPaidByHospitalPara
        Try
            'Call WS
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByHospital(inp.GRP_CODE, inp.AC_CODE, inp.POL_NO, inp.POL_YEAR, inp.USER_ID, inp.SORT_TYPE, inp.TOP_LEVEL, inp.LANGUAGE, output.AS_OF_DATE, output.POL_NAME, output.AC_NAME, output.EFFECT_DATE, output.EXPIRE_DATE, output.HLT_CLM1, output.HLT_CLM2, output.HLT_CLM3, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.HLT_CLM1.Trim <> "" Then
                    output.HLT_CLM_LIST = New DataTable
                    output.HLT_CLM_LIST.Columns.Add("grp_code")
                    output.HLT_CLM_LIST.Columns.Add("pol_no")
                    output.HLT_CLM_LIST.Columns.Add("pol_name")
                    output.HLT_CLM_LIST.Columns.Add("pol_desc")
                    output.HLT_CLM_LIST.Columns.Add("ac_code")
                    output.HLT_CLM_LIST.Columns.Add("ac_name")
                    output.HLT_CLM_LIST.Columns.Add("ac_desc")
                    output.HLT_CLM_LIST.Columns.Add("pol_year")
                    output.HLT_CLM_LIST.Columns.Add("effect_date")
                    output.HLT_CLM_LIST.Columns.Add("as_of_date")
                    output.HLT_CLM_LIST.Columns.Add("top_claim")

                    output.HLT_CLM_LIST.Columns.Add("type")
                    output.HLT_CLM_LIST.Columns.Add("seq")
                    output.HLT_CLM_LIST.Columns.Add("hospital")
                    output.HLT_CLM_LIST.Columns.Add("frequency_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("frequency_maternity", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_maternity", GetType(Double))

                    CreateHltClmPaidByHospitalList(output.HLT_CLM1, output.HLT_CLM_LIST, inp, output)

                    If output.HLT_CLM2.Trim <> "" Then
                        CreateHltClmPaidByHospitalList(output.HLT_CLM2, output.HLT_CLM_LIST, inp, output)
                    End If
                    If output.HLT_CLM3.Trim <> "" Then
                        CreateHltClmPaidByHospitalList(output.HLT_CLM3, output.HLT_CLM_LIST, inp, output)
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูล (No data found.)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function

    Private Sub CreateHltClmPaidByHospitalList(ByVal HltClm As String, ByVal dt As DataTable, ByVal inp As InputHltClmPaidByHospitalPara, ByVal output As OutputHltClmPaidByHospitalPara)
        Dim strRow() As String = Split(HltClm.Trim, "##")
        If strRow.Length > 0 Then
            For Each Str As String In strRow
                If Str.Trim <> "" Then
                    Dim strField() As String = Split(Str, "|")
                    If strField.Length > 0 Then
                        Dim dr As DataRow = dt.NewRow
                        dr("grp_code") = inp.GRP_CODE
                        dr("pol_no") = inp.POL_NO
                        dr("pol_name") = output.POL_NAME
                        dr("pol_desc") = inp.POL_NO & " : " & output.POL_NAME
                        dr("ac_code") = inp.AC_CODE
                        dr("ac_name") = output.AC_NAME
                        dr("ac_desc") = inp.AC_CODE & " : " & output.AC_NAME
                        dr("pol_year") = inp.POL_YEAR
                        dr("effect_date") = ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy") & " - " & ConvertDateFromWS(output.EXPIRE_DATE).ToString("dd/MM/yyyy")
                        dr("as_of_date") = ConvertDateFromWS(output.AS_OF_DATE).ToString("dd/MM/yyyy")
                        dr("top_claim") = inp.TOP_LEVEL

                        dr("type") = strField(0)
                        dr("seq") = strField(1)
                        dr("hospital") = strField(2)
                        If dr("type") = "" Then
                            dr("frequency_dental") = 0
                            dr("payment_dental") = 0
                            dr("frequency_ipd") = strField(3)
                            dr("payment_ipd") = strField(4)
                            dr("frequency_opd") = strField(5)
                            dr("payment_opd") = strField(6)
                            dr("frequency_maternity") = 0
                            dr("payment_maternity") = 0
                        ElseIf dr("type") = "1" Then
                            dr("frequency_dental") = strField(3)
                            dr("payment_dental") = strField(4)
                            dr("frequency_ipd") = strField(5)
                            dr("payment_ipd") = strField(6)
                            dr("frequency_opd") = strField(7)
                            dr("payment_opd") = strField(8)
                            dr("frequency_maternity") = 0
                            dr("payment_maternity") = 0
                        ElseIf dr("type") = "2" Then
                            dr("frequency_dental") = strField(3)
                            dr("payment_dental") = strField(4)
                            dr("frequency_ipd") = strField(5)
                            dr("payment_ipd") = strField(6)
                            dr("frequency_opd") = strField(7)
                            dr("payment_opd") = strField(8)
                            dr("frequency_maternity") = strField(9)
                            dr("payment_maternity") = strField(10)
                        ElseIf dr("type") = "3" Then
                            dr("frequency_dental") = strField(3)
                            dr("payment_dental") = strField(4)
                            dr("frequency_ipd") = strField(5)
                            dr("payment_ipd") = strField(6)
                            dr("frequency_opd") = strField(7)
                            dr("payment_opd") = strField(8)
                            dr("frequency_maternity") = strField(9)
                            dr("payment_maternity") = strField(10)
                        End If
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
        End If
    End Sub

    Public Function DelHltClmPaidByHospital(ByVal UserID As String) As Boolean
        Dim ret As String = ""
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DelHltClmPaidByHospital(UserID, ret)
            If ret = "N" Then
                _err = "ไม่สามารถลบข้อมูลผ่าน Web Service ได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return (ret = "Y")
    End Function
    Public Function HltClmByPlanRelation(ByVal inp As InputHltClmPaidByPlanRelationPara) As OutputHltClmPaidByPlanRelationPara
        Dim output As New OutputHltClmPaidByPlanRelationPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByPlanRelation(inp.GRP_CODE, inp.AC_CODE, inp.POL_NO, inp.POL_YEAR, inp.USER_ID, inp.LANGUAGE, output.AS_OF_DATE, output.POL_NAME, output.AC_NAME, output.EFFECT_DATE, output.EXPIRE_DATE, output.HLT_CLM, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.HLT_CLM.Trim <> "" Then
                    output.HLT_CLM_LIST = New DataTable
                    output.HLT_CLM_LIST.Columns.Add("grp_code")
                    output.HLT_CLM_LIST.Columns.Add("pol_no")
                    output.HLT_CLM_LIST.Columns.Add("pol_name")
                    output.HLT_CLM_LIST.Columns.Add("pol_desc")
                    output.HLT_CLM_LIST.Columns.Add("ac_code")
                    output.HLT_CLM_LIST.Columns.Add("ac_name")
                    output.HLT_CLM_LIST.Columns.Add("ac_desc")
                    output.HLT_CLM_LIST.Columns.Add("pol_year")
                    output.HLT_CLM_LIST.Columns.Add("effect_date")
                    output.HLT_CLM_LIST.Columns.Add("as_of_date")
                    output.HLT_CLM_LIST.Columns.Add("type")

                    output.HLT_CLM_LIST.Columns.Add("plan_code")
                    output.HLT_CLM_LIST.Columns.Add("emp_type")
                    output.HLT_CLM_LIST.Columns.Add("incured_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_dental", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("incured_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_ipd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("incured_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_opd", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("incured_maternity", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("payment_maternity", GetType(Double))
                    output.HLT_CLM_LIST.Columns.Add("not_cover_maternity", GetType(Double))

                    'For Graph Report
                    output.HLT_CLM_LIST.Columns.Add("treament_group")
                    output.HLT_CLM_LIST.Columns.Add("treament_value", GetType(Double))

                    Dim strRow() As String = Split(output.HLT_CLM.Trim, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    Dim dr As DataRow = output.HLT_CLM_LIST.NewRow
                                    dr("grp_code") = inp.GRP_CODE
                                    dr("pol_no") = inp.POL_NO
                                    dr("pol_name") = output.POL_NAME
                                    dr("pol_desc") = inp.POL_NO & " : " & output.POL_NAME
                                    dr("ac_code") = inp.AC_CODE
                                    dr("ac_name") = output.AC_NAME
                                    dr("ac_desc") = inp.AC_CODE & " : " & output.AC_NAME
                                    dr("pol_year") = inp.POL_YEAR
                                    dr("effect_date") = ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy") & " - " & ConvertDateFromWS(output.EXPIRE_DATE).ToString("dd/MM/yyyy")
                                    dr("as_of_date") = ConvertDateFromWS(output.AS_OF_DATE).ToString("dd/MM/yyyy")
                                    dr("type") = strField(0)

                                    dr("plan_code") = strField(1)
                                    dr("emp_type") = strField(2)
                                    If dr("type") = "" Then
                                        dr("incured_dental") = 0
                                        dr("payment_dental") = 0
                                        dr("not_cover_dental") = 0
                                        dr("incured_ipd") = strField(3)
                                        dr("payment_ipd") = strField(4)
                                        dr("not_cover_ipd") = strField(5)
                                        dr("incured_opd") = strField(6)
                                        dr("payment_opd") = strField(7)
                                        dr("not_cover_opd") = strField(8)
                                        dr("incured_maternity") = 0
                                        dr("payment_maternity") = 0
                                        dr("not_cover_maternity") = 0
                                    ElseIf dr("type") = "1" Then
                                        dr("incured_dental") = strField(3)
                                        dr("payment_dental") = strField(4)
                                        dr("not_cover_dental") = strField(5)
                                        dr("incured_ipd") = strField(6)
                                        dr("payment_ipd") = strField(7)
                                        dr("not_cover_ipd") = strField(8)
                                        dr("incured_opd") = strField(9)
                                        dr("payment_opd") = strField(10)
                                        dr("not_cover_opd") = strField(11)
                                        dr("incured_maternity") = 0
                                        dr("payment_maternity") = 0
                                        dr("not_cover_maternity") = 0
                                    ElseIf dr("type") = "2" Then
                                        dr("incured_dental") = strField(3)
                                        dr("payment_dental") = strField(4)
                                        dr("not_cover_dental") = strField(5)
                                        dr("incured_ipd") = strField(6)
                                        dr("payment_ipd") = strField(7)
                                        dr("not_cover_ipd") = strField(8)
                                        dr("incured_opd") = strField(9)
                                        dr("payment_opd") = strField(10)
                                        dr("not_cover_opd") = strField(11)
                                        dr("incured_maternity") = strField(12)
                                        dr("payment_maternity") = strField(13)
                                        dr("not_cover_maternity") = strField(14)
                                    ElseIf dr("type") = "3" Then
                                        dr("incured_dental") = 0
                                        dr("payment_dental") = 0
                                        dr("not_cover_dental") = 0
                                        dr("incured_ipd") = strField(3)
                                        dr("payment_ipd") = strField(4)
                                        dr("not_cover_ipd") = strField(5)
                                        dr("incured_opd") = strField(6)
                                        dr("payment_opd") = strField(7)
                                        dr("not_cover_opd") = strField(8)
                                        dr("incured_maternity") = strField(9)
                                        dr("payment_maternity") = strField(10)
                                        dr("not_cover_maternity") = strField(11)
                                    End If
                                    output.HLT_CLM_LIST.Rows.Add(dr)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูล (No data found)"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            '_err = "Web Service Exception : " & ex.Message
            _err = "การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่  (Connection failed; Please try again or contact our staff.)"
        End Try
        Return output
    End Function
    Public Function HltClmPaidByPlanRelation_Graph(ByVal inp As InputHltClmPaidByPlanRelation_GraphPara) As OutputHltClmPaidByPlanRelation_GraphPara
        Dim output As New OutputHltClmPaidByPlanRelation_GraphPara
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.HltClmPaidByPlanRelation_Graph(inp.GRP_CODE, inp.AC_CODE, inp.POL_YEAR, output.CLM_BY_TREAT_GRP, output.ISFOUND)
            If output.ISFOUND = "Y" Then
                If output.CLM_BY_TREAT_GRP.Trim <> "" Then
                    output.CLM_BY_TREAT_GRP_LIST = New DataTable
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("plan_code")
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("treament_group")
                    output.CLM_BY_TREAT_GRP_LIST.Columns.Add("treament_value", GetType(Double))

                    Dim strRow() As String = Split(output.CLM_BY_TREAT_GRP.Trim, "##")
                    If strRow.Length > 0 Then
                        For Each Str As String In strRow
                            If Str.Trim <> "" Then
                                Dim strField() As String = Split(Str, "|")
                                If strField.Length > 0 Then
                                    For i As Integer = 0 To strField.Length - 1
                                        Dim dr As DataRow = output.CLM_BY_TREAT_GRP_LIST.NewRow
                                        dr("plan_code") = strField(0)
                                        If i = 1 Then 'Maternity
                                            dr("treament_group") = "Dental"
                                            dr("treament_value") = strField(1)
                                        ElseIf i = 2 Then  'IPD
                                            dr("treament_group") = "IPD"
                                            dr("treament_value") = strField(2)
                                        ElseIf i = 3 Then  'OPD
                                            dr("treament_group") = "OPD"
                                            dr("treament_value") = strField(3)
                                        ElseIf i = 4 Then
                                            dr("treament_group") = "Maternity"
                                            dr("treament_value") = strField(4)
                                        End If
                                        output.CLM_BY_TREAT_GRP_LIST.Rows.Add(dr)
                                    Next
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                _err = "ไม่พบข้อมูลจาก Web Service"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return output
    End Function


    Public Function DelHltClmPaidByPlanRelation(ByVal UserID As String) As Boolean
        Dim ret As String = ""
        Try
            Dim ws As New WebGroupWS.MagicWS_WebGroup
            ws.DelHltClmPaidByPlanRelation(UserID, ret)
            If ret = "N" Then
                _err = "ไม่สามารถลบข้อมูลผ่าน Web Service ได้"
            End If
        Catch ex As TimeoutException
            _err = "Web Service Timeout Exception : " & ex.Message
        Catch ex As IndexOutOfRangeException
            _err = "Web Service Index Out of Range Exception : " & ex.Message
        Catch ex As Exception
            _err = "Web Service Exception : " & ex.Message
        End Try
        Return (ret = "Y")
    End Function


    Private Function ConvertDateFromWS(ByVal DateFromWS As String) As Date
        'ข้อมูลที่มาจาก WS จะมาในรูปแบบ MM/DD/YYYY (ปี คศ) แล้วเราจะ Convert ให้เป็น Date สำหรับใช้แสดงในรายงาน
        Dim ret As Date
        If DateFromWS.Trim <> "" Then
            Dim vDay As String = DateFromWS.Substring(3, 2)
            Dim vMonth As String = Left(DateFromWS, 2)
            Dim vYear As String = Right(DateFromWS, 4)

            ret = New Date(vYear, vMonth, vDay)
        Else
            ret = New Date(1, 1, 1)
        End If

        Return ret
    End Function
End Class
