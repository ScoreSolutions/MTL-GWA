Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.Common.Utilities.SQLDB
Imports Para.TABLE
Imports Para.Common.Utilities

Namespace TABLE
    'Represents a transaction for USERS table LinqDB.
    '[Create by  on November, 20 2011]
    Public Class UsersLinqDB
        Public sub UsersLinqDB()

        End Sub 
        ' USERS
        Const _tableName As String = "USERS"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_ID As String = ""
        Dim _USER_PASSWD As String = ""
        Dim _USER_TYPE As Char = ""
        Dim _USER_NAME_T As String = ""
        Dim _USER_NAME_E As  String  = ""
        Dim _BROKER_CODE As  String  = ""
        Dim _AC_CODE As  String  = ""
        Dim _COMPANY_NAME As String = ""
        Dim _PASSWD_DATE As DateTime = New DateTime(1,1,1)
        Dim _USER_S_DATE As DateTime = New DateTime(1,1,1)
        Dim _USER_E_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_LEVEL As Long = 0
        Dim _USER_EMAIL As String = ""
        Dim _USER_TEL As  String  = ""
        Dim _MARKET_EMAIL As String = ""
        Dim _MARKET_CC_EMAIL As String = ""
        Dim _CLAIM_EMAIL As String = ""
        Dim _CLAIM_CC_EMAIL As String = ""
        Dim _DISC_REASON As  String  = ""
        Dim _INPUT_PERSON As String = ""
        Dim _CREATE_DTTM As DateTime = New DateTime(1,1,1)
        Dim _MNT_DTTM As DateTime = New DateTime(1,1,1)
        Dim _IS_FIRST_LOGIN As  System.Nullable(Of Char)  = ""
        Dim _LOGIN_FAIL_COUNT As  System.Nullable(Of Long)  = 0
        Dim _LAST_LOGIN_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_ON", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_ON() As DateTime
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As DateTime)
               _CREATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(50)")>  _
        Public Property UPDATE_BY() As  String 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  String )
               _UPDATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_ON", DbType:="DateTime")>  _
        Public Property UPDATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_USER_ID", DbType:="VarChar(8) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_ID() As String
            Get
                Return _USER_ID
            End Get
            Set(ByVal value As String)
               _USER_ID = value
            End Set
        End Property 
        <Column(Storage:="_USER_PASSWD", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_PASSWD() As String
            Get
                Return _USER_PASSWD
            End Get
            Set(ByVal value As String)
               _USER_PASSWD = value
            End Set
        End Property 
        <Column(Storage:="_USER_TYPE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_TYPE() As Char
            Get
                Return _USER_TYPE
            End Get
            Set(ByVal value As Char)
               _USER_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_T", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_NAME_T() As String
            Get
                Return _USER_NAME_T
            End Get
            Set(ByVal value As String)
               _USER_NAME_T = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_E", DbType:="VarChar(100)")>  _
        Public Property USER_NAME_E() As  String 
            Get
                Return _USER_NAME_E
            End Get
            Set(ByVal value As  String )
               _USER_NAME_E = value
            End Set
        End Property 
        <Column(Storage:="_BROKER_CODE", DbType:="VarChar(8)")>  _
        Public Property BROKER_CODE() As  String 
            Get
                Return _BROKER_CODE
            End Get
            Set(ByVal value As  String )
               _BROKER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_AC_CODE", DbType:="VarChar(10)")>  _
        Public Property AC_CODE() As  String 
            Get
                Return _AC_CODE
            End Get
            Set(ByVal value As  String )
               _AC_CODE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_NAME() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_PASSWD_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property PASSWD_DATE() As DateTime
            Get
                Return _PASSWD_DATE
            End Get
            Set(ByVal value As DateTime)
               _PASSWD_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_S_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_S_DATE() As DateTime
            Get
                Return _USER_S_DATE
            End Get
            Set(ByVal value As DateTime)
               _USER_S_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_E_DATE", DbType:="DateTime")>  _
        Public Property USER_E_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _USER_E_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _USER_E_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_LEVEL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_LEVEL() As Long
            Get
                Return _USER_LEVEL
            End Get
            Set(ByVal value As Long)
               _USER_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_USER_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_EMAIL() As String
            Get
                Return _USER_EMAIL
            End Get
            Set(ByVal value As String)
               _USER_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_USER_TEL", DbType:="VarChar(10)")>  _
        Public Property USER_TEL() As  String 
            Get
                Return _USER_TEL
            End Get
            Set(ByVal value As  String )
               _USER_TEL = value
            End Set
        End Property 
        <Column(Storage:="_MARKET_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property MARKET_EMAIL() As String
            Get
                Return _MARKET_EMAIL
            End Get
            Set(ByVal value As String)
               _MARKET_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_MARKET_CC_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property MARKET_CC_EMAIL() As String
            Get
                Return _MARKET_CC_EMAIL
            End Get
            Set(ByVal value As String)
               _MARKET_CC_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_CLAIM_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLAIM_EMAIL() As String
            Get
                Return _CLAIM_EMAIL
            End Get
            Set(ByVal value As String)
               _CLAIM_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_CLAIM_CC_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLAIM_CC_EMAIL() As String
            Get
                Return _CLAIM_CC_EMAIL
            End Get
            Set(ByVal value As String)
               _CLAIM_CC_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_DISC_REASON", DbType:="VarChar(100)")>  _
        Public Property DISC_REASON() As  String 
            Get
                Return _DISC_REASON
            End Get
            Set(ByVal value As  String )
               _DISC_REASON = value
            End Set
        End Property 
        <Column(Storage:="_INPUT_PERSON", DbType:="VarChar(8) NOT NULL ",CanBeNull:=false)>  _
        Public Property INPUT_PERSON() As String
            Get
                Return _INPUT_PERSON
            End Get
            Set(ByVal value As String)
               _INPUT_PERSON = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_DTTM", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_DTTM() As DateTime
            Get
                Return _CREATE_DTTM
            End Get
            Set(ByVal value As DateTime)
               _CREATE_DTTM = value
            End Set
        End Property 
        <Column(Storage:="_MNT_DTTM", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property MNT_DTTM() As DateTime
            Get
                Return _MNT_DTTM
            End Get
            Set(ByVal value As DateTime)
               _MNT_DTTM = value
            End Set
        End Property 
        <Column(Storage:="_IS_FIRST_LOGIN", DbType:="Char(1)")>  _
        Public Property IS_FIRST_LOGIN() As  System.Nullable(Of Char) 
            Get
                Return _IS_FIRST_LOGIN
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_FIRST_LOGIN = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_FAIL_COUNT", DbType:="Int")>  _
        Public Property LOGIN_FAIL_COUNT() As  System.Nullable(Of Long) 
            Get
                Return _LOGIN_FAIL_COUNT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _LOGIN_FAIL_COUNT = value
            End Set
        End Property 
        <Column(Storage:="_LAST_LOGIN_TIME", DbType:="DateTime")>  _
        Public Property LAST_LOGIN_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LAST_LOGIN_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LAST_LOGIN_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _USER_ID = ""
            _USER_PASSWD = ""
            _USER_TYPE = ""
            _USER_NAME_T = ""
            _USER_NAME_E = ""
            _BROKER_CODE = ""
            _AC_CODE = ""
            _COMPANY_NAME = ""
            _PASSWD_DATE = New DateTime(1,1,1)
            _USER_S_DATE = New DateTime(1,1,1)
            _USER_E_DATE = New DateTime(1,1,1)
            _USER_LEVEL = 0
            _USER_EMAIL = ""
            _USER_TEL = ""
            _MARKET_EMAIL = ""
            _MARKET_CC_EMAIL = ""
            _CLAIM_EMAIL = ""
            _CLAIM_CC_EMAIL = ""
            _DISC_REASON = ""
            _INPUT_PERSON = ""
            _CREATE_DTTM = New DateTime(1,1,1)
            _MNT_DTTM = New DateTime(1,1,1)
            _IS_FIRST_LOGIN = ""
            _LOGIN_FAIL_COUNT = 0
            _LAST_LOGIN_TIME = New DateTime(1,1,1)
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into USERS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _id = DB.GetNextID("id",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_ON = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to USERS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UPDATE_BY = LoginName
                _UPDATE_ON = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to USERS table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from USERS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cPK As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("id = " & cPK, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of USERS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of USERS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As UsersLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of USERS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As UsersPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of USERS by specified USER_ID key is retrieved successfully.
        '/// <param name=cUSER_ID>The USER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSER_ID(cUSER_ID As String, trans As SQLTransaction) As Boolean
            Return doChkData("USER_ID = " & DB.SetString(cUSER_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of USERS by specified USER_ID key is retrieved successfully.
        '/// <param name=cUSER_ID>The USER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSER_ID(cUSER_ID As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USER_ID = " & DB.SetString(cUSER_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of USERS by specified PASSWD_DATE key is retrieved successfully.
        '/// <param name=cPASSWD_DATE>The PASSWD_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPASSWD_DATE(cPASSWD_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("PASSWD_DATE = " & DB.SetDateTime(cPASSWD_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of USERS by specified PASSWD_DATE key is retrieved successfully.
        '/// <param name=cPASSWD_DATE>The PASSWD_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByPASSWD_DATE(cPASSWD_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("PASSWD_DATE = " & DB.SetDateTime(cPASSWD_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of USERS by specified USER_E_DATE key is retrieved successfully.
        '/// <param name=cUSER_E_DATE>The USER_E_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSER_E_DATE(cUSER_E_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("USER_E_DATE = " & DB.SetDateTime(cUSER_E_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of USERS by specified USER_E_DATE key is retrieved successfully.
        '/// <param name=cUSER_E_DATE>The USER_E_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSER_E_DATE(cUSER_E_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USER_E_DATE = " & DB.SetDateTime(cUSER_E_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of USERS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into USERS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = MessageResources.MSGEN001
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to USERS table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGEU001
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from USERS table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of USERS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("user_id")) = False Then _user_id = Rdr("user_id").ToString()
                        If Convert.IsDBNull(Rdr("user_passwd")) = False Then _user_passwd = Rdr("user_passwd").ToString()
                        If Convert.IsDBNull(Rdr("user_type")) = False Then _user_type = Rdr("user_type").ToString()
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then _user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then _user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then _broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then _ac_code = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("passwd_date")) = False Then _passwd_date = Convert.ToDateTime(Rdr("passwd_date"))
                        If Convert.IsDBNull(Rdr("user_s_date")) = False Then _user_s_date = Convert.ToDateTime(Rdr("user_s_date"))
                        If Convert.IsDBNull(Rdr("user_e_date")) = False Then _user_e_date = Convert.ToDateTime(Rdr("user_e_date"))
                        If Convert.IsDBNull(Rdr("user_level")) = False Then _user_level = Convert.ToInt32(Rdr("user_level"))
                        If Convert.IsDBNull(Rdr("user_email")) = False Then _user_email = Rdr("user_email").ToString()
                        If Convert.IsDBNull(Rdr("user_tel")) = False Then _user_tel = Rdr("user_tel").ToString()
                        If Convert.IsDBNull(Rdr("market_email")) = False Then _market_email = Rdr("market_email").ToString()
                        If Convert.IsDBNull(Rdr("market_cc_email")) = False Then _market_cc_email = Rdr("market_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_email")) = False Then _claim_email = Rdr("claim_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_cc_email")) = False Then _claim_cc_email = Rdr("claim_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("disc_reason")) = False Then _disc_reason = Rdr("disc_reason").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then _input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then _create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then _mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))
                        If Convert.IsDBNull(Rdr("is_first_login")) = False Then _is_first_login = Rdr("is_first_login").ToString()
                        If Convert.IsDBNull(Rdr("login_fail_count")) = False Then _login_fail_count = Convert.ToInt32(Rdr("login_fail_count"))
                        If Convert.IsDBNull(Rdr("last_login_time")) = False Then _last_login_time = Convert.ToDateTime(Rdr("last_login_time"))
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of USERS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As UsersLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("user_id")) = False Then _user_id = Rdr("user_id").ToString()
                        If Convert.IsDBNull(Rdr("user_passwd")) = False Then _user_passwd = Rdr("user_passwd").ToString()
                        If Convert.IsDBNull(Rdr("user_type")) = False Then _user_type = Rdr("user_type").ToString()
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then _user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then _user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then _broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then _ac_code = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("passwd_date")) = False Then _passwd_date = Convert.ToDateTime(Rdr("passwd_date"))
                        If Convert.IsDBNull(Rdr("user_s_date")) = False Then _user_s_date = Convert.ToDateTime(Rdr("user_s_date"))
                        If Convert.IsDBNull(Rdr("user_e_date")) = False Then _user_e_date = Convert.ToDateTime(Rdr("user_e_date"))
                        If Convert.IsDBNull(Rdr("user_level")) = False Then _user_level = Convert.ToInt32(Rdr("user_level"))
                        If Convert.IsDBNull(Rdr("user_email")) = False Then _user_email = Rdr("user_email").ToString()
                        If Convert.IsDBNull(Rdr("user_tel")) = False Then _user_tel = Rdr("user_tel").ToString()
                        If Convert.IsDBNull(Rdr("market_email")) = False Then _market_email = Rdr("market_email").ToString()
                        If Convert.IsDBNull(Rdr("market_cc_email")) = False Then _market_cc_email = Rdr("market_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_email")) = False Then _claim_email = Rdr("claim_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_cc_email")) = False Then _claim_cc_email = Rdr("claim_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("disc_reason")) = False Then _disc_reason = Rdr("disc_reason").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then _input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then _create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then _mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))
                        If Convert.IsDBNull(Rdr("is_first_login")) = False Then _is_first_login = Rdr("is_first_login").ToString()
                        If Convert.IsDBNull(Rdr("login_fail_count")) = False Then _login_fail_count = Convert.ToInt32(Rdr("login_fail_count"))
                        If Convert.IsDBNull(Rdr("last_login_time")) = False Then _last_login_time = Convert.ToDateTime(Rdr("last_login_time"))

                        'Generate Item For Child Table
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function


        '/// Returns an indication whether the Class Data of USERS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As UsersPara
            ClearData()
            _haveData  = False
            Dim ret As New UsersPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then ret.create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then ret.create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then ret.update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then ret.update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("user_id")) = False Then ret.user_id = Rdr("user_id").ToString()
                        If Convert.IsDBNull(Rdr("user_passwd")) = False Then ret.user_passwd = Rdr("user_passwd").ToString()
                        If Convert.IsDBNull(Rdr("user_type")) = False Then ret.user_type = Rdr("user_type").ToString()
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then ret.user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then ret.user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then ret.broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then ret.ac_code = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then ret.company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("passwd_date")) = False Then ret.passwd_date = Convert.ToDateTime(Rdr("passwd_date"))
                        If Convert.IsDBNull(Rdr("user_s_date")) = False Then ret.user_s_date = Convert.ToDateTime(Rdr("user_s_date"))
                        If Convert.IsDBNull(Rdr("user_e_date")) = False Then ret.user_e_date = Convert.ToDateTime(Rdr("user_e_date"))
                        If Convert.IsDBNull(Rdr("user_level")) = False Then ret.user_level = Convert.ToInt32(Rdr("user_level"))
                        If Convert.IsDBNull(Rdr("user_email")) = False Then ret.user_email = Rdr("user_email").ToString()
                        If Convert.IsDBNull(Rdr("user_tel")) = False Then ret.user_tel = Rdr("user_tel").ToString()
                        If Convert.IsDBNull(Rdr("market_email")) = False Then ret.market_email = Rdr("market_email").ToString()
                        If Convert.IsDBNull(Rdr("market_cc_email")) = False Then ret.market_cc_email = Rdr("market_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_email")) = False Then ret.claim_email = Rdr("claim_email").ToString()
                        If Convert.IsDBNull(Rdr("claim_cc_email")) = False Then ret.claim_cc_email = Rdr("claim_cc_email").ToString()
                        If Convert.IsDBNull(Rdr("disc_reason")) = False Then ret.disc_reason = Rdr("disc_reason").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then ret.input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then ret.create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then ret.mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))
                        If Convert.IsDBNull(Rdr("is_first_login")) = False Then ret.is_first_login = Rdr("is_first_login").ToString()
                        If Convert.IsDBNull(Rdr("login_fail_count")) = False Then ret.login_fail_count = Convert.ToInt32(Rdr("login_fail_count"))
                        If Convert.IsDBNull(Rdr("last_login_time")) = False Then ret.last_login_time = Convert.ToDateTime(Rdr("last_login_time"))

                        'Generate Item For Child Table

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return ret
        End Function

        ' SQL Statements


        'Get Insert Statement for table USERS
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USER_ID, USER_PASSWD, USER_TYPE, USER_NAME_T, USER_NAME_E, BROKER_CODE, AC_CODE, COMPANY_NAME, PASSWD_DATE, USER_S_DATE, USER_E_DATE, USER_LEVEL, USER_EMAIL, USER_TEL, MARKET_EMAIL, MARKET_CC_EMAIL, CLAIM_EMAIL, CLAIM_CC_EMAIL, DISC_REASON, INPUT_PERSON, CREATE_DTTM, MNT_DTTM, IS_FIRST_LOGIN, LOGIN_FAIL_COUNT, LAST_LOGIN_TIME)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USER_ID) & ", "
                sql += DB.SetString(_USER_PASSWD) & ", "
                sql += DB.SetString(_USER_TYPE) & ", "
                sql += DB.SetString(_USER_NAME_T) & ", "
                sql += DB.SetString(_USER_NAME_E) & ", "
                sql += DB.SetString(_BROKER_CODE) & ", "
                sql += DB.SetString(_AC_CODE) & ", "
                sql += DB.SetString(_COMPANY_NAME) & ", "
                sql += DB.SetDateTime(_PASSWD_DATE) & ", "
                sql += DB.SetDateTime(_USER_S_DATE) & ", "
                sql += DB.SetDateTime(_USER_E_DATE) & ", "
                sql += DB.SetDouble(_USER_LEVEL) & ", "
                sql += DB.SetString(_USER_EMAIL) & ", "
                sql += DB.SetString(_USER_TEL) & ", "
                sql += DB.SetString(_MARKET_EMAIL) & ", "
                sql += DB.SetString(_MARKET_CC_EMAIL) & ", "
                sql += DB.SetString(_CLAIM_EMAIL) & ", "
                sql += DB.SetString(_CLAIM_CC_EMAIL) & ", "
                sql += DB.SetString(_DISC_REASON) & ", "
                sql += DB.SetString(_INPUT_PERSON) & ", "
                sql += DB.SetDateTime(_CREATE_DTTM) & ", "
                sql += DB.SetDateTime(_MNT_DTTM) & ", "
                sql += DB.SetString(_IS_FIRST_LOGIN) & ", "
                sql += DB.SetDouble(_LOGIN_FAIL_COUNT) & ", "
                sql += DB.SetDateTime(_LAST_LOGIN_TIME)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table USERS
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "USER_ID = " & DB.SetString(_USER_ID) & ", "
                Sql += "USER_PASSWD = " & DB.SetString(_USER_PASSWD) & ", "
                Sql += "USER_TYPE = " & DB.SetString(_USER_TYPE) & ", "
                Sql += "USER_NAME_T = " & DB.SetString(_USER_NAME_T) & ", "
                Sql += "USER_NAME_E = " & DB.SetString(_USER_NAME_E) & ", "
                Sql += "BROKER_CODE = " & DB.SetString(_BROKER_CODE) & ", "
                Sql += "AC_CODE = " & DB.SetString(_AC_CODE) & ", "
                Sql += "COMPANY_NAME = " & DB.SetString(_COMPANY_NAME) & ", "
                Sql += "PASSWD_DATE = " & DB.SetDateTime(_PASSWD_DATE) & ", "
                Sql += "USER_S_DATE = " & DB.SetDateTime(_USER_S_DATE) & ", "
                Sql += "USER_E_DATE = " & DB.SetDateTime(_USER_E_DATE) & ", "
                Sql += "USER_LEVEL = " & DB.SetDouble(_USER_LEVEL) & ", "
                Sql += "USER_EMAIL = " & DB.SetString(_USER_EMAIL) & ", "
                Sql += "USER_TEL = " & DB.SetString(_USER_TEL) & ", "
                Sql += "MARKET_EMAIL = " & DB.SetString(_MARKET_EMAIL) & ", "
                Sql += "MARKET_CC_EMAIL = " & DB.SetString(_MARKET_CC_EMAIL) & ", "
                Sql += "CLAIM_EMAIL = " & DB.SetString(_CLAIM_EMAIL) & ", "
                Sql += "CLAIM_CC_EMAIL = " & DB.SetString(_CLAIM_CC_EMAIL) & ", "
                Sql += "DISC_REASON = " & DB.SetString(_DISC_REASON) & ", "
                Sql += "INPUT_PERSON = " & DB.SetString(_INPUT_PERSON) & ", "
                Sql += "CREATE_DTTM = " & DB.SetDateTime(_CREATE_DTTM) & ", "
                Sql += "MNT_DTTM = " & DB.SetDateTime(_MNT_DTTM) & ", "
                Sql += "IS_FIRST_LOGIN = " & DB.SetString(_IS_FIRST_LOGIN) & ", "
                Sql += "LOGIN_FAIL_COUNT = " & DB.SetDouble(_LOGIN_FAIL_COUNT) & ", "
                Sql += "LAST_LOGIN_TIME = " & DB.SetDateTime(_LAST_LOGIN_TIME) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table USERS
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table USERS
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
