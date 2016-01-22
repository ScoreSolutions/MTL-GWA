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
    'Represents a transaction for USERS_RESPONSE_COMPANY table LinqDB.
    '[Create by  on November, 20 2011]
    Public Class UsersResponseCompanyLinqDB
        Public sub UsersResponseCompanyLinqDB()

        End Sub 
        ' USERS_RESPONSE_COMPANY
        Const _tableName As String = "USERS_RESPONSE_COMPANY"
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
        Dim _GRP_CODE As String = ""
        Dim _AC_CODE As String = ""
        Dim _AC_NAME As String = ""
        Dim _POL_YEAR As Long = 0
        Dim _POL_NO As String = ""
        Dim _USER_GPO_ID As String = ""
        Dim _LANGUAGE As Char = ""
        Dim _INPUT_PERSON As String = ""
        Dim _CREATE_DTTM As DateTime = New DateTime(1,1,1)
        Dim _MNT_DTTM As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_GRP_CODE", DbType:="VarChar(10) NOT NULL ",CanBeNull:=false)>  _
        Public Property GRP_CODE() As String
            Get
                Return _GRP_CODE
            End Get
            Set(ByVal value As String)
               _GRP_CODE = value
            End Set
        End Property 
        <Column(Storage:="_AC_CODE", DbType:="VarChar(10) NOT NULL ",CanBeNull:=false)>  _
        Public Property AC_CODE() As String
            Get
                Return _AC_CODE
            End Get
            Set(ByVal value As String)
               _AC_CODE = value
            End Set
        End Property
        <Column(Storage:="_AC_NAME", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property AC_NAME() As String
            Get
                Return _AC_NAME
            End Get
            Set(ByVal value As String)
                _AC_NAME = value
            End Set
        End Property
        <Column(Storage:="_POL_YEAR", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property POL_YEAR() As Long
            Get
                Return _POL_YEAR
            End Get
            Set(ByVal value As Long)
               _POL_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_POL_NO", DbType:="VarChar(15) NOT NULL ",CanBeNull:=false)>  _
        Public Property POL_NO() As String
            Get
                Return _POL_NO
            End Get
            Set(ByVal value As String)
               _POL_NO = value
            End Set
        End Property 
        <Column(Storage:="_USER_GPO_ID", DbType:="VarChar(8) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_GPO_ID() As String
            Get
                Return _USER_GPO_ID
            End Get
            Set(ByVal value As String)
               _USER_GPO_ID = value
            End Set
        End Property 
        <Column(Storage:="_LANGUAGE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property LANGUAGE() As Char
            Get
                Return _LANGUAGE
            End Get
            Set(ByVal value As Char)
               _LANGUAGE = value
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
        <Column(Storage:="_MNT_DTTM", DbType:="DateTime")>  _
        Public Property MNT_DTTM() As  System.Nullable(Of DateTime) 
            Get
                Return _MNT_DTTM
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _MNT_DTTM = value
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
            _GRP_CODE = ""
            _AC_CODE = ""
            _AC_NAME = ""
            _POL_YEAR = 0
            _POL_NO = ""
            _USER_GPO_ID = ""
            _LANGUAGE = ""
            _INPUT_PERSON = ""
            _CREATE_DTTM = New DateTime(1,1,1)
            _MNT_DTTM = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the current data is updated to USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the current data is updated to USERS_RESPONSE_COMPANY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the record of USERS_RESPONSE_COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of USERS_RESPONSE_COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As UsersResponseCompanyLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of USERS_RESPONSE_COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As UsersResponseCompanyPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of USERS_RESPONSE_COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the current data is updated to USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the current data is deleted from USERS_RESPONSE_COMPANY table successfully.
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


        '/// Returns an indication whether the record of USERS_RESPONSE_COMPANY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("grp_code")) = False Then _grp_code = Rdr("grp_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then _AC_CODE = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_name")) = False Then _AC_NAME = Rdr("ac_name").ToString()
                        If Convert.IsDBNull(Rdr("pol_year")) = False Then _pol_year = Convert.ToInt32(Rdr("pol_year"))
                        If Convert.IsDBNull(Rdr("pol_no")) = False Then _pol_no = Rdr("pol_no").ToString()
                        If Convert.IsDBNull(Rdr("user_gpo_id")) = False Then _user_gpo_id = Rdr("user_gpo_id").ToString()
                        If Convert.IsDBNull(Rdr("language")) = False Then _language = Rdr("language").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then _input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then _create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then _mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))
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


        '/// Returns an indication whether the record of USERS_RESPONSE_COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As UsersResponseCompanyLinqDB
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
                        If Convert.IsDBNull(Rdr("grp_code")) = False Then _grp_code = Rdr("grp_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then _AC_CODE = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_name")) = False Then _AC_NAME = Rdr("ac_name").ToString()
                        If Convert.IsDBNull(Rdr("pol_year")) = False Then _pol_year = Convert.ToInt32(Rdr("pol_year"))
                        If Convert.IsDBNull(Rdr("pol_no")) = False Then _pol_no = Rdr("pol_no").ToString()
                        If Convert.IsDBNull(Rdr("user_gpo_id")) = False Then _user_gpo_id = Rdr("user_gpo_id").ToString()
                        If Convert.IsDBNull(Rdr("language")) = False Then _language = Rdr("language").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then _input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then _create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then _mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))

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


        '/// Returns an indication whether the Class Data of USERS_RESPONSE_COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As UsersResponseCompanyPara
            ClearData()
            _haveData  = False
            Dim ret As New UsersResponseCompanyPara
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
                        If Convert.IsDBNull(Rdr("grp_code")) = False Then ret.grp_code = Rdr("grp_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_code")) = False Then ret.AC_CODE = Rdr("ac_code").ToString()
                        If Convert.IsDBNull(Rdr("ac_name")) = False Then ret.AC_NAME = Rdr("ac_name").ToString()
                        If Convert.IsDBNull(Rdr("pol_year")) = False Then ret.pol_year = Convert.ToInt32(Rdr("pol_year"))
                        If Convert.IsDBNull(Rdr("pol_no")) = False Then ret.pol_no = Rdr("pol_no").ToString()
                        If Convert.IsDBNull(Rdr("user_gpo_id")) = False Then ret.user_gpo_id = Rdr("user_gpo_id").ToString()
                        If Convert.IsDBNull(Rdr("language")) = False Then ret.language = Rdr("language").ToString()
                        If Convert.IsDBNull(Rdr("input_person")) = False Then ret.input_person = Rdr("input_person").ToString()
                        If Convert.IsDBNull(Rdr("create_dttm")) = False Then ret.create_dttm = Convert.ToDateTime(Rdr("create_dttm"))
                        If Convert.IsDBNull(Rdr("mnt_dttm")) = False Then ret.mnt_dttm = Convert.ToDateTime(Rdr("mnt_dttm"))

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


        'Get Insert Statement for table USERS_RESPONSE_COMPANY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & TableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USER_ID, GRP_CODE, AC_CODE, AC_NAME, POL_YEAR, POL_NO, USER_GPO_ID, LANGUAGE, INPUT_PERSON, CREATE_DTTM, MNT_DTTM)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USER_ID) & ", "
                sql += DB.SetString(_GRP_CODE) & ", "
                Sql += DB.SetString(_AC_CODE) & ", "
                Sql += DB.SetString(_AC_NAME) & ", "
                sql += DB.SetDouble(_POL_YEAR) & ", "
                sql += DB.SetString(_POL_NO) & ", "
                sql += DB.SetString(_USER_GPO_ID) & ", "
                sql += DB.SetString(_LANGUAGE) & ", "
                sql += DB.SetString(_INPUT_PERSON) & ", "
                sql += DB.SetDateTime(_CREATE_DTTM) & ", "
                sql += DB.SetDateTime(_MNT_DTTM)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table USERS_RESPONSE_COMPANY
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
                Sql += "GRP_CODE = " & DB.SetString(_GRP_CODE) & ", "
                Sql += "AC_CODE = " & DB.SetString(_AC_CODE) & ", "
                Sql += "AC_NAME = " & DB.SetString(_AC_NAME) & ", "
                Sql += "POL_YEAR = " & DB.SetDouble(_POL_YEAR) & ", "
                Sql += "POL_NO = " & DB.SetString(_POL_NO) & ", "
                Sql += "USER_GPO_ID = " & DB.SetString(_USER_GPO_ID) & ", "
                Sql += "LANGUAGE = " & DB.SetString(_LANGUAGE) & ", "
                Sql += "INPUT_PERSON = " & DB.SetString(_INPUT_PERSON) & ", "
                Sql += "CREATE_DTTM = " & DB.SetDateTime(_CREATE_DTTM) & ", "
                Sql += "MNT_DTTM = " & DB.SetDateTime(_MNT_DTTM) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table USERS_RESPONSE_COMPANY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table USERS_RESPONSE_COMPANY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
