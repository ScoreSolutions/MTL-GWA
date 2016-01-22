Imports System.Data
Imports Engine.Common
Imports Para.CallWS
Imports Para.Common.Utilities

Partial Class PageControl_ctlSectionCode
    Inherits System.Web.UI.UserControl

    Public Event PopClick()
    Public Event Click(ByVal sender As Object, ByVal e As EventArgs)

    Const SessSectList As String = "SessSectList"

    Public ReadOnly Property SectCode() As String
        Get
            Return txtCode.Text.Trim
        End Get
    End Property

    Public Sub SetSection(ByVal sectCode As String)
        Dim inp As New InputGetSectionNameListPara
        inp.AC_CODE = txtAcCode.Text.Trim
        inp.GRP_CODE = txtGrpCode.Text.Trim
        inp.LANGUAGE = MessageResources.GetCultureDigit
        inp.SECT_CODE = sectCode

        Dim ws As New WebServiceENG
        txtCode.Text = inp.SECT_CODE
        txtName.Text = ws.GetSectionNameWS(inp)
    End Sub

    Public Sub ClearSection()
        txtCode.Text = ""
        txtName.Text = ""
        txtSearchSectName.Text = ""
    End Sub
    Public Property Width() As Unit
        Get
            Return txtName.Width
        End Get
        Set(ByVal value As Unit)
            txtName.Width = value
        End Set
    End Property

    Public Overloads ReadOnly Property ClientID() As String
        Get
            Return txtCode.ClientID
        End Get
    End Property

    Public Sub InitialAccount(ByVal grpCode As String, ByVal acCode As String)
        txtGrpCode.Text = grpCode
        txtAcCode.Text = acCode
        ClearSection()
        Session(SessSectList) = Nothing
    End Sub

    Private Sub SearchData(ByVal IsKeyCode As Boolean)
        Dim dt As New DataTable

        Dim inpPara As New InputGetSectionNameListPara
        inpPara.AC_CODE = txtAcCode.Text
        inpPara.GRP_CODE = txtGrpCode.Text
        If IsKeyCode = True Then
            inpPara.SECT_CODE = txtCode.Text
        End If
        inpPara.SECT_NAME = txtSearchSectName.Text
        inpPara.LANGUAGE = MessageResources.GetCultureDigit
        Dim eng As New WebServiceENG
        dt = eng.GetSectionNameList(inpPara)

        If dt.Rows.Count > 0 Then
            Config.BuildNoColumn(dt)
            Session(SessSectList) = dt
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
        Else
            'ถ้ากรณีกรอกที่่ช่องรหัส แล้วไม่พบข้อมูลเลยให้แสดงข้อมูลทั้งหมด
            If IsKeyCode = True Then
                inpPara = New InputGetSectionNameListPara
                inpPara.AC_CODE = txtAcCode.Text
                inpPara.GRP_CODE = txtGrpCode.Text
                inpPara.LANGUAGE = MessageResources.GetCultureDigit
                dt = eng.GetSectionNameList(inpPara)
                If dt.Rows.Count > 0 Then
                    Config.BuildNoColumn(dt)
                    Session(SessSectList) = dt
                    pc1.SetMainGridView(GridView1)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    pc1.Update(dt.Rows.Count)
                Else
                    Session(SessSectList) = Nothing
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                    pc1.Visible = False
                    Config.SetAlert(eng.ErrorMessage, Me.Page, txtSearchSectName.ClientID)

                    If IsKeyCode = True Then
                        txtCode.Text = ""
                        txtName.Text = ""
                    End If
                End If
            Else
                Session(SessSectList) = Nothing
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                pc1.Visible = False
                Config.SetAlert(eng.ErrorMessage, Me.Page, txtSearchSectName.ClientID)
                If IsKeyCode = True Then
                    txtCode.Text = ""
                    txtName.Text = ""
                End If
            End If
        End If
        zPop.Show()
    End Sub

    Protected Sub imgShowPop_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShowPop.Click
        SearchData(False)
        RaiseEvent PopClick()
    End Sub

    Protected Sub GetSectionDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As LinkButton = sender
        Dim grv As GridViewRow = lbl.Parent.Parent

        Dim lnkAcCode As LinkButton = grv.Cells(1).FindControl("lnkSectCode")
        Dim lnkAccountName As LinkButton = grv.Cells(2).FindControl("lnkSectName")
        txtCode.Text = lnkAcCode.Text
        txtName.Text = lnkAccountName.Text
        txtSearchSectName.Text = ""
        RaiseEvent PopClick()
        zPop.Hide()
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessSectList)
        If dt.Rows.Count > 0 Then
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pc1.SelectPageIndex)
            pc1.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
        End If
        RaiseEvent PopClick()
        zPop.Show()
    End Sub

    Protected Sub pc1_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pc1.PageChange
        Dim dt As New DataTable
        dt = Session(SessSectList)
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
        RaiseEvent PopClick()
        zPop.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Attributes.Add("onkeypress", "return clickButton(event,'" + imgShowPop.ClientID + "') ")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchData(False)
        RaiseEvent PopClick()
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        txtSearchSectName.Text = ""
        RaiseEvent PopClick()
        zPop.Hide()
    End Sub

    Protected Sub txtCode_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChange
        If txtCode.Text.Trim <> "" Then
            SearchData(True)
        Else
            txtCode.Text = ""
            txtName.Text = ""
            txtSearchSectName.Text = ""
        End If
        RaiseEvent PopClick()
    End Sub
End Class
