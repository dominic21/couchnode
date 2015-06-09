Public Class ReLogin
    Private Timer As System.Timers.Timer
    Private ReadOnly SyncTimer As Object = New Object

    Private Sub ReLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            OraCla.ReLogin()
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "再ログイン中...")
            Timer = New System.Timers.Timer
            AddHandler Timer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf ConnectionCheck)
            Timer.Interval = 1000
            Timer.AutoReset = True
            Timer.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Delegate Sub FormCloseDelegate()

    Private Sub FormClose()
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "再ログイン成功")
            Timer.Enabled = False
            Timer.Dispose()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ConnectionCheck()
        Try
            SyncLock SyncTimer
                If OraCla.Connect Then
                    Invoke(New FormCloseDelegate(AddressOf FormClose))
                End If
            End SyncLock
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class