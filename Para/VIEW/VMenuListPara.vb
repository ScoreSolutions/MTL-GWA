
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace VIEW
    'Represents a transaction for v_menu_list view Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="v_menu_list")>  _
    Public Class VMenuListPara

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


    End Class
End Namespace
