Imports Engine.UserProfile
Imports Engine.Common
Imports Para.TABLE
Imports Para.Common.Utilities
Imports Para.Common

Partial Class WebApp_frmUsersProfile
    Inherits System.Web.UI.Page

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If txtMail.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุ E-Mail", Me, txtMail.ClientID)
        ElseIf txtTel.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุเบอร์โทร", Me, txtTel.ClientID)
        End If

        Return ret
    End Function

    Private Sub DisplayUserProfile(ByVal vUserID As String)
        Dim eng As New UsersENG
        Dim para As New UsersPara
        'para = eng.GetProfileByUserID(vUserID)
        para = Config.GetLogOnUser().USER_PARA

        If para.ID <> 0 Then
            txtUserFullNameThai.Text = para.USER_NAME_T
            txtUserFillNameEng.Text = para.USER_NAME_E
            txtEffectDate.Text = para.USER_S_DATE.ToString("dd/MM/yyyy")
            txtExpireDate.Text = para.USER_E_DATE.Value.ToString("dd/MM/yyyy")
            txtUserType.Text = Config.GetUserTypeDesc(para.USER_TYPE)
            txtUserLevel.Text = para.USER_LEVEL
            txtMail.Text = para.USER_EMAIL
            txtTel.Text = para.USER_TEL

            If para.USER_ID = "SYSTEM" Then
                txtMail.TextType = UserControls_txtAutoComplete.TextboxType.TextView
                txtTel.TextType = UserControls_txtAutoComplete.TextboxType.TextView
                btnSave.Visible = False
                btnClear.Visible = False
            End If
        End If
    End Sub
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ข้อมูลส่วนตัว >> ข้อมูลผู้ใช้งาน(My Profile)"

        If IsPostBack = False Then
            txtUserID.Text = Config.GetUserID()
            txtLastLogin.Text = Config.GetLogOnUser().USER_PARA.LAST_LOGIN_TIME.Value.ToString("dd/MM/yyyy hh:mm tt")
            DisplayUserProfile(txtUserID.Text)
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Valid() = True Then
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim eng As New UsersENG
            Dim para As New UsersPara
            para = eng.GetProfileByUserID(txtUserID.Text)
            para.USER_EMAIL = txtMail.Text.Trim
            para.USER_TEL = txtTel.Text.Trim

            Dim ret As Boolean = eng.SaveUsers(txtUserID.Text, para, trans, False)
            If ret = True Then
                trans.CommitTransaction()
                Config.SaveTransLog("แก้ไขข้อมูลผู้ใช้งาน")
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย(Save complete.)", Me, txtUserFullNameThai.ClientID)
            Else
                trans.RollbackTransaction()
                Config.SaveErrorLog(eng.ErrorMessage)
                Config.SetAlert(eng.ErrorMessage, Me, txtUserFullNameThai.ClientID)
            End If
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        Config.SaveTransLog("คลิกปุ่ม ยกเลิก")
        DisplayUserProfile(txtUserID.Text)
    End Sub
End Class
