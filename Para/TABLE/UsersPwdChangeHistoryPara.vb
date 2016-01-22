
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for USERS_PWD_CHANGE_HISTORY table Parameter.
    '[Create by  on November, 20 2011]

    <Table(Name:="USERS_PWD_CHANGE_HISTORY")>  _
    Public Class UsersPwdChangeHistoryPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USER_ID As String = ""
        Dim _OLD_PASSWORD As String = ""
        Dim _NEW_PASSWORD As  String  = ""
        Dim _CHANGE_DATE As DateTime = New DateTime(1,1,1)

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
        <Column(Storage:="_OLD_PASSWORD", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property OLD_PASSWORD() As String
            Get
                Return _OLD_PASSWORD
            End Get
            Set(ByVal value As String)
               _OLD_PASSWORD = value
            End Set
        End Property 
        <Column(Storage:="_NEW_PASSWORD", DbType:="VarChar(500)")>  _
        Public Property NEW_PASSWORD() As  String 
            Get
                Return _NEW_PASSWORD
            End Get
            Set(ByVal value As  String )
               _NEW_PASSWORD = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_DATE() As DateTime
            Get
                Return _CHANGE_DATE
            End Get
            Set(ByVal value As DateTime)
               _CHANGE_DATE = value
            End Set
        End Property 


    End Class
End Namespace
