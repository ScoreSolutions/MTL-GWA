Imports Para.CallWS
Imports Para.OutputWS
Imports Para.TABLE
Imports Para.Common
Imports Para.Common.Utilities
Imports LinqDB.TABLE
Imports LinqDB.VIEW
Imports LinqWS
Imports System.Web
Imports Engine.Common

Namespace Auth
    Public Class LogInENG
        Dim _uPara As UsersPara
        Dim _LOGIN_HISTORY_ID As Long
        Dim _err As String
        Dim _userEmail As String

        Public ReadOnly Property UserProfilePara() As UsersPara
            Get
                Return _uPara
            End Get
        End Property
        Public ReadOnly Property LOGIN_HISTORY_ID() As Long
            Get
                Return _LOGIN_HISTORY_ID
            End Get
        End Property
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property USER_EMAIL() As String
            Get
                Return _userEmail
            End Get
        End Property

        Public Function ChkLogin(ByVal inputPara As InputGetUserProfilePara) As Boolean
            Dim lnq As New LinqWS.WebGroupLinqWS
            Return (lnq.GetUserProfile(inputPara) IsNot Nothing)
        End Function

        Public Function ChkLogin(ByVal userID As String, ByVal pwd As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersLinqDB
            If lnq.ChkDataByUSER_ID(userID, trans.Trans) = True Then
                'If lnq.USER_PASSWD = pwd Then
                If lnq.USER_PASSWD = Common.ConfigENG.EnCripPwd(pwd) Then
                    Dim pLnq As New RoleScreenLinqDB
                    If pLnq.ChkDataByWhere("user_type = '" & lnq.USER_TYPE & "'", trans.Trans) = True Then
                        If pLnq.ChkDataByWhere("user_type = '" & lnq.USER_TYPE & "' and module_id = '" & ConfigENG.GetConfigValue(Constant.SystemConfig.FirstPageModuleID) & "' and menu_id is null", trans.Trans) = True Then
                            If lnq.LOGIN_FAIL_COUNT >= ConfigENG.GetConfigValue(Constant.SystemConfig.LoginFailLimit) Then
                                _err = "รหัสผ่านของท่านถูกระงับการใช้งาน กรุณาติดต่อเจ้าหน้าที่"
                                trans.RollbackTransaction()
                            Else
                                ret = True
                                _uPara = lnq.GetParameter(lnq.ID, trans.Trans)
                                trans.CommitTransaction()
                            End If
                        Else
                            _err = "ผู้ใช้ยังไม่ได้รับการกำหนดสิทธิ์การใช้งาน (User ID not have permission)"
                            trans.RollbackTransaction()
                        End If
                    Else
                        _err = "ผู้ใช้ยังไม่ได้รับการกำหนดสิทธิ์การใช้งาน (User ID not have permission)"
                        trans.RollbackTransaction()
                    End If
                Else
                    _err = "รหัสผ่านไม่ถูกต้อง (Incorrect Password)"
                    lnq.LOGIN_FAIL_COUNT += 1
                    If lnq.UpdateByPK(userID, trans.Trans) = False Then
                        _err = lnq.ErrorMessage
                        trans.RollbackTransaction()
                    Else
                        If SetWsLoginFailCount(userID) = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    End If

                    If lnq.LOGIN_FAIL_COUNT > ConfigENG.GetConfigValue(Constant.SystemConfig.LoginFailLimit) Then
                        _err = "รหัสผ่านของท่านถูกระงับการใช้งาน กรุณาติดต่อเจ้าหน้าที่"
                    End If
                End If

                

            Else
                _err = "User ID ไม่ถูกต้อง (Incorrect User ID)"
                trans.RollbackTransaction()
            End If


            'Dim inp As New InputGetUserProfilePara
            'inp.USER_ID = userID
            'inp.USER_PASSWD = pwd
            'Dim engWS As New WebServiceENG
            'Dim oup As OutputGetUserProfilePara = engWS.GetUserProfile(inp)
            'If oup.ISFOUND = "Y" Then
            '    ret = UpdateUserProfile(userID, pwd, oup)
            'Else
            '    _err = engWS.ErrorMessage
            'End If

            Return ret
        End Function

        Public Function ChkForgotPassword(ByVal UserID As String, ByVal UserEMail As String) As Boolean
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim ret As Boolean = False

            Dim lnq As New UsersLinqDB
            ret = lnq.ChkDataByUSER_ID(UserID, trans.Trans)
            If ret = True Then
                If lnq.USER_EMAIL = UserEMail Then
                    ret = True
                    _userEmail = lnq.USER_EMAIL
                    _uPara = lnq.GetParameter(lnq.ID, trans.Trans)
                    trans.CommitTransaction()
                Else
                    ret = False
                    _err = "อีเมล์ของท่านไม่ถูกต้อง (Incorrect E-Mail)"
                End If
            Else
                ret = False
                trans.RollbackTransaction()
                _err = "ชื่อผู้ใช้ของท่านไม่ถูกต้อง (Incorrect User ID)"
            End If

            Return ret
        End Function


        Private Function SetWsLoginFailCount(ByVal UserID As String) As Boolean
            Return True

        End Function

        Private Function UpdateUserProfile(ByVal userId As String, ByVal pwd As String, ByVal output As OutputGetUserProfilePara) As Boolean
            Dim ret As Boolean = False
            Dim trans As New DbTrans
            trans.CreateTransaction()

            'ถ้ามีข้อมูลใน WS ให้เอาข้อมูลมาอัพเดทใน Table เลย
            Dim lnq As New UsersLinqDB
            lnq.ChkDataByUSER_ID(userId, trans.Trans)

            lnq.USER_S_DATE = ConfigENG.ConvertDateFromWS(output.USER_S_DATE)
            lnq.USER_E_DATE = ConfigENG.ConvertDateFromWS(output.USER_E_DATE)
            lnq.PASSWD_DATE = ConfigENG.ConvertDateFromWS(output.PASSWD_DATE)
            lnq.USER_TYPE = output.USER_TYPE
            lnq.BROKER_CODE = output.BROKER_CODE
            lnq.AC_CODE = output.AC_CODE
            lnq.USER_NAME_T = output.USER_NAME_T
            lnq.USER_NAME_E = output.USER_NAME_E
            lnq.COMPANY_NAME = output.COMPANY_NAME
            lnq.USER_EMAIL = output.USER_EMAIL
            lnq.USER_TEL = output.USER_TEL
            lnq.USER_LEVEL = output.USER_LEVEL
            lnq.DISC_REASON = output.DISC_REASON
            lnq.MARKET_EMAIL = output.MARKET_EMAIL
            lnq.MARKET_CC_EMAIL = output.MARKET_CC_EMAIL
            lnq.CLAIM_EMAIL = output.CLAIM_EMAIL
            lnq.CLAIM_CC_EMAIL = output.CLAIM_CC_EMAIL
            lnq.INPUT_PERSON = output.INPUT_PERSON
            lnq.MNT_DTTM = ConfigENG.ConvertDTTM(output.MNT_DTTM)
            lnq.IS_FIRST_LOGIN = "Y" 'IIf(output.IS_FIRST_LOGIN = """", "Y", output.IS_FIRST_LOGIN)
            lnq.LOGIN_FAIL_COUNT = 0 'IIf(output.LOGIN_FAIL_COUNT = """", 0, output.LOGIN_FAIL_COUNT)

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(lnq.USER_ID, trans.Trans)
            Else
                lnq.USER_ID = userId
                lnq.USER_PASSWD = ConfigENG.EnCripPwd(pwd)
                lnq.CREATE_DTTM = DateTime.Now
                lnq.LAST_LOGIN_TIME = DateTime.Now

                ret = lnq.InsertData(userId, trans.Trans)
            End If

            If ret = True Then
                _uPara = lnq.GetParameter(lnq.ID, trans.Trans)
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SetLoginSuccess(ByVal userID As String, ByVal vID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()

            Dim lnq As New UsersLinqDB
            lnq.GetDataByPK(vID, trans.Trans)
            If lnq.HaveData = True Then
                lnq.LAST_LOGIN_TIME = DateTime.Now
                lnq.LOGIN_FAIL_COUNT = 0
                ret = lnq.UpdateByPK(userID, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                End If
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function GetUsersPara(ByVal vID As Long, ByVal trans As Common.DbTrans) As UsersPara
            Dim lnq As New UsersLinqDB
            Return lnq.GetParameter(vID, trans.Trans)
        End Function

        Public Function GetMenuList(ByVal whText As String, ByVal trans As DbTrans) As DataTable
            Dim sql As String = ""
            sql += " select ml.* "
            sql += " from ROLE_SCREEN rs "
            sql += " left join v_menu_list ml on ml.menu_id=rs.menu_id and ml.module_id=rs.module_id "
            sql += " where " & whText
            sql += " order by ml.menu_order_seq "

            Dim mdl As New RoleScreenLinqDB
            'Return mdl.GetDataList(whText, "order_seq", trans.Trans)
            Return mdl.GetListBySql(sql, trans.Trans)
        End Function
        Public Function GetModuleList(ByVal whText As String, ByVal trans As DbTrans) As DataTable
            Dim sql As String = ""
            sql += " select distinct m.* "
            sql += " from module m"
            sql += " inner join role_screen rs on rs.module_id=m.id "
            sql += " where " & whText
            sql += " order by m.order_seq"

            Dim mdl As New ModuleLinqDB
            'Return mdl.GetDataList(whText, "order_seq", trans.Trans)
            Return mdl.GetListBySql(sql, trans.Trans)
        End Function

        Public Function GetScreenList(ByVal whText As String, ByVal trans As DbTrans) As DataTable
            Dim sLnq As New ScreenLinqDB
            Return sLnq.GetDataList(whText, "", trans.Trans)
        End Function
    End Class
End Namespace

