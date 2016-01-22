
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for USERS table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="USERS")>  _
    Public Class UsersPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_ID As String = ""
        Dim _USER_PASSWD As String = ""
        Dim _USER_TYPE As Char = ""
        Dim _USER_NAME_T As String = ""
        Dim _USER_NAME_E As  String  = ""
        Dim _BROKER_CODE As  String  = ""
        Dim _AC_CODE As  String  = ""
        Dim _COMPANY_NAME As String = ""
        Dim _PASSWD_DATE As DateTime = New DateTime(1,1,1)
        Dim _USER_S_DATE As DateTime = New DateTime(1,1,1)
        Dim _USER_E_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_LEVEL As Long = 0
        Dim _USER_EMAIL As String = ""
        Dim _USER_TEL As  String  = ""
        Dim _MARKET_EMAIL As String = ""
        Dim _MARKET_CC_EMAIL As String = ""
        Dim _CLAIM_EMAIL As String = ""
        Dim _CLAIM_CC_EMAIL As String = ""
        Dim _DISC_REASON As  String  = ""
        Dim _INPUT_PERSON As String = ""
        Dim _CREATE_DTTM As DateTime = New DateTime(1,1,1)
        Dim _MNT_DTTM As DateTime = New DateTime(1,1,1)
        Dim _IS_FIRST_LOGIN As  System.Nullable(Of Char)  = ""
        Dim _LOGIN_FAIL_COUNT As  System.Nullable(Of Long)  = 0
        Dim _LAST_LOGIN_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_USER_PASSWD", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_PASSWD() As String
            Get
                Return _USER_PASSWD
            End Get
            Set(ByVal value As String)
               _USER_PASSWD = value
            End Set
        End Property 
        <Column(Storage:="_USER_TYPE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_TYPE() As Char
            Get
                Return _USER_TYPE
            End Get
            Set(ByVal value As Char)
               _USER_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_T", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_NAME_T() As String
            Get
                Return _USER_NAME_T
            End Get
            Set(ByVal value As String)
               _USER_NAME_T = value
            End Set
        End Property 
        <Column(Storage:="_USER_NAME_E", DbType:="VarChar(100)")>  _
        Public Property USER_NAME_E() As  String 
            Get
                Return _USER_NAME_E
            End Get
            Set(ByVal value As  String )
               _USER_NAME_E = value
            End Set
        End Property 
        <Column(Storage:="_BROKER_CODE", DbType:="VarChar(8)")>  _
        Public Property BROKER_CODE() As  String 
            Get
                Return _BROKER_CODE
            End Get
            Set(ByVal value As  String )
               _BROKER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_AC_CODE", DbType:="VarChar(10)")>  _
        Public Property AC_CODE() As  String 
            Get
                Return _AC_CODE
            End Get
            Set(ByVal value As  String )
               _AC_CODE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_NAME() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_PASSWD_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property PASSWD_DATE() As DateTime
            Get
                Return _PASSWD_DATE
            End Get
            Set(ByVal value As DateTime)
               _PASSWD_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_S_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_S_DATE() As DateTime
            Get
                Return _USER_S_DATE
            End Get
            Set(ByVal value As DateTime)
               _USER_S_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_E_DATE", DbType:="DateTime")>  _
        Public Property USER_E_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _USER_E_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _USER_E_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USER_LEVEL", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_LEVEL() As Long
            Get
                Return _USER_LEVEL
            End Get
            Set(ByVal value As Long)
               _USER_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_USER_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property USER_EMAIL() As String
            Get
                Return _USER_EMAIL
            End Get
            Set(ByVal value As String)
               _USER_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_USER_TEL", DbType:="VarChar(10)")>  _
        Public Property USER_TEL() As  String 
            Get
                Return _USER_TEL
            End Get
            Set(ByVal value As  String )
               _USER_TEL = value
            End Set
        End Property 
        <Column(Storage:="_MARKET_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property MARKET_EMAIL() As String
            Get
                Return _MARKET_EMAIL
            End Get
            Set(ByVal value As String)
               _MARKET_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_MARKET_CC_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property MARKET_CC_EMAIL() As String
            Get
                Return _MARKET_CC_EMAIL
            End Get
            Set(ByVal value As String)
               _MARKET_CC_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_CLAIM_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLAIM_EMAIL() As String
            Get
                Return _CLAIM_EMAIL
            End Get
            Set(ByVal value As String)
               _CLAIM_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_CLAIM_CC_EMAIL", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLAIM_CC_EMAIL() As String
            Get
                Return _CLAIM_CC_EMAIL
            End Get
            Set(ByVal value As String)
               _CLAIM_CC_EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_DISC_REASON", DbType:="VarChar(100)")>  _
        Public Property DISC_REASON() As  String 
            Get
                Return _DISC_REASON
            End Get
            Set(ByVal value As  String )
               _DISC_REASON = value
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
        <Column(Storage:="_MNT_DTTM", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property MNT_DTTM() As DateTime
            Get
                Return _MNT_DTTM
            End Get
            Set(ByVal value As DateTime)
               _MNT_DTTM = value
            End Set
        End Property 
        <Column(Storage:="_IS_FIRST_LOGIN", DbType:="Char(1)")>  _
        Public Property IS_FIRST_LOGIN() As  System.Nullable(Of Char) 
            Get
                Return _IS_FIRST_LOGIN
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_FIRST_LOGIN = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_FAIL_COUNT", DbType:="Int")>  _
        Public Property LOGIN_FAIL_COUNT() As  System.Nullable(Of Long) 
            Get
                Return _LOGIN_FAIL_COUNT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _LOGIN_FAIL_COUNT = value
            End Set
        End Property 
        <Column(Storage:="_LAST_LOGIN_TIME", DbType:="DateTime")>  _
        Public Property LAST_LOGIN_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LAST_LOGIN_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LAST_LOGIN_TIME = value
            End Set
        End Property 


    End Class
End Namespace
