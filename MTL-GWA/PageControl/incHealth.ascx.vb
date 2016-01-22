Imports System.Data
Imports Para.CallWS
Imports Para.OutputWS
Imports Engine.Common

Partial Class PageControl_incHealth
    Inherits System.Web.UI.UserControl


    Public Sub ClearDesc()
        lblHealthDesc.Text = ""
    End Sub

    Public Sub ShowHealth()
        If lblHealthDesc.Text.Trim <> "" Then
            zPop.Show()
        Else
            Config.SetAlert("ไม่พบข้อมูลของแผนความคุ้มครอง กรุณาติดต่อเจ้าหน้าที่ \n\r (Benefit Plan detail not found. Please contact our staff.)", Me.Page)
        End If
    End Sub

    Public Sub SetBenefitType(ByVal BenefitType As String)
        lblTitle.Text = BenefitType
    End Sub

    Public Sub ShowHealth(ByVal para As InputGetBenefitHealthIPDPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitHealthIPDPara = eng.GetBenefitHealthIPD(para)
        If oup.ISFOUND_IPD = "Y" Then
            CreateDesc(oup.BENEFIT_LIST, oup.SUB_INS_TYPE)
            Config.SaveTransLog("แสดงรายละเอียดประกันสุขภาพสำหรับ " & oup.SUB_INS_TYPE)
        Else
            Config.SaveErrorLog(eng.ErrorMessage)
        End If


    End Sub

    Public Sub ShowHealth(ByVal para As InputGetBenefitHealthOPDPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitHealthOPDPara = eng.GetBenefitHealthOPD(para)
        If oup.ISFOUND_OPD = "Y" Then
            CreateDesc(oup.BENEFIT_LIST, oup.SUB_INS_TYPE)
            Config.SaveTransLog("แสดงรายละเอียดประกันสุขภาพสำหรับ " & oup.SUB_INS_TYPE)
        Else
            Config.SaveErrorLog(eng.ErrorMessage)
        End If
    End Sub

    Public Sub ShowHealth(ByVal para As InputGetBenefitHealthDentalPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitHealthDentalPara = eng.GetBenefitHealthDental(para)
        If oup.ISFOUND_DENTAL = "Y" Then
            CreateDesc(oup.BENEFIT_LIST, oup.SUB_INS_TYPE)
            Config.SaveTransLog("แสดงรายละเอียดประกันสุขภาพสำหรับ " & oup.SUB_INS_TYPE)
        Else
            Config.SaveErrorLog(eng.ErrorMessage)
        End If
    End Sub

    Public Sub ShowHealth(ByVal para As InputGetBenefitHealthMajorMedPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitHealthMajorMedPara = eng.GetBenefitHealthMajorMed(para)
        If oup.ISFOUND_MAJOR = "Y" Then
            CreateDesc(oup.BENEFIT_LIST, oup.SUB_INS_TYPE)
            Config.SaveTransLog("แสดงรายละเอียดประกันสุขภาพสำหรับ " & oup.SUB_INS_TYPE)
        Else
            Config.SaveErrorLog(eng.ErrorMessage)
        End If


    End Sub

    Public Sub ShowHealth(ByVal para As InputGetBenefitHealthMaternityPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitHealthMaternityPara = eng.GetBenefitHealthMaternity(para)
        If oup.ISFOUND_MASTER = "Y" Then
            CreateDesc(oup.BENEFIT_LIST, oup.SUB_INS_TYPE)
            Config.SaveTransLog("แสดงรายละเอียดประกันสุขภาพสำหรับ " & oup.SUB_INS_TYPE)
        Else
            Config.SaveErrorLog(eng.ErrorMessage)
        End If
    End Sub

    Private Sub CreateDesc(ByVal dt As DataTable, ByVal BenefitType As String)
        If dt.Rows.Count > 0 Then
            lblHealthDesc.Text += "<tr height='30px'>"
            lblHealthDesc.Text += "  <td align='left' ><b>" & BenefitType & "</b></td>"
            lblHealthDesc.Text += "  <td align='right' >&nbsp;</td>"
            lblHealthDesc.Text += "  <td >&nbsp;</td>"
            lblHealthDesc.Text += "</tr>"

            For Each dr As DataRow In dt.Rows
                lblHealthDesc.Text += "<tr height='30px'>"
                lblHealthDesc.Text += "   <td align='left' >&nbsp;&nbsp;" & dr("benefit")
                If dr("remarks") <> "" And dr("remarks") <> "-" Then
                    lblHealthDesc.Text += "<br />&nbsp;&nbsp;"
                    lblHealthDesc.Text += "(" & dr("remarks") & ")"
                End If
                lblHealthDesc.Text += "    </td>"
                If dr("money_amt") = "-" Then
                    lblHealthDesc.Text += "   <td align='center' >&nbsp;&nbsp;" & dr("money_amt") & "</td>"
                Else
                    lblHealthDesc.Text += "   <td align='right' >&nbsp;&nbsp;" & dr("money_amt") & "&nbsp;&nbsp;</td>"
                End If

                lblHealthDesc.Text += "</tr>"
            Next
        End If
    End Sub

End Class
