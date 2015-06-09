Public Class LogWriter
    Dim LogWrite As System.IO.StreamWriter

    Private Sub LogWrite_pro(ByVal name As String)
        Const MyName As String = "LogWrite_pro"
        Try
            Dim sFileName As String = ".\LOG\" & DateTime.Today.ToString("dd") & ".log"
            'LOGフォルダがなければカレントディレクトリにLOGフォルダを作る
            If System.IO.Directory.Exists(".\LOG") = False Then
                System.IO.Directory.CreateDirectory(".\LOG")
            End If

            '日付が同じで1ヶ月前のファイルなら削除
            If System.IO.File.Exists(sFileName) And System.IO.File.GetCreationTime(sFileName) < DateTime.Today.AddDays(-1) Then
                System.IO.File.Delete(sFileName)
            End If

            LogWrite = New System.IO.StreamWriter(".\LOG\" & DateTime.Today.ToString("dd") & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
            LogWrite.Write(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff") & vbTab & vbTab & name & vbCrLf)
            LogWrite.Close()

        Catch ex As Exception
            MsgBox("実行時エラー" & MyName & vbCrLf & ex.ToString)
            LogWrite.Close()
        End Try
    End Sub

End Class
