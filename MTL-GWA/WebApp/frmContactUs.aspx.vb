Imports Engine.Common
Imports Engine.ContactUs
Imports Para.TABLE
Imports Para.Common.Utilities
Imports System.Web.Mail
Imports Para.CallWS
Imports Para.OutputWS
Imports LinqWS
Imports System.Data
Imports Para.Common

Partial Class WebApp_frmContactUs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Request("menuID") IsNot Nothing Then
                SetPageContent(Request("menuID"))
                SetDefault()
            End If
        End If
    End Sub

    Private Sub SetDefault()
        Dim oup As OutputGetUserJoinCasePara
        If Session(Constant.UserJoinCaseSession) IsNot Nothing Then
            oup = Session(Constant.UserJoinCaseSession)
        Else
            Dim para As New InputGetUserJoinCasePara
            para.USER_ID = Config.GetUserID
            Dim ws As New WebServiceENG
            oup = ws.GetUserJoinCase(para)
        End If
        If oup.ISFOUND_CASE = "Y" Then
            If oup.OUT_CASE_LIST IsNot Nothing Then
                Dim dt As New DataTable
                dt.Columns.Add("account_code")
                dt.Columns.Add("account_name")
                dt.Columns.Add("language")
                dt.Columns.Add("mtl_user_id")
                For i As Integer = 0 To oup.OUT_CASE_LIST.Rows.Count - 1
                    Dim dr As DataRow = dt.NewRow()
                    dr("account_code") = oup.OUT_CASE_LIST.Rows(i)("account_code")
                    dr("account_name") = oup.OUT_CASE_LIST.Rows(i)("account_code") & " : " & oup.OUT_CASE_LIST.Rows(i)("account_name")
                    dr("language") = oup.OUT_CASE_LIST.Rows(i)("language")
                    dr("mtl_user_id") = oup.OUT_CASE_LIST.Rows(i)("mtl_user_id")
                    dt.Rows.Add(dr)
                Next
                cmbAccountCode.SetItemList(dt, "account_name", "account_code")
                Session("AccountList") = dt
            End If
        End If
        If rdiSendType.Visible = True Then
            rdiSendType.SelectedValue = "1"
        End If
        txtDescription.Text = ""
        txtSendBackMail.Text = Config.GetLogOnUser.USER_PARA.USER_EMAIL
        txtID.Text = "0"
    End Sub

    Private Sub SetPageContent(ByVal vMenuID As Long)
        Dim trans As New DbTrans
        trans.CreateTransaction()
        Dim eng As New ContactUsENG
        Dim MenuPara As MenuPara = eng.GetMenuParameter(vMenuID, trans)
        trans.CommitTransaction()
        Dim mFrm As MasterPage = Me.Master
        Dim lblPageName As Label = mFrm.FindControl("lblPageName")
        lblPageName.Text = "ติดต่อเรา >> " & MenuPara.MENU_NAME_THAI & "(" & MenuPara.MENU_NAME_ENG & ")"
        txtMenuID.Text = vMenuID

        If vMenuID = Constant.MailContactType.PolicyService Or vMenuID = Constant.MailContactType.LifeClaimService Then
            rdiSendType.Visible = True
        Else
            rdiSendType.Visible = False
        End If
        Config.SaveTransLog("แสดงหน้าจอเมื่อคลิกเมนู" & MenuPara.MENU_NAME_THAI)
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Valid() = True Then
            Dim trans As New DbTrans
            trans.CreateTransaction()

            Dim para As New ContactUsPara
            para.ID = txtID.Text.Trim
            para.MENU_ID = txtMenuID.Text
            para.ACCOUNT_CODE = cmbAccountCode.SelectedValue
            para.DESCRIPTION = txtDescription.Text.Trim
            para.REPLY_MAIL = txtSendBackMail.Text.Trim
            If rdiSendType.Visible = True Then
                para.SEND_TYPE = rdiSendType.SelectedValue
            End If

            Dim eng As New ContactUsENG
            Dim ret As Boolean = eng.SaveContactUS(Config.GetUserID, para, trans)
            If ret = True Then
                If SendMail(para) = True Then
                    trans.CommitTransaction()
                    SetDefault()
                    Config.SaveTransLog("ถามคำถามสำหรับ " & lblContactUsType.Text)
                    Config.SetAlert("คำถามของท่านถูกส่งไปยังบริษัทเมืองไทยประกันชีวิตเรียบร้อยแล้ว\r\n(Your question is sent to the Muang Thai Life Assurance has been.)", Me)
                Else
                    trans.RollbackTransaction()
                    Config.SaveErrorLog(eng.ErrorMessage)
                    Config.SetAlert(eng.ErrorMessage, Me)
                End If
            Else
                trans.RollbackTransaction()
                Config.SaveErrorLog(eng.ErrorMessage)
                Config.SetAlert(eng.ErrorMessage, Me)
            End If
        End If
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If cmbAccountCode.SelectedValue = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือกชื่อบริษัท", Me, cmbAccountCode.ClientID)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรายละเอียดคำถาม", Me, cmbAccountCode.ClientID)
        ElseIf txtSendBackMail.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุอีเมล์สำหรับติดต่อกลับ", Me, txtSendBackMail.ClientID)
        End If
        Return ret
    End Function

    Private Function SendMail(ByVal para As ContactUsPara) As Boolean
        Dim ret As Boolean = True
        Try
            Dim uUser As Para.Common.UserProfilePara = Config.GetLogOnUser
            Dim mail As New MailMessage()
            Dim dt As New DataTable
            Dim lang As String = ""
            Dim GpoUserID As String = ""
            If Session("AccountList") IsNot Nothing Then
                dt = Session("AccountList")
                dt.DefaultView.RowFilter = "account_code = '" & para.ACCOUNT_CODE & "'"
                If dt.DefaultView.Count > 0 Then
                    lang = dt.DefaultView(0)("language").ToString
                    GpoUserID = dt.DefaultView(0)("mtl_user_id").ToString
                End If

                If para.MENU_ID = Constant.MailContactType.PolicyService Or para.MENU_ID = Constant.MailContactType.LifeClaimService Then
                    'บริการสินไหมชีวิต และบริการกรมธรรม์
                    If rdiSendType.SelectedValue = "1" Then
                        Dim eng As New ContactUsENG
                        Dim pam As New InputGetContractNamePara
                        pam.GPO_USER_ID = GpoUserID
                        pam.LANGUAGE = lang
                        Dim oup As OutputGetContractNamePara = eng.GetContactName(pam)
                        If oup.ISFOUND = "Y" Then
                            mail.To = oup.GPO_EMAIL
                            mail.Cc = oup.GPO_CC_EMAIL
                        Else
                            Config.SaveErrorLog(eng.ErrorMessage)
                            'Config.SetAlert(eng.ErrorMessage, Me)
                            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
                            ret = False
                        End If
                    ElseIf rdiSendType.SelectedValue = "2" Then
                        mail.To = uUser.USER_PARA.MARKET_EMAIL
                        mail.Cc = uUser.USER_PARA.MARKET_CC_EMAIL
                    ElseIf rdiSendType.SelectedValue = "3" Then
                        Dim eng As New ContactUsENG
                        Dim pam As New InputGetContractNamePara
                        pam.GPO_USER_ID = GpoUserID
                        pam.LANGUAGE = lang
                        Dim oup As OutputGetContractNamePara = eng.GetContactName(pam)
                        If oup.ISFOUND = "Y" Then
                            mail.To = oup.GPO_EMAIL & ";" & uUser.USER_PARA.MARKET_EMAIL
                            mail.Cc = oup.GPO_CC_EMAIL & ";" & uUser.USER_PARA.MARKET_CC_EMAIL
                        Else
                            Config.SaveErrorLog(eng.ErrorMessage)
                            'Config.SetAlert(eng.ErrorMessage, Me)
                            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
                            ret = False
                        End If
                    End If
                ElseIf para.MENU_ID = Constant.MailContactType.HealthClaimService Then
                    mail.To = uUser.USER_PARA.CLAIM_EMAIL
                    mail.Cc = uUser.USER_PARA.CLAIM_CC_EMAIL
                End If
                mail.Headers.Add("Reply-To", txtSendBackMail.Text.Replace(",", ";"))
                mail.From = Config.GetConfigValue("MailFrom")
                mail.Subject = CreateMailSubject()
                mail.BodyFormat = MailFormat.Text
                mail.Body = txtDescription.Text
                SmtpMail.SmtpServer = Config.GetConfigValue("MailServer")
                SmtpMail.Send(mail)
            End If
            'Dim mail As New MailMessage()
            'mail.To = "akkarawat@scoresolutions.co.th"
            'mail.Cc = "akkarawatp@yahoo.com"
            'mail.Headers.Add("Reply-To", txtSendBackMail.Text)
            'mail.From = "pichit_k@muangthai.co.th"
            'mail.Subject = "Test From MTL"
            'mail.BodyFormat = MailFormat.Text
            'mail.Body = txtDescription.Text
            'SmtpMail.SmtpServer = "10.1.0.10"
            'SmtpMail.Send(mail)
        Catch ex As HttpException
            ret = False
            LogENG.SaveErrorLog(ex.Message, Config.GetLogOnUser)
            'Config.SetAlert(ex.Message, Me)
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
        Catch ex As Exception
            ret = False
            LogENG.SaveErrorLog(ex.Message, Config.GetLogOnUser)
            'Config.SetAlert(ex.Message, Me)
            Config.SetAlert("การเชื่อมต่อขัดข้อง กรุณาเรียกดูข้อมูลใหม่อีกครั้งหรือติดต่อเจ้าหน้าที่ (Connection failed; Please try again or contact our staff.)", Me)
        End Try

        Return ret
    End Function

    Private Function CreateMailSubject() As String
        Dim ret As String = ""
        'Sample Subject    ## WEB Q&A  ชื่อบริษัท : Group Account : Account Code
        Dim oup As OutputGetUserJoinCasePara = Session(Constant.UserJoinCaseSession)
        If oup.OUT_CASE_LIST IsNot Nothing Then
            Dim dt As DataTable = oup.OUT_CASE_LIST
            dt.DefaultView.RowFilter = "account_code = '" & cmbAccountCode.SelectedValue & "'"
            Dim grpCode As String = ""
            If dt.DefaultView.Count > 0 Then
                grpCode = dt.DefaultView.Item(0)("grp_code").ToString()
            End If

            ret += "WEB Q&A "
            ret += cmbAccountCode.SelectedText + " : "
            ret += grpCode + " : "
            ret += cmbAccountCode.SelectedValue
        End If
        Return ret
    End Function

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.Click
        SetDefault()
    End Sub
End Class
