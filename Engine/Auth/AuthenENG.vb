Imports Para.TABLE
Imports LinqDB.TABLE
Imports Para.Common
Imports Engine.Common
Namespace Auth
    Public Class AuthenENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property

        Public Function CheckAuthen(ByVal menuID As Long, ByVal uData As UserProfilePara) As Boolean
            Return True
        End Function
        Public Function GetMenuList(ByVal whText As String, ByVal orderBy As String, ByVal UsetType As String, ByVal trans As DbTrans) As DataTable
            Dim sql As String = ""
            sql += " select m.id module_id, me.id menu_id, me.menu_name_thai + '(' + me.menu_name_eng + ')' menu_name, "
            sql += " m.module_name_thai + '(' + m.module_name_eng + ')' module_name, rs.id, m.order_seq module_order_seq , me.order_seq menu_order_seq "
            sql += " from module m "
            sql += " inner join menu me on me.module_id=m.id"
            sql += " left join role_screen rs on rs.module_id=m.id and rs.menu_id=me.id and rs.user_type = '" & UsetType & "'"
            sql += " where " & whText
            sql += " union all "
            sql += " select m.id module_id, null menu_id, null menu_name, "
            sql += " m.module_name_thai + '(' + m.module_name_eng + ')' module_name, rs.id, m.order_seq module_order_seq , null menu_order_seq "
            sql += " from module m "
            sql += " left join role_screen rs on rs.module_id=m.id  and rs.user_type = '" & UsetType & "' and rs.menu_id is null"
            sql += " inner join screen sc on sc.id=m.screen_id"
            sql += " where " & whText

            sql += " order by " & orderBy
            Dim lnq As New ScreenLinqDB
            Return lnq.GetListBySql(sql, trans.Trans)
        End Function
        Public Function SaveMenuAuth(ByVal UserID As String, ByVal dt As DataTable, ByVal UserType As String, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = True
            If DeleteMenuAuth(UserType, trans) = True Then
                Try
                    For Each dr As DataRow In dt.Rows
                        Dim lnq As New RoleScreenLinqDB
                        lnq.USER_TYPE = UserType
                        lnq.MODULE_ID = dr("module_id")
                        If Convert.IsDBNull(dr("menu_id")) = True Then
                            lnq.MENU_ID = Nothing
                        Else
                            lnq.MENU_ID = Convert.ToInt64(dr("menu_id"))
                        End If

                        lnq.ACTIVE = "Y"
                        If lnq.InsertData(UserID, trans.Trans) = False Then
                            ret = False
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    ret = False
                    _err = ex.Message
                End Try
            End If
            Return ret
        End Function

        Private Function DeleteMenuAuth(ByVal UserType As String, ByVal trans As DbTrans) As Boolean
            Dim sql As String = "delete from ROLE_SCREEN where user_type = '" & UserType & "'"
            Return LinqDB.Common.Utilities.SqlDB.ExecuteNonQuery(sql, trans.Trans) > 0
        End Function

        Public Function DeleteMenuAuth(ByVal vID As Long, ByVal trans As DbTrans) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New RoleScreenLinqDB
                ret = lnq.DeleteByPK(vID, trans.Trans)
            Catch ex As Exception
                ret = False
                _err = ex.Message
            End Try
            Return ret
        End Function
    End Class


End Namespace

