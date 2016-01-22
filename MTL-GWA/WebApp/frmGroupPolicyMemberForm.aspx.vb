Imports Engine.GroupPolicy
Imports System.Data
Imports Para.CallWS
Imports Para.OutputWS
Imports Engine.Common
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmGroupPolicyMemberForm
    Inherits System.Web.UI.Page

    Private Sub GetLifePlan()
        Dim eng As New MemberFormENG
        Dim dt As DataTable = eng.GetPlanLife
        If dt.Rows.Count > 0 Then
            gvLife.DataSource = dt
            gvLife.DataBind()
        Else
            gvLife.DataSource = Nothing
            gvLife.DataBind()
        End If
    End Sub

    Private Sub GetHealthPlan()
        Dim eng As New MemberFormENG
        Dim dt As DataTable = eng.GetPlanHealth

        If dt.Rows.Count > 0 Then
            gvHealth1.DataSource = dt
            gvHealth1.DataBind()
        Else
            gvHealth1.DataSource = Nothing
            gvHealth1.DataBind()
        End If
    End Sub

    Const SessLifeList As String = "SessLifeList"
    Const SessHealth1List As String = "SessHealth1List"
    Const SessHealth2List As String = "SessHealth2List"

    Private Sub FillData()
        Dim keyMem() As String = Split(Session("GetMemberDetailPara").ToString(), "##")
        Dim dr As DataRowView = Session("GetAccountDetailPara")
        Dim keyID() As String = Split(dr("CommandArgument").ToString, "##")

        Dim para As New InputGetDetailMember
        para.GRP_CODE = keyID(0)
        para.AC_CODE = keyID(1)
        para.POL_YEAR = keyID(2)
        para.LANGUAGE = keyID(3)
        para.MEMBER_NO = keyMem(1)


        ''Demo
        'para.GRP_CODE = "G75-0001"
        'para.AC_CODE = "A75-0011"
        'para.POL_YEAR = "37"
        'para.LANGUAGE = "T"
        'para.MEMBER_NO = keyMem(1)

        Dim ws As New WebServiceENG
        Dim output As OutputGetDetailMemberPara = ws.GetDetailMember(para)
        If output.ISFOUND_DET = "Y" Then
            txtAccountCode.Text = para.AC_CODE
            txtAccountName.Text = dr("account_name")
            txtGroupCode.Text = para.GRP_CODE
            txtPolNo.Text = dr("pol_no")
            txtPolYear.Text = para.POL_YEAR
            txtMemberName.Text = keyMem(2)
            txtMemberNo.Text = keyMem(1)
            txtEmployeeNo.Text = keyMem(0)
            txtBirthDate.Text = ConfigENG.ConvertDateFromWS(output.MEM_DOB).ToString("dd/MM/yyyy")
            txtAge.Text = output.MEM_AGE
            txtRelation.Text = keyMem(3)
            txtGender.Text = output.MEM_SEX
            txtEffectDate.Text = ConfigENG.ConvertDateFromWS(output.EFFECT_DATE).ToString("dd/MM/yyyy")
            txtExpireDate.Text = ConfigENG.ConvertDateFromWS(output.PLAN_E_DATE).ToString("dd/MM/yyyy")
            txtBankAccountNo.Text = output.MEM_BKAC_NO
            txtHealthCard.Text = output.HLT_CARD
            txtSection.Text = output.MEM_SECT
            txtMeditation.Text = output.CONSIDER
            txtMemberStatus.Text = output.BENEFIT_STS
            txtHealthPlanRemarks.Text = output.PLAN_NOTEPAD1
            lblBenefitDetail.Text = "ผลประโยชน์ความคุ้มครอง ตามกรมธรรม์ ณ วันที่ " & DateTime.Now.ToString("dd/MM/yyyy") & "<br />"
            lblBenefitDetail.Text += "(Policy benefits as of " & DateTime.Now.ToString("dd/MM/yyyy", New System.Globalization.CultureInfo("en-US")) & ")"

            If output.PLAN_HLT_LIST1 IsNot Nothing Then
                lblHealthPlan.Text = "แผนคุ้มครองสุขภาพ <br />"
                lblHealthPlan.Text += "(Group Health Insurance Plans)"
                TabContainer1.Visible = True
                lblHealth1.Text = output.PLAN_CODE_H1
                Config.BuildNoColumn(output.PLAN_HLT_LIST1)
                Session(SessHealth1List) = output.PLAN_HLT_LIST1
                gvHealth1.DataSource = output.PLAN_HLT_LIST1
                gvHealth1.DataBind()
            Else
                lblHealthPlan.Text = ""
                gvHealth1.DataSource = Nothing
                gvHealth1.DataBind()
                TabContainer1.Visible = False
            End If

            If output.PLAN_HLT_LIST2 IsNot Nothing Then
                tabHealth2.Visible = True
                lblHealth2.Text = output.PLAN_CODE_H2
                Config.BuildNoColumn(output.PLAN_HLT_LIST2)
                Session(SessHealth2List) = output.PLAN_HLT_LIST2
                gvHealth2.DataSource = output.PLAN_HLT_LIST2
                gvHealth2.DataBind()
            Else
                tabHealth2.Visible = False
                gvHealth2.DataSource = Nothing
                gvHealth2.DataBind()
            End If

            If output.PLAN_NONHLT_LIST IsNot Nothing Then
                tbNonHealth.Visible = True
                Config.BuildNoColumn(output.PLAN_NONHLT_LIST)
                Session(SessLifeList) = output.PLAN_NONHLT_LIST
                gvLife.DataSource = output.PLAN_NONHLT_LIST
                gvLife.DataBind()
            Else
                gvLife.DataSource = Nothing
                gvLife.DataBind()
                tbNonHealth.Visible = False
            End If
            Config.SaveTransLog("แสดงรายละเอียดพนักงาน " & txtMemberName.Text & " EmployeeNo:" & txtEmployeeNo.Text)
        Else
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
            Config.SaveErrorLog(ws.ErrorMessage)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลกรมธรรม์  >> รายละเอียดผู้เอาประกัน(Member Info)"

        If IsPostBack = False Then
            If Session("GetMemberDetailPara") IsNot Nothing Then
                FillData()
            Else
                Response.Redirect("frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond)
            End If

            'txtMemberNo.CssClass = "TextView"
            'txtMemberNo.Attributes.Add("OnKeyPress", "txtKeyPress(event);")
            'txtMemberNo.Attributes.Add("onKeyDown", "CheckKeyBackSpace(event);")

            ''Demo
            'GetLifePlan()
            'GetHealthPlan()
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("frmGroupPolicyMemberSearch.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub gvLife_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLife.Sorted
        For i As Integer = 0 To gvLife.Rows.Count - 1
            gvLife.Rows(i).Cells(0).Text = (i + 1)
        Next
    End Sub

    Protected Sub gvLife_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvLife.Sorting
        SetGvSorting(e, Session(SessLifeList), txtSortFieldLife, txtSortDirLife, gvLife)
    End Sub

    Protected Sub gvHealth1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvHealth1.Sorted
        For i As Integer = 0 To gvHealth1.Rows.Count - 1
            gvHealth1.Rows(i).Cells(0).Text = (i + 1)
        Next
    End Sub

    Private Sub SetGvSorting(ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs, ByVal dt As DataTable, ByVal txtSortField As TextBox, ByVal txtSortDir As TextBox, ByVal gv As GridView)
        If dt.Rows.Count > 0 Then
            If e.SortExpression = "DEFAULT" Then
                txtSortDirH1.Text = e.SortDirection
                txtSortFieldH1.Text = e.SortExpression
            Else
                If txtSortField.Text = e.SortExpression Then
                    txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
                Else : txtSortField.Text = e.SortExpression
                End If
            End If

            Dim sortStr As String = ""
            If txtSortField.Text.Trim <> "" Then
                sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
            End If
            dt.DefaultView.Sort = sortStr
            dt = dt.DefaultView.ToTable()
            If dt.Columns.Contains("no") Then
                Config.ReRuningNo(dt)
            Else
                Config.BuildNoColumn(dt)
            End If

            gv.DataSource = dt
            gv.DataBind()
        End If
    End Sub

    Protected Sub gvHealth1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvHealth1.Sorting
        SetGvSorting(e, Session(SessHealth1List), txtSortFieldH1, txtSortDirH1, gvHealth1)
    End Sub

    Protected Sub gvHealth2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvHealth2.Sorting
        SetGvSorting(e, Session(SessHealth2List), txtSortFieldH2, txtSortDirH2, gvHealth2)
    End Sub
End Class
