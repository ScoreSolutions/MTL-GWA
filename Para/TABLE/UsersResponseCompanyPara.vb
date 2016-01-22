
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for USERS_RESPONSE_COMPANY table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="USERS_RESPONSE_COMPANY")>  _
    Public Class UsersResponseCompanyPara

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


    End Class
End Namespace
