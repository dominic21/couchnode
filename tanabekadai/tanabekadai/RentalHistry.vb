Imports Oracle.DataAccess.Client
Public Class RentalHistry

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RentalHistry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder

            DgvLoad()

            DataGVHistry.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGVHistry.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGVHistry.DefaultCellStyle.Font = New Font(DataGVHistry.Font.Name, 14)

            DataGVHistry.Columns(0).Width = 100
            DataGVHistry.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            DataGVHistry.Columns(1).Width = 150
            DataGVHistry.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            DataGVHistry.Columns(2).Width = 340
            DataGVHistry.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            DataGVHistry.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            DataGVHistry.Columns(3).Width = 130
            DataGVHistry.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGVHistry.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGVHistry.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ComboClassification.Items.Add("-- 分類検索 --")
            ComboClassification.Items.Add("全て")
            ComboStateSearch.Items.Add("-- 状態検索 --")
            ComboStateSearch.Items.Add("全て")
            ComboStateSearch.Items.Add("貸出中")
            ComboStateSearch.Items.Add("返却済")
            sbSqlCmd = New System.Text.StringBuilder
            sbSqlCmd.Append("SELECT BUNRUI_NAME FROM BUNRUI_MST")
            Dim drReader As OracleDataReader

            Do
                CheckOdp(Me)
                drReader = OraCla.GetDBReader(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            While drReader.Read
                ComboClassification.Items.Add(drReader(0).ToString)
            End While
            ComboClassification.SelectedIndex = 0
            ComboStateSearch.SelectedIndex = 0
            DataGVHistry.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Try
            Dim sISBNCd As String = ""
            If TxtISBNcode.Text <> Nothing Then
                sISBNCd = TxtISBNcode.Text
            End If
            DgvLoad(, , sISBNCd)
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "検索開始 : ISBNCD : " & sISBNCd & "分類 : " & ComboClassification.Text & "状態 : " & ComboStateSearch.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub DgvLoad(Optional ByVal sClassification As String = "", Optional ByVal sState As String = "", Optional ByVal sISBNCd As String = "")
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder

            If ComboClassification.Text <> "-- 分類検索 --" And ComboClassification.Text <> "全て" Then
                sClassification = ComboClassification.Text
            End If


            If ComboStateSearch.Text <> "-- 状態検索 --" And ComboStateSearch.Text <> "全て" Then
                Select Case ComboStateSearch.Text
                    Case "貸出中"
                        sState = "1"
                    Case "返却済"
                        sState = "2"
                End Select
            End If

            'sbSqlCmd.Append("SELECT BUNRUI_NAME AS 分類, ISBN_CD AS 書籍コード, BOOK1_NAME || CHR(13) || CHR(10) || BOOK2_NAME AS 書籍名,")
            'sbSqlCmd.Append(" TO_CHAR(RENTALS_DATE, 'YYYY/MM/DD') AS 貸出日, TO_CHAR(RENTALE_DATE, 'YYYY/MM/DD') AS 返却日 FROM(")
            'sbSqlCmd.Append("SELECT BUNRUI_NAME, RENTAL_MNG.ISBN_CD, BOOK1_NAME, BOOK2_NAME,")
            'sbSqlCmd.Append(" RENTALS_DATE, RENTALE_DATE")
            'sbSqlCmd.Append(" FROM RENTAL_MNG, BOOK_MST,BUNRUI_MST")
            'sbSqlCmd.AppendFormat(" WHERE BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD AND RENTAL_MNG.ISBN_CD = BOOK_MST.ISBN_CD AND BUNRUI_NAME LIKE '%{0}%' AND DECODE(RENTALE_DATE, NULL, '1' ,'2') LIKE '%{1}%'", sClassification, sState)
            'sbSqlCmd.AppendFormat(" AND BOOK1_NAME || BOOK2_NAME LIKE '%{0}%'", sISBNCd)
            'sbSqlCmd.Append(" ORDER BY DECODE(RENTALE_DATE, NULL, '1' ,'2'), RENTALS_DATE DESC")
            'sbSqlCmd.AppendFormat(") WHERE ROWNUM <= 100")


            'RowNumで100件制限をかけるため副問い合わせ
            sbSqlCmd.Append("SELECT BUNRUI_NAME AS 分類,")
            sbSqlCmd.Append("    ISBN_CD AS 書籍コード,")
            sbSqlCmd.Append("    BOOK1_NAME || CHR(13) || CHR(10) || BOOK2_NAME AS 書籍名,")
            sbSqlCmd.Append("    TO_CHAR(RENTALS_DATE, 'YYYY/MM/DD') AS 貸出日,")
            sbSqlCmd.Append("    TO_CHAR(RENTALE_DATE, 'YYYY/MM/DD') AS 返却日")
            sbSqlCmd.Append(" FROM(")
            sbSqlCmd.Append("    SELECT BUNRUI_NAME, RENTAL_MNG.ISBN_CD, BOOK1_NAME, BOOK2_NAME,")
            sbSqlCmd.Append("           RENTALS_DATE, RENTALE_DATE")
            sbSqlCmd.Append("    FROM RENTAL_MNG, BOOK_MST,BUNRUI_MST")
            sbSqlCmd.Append("    WHERE BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD")
            sbSqlCmd.Append("          AND RENTAL_MNG.ISBN_CD = BOOK_MST.ISBN_CD")
            sbSqlCmd.AppendFormat("    AND BUNRUI_NAME LIKE '%{0}%'", sClassification)
            sbSqlCmd.AppendFormat("    AND DECODE(RENTALE_DATE, NULL, '1' ,'2') LIKE '%{0}%'", sState)
            sbSqlCmd.AppendFormat("    AND BOOK1_NAME || BOOK2_NAME LIKE '%{0}%'", sISBNCd)
            sbSqlCmd.Append(" ORDER BY DECODE(RENTALE_DATE, NULL, '1' ,'2'), RENTALS_DATE DESC")
            sbSqlCmd.Append(" )")
            sbSqlCmd.Append(" WHERE ROWNUM <= 100")
            Do
                CheckOdp(Me)
                DataGVHistry.DataSource = OraCla.OraDgvSetting(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 印刷ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "印刷押下")
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 印刷設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class