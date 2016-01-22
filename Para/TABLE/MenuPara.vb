
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for MENU table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="MENU")>  _
    Public Class MenuPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MODULE_ID As Long = 0
        Dim _SCREEN_ID As Long = 0
        Dim _MENU_CODE As String = ""
        Dim _MENU_NAME_THAI As String = ""
        Dim _MENU_NAME_ENG As  String  = ""
        Dim _MENU_DESC_THAI As  String  = ""
        Dim _MENU_DESC_ENG As  String  = ""
        Dim _MENU_ICON As  String  = ""
        Dim _ORDER_SEQ As Long = 0
        Dim _ACTIVE As Char = ""
        Dim _REF_MENU_ID As Long = 0

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
        <Column(Storage:="_MODULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property SCREEN_ID() As Long
            Get
                Return _SCREEN_ID
            End Get
            Set(ByVal value As Long)
               _SCREEN_ID = value
            End Set
        End Property 
        <Column(Storage:="_MENU_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MENU_CODE() As String
            Get
                Return _MENU_CODE
            End Get
            Set(ByVal value As String)
               _MENU_CODE = value
            End Set
        End Property 
        <Column(Storage:="_MENU_NAME_THAI", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MENU_NAME_THAI() As String
            Get
                Return _MENU_NAME_THAI
            End Get
            Set(ByVal value As String)
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
        <Column(Storage:="_MENU_ICON", DbType:="VarChar(255)")>  _
        Public Property MENU_ICON() As  String 
            Get
                Return _MENU_ICON
            End Get
            Set(ByVal value As  String )
               _MENU_ICON = value
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
        <Column(Storage:="_REF_MENU_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property REF_MENU_ID() As Long
            Get
                Return _REF_MENU_ID
            End Get
            Set(ByVal value As Long)
               _REF_MENU_ID = value
            End Set
        End Property 


            'Define Child Table 

       Dim _CONTACT_US_id As DataTable

       Public Property CHILD_CONTACT_US_id() As DataTable
           Get
               Return _CONTACT_US_id
           End Get
           Set(ByVal value As DataTable)
               _CONTACT_US_id = value
           End Set
       End Property
    End Class
End Namespace
