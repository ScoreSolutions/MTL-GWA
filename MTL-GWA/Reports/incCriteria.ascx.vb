Imports Para.Common.Utilities
Imports System.Data
Imports Para.CallWS
Imports Para.OutputWS
Imports Engine.Reports

Partial Class Reports_incCriteria
    Inherits System.Web.UI.UserControl

    Const ReportSessAccountList As String = "ReportSessAccountList"
    Const SessAccountList As String = "SessAccountList"

    Public Event SelectedAccount()
    Dim _Valid As Boolean = True

    Public ReadOnly Property Valid() As Boolean
        Get
            If txtGroupCode.Text.Trim = "" Then
                _Valid = False
                Config.SetAlert("กรุณาระบุรหัสกลุ่มบริษัท", Me.Page, txtGroupCode.ClientID)
            ElseIf txtAccountCode.Text.Trim = "" Then
                _Valid = False
                Config.SetAlert("กรุณาระบุรหัสบริษัท", Me.Page, txtAccountCode.ClientID)
            ElseIf txtPolicyNo.Text.Trim = "" Then
                _Valid = False
                Config.SetAlert("กรุณาระบุเลขที่กรมธรรม์", Me.Page, txtPolicyNo.ClientID)
            ElseIf txtPolYear.Text.Trim = "" Then
                _Valid = False
                Config.SetAlert("กรุณาระบุปีกรมธรรม์", Me.Page, txtPolYear.ClientID)
            End If

            Return _Valid
        End Get
    End Property
    Public ReadOnly Property GroupCode() As UserControls_txtAutoComplete
        Get
            Return txtGroupCode
        End Get
    End Property
    Public ReadOnly Property PolicyNo() As UserControls_txtAutoComplete
        Get
            Return txtPolicyNo
        End Get
    End Property
    Public ReadOnly Property PolicyYear() As UserControls_txtAutoComplete
        Get
            Return txtPolYear
        End Get
    End Property
    Public ReadOnly Property AccountCode() As UserControls_txtAutoComplete
        Get
            Return txtAccountCode
        End Get
    End Property

    Protected Sub GetAccountDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As LinkButton = sender
        Dim grv As GridViewRow = lbl.Parent.Parent

        Dim lnkAcCode As LinkButton = grv.Cells(1).FindControl("lnkAcCode")
        txtAccountCode.Text = lnkAcCode.Text

        Dim dv As DataView
        If Session(SessAccountList) IsNot Nothing Then
            dv = CType(Session(SessAccountList), DataTable).DefaultView
        Else
            dv = CType(Session(ReportSessAccountList), DataTable).DefaultView
        End If
        dv.RowFilter = "account_code = '" & txtAccountCode.Text & "'"
        If dv.Count = 1 Then
            txtGroupCode.Text = dv(0)("grp_code")
            txtPolicyNo.Text = dv(0)("pol_no")
            txtPolYear.Text = dv(0)("pol_year")

            txtSearchAcName.Text = ""

            RaiseEvent SelectedAccount()
        End If

        zPop.Hide()
    End Sub

    Private Sub SearchData(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable
        If Session(ReportSessAccountList) IsNot Nothing Then
            dt = CType(Session(ReportSessAccountList), DataTable).Copy
            If dt.Rows.Count > 0 Then
                If IsClickSearch = True Then
                    Dim dv As DataView = dt.DefaultView
                    dv.RowFilter = "account_name like '%" & txtSearchAcName.Text.Trim & "%'"
                    dt = dv.ToTable
                End If
                If dt.Rows.Count = 0 Then
                    'ถ้าไม่พบข้อมูลเลยให้แสดงข้อมูลทั้งหมด
                    If IsClickSearch = False Then
                        dt = Session(ReportSessAccountList)
                    End If
                End If
                Config.BuildNoColumn(dt)
                Session(SessAccountList) = dt    'For Page Change & Sorting
                pc1.SetMainGridView(GridView1)
                GridView1.DataSource = dt
                GridView1.DataBind()
                pc1.Update(dt.Rows.Count)
                zPop.Show()
            End If
        Else
            Config.SetAlert("ไม่พบข้อมูลจาก Web Service", Me.Page)
        End If
    End Sub

    Protected Sub imgShowPop_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShowPop.Click
        SearchData(False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Session(Constant.UserJoinCaseSession) IsNot Nothing Then
                Dim oup As OutputGetUserJoinCasePara = Session(Constant.UserJoinCaseSession)
                Session(ReportSessAccountList) = oup.OUT_CASE_LIST
            Else
                Dim eng As New ReportsENG
                Session(ReportSessAccountList) = eng.GetUserJoinCaseDT(Config.GetUserID)
            End If
        End If
        txtAccountCode.Attributes.Add("onkeypress", "return clickButton(event,'" + imgShowPop.ClientID + "') ")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        SearchData(True)
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessAccountList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
        End If
        zPop.Show()
    End Sub

    Protected Sub pc1_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pc1.PageChange
        Dim dt As New DataTable
        dt = Session(SessAccountList)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pc1.SelectPageIndex
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)

            For i As Integer = 0 To GridView1.Rows.Count - 1
                GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
            Next
        End If
        zPop.Show()
    End Sub

    Public Sub ClearAll()
        txtPolicyNo.Text = ""
        txtPolYear.Text = ""
        txtAccountCode.Text = ""
        txtSearchAcName.Text = ""
        txtGroupCode.Text = ""
    End Sub
End Class
