Imports Engine.FAQ
Imports System.Data
Imports Para.TABLE
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmFAQDetail
    Inherits System.Web.UI.Page


    Private Sub SetQuestionDetail(ByVal vID As Long)
        Dim ret As String = ""
        ret += "<div class='arrowlistmenu' align='left' style='width:100%' >"
        Dim eng As New FAQFormENG
        Dim para As FaqPara = eng.GetFAQPara(vID)
        Dim dtF As DataTable = eng.GetFAQFile()
        ret += "    <table border='0' cellpadding='5' cellspacing='0' width='100%' >"
        ret += "        <tr>"
        ret += "            <td width='10px'>&nbsp;</td>"
        ret += "            <td style='color: #2f3e74;font-weight:bold;'>&nbsp;&nbsp;Q " & para.QUESTION & "</td>"
        ret += "        </tr>"
        ret += "        <tr>"
        ret += "            <td width='10px'>&nbsp;</td>"
        ret += "            <td style='color: #ec008c;' >"
        ret += "                    &nbsp;&nbsp;"
        ret += "                A " & para.ANSWER & "<br />"
        dtF.DefaultView.RowFilter = "faq_id = " & para.ID
        If dtF.DefaultView.Count > 0 Then
            ret += "    <b><font color='blue'>เอกสารแนบ&nbsp;</font></b>"
            For i As Integer = 0 To dtF.DefaultView.Count - 1
                Dim drF As DataRowView = dtF.DefaultView.Item(i)
                ret += "    <a href='" & Config.GetFileURL(Request) & Constant.FilePrefix.FAQ & drF("id") & drF("file_ext") & "' target='_blank' >" & drF("file_desc") & ";</a>&nbsp;"
            Next
        End If

        ret += "            </td>"
        ret += "        </tr>"
        ret += "    </table>"
        ret += "</div>"
        lblQuestionDetail.Text = ret
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "คำถามที่พบบ่อย (FAQ) >> รายละเอียดคำถาม"

        If Request("id") IsNot Nothing Then
            SetQuestionDetail(Request("id"))
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("../WebApp/frmFAQPreview.aspx?ShowSearch=Y&rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
