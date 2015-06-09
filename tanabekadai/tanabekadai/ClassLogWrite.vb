'LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "書きたい内容")
Public Class ClassLogWrite
    Private LogWrite As System.IO.StreamWriter
    Private JobQueue As Queue(Of JobLog) = New Queue(Of JobLog)
    Private JobCount As Integer
    Private SyncJobObj As Object = New Object
    Private ThreadInterbal As Integer = 10

#Region "構造体"
    Private Structure JobLog
        Dim JobName As String
        Dim JobMessage As String
        Dim JobTime As Date

        Sub New(ByVal name As String, ByVal LogMes As String, ByVal Time As Date)
            Me.JobName = name
            Me.JobMessage = LogMes
            Me.JobTime = Time
        End Sub
    End Structure
#End Region

    Public Sub New()
        'コンストラクタ
        JobQueue.Clear()
        MyClass.WriteLog("ClassLogWrite.New", "---------------   LogWrite Start   ---------------")
        Dim LogThread As Threading.Thread = New Threading.Thread(AddressOf CheckJob)
        LogThread.IsBackground = True
        LogThread.Start()

    End Sub

    Protected Overrides Sub Finalize()
        'デストラクタ
        MyClass.LogWrite_pro("ClassLogWrite.Finalize", "---------------   LogWrite END   ---------------", DateTime.Now)
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' WriteLogJob追加
    ''' </summary>
    ''' <param name="name">実行した場所 str</param>
    ''' <param name="message">Logに書き込む内容 str</param>
    ''' <remarks></remarks>
    Public Sub WriteLog(ByVal name As String, ByVal message As String)
        Try
            Dim LogMes As JobLog = New JobLog(name, message, DateTime.Now)
            SyncLock SyncJobObj
                JobQueue.Enqueue(LogMes)
            End SyncLock
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub StartLogThread()
        Try
            Dim Thread As Threading.Thread = New Threading.Thread(AddressOf CheckJob)
            Thread.IsBackground = True
            Thread.Start()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CheckJob()
        Try
            Do
                SyncLock SyncJobObj
                    JobCount = JobQueue.Count
                End SyncLock
                If JobQueue.Count <= 0 Then
                    Threading.Thread.Sleep(ThreadInterbal)
                    Continue Do
                Else
                    Dim JobContents As JobLog

                    SyncLock SyncJobObj
                        JobContents = JobQueue.Dequeue
                    End SyncLock

                    LogWrite_pro(JobContents.JobName, JobContents.JobMessage, JobContents.JobTime)
                    Threading.Thread.Sleep(ThreadInterbal)
                End If
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LogWrite_pro(ByVal name As String, ByVal Mes As String, ByVal Time As Date)
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
            Dim sbLog As System.Text.StringBuilder = New System.Text.StringBuilder

            LogWrite = New System.IO.StreamWriter(".\LOG\" & DateTime.Today.ToString("dd") & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))

            LogWrite.WriteLine(Time.ToString("yyyy/MM/dd hh:mm:ss.fff") & vbTab & name & vbTab & vbTab & Mes)
            LogWrite.Close()

        Catch ex As Exception
            MsgBox("実行時エラー" & MyName & vbCrLf & ex.ToString)
            LogWrite.Close()
        End Try
    End Sub
End Class
