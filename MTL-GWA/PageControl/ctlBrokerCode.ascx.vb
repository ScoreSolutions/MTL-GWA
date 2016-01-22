Imports System.Data
Imports Engine.Common
Imports Para.CallWS
Imports Para.Common.Utilities

Partial Class PageControl_ctlBrokerCode
    Inherits System.Web.UI.UserControl

    Const SessBrokerList As String = "SessBrokerList"
    Public ReadOnly Property BrokerCode() As String
        Get
            Return txtCode.Text.Trim
        End Get
    End Property

    Public Sub SetBroker(ByVal brokerCode As String, ByVal lang As String)
        Dim eng As New WebServiceENG
        Dim ret As String = eng.GetBrokerNameWS(brokerCode, lang)
        txtCode.Text = brokerCode
        txtName.Text = ret 'Call Web Service

        If eng.ErrorMessage.Trim <> "" Then
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me.Page)
            Config.SaveErrorLog(eng.ErrorMessage)
        End If
    End Sub

    Public Overloads ReadOnly Property ClientID() As String
        Get
            Return txtCode.ClientID
        End Get
    End Property

    Public Property Width() As Unit
        Get
            Return txtName.Width
        End Get
        Set(ByVal value As Unit)
            txtName.Width = value
        End Set
    End Property

    Private Sub SearchData(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable
        'dt.Columns.Add("broker_code")
        'dt.Columns.Add("broker_name")

        'For i As Integer = 0 To 0
        '    Dim dr As DataRow = dt.NewRow
        '    dr("ac_code") = "AA-0000" & (i + 1)
        '    dr("ac_name") = "xxxxxxxx " & (i + 1)
        '    dt.Rows.Add(dr)
        'Next

        Dim inpPara As New InputGetBrokerNameListPara
        inpPara.BROKER_CODE = txtCode.Text.Trim
        inpPara.BROKER_NAME = txtSearchBrName.Text.Trim
        inpPara.LANGUAGE = MessageResources.GetCultureDigit
        Dim eng As New WebServiceENG
        dt = eng.GetBrokerNameList(inpPara)

        If eng.ErrorMessage.Trim = "" Then
            If dt.Rows.Count = 1 Then
                txtCode.Text = dt.Rows(0)("broker_code")
                txtName.Text = dt.Rows(0)("broker_name")
                txtSearchBrName.Text = ""
            Else
                If dt.Rows.Count = 0 Then
                    If IsClickSearch = False Then
                        'ถ้าไม่พบข้อมูลเลยให้แสดงข้อมูลทั้งหมด
                        inpPara = New InputGetBrokerNameListPara
                        inpPara.BROKER_CODE = ""
                        inpPara.BROKER_NAME = ""
                        inpPara.LANGUAGE = MessageResources.GetCultureDigit
                        dt = eng.GetBrokerNameList(inpPara)
                    End If
                End If
                Config.BuildNoColumn(dt)
                Session(SessBrokerList) = dt
                pc1.SetMainGridView(GridView1)
                GridView1.DataSource = dt
                GridView1.DataBind()
                pc1.Update(dt.Rows.Count)
                zPop.Show()
            End If
        Else
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me.Page)
            Config.SaveErrorLog(eng.ErrorMessage)
        End If
    End Sub

    Protected Sub imgShowPop_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShowPop.Click
        SearchData(False)
    End Sub

    Protected Sub GetBrokerDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As LinkButton = sender
        Dim grv As GridViewRow = lbl.Parent.Parent

        Dim lnkBrCode As LinkButton = grv.Cells(1).FindControl("lnkBrCode")
        Dim lnkBrName As LinkButton = grv.Cells(2).FindControl("lnkBrName")
        txtCode.Text = lnkBrCode.Text
        txtName.Text = lnkBrName.Text
        txtSearchBrName.Text = ""
        zPop.Hide()
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessBrokerList)
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
        dt = Session(SessBrokerList)
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Attributes.Add("onkeypress", "return clickButton(event,'" + imgShowPop.ClientID + "') ")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchData(True)
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        txtSearchBrName.Text = ""
        zPop.Hide()
    End Sub

    Protected Sub txtCode_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChange
        If txtCode.Text.Trim <> "" Then
            SearchData(False)
        Else
            txtCode.Text = ""
            txtName.Text = ""
            txtSearchBrName.Text = ""
        End If
    End Sub
End Class
