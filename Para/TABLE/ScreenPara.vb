
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for SCREEN table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="SCREEN")>  _
    Public Class ScreenPara

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
