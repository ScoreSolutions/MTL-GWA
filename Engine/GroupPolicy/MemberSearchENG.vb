Imports Para.CallWS
Imports Para.OutputWS
Imports LinqWS

Namespace GroupPolicy
    Public Class MemberSearchENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public Function SearchFromWS(ByVal para As InputGetQueryMemberPara) As DataTable
            
            'Call WebService
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetQueryMemberPara = ws.GetQueryMember(para)
            Dim dt As DataTable
            If output.MEMBER_LIST IsNot Nothing Then
                dt = output.MEMBER_LIST
            Else
                _err = ws.ErrorMessage
            End If

            Return dt
        End Function

        Public Function GetSectionList(ByVal inp As InputGetSectionNameListPara) As DataTable
            Dim ws As New WebGroupLinqWS
            Dim output As OutputGetSectionNameListPara = ws.GetSectionNameList(inp)
            Dim dt As DataTable
            If output.ISFOUND = "Y" Then
                dt = output.SEC_SEARCH_LIST
            Else
                _err = ws.ErrorMessage
            End If

            Return dt
        End Function
    End Class
End Namespace

