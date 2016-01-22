Imports LinqDB.TABLE
Imports Para.TABLE
Imports System.IO
Imports Para.Common.Utilities

Namespace FAQ
    Public Class FAQFormENG
        Dim _err As String = ""
        Dim _FAQ_ID As Long = 0
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property FAQ_ID() As Long
            Get
                Return _FAQ_ID
            End Get
        End Property


        Public Function GetServiceTypeList() As DataTable
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New PolicyServiceTypeLinqDB
            Dim dt As DataTable = lnq.GetDataList("1=1", "order_seq", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function SaveFAQ(ByVal UserID As String, ByVal para As FaqPara, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = True
            Dim lnq As New FaqLinqDB
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.POLICY_SERVICE_TYPE_ID = para.POLICY_SERVICE_TYPE_ID
            lnq.QUESTION = para.QUESTION
            lnq.QUESTION_DATE = para.QUESTION_DATE
            lnq.ANSWER = para.ANSWER
            lnq.ORDER_SEQ = para.ORDER_SEQ
            lnq.ACTIVE = para.ACTIVE

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If
            If ret = True Then
                _FAQ_ID = lnq.ID
            Else
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SaveAttachFile(ByVal FaqID As Long, ByVal UserID As String, ByVal dt As DataTable, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = True
            If dt IsNot Nothing Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New FaqFileLinqDB
                    Dim para As New FaqFilePara
                    If dr("id") <> 0 Then
                        para = lnq.GetParameter(dr("id"), trans.Trans)
                        lnq.GetDataByPK(dr("id"), trans.Trans)
                    End If
                    lnq.FAQ_ID = FaqID
                    lnq.IMPORT_DATE = dr("import_date")
                    lnq.FILE_DESC = dr("file_desc")
                    lnq.FILE_EXT = dr("file_ext")
                    lnq.ORDER_SEQ = dr("order_seq")
                    lnq.ACTIVE = dr("active")

                    If dr("id") <> 0 Then
                        ret = lnq.UpdateByPK(UserID, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserID, trans.Trans)
                    End If

                    If ret = False Then
                        _err = lnq.ErrorMessage
                        Exit For
                    Else
                        'ลบไฟล์ที่มีอยู่เดิมออกก่อน
                        If File.Exists(Common.ConfigENG.GetUploadPath & Constant.FilePrefix.FAQ & lnq.ID & para.FILE_EXT) Then
                            File.Delete(Common.ConfigENG.GetUploadPath & Constant.FilePrefix.FAQ & lnq.ID & para.FILE_EXT)
                        End If

                        Dim tmpFile As Para.Common.TmpFileUploadPara = dr("TmpFileUploadPara")
                        File.WriteAllBytes(Common.ConfigENG.GetUploadPath & Constant.FilePrefix.FAQ & lnq.ID & lnq.FILE_EXT, tmpFile.TmpFileByte)
                    End If
                Next
            End If

            Return ret
        End Function

        Public Function SaveKeyword(ByVal FaqID As Long, ByVal UserID As String, ByVal dt As DataTable, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = True
            If dt IsNot Nothing Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New FaqKeywordLinqDB
                    If dr("id") <> 0 Then
                        lnq.GetDataByPK(dr("id"), trans.Trans)
                    End If
                    lnq.FAQ_ID = FaqID
                    lnq.KEYWORD = dr("keyword")

                    If lnq.ID <> 0 Then
                        ret = lnq.UpdateByPK(UserID, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserID, trans.Trans)
                    End If
                    If ret = False Then
                        _err = lnq.ErrorMessage
                        Exit For
                    End If
                Next
            End If

            Return ret
        End Function

        Public Function GetFAQPara(ByVal vID As Long) As FaqPara
            Dim ret As FaqPara
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqLinqDB
            ret = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            Return ret
        End Function

        Public Function DeleteFile(ByVal vID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqFileLinqDB
            lnq.GetDataByPK(vID, trans.Trans)
            If lnq.ID <> 0 Then
                ret = lnq.DeleteByPK(vID, trans.Trans)
                If ret = True Then
                    File.Delete(Common.ConfigENG.GetUploadPath() & Constant.FilePrefix.FAQ & vID & lnq.FILE_EXT)
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
        Public Function DeleteKeyword(ByVal vID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqKeywordLinqDB
            ret = lnq.DeleteByPK(vID, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If
            Return ret
        End Function

        Public Function GetFAQPreviewList(ByVal vPolicyServiceTypeID As Long) As DataTable
            Dim dt As DataTable
            Dim lnq As New FaqLinqDB
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            'dt = lnq.GetDataList("policy_service_type_id = " & vPolicyServiceTypeID & " and active = 'Y'", "order_seq", trans.Trans)
            Dim sql As String = ""
            sql += " SELECT top 5 [id] ,[policy_service_type_id],[question_date],[question],[answer],[order_seq],[active]"
            sql += " FROM [FAQ] "
            sql += " where policy_service_type_id = " & vPolicyServiceTypeID & " and active = 'Y'"
            sql += " order by order_seq "
            dt = lnq.GetListBySql(sql, trans.Trans)

            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetFaqSearch(ByVal catID As Long, ByVal question As String, ByVal active As String) As DataTable
            Dim dt As DataTable
            Dim lnq As New FaqLinqDB
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()

            Dim sql As String = "select q.id,ps.policy_service_name question_category,q.question, "
            sql += " case when (select count(f.id) from faq_file f where f.faq_id=q.id)>0 then 'มี' else 'ไม่มี' end is_file, "
            sql += " q.question_date,q.order_seq, case when q.active='Y' then 'แสดง' else 'ไม่แสดง' end active_status "
            sql += " from faq q "
            sql += " inner join policy_service_type ps on ps.id=q.policy_service_type_id "
            sql += " where 1=1 "

            If active <> "" Then
                sql += " and q.active='Y' "
            End If
            If catID <> 0 Then
                sql += " and policy_service_type_id = " & catID
            End If
            If question.Trim <> "" Then
                sql += " and question like '%" & question & "%'"
                sql += " or ((select count(id) from faq_keyword where keyword like '%" & question & "%' and faq_id=q.id)>0)"
            End If
            sql += " order by ps.policy_service_name, q.order_seq "

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetFAQFile() As DataTable
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqFileLinqDB
            Dim dt As DataTable = lnq.GetDataList(" active = 'Y'", "order_seq, id", trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function SeperateOrderSeq(ByVal UserID As String, ByVal vServiceType As Long, ByVal NewSeq As Long, ByVal OldSeq As Long) As Boolean
            'เอาค่าที่กำลังจะบันทึกลงไปมาทำการแทรกก่อน
            Dim ret As Boolean = True
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()

            Dim lnq As New FaqLinqDB

            If NewSeq < OldSeq Or OldSeq = 0 Then
                If lnq.ChkDataByWhere("policy_service_type_id = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans) = True Then
                    ret = lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq + 1 where policy_service_type_id = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = lnq.ErrorMessage
                    End If
                End If
            Else
                If lnq.ChkDataByWhere("policy_service_type_id = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans) = True Then
                    ret = lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq - 1 where policy_service_type_id = " & vServiceType & " and order_seq = " & NewSeq, trans.Trans)
                    If ret = True Then
                        lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq + 1 where policy_service_type_id = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans)

                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = lnq.ErrorMessage
                    End If
                Else
                    'ถ้าไม่พบข้อมูลแสดงว่าลำดับใหม่ มีค่าเกินจากจำนวนรายการที่มี
                    ret = True
                End If
            End If
            Return ret
        End Function

        Public Function GetNextSeq(ByVal vServiceTypeID As String) As Long
            Dim ret As Long = 0
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqLinqDB
            Dim dt As DataTable = lnq.GetDataList("policy_service_type_id = " & vServiceTypeID, "order_seq desc", trans.Trans)
            trans.CommitTransaction()

            If dt.Rows.Count > 0 Then
                ret = Convert.ToInt64(dt.Rows(0)("order_seq")) + 1
            Else
                ret = 1
            End If

            Return ret
        End Function

        Public Function RunOrderSeq(ByVal UserID As String, ByVal vServiceType As Long) As Boolean
            Dim ret As Boolean = True
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqLinqDB
            Dim dt As DataTable = lnq.GetDataList("policy_service_type_id = " & vServiceType, "order_seq", trans.Trans)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lnq = New FaqLinqDB
                    lnq.GetDataByPK(dt.Rows(i)("id"), trans.Trans)
                    lnq.ORDER_SEQ = (i + 1)
                    ret = lnq.UpdateByPK(UserID, trans.Trans)
                    If ret = False Then
                        _err = lnq.ErrorMessage
                        Exit For
                    End If
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function ChkDupKeyword(ByVal keyword As String, ByVal vFAQ_ID As Long, ByVal vID As Long) As Boolean
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New FaqKeywordLinqDB
            'Dim ret As Boolean = lnq.ChkDataByWhere("keyword = '" & keyword & "' and id <> " & vID, trans.Trans)
            Dim ret As Boolean = lnq.ChkDuplicateByFAQ_ID_KEYWORD(vID, keyword, vID, trans.Trans)
            trans.CommitTransaction()
            Return ret
        End Function
    End Class
End Namespace
