Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.Common.Utilities.SQLDB
Imports Para.VIEW
Imports Para.Common.Utilities

Namespace VIEW
    'Represents a transaction for v_menu_list view LinqDB.
    '[Create by  on November, 20 2011]
    Public Class VMenuListLinqDB
        Public sub VMenuListLinqDB()

        End Sub 
        ' v_menu_list
        Const _viewName As String = "v_menu_list"

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property ViewName As String
            Get
                Return _viewName
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
        Dim _MENU_TYPE As String = ""
        Dim _MENU_ID As  System.Nullable(Of Long)  = 0
        Dim _MENU_CODE As  String  = ""
        Dim _MENU_NAME_THAI As  String  = ""
        Dim _MENU_NAME_ENG As  String  = ""
        Dim _MENU_DESC_THAI As  String  = ""
        Dim _MENU_DESC_ENG As  String  = ""
        Dim _MENU_ORDER_SEQ As  System.Nullable(Of Long)  = 0
        Dim _MENU_ACTIVE As  System.Nullable(Of Char)  = ""
        Dim _REF_MENU_ID As  System.Nullable(Of Long)  = 0
        Dim _SCREEN_MENU_ID As  System.Nullable(Of Long)  = 0
        Dim _MENU_SCREEN_NAME_THAI As  String  = ""
        Dim _MENU_URL As  String  = ""
        Dim _MODULE_ID As Long = 0
        Dim _MODULE_NAME_THAI As String = ""
        Dim _MODULE_NAME_ENG As  String  = ""
        Dim _MODULE_DESC_THAI As  String  = ""
        Dim _MODULE_DESC_ENG As  String  = ""
        Dim _MODULE_ORDER_SEQ As Long = 0
        Dim _MODULE_ACTIVE As Char = ""
        Dim _SCREEN_MODULE_ID As  System.Nullable(Of Long)  = 0
        Dim _MODULE_SCREEN_NAME_THAI As  String  = ""
        Dim _MODULE_URL As  String  = ""

        'Generate Field Property 
        <Column(Storage:="_MENU_TYPE", DbType:="VarChar(6) NOT NULL ",CanBeNull:=false)>  _
        Public Property MENU_TYPE() As String
            Get
                Return _MENU_TYPE
            End Get
            Set(ByVal value As String)
               _MENU_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_MENU_ID", DbType:="BigInt")>  _
        Public Property MENU_ID() As  System.Nullable(Of Long) 
            Get
                Return _MENU_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MENU_ID = value
            End Set
        End Property 
        <Column(Storage:="_MENU_CODE", DbType:="VarChar(50)")>  _
        Public Property MENU_CODE() As  String 
            Get
                Return _MENU_CODE
            End Get
            Set(ByVal value As  String )
               _MENU_CODE = value
            End Set
        End Property 
        <Column(Storage:="_MENU_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property MENU_NAME_THAI() As  String 
            Get
                Return _MENU_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _MENU_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MENU_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property MENU_NAME_ENG() As  String 
            Get
                Return _MENU_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _MENU_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_MENU_DESC_THAI", DbType:="VarChar(255)")>  _
        Public Property MENU_DESC_THAI() As  String 
            Get
                Return _MENU_DESC_THAI
            End Get
            Set(ByVal value As  String )
               _MENU_DESC_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MENU_DESC_ENG", DbType:="VarChar(255)")>  _
        Public Property MENU_DESC_ENG() As  String 
            Get
                Return _MENU_DESC_ENG
            End Get
            Set(ByVal value As  String )
               _MENU_DESC_ENG = value
            End Set
        End Property 
        <Column(Storage:="_MENU_ORDER_SEQ", DbType:="Int")>  _
        Public Property MENU_ORDER_SEQ() As  System.Nullable(Of Long) 
            Get
                Return _MENU_ORDER_SEQ
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MENU_ORDER_SEQ = value
            End Set
        End Property 
        <Column(Storage:="_MENU_ACTIVE", DbType:="Char(1)")>  _
        Public Property MENU_ACTIVE() As  System.Nullable(Of Char) 
            Get
                Return _MENU_ACTIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _MENU_ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_REF_MENU_ID", DbType:="BigInt")>  _
        Public Property REF_MENU_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_MENU_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_MENU_ID = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_MENU_ID", DbType:="BigInt")>  _
        Public Property SCREEN_MENU_ID() As  System.Nullable(Of Long) 
            Get
                Return _SCREEN_MENU_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SCREEN_MENU_ID = value
            End Set
        End Property 
        <Column(Storage:="_MENU_SCREEN_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property MENU_SCREEN_NAME_THAI() As  String 
            Get
                Return _MENU_SCREEN_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _MENU_SCREEN_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MENU_URL", DbType:="VarChar(255)")>  _
        Public Property MENU_URL() As  String 
            Get
                Return _MENU_URL
            End Get
            Set(ByVal value As  String )
               _MENU_URL = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_ID = value
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
        <Column(Storage:="_MODULE_ORDER_SEQ", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ORDER_SEQ() As Long
            Get
                Return _MODULE_ORDER_SEQ
            End Get
            Set(ByVal value As Long)
               _MODULE_ORDER_SEQ = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ACTIVE() As Char
            Get
                Return _MODULE_ACTIVE
            End Get
            Set(ByVal value As Char)
               _MODULE_ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_MODULE_ID", DbType:="BigInt")>  _
        Public Property SCREEN_MODULE_ID() As  System.Nullable(Of Long) 
            Get
                Return _SCREEN_MODULE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SCREEN_MODULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_SCREEN_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property MODULE_SCREEN_NAME_THAI() As  String 
            Get
                Return _MODULE_SCREEN_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _MODULE_SCREEN_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_URL", DbType:="VarChar(255)")>  _
        Public Property MODULE_URL() As  String 
            Get
                Return _MODULE_URL
            End Get
            Set(ByVal value As  String )
               _MODULE_URL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _MENU_TYPE = ""
            _MENU_ID = 0
            _MENU_CODE = ""
            _MENU_NAME_THAI = ""
            _MENU_NAME_ENG = ""
            _MENU_DESC_THAI = ""
            _MENU_DESC_ENG = ""
            _MENU_ORDER_SEQ = 0
            _MENU_ACTIVE = ""
            _REF_MENU_ID = 0
            _SCREEN_MENU_ID = 0
            _MENU_SCREEN_NAME_THAI = ""
            _MENU_URL = ""
            _MODULE_ID = 0
            _MODULE_NAME_THAI = ""
            _MODULE_NAME_ENG = ""
            _MODULE_DESC_THAI = ""
            _MODULE_DESC_ENG = ""
            _MODULE_ORDER_SEQ = 0
            _MODULE_ACTIVE = ""
            _SCREEN_MODULE_ID = 0
            _MODULE_SCREEN_NAME_THAI = ""
            _MODULE_URL = ""
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


        '/// Returns an indication whether the record of v_menu_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the record of v_menu_list by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("menu_type")) = False Then _menu_type = Rdr("menu_type").ToString()
                        If Convert.IsDBNull(Rdr("menu_id")) = False Then _menu_id = Convert.ToInt64(Rdr("menu_id"))
                        If Convert.IsDBNull(Rdr("menu_code")) = False Then _menu_code = Rdr("menu_code").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_thai")) = False Then _menu_name_thai = Rdr("menu_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_eng")) = False Then _menu_name_eng = Rdr("menu_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_thai")) = False Then _menu_desc_thai = Rdr("menu_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_eng")) = False Then _menu_desc_eng = Rdr("menu_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_order_seq")) = False Then _menu_order_seq = Convert.ToInt32(Rdr("menu_order_seq"))
                        If Convert.IsDBNull(Rdr("menu_active")) = False Then _menu_active = Rdr("menu_active").ToString()
                        If Convert.IsDBNull(Rdr("ref_menu_id")) = False Then _ref_menu_id = Convert.ToInt64(Rdr("ref_menu_id"))
                        If Convert.IsDBNull(Rdr("screen_menu_id")) = False Then _screen_menu_id = Convert.ToInt64(Rdr("screen_menu_id"))
                        If Convert.IsDBNull(Rdr("menu_screen_name_thai")) = False Then _menu_screen_name_thai = Rdr("menu_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then _menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then _module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then _module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then _module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then _module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_order_seq")) = False Then _module_order_seq = Convert.ToInt32(Rdr("module_order_seq"))
                        If Convert.IsDBNull(Rdr("module_active")) = False Then _module_active = Rdr("module_active").ToString()
                        If Convert.IsDBNull(Rdr("screen_module_id")) = False Then _screen_module_id = Convert.ToInt64(Rdr("screen_module_id"))
                        If Convert.IsDBNull(Rdr("module_screen_name_thai")) = False Then _module_screen_name_thai = Rdr("module_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_url")) = False Then _module_url = Rdr("module_url").ToString()
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


        '/// Returns an indication whether the record of v_menu_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As VMenuListLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("menu_type")) = False Then _menu_type = Rdr("menu_type").ToString()
                        If Convert.IsDBNull(Rdr("menu_id")) = False Then _menu_id = Convert.ToInt64(Rdr("menu_id"))
                        If Convert.IsDBNull(Rdr("menu_code")) = False Then _menu_code = Rdr("menu_code").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_thai")) = False Then _menu_name_thai = Rdr("menu_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_eng")) = False Then _menu_name_eng = Rdr("menu_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_thai")) = False Then _menu_desc_thai = Rdr("menu_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_eng")) = False Then _menu_desc_eng = Rdr("menu_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_order_seq")) = False Then _menu_order_seq = Convert.ToInt32(Rdr("menu_order_seq"))
                        If Convert.IsDBNull(Rdr("menu_active")) = False Then _menu_active = Rdr("menu_active").ToString()
                        If Convert.IsDBNull(Rdr("ref_menu_id")) = False Then _ref_menu_id = Convert.ToInt64(Rdr("ref_menu_id"))
                        If Convert.IsDBNull(Rdr("screen_menu_id")) = False Then _screen_menu_id = Convert.ToInt64(Rdr("screen_menu_id"))
                        If Convert.IsDBNull(Rdr("menu_screen_name_thai")) = False Then _menu_screen_name_thai = Rdr("menu_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then _menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then _module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then _module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then _module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then _module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_order_seq")) = False Then _module_order_seq = Convert.ToInt32(Rdr("module_order_seq"))
                        If Convert.IsDBNull(Rdr("module_active")) = False Then _module_active = Rdr("module_active").ToString()
                        If Convert.IsDBNull(Rdr("screen_module_id")) = False Then _screen_module_id = Convert.ToInt64(Rdr("screen_module_id"))
                        If Convert.IsDBNull(Rdr("module_screen_name_thai")) = False Then _module_screen_name_thai = Rdr("module_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_url")) = False Then _module_url = Rdr("module_url").ToString()

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


        '/// Returns an indication whether the Class Data of v_menu_list by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As VMenuListPara
            ClearData()
            _haveData  = False
            Dim ret As New VMenuListPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("menu_type")) = False Then ret.menu_type = Rdr("menu_type").ToString()
                        If Convert.IsDBNull(Rdr("menu_id")) = False Then ret.menu_id = Convert.ToInt64(Rdr("menu_id"))
                        If Convert.IsDBNull(Rdr("menu_code")) = False Then ret.menu_code = Rdr("menu_code").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_thai")) = False Then ret.menu_name_thai = Rdr("menu_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_name_eng")) = False Then ret.menu_name_eng = Rdr("menu_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_thai")) = False Then ret.menu_desc_thai = Rdr("menu_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_desc_eng")) = False Then ret.menu_desc_eng = Rdr("menu_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("menu_order_seq")) = False Then ret.menu_order_seq = Convert.ToInt32(Rdr("menu_order_seq"))
                        If Convert.IsDBNull(Rdr("menu_active")) = False Then ret.menu_active = Rdr("menu_active").ToString()
                        If Convert.IsDBNull(Rdr("ref_menu_id")) = False Then ret.ref_menu_id = Convert.ToInt64(Rdr("ref_menu_id"))
                        If Convert.IsDBNull(Rdr("screen_menu_id")) = False Then ret.screen_menu_id = Convert.ToInt64(Rdr("screen_menu_id"))
                        If Convert.IsDBNull(Rdr("menu_screen_name_thai")) = False Then ret.menu_screen_name_thai = Rdr("menu_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("menu_url")) = False Then ret.menu_url = Rdr("menu_url").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then ret.module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("module_name_thai")) = False Then ret.module_name_thai = Rdr("module_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_name_eng")) = False Then ret.module_name_eng = Rdr("module_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_thai")) = False Then ret.module_desc_thai = Rdr("module_desc_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_desc_eng")) = False Then ret.module_desc_eng = Rdr("module_desc_eng").ToString()
                        If Convert.IsDBNull(Rdr("module_order_seq")) = False Then ret.module_order_seq = Convert.ToInt32(Rdr("module_order_seq"))
                        If Convert.IsDBNull(Rdr("module_active")) = False Then ret.module_active = Rdr("module_active").ToString()
                        If Convert.IsDBNull(Rdr("screen_module_id")) = False Then ret.screen_module_id = Convert.ToInt64(Rdr("screen_module_id"))
                        If Convert.IsDBNull(Rdr("module_screen_name_thai")) = False Then ret.module_screen_name_thai = Rdr("module_screen_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("module_url")) = False Then ret.module_url = Rdr("module_url").ToString()

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


        'Get Select Statement for table v_menu_list
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & viewName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
