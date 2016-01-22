Imports Para.TABLE
Imports LinqDB.TABLE
Imports Para.Common.Utilities
Imports Para.OutputWS

Namespace Download
    Public Class DownloadENG
        Dim _err As String = ""
        Dim _DownloadID As Long

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property DownloadID() As Long
            Get
                Return _DownloadID
            End Get
        End Property

        Public Function GetDownloadList(ByVal vType As Long, ByVal trans As Common.DbTrans, ByVal UserID As String) As DataTable
            Dim lnq As New DownloadLinqDB
            Dim dt As New DataTable


            'ถ้ามีเอกสารที่มีการระบุชื่อบริษัท ก็ให้แสดงเฉพาะเอกสารเหล่านั้น
            Dim resCom As String = GetAcCodeArray(UserID, trans)
            If resCom.Trim <> "" Then
                If lnq.ChkDataByWhere(" download_type_id =" & vType & resCom & " and account_code is not null and document_type = '2' and active = 'Y'", trans.Trans) = True Then
                    dt = lnq.GetDataList(" download_type_id = " & vType & GetAcCodeArray(UserID, trans) & " and account_code is not null and document_type = '2' and active = 'Y'", "download_type_id, order_seq", trans.Trans)
                Else
                    'ถ้ามีการระบุชื่อบริษัทที่รับผิดชอบ  แต่ไม่มีเอกสารเฉพาะบริษัท ก็ให้แสดงเฉพาะเอกสารมาตรฐาน
                    dt = lnq.GetDataList(" download_type_id = " & vType & " and account_code is null and document_type = '1' and active = 'Y'", "download_type_id, order_seq", trans.Trans)
                End If
            Else
                'ถ้าไม่มีการระบุชื่อบริษัทที่รับผิดชอบ ก็ให้แสดงเฉพาะเอกสารมาตรฐาน
                dt = lnq.GetDataList(" download_type_id = " & vType & " and account_code is null and document_type = '1' and active = 'Y'", "download_type_id, order_seq", trans.Trans)
            End If
            
            Return dt
        End Function

        Private Function GetAcCodeArray(ByVal UserID As String, ByVal trans As Common.DbTrans) As String
            Dim ret As String = ""
            Dim lnq As New UsersResponseCompanyLinqDB
            Dim dt As DataTable = lnq.GetDataList("user_id = '" & UserID & "'", "", trans.Trans)
            If dt.Rows.Count > 0 Then
                Dim tmp As String = ""
                ret = " and account_code in ("
                For Each dr As DataRow In dt.Rows
                    If tmp.Trim = "" Then
                        tmp = "'" & dr("ac_code") & "' "
                    Else
                        tmp += ", '" & dr("ac_code") & "' "
                    End If
                Next
                ret += tmp & ") "
            End If

            Return ret
        End Function

        Public Function GetAllFileList(ByVal TypeID As String) As DataTable
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New DownloadLinqDB
            Dim sql As String = ""
            sql += " select d.id, dt.type_name file_category, d.file_desc, "
            sql += " case d.active when 'Y' then 'แสดง' when 'N' then 'ไม่แสดง' end active_name,"
            sql += " d.import_date "
            sql += " from download d "
            sql += " inner join download_type dt on dt.id=d.download_type_id"
            If TypeID <> "0" Then
                sql += " where dt.id = '" & TypeID & "'"
            End If
            sql += " order by d.order_seq "

            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetDownloadTypeList() As DataTable
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New DownloadTypeLinqDB
            'Dim sql As String = ""
            'sql += " select id, name from aaaaa  where 1=1 order by order_seq"
            'Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)


            Dim dt As DataTable = lnq.GetDataList("1=1", "order_seq", trans.Trans)
            trans.CommitTransaction()

            Return dt

        End Function

        Public Function GetIconFile(ByVal dr As DataRow) As String
            Dim ret As String = "<img src='../Images/"
            If dr("FILE_EXT").ToString.ToUpper = Constant.FileExt.PDF.ToUpper Then
                ret += "PDFIcon.png'"
            ElseIf dr("FILE_EXT").ToString.ToUpper = Constant.FileExt.DOC.ToUpper Or dr("FILE_EXT").ToString.ToUpper = Constant.FileExt.DOCX.ToUpper Then
                ret += "WORDicon.gif'"
            ElseIf dr("FILE_EXT").ToString.ToUpper = Constant.FileExt.XLS.ToUpper Or dr("FILE_EXT").ToString.ToUpper = Constant.FileExt.XLSX.ToUpper Then
                ret += "ExcelIcon.gif'"
            End If
            ret += " border='0' height='24px' />"

            Return ret
        End Function

        Public Function SaveDownload(ByVal UserID As String, ByVal para As DownloadPara, ByVal trans As Common.DbTrans) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New DownloadLinqDB
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.DOWNLOAD_TYPE_ID = para.DOWNLOAD_TYPE_ID
            lnq.IMPORT_DATE = para.IMPORT_DATE
            lnq.FILE_DESC = para.FILE_DESC
            lnq.FILE_EXT = para.FILE_EXT
            lnq.DOCUMENT_TYPE = para.DOCUMENT_TYPE
            lnq.ACCOUNT_CODE = para.ACCOUNT_CODE
            lnq.ORDER_SEQ = para.ORDER_SEQ
            lnq.ACTIVE = para.ACTIVE

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            Else
                _DownloadID = lnq.ID
            End If

            Return ret

        End Function

        Public Function GetDownloadPara(ByVal vID As Long, ByVal trans As Common.DbTrans) As DownloadPara
            Dim lnq As New DownloadLinqDB
            Return lnq.GetParameter(vID, trans.Trans)
        End Function

        Public Function DeleteDownloadRecord(ByVal vID As Long, ByVal trans As Common.DbTrans) As Boolean
            Dim lnq As New DownloadLinqDB
            Dim ret As Boolean = lnq.DeleteByPK(vID, trans.Trans)
            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            Return ret
        End Function
    End Class
End Namespace

