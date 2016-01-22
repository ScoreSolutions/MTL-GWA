
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for CONTACT_US table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="CONTACT_US")>  _
    Public Class ContactUsPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MENU_ID As  System.Nullable(Of Long)  = 0
        Dim _ACCOUNT_CODE As  String  = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _REPLY_MAIL As String = ""
        Dim _SEND_TYPE As String = ""

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
        <Column(Storage:="_MENU_ID", DbType:="BigInt")>  _
        Public Property MENU_ID() As  System.Nullable(Of Long) 
            Get
                Return _MENU_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MENU_ID = value
            End Set
        End Property 
        <Column(Storage:="_ACCOUNT_CODE", DbType:="VarChar(50)")>  _
        Public Property ACCOUNT_CODE() As  String 
            Get
                Return _ACCOUNT_CODE
            End Get
            Set(ByVal value As  String )
               _ACCOUNT_CODE = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(4000)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_REPLY_MAIL", DbType:="VarChar(200)")>  _
        Public Property REPLY_MAIL() As  String 
            Get
                Return _REPLY_MAIL
            End Get
            Set(ByVal value As  String )
               _REPLY_MAIL = value
            End Set
        End Property
        <Column(Storage:="_SEND_TYPE", DbType:="Char(1)")> _
        Public Property SEND_TYPE() As String
            Get
                Return _SEND_TYPE
            End Get
            Set(ByVal value As String)
                _SEND_TYPE = value
            End Set
        End Property


    End Class
End Namespace
