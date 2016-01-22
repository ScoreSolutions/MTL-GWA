'Imports Func.Common
Imports Para.Common
Imports LinqDB.TABLE
Imports Para.TABLE
Imports System.Web

Namespace Common
    Public Class LogENG
        Dim _LOGIN_HISTORY_ID As Long
        Dim _err As String = ""

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

        Public Sub SaveLoginHistory(ByVal uData As UsersPara, ByVal req As HttpRequest)
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Try
                Dim lnq As New LoginHistoryLinqDB
                lnq.USER_ID = uData.USER_ID
                lnq.USER_NAME_T = uData.USER_NAME_T
                lnq.USER_NAME_E = uData.USER_NAME_E
                lnq.BROKER_CODE = uData.BROKER_CODE
                lnq.COMPANY_NAME = uData.COMPANY_NAME
                lnq.LOGIN_TIME = DateTime.Now

                Dim browser As String = " Type:" + req.Browser.Type + " Version:" + req.Browser.Version + " Browser:" + req.Browser.Browser
                lnq.IP_ADDRESS = req.UserHostAddress 'Get Client IP ADDRESS
                lnq.BROWSER = browser
                lnq.SESSION_ID = HttpContext.Current.Session.SessionID

                Dim ret As Boolean = lnq.InsertData(lnq.USER_ID, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                    _LOGIN_HISTORY_ID = lnq.ID
                Else
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                End If

            Catch ex As Exception
                trans.RollbackTransaction()
                _err = ex.Message
            End Try
        End Sub

        Public Shared Sub SaveTransLog(ByVal TransDesc As String, ByVal lSess As UserProfilePara)
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Try
                Dim lnq As New LogTransLinqDB
                lnq.LOGIN_HIS_ID = lSess.LOGIN_HISTORY_ID
                lnq.TRANS_DATE = DateTime.Now
                lnq.TRANS_DESC = TransDesc

                If lnq.InsertData(lSess.USER_PARA.USER_ID, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    SaveErrorLog(lnq.ErrorMessage, lSess)
                End If
            Catch ex As Exception
                trans.RollbackTransaction()
                SaveErrorLog(ex.Message, lSess)
            End Try
        End Sub

        Public Shared Sub SaveErrorLog(ByVal ErrDesc As String, ByVal lSess As UserProfilePara)
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Try
                Dim lnq As New LogErrorLinqDB
                lnq.LOGIN_HIS_ID = lSess.LOGIN_HISTORY_ID
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = ErrDesc

                If lnq.InsertData(lSess.USER_PARA.USER_ID, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Catch ex As Exception
                trans.RollbackTransaction()
            End Try
        End Sub

        Public Function SaveLogout(ByVal uSess As UserProfilePara) As Boolean
            Dim ret As Boolean = False
            Dim trans As New DbTrans
            trans.CreateTransaction()
            Dim lnq As New LoginHistoryLinqDB
            lnq.GetDataByPK(uSess.LOGIN_HISTORY_ID, trans.Trans)
            lnq.LOGOUT_TIME = DateTime.Now

            If lnq.UpdateByPK(uSess.USER_ID, trans.Trans) = True Then
                ret = True
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function
    End Class

End Namespace