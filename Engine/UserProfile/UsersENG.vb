Imports Para.TABLE
Imports LinqDB.TABLE
Imports Para.CallWS
Imports Para.OutputWS
Imports Engine.Common
Imports LinqWS
Imports Para.Common.Utilities

Namespace UserProfile
    Public Class UsersENG
        Dim _err As String = ""
        Dim _user_id As String = ""
        Dim _id As Long
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property USER_ID() As String
            Get
                Return _user_id
            End Get
        End Property
        Public ReadOnly Property ID() As String
            Get
                Return _id
            End Get
        End Property

        'Public Function SaveUsers(ByVal UserID As String, ByVal para As InputInsertUserProfilePara) As Boolean
        '    Dim output As OutputInsertUserProfilePara
        '    Dim ws As New WebGroupLinqWS
        '    output = ws.InsertUserProfile(para)
        '    Return (output.ACK = "Y")
        'End Function

        Public Function ChangePassword(ByVal UserID As String, ByVal para As UsersPara, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New UsersLinqDB
            ret = lnq.ChkDataByUSER_ID(UserID, trans.Trans)
            Dim old_passwd As String = lnq.USER_PASSWD
            If ret = True Then
                lnq.USER_PASSWD = para.USER_PASSWD

                lnq.PASSWD_DATE = para.PASSWD_DATE
                If para.PASSWD_DATE > lnq.USER_E_DATE Then
                    lnq.PASSWD_DATE = lnq.USER_E_DATE
                End If

                lnq.LOGIN_FAIL_COUNT = para.LOGIN_FAIL_COUNT
                lnq.IS_FIRST_LOGIN = para.IS_FIRST_LOGIN

                ret = lnq.UpdateByPK(UserID, trans.Trans)
                If ret = True Then
                    Dim hlnq As New UsersPwdChangeHistoryLinqDB
                    hlnq.USER_ID = UserID
                    hlnq.OLD_PASSWORD = old_passwd
                    hlnq.NEW_PASSWORD = para.USER_PASSWD
                    hlnq.CHANGE_DATE = DateTime.Now

                    ret = hlnq.InsertData(UserID, trans.Trans)
                    If ret = False Then
                        _err = hlnq.ErrorMessage
                    Else
                        Dim inp As New InputChangePasswordPara
                        inp.INPUT_PERSON = UserID
                        inp.USER_ID = UserID
                        inp.USER_PASSWORD = ConfigENG.DeCripPwd(para.USER_PASSWD)
                        inp.PASS_DATE = para.PASSWD_DATE.ToString("MM/dd") & "/" & DateTime.Now.Year
                        inp.MNT_DTTM = DateTime.Now.Year & "-" & DateTime.Now.ToString("MM-dd hh:mm:ss")

                        Dim ws As New WebGroupLinqWS
                        ret = ws.ChangePassword(inp)
                        If ret = False Then
                            _err = ws.ErrorMessage
                        End If
                    End If
                Else
                    _err = lnq.ErrorMessage
                End If
            Else
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SaveUsers(ByVal UserID As String, ByVal para As UsersPara, ByVal trans As DbTrans, ByVal IsChangePwd As Boolean) As Boolean
            Dim ret As Boolean = False
            'บันทึกลงฐานข้อมูล
            Dim lnq As New UsersLinqDB
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)

                If ConfigENG.DeCripPwd(para.USER_PASSWD) <> "" Then  'ถ้าเป็นกรณีแก้ไข แล้วมีการกำหนดรหัสผ่านใหม่
                    lnq.USER_PASSWD = para.USER_PASSWD
                End If
            Else
                lnq.USER_PASSWD = para.USER_PASSWD
            End If

            lnq.USER_ID = para.USER_ID
            lnq.USER_S_DATE = para.USER_S_DATE
            lnq.USER_E_DATE = para.USER_E_DATE
            lnq.PASSWD_DATE = para.PASSWD_DATE
            lnq.USER_TYPE = para.USER_TYPE
            lnq.BROKER_CODE = para.BROKER_CODE
            lnq.AC_CODE = para.AC_CODE
            lnq.USER_NAME_T = para.USER_NAME_T
            lnq.USER_NAME_E = para.USER_NAME_E
            lnq.COMPANY_NAME = para.COMPANY_NAME
            lnq.USER_EMAIL = para.USER_EMAIL
            lnq.USER_TEL = para.USER_TEL
            lnq.USER_LEVEL = para.USER_LEVEL
            lnq.DISC_REASON = para.DISC_REASON
            lnq.MARKET_EMAIL = para.MARKET_EMAIL
            lnq.MARKET_CC_EMAIL = para.MARKET_CC_EMAIL
            lnq.CLAIM_EMAIL = para.CLAIM_EMAIL
            lnq.CLAIM_CC_EMAIL = para.CLAIM_CC_EMAIL
            lnq.INPUT_PERSON = para.INPUT_PERSON
            lnq.CREATE_DTTM = para.CREATE_DTTM
            lnq.MNT_DTTM = para.MNT_DTTM
            lnq.IS_FIRST_LOGIN = para.IS_FIRST_LOGIN
            lnq.LOGIN_FAIL_COUNT = para.LOGIN_FAIL_COUNT

            If lnq.ID <> 0 Then
                If IsChangePwd = False Then
                    lnq.IS_FIRST_LOGIN = "N"
                End If
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = True Then
                _user_id = lnq.USER_ID
                _id = lnq.ID

                'บันทึกลงใน WS
                Dim ws As New WebGroupLinqWS
                para.USER_PASSWD = ConfigENG.DeCripPwd(para.USER_PASSWD)

                If para.ID <> 0 Then
                    Dim output As OutputUpdateUserProfilePara = ws.UpdateUserProfile(para)
                    ret = (output.ACK = "Y")
                    If ret = False Then
                        _err = ws.ErrorMessage
                    End If
                Else
                    Dim output As OutputInsertUserProfilePara = ws.InsertUserProfile(para)
                    ret = (output.ACK = "Y")
                    If ret = False Then
                        _err = ws.ErrorMessage
                    End If
                End If

                If para.ID <> 0 Then 'กรณี Update
                    If IsChangePwd = True Then
                        If ret = True Then
                            If para.USER_PASSWD <> "" Then  'ถ้าเป็นกรณีแก้ไข แล้วมีการกำหนดรหัสผ่านใหม่ ให้เปลี่ยนรหัสผ่านโดย Call WebService
                                Dim parP As New InputChangePasswordPara
                                parP.INPUT_PERSON = para.INPUT_PERSON
                                parP.MNT_DTTM = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US"))
                                parP.PASS_DATE = para.PASSWD_DATE.ToString("MM/dd/yyyy", New Globalization.CultureInfo("en-US"))
                                parP.USER_ID = para.USER_ID
                                parP.USER_PASSWORD = para.USER_PASSWD
                                ret = ws.ChangePassword(parP)
                                If ret = True Then
                                    _user_id = ws.USER_ID
                                Else
                                    _err = ws.ErrorMessage
                                End If
                            End If
                        Else
                            _err = ws.ErrorMessage
                        End If
                    End If
                End If
            Else
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SaveUsersResponseCompany(ByVal UserID As String, ByVal para As UsersResponseCompanyPara, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New UsersResponseCompanyLinqDB
            If para.ID <> 0 Then
                lnq.ChkDataByPK(para.ID, trans.Trans)
            End If
            lnq.USER_ID = para.USER_ID
            lnq.GRP_CODE = para.GRP_CODE
            lnq.AC_CODE = para.AC_CODE
            lnq.AC_NAME = para.AC_NAME
            lnq.POL_YEAR = para.POL_YEAR
            lnq.POL_NO = para.POL_NO
            lnq.USER_GPO_ID = para.USER_GPO_ID
            lnq.LANGUAGE = para.LANGUAGE
            lnq.INPUT_PERSON = para.INPUT_PERSON
            lnq.CREATE_DTTM = para.CREATE_DTTM
            lnq.MNT_DTTM = para.MNT_DTTM
            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If
            If ret = True Then
                'บันทึกลง WS
                Dim ws As New WebGroupLinqWS
                ret = ws.InsertUserProfileDetail(para)
                If ret = False Then
                    _err = ws.ErrorMessage
                End If
            Else
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function ChkDupUsersResponseCompany(ByVal vID As Long, ByVal UserID As String, ByVal AcCode As String, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New UsersResponseCompanyLinqDB
            ret = lnq.ChkDataByWhere("user_id = '" & UserID & "' and ac_code = '" & AcCode & "' and id <> " & vID, trans.Trans)

            Return ret
        End Function

        
        Public Function GetUserProfileDetailList(ByVal UserID As String) As DataTable
            Dim trans As New DbTrans
            trans.CreateTransaction()

            Dim lnq As New UsersResponseCompanyLinqDB
            Dim dt As DataTable = lnq.GetDataList("user_id = '" & UserID & "'", "grp_code, ac_code", trans.Trans)
            trans.CommitTransaction()
            Return dt

        End Function
        'Public Function GetUserProfileDetailAllList() As DataTable
        '    Dim trans As New DbTrans
        '    trans.CreateTransaction()

        '    Dim lnq As New UsersResponseCompanyLinqDB
        '    Dim dt As DataTable = lnq.GetDataList("", "grp_code, ac_code", trans.Trans)
        '    trans.CommitTransaction()
        '    Return dt

        'End Function

        'Public Sub InitielAccName()
        '    Dim dt As DataTable = GetUserProfileDetailAllList()
        '    If dt.Rows.Count > 0 Then
        '        For Each dr As DataRow In dt.Rows
        '            Dim trans As New Common.DbTrans
        '            trans.CreateTransaction()

        '            Dim lnq As New UsersResponseCompanyLinqDB
        '            lnq.GetDataByPK(dr("id"), trans.Trans)
        '            Dim ret As Boolean = False
        '            If lnq.ID <> 0 Then
        '                Dim ws As New WebServiceENG
        '                Dim AcName As String = ws.GetAccountNameWS(dr("ac_code").ToString, dr("language").ToString)
        '                If AcName.Trim.Trim <> "" Then
        '                    lnq.AC_NAME = AcName
        '                    ret = lnq.UpdateByPK(lnq.CREATE_BY, trans.Trans)
        '                    If ret = True Then
        '                        trans.CommitTransaction()
        '                    Else
        '                        trans.RollbackTransaction()
        '                    End If
        '                End If
        '            End If
        '        Next
        '    End If
        'End Sub

        Public Function GetUserProfileDetailByID(ByVal vID As Long) As UsersResponseCompanyPara
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersResponseCompanyLinqDB
            Dim para As UsersResponseCompanyPara = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()

            Return para
        End Function

        Public Function DeleteUserProfile(ByVal vID As Long) As Boolean
            Dim ret As Boolean = True
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersLinqDB
            lnq.GetDataByPK(vID, trans.Trans)

            If ChkUsersReference(lnq.USER_ID, trans) = False Then
                ret = lnq.DeleteByPK(vID, trans.Trans)
                If ret = False Then
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                Else
                    Dim para As New InputDeleteUserProfilePara
                    para.USER_ID = lnq.USER_ID

                    Dim ws As New WebGroupLinqWS
                    ret = ws.DeleteUserProfile(para)
                    If ret = False Then
                        trans.RollbackTransaction()
                        _err = ws.ErrorMessage
                    Else
                        trans.CommitTransaction()
                    End If
                End If
            Else
                trans.RollbackTransaction()
                ret = False
                '_err = "ไม่สามารถลบผู้ใช้งานระบบได้ เนื่องจากมีบริษัทที่รับผิดชอบอยู่"
                'เปลี่ยนกลับเป็นเหมือนเดิม 2012-07-05
                _err = "ข้อมูลผู้ใช้ได้ถูกนำไปใช้งานแล้ว ไม่สามารถลบข้อมูลได้"
            End If

            Return ret
        End Function

        Private Function ChkUsersReference(ByVal UserID As String, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = False

            Dim lcLnq As New ClaimAttachFileLinqDB
            If lcLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                ret = True
            Else
                Dim ltLnq As New ContactUsLinqDB
                If ltLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                    ret = True
                Else
                    Dim dlLnq As New DownloadLinqDB
                    If dlLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                        ret = True
                    Else
                        Dim dtLnq As New DownloadTypeLinqDB
                        If ltLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                            ret = True
                        Else
                            Dim fLnq As New FaqLinqDB
                            If fLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                ret = True
                            Else
                                Dim ffLnq As New FaqFileLinqDB
                                If ffLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                    ret = True
                                Else
                                    Dim fkLnq As New FaqKeywordLinqDB
                                    If fkLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                        ret = True
                                    Else
                                        Dim leLnq As New LogErrorLinqDB
                                        If leLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                            ret = True
                                        Else
                                            Dim lrLnq As New LogTransLinqDB
                                            If lrLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                ret = True
                                            Else
                                                Dim liLnq As New LoginHistoryLinqDB
                                                If liLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "' or user_id ='" & UserID & "'", trans.Trans) = True Then
                                                    ret = True
                                                Else
                                                    Dim meLnq As New MenuLinqDB
                                                    If meLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                        ret = True
                                                    Else
                                                        Dim mLnq As New ModuleLinqDB
                                                        If mLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                            ret = True
                                                        Else
                                                            Dim psLnq As New PolicyServiceTypeLinqDB
                                                            If psLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                                ret = True
                                                            Else
                                                                Dim rcLnq As New RoleScreenLinqDB
                                                                If rcLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                                    ret = True
                                                                Else
                                                                    Dim sLnq As New ScreenLinqDB
                                                                    If sLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "'", trans.Trans) = True Then
                                                                        ret = True
                                                                    Else
                                                                        Dim uLnq As New UsersLinqDB
                                                                        If uLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "' or input_person = '" & UserID & "'", trans.Trans) = True Then
                                                                            ret = True
                                                                        Else
                                                                            Dim ucLnq As New UsersResponseCompanyLinqDB
                                                                            If ucLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "' or user_id = '" & UserID & "'", trans.Trans) = True Then
                                                                                ret = True
                                                                            Else
                                                                                Dim upLnq As New UsersPwdChangeHistoryLinqDB
                                                                                If upLnq.ChkDataByWhere("create_by = '" & UserID & "' or update_by = '" & UserID & "' or user_id = '" & UserID & "'", trans.Trans) = True Then
                                                                                    ret = True
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Return ret
        End Function

        Public Function DeleteProfileDetail(ByVal vID As Long) As Boolean
            Dim ret As Boolean = True

            'ลบข้อมูลใน WS ก่อน
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersResponseCompanyLinqDB
            lnq.GetDataByPK(vID, trans.Trans)

            Dim inp As New Para.CallWS.InputDeleteUserProfileDetailPara
            inp.GROUP_CODE = lnq.GRP_CODE
            inp.AC_CODE = lnq.AC_CODE
            inp.USER_ID = lnq.USER_ID

            Dim ws As New WebGroupLinqWS
            ret = ws.DeleteUserProfileDetail(inp)
            If ret = False Then
                _err = ws.ErrorMessage
            Else
                'ลบข้อมูลใน Table
                ret = lnq.DeleteByPK(vID, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    _err = lnq.ErrorMessage
                    trans.RollbackTransaction()
                End If
            End If

            Return ret

        End Function

        Public Function CheckPassword(ByVal UserID As String, ByVal UserPWD As String) As Boolean
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim ret As Boolean = False
            Dim lnq As New UsersLinqDB
            If lnq.ChkDataByUSER_ID(UserID, trans.Trans) = True Then
                ret = (lnq.USER_PASSWD = UserPWD)
                trans.CommitTransaction()
            Else
                ret = False
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function GetProfileByUserID(ByVal UserID As String) As UsersPara
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim ret As UsersPara = Nothing
            Dim lnq As New UsersLinqDB
            If (lnq.ChkDataByUSER_ID(UserID, trans.Trans)) = True Then
                ret = lnq.GetParameter(lnq.ID, trans.Trans)
                trans.CommitTransaction()
            Else
                _err = lnq.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function GetProfileByID(ByVal vID As Long) As UsersPara
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim ret As UsersPara = Nothing
            Dim lnq As New UsersLinqDB
            lnq.GetDataByPK(vID, trans.Trans)
            If lnq.HaveData = True Then
                ret = lnq.GetParameter(lnq.ID, trans.Trans)
                trans.CommitTransaction()
            Else
                _err = lnq.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function ChkDupUserID(ByVal UserID As String, ByVal vID As Long) As Boolean
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim ret As Boolean = False
            Dim lnq As New UsersLinqDB
            ret = lnq.ChkDuplicateByUSER_ID(UserID, vID, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = lnq.ErrorMessage
                trans.RollbackTransaction()
            End If
            Return ret
        End Function

        Public Function CheckPasswordHistory(ByVal UserID As String, ByVal NewPasswd As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersPwdChangeHistoryLinqDB
            Dim sql As String = " select top " & ConfigENG.GetConfigValue(Constant.SystemConfig.PwdHisLimit) & " id, new_password "
            sql += " from users_pwd_change_history "
            sql += " where user_id = '" & UserID & "' "
            sql += " order by change_date desc "
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)

            dt.DefaultView.RowFilter = " new_password = '" & NewPasswd & "'"
            If dt.DefaultView.Count > 0 Then
                ret = True
            Else
                ret = False
            End If

            Return ret
        End Function

        Public Function SearchUsers(ByVal UserID As String, ByVal UserType As String, ByVal BrokerCode As String, ByVal AccountCode As String, ByVal UserNameThai As String, ByVal UserNameEng As String) As DataTable
            Dim sql As String = " id <> 1 "
            If UserID.Trim <> "" Then
                sql += " and user_id like '%" & UserID & "%' "
            End If
            If UserType <> "0" Then
                sql += " and user_type = '" & UserType & "' "
            End If
            If BrokerCode.Trim <> "" Then
                sql += " and broker_code like '%" & BrokerCode & "%' "
            End If
            If AccountCode.Trim <> "" Then
                sql += " and ac_code like '%" & AccountCode & "%' "
            End If
            If UserNameThai.Trim <> "" Then
                sql += " and user_name_t like '%" & UserNameThai & "%' "
            End If
            If UserNameEng.Trim <> "" Then
                sql += " and user_name_e like '%" & UserNameEng & "%' "
            End If

            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New UsersLinqDB
            Dim dt As DataTable = lnq.GetDataList(sql, "user_id", trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function
    End Class
End Namespace

