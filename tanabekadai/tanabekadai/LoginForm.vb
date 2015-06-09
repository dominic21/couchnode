Public Class Formlogin

    Private Sub TextBoxStaff_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxStaff.KeyPress
        Try
            '数字以外が入力された時は無反応(バックスペースとエンターは反応するようにする)
            If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        Catch ex As Exception
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "エラー" & ex.ToString)
        End Try

    End Sub
    Private Sub TextBoxStaff_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBoxStaff.PreviewKeyDown
        Try
            '押されたボタンがエンターだった場合の処理
            If e.KeyCode = Keys.Enter Then
                Dim cmd As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim result As String
                cmd.AppendFormat("SELECT SYAIN_NAME FROM TANABE_SYAIN_MST WHERE SYAIN_CD = '{0}'", TextBoxStaff.Text)

                Do
                    CheckOdp(Me)
                    result = OraCla.GetStrValue(cmd.ToString)
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

                LblStaffName.Text = result
                'データベースに社員コードがなかったときエラー画面表示
                If result = "" Then
                    Dim ShowErrForm As ErrForm = New ErrForm
                    ButtonStart.Enabled = False
                    ShowErrForm.Owner = Me
                    ShowErrForm.StartPosition = FormStartPosition.CenterParent
                    ShowErrForm.ShowDialog()
                Else
                    ButtonStart.Enabled = True
                End If

                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "SELECT終了")
            End If
        Catch ex As Exception
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "エラー" & ex.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnd.Click
        Try
            OraCla.DisConnect()
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "終了ボタン押下")
            End
        Catch ex As Exception
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "エラー" & ex.ToString)
        End Try
    End Sub


    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        Try
            Dim ShowMenuForm As MenuForm = New MenuForm
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "開始ボタン押下 社員名: " & LblStaffName.Text)
            Me.Visible = False
            ShowMenuForm.Owner = Me
            ShowMenuForm.StartPosition = FormStartPosition.CenterParent
            ShowMenuForm.ShowDialog()
        Catch ex As Exception
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "エラー" & ex.ToString)
        End Try

    End Sub

    Private Sub Formlogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            TextBoxStaff.ImeMode = ImeMode.Off
            TextBoxStaff.MaxLength = 4
            LblStaffName.Text = ""
            ButtonStart.Enabled = False
            If Not OraCla.Login() Then
                MsgBox("データベース接続に失敗しました" & vbCrLf & "再ログインします")
                Dim Relogin As ReLogin = New ReLogin
                Relogin.Owner = Me
                Relogin.StartPosition = FormStartPosition.CenterParent
                Relogin.ShowDialog()
            End If

        Catch ex As Exception
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "エラー" & ex.ToString)
        End Try
    End Sub
End Class
