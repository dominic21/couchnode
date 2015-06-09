Public Class ClassificationMst

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSignup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSignup.Click
        Try

            If TextBoxClassificationCD.Text = Nothing Then
                MsgBox("分類コードを入力してください")
                Exit Sub
            ElseIf TextBoxClassificationName.Text = Nothing Then
                MsgBox("分類名を入力してください")
                Exit Sub
            End If

            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            If ButtonSignup.Text = "登録" Then
                '登録の場合の処理
                sbSqlCmd.AppendFormat("INSERT INTO BUNRUI_MST VALUES('{0}','{1}')", TextBoxClassificationCD.Text, TextBoxClassificationName.Text)

                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録完了 SQL : " & sbSqlCmd.ToString)
                        MsgBox("登録完了")
                        ButtonSignup.Text = "更新"
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録失敗 SQL : " & sbSqlCmd.ToString)
                        MsgBox("登録失敗")
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            Else
                '更新の場合の処理
                sbSqlCmd.AppendFormat("UPDATE BUNRUI_MST SET BUNRUI_CD = '{0}', ", TextBoxClassificationCD.Text)
                sbSqlCmd.AppendFormat("       BUNRUI_NAME = '{0}'", TextBoxClassificationName.Text)
                sbSqlCmd.AppendFormat("       WHERE BUNRUI_CD = '{0}'", TextBoxClassificationCD.Text)
                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新完了 SQL : " & sbSqlCmd.ToString)
                        MsgBox("更新完了")
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新失敗 SQL : " & sbSqlCmd.ToString)
                        MsgBox("更新失敗")
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        Try
            Dim sClassificationCode As String
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Do
                CheckOdp(Me)
                sClassificationCode = OraCla.GetStrValue("SELECT BUNRUI_CD FROM BUNRUI_MST WHERE BUNRUI_CD = '" & TextBoxClassificationCD.Text & "'")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect


            If sClassificationCode <> Nothing Then
                '分類コードがDB上にあるなら実行()
                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        sbSqlCmd.AppendFormat("DELETE FROM BUNRUI_MST WHERE BUNRUI_CD = '{0}'", sClassificationCode)
                        OraCla.OraCmdExecute(sbSqlCmd.ToString)
                        OraCla.OraCommit()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "削除完了 SQL : " & sbSqlCmd.ToString)
                        MsgBox("削除しました。")
                        TextBoxClassificationName.Text = ""
                        ButtonSignup.Text = "登録"
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "削除失敗 SQL : " & sbSqlCmd.ToString)
                        MsgBox("削除失敗しました")
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            Else
                'DBにないとき実行
                MsgBox("その分類コードは存在しません。")
                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "その分類コードは存在しません")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxClassificationCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxClassificationCD.TextChanged
        Try
            Dim sbClassificationCode As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sCD As String = TextBoxClassificationCD.Text
            Dim sClassificationName As String = Nothing

            If sCD <> Nothing Then
                sbClassificationCode.AppendFormat("SELECT BUNRUI_NAME FROM BUNRUI_MST WHERE BUNRUI_CD = {0}", sCD)
                Do
                    CheckOdp(Me)
                    sClassificationName = OraCla.GetStrValue(sbClassificationCode.ToString)
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            End If

            '分類コードがあればテキストに分類名表示、ボタンの表示切替
            If sClassificationName <> Nothing Then
                TextBoxClassificationName.Text = sClassificationName
                ButtonSignup.Text = "更新"
            Else
                ButtonSignup.Text = "登録"
                TextBoxClassificationName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ClassificationMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初期設定
        Try
            TextBoxClassificationCD.MaxLength = 2
            TextBoxClassificationCD.ImeMode = ImeMode.Off
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class