Public Class ErrForm

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "OK押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class