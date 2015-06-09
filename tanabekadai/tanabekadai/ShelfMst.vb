Public Class ShelfMst

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ShelfMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '初期設定
            TextBoxShelf.MaxLength = 3
            TextBoxShelf.ImeMode = ImeMode.Off
            TextBoxStage.MaxLength = 2
            TextBoxStage.ImeMode = ImeMode.Off

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxShelf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxShelf.TextChanged
        Try

            If TextBoxStage.Text <> Nothing Then
                '棚Noが変わったとき段Noも入っていれば実行
                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "棚No: " & TextBoxShelf.Text & "段No: " & TextBoxStage.Text)
                SearchShelf()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxStage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxStage.TextChanged
        Try
            If TextBoxShelf.Text <> Nothing Then
                '段Noが変わったとき棚Noも入っていれば実行
                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "棚No: " & TextBoxShelf.Text & "段No: " & TextBoxStage.Text)
                SearchShelf()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SearchShelf()
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sShelf As String = TextBoxShelf.Text
            Dim sStage As String = TextBoxStage.Text
            Dim sRemarks As String = Nothing

            If sShelf <> Nothing And sStage <> Nothing Then
                sbSqlCmd.AppendFormat("SELECT BIKO FROM TANA_MST WHERE TANA_NO = '{0}' AND DAN_NO = '{1}'", sShelf, sStage)
                Do
                    CheckOdp(Me)
                    sRemarks = OraCla.GetStrValue(sbSqlCmd.ToString)
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            End If


            If sRemarks <> Nothing Then
                TextBoxRemarks.Text = sRemarks
                ButtonSignup.Text = "更新"
            Else
                TextBoxRemarks.Text = ""
                ButtonSignup.Text = "登録"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sShelf As String = TextBoxShelf.Text
            Dim sStage As String = TextBoxStage.Text
            Dim sCheck As String
            sbSqlCmd.AppendFormat("SELECT TANA_NO FROM TANA_MST WHERE TANA_NO = '{0}' AND DAN_NO = '{1}'", sShelf, sStage)
            Do
                CheckOdp(Me)
                sCheck = OraCla.GetStrValue(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect


            If sCheck <> Nothing Then
                '段NoがDB上にあるなら実行
                OraCla.TransactionStart()
                sbSqlCmd = New System.Text.StringBuilder
                sbSqlCmd.AppendFormat("DELETE FROM TANA_MST WHERE TANA_NO = '{0}' AND DAN_NO = '{1}'", sShelf, sStage)
                Try
                    Do
                        CheckOdp(Me)
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        OraCla.CheckInstance()
                    Loop While Not OraCla.Connect
                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "削除完了 SQL: " & sbSqlCmd.ToString)
                    MsgBox("削除しました。")
                    ButtonSignup.Text = "登録"
                    TextBoxShelf.Text = ""
                    TextBoxStage.Text = ""
                    TextBoxRemarks.Text = ""
                Catch ex As Exception
                    OraCla.OraRollBack()
                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "削除失敗 SQL: " & sbSqlCmd.ToString)
                    MsgBox("削除失敗しました")
                End Try

            Else
                'DBにないとき実行
                MsgBox("その棚は存在しません。")
                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "その棚は存在しません SQL: " & sbSqlCmd.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSignup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSignup.Click
        Try


            If TextBoxShelf.Text = Nothing Then
                MsgBox("棚Noを入力してください")
                Exit Sub
            ElseIf TextBoxStage.Text = Nothing Then
                MsgBox("段Noを入力してください")
                Exit Sub
            ElseIf TextBoxRemarks.Text = Nothing Then
                MsgBox("備考を入力してください")
                Exit Sub
            End If

            Dim sShelf As String = TextBoxShelf.Text
            Dim sStage As String = TextBoxStage.Text
            Dim sRemarks As String = TextBoxRemarks.Text
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            If ButtonSignup.Text = "登録" Then
                '登録の場合の処理
                sbSqlCmd.AppendFormat("INSERT INTO TANA_MST VALUES('{0}', ", sShelf)
                sbSqlCmd.AppendFormat("'{0}', '{1}')", sStage, sRemarks)
                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        MsgBox("登録完了")
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録完了 SQL: " & sbSqlCmd.ToString)
                        ButtonSignup.Text = "更新"
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録失敗 SQL: " & sbSqlCmd.ToString)
                        MsgBox("登録失敗")
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            Else
                '更新の場合の処理
                sbSqlCmd.AppendFormat("UPDATE TANA_MST SET TANA_NO = '{0}', ", sShelf)
                sbSqlCmd.AppendFormat("DAN_NO = '{0}', BIKO = '{1}'", sStage, sRemarks)
                sbSqlCmd.AppendFormat("WHERE TANA_NO = '{0}' AND DAN_NO = '{1}'", sShelf, sStage)
                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新完了 SQL: " & sbSqlCmd.ToString)
                        MsgBox("更新完了")
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新失敗 SQL: " & sbSqlCmd.ToString)
                        MsgBox("更新失敗")
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class