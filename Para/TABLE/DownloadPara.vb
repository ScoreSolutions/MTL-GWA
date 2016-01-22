
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOWNLOAD table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="DOWNLOAD")>  _
    Public Class DownloadPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOWNLOAD_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _IMPORT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _FILE_DESC As  String  = ""
        Dim _FILE_EXT As  String  = ""
        Dim _DOCUMENT_TYPE As  System.Nullable(Of Char)  = ""
        Dim _ACCOUNT_CODE As  String  = ""
        Dim _ORDER_SEQ As  System.Nullable(Of Long)  = 0
        Dim _ACTIVE As  System.Nullable(Of Char)  = ""

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
        <Column(Storage:="_DOWNLOAD_TYPE_ID", DbType:="BigInt")>  _
        Public Property DOWNLOAD_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOWNLOAD_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOWNLOAD_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_IMPORT_DATE", DbType:="DateTime")>  _
        Public Property IMPORT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _IMPORT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _IMPORT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_FILE_DESC", DbType:="VarChar(255)")>  _
        Public Property FILE_DESC() As  String 
            Get
                Return _FILE_DESC
            End Get
            Set(ByVal value As  String )
               _FILE_DESC = value
            End Set
        End Property 
        <Column(Storage:="_FILE_EXT", DbType:="VarChar(50)")>  _
        Public Property FILE_EXT() As  String 
            Get
                Return _FILE_EXT
            End Get
            Set(ByVal value As  String )
               _FILE_EXT = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_TYPE", DbType:="Char(1)")>  _
        Public Property DOCUMENT_TYPE() As  System.Nullable(Of Char) 
            Get
                Return _DOCUMENT_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _DOCUMENT_TYPE = value
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
        <Column(Storage:="_ORDER_SEQ", DbType:="Int")>  _
        Public Property ORDER_SEQ() As  System.Nullable(Of Long) 
            Get
                Return _ORDER_SEQ
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORDER_SEQ = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1)")>  _
        Public Property ACTIVE() As  System.Nullable(Of Char) 
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ACTIVE = value
            End Set
        End Property 


    End Class
End Namespace
