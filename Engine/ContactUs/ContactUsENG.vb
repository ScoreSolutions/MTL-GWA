Imports Engine.Common
Imports Para.TABLE
Imports LinqDB.TABLE
Imports Para.CallWS
Imports Para.OutputWS
Imports LinqWS

Namespace ContactUs
    Public Class ContactUsENG
        Dim _err As String = ""
        Dim _ContactUsID As Long = 0

        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ContactUsID() As Long
            Get
                Return _ContactUsID
            End Get
        End Property

        Public Function GetMenuParameter(ByVal vMenuID As Long, ByVal trans As DbTrans) As Para.TABLE.MenuPara
            Dim lnq As New MenuLinqDB
            Return lnq.GetParameter(vMenuID, trans.Trans)
        End Function

        Public Function SaveContactUS(ByVal UserID As String, ByVal para As ContactUsPara, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New ContactUsLinqDB
            If para.ID <> 0 Then
                lnq.GetParameter(para.ID, trans.Trans)
            End If
            lnq.MENU_ID = para.MENU_ID
            lnq.ACCOUNT_CODE = para.ACCOUNT_CODE
            lnq.DESCRIPTION = para.DESCRIPTION
            lnq.REPLY_MAIL = para.REPLY_MAIL
            lnq.SEND_TYPE = para.SEND_TYPE

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If
            If ret = False Then
                _err = lnq.ErrorMessage
            Else
                _ContactUsID = lnq.ID
            End If

            Return ret
        End Function

        Public Function GetContactName(ByVal para As InputGetContractNamePara) As OutputGetContractNamePara
            Dim ws As New WebGroupLinqWS
            Dim oup As OutputGetContractNamePara = ws.GetContractName(para)
            If oup.ISFOUND = "N" Then
                _err = ws.ErrorMessage
            End If

            Return oup
        End Function


        Public Function GetUserJoinCase(ByVal para As InputGetUserJoinCasePara) As DataTable
            Dim ws As New LinqWS.WebGroupLinqWS
            Dim output As New OutputGetUserJoinCasePara
            output = ws.GetUserJoinCase(para)
            Dim dt As DataTable
            If output.OUT_CASE_LIST IsNot Nothing Then
                dt = output.OUT_CASE_LIST
            End If

            Return dt
        End Function
    End Class
End Namespace

