Imports Oracle.DataAccess.Client

Public Class BookMst
#Region "共通変数"
    Dim htClassification As Hashtable = New Hashtable
    Dim sInStoreCode As String
#End Region

    Private Sub ButtonList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonList.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "一覧押下")
            Dim ShowBookList As BookList = New BookList
            ShowBookList.Owner = Me
            ShowBookList.StartPosition = FormStartPosition.CenterParent
            ShowBookList.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BookMst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            'フォーカスが入力できる物以外にあったのならISBNボックスに移動

            If TextBoxISBN.Enabled Then
                If Me.ActiveControl.Name <> "TextBoxBookName1" And Me.ActiveControl.Name <> "TextBoxBookName2" _
                And Me.ActiveControl.Name <> "TextBoxRemarks" And Me.ActiveControl.Name <> "TextBoxISBN" Then

                    'フォーカスを移動させると全選択になって次の文字が消えてしまうので
                    '一旦フォーカスしてから押したボタンを再度入力後カーソルを移動
                    Me.ActiveControl = Me.TextBoxISBN
                    'キーコードはChrにキャストするだけで文字になる
                    Me.TextBoxISBN.Text = Chr(e.KeyCode).ToString.ToLower
                    Me.TextBoxISBN.SelectionStart = TextBoxISBN.Text.Length
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub FirstSetting()
        Try
            'DB仕様に合わせた初期設定
            TextBoxISBN.MaxLength = 13
            TextBoxBookName1.MaxLength = 20
            TextBoxBookName2.MaxLength = 20
            TextBoxRemarks.MaxLength = 40

            '初期設定
            TextBoxFlg.ReadOnly = True
            TextBoxGroup.ReadOnly = True
            TextBoxPublisher.ReadOnly = True
            TextBoxBook.ReadOnly = True
            TextBoxCD.ReadOnly = True
            ComboClassification.Items.Add("--分類選択--")
            ComboShelf.Items.Add("--棚選択--")

            Dim ClassificationList As String()
            Dim ClassificationCdList As String()
            Dim ShelfNumberList As String()
            'If Not OraCla.Connect Then
            '    Dim Relogin As ReLogin = New ReLogin
            '    Relogin.Owner = Me
            '    Relogin.StartPosition = FormStartPosition.CenterParent
            '    Relogin.ShowDialog()
            'End If
            'Dim ClassificationList As String() = CheckOdp("SELECT * FROM BUNRUI_MST", "BUNRUI_NAME")

            Do
                CheckOdp(Me)
                ClassificationList = OraCla.GetDBList("SELECT * FROM BUNRUI_MST", "BUNRUI_NAME")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            Do
                CheckOdp(Me)
                ClassificationCdList = OraCla.GetDBList("SELECT * FROM BUNRUI_MST", "BUNRUI_CD")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            Do
                CheckOdp(Me)
                ShelfNumberList = OraCla.GetDBList("SELECT TANA_NO || '-' || DAN_NO AS TANA_NO FROM TANA_MST", "TANA_NO")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            '分類リスト取得
            Dim i As Integer = 0
            While ClassificationList.Length > i
                ComboClassification.Items.Add(ClassificationList(i))
                htClassification.Add(ClassificationCdList(i), ClassificationList(i))
                i += 1
            End While

            '棚リスト取得
            i = 0
            While ShelfNumberList.Length > i
                ComboShelf.Items.Add(ShelfNumberList(i))
                i += 1
            End While

            ComboClassification.SelectedIndex = 0
            ComboShelf.SelectedIndex = 0
            Me.KeyPreview = True
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "初期設定終了")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSignUp.Click
        Try
            Dim sbDBSignUp As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sClassificationCD As String

            Do
                CheckOdp(Me)
                sClassificationCD = OraCla.GetStrValue _
                                 ("SELECT BUNRUI_CD FROM BUNRUI_MST WHERE BUNRUI_NAME = '" & ComboClassification.Text & "'")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            Dim sCheckBox As String = "0"

            If CheckLendingban.Checked Then
                sCheckBox = "2"
            End If


            If TextBoxBookName1.Text = "" Or TextBoxBookName2.Text = "" Or TextBoxRemarks.Text = "" Then
                MsgBox("空欄項目があります")
                Exit Sub
            End If

            If ComboClassification.SelectedIndex = 0 Or ComboShelf.SelectedIndex = 0 Then
                MsgBox("分類と棚を設定してください")
                Exit Sub
            End If



            If ButtonSignUp.Text = "登録" Then
                'テキストが登録の場合

                sbDBSignUp.Append("INSERT INTO BOOK_MST")
                sbDBSignUp.Append(" VALUES('" & TextBoxISBN.Text)
                sbDBSignUp.Append("', '" & TextBoxBookName1.Text)
                sbDBSignUp.Append("', '" & TextBoxBookName2.Text)
                sbDBSignUp.Append("', '" & sClassificationCD)
                sbDBSignUp.Append("', '" & ComboShelf.Text.Substring(0, 3))
                sbDBSignUp.Append("', '" & ComboShelf.Text.Substring(4, 2))
                sbDBSignUp.Append("', '" & sCheckBox)
                sbDBSignUp.Append("', '" & TextBoxRemarks.Text)
                sbDBSignUp.Append("', SYSDATE, SYSDATE)")
                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try
                        OraCla.OraCmdExecute(sbDBSignUp.ToString)
                        OraCla.OraCommit()
                        MsgBox("登録完了")
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録完了 SQL : " & sbDBSignUp.ToString)
                        ButtonSignUp.Text = "更新"
                        TextBoxISBN.Enabled = True
                    Catch ex As Exception
                        OraCla.OraRollBack()
                        MsgBox("データベースエラー" & vbCrLf & "すでに登録されているか、無効なコードです。")
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "登録失敗 SQL : " & sbDBSignUp.ToString)
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            Else
                'テキストが更新の場合

                sbDBSignUp.Append("UPDATE BOOK_MST SET BOOK1_NAME = '" & TextBoxBookName1.Text)
                sbDBSignUp.Append("', BOOK2_NAME = '" & TextBoxBookName2.Text)
                sbDBSignUp.Append("', BUNRUI_CD = '" & sClassificationCD)
                sbDBSignUp.Append("', TANA_NO = '" & ComboShelf.Text.Substring(0, 3))
                sbDBSignUp.Append("', DAN_NO = '" & ComboShelf.Text.Substring(4, 2))
                sbDBSignUp.Append("', RENTAL_STATUS = '" & sCheckBox)
                sbDBSignUp.Append("', BIKO = '" & TextBoxRemarks.Text)
                sbDBSignUp.Append("', UPDATE_DATE = SYSDATE")
                sbDBSignUp.Append(" WHERE ISBN_CD = '" & TextBoxISBN.Text & "'")
                'sbDBSignUp.Append(" FOR UPDATE")
                'sbDBSignUp.Append(" DDL_LOCK_TIMEOUT = 15") どっちもSQLが最後まで書かれていませんと出てだめ

                Do
                    CheckOdp(Me)
                    OraCla.TransactionStart()
                    Try

                        If OraCla.OraCmdExecute(sbDBSignUp.ToString) Then
                            MsgBox("更新完了")
                            OraCla.OraCommit()
                            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新完了 SQL : " & sbDBSignUp.ToString)
                        Else
                            MsgBox("更新エラー" & vbCrLf & "更新出来ませんでした")
                            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新失敗 SQL : " & sbDBSignUp.ToString)
                            OraCla.OraRollBack()
                        End If
                    Catch ex As Exception
                        MsgBox("更新エラー" & vbCrLf & "更新出来ませんでした")
                        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "更新失敗 SQL : " & sbDBSignUp.ToString)
                        OraCla.OraRollBack()
                    End Try
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect

            End If
            Dim sbSetting As System.Text.StringBuilder = New System.Text.StringBuilder
            'sbSetting.AppendFormat()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub TextBoxISBN_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBoxISBN.PreviewKeyDown
        Try
            '13桁の時エンターを押したら実行
            If e.KeyCode = Keys.Enter And TextBoxISBN.TextLength = 13 Then
                IsbnCodeSetting()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub IsbnCodeSetting()
        Try
            TextBoxFlg.Text = TextBoxISBN.Text.Substring(0, 3)
            TextBoxGroup.Text = TextBoxISBN.Text.Substring(3, 1)
            TextBoxPublisher.Text = TextBoxISBN.Text.Substring(4, 5)
            TextBoxBook.Text = TextBoxISBN.Text.Substring(9, 3)
            TextBoxCD.Text = TextBoxISBN.Text.Substring(12, 1)

            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sISBNCode As String = TextBoxISBN.Text
            sbSqlCmd.AppendFormat("SELECT * FROM BOOK_MST WHERE ISBN_CD = '{0}'", sISBNCode)

            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "SELECT終了 :" & sISBNCode)

            Dim orISBNList As OracleDataReader
            Do
                CheckOdp(Me)
                orISBNList = OraCla.GetDBReader(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            If orISBNList.Read Then
                '登録済みのISBNコードの場合
                'orISBNList : 0=ISBNCD 1=Bookname1 2=Bookname2 3=BunruiCD 4=TanaNo 5=DanNo
                '            6=貸出状態 7=備考 8=登録日 9=更新日

                ButtonSignUp.Text = "更新"
                ButtonDelete.Enabled = True
                CheckLendingban.Enabled = True

                Dim sClassificationCd As String = orISBNList(3).ToString
                ComboClassification.SelectedIndex = ComboClassification.FindStringExact(CType(htClassification(sClassificationCd), String))
                Dim sTanaDan As String = orISBNList(4).ToString & "-" & orISBNList(5).ToString
                ComboShelf.SelectedIndex = ComboShelf.FindStringExact(sTanaDan)
                If orISBNList(6).ToString = "2" Then
                    '禁貸出の場合はチェックをつける
                    CheckLendingban.Checked = True
                ElseIf orISBNList(6).ToString = "1" Then
                    '貸出中ならば禁貸出のチェックをつけられないようにする
                    CheckLendingban.Checked = False
                    CheckLendingban.Enabled = False
                End If
                TextBoxBookName1.Text = orISBNList(1).ToString
                TextBoxBookName2.Text = orISBNList(2).ToString
                TextBoxRemarks.Text = orISBNList(7).ToString


            Else
                '登録していないISBNコードの場合
                ButtonSignUp.Text = "登録"
                InitPro()
                'Exit While
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 各プロパティ初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitPro()
        Try
            CheckLendingban.Enabled = True
            CheckLendingban.Checked = False
            ComboClassification.SelectedIndex = 0
            ComboShelf.SelectedIndex = 0
            TextBoxBookName1.Text = ""
            TextBoxBookName2.Text = ""
            TextBoxRemarks.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 削除ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        Try
            Dim sISBNCode As String
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "削除押下")
            Do
                CheckOdp(Me)
                sISBNCode = OraCla.GetStrValue("SELECT ISBN_CD FROM BOOK_MST WHERE ISBN_CD = '" & TextBoxISBN.Text & "'")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            If sISBNCode <> Nothing Then
                'ISBNコードがDB上にあるなら実行
                OraCla.TransactionStart()
                Try
                    OraCla.OraCmdExecute("DELETE FROM BOOK_MST WHERE ISBN_CD = '" & sISBNCode & "'")
                    OraCla.OraCommit()
                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "Delete完了 : " & sISBNCode)
                    InitPro()
                    MsgBox("削除しました。")
                Catch ex As Exception
                    OraCla.OraRollBack()
                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "Delete失敗 : " & sISBNCode)
                    MsgBox("削除失敗しました")
                End Try

            Else
                'DBにないとき実行
                MsgBox("そのISBNコードは存在しません。")
                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "そのISBNコードは存在しません : " & sISBNCode)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#Region "コンストラクタ"

    Public Sub New()
        Try
            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()
            FirstSetting()
            TextBoxISBN.Text = ""
            ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub New(ByVal ISBNCode As String)
        Try
            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()
            FirstSetting()
            TextBoxISBN.Text = ISBNCode
            TextBoxISBN.Enabled = False
            IsbnCodeSetting()
            ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region


End Class