Imports Engine.Claim
Imports Para.Common.Utilities
Imports System.Data
Imports Engine.Common
Imports Para.Common

Partial Class WebApp_frmClaimHealthClaim
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "บริการด้านสินไหม >> สินไหมประกันสุขภาพ(Health Claim)"

        Dim ret As String = ""
        ret += "<table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"
        ret += "<tr>"
        ret += "<td align='center' >"

        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New ClaimENG
        Dim dt As DataTable = eng.GetFileListByServiceType(Config.GetConfigValue(Constant.SystemConfig.HelthClaimServiceTypeID), trans)
        If dt.Rows.Count > 0 Then
            ret += "    <table border='0' cellpadding='0' cellpadding='0' align='left' width='80%' >"
            For Each dr As DataRow In dt.Rows
                ret += "        <tr>"
                ret += "            <td>&nbsp;</td>"
                ret += "            <td align='left' > <img src='../Images/39.gif' border='0' />"
                ret += "                <a href='" & Config.GetFileURL(Request) & "CLAIM_" & dr("id") & dr("file_ext") & "' target='_blank' OnClick=""SaveTransLog(" & Chr(39) & "ดาวน์โหลดเอกสาร " & dr("file_desc") & Chr(39) & ");"" >" & eng.GetIconFile(dr) & dr("file_desc") & " </a>"
                ret += "            </td>"
                ret += "        </tr>"
                ret += "        <tr><td colspan='2'>&nbsp;</td></tr>"
            Next
            ret += "    </table>"
        Else
            ret += "    อยู่ระหว่างการปรับปรุง (Under Construction)"
        End If
        trans.CommitTransaction()

        ret += "</td>"
        ret += "</tr>"
        ret += "</table>"

        lblFileList.Text = ret
    End Sub
End Class
