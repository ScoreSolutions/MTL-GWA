Imports LinqWS
Imports Para.CallWS
Imports Para.OutputWS
Imports Para.TABLE
Imports LinqDB.TABLE

Namespace Common
    Public Class WebServiceENG
        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public Function GetAccountNameWS(ByVal acCode As String, ByVal lang As String) As String
            Dim ret As String = ""
            Dim inp As New InputGetAccountNamePara
            inp.AC_CODE = acCode
            inp.LANGUAGE = lang
            Dim ws As New WebGroupLinqWS

            ret = ws.GetAccountName(inp).AC_NAME
            Return ret
        End Function
        Public Function GetSectionNameWS(ByVal inp As InputGetSectionNameListPara) As String
            Dim ret As String = ""
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetSectionNameListPara = ws.GetSectionNameList(inp)
            If output.ISFOUND = "Y" Then
                Dim dt As DataTable = output.SEC_SEARCH_LIST
                If dt IsNot Nothing Then
                    ret = dt.Rows(0)("sect_name")
                End If
            End If
            Return ret
        End Function
        Public Function GetSectionNameList(ByVal inp As InputGetSectionNameListPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetSectionNameListPara = ws.GetSectionNameList(inp)
            Dim dt As New DataTable
            If output.ISFOUND = "Y" Then
                dt = output.SEC_SEARCH_LIST
            Else
                _err = ws.ErrorMessage
            End If
            Return dt
        End Function

        Public Function GetQueryAccount(ByVal para As InputGetQueryAccountPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetQueryAccountPara = ws.GetQueryAccount(para)
            If ws.ErrorMessage <> "" Then
                _err = ws.ErrorMessage
            End If

            If output.ACCOUNT_LIST IsNot Nothing Then
                For i As Integer = 0 To output.ACCOUNT_LIST.Rows.Count - 1
                    output.ACCOUNT_LIST.Rows(i)("ef_date") = ConfigENG.ConvertDateFromWS(output.ACCOUNT_LIST.Rows(i)("ef_date")).ToString("dd/MM/yyyy")
                    output.ACCOUNT_LIST.Rows(i)("ep_date") = ConfigENG.ConvertDateFromWS(output.ACCOUNT_LIST.Rows(i)("ep_date")).ToString("dd/MM/yyyy")
                Next
                output.ACCOUNT_LIST.DefaultView.Sort = "group_code, policy_no"
                output.ACCOUNT_LIST = output.ACCOUNT_LIST.DefaultView.ToTable
            End If

            Return output.ACCOUNT_LIST
        End Function

        Public Function GetAccountDetail(ByVal para As InputGetAccountDetailPara) As OutputGetAccountDetailPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetAccountDetailPara = ws.GetAccountDetail(para)
            If ws.ErrorMessage <> "" Then
                _err = ws.ErrorMessage
            End If

            Return output
        End Function

        Public Function GetAccountUserProfile(ByVal ac_code As String) As OutputGetAccountUserPofilePara
            Dim ws As New WebGroupLinqWS
            Dim para As New InputGetAccountUserPofilePara
            para.AC_CODE = ac_code
            Dim output As OutputGetAccountUserPofilePara = ws.GetAccountUserProfile(para)
            If ws.ErrorMessage <> "" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

        Public Function GetUserProfile(ByVal para As InputGetUserProfilePara) As OutputGetUserProfilePara

            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetUserProfilePara = ws.GetUserProfile(para)
            If output.ISFOUND = "N" Then
                _err = ws.ErrorMessage
            End If

            Return output
        End Function

        Public Function GetUserJoinCase(ByVal para As InputGetUserJoinCasePara) As OutputGetUserJoinCasePara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetUserJoinCasePara = ws.GetUserJoinCase(para)
            If output.ISFOUND_CASE = "Y" Then
                If output.OUT_CASE_LIST IsNot Nothing Then
                    For i As Integer = 0 To output.OUT_CASE_LIST.Rows.Count - 1
                        output.OUT_CASE_LIST.Rows(i)("effect_date") = ConfigENG.ConvertDateFromWS(output.OUT_CASE_LIST.Rows(i)("effect_date")).ToString("dd/MM/yyyy")
                        output.OUT_CASE_LIST.Rows(i)("expire_date") = ConfigENG.ConvertDateFromWS(output.OUT_CASE_LIST.Rows(i)("expire_date")).ToString("dd/MM/yyyy")
                    Next
                    'output.OUT_CASE_LIST.DefaultView.Sort = "grp_code, pol_no"
                    'output.OUT_CASE_LIST = output.OUT_CASE_LIST.DefaultView.ToTable
                End If
            ElseIf output.ISFOUND_CASE = "" Then
                _err = ws.ErrorMessage
            End If

            Return output
        End Function

        Public Function BuiltGroupCode(ByVal para As OutputGetUserJoinCasePara) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("grp_code")

            If para.OUT_CASE_LIST IsNot Nothing Then
                Dim tmpGrpCode As String = ""
                For Each dr_out As DataRow In para.OUT_CASE_LIST.Rows
                    If tmpGrpCode <> dr_out("grp_code") Then
                        Dim dr As DataRow = dt.NewRow
                        dr("grp_code") = dr_out("grp_code")
                        dt.Rows.Add(dr)
                        tmpGrpCode = dr_out("grp_code")
                    End If
                Next
            End If

            Return dt
        End Function

        Public Function GetDetailMember(ByVal inp As InputGetDetailMember) As OutputGetDetailMemberPara
            Dim ws As New WebGroupLinqWS
            Return ws.GetDetailMember(inp)
        End Function

        Public Function GetAccountNameList(ByVal inp As InputGetAccountNameListPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputGetAccountNameListPara = ws.GetAccountNameList(inp)
            Dim dt As New DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.AC_SEARCH_LIST
            Else
                _err = ws.ErrorMessage
            End If

            Return dt
        End Function

        Public Function GetBrokerNameList(ByVal inp As InputGetBrokerNameListPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputGetBrokerNameListPara = ws.GetBrokerNameList(inp)
            Dim dt As New DataTable
            If oup.ISFOUND = "Y" Then
                dt = oup.BROKER_SEARCH_LIST
            Else
                _err = ws.ErrorMessage
            End If

            Return dt
        End Function

        Public Function GetBrokerNameWS(ByVal brokerCode As String, ByVal lang As String) As String
            Dim ret As String = ""
            Dim inp As New InputGetBrokerNamePara
            inp.BROKER_CODE = brokerCode
            inp.LANGUAGE = lang
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputGetBrokerNamePara = ws.GetBrokerName(inp)
            If oup.ISFOUND = "Y" Then
                ret = oup.BROKER_NAME
            Else
                _err = ws.ErrorMessage
            End If

            Return ret
        End Function

        Public Function GetBenefitNonHealth(ByVal inp As InputGetBenefitNonHealthPara) As OutputGetBenefitNonHealthPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitNonHealthPara = ws.GetBenefitNonHealth(inp)
            If output.ISFOUND_NON_HEALTH = "N" Then
                _err = ws.ErrorMessage
            End If

            Return output
        End Function

        Public Function GetBenefitHealthIPD(ByVal inp As InputGetBenefitHealthIPDPara) As OutputGetBenefitHealthIPDPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitHealthIPDPara = ws.GetBenefitHealthIPD(inp)
            If output.ISFOUND_IPD = "N" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

        Public Function GetBenefitHealthOPD(ByVal inp As InputGetBenefitHealthOPDPara) As OutputGetBenefitHealthOPDPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitHealthOPDPara = ws.GetBenefitHealthOPD(inp)
            If output.ISFOUND_OPD = "N" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

        Public Function GetBenefitHealthDental(ByVal inp As InputGetBenefitHealthDentalPara) As OutputGetBenefitHealthDentalPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitHealthDentalPara = ws.GetBenefitHealthDental(inp)
            If output.ISFOUND_DENTAL = "N" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

        Public Function GetBenefitHealthMajorMed(ByVal inp As InputGetBenefitHealthMajorMedPara) As OutputGetBenefitHealthMajorMedPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitHealthMajorMedPara = ws.GetBenefitHealthMajorMed(inp)
            If output.ISFOUND_MAJOR = "N" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

        Public Function GetBenefitHealthMaternity(ByVal inp As InputGetBenefitHealthMaternityPara) As OutputGetBenefitHealthMaternityPara
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetBenefitHealthMaternityPara = ws.GetBenefitHealthMaternity(inp)
            If output.ISFOUND_MASTER = "N" Then
                _err = ws.ErrorMessage
            End If
            Return output
        End Function

    End Class
End Namespace

