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
    'Represents a transaction for SCREEN table LinqDB.
    '[Create by  on November, 20 2011]
    Public Class ScreenLinqDB
        Public sub ScreenLinqDB()

        End Sub 
        ' SCREEN
        Const _tableName As String = "SCREEN"
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
        Dim _SCREEN_CODE As String = ""
        Dim _SCREEN_NAME_THAI As String = ""
        Dim _SCREEN_NAME_ENG As  String  = ""
        Dim _SCREEN_URL As String = ""
        Dim _SCREEN_DESC_THAI As  String  = ""
        Dim _SCREEN_DESC_ENG As  String  = ""
        Dim _ACTIVE As Char = ""

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
        <Column(Storage:="_SCREEN_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCREEN_CODE() As String
            Get
                Return _SCREEN_CODE
            End Get
            Set(ByVal value As String)
               _SCREEN_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_NAME_THAI", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCREEN_NAME_THAI() As String
            Get
                Return _SCREEN_NAME_THAI
            End Get
            Set(ByVal value As String)
               _SCREEN_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property SCREEN_NAME_ENG() As  String 
            Get
                Return _SCREEN_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _SCREEN_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_URL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SCREEN_URL() As String
            Get
                Return _SCREEN_URL
            End Get
            Set(ByVal value As String)
               _SCREEN_URL = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_DESC_THAI", DbType:="VarChar(255)")>  _
        Public Property SCREEN_DESC_THAI() As  String 
            Get
                Return _SCREEN_DESC_THAI
            End Get
            Set(ByVal value As  String )
               _SCREEN_DESC_THAI = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_DESC_ENG", DbType:="VarChar(255)")>  _
        Public Property SCREEN_DESC_ENG() As  String 
            Get
                Return _SCREEN_DESC_ENG
            End Get
            Set(ByVal value As  String )
               _SCREEN_DESC_ENG = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _SCREEN_CODE = ""
            _SCREEN_NAME_THAI = ""
            _SCREEN_NAME_ENG = ""
            _SCREEN_URL = ""
            _SCREEN_DESC_THAI = ""
            _SCREEN_DESC_ENG = ""
            _ACTIVE = ""
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


        '/// Returns an indication whether the current data is inserted into SCREEN table successfully.
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


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
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


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
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


        '/// Returns an indication whether the record of SCREEN by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of SCREEN by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As ScreenLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of SCREEN by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As ScreenPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified SCREEN_CODE key is retrieved successfully.
        '/// <param name=cSCREEN_CODE>The SCREEN_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCREEN_CODE(cSCREEN_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of SCREEN by specified SCREEN_CODE key is retrieved successfully.
        '/// <param name=cSCREEN_CODE>The SCREEN_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySCREEN_CODE(cSCREEN_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified SCREEN_NAME_THAI key is retrieved successfully.
        '/// <param name=cSCREEN_NAME_THAI>The SCREEN_NAME_THAI key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCREEN_NAME_THAI(cSCREEN_NAME_THAI As String, trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_NAME_THAI = " & DB.SetString(cSCREEN_NAME_THAI) & " ", trans)
        End Function

        '/// Returns an duplicate data record of SCREEN by specified SCREEN_NAME_THAI key is retrieved successfully.
        '/// <param name=cSCREEN_NAME_THAI>The SCREEN_NAME_THAI key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySCREEN_NAME_THAI(cSCREEN_NAME_THAI As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_NAME_THAI = " & DB.SetString(cSCREEN_NAME_THAI) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into SCREEN table successfully.
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


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
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


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
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


        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("screen_code")) = False Then _screen_code = Rdr("screen_code").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_thai")) = False Then _screen_name_thai = Rdr("screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_eng")) = False Then _screen_name_eng = Rdr("screen_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("screen_url")) = False Then _screen_url = Rdr("screen_url").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_thai")) = False Then _screen_desc_thai = Rdr("screen_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_eng")) = False Then _screen_desc_eng = Rdr("screen_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
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


        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As ScreenLinqDB
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
                        If Convert.IsDBNull(Rdr("screen_code")) = False Then _screen_code = Rdr("screen_code").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_thai")) = False Then _screen_name_thai = Rdr("screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_eng")) = False Then _screen_name_eng = Rdr("screen_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("screen_url")) = False Then _screen_url = Rdr("screen_url").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_thai")) = False Then _screen_desc_thai = Rdr("screen_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_eng")) = False Then _screen_desc_eng = Rdr("screen_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : MENU Column :screen_id
                        Dim Menu_screen_idItem As New MenuLinqDB
                        _MENU_screen_id = Menu_screen_idItem.GetDataList("screen_id = " & _ID, "", Nothing)

                        'Child Table Name : MODULE Column :screen_id
                        Dim Module_screen_idItem As New ModuleLinqDB
                        _MODULE_screen_id = Module_screen_idItem.GetDataList("screen_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As ScreenPara
            ClearData()
            _haveData  = False
            Dim ret As New ScreenPara
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
                        If Convert.IsDBNull(Rdr("screen_code")) = False Then ret.screen_code = Rdr("screen_code").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_thai")) = False Then ret.screen_name_thai = Rdr("screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_name_eng")) = False Then ret.screen_name_eng = Rdr("screen_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("screen_url")) = False Then ret.screen_url = Rdr("screen_url").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_thai")) = False Then ret.screen_desc_thai = Rdr("screen_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc_eng")) = False Then ret.screen_desc_eng = Rdr("screen_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : MENU Column :screen_id
                        Dim Menu_screen_idItem As New MenuLinqDB
                        _MENU_screen_id = Menu_screen_idItem.GetDataList("screen_id = " & ret.id, "", Nothing)
                        ret.CHILD_MENU_screen_id = _MENU_screen_id

                        'Child Table Name : MODULE Column :screen_id
                        Dim Module_screen_idItem As New ModuleLinqDB
                        _MODULE_screen_id = Module_screen_idItem.GetDataList("screen_id = " & ret.id, "", Nothing)
                        ret.CHILD_MODULE_screen_id = _MODULE_screen_id


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


        'Get Insert Statement for table SCREEN
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, SCREEN_CODE, SCREEN_NAME_THAI, SCREEN_NAME_ENG, SCREEN_URL, SCREEN_DESC_THAI, SCREEN_DESC_ENG, ACTIVE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_SCREEN_CODE) & ", "
                sql += DB.SetString(_SCREEN_NAME_THAI) & ", "
                sql += DB.SetString(_SCREEN_NAME_ENG) & ", "
                sql += DB.SetString(_SCREEN_URL) & ", "
                sql += DB.SetString(_SCREEN_DESC_THAI) & ", "
                sql += DB.SetString(_SCREEN_DESC_ENG) & ", "
                sql += DB.SetString(_ACTIVE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table SCREEN
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "SCREEN_CODE = " & DB.SetString(_SCREEN_CODE) & ", "
                Sql += "SCREEN_NAME_THAI = " & DB.SetString(_SCREEN_NAME_THAI) & ", "
                Sql += "SCREEN_NAME_ENG = " & DB.SetString(_SCREEN_NAME_ENG) & ", "
                Sql += "SCREEN_URL = " & DB.SetString(_SCREEN_URL) & ", "
                Sql += "SCREEN_DESC_THAI = " & DB.SetString(_SCREEN_DESC_THAI) & ", "
                Sql += "SCREEN_DESC_ENG = " & DB.SetString(_SCREEN_DESC_ENG) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table SCREEN
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table SCREEN
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _MENU_screen_id As DataTable
       Dim _MODULE_screen_id As DataTable

       Public Property CHILD_MENU_screen_id() As DataTable
           Get
               Return _MENU_screen_id
           End Get
           Set(ByVal value As DataTable)
               _MENU_screen_id = value
           End Set
       End Property
       Public Property CHILD_MODULE_screen_id() As DataTable
           Get
               Return _MODULE_screen_id
           End Get
           Set(ByVal value As DataTable)
               _MODULE_screen_id = value
           End Set
       End Property
    End Class
End Namespace
