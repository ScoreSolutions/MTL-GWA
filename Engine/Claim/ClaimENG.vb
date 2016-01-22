Imports LinqDB.TABLE
Imports Para.TABLE
Imports Para.Common.Utilities

Namespace Claim
    Public Class ClaimENG
        Public Function GetFileListByServiceType(ByVal vServiceType As String, ByVal trans As Common.DbTrans) As DataTable
            Dim lnq As New ClaimAttachFileLinqDB
            Dim dt As DataTable = lnq.GetDataList(" service_type = '" & vServiceType & "' and active = 'Y' ", "order_seq", trans.Trans)
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
    End Class
End Namespace

