Imports LinqDB.TABLE
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Namespace Common
    Public Class ConfigENG
        Public Shared Function GetConfigValue(ByVal vConfigName As String) As String
            Dim ret As String = ""
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()
            Dim lnq As New SysconfigLinqDB
            If lnq.ChkDataByCONFIG_NAME(vConfigName, trans.Trans) = True Then
                ret = lnq.CONFIG_VALUE
            End If
            trans.CommitTransaction()
            Return ret
        End Function

        Public Shared Function GetUploadPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("UploadPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function

#Region " Encrypt/Decrypt "
        Private Shared mSEncryptionKey As String = "encryptstring"
        Private Shared mIV() As Byte = {&H25, &H29, &H93, &H27, &H52, &HFD, &HAE, &HBC}
        Private Shared mkey() As Byte = {}

        Public Shared Function EnCripPwd(ByVal pwd As String) As String
            Try
                mkey = System.Text.Encoding.UTF8.GetBytes(Left(mSEncryptionKey, 8))
                Dim des As New DESCryptoServiceProvider()
                ' convert our input string to a byte array
                Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(pwd)
                'now encrypt the bytearray
                Dim ms As New MemoryStream()
                Dim cs As New CryptoStream(ms, des.CreateEncryptor(mkey, mIV), CryptoStreamMode.Write)
                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                ' now return the byte array as a "safe for XMLDOM" Base64 String
                Return Convert.ToBase64String(ms.ToArray())
            Catch e As Exception
                Return e.Message
            End Try
        End Function

        Public Shared Function DeCripPwd(ByVal pwd As String) As String
            Dim inputByteArray(pwd.Length) As Byte
            ' Note: The DES CryptoService only accepts certain key byte lengths
            ' We are going to make things easy by insisting on an 8 byte legal key length

            Try
                mkey = System.Text.Encoding.UTF8.GetBytes(Left(mSEncryptionKey, 8))
                Dim des As New DESCryptoServiceProvider()
                ' we have a base 64 encoded string so first must decode to regular unencoded (encrypted) string
                inputByteArray = Convert.FromBase64String(pwd)
                ' now decrypt the regular string
                Dim ms As New MemoryStream()
                Dim cs As New CryptoStream(ms, des.CreateDecryptor(mkey, mIV), CryptoStreamMode.Write)
                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
                Return encoding.GetString(ms.ToArray())
            Catch e As Exception
                Return e.Message
            End Try
        End Function
#End Region


        Public Shared Function ConvertDateFromWS(ByVal DateFromWS As String) As Date
            'ข้อมูลที่มาจาก WS จะมาในรูปแบบ MM/DD/YYYY แล้วเราจะ Convert ให้เป็น Date
            Dim ret As Date
            If DateFromWS.Trim <> "" Then
                Dim vDay As String = DateFromWS.Substring(3, 2)
                Dim vMonth As String = Left(DateFromWS, 2)
                Dim vYear As String = Right(DateFromWS, 4)

                ret = New Date(vYear, vMonth, vDay)
            Else
                ret = New Date(1, 1, 1)
            End If

            Return ret
        End Function

        Public Shared Function ConvertDTTM(ByVal DttmFromWS As String) As DateTime
            'ข้อมูลที่มาจาก WS จะมาในรูปแบบ 2011-10-05 10:46:50 แล้วเราจะ Convert ให้เป็น Date
            Dim ret As DateTime
            If DttmFromWS <> "" Then
                Dim vDay As String = DttmFromWS.Substring(8, 2)
                Dim vMonth As String = DttmFromWS.Substring(5, 2)
                Dim vYear As String = Left(DttmFromWS, 4)
                Dim vHour As String = DttmFromWS.Substring(11, 2)
                Dim vMin As String = DttmFromWS.Substring(14, 2)
                Dim vSec As String = Right(DttmFromWS, 2)

                ret = New Date(vYear, vMonth, vDay, vHour, vMin, vSec)
            Else
                ret = New Date(1, 1, 1)
            End If

            Return ret
        End Function

        Private Shared _err As String = ""
        Public Shared ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Shared Function ExecuteSQL(ByVal sql As String, ByVal trans As LinqDB.Common.Utilities.TransactionDB) As DataTable
            Dim dt As New DataTable

            If sql.Trim().StartsWith("select") = True Then
                dt = LinqDB.Common.Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
            Else
                dt.Columns.Add("message")
                Dim dr As DataRow = dt.NewRow
                dr("message") = LinqDB.Common.Utilities.SqlDB.ExecuteNonQuery(sql, trans.Trans)
                dt.Rows.Add(dr)
            End If

            If LinqDB.Common.Utilities.SqlDB.ErrorMessate <> "" Then
                _err = LinqDB.Common.Utilities.SqlDB.ErrorMessate
            End If
            Return dt
        End Function
    End Class
End Namespace

