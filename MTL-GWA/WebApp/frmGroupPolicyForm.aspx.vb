Imports System.Data
Imports Engine.GroupPolicy
Imports Para.OutputWS
Imports Para.CallWS
Imports Para.Common.Utilities
Imports Engine.Common
Imports Para.Common

Partial Class WebApp_frmGroupPolicyForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลกรมธรรม์  >> ข้อมูลบริษัทผู้เอาประกัน(Policy Info)"

        If IsPostBack = False Then
            'Call WS()
            FillData()
        End If
    End Sub

    Private Sub FillData()
        '        Dim para As InputGetAccountDetailPara = Session("GetAccountDetailPara")
        If Session("GetAccountDetailPara") IsNot Nothing Then
            Dim dr As DataRowView = Session("GetAccountDetailPara")
            Dim keyID() As String = Split(dr("CommandArgument").ToString, "##")

            Dim para As New InputGetAccountDetailPara
            para.P_GRP_CODE = keyID(0)
            para.P_AC_CODE = keyID(1)
            para.P_POL_YEAR = keyID(2)
            para.P_LANGUATE = keyID(3)

            Dim eng As New WebServiceENG
            Dim output As OutputGetAccountDetailPara = eng.GetAccountDetail(para)
            If output.ISFOUND_DETAIL = "Y" Then
                txtGroupCode.Text = para.P_GRP_CODE
                txtPolicyNo.Text = dr("pol_no")
                txtPolicyNane.Text = output.POL_NAME
                txtAccountCode.Text = para.P_AC_CODE
                txtAccountName.Text = dr("account_name")
                txtEffectiveDate.Text = dr("effect_date")
                txtExpireDate.Text = dr("expire_date")
                txtPolicyYear.Text = para.P_POL_YEAR
                txtModeOfPayment.Text = output.PAYMENT_MODE
                txtAddress.Text = output.ADDRESS
                txtAccountStatus.Text = output.ACCOUNT_STS
                txtFreeCoverAmount.Text = output.FCL_AMT
                txtHealthCard.Text = output.HEALTH_CARD
                txtEmployeeAgeFrom.Text = output.MIN_AGE
                txtEmployeeAgeTo.Text = output.MAX_AGE
                txtContactPerson.Text = output.CONTACT_PERSON

                If output.PLAN_LIST IsNot Nothing Then
                    lblEffectedDate.Text = "ผลประโยชน์ความคุ้มครอง ตามกรมธรรม์ ณ วันที่ " & DateTime.Now.ToString("dd/MM/yyyy") & "<br />"
                    lblEffectedDate.Text += "(Policy benefits as of " & DateTime.Now.ToString("dd/MM/yyyy", New System.Globalization.CultureInfo("en-US")) & ")"
                    GridView1.DataSource = output.PLAN_LIST
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = Nothing
                End If

                Select Case output.ACCOUNT_STS
                    Case Constant.AccountStatus.INPROGRESS_TH, Constant.AccountStatus.INPROGRESS_EN, Constant.AccountStatus.POLICY_EXPIRED_EN, Constant.AccountStatus.POLICY_EXPIRED_TH
                        btnMemberDetail.Visible = False
                        lblTypeOfInsurance.Visible = False
                End Select

                Config.SaveTransLog("แสดงรายละเอียดบริษัท " & dr("account_name"))
            Else
                LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่  \n\r (Connection failed; Please try again or contact our staff.)", Me)
            End If
        Else
            Response.Redirect("frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    Private Sub SetGridview()
        Dim eng As New GroupPolicyFormENG
        Dim dt As DataTable = eng.GetBenefitPlanList

        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            GridView1.DataSource = Nothing
        End If
    End Sub


    Const CellBenefitTableCode As Integer = 4
    Const CellBenefitTableStartDate As Integer = 5
    Const CellEndorseNo As Integer = 6
    Const CellBenefitType As Integer = 1

    Protected Sub GetBenefitDetail(ByVal sender As Object, ByVal e As System.EventArgs)
        'Call WS Data

        Dim dr As DataRowView = Session("GetAccountDetailPara")
        Dim keyGID() As String = Split(dr("CommandArgument").ToString, "##")
        Dim lbl As LinkButton = sender
        Dim grv As GridViewRow = lbl.Parent.Parent

        Dim keyID As String = sender.CommandArgument
        If keyID <> "4" Then
            Dim para As New InputGetBenefitNonHealthPara
            para.GRP_CODE = keyGID(0)
            para.AC_CODE = keyGID(1)
            para.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para.LANGUAGE = keyGID(3)

            Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            para.BENEFIT_TYPE = lnkProtectionType.Text
            incLife1.ShowLife(para)

        Else
            incHealth1.ClearDesc()
            Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            incHealth1.SetBenefitType(lnkProtectionType.Text)

            '#### IPD
            Dim para1 As New InputGetBenefitHealthIPDPara
            para1.GRP_CODE = keyGID(0)
            para1.AC_CODE = keyGID(1)
            para1.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para1.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para1.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para1.LANGUAGE = keyGID(3)
            'Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            'para1.BENEFIT_TYPE = lnkProtectionType.Text
            incHealth1.ShowHealth(para1)

            '####OPD
            Dim para2 As New InputGetBenefitHealthOPDPara
            para2.GRP_CODE = keyGID(0)
            para2.AC_CODE = keyGID(1)
            para2.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para2.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para2.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para2.LANGUAGE = keyGID(3)
            'Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            'para2.BENEFIT_TYPE = lnkProtectionType.Text
            incHealth1.ShowHealth(para2)

            '####Dental
            Dim para3 As New InputGetBenefitHealthDentalPara
            para3.GRP_CODE = keyGID(0)
            para3.AC_CODE = keyGID(1)
            para3.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para3.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para3.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para3.LANGUAGE = keyGID(3)
            'Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            'para.BENEFIT_TYPE = lnkProtectionType.Text
            incHealth1.ShowHealth(para3)

            '####MaorMed
            Dim para4 As New InputGetBenefitHealthMajorMedPara
            para4.GRP_CODE = keyGID(0)
            para4.AC_CODE = keyGID(1)
            para4.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para4.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para4.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para4.LANGUAGE = keyGID(3)
            'Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            'para4.BENEFIT_TYPE = lnkProtectionType.Text
            incHealth1.ShowHealth(para4)

            '####Maternity
            Dim para5 As New InputGetBenefitHealthMaternityPara
            para5.GRP_CODE = keyGID(0)
            para5.AC_CODE = keyGID(1)
            para5.BEN_TAB_CODE = grv.Cells(CellBenefitTableCode).Text
            para5.BEN_TAB_S_DATE = grv.Cells(CellBenefitTableStartDate).Text
            If grv.Cells(CellEndorseNo).Text.Trim <> "&nbsp;" And grv.Cells(CellEndorseNo).Text.Trim <> "" Then
                para5.BEN_TAB_END_NO = grv.Cells(CellEndorseNo).Text
            End If
            para5.LANGUAGE = keyGID(3)
            'Dim lnkProtectionType As LinkButton = grv.Cells(CellBenefitType).FindControl("lnkProtectionType")
            'para.BENEFIT_TYPE = lnkProtectionType.Text
            incHealth1.ShowHealth(para5)

            incHealth1.ShowHealth()
        End If
    End Sub

    Protected Sub btnMemberDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMemberDetail.Click
        If Session("GetAccountDetailPara") IsNot Nothing Then
            Dim dr As DataRowView = Session("GetAccountDetailPara")
            Dim keyID() As String = Split(dr("CommandArgument").ToString, "##")
            Config.SaveTransLog("แสดงหน้าจอค้นหาพนักงานของบริษัท " & keyID(1) & " : " & dr("account_name"))
        End If

        Response.Redirect("frmGroupPolicyMemberSearch.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
