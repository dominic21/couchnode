#Region "インポート"

Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

#End Region

Public Class ClassOraOdp

#Region "内部変数"

    Private sOraServer As String
    Private sOraUser As String
    Private sOraPass As String
    Private OraConnect As OracleConnection = New OracleConnection
    Private OraCmd As OracleCommand = New OracleCommand
    Private Tran As OracleTransaction
    Private da As OracleDataAdapter
    Private ds As DataSet
    Private cb As OracleCommandBuilder
    Private _sErrMessage As String
    Private _Connect As Boolean
    Private p_ErrNo As Integer

#End Region

#Region "プロパティ"

    ''' <summary>
    '''接続状態プロパティ 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Boolean オープン:True クローズ:False</returns>
    ''' <remarks></remarks>
    ''' 
    Public ReadOnly Property Connect() As Boolean
        Get
            If OraConnect.State <> ConnectionState.Open Then
                _Connect = False
            Else
                _Connect = True
            End If
            Return _Connect
        End Get
    End Property

    ''' <summary>
    ''' オラクルエラーメッセージプロパティ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property sErrMessage()
        Get
            Return _sErrMessage
        End Get
    End Property

#End Region


#Region "内部関数"

    Public Sub CheckInstance()
        Try
            _sErrMessage = ""
            If OraConnect Is Nothing Then
                OraConnect = New OracleConnection
            End If
            If OraCmd Is Nothing Then
                OraCmd = New OracleCommand
            End If
        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try

    End Sub

    ''' <summary>
    ''' ログイン設定
    ''' </summary>
    ''' <returns>bool メソッドが全て実行されたらTrue</returns>
    ''' <remarks></remarks>
    Public Function Login() As Boolean
        Dim flg As Boolean = False
        Try
            _sErrMessage = ""
            If OraConnect.State <> ConnectionState.Open Then
                If OraConnect.ConnectionString = "" Then
                    sOraUser = "IWASAWA"
                    sOraPass = "IWASAWA"
                    sOraServer = "BARNET"
                    Dim sConnect As String = "Data Source=" & sOraServer & ";User ID=" & sOraUser & "; Password=" & sOraPass & ";"
                    OraConnect.ConnectionString = sConnect
                End If

                OraConnect.Open()
                OraCmd.Connection = OraConnect
                flg = True
            Else
                flg = True
            End If

            Return flg
        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' 再ログインスレッド設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReLogin()
        Try
            _sErrMessage = ""
            Dim Thread As Threading.Thread = New Threading.Thread(AddressOf LoginAgain)
            Thread.IsBackground = True
            Thread.Start()
        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try
    End Sub

    ''' <summary>
    ''' ReLoginから呼び出されるログインループ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoginAgain()
        Try
            _sErrMessage = ""
            '別スレッドを立ててログインループ
            While OraConnect.State <> ConnectionState.Open
                MyClass.Login()
            End While

        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try

    End Sub

    ''' <summary>
    ''' 切断設定
    ''' </summary>
    ''' <returns>bool メソッドが全て実行されたらTrue</returns>
    ''' <remarks></remarks>
    Public Function DisConnect() As Boolean
        Dim flg As Boolean = False
        Try
            _sErrMessage = ""
            If OraCmd IsNot Nothing Then
                OraCmd.Dispose()
            End If
            OraCmd = Nothing

            If OraConnect IsNot Nothing Then
                If OraConnect.State <> ConnectionState.Closed Then
                    OraConnect.Close()
                End If
                OraConnect.Dispose()
            End If
            OraConnect = Nothing
            flg = True
            Return flg
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return flg
        End Try
    End Function

    ''' <summary>
    ''' テーブル取得
    ''' </summary>
    ''' <param name="sSQL">SQLコマンド</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OraDgvSetting(ByVal sSQL As String) As System.Data.DataTable
        Try
            _sErrMessage = ""
            OraCmd.CommandText = sSQL
            OraCmd.CommandType = CommandType.Text
            OraCmd.Connection = OraConnect
            ds = New DataSet()
            da = New OracleDataAdapter(OraCmd)
            cb = New OracleCommandBuilder(da)
            da.Fill(ds)
            Return ds.Tables(0)
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
            Return Nothing
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' SQL実行
    ''' </summary>
    ''' <param name="sCmdSql">str SQL文</param>
    ''' <remarks></remarks>
    Public Function OraCmdExecute(ByVal sCmdSql As String) As Boolean
        Try
            _sErrMessage = ""
            OraCmd.CommandText = sCmdSql
            If OraCmd.ExecuteNonQuery() <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
            Return Nothing
        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' DBReader取得
    ''' </summary>
    ''' <param name="sOraCmd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDBReader(ByVal sOraCmd As String) As OracleDataReader
        Try
            _sErrMessage = ""
            Dim DBReader As OracleDataReader
            OraCmd.CommandText = sOraCmd
            DBReader = OraCmd.ExecuteReader

            Return DBReader
            'Dim DBLine() As Object
            'If DBReader.Read Then
            '    Dim i As Integer = 0
            '    While i < DBReader.FieldCount
            '        ReDim Preserve DBLine(i)
            '        DBLine(i) = DBReader(i)
            '        i += 1
            '    End While
            'End If
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
            Return Nothing
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return Nothing
        End Try


    End Function


    ''' <summary>
    ''' DB配列取得（列）Readerで良くない？
    ''' </summary>
    ''' <returns>1次配列str</returns>
    ''' <remarks></remarks>
    Public Function GetDBList(ByVal sOraCmd As String, ByVal Value As String) As String()
        Try
            _sErrMessage = ""
            Dim DBreader As OracleDataReader
            Dim sList(0) As String
            OraCmd.CommandText = sOraCmd
            DBreader = OraCmd.ExecuteReader

            Dim i As Integer = 0
            While DBreader.Read
                ReDim Preserve sList(i)
                sList(i) = DBreader(Value).ToString
                i += 1
            End While

            Return sList

        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
            Return Nothing
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' DB値取得
    ''' </summary>
    ''' <param name="sOraCmd">str 役職名</param>
    ''' <returns>str セレクトした値</returns>
    ''' <remarks></remarks>
    Public Function GetStrValue(ByVal sOraCmd As String) As String
        Try
            _sErrMessage = ""
            If OraConnect.State.ToString <> "Open" Then
                Login()
            End If
            Dim Value As String = Nothing

            OraCmd.CommandText = sOraCmd
            Value = CStr(OraCmd.ExecuteScalar)

            Return Value
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
            Return Nothing
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' トランザクション
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TransactionStart()
        Try
            _sErrMessage = ""
            Tran = OraCmd.Connection.BeginTransaction
            OraCmd.Transaction = Tran
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
        Catch ex As Exception
            _sErrMessage = ex.ToString
        End Try
    End Sub

    ''' <summary>
    ''' コミット
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OraCommit()
        Try
            _sErrMessage = ""
            Tran.Commit()
        Catch oex As OracleException
            p_ErrNo = oex.Number
            If OpenErrCheck() Then
                DisConnect()
            End If
            _sErrMessage = oex.ToString
        Catch ex As Exception
            _sErrMessage = ex.ToString
            OraCmd.Transaction.Dispose()
            OraCmd.Connection.BeginTransaction.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' ロールバック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OraRollBack()
        Try
            _sErrMessage = ""
            Tran.Rollback()
        Catch ex As Exception
            _sErrMessage = ex.ToString
            OraCmd.Transaction.Dispose()
            OraCmd.Connection.BeginTransaction.Dispose()
        End Try
    End Sub

#End Region

    'オープンエラーか？
    Private Function OpenErrCheck() As Boolean
        '接続エラーのチェック
        '(ORA-01033:Oracle の初期化または停止中です )
        '(ORA-01034:Oracle は使用できません )
        '(ORA-01089:即時停止処理中- 操作はできません )
        '(ORA-01090:停止処理中- 接続はできません)
        '(ORA-03113:通信チャネルでファイルの終わりが検出されました)
        '(ORA-03114:Oracleに接続されていません)
        '(ORA-03135:接続が失われました)
        '(ORA-12541:リスナーがありません。)
        '(ORA-12571:パケットの書込み機に障害が発生しました。)
        '(ORA-12170:接続タイムアウトが発生しました。)
        Try
            _sErrMessage = ""
            If p_ErrNo = 1033 Or p_ErrNo = 1034 Or p_ErrNo = 1089 Or p_ErrNo = 1090 Or _
               p_ErrNo = 3113 Or p_ErrNo = 3114 Or p_ErrNo = 3135 Or p_ErrNo = 12541 Or _
               p_ErrNo = 12571 Or p_ErrNo = 12170 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            _sErrMessage = ex.ToString
            Return False
        End Try

    End Function

End Class
