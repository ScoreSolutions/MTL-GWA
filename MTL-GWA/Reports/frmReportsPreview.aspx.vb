Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Para.Common.Utilities
Imports Engine.Common
Imports Engine.Reports
Imports System.Data
Imports Para.CallWS

Partial Class Reports_frmReportsPreview
    Inherits System.Web.UI.Page


    Private Sub PrintReport(ByVal reportName As String)
        Dim rpt As New ReportDocument


        Dim tbLogOn As New TableLogOnInfo
        tbLogOn.ConnectionInfo.ServerName = DbConn.DataSource
        tbLogOn.ConnectionInfo.DatabaseName = DbConn.DbName
        tbLogOn.ConnectionInfo.UserID = DbConn.DbUserID
        tbLogOn.ConnectionInfo.Password = DbConn.DbPwd

        If DbConn.ChkConnection = True Then
            CrystalReportViewer1.LogOnInfo.Add(tbLogOn)
            Dim rep As New ReportsENG
            If reportName = rep.HealthClaimPaidByBenefit Then
                Dim para As New InputHltClmPaidByBenefitPara
                para.GRP_CODE = Request("vGroupCode")
                para.AC_CODE = Request("vAccountCode")
                para.POL_NO = Request("vPolNo")
                para.POL_YEAR = Request("vPolYear")
                para.LANGUAGE = MessageResources.GetCultureDigit
                para.USER_ID = Config.GetUserID

                Dim dt As DataTable = rep.GetHealthClaimPaidByBenefit(para)

                If dt.Rows.Count > 0 Then
                    rpt.Load(Server.MapPath(Constant.HomeFolder & "/Reports/" & reportName & ".rpt"))
                    rpt.SetDataSource(dt)
                    CreateReport(Constant.ReportType.PDF, rpt, reportName)
                Else
                    CrystalReportViewer1.Visible = False
                    lblErrorMessage.Text = rep.RETURN_MSG
                End If
            ElseIf reportName = rep.HealthClaimPaidByAccountAndEmployee Then
                Dim para As New InputHltClmPaidByAcc_EmpPara
                para.GRP_CODE = Request("vGroupCode")
                para.AC_CODE = Request("vAccountCode")
                para.POL_NO = Request("vPolNo")
                para.POL_YEAR = Request("vPolYear")
                para.LANGUAGE = MessageResources.GetCultureDigit
                para.SECTION_CODE = Request("vSectionCode")
                If para.SECTION_CODE.Trim <> "" Then
                    para.SECTION_NAME = GetSectionName(para.SECTION_CODE, para)
                End If

                para.TOP_LEVEL = Request("vTopLevel")
                para.SORT_TYPE = Request("vSortType")
                para.USER_ID = Config.GetUserID

                Dim dt As DataTable = rep.GetHealthClaimPaidByAccountAndEmployee(para)
                If dt IsNot Nothing Then
                    rpt.Load(Server.MapPath(Constant.HomeFolder & "/Reports/" & reportName & ".rpt"))
                    rpt.SetDataSource(dt)
                    CreateReport(Constant.ReportType.PDF, rpt, reportName)
                Else
                    CrystalReportViewer1.Visible = False
                    lblErrorMessage.Text = rep.RETURN_MSG
                End If
            ElseIf reportName = rep.HealthClaimPaidByDiagnosis Then
                Dim para As New InputHltClmPaidByDiagnosePara
                para.GRP_CODE = Request("vGroupCode")
                para.AC_CODE = Request("vAccountCode")
                para.POL_NO = Request("vPolNo")
                para.POL_YEAR = Request("vPolYear")
                para.LANGUAGE = MessageResources.GetCultureDigit
                para.SORT_TYPE = Request("vSortType")
                para.TOP_LEVEL = Request("vTopLevel")
                para.USER_ID = Config.GetUserID

                Dim dt As DataTable = rep.GetHealthClaimPaidByDiagnosis(para)
                If dt IsNot Nothing Then
                    rpt.Load(Server.MapPath(Constant.HomeFolder & "/Reports/" & reportName & ".rpt"))
                    rpt.SetDataSource(dt)
                    CreateReport(Constant.ReportType.PDF, rpt, reportName)
                Else
                    CrystalReportViewer1.Visible = False
                    lblErrorMessage.Text = rep.RETURN_MSG
                End If
            ElseIf reportName = rep.HealthClaimPaidByPlanRelationship Then
                Dim para As New InputHltClmPaidByPlanRelationPara
                para.GRP_CODE = Request("vGroupCode")
                para.AC_CODE = Request("vAccountCode")
                para.POL_NO = Request("vPolNo")
                para.POL_YEAR = Request("vPolYear")
                para.LANGUAGE = MessageResources.GetCultureDigit
                para.USER_ID = Config.GetUserID

                Dim dt As DataTable = rep.GetHealthClaimPaidByPlanRelation(para)
                If dt IsNot Nothing Then
                    Dim rptFile As String = Constant.HomeFolder & "/Reports/" & reportName
                    If dt.Rows(0)("type").ToString.Trim = "" Then
                        rpt.Load(Server.MapPath(rptFile & "_.rpt"))
                        rpt.SetDatabaseLogon(DbConn.DbUserID, DbConn.DbPwd, DbConn.DataSource, DbConn.DbName)
                    ElseIf dt.Rows(0)("type").ToString.Trim = "1" Then
                        rpt.Load(Server.MapPath(rptFile & "_1.rpt"))
                        rpt.SetDatabaseLogon(DbConn.DbUserID, DbConn.DbPwd, DbConn.DataSource, DbConn.DbName)
                    ElseIf dt.Rows(0)("type").ToString.Trim = "2" Then
                        rpt.Load(Server.MapPath(rptFile & "_2.rpt"))
                        rpt.SetDatabaseLogon(DbConn.DbUserID, DbConn.DbPwd, DbConn.DataSource, DbConn.DbName)
                    ElseIf dt.Rows(0)("type").ToString.Trim = "3" Then
                        rpt.Load(Server.MapPath(rptFile & "_2.rpt"))
                        rpt.SetDatabaseLogon(DbConn.DbUserID, DbConn.DbPwd, DbConn.DataSource, DbConn.DbName)
                    End If
                    rpt.SetDataSource(dt)
                    CreateReport(Constant.ReportType.PDF, rpt, reportName)
                Else
                    CrystalReportViewer1.Visible = False
                    lblErrorMessage.Text = rep.RETURN_MSG
                End If
            ElseIf reportName = rep.HealthClaimPaidByHospital Then
                Dim para As New InputHltClmPaidByHospitalPara
                para.GRP_CODE = Request("vGroupCode")
                para.AC_CODE = Request("vAccountCode")
                para.POL_NO = Request("vPolNo")
                para.POL_YEAR = Request("vPolYear")
                para.LANGUAGE = MessageResources.GetCultureDigit
                para.SORT_TYPE = Request("vSortType")
                para.TOP_LEVEL = Request("vTopLevel")
                para.USER_ID = Config.GetUserID

                Dim dt As DataTable = rep.GetHealthClaimPaidByHospital(para)
                If dt IsNot Nothing Then
                    rpt.Load(Server.MapPath(Constant.HomeFolder & "/Reports/" & reportName & ".rpt"))
                    rpt.SetDataSource(dt)
                    CreateReport(Constant.ReportType.PDF, rpt, reportName)
                Else
                    CrystalReportViewer1.Visible = False
                    lblErrorMessage.Text = rep.RETURN_MSG
                End If
            End If

            'CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub

    Private Sub CreateReport(ByVal vReportType As String, ByVal rpt As ReportDocument, ByVal reportName As String)
        If vReportType <> Constant.ReportType.CRYSTAL Then
            Dim s As System.IO.MemoryStream
            With System.Web.HttpContext.Current.Response
                .ClearContent()
                .ClearHeaders()
                If vReportType = Constant.ReportType.PDF Then
                    s = rpt.ExportToStream(ExportFormatType.PortableDocFormat)
                    .ContentType = "application/pdf"
                    .AddHeader("Content-Disposition", "inline; filename=" & reportName & ".pdf")
                ElseIf vReportType = Constant.ReportType.EXCEL Then
                    s = rpt.ExportToStream(ExportFormatType.Excel)                    
                    '                    .ContentType = "application/vnd.ms-excel"
                    .ContentType = "application/msexcel"
                    .AddHeader("Content-Disposition", "inline; filename=" & reportName & ".xls")
                ElseIf vReportType = Constant.ReportType.WORD Then
                    s = rpt.ExportToStream(ExportFormatType.WordForWindows)
                    .ContentType = "application/msword"
                    .AddHeader("Content-Disposition", "inline; filename=" & reportName & ".doc")
                End If
                .BinaryWrite(s.ToArray)
                .End()
            End With
        End If
    End Sub

    Private Function GetSectionName(ByVal SecCode As String, ByVal inp As InputHltClmPaidByAcc_EmpPara) As String
        Dim inp2 As New InputGetSectionNameListPara
        inp2.GRP_CODE = inp.GRP_CODE
        inp2.AC_CODE = inp.AC_CODE
        inp2.LANGUAGE = inp.LANGUAGE
        inp2.SECT_CODE = SecCode

        Dim ws As New Engine.Common.WebServiceENG
        Return ws.GetSectionNameWS(inp2)
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsPostBack = False Then
        If Request IsNot Nothing Then
            PrintReport(Request("ReportName"))
        End If
        'End If
    End Sub
End Class
