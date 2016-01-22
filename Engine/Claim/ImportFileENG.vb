Imports Para.TABLE
Imports Para.Common.Utilities
Imports LinqDB.TABLE
Imports System.Data

Namespace Claim
    Public Class ImportFileENG
        Dim _err As String = ""
        Dim _id As Long

        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ID() As Long
            Get
                Return _id
            End Get
        End Property

        Public Function SaveClaimAttachFile(ByVal UserID As String, ByVal para As ClaimAttachFilePara, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New ClaimAttachFileLinqDB
            Dim oldPara As New ClaimAttachFilePara
            If para.ID <> 0 Then
                oldPara = lnq.GetParameter(para.ID, trans.Trans)
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.SERVICE_TYPE = para.SERVICE_TYPE
            lnq.FILE_DESC = para.FILE_DESC
            lnq.FILE_EXT = para.FILE_EXT
            lnq.ORDER_SEQ = para.ORDER_SEQ
            lnq.ACTIVE = para.ACTIVE

            If para.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                lnq.IMPORT_DATE = DateTime.Now
                ret = lnq.InsertData(UserID, trans.Trans)
            End If
            If ret = False Then
                _err = lnq.ErrorMessage
            Else
                _id = lnq.ID
            End If

            Return ret
        End Function

        Public Function SeperateOrderSeq(ByVal UserID As String, ByVal vServiceType As Long, ByVal NewSeq As Long, ByVal OldSeq As Long) As Boolean
            'เอาค่าที่กำลังจะบันทึกลงไปมาทำการแทรกก่อน
            Dim ret As Boolean = True
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()

            Dim lnq As New ClaimAttachFileLinqDB

            If NewSeq <= OldSeq Then
                If lnq.ChkDataByWhere("service_type = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans) = True Then
                    ret = lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq + 1 where service_type = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = lnq.ErrorMessage
                    End If
                End If
            Else
                If lnq.ChkDataByWhere("service_type = " & vServiceType & " and order_seq >= " & NewSeq, trans.Trans) = True Then
                    ret = lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq - 1 where service_type = " & vServiceType & " and order_seq = " & NewSeq, trans.Trans)
                    If ret = True Then
                        lnq.UpdateBySql("update " & lnq.TableName & " set order_seq = order_seq + 1 where service_type = " & vServiceType & " and order_seq > " & NewSeq, trans.Trans)

                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = lnq.ErrorMessage
                    End If
                Else
                    ret = True
                End If
            End If

            Return ret
        End Function

        Public Function RunOrderSeq(ByVal UserID As String, ByVal vServiceType As Long) As Boolean
            Dim ret As Boolean = True
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New ClaimAttachFileLinqDB
            Dim dt As DataTable = lnq.GetDataList("service_type = " & vServiceType, "order_seq", trans.Trans)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lnq = New ClaimAttachFileLinqDB
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

        Public Function GetClaimAttachFilePara(ByVal vID As Long, ByVal trans As Common.DbTrans) As ClaimAttachFilePara
            Dim lnq As New ClaimAttachFileLinqDB
            Return lnq.GetParameter(vID, trans.Trans)
        End Function
        Public Function DeleteClaimAttachFile(ByVal vID As Long, ByVal trans As Common.DbTrans) As Boolean
            Dim lnq As New ClaimAttachFileLinqDB
            Dim ret As Boolean = lnq.DeleteByPK(vID, trans.Trans)
            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            Return ret
        End Function

        Public Function SetFileList(ByVal ServiceTypeID As String, ByVal trans As Common.DbTrans) As DataTable
            Dim sql As String = ""
            sql += " select id, case service_type when '1' then 'สินไหมประกันสุขภาพ' when '2' then 'สินไหม:ประกันชีวิต,อุบัติเหตุ,ทุพพลภาพ' end service_category, "
            sql += " order_seq, file_desc, case active when 'Y' then 'แสดง' when 'N' then 'ไม่แสดง' end active_name, import_date "
            sql += " from CLAIM_ATTACH_FILE "
            sql += " where service_type = '" & ServiceTypeID & "'"
            sql += " order by order_seq "

            Dim lnq As New ClaimAttachFileLinqDB
            Return lnq.GetListBySql(sql, trans.Trans)
        End Function

        Public Function GenNextOrderSeq(ByVal vServiceType As String) As String
            Dim ret As String = "1"
            Dim lnq As New ClaimAttachFileLinqDB
            Dim sql As String = ""
            sql += " select max(order_seq) max_order_seq "
            sql += " from claim_attach_file "
            sql += " where service_type = '" & vServiceType & "'"

            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            If IsDBNull(dt.Rows(0)("max_order_seq")) = False Then
                ret = (Convert.ToDouble(dt.Rows(0)("max_order_seq")) + 1).ToString
            End If
            Return ret
        End Function
    End Class
End Namespace

