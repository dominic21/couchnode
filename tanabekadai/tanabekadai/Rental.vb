Imports Oracle.DataAccess.Client

Public Class Rental

    Dim htStaffCD As Hashtable = New Hashtable

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonHistry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHistry.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "一覧押下")
            Dim ShowRentalHistry As RentalHistry = New RentalHistry
            ShowRentalHistry.Owner = Me
            ShowRentalHistry.StartPosition = FormStartPosition.CenterParent
            ShowRentalHistry.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Rental_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            'フォーカスが入力できる物以外にあったのならISBNボックスに移動
            If Me.ActiveControl.Name <> "ComboStaffSelect" And Me.ActiveControl.Name <> "TextBoxISBN" Then

                'フォーカスを移動させると全選択になって次の文字が消えてしまうので
                '一旦フォーカスしてから押したボタンを再度入力後カーソルを移動
                Me.ActiveControl = Me.TextBoxISBN
                'キーコードはChrにキャストするだけで文字になる
                Me.TextBoxISBN.Text = Chr(e.KeyCode).ToString.ToLower
                Me.TextBoxISBN.SelectionStart = TextBoxISBN.Text.Length
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Rental_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim orColumn As OracleDataReader
            Dim sSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim iID As Integer = 0
            TextBoxISBN.MaxLength = 13
            Me.KeyPreview = True
            sSqlCmd.Append(" SELECT SYAIN_CD, SYAIN_NAME")
            sSqlCmd.Append(" FROM TANABE_SYAIN_MST ORDER BY SYAIN_CD")
            Do
                CheckOdp(Me)
                orColumn = OraCla.GetDBReader(sSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            ComboStaffSelect.Items.Add("--社員選択--")
            While orColumn.Read
                Dim sbName As System.Text.StringBuilder = New System.Text.StringBuilder
                iID = CInt(orColumn(0))
                sbName.Append(CStr(iID))
                sbName.Append(" : ")
                sbName.Append(orColumn(1))
                ComboStaffSelect.Items.Add(sbName.ToString)
                htStaffCD.Add(orColumn(1), orColumn(0))
            End While

            InitPro()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxISBN_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBoxISBN.PreviewKeyDown
        Try
            '13桁で押されたキーがエンターなら実行

            If TextBoxISBN.Text.Length = 13 And e.KeyCode = Keys.Enter Then
                IsbnDisplay()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub InitPro()
        Try
            'プロパティ初期化
            LblClassificationTxt.Text = ""
            LblShelfTxt.Text = ""
            LblBookNameTxt1.Text = ""
            LblBookNameTxt2.Text = ""
            LblRentalDate.Text = ""
            LblReturnDate.Text = ""
            LblStaffName.Text = ""
            LblStockTxt.Text = "貸出可能です"
            LblStock.Text = "在庫有"
            LblStockTxt.ForeColor = Color.Blue
            LblStock.BackColor = Color.LimeGreen
            ComboStaffSelect.SelectedIndex = 0
            ButtonRental.Text = "貸出"
            ButtonRental.Visible = True
            'ComboStaffSelect.Enabled = False テスト用にコメントアウトしてるだけ
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonRental_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRental.Click
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sbSqlCmd2 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sISBNCD As String = TextBoxISBN.Text
            Dim sRentalStatus As String
            sbSqlCmd.Append("      SELECT RENTAL_STATUS ")
            sbSqlCmd.AppendFormat("FROM BOOK_MST WHERE ISBN_CD = '{0}'", sISBNCD)

            Do
                CheckOdp(Me)
                sRentalStatus = OraCla.GetStrValue(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            If ButtonRental.Text = "貸出" Then
                '貸出の処理

                If sRentalStatus = "0" Then
                    '貸出可のままならば

                    If ComboStaffSelect.Text <> "--社員選択--" Then

                        sbSqlCmd = New System.Text.StringBuilder
                        sbSqlCmd2 = New System.Text.StringBuilder
                        'コンボボックスのテキストから":"の場所を探してその後の名前空間から名前を抜き出し、ハッシュテーブルから社員コード検索
                        '書籍マスタの貸出可を貸出中に変更
                        sbSqlCmd.Append("      INSERT INTO　RENTAL_MNG (ISBN_CD, RENTALS_DATE, SYAIN_CD, ORDER_NO) ")
                        sbSqlCmd.AppendFormat("       VALUES ('{0}', SYSDATE, '{1}', SYSDATE)", _
                                              sISBNCD, htStaffCD(ComboStaffSelect.Text.Substring(ComboStaffSelect.Text.IndexOf(":") + 2)))
                        sbSqlCmd2.Append("            UPDATE BOOK_MST SET RENTAL_STATUS = '1',")
                        sbSqlCmd2.AppendFormat("      UPDATE_DATE = SYSDATE WHERE ISBN_CD = '{0}'", sISBNCD)

                        Do
                            CheckOdp(Me)
                            OraCla.TransactionStart()
                            Try
                                If OraCla.OraCmdExecute(sbSqlCmd.ToString) And OraCla.OraCmdExecute(sbSqlCmd2.ToString) Then
                                    OraCla.OraCommit()
                                    InitPro()
                                    IsbnDisplay()
                                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出処理" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                                    MsgBox("貸出ました")
                                Else
                                    MsgBox("貸出処理失敗")
                                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出処理失敗" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                                    OraCla.OraRollBack()
                                End If
                            Catch ex As Exception
                                OraCla.OraRollBack()
                                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出処理失敗" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                                MsgBox("貸出処理失敗")
                            End Try
                            OraCla.CheckInstance()
                        Loop While Not OraCla.Connect



                    Else
                        '社員選択がされていない時
                        MsgBox("社員選択してください")
                    End If

                Else
                    '貸出可から変わっているなら
                    MsgBox("貸出状態が変わっています、再確認してください。")

                End If
            Else
                '返却の処理
                If sRentalStatus = "1" Then
                    sbSqlCmd = New System.Text.StringBuilder
                    sbSqlCmd2 = New System.Text.StringBuilder
                    sbSqlCmd.Append("        UPDATE RENTAL_MNG SET RENTALE_DATE = SYSDATE, ORDER_NO = SYSDATE")
                    sbSqlCmd.AppendFormat("  WHERE ISBN_CD = '{0}'", sISBNCD)
                    sbSqlCmd.Append("              AND RENTALE_DATE IS NULL")

                    sbSqlCmd2.Append(" UPDATE BOOK_MST SET RENTAL_STATUS = '0',")
                    sbSqlCmd2.Append("        UPDATE_DATE = SYSDATE")
                    sbSqlCmd2.AppendFormat("  WHERE ISBN_CD = '{0}'", sISBNCD)

                    Do
                        CheckOdp(Me)
                        OraCla.TransactionStart()
                        Try

                            If OraCla.OraCmdExecute(sbSqlCmd.ToString) And OraCla.OraCmdExecute(sbSqlCmd2.ToString) Then
                                OraCla.OraCommit()
                                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "返却処理" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                                MsgBox("返却しました")
                                IsbnDisplay()
                            Else
                                OraCla.OraRollBack()
                                LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "返却処理失敗" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                                MsgBox("返却処理失敗")
                            End If

                        Catch ex As Exception
                            OraCla.OraRollBack()
                            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "返却処理失敗" & sbSqlCmd.ToString & vbCrLf & sbSqlCmd2.ToString)
                            MsgBox("返却処理失敗")
                        End Try
                        OraCla.CheckInstance()
                    Loop While Not OraCla.Connect

                Else
                    '貸出可から変わっているなら
                    MsgBox("貸出状態が変わっています、再確認してください。")
                    LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出状態が変わっています、再確認してください" & sISBNCD)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub IsbnDisplay()
        Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim sISBNCd As String = TextBoxISBN.Text
        '0=ISBN_CD 1=本の名前1 2=本の名前2 3=分類名 4=棚NO 5=段No 6=貸出状態
        sbSqlCmd.Append("SELECT ISBN_CD, BOOK1_NAME, BOOK2_NAME, BUNRUI_NAME, TANA_NO, DAN_NO, RENTAL_STATUS ")
        sbSqlCmd.Append("       FROM BOOK_MST JOIN BUNRUI_MST ON BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD ")
        sbSqlCmd.AppendFormat(" WHERE ISBN_CD = '{0}'", sISBNCd)
        Dim orReader As OracleDataReader
        Do
            CheckOdp(Me)
            orReader = OraCla.GetDBReader(sbSqlCmd.ToString)
            OraCla.CheckInstance()
        Loop While Not OraCla.Connect

        If orReader.Read Then
            If orReader(0).ToString <> Nothing Then
                sbSqlCmd = New System.Text.StringBuilder
                ''0=ISBN_CD 1=本の名前1 2=本の名前2 3=分類名 4=棚NO 5=段No 6=貸出状態
                'sbSqlCmd.Append("SELECT ISBN_CD, BOOK1_NAME, BOOK2_NAME, BUNRUI_NAME, TANA_NO, DAN_NO, RENTAL_STATUS ")
                'sbSqlCmd.Append("FROM BOOK_MST JOIN BUNRUI_MST ON BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD ")
                'sbSqlCmd.AppendFormat("WHERE ISBN_CD = '{0}'", sISBNCd)
                'Dim orReader As OracleDataReader = OraCla.GetDBReader(sbSqlCmd.ToString)


                LblClassificationTxt.Text = orReader(3)
                LblShelfTxt.Text = orReader(4) & " - " & orReader(5)
                LblBookNameTxt1.Text = orReader(1)
                LblBookNameTxt2.Text = orReader(2)

                Select Case orReader(6)
                    Case "0"
                        '貸出可
                        LblStock.Text = "在庫有"
                        LblStock.BackColor = Color.LimeGreen
                        LblStockTxt.Text = "貸出可能です。"
                        LblStockTxt.ForeColor = Color.Blue
                        ButtonRental.Text = "貸出"
                        ButtonRental.Visible = True
                        ComboStaffSelect.Enabled = True
                    Case "1"
                        LblStock.Text = "在庫中"
                        LblStock.BackColor = Color.Yellow
                        LblStockTxt.Text = "貸出中です。"
                        LblStockTxt.ForeColor = Color.Blue
                        ButtonRental.Text = "返却"
                        ButtonRental.Visible = True
                        ComboStaffSelect.Enabled = False
                        '貸出中
                    Case Else
                        LblStock.Text = "禁貸出"
                        LblStock.BackColor = Color.Red
                        LblStockTxt.Text = "貸出禁止です。"
                        LblStockTxt.ForeColor = Color.Red
                        ButtonRental.Visible = False
                        ComboStaffSelect.Enabled = False
                        '禁貸出
                End Select



                sbSqlCmd = New System.Text.StringBuilder
                '0=ISBN_CD 1=貸出日時 2=返却日時 3=社員名 4=更新日時
                sbSqlCmd.Append("SELECT ISBN_CD, RENTALS_DATE, RENTALE_DATE, SYAIN_NAME ")
                sbSqlCmd.Append("       FROM RENTAL_MNG JOIN TANABE_SYAIN_MST ON RENTAL_MNG.SYAIN_CD = TANABE_SYAIN_MST.SYAIN_CD ")
                sbSqlCmd.AppendFormat(" WHERE ISBN_CD = '{0}' ORDER BY RENTALS_DATE DESC", sISBNCd)
                Do
                    CheckOdp(Me)
                    orReader = OraCla.GetDBReader(sbSqlCmd.ToString)
                    OraCla.CheckInstance()
                Loop While Not OraCla.Connect


                If orReader.Read Then
                    LblRentalDate.Text = Format(orReader(1), "yyyy/MM/dd")
                    If orReader(2).ToString <> Nothing Then
                        LblReturnDate.Text = Format(orReader(2), "yyyy/MM/dd")
                    Else
                        LblReturnDate.Text = ""
                    End If
                    LblStaffName.Text = orReader(3).ToString
                Else
                    LblRentalDate.Text = ""
                    LblReturnDate.Text = ""
                    LblStaffName.Text = ""
                End If

            End If
        Else
            MsgBox("そのISBNコードは登録されていません")
            InitPro()
        End If
        LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "ISBNCD内容表示" & sISBNCd)


    End Sub
End Class