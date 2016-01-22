Imports Engine.GroupPolicy
Imports Para.CallWS
Imports System.Data
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmGroupPolicyMemberSearch
    Inherits System.Web.UI.Page

    Const SessMemberList As String = "SessMemberList"

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dr As DataRowView = Session("GetAccountDetailPara")
        Dim keyID() As String = Split(dr("CommandArgument").ToString, "##")

        Dim para As New InputGetQueryMemberPara
        para.P_IN_GRP_CODE = keyID(0)
        para.P_IN_AC_CODE = keyID(1)
        para.P_IN_POL_YEAR = keyID(2)
        para.P_IN_LANGUAGE = keyID(3)
        If txtMemberNo_2.Text.Trim = "" And txtMemberNo_3.Text.Trim = "" Then
            para.P_IN_MEMBER_NO = lblMemberNo1.Text
        Else
            para.P_IN_MEMBER_NO = lblMemberNo1.Text & txtMemberNo_2.Text.Trim & "-" & txtMemberNo_3.Text.Trim
        End If
        If txtHealthCardNo_2.Text.Trim = "" And txtHealthCardNo_3.Text.Trim = "" Then
            para.P_IN_HLT_CARD_NO = lblHealthCardNo1.Text
        Else
            para.P_IN_HLT_CARD_NO = lblHealthCardNo1.Text & txtHealthCardNo_2.Text.Trim & "-" & txtHealthCardNo_3.Text.Trim
        End If

        para.P_IN_EMPLOYEE_NO = txtEmployeeNo.Text.Trim

        para.P_IN_MEM_NAME = txtMemberName.Text
        para.P_IN_MEM_SURNAME = txtMemberSurname.Text
        para.P_IN_SEC_CODE = ctlSectionCode1.SectCode
        Config.SaveTransLog("ค้นหาชื่อพนักงานของบริษัท : " & para.P_IN_AC_CODE & " : " & dr("account_name"))

        Dim eng As New MemberSearchENG
        Dim dt As DataTable = eng.SearchFromWS(para)
        If dt IsNot Nothing Then
            Config.BuildNoColumn(dt)
            Session(SessMemberList) = dt
            lblDisplayData.Visible = True
            pcTop.Visible = True
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            Config.SetAlert(eng.ErrorMessage, Me)
            'Config.SetAlert("12345", Me)
            Session.Remove(SessMemberList)
            lblDisplayData.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
            'Config.SaveErrorLog(eng.ErrorMessage)
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)

        End If
    End Sub

    Protected Sub GetMemberDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim keyID As String = sender.CommandArgument
        Session("GetMemberDetailPara") = keyID
        Response.Redirect("frmGroupPolicyMemberForm.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session(SessMemberList) IsNot Nothing Then
            Dim dt As New DataTable
            dt = Session(SessMemberList)
            If dt.Rows.Count > 0 Then
                Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
                pcTop.SetMainGridView(GridView1)
                GridView1.DataSource = dt
                GridView1.DataBind()
                pcTop.Update(dt.Rows.Count)
            End If
        End If
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = Session(SessMemberList)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)

            For i As Integer = 0 To GridView1.Rows.Count - 1
                GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
            Next
        End If



        'Dim dt As New DataTable
        'dt = Session(SessGroupPolicyList)
        'If dt.Rows.Count > 0 Then
        '    GridView1.PageIndex = pc1.SelectPageIndex
        '    pc1.SetMainGridView(GridView1)
        '    GridView1.DataSource = dt
        '    GridView1.DataBind()
        '    pc1.Update(dt.Rows.Count)

        '    For i As Integer = 0 To GridView1.Rows.Count - 1
        '        GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        '    Next
        'End If
    End Sub

    Private Sub SetTextAttributes(ByVal txt As TextBox)
        txt.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txt.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GetAccountDetailPara") IsNot Nothing Then
            Dim mFrm As MasterPage = Me.Master
            Dim lblPageName As Label = mFrm.FindControl("lblPageName")
            lblPageName.Text = "ข้อมูลกรมธรรม์  >> ค้นหาข้อมูลผู้เอาประกัน(Member Search)"

            If IsPostBack = False Then
                SetTextAttributes(txtMemberNo_2)
                SetTextAttributes(txtMemberNo_3)
                SetTextAttributes(txtHealthCardNo_2)
                SetTextAttributes(txtHealthCardNo_3)

                Dim dr As DataRowView = Session("GetAccountDetailPara")
                FillAccountData(dr)
                SetSectionList(dr)
            End If
        Else
            Response.Redirect("frmLogOut.aspx?logout=Y&rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub
    Private Sub FillAccountData(ByVal dr As DataRowView)
        If dr IsNot Nothing Then
            txtGroupCode.Text = dr("grp_code")
            txtAcCode.Text = dr("account_code")
            txtAcName.Text = dr("account_name")
            txtPolNo.Text = dr("pol_no")
            txtPolYear.Text = dr("pol_year")
            'txtHealthCardNo.Text = dr("account_code")
            lblMemberNo1.Text = "E"
            lblHealthCardNo1.Text = "G-" & dr("account_code") & "-E"  'G-A84-0013-E0000011-00
        End If
    End Sub
    Private Sub SetSectionList(ByVal dr As DataRowView)
        Dim para As New InputGetSectionNameListPara
        para.AC_CODE = dr("account_code")
        para.GRP_CODE = dr("grp_code")
        ctlSectionCode1.InitialAccount(para.GRP_CODE, para.AC_CODE)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        txtMemberNo_2.Text = ""
        txtMemberNo_3.Text = ""
        txtEmployeeNo.Text = ""
        txtHealthCardNo_2.Text = ""
        txtHealthCardNo_3.Text = ""
        txtMemberName.Text = ""
        txtMemberSurname.Text = ""
        ctlSectionCode1.ClearSection()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        pcTop.Visible = False
        lblDisplayData.Visible = False
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("../WebApp/frmGroupPolicyForm.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
