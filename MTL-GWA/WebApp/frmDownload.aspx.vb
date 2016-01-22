Imports Engine.Download
Imports System.Data
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmDownload
    Inherits System.Web.UI.Page



    Private Sub SetTabDisable()
        btnTabForm.ActiveTab = False
        btnTabManual.ActiveTab = False
        btnTabOther.ActiveTab = False
    End Sub
    Protected Sub btnTabManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabManual.Click
        SetTabManual()
        Config.SaveTransLog("คลิกแท็บคู่มือ")
    End Sub


    Private Sub SetTabManual()
        SetTabDisable()
        btnTabManual.ActiveTab = True

        Dim ret As String = ""
        ret += "<table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"
        ret += "<tr>"
        ret += "<td class='CssSubHeadPink' align='left' >ดาวน์โหลดคู่มือประกันกลุ่ม(Group Insurance Handbook)</td>"
        ret += "</tr>"
        ret += "<tr>"
        ret += "<td align='left' >"
        ret += "    <table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"

        Dim trans As New Engine.Common.DbTrans
        trans.CreateTransaction()
        Dim eng As New DownloadENG
        Dim dt As DataTable = eng.GetDownloadList(1, trans, Config.GetUserID)
        If dt.Rows.Count > 0 Then
            Dim i As Integer = 0
            For Each dr As DataRow In dt.Rows
                If i Mod 2 = 0 Then
                    ret += "        <tr>"
                Else
                    ret += "        <tr style='background-color: #E8E8E8;'>"
                End If
                ret += "            <td>&nbsp;</td>"
                ret += "            <td > <img src='../Images/39.gif' border='0' />"
                ret += "                <a href='" & Config.GetFileURL(Request) & Constant.FilePrefix.DOWNLOAD & dr("id") & dr("file_ext") & "' target='_blank' OnClick=""SaveTransLog(" & Chr(39) & "ดาวน์โหลดเอกสาร " & dr("file_desc") & Chr(39) & ");"" >"
                ret += "                    " & eng.GetIconFile(dr) & dr("file_desc") & " </a>"
                ret += "            </td>"
                ret += "        </tr>"
                ret += "        <tr><td colspan='2'>&nbsp;</td></tr>"
                i += 1
            Next
        Else
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >อยู่ระหว่างการปรับปรุง (Under Construction)</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
        End If
        trans.CommitTransaction()
        ret += "    </table>"
        ret += "</td>"
        ret += "</tr>"
        ret += "</table>"

        lblFileList.Text = ret
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ดาวน์โหลด (Download)"

        If IsPostBack = False Then
            SetTabManual()
        End If
    End Sub

    Protected Sub btnTabForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabForm.Click
        SetTabDisable()
        btnTabForm.ActiveTab = True
        Dim ret As String = ""
        ret += "<table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"
        ret += "<tr>"
        ret += "<td class='CssSubHeadPink' align='left' >ดาวน์โหลดแบบฟอร์ม(Forms)</td>"
        ret += "</tr>"
        ret += "<tr>"
        ret += "<td align='left' >"
        ret += "    <table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"

        Dim trans As New Engine.Common.DbTrans
        trans.CreateTransaction()
        Dim eng As New DownloadENG
        Dim dt As DataTable = eng.GetDownloadList(2, trans, Config.GetUserID)
        If dt.Rows.Count > 0 Then
            Dim i As Integer = 0
            For Each dr As DataRow In dt.Rows
                If i Mod 2 = 0 Then
                    ret += "        <tr>"
                Else
                    ret += "        <tr style='background-color: #E8E8E8;'>"
                End If
                ret += "            <td>&nbsp;</td>"
                ret += "            <td > <img src='../Images/39.gif' border='0' />"
                ret += "                <a href='" & Config.GetFileURL(Request) & Constant.FilePrefix.DOWNLOAD & dr("id") & dr("file_ext") & "' target='_blank' OnClick=""SaveTransLog(" & Chr(39) & "ดาวน์โหลดเอกสาร " & dr("file_desc") & Chr(39) & ");"" >"
                ret += "                    " & eng.GetIconFile(dr) & dr("file_desc") & " </a>"
                ret += "            </td>"
                ret += "        </tr>"
                ret += "        <tr><td colspan='2'>&nbsp;</td></tr>"
                i += 1
            Next
        Else
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >อยู่ระหว่างการปรับปรุง (Under Construction)</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
        End If
        trans.CommitTransaction()
        ret += "    </table>"
        ret += "</td>"
        ret += "</tr>"
        ret += "</table>"

        lblFileList.Text = ret
        Config.SaveTransLog("คลิกแท็บแบบฟอร์ม")
    End Sub

    Protected Sub btnTabOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabOther.Click
        SetTabDisable()
        btnTabOther.ActiveTab = True
        Dim ret As String = ""
        ret += "<table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"
        ret += "<tr>"
        ret += "<td class='CssSubHeadPink' align='left' >ดาวน์โหลดเอกสารอื่นๆ(Others)</td>"
        ret += "</tr>"
        ret += "<tr>"
        ret += "<td align='left' >"
        ret += "    <table border='0' cellpadding='0' cellpadding='0' align='left' width='100%' >"
        Dim trans As New Engine.Common.DbTrans
        trans.CreateTransaction()
        Dim eng As New DownloadENG
        Dim dt As DataTable = eng.GetDownloadList(3, trans, Config.GetUserID)
        If dt.Rows.Count > 0 Then
            Dim i As Integer = 0
            For Each dr As DataRow In dt.Rows
                If i Mod 2 = 0 Then
                    ret += "        <tr>"
                Else
                    ret += "        <tr style='background-color: #E8E8E8;'>"
                End If
                ret += "            <td>&nbsp;</td>"
                ret += "            <td > <img src='../Images/39.gif' border='0' />"
                ret += "                <a href='" & Config.GetFileURL(Request) & Constant.FilePrefix.DOWNLOAD & dr("id") & dr("file_ext") & "' target='_blank' OnClick=""SaveTransLog(" & Chr(39) & "ดาวน์โหลดเอกสาร " & dr("file_desc") & Chr(39) & ");"" >"
                ret += "                    " & eng.GetIconFile(dr) & dr("file_desc") & " </a>"
                ret += "            </td>"
                ret += "        </tr>"
                ret += "        <tr><td colspan='2'>&nbsp;</td></tr>"
                i += 1
            Next
        Else
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >อยู่ระหว่างการปรับปรุง (Under Construction)</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
            ret += "        <tr><td align='center' >&nbsp;</td></tr>"
        End If
        trans.CommitTransaction()

        ret += "    </table>"
        ret += "</td>"
        ret += "</tr>"
        ret += "</table>"

        lblFileList.Text = ret
        Config.SaveTransLog("คลิกแท็บอื่นๆ")
    End Sub
End Class
