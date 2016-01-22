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
    'Represents a transaction for LOGIN_HISTORY table LinqDB.
    '[Create by  on November, 20 2011]
    Public Class LoginHistoryLinqDB
        Public sub LoginHistoryLinqDB()

        End Sub 
        ' LOGIN_HISTORY
        Const _tableName As String = "LOGIN_HISTORY"
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
        Dim _USER_NAME_T As String = ""
        Dim _USER_NAME_E As  String  = ""
        Dim _BROKER_CODE As  String  = ""
        Dim _COMPANY_NAME As  String  = ""
        Dim _LOGIN_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOGOUT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IP_ADDRESS As String = ""
        Dim _SESSION_ID As String = ""
        Dim _BROWSER As String = ""

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
        <Column(Storage:="_CREATE_ON", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
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
        <Column(Storage:="_UPDATE_ON", DbType:="DateTime2")>  _
        Public Property UPDATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_USER_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_ID() As String
            Get
                Return _USER_ID
            End Get
            Set(ByVal value As String)
               _USER_ID = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_T", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_NAME_T() As String
            Get
                Return _USER_NAME_T
            End Get
            Set(ByVal value As String)
               _USER_NAME_T = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_E", DbType:="VarChar(255)")>  _
        Public Property USER_NAME_E() As  String 
            Get
                Return _USER_NAME_E
            End Get
            Set(ByVal value As  String )
               _USER_NAME_E = value
            End Set
        End Property 
        <Column(Storage:="_BROKER_CODE", DbType:="VarChar(255)")>  _
        Public Property BROKER_CODE() As  String 
            Get
                Return _BROKER_CODE
            End Get
            Set(ByVal value As  String )
               _BROKER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255)")>  _
        Public Property COMPANY_NAME() As  String 
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As  String )
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_TIME", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_TIME() As DateTime
            Get
                Return _LOGIN_TIME
            End Get
            Set(ByVal value As DateTime)
               _LOGIN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_LOGOUT_TIME", DbType:="DateTime2")>  _
        Public Property LOGOUT_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LOGOUT_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LOGOUT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_SESSION_ID", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SESSION_ID() As String
            Get
                Return _SESSION_ID
            End Get
            Set(ByVal value As String)
               _SESSION_ID = value
            End Set
        End Property 
        <Column(Storage:="_BROWSER", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BROWSER() As String
            Get
                Return _BROWSER
            End Get
            Set(ByVal value As String)
               _BROWSER = value
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
            _USER_NAME_T = ""
            _USER_NAME_E = ""
            _BROKER_CODE = ""
            _COMPANY_NAME = ""
            _LOGIN_TIME = New DateTime(1,1,1)
            _LOGOUT_TIME = New DateTime(1,1,1)
            _IP_ADDRESS = ""
            _SESSION_ID = ""
            _BROWSER = ""
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


        '/// Returns an indication whether the current data is inserted into LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As LoginHistoryLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As LoginHistoryPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified USER_ID key is retrieved successfully.
        '/// <param name=cUSER_ID>The USER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSER_ID(cUSER_ID As String, trans As SQLTransaction) As Boolean
            Return doChkData("USER_ID = " & DB.SetString(cUSER_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified USER_ID key is retrieved successfully.
        '/// <param name=cUSER_ID>The USER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSER_ID(cUSER_ID As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USER_ID = " & DB.SetString(cUSER_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOGIN_TIME(cLOGIN_TIME As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByLOGIN_TIME(cLOGIN_TIME As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is deleted from LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then _user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then _user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then _broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                        If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()
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


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As LoginHistoryLinqDB
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
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then _user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then _user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then _broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                        If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : LOG_ERROR Column :login_his_id
                        Dim LogError_login_his_idItem As New LogErrorLinqDB
                        _LOG_ERROR_login_his_id = LogError_login_his_idItem.GetDataList("login_his_id = " & _ID, "", Nothing)

                        'Child Table Name : LOG_TRANS Column :login_his_id
                        Dim LogTrans_login_his_idItem As New LogTransLinqDB
                        _LOG_TRANS_login_his_id = LogTrans_login_his_idItem.GetDataList("login_his_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As LoginHistoryPara
            ClearData()
            _haveData  = False
            Dim ret As New LoginHistoryPara
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
                        If Convert.IsDBNull(Rdr("user_name_t")) = False Then ret.user_name_t = Rdr("user_name_t").ToString()
                        If Convert.IsDBNull(Rdr("user_name_e")) = False Then ret.user_name_e = Rdr("user_name_e").ToString()
                        If Convert.IsDBNull(Rdr("broker_code")) = False Then ret.broker_code = Rdr("broker_code").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then ret.company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then ret.login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then ret.logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then ret.ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("session_id")) = False Then ret.session_id = Rdr("session_id").ToString()
                        If Convert.IsDBNull(Rdr("browser")) = False Then ret.browser = Rdr("browser").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : LOG_ERROR Column :login_his_id
                        Dim LogError_login_his_idItem As New LogErrorLinqDB
                        _LOG_ERROR_login_his_id = LogError_login_his_idItem.GetDataList("login_his_id = " & ret.id, "", Nothing)
                        ret.CHILD_LOG_ERROR_login_his_id = _LOG_ERROR_login_his_id

                        'Child Table Name : LOG_TRANS Column :login_his_id
                        Dim LogTrans_login_his_idItem As New LogTransLinqDB
                        _LOG_TRANS_login_his_id = LogTrans_login_his_idItem.GetDataList("login_his_id = " & ret.id, "", Nothing)
                        ret.CHILD_LOG_TRANS_login_his_id = _LOG_TRANS_login_his_id


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


        'Get Insert Statement for table LOGIN_HISTORY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USER_ID, USER_NAME_T, USER_NAME_E, BROKER_CODE, COMPANY_NAME, LOGIN_TIME, LOGOUT_TIME, IP_ADDRESS, SESSION_ID, BROWSER)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USER_ID) & ", "
                sql += DB.SetString(_USER_NAME_T) & ", "
                sql += DB.SetString(_USER_NAME_E) & ", "
                sql += DB.SetString(_BROKER_CODE) & ", "
                sql += DB.SetString(_COMPANY_NAME) & ", "
                sql += DB.SetDateTime(_LOGIN_TIME) & ", "
                sql += DB.SetDateTime(_LOGOUT_TIME) & ", "
                sql += DB.SetString(_IP_ADDRESS) & ", "
                sql += DB.SetString(_SESSION_ID) & ", "
                sql += DB.SetString(_BROWSER)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table LOGIN_HISTORY
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
                Sql += "USER_NAME_T = " & DB.SetString(_USER_NAME_T) & ", "
                Sql += "USER_NAME_E = " & DB.SetString(_USER_NAME_E) & ", "
                Sql += "BROKER_CODE = " & DB.SetString(_BROKER_CODE) & ", "
                Sql += "COMPANY_NAME = " & DB.SetString(_COMPANY_NAME) & ", "
                Sql += "LOGIN_TIME = " & DB.SetDateTime(_LOGIN_TIME) & ", "
                Sql += "LOGOUT_TIME = " & DB.SetDateTime(_LOGOUT_TIME) & ", "
                Sql += "IP_ADDRESS = " & DB.SetString(_IP_ADDRESS) & ", "
                Sql += "SESSION_ID = " & DB.SetString(_SESSION_ID) & ", "
                Sql += "BROWSER = " & DB.SetString(_BROWSER) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table LOGIN_HISTORY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table LOGIN_HISTORY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _LOG_ERROR_login_his_id As DataTable
       Dim _LOG_TRANS_login_his_id As DataTable

       Public Property CHILD_LOG_ERROR_login_his_id() As DataTable
           Get
               Return _LOG_ERROR_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_ERROR_login_his_id = value
           End Set
       End Property
       Public Property CHILD_LOG_TRANS_login_his_id() As DataTable
           Get
               Return _LOG_TRANS_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_TRANS_login_his_id = value
           End Set
       End Property
    End Class
End Namespace
