Imports Engine.Common
Imports Engine.UserProfile
Imports Para.TABLE
Imports Para.CallWS
Imports Para.OutputWS
Imports Para.Common.Utilities
Imports System.Data
Imports Para.Common

Partial Class WebApp_frmMasterUsersForm
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Config.SetAlert(txtPasswordDate.GetDateCondition, Me, txtPasswordDate.ClientID)
        If Valid() = True Then
            Dim trans As New DbTrans
            trans.CreateTransaction()

            Dim para As New UsersPara
            'Dim para As New InputInsertUserProfilePara
            para.ID = IIf(txtID.Text = "", "0", txtID.Text)
            para.USER_ID = txtUserID.Text.Trim
            para.USER_PASSWD = ConfigENG.EnCripPwd(txtPassword.Text.Trim)
            para.USER_S_DATE = txtStartDate.DateValue
            para.USER_E_DATE = txtExpireDate.DateValue
            para.PASSWD_DATE = txtPasswordDate.DateValue
            para.USER_TYPE = cmbUserType.SelectedValue
            para.BROKER_CODE = ctlBrokerCode1.BrokerCode
            para.AC_CODE = ctlAccountCode1.AccountCode
            para.USER_NAME_T = txtUserNameThai.Text.Trim
            para.USER_NAME_E = txtUserNameEng.Text.Trim
            para.COMPANY_NAME = txtCompanyName.Text.Trim
            para.USER_EMAIL = txtUserEmail.Text.Trim
            para.USER_TEL = txtTel.Text.Trim
            para.USER_LEVEL = cmbUserLevel.SelectedValue
            para.DISC_REASON = txtDiscReason.Text.Trim
            para.MARKET_EMAIL = txtEmailOfMarketing.Text.Trim
            para.MARKET_CC_EMAIL = txtEmailOfMarketingCC.Text.Trim
            para.CLAIM_EMAIL = txtEmailOfClaim.Text.Trim
            para.CLAIM_CC_EMAIL = txtEmailOfClaimCC.Text.Trim
            para.INPUT_PERSON = txtInputPerson.Text.Trim
            para.CREATE_DTTM = DateTime.Now
            para.MNT_DTTM = DateTime.Now
            para.LOGIN_FAIL_COUNT = 0
            para.IS_FIRST_LOGIN = "Y"

            Dim eng As New UsersENG
            Dim ret As Boolean = eng.SaveUsers(Config.GetUserID, para, trans, (txtPassword.Text.Trim <> ""))
            'Dim ret As Boolean = eng.SaveUsers("SYSTEM", para, trans)
            If ret = True Then
                trans.CommitTransaction()
                SetUsersForm(eng.ID)
                LogENG.SaveTransLog("บันทึกรายชื่อผู้ใช้งาน", Config.GetLogOnUser)
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                LogENG.SaveErrorLog(eng.ErrorMessage, Config.GetLogOnUser)
                'Config.SetAlert(eng.ErrorMessage, Me)
                Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
            End If
        End If
    End Sub

    Private Sub SetUsersForm(ByVal vID As Long)
        Dim eng As New UsersENG
        Dim para As UsersPara = eng.GetProfileByID(vID)
        If para.ID <> 0 Then
            txtID.Text = para.ID
            txtUserID.Text = para.USER_ID
            txtPassword.Text = ConfigENG.DeCripPwd(para.USER_PASSWD)
            txtStartDate.DateValue = para.USER_S_DATE
            txtExpireDate.DateValue = para.USER_E_DATE
            txtPasswordDate.DateValue = para.PASSWD_DATE
            cmbUserType.SelectedValue = para.USER_TYPE
            If para.USER_TYPE = Constant.UserType.BROKER Then
                If para.BROKER_CODE.Trim <> "" Then
                    ctlBrokerCode1.SetBroker(para.BROKER_CODE, MessageResources.GetCultureDigit())
                End If
            ElseIf para.USER_TYPE = Constant.UserType.MEMBER Then
                If para.AC_CODE.Trim <> "" Then
                    ctlAccountCode1.SetAccount(para.AC_CODE, MessageResources.GetCultureDigit())
                End If
            End If
            txtUserNameThai.Text = para.USER_NAME_T
            txtUserNameEng.Text = para.USER_NAME_E
            txtCompanyName.Text = para.COMPANY_NAME
            txtUserEmail.Text = para.USER_EMAIL
            txtTel.Text = para.USER_TEL
            cmbUserLevel.SelectedValue = para.USER_LEVEL
            txtDiscReason.Text = para.DISC_REASON
            txtEmailOfMarketing.Text = para.MARKET_EMAIL
            txtEmailOfMarketingCC.Text = para.MARKET_CC_EMAIL
            txtEmailOfClaim.Text = para.CLAIM_EMAIL
            txtEmailOfClaimCC.Text = para.CLAIM_CC_EMAIL
            txtInputPerson.Text = para.INPUT_PERSON
            txtMntDate.DateValue = para.MNT_DTTM

            btnResponseCompany.Visible = True
            SetResGridview(txtUserID.Text)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลผู้ใช้งาน >> เพิ่มข้อมูลผู้ใช้ระบบ (New Users)"

        If IsPostBack = False Then
            SetCombo()
        End If
    End Sub

    Private Sub SetCombo()
        cmbUserType.SetItemList("HR", "H")
        cmbUserType.SetItemList("Broker", "B")
        cmbUserType.SetItemList("Agent", "A")
        cmbUserType.SetItemList("Member", "M")
        cmbUserType.SetItemList("Super User", "S")
        cmbUserType.SetItemList("User", "U")
        cmbUserType.SetItemList("Admin (IT)", "I")


        For i As Integer = 1 To 99
            cmbUserLevel.SetItemList(i, i)
        Next

    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If txtUserID.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ User ID", Me, txtUserID.ClientID)
        ElseIf txtPassword.Text.Trim = "" And txtID.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ Password", Me, txtPassword.ClientID)
        ElseIf txtStartDate.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุ Start Date", Me, txtStartDate.ClientID)
        ElseIf txtExpireDate.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุ Expire Date", Me, txtStartDate.ClientID)
        ElseIf txtPasswordDate.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุ Password Date", Me, txtPasswordDate.ClientID)
        ElseIf txtPasswordDate.DateValue < txtStartDate.DateValue Or txtPasswordDate.DateValue > txtExpireDate.DateValue Then
            ret = False
            Config.SetAlert("Password Date must be >= Start Date and must be <= Expire Date", Me, txtPasswordDate.ClientID)
        ElseIf cmbUserType.SelectedValue = Constant.UserType.BROKER And ctlBrokerCode1.BrokerCode.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือก Broker", Me, ctlBrokerCode1.ClientID)
        ElseIf cmbUserType.SelectedValue = Constant.UserType.MEMBER And ctlAccountCode1.AccountCode.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือก Account", Me, ctlAccountCode1.ClientID)
        ElseIf txtUserNameThai.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ User Name Thai", Me, txtUserNameThai.ClientID)
        ElseIf txtUserNameEng.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ User Name Englist", Me, txtUserNameEng.ClientID)
        ElseIf txtCompanyName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ Company Name", Me, txtCompanyName.ClientID)
        ElseIf txtUserEmail.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ User E-Mail", Me, txtUserEmail.ClientID)
        ElseIf txtEmailOfMarketing.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ E-Mail of Marketing", Me, txtEmailOfMarketing.ClientID)
        ElseIf txtEmailOfMarketingCC.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ CC", Me, txtEmailOfMarketingCC.ClientID)
        ElseIf txtEmailOfClaim.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ E-Mail of Claim", Me, txtEmailOfClaim.ClientID)
        ElseIf txtEmailOfClaimCC.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ CC", Me, txtEmailOfClaimCC.ClientID)
        Else
            Dim eng As New UsersENG
            Dim vID As Long = 0
            If txtID.Text.Trim <> "" Then
                vID = Convert.ToInt64(txtID.Text)
            End If

            If eng.ChkDupUserID(txtUserID.Text.Trim, vID) = True Then
                ret = False
                Config.SetAlert("User ID ซ้ำ", Me, txtUserID.ClientID)
            End If
        End If
        Return ret
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            SetDefault()
            If Request("id") IsNot Nothing Then
                SetUsersForm(Request("id"))
            End If
        End If
    End Sub
    Private Sub SetDefault()
        txtPassword.Attributes.Add("OnBlur", "return ValidPassword('" & txtPassword.ClientID & "');")
        txtPassword.Attributes.Add("OnKeyPress", "ValidPasswordKeyPress(event,'" & txtPassword.ClientID & "');")
        txtPassword.Attributes.Add("OnKeyDown", "ValidPwdKeyDown(event);")
        txtPassword.Attributes.Add("OnKeyUp", "ValidPwdKeyUp(event,'" & txtPassword.ClientID & "');")
        txtPassword.Attributes.Add("OnMouseDown", "ValidRightClick(event)")

        txtStartDate.LinkAttributes.Remove("OnClick")
        txtStartDate.LinkAttributes.Add("OnClick", "NewCssCal('" & txtStartDate.ClientID & "','DDMMYYYY',null,null,null,null,'" & txtPasswordDate.ClientID & "','" & txtExpireDate.ClientID & "');")
        txtStartDate.DateValue = DateTime.Now
        txtExpireDate.DateValue = Today.AddDays(-1).AddYears(1)
        txtPasswordDate.DateValue = Today.AddDays(-1).AddDays(90)
        txtInputPerson.Text = Config.GetLogOnUser().USER_PARA.USER_ID
    End Sub

    Protected Sub btnResponseCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResponseCompany.Click
        txtResUser.Text = txtUserID.Text
        zPop.Show()
    End Sub

    Protected Sub btnResSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResSave.Click
        If ctlResAccount.AccountCode.Trim <> "" Then
            If ValidRes() = True Then
                Dim trans As New DbTrans
                trans.CreateTransaction()

                Dim para As New UsersResponseCompanyPara
                para.ID = IIf(txtResponseCompanyID.Text.Trim = "", "0", txtResponseCompanyID.Text.Trim)
                para.USER_ID = txtUserID.Text.Trim
                para.GRP_CODE = txtResGroupCode.Text.Trim
                para.AC_CODE = ctlResAccount.AccountCode.Trim
                'Dim ws As New WebServiceENG
                para.AC_NAME = ctlResAccount.AccountName.Trim   'ws.GetAccountNameWS(ctlResAccount.AccountCode.Trim, txtResLanguage.Text.Trim)
                para.POL_YEAR = txtResPolYear.Text.Trim
                para.POL_NO = txtResPolNo.Text.Trim
                para.USER_GPO_ID = txtResUserGPO.Text.Trim
                para.LANGUAGE = txtResLanguage.Text.Trim
                para.INPUT_PERSON = Config.GetUserID
                para.INPUT_PERSON = Config.GetUserID
                para.CREATE_DTTM = DateTime.Now
                para.MNT_DTTM = DateTime.Now

                Dim eng As New UsersENG
                Dim ret As Boolean = eng.SaveUsersResponseCompany(txtUserID.Text.Trim, para, trans)
                If ret = True Then
                    trans.CommitTransaction()
                    SetResGridview(txtUserID.Text)
                    ClearResForm()
                    Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
                Else
                    trans.RollbackTransaction()
                    'Config.SetAlert(eng.ErrorMessage, Me)
                    Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
                End If
            End If
            zPop.Show()
        Else
            Config.SetAlert("กรุณาเลือกบริษัท", Me, ctlResAccount.ClientID)
            zPop.Show()
        End If
    End Sub

    Private Function ValidRes() As Boolean
        Dim ret As Boolean = True
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New UsersENG
        If eng.ChkDupUsersResponseCompany(Convert.ToInt64(txtResponseCompanyID.Text), txtUserID.Text, ctlResAccount.AccountCode, trans) = True Then
            ret = False
            Config.SetAlert("บริษัทที่เลือกซ้ำ\r\n(Duplicate account)", Me)
        End If
        trans.CommitTransaction()
        Return ret
    End Function

    Private Sub ClearResForm()
        txtResponseCompanyID.Text = "0"
        ctlResAccount.SetAccount("", "T")
        txtResGroupCode.Text = ""
        txtResPolNo.Text = ""
        txtResPolYear.Text = ""
        txtResUserGPO.Text = ""
        txtResLanguage.Text = ""
    End Sub

    Const SessResList As String = "SessResList"
    Private Sub SetResGridview(ByVal UserID As String)
        Dim eng As New UsersENG
        Dim dt As DataTable = eng.GetUserProfileDetailList(UserID)
        If dt.Rows.Count > 0 Then
            Config.BuildNoColumn(dt)
            'dt.Columns.Add("ac_name")
            'Dim i As Integer = 1
            'For Each dr As DataRow In dt.Rows
            '    Dim ws As New WebServiceENG
            '    dr("ac_name") = ws.GetAccountNameWS(dr("ac_code").ToString, dr("language").ToString)
            '    i += 1
            'Next
            pc1.SetMainGridView(GridView1)
            Session(SessResList) = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
            pc1.Update(dt.Rows.Count)
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pc1.Visible = False
            Session(SessResList) = Nothing
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim eng As New UsersENG

        If e.CommandName = "EDIT" Then
            Dim para As UsersResponseCompanyPara = eng.GetUserProfileDetailByID(e.CommandArgument)
            txtResponseCompanyID.Text = para.ID
            txtResUser.Text = para.USER_ID
            ctlResAccount.SetAccount(para.AC_CODE, para.LANGUAGE)
            txtResGroupCode.Text = para.GRP_CODE
            txtResPolNo.Text = para.POL_NO
            txtResPolYear.Text = para.POL_YEAR
            txtResUserGPO.Text = para.USER_GPO_ID
            txtResLanguage.Text = para.LANGUAGE
        ElseIf e.CommandName = "DELETE" Then
            Dim ret As Boolean = eng.DeleteProfileDetail(e.CommandArgument)
            If ret = True Then
                SetResGridview(txtResUser.Text)
            Else
                Config.SetAlert(eng.ErrorMessage, Me)
            End If
        End If

        zPop.Show()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

    End Sub

    Protected Sub ctlResAccount_PopClick() Handles ctlResAccount.PopClick
        If ctlResAccount.AccountCode.Trim <> "" Then
            Dim eng As New WebServiceENG
            Dim output As OutputGetAccountUserPofilePara = eng.GetAccountUserProfile(ctlResAccount.AccountCode)
            If output.ISFOUND = "Y" Then
                txtResGroupCode.Text = output.GRP_CODE
                txtResPolNo.Text = output.POL_NO
                txtResPolYear.Text = output.POL_YEAR
                txtResUserGPO.Text = output.USER_GPO_ID
                txtResLanguage.Text = output.LANGUAGE
            Else
                Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
                Config.SaveErrorLog(eng.ErrorMessage)
            End If
        End If
        zPop.Show()
    End Sub

    Protected Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        For i As Integer = 0 To GridView1.Rows.Count - 1
            GridView1.Rows(i).Cells(0).Text = (GridView1.PageIndex * GridView1.PageSize) + (i + 1)
        Next
        zPop.Show()
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessResList)
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
        dt = Session(SessResList)
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

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        If txtID.Text.Trim = "0" Or txtID.Text.Trim = "" Then
            ClearUserForm()
            SetDefault()
        Else
            SetUsersForm(txtID.Text.Trim)
        End If
    End Sub

    Private Sub ClearUserForm()
        txtID.Text = "0"
        txtUserID.Text = ""
        txtPassword.Text = ""
        txtStartDate.DateValue = New Date(1, 1, 1)
        txtExpireDate.DateValue = New Date(1, 1, 1)
        txtPasswordDate.DateValue = New Date(1, 1, 1)
        cmbUserType.SelectedValue = "H"
        cmbUserLevel.SelectedValue = "1"
        ctlBrokerCode1.SetBroker("", "")
        ctlAccountCode1.SetAccount("", "")
        txtUserNameThai.Text = ""
        txtUserNameEng.Text = ""
        txtCompanyName.Text = ""
        txtUserEmail.Text = ""
        txtTel.Text = ""
        txtDiscReason.Text = ""
        txtEmailOfMarketing.Text = ""
        txtEmailOfMarketingCC.Text = ""
        txtEmailOfClaim.Text = ""
        txtEmailOfClaimCC.Text = ""
        txtInputPerson.Text = ""
        txtMntDate.DateValue = New Date(1, 1, 1)

        btnResponseCompany.Visible = False
        SetResGridview(txtUserID.Text)
    End Sub

    Protected Sub btnResCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnResCancel.Click
        ClearResForm()
        zPop.Show()
    End Sub
End Class
