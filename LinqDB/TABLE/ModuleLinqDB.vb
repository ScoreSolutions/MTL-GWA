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
    'Represents a transaction for MODULE table LinqDB.
    '[Create by  on November, 20 2011]
    Public Class ModuleLinqDB
        Public sub ModuleLinqDB()

        End Sub 
        ' MODULE
        Const _tableName As String = "MODULE"
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
        Dim _SCREEN_ID As  System.Nullable(Of Long)  = 0
        Dim _MODULE_CODE As String = ""
        Dim _MODULE_NAME_THAI As String = ""
        Dim _MODULE_NAME_ENG As  String  = ""
        Dim _MODULE_ICON As String = ""
        Dim _MODULE_DESC_THAI As  String  = ""
        Dim _MODULE_DESC_ENG As  String  = ""
        Dim _ORDER_SEQ As Long = 0
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
        <Column(Storage:="_SCREEN_ID", DbType:="BigInt")>  _
        Public Property SCREEN_ID() As  System.Nullable(Of Long) 
            Get
                Return _SCREEN_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SCREEN_ID = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_CODE() As String
            Get
                Return _MODULE_CODE
            End Get
            Set(ByVal value As String)
               _MODULE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_NAME_THAI", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_NAME_THAI() As String
            Get
                Return _MODULE_NAME_THAI
            End Get
            Set(ByVal value As String)
               _MODULE_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_NAME_ENG", DbType:="VarChar(100)")>  _
        Public Property MODULE_NAME_ENG() As  String 
            Get
                Return _MODULE_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _MODULE_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_ICON", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ICON() As String
            Get
                Return _MODULE_ICON
            End Get
            Set(ByVal value As String)
               _MODULE_ICON = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_DESC_THAI", DbType:="VarChar(500)")>  _
        Public Property MODULE_DESC_THAI() As  String 
            Get
                Return _MODULE_DESC_THAI
            End Get
            Set(ByVal value As  String )
               _MODULE_DESC_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_DESC_ENG", DbType:="VarChar(500)")>  _
        Public Property MODULE_DESC_ENG() As  String 
            Get
                Return _MODULE_DESC_ENG
            End Get
            Set(ByVal value As  String )
               _MODULE_DESC_ENG = value
            End Set
        End Property 
        <Column(Storage:="_ORDER_SEQ", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ORDER_SEQ() As Long
            Get
                Return _ORDER_SEQ
            End Get
            Set(ByVal value As Long)
               _ORDER_SEQ = value
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
            _SCREEN_ID = 0
            _MODULE_CODE = ""
            _MODULE_NAME_THAI = ""
            _MODULE_NAME_ENG = ""
            _MODULE_ICON = ""
            _MODULE_DESC_THAI = ""
            _MODULE_DESC_ENG = ""
            _ORDER_SEQ = 0
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


        '/// Returns an indication whether the current data is inserted into MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MODULE table successfully.
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


        '/// Returns an indication whether the record of MODULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MODULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As ModuleLinqDB
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of MODULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As ModulePara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MODULE by specified MODULE_CODE key is retrieved successfully.
        '/// <param name=cMODULE_CODE>The MODULE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMODULE_CODE(cMODULE_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("MODULE_CODE = " & DB.SetString(cMODULE_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MODULE by specified MODULE_CODE key is retrieved successfully.
        '/// <param name=cMODULE_CODE>The MODULE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMODULE_CODE(cMODULE_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MODULE_CODE = " & DB.SetString(cMODULE_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MODULE by specified MODULE_NAME_THAI key is retrieved successfully.
        '/// <param name=cMODULE_NAME_THAI>The MODULE_NAME_THAI key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMODULE_NAME_THAI(cMODULE_NAME_THAI As String, trans As SQLTransaction) As Boolean
            Return doChkData("MODULE_NAME_THAI = " & DB.SetString(cMODULE_NAME_THAI) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MODULE by specified MODULE_NAME_THAI key is retrieved successfully.
        '/// <param name=cMODULE_NAME_THAI>The MODULE_NAME_THAI key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMODULE_NAME_THAI(cMODULE_NAME_THAI As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MODULE_NAME_THAI = " & DB.SetString(cMODULE_NAME_THAI) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MODULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MODULE table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MODULE table successfully.
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


        '/// Returns an indication whether the record of MODULE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("screen_id")) = False Then _screen_id = Convert.ToInt64(Rdr("screen_id"))
                        If Convert.IsDBNull(Rdr("module_code")) = False Then _module_code = Rdr("module_code").ToString()
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then _module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then _module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_icon")) = False Then _module_icon = Rdr("module_icon").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then _module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then _module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt32(Rdr("order_seq"))
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


        '/// Returns an indication whether the record of MODULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As ModuleLinqDB
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
                        If Convert.IsDBNull(Rdr("screen_id")) = False Then _screen_id = Convert.ToInt64(Rdr("screen_id"))
                        If Convert.IsDBNull(Rdr("module_code")) = False Then _module_code = Rdr("module_code").ToString()
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then _module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then _module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_icon")) = False Then _module_icon = Rdr("module_icon").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then _module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then _module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt32(Rdr("order_seq"))
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : MENU Column :module_id
                        Dim Menu_module_idItem As New MenuLinqDB
                        _MENU_module_id = Menu_module_idItem.GetDataList("module_id = " & _ID, "", Nothing)

                        'Child Table Name : ROLE_SCREEN Column :module_id
                        Dim RoleScreen_module_idItem As New RoleScreenLinqDB
                        _ROLE_SCREEN_module_id = RoleScreen_module_idItem.GetDataList("module_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of MODULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As ModulePara
            ClearData()
            _haveData  = False
            Dim ret As New ModulePara
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
                        If Convert.IsDBNull(Rdr("screen_id")) = False Then ret.screen_id = Convert.ToInt64(Rdr("screen_id"))
                        If Convert.IsDBNull(Rdr("module_code")) = False Then ret.module_code = Rdr("module_code").ToString()
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then ret.module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then ret.module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_icon")) = False Then ret.module_icon = Rdr("module_icon").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then ret.module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then ret.module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("order_seq")) = False Then ret.order_seq = Convert.ToInt32(Rdr("order_seq"))
                        If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : MENU Column :module_id
                        Dim Menu_module_idItem As New MenuLinqDB
                        _MENU_module_id = Menu_module_idItem.GetDataList("module_id = " & ret.id, "", Nothing)
                        ret.CHILD_MENU_module_id = _MENU_module_id

                        'Child Table Name : ROLE_SCREEN Column :module_id
                        Dim RoleScreen_module_idItem As New RoleScreenLinqDB
                        _ROLE_SCREEN_module_id = RoleScreen_module_idItem.GetDataList("module_id = " & ret.id, "", Nothing)
                        ret.CHILD_ROLE_SCREEN_module_id = _ROLE_SCREEN_module_id


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


        'Get Insert Statement for table MODULE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, SCREEN_ID, MODULE_CODE, MODULE_NAME_THAI, MODULE_NAME_ENG, MODULE_ICON, MODULE_DESC_THAI, MODULE_DESC_ENG, ORDER_SEQ, ACTIVE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_SCREEN_ID) & ", "
                sql += DB.SetString(_MODULE_CODE) & ", "
                sql += DB.SetString(_MODULE_NAME_THAI) & ", "
                sql += DB.SetString(_MODULE_NAME_ENG) & ", "
                sql += DB.SetString(_MODULE_ICON) & ", "
                sql += DB.SetString(_MODULE_DESC_THAI) & ", "
                sql += DB.SetString(_MODULE_DESC_ENG) & ", "
                sql += DB.SetDouble(_ORDER_SEQ) & ", "
                sql += DB.SetString(_ACTIVE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MODULE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "SCREEN_ID = " & DB.SetDouble(_SCREEN_ID) & ", "
                Sql += "MODULE_CODE = " & DB.SetString(_MODULE_CODE) & ", "
                Sql += "MODULE_NAME_THAI = " & DB.SetString(_MODULE_NAME_THAI) & ", "
                Sql += "MODULE_NAME_ENG = " & DB.SetString(_MODULE_NAME_ENG) & ", "
                Sql += "MODULE_ICON = " & DB.SetString(_MODULE_ICON) & ", "
                Sql += "MODULE_DESC_THAI = " & DB.SetString(_MODULE_DESC_THAI) & ", "
                Sql += "MODULE_DESC_ENG = " & DB.SetString(_MODULE_DESC_ENG) & ", "
                Sql += "ORDER_SEQ = " & DB.SetDouble(_ORDER_SEQ) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MODULE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MODULE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _MENU_module_id As DataTable
       Dim _ROLE_SCREEN_module_id As DataTable

       Public Property CHILD_MENU_module_id() As DataTable
           Get
               Return _MENU_module_id
           End Get
           Set(ByVal value As DataTable)
               _MENU_module_id = value
           End Set
       End Property
       Public Property CHILD_ROLE_SCREEN_module_id() As DataTable
           Get
               Return _ROLE_SCREEN_module_id
           End Get
           Set(ByVal value As DataTable)
               _ROLE_SCREEN_module_id = value
           End Set
       End Property
    End Class
End Namespace
