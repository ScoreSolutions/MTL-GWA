Imports Para.CallWS
Imports Para.OutputWS
Imports Engine.Common
Imports System.Data
Partial Class PageControl_incLife
    Inherits System.Web.UI.UserControl

    Public Sub ShowLife(ByVal para As InputGetBenefitNonHealthPara)
        Dim eng As New WebServiceENG
        Dim oup As OutputGetBenefitNonHealthPara = eng.GetBenefitNonHealth(para)
        If oup.ISFOUND_NON_HEALTH = "Y" Then
            lblTitle.Text = para.BENEFIT_TYPE
            Dim dt As DataTable = oup.BENEFIT_LIST
            If oup.BENEFIT_LIST.Rows.Count > 0 Then
                lblLifeDesc.Text = ""
                For Each dr As DataRow In dt.Rows
                    lblLifeDesc.Text += "<tr height='30px'>"
                    lblLifeDesc.Text += "   <td align='left' >&nbsp;&nbsp;" & dr("benefit") & "</td>"
                    lblLifeDesc.Text += "   <td align='right' >" & dr("money_amt") & "&nbsp;&nbsp;</td>"
                    lblLifeDesc.Text += "</tr>"
                Next
            End If
            Config.SaveTransLog("แสดงรายละเอียดแบบประกันชีวิตสำหรับ " & para.BENEFIT_TYPE)
            zPop.Show()
        Else
            If eng.ErrorMessage <> "" Then
                LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                Config.SetAlert("ไม่พบข้อมูลของแผนความคุ้มครอง กรุณาติดต่อเจ้าหน้าที่ \n\r (Benefit Plan detail not found. Please contact our staff.)", Me.Page)
            Else
                LogENG.SaveErrorLog("ไม่พบข้อมูลจาก Web Service", Config.GetLogOnUser)
                Config.SetAlert("ไม่พบข้อมูลของแผนความคุ้มครอง กรุณาติดต่อเจ้าหน้าที่ \n\r (Benefit Plan detail not found. Please contact our staff.)", Me.Page)
            End If
        End If
    End Sub
End Class
