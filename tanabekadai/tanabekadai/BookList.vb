Imports Oracle.DataAccess.Client

Public Class BookList

#Region "共通変数"
    'Dim htClassification As Hashtable = New Hashtable
    'Dim htClassificationCD As Hashtable = New Hashtable
#End Region

#Region "イベント"

    ''' <summary>
    ''' フォームロード時設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BookList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '初期設定
            ComboClassification.Items.Add("-- 分類検索 --")
            ComboClassification.Items.Add("全て")
            ComboState.Items.Add("-- 状態検索 --")
            ComboState.Items.Add("全て")
            ComboState.Items.Add("貸出可")
            ComboState.Items.Add("貸出中")
            ComboState.Items.Add("禁貸出")
            Dim ClassificationList As String()
            Do
                CheckOdp(Me)
                ClassificationList = OraCla.GetDBList("SELECT * FROM BUNRUI_MST", "BUNRUI_NAME")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect

            'Dim ClassificationCdList As String() = OraCla.GetDBList("SELECT * FROM BUNRUI_MST", "BUNRUI_CD")
            Dim i As Integer = 0

            '分類コードと分類名を紐つけ
            While ClassificationList.Length > i
                ComboClassification.Items.Add(ClassificationList(i))
                'htClassification.Add(ClassificationCdList(i), ClassificationList(i))
                'htClassificationCD.Add(ClassificationList(i), ClassificationCdList(i))
                i += 1
            End While

            ComboClassification.SelectedIndex = 0
            ComboState.SelectedIndex = 0


            ''データグリッドビュー設定
            'DataGVList.DefaultCellStyle.Font = New Font(DataGVList.Font.Name, 14)
            'DataGVList.Columns.Add("Shelf", "棚")
            'DataGVList.Columns(0).Width = 100
            'DataGVList.Columns.Add("Classification", "分類")
            'DataGVList.Columns(1).Width = 90
            'DataGVList.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            'DataGVList.Columns.Add("ISBNCode", "書籍コード")
            'DataGVList.Columns(2).Width = 200
            'DataGVList.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            'DataGVList.Columns.Add("BookName", "書籍名")
            'DataGVList.Columns(3).Width = 400
            'DataGVList.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            'DataGVList.Columns.Add("Rental", "貸出")
            'DataGVList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGVList.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Dim DataReaderBookMst As OracleDataReader = OraCla.GetDBReader("SELECT * FROM BOOK_MST")
            ''DataReaderBookMst : 0=ISBNCD 1=Bookname1 2=Bookname2 3=BunruiCD 4=TanaNo 5=DanNo
            ''            6=貸出状態 7=備考 8=登録日 9=更新日
            'Dim x As Integer = 0
            'While DataReaderBookMst.Read
            '    DataGVList.Rows.Add()

            '    DataGVList(0, x).Value = DataReaderBookMst(4).ToString & "-" & DataReaderBookMst(5).ToString
            '    If htClassification(DataReaderBookMst(3)).ToString.Length >= 6 Then

            '        DataGVList(1, x).Value = htClassification(DataReaderBookMst(3)).ToString.Substring(0, 5) _
            '        & vbCrLf & htClassification(DataReaderBookMst(3)).ToString.ToString.Substring(5)

            '        DataGVList.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            '    Else
            '        DataGVList(1, x).Value = htClassification(DataReaderBookMst(3)).ToString.ToString
            '    End If
            '    DataGVList(2, x).Value = DataReaderBookMst(0).ToString
            '    DataGVList(3, x).Value = DataReaderBookMst(1).ToString & vbCrLf & DataReaderBookMst(2).ToString

            '    If DataReaderBookMst(6).ToString = "0" Then
            '        '貸出可なら
            '        DataGVList(4, x).Value = ""
            '    ElseIf DataReaderBookMst(6).ToString = "1" Then
            '        '貸出中なら
            '        DataGVList(4, x).Value = "○"
            '    Else
            '        '禁貸出なら
            '        DataGVList(4, x).Value = "禁"
            '    End If
            '    x += 1

            'End While

            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "初期設定")
            DgvLoad()

            'データグリッドビュー設定
            DataGVList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGVList.DefaultCellStyle.Font = New Font(DataGVList.Font.Name, 14)
            DataGVList.Columns(0).Width = 100
            DataGVList.Columns(1).Width = 90
            DataGVList.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGVList.Columns(2).Width = 200
            DataGVList.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGVList.Columns(3).Width = 400
            DataGVList.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            DataGVList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGVList.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGVList.ReadOnly = True

            'DataGVList.AllowUserToAddRows = False
            'DataGVList.AllowUserToDeleteRows = False

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 検索ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Try
            'DataGVList.Rows.Clear()
            'Dim sbSQL As System.Text.StringBuilder = New System.Text.StringBuilder
            'Dim sState As String
            'Dim sClassification As String
            'Select Case ComboState.Text
            '    Case "貸出可"
            '        sState = "0"
            '    Case "貸出中"
            '        sState = "1"
            '    Case "禁貸出"
            '        sState = "2"
            '    Case Else
            '        sState = ""
            'End Select

            'If ComboClassification.Text = "-- 分類検索 --" Or ComboClassification.Text = "全て" Then
            '    sClassification = ""
            'Else
            '    sClassification = htClassificationCD(ComboClassification.Text)
            'End If

            'sbSQL.Append("SELECT * FROM BOOK_MST WHERE ISBN_CD LIKE '%")
            'sbSQL.Append(TextBoxISBNCDSearch.Text & "%' AND BUNRUI_CD LIKE '%")
            'sbSQL.Append(sClassification & "%' AND RENTAL_STATUS LIKE '%")
            'sbSQL.Append(sState & "%'")
            'sbSQL.AppendFormat(" AND BOOK1_NAME || BOOK2_NAME LIKE '%{0}%'", TextBoxISBNCDSearch.Text)
            'Dim DataReaderBookMst As OracleDataReader = OraCla.GetDBReader(sbSQL.ToString)
            ''DataReaderBookMst : 0=ISBNCD 1=Bookname1 2=Bookname2 3=BunruiCD 4=TanaNo 5=DanNo
            ''            6=貸出状態 7=備考 8=登録日 9=更新日
            'Dim x As Integer = 0
            'While DataReaderBookMst.Read
            '    DataGVList.Rows.Add()

            '    DataGVList(0, x).Value = DataReaderBookMst(4).ToString & "-" & DataReaderBookMst(5).ToString
            '    If htClassification(DataReaderBookMst(3)).ToString.Length >= 6 Then

            '        DataGVList(1, x).Value = htClassification(DataReaderBookMst(3)).ToString.Substring(0, 5) _
            '        & vbCrLf & htClassification(DataReaderBookMst(3)).ToString.ToString.Substring(5)

            '        DataGVList.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            '    Else
            '        DataGVList(1, x).Value = htClassification(DataReaderBookMst(3)).ToString.ToString
            '    End If
            '    DataGVList(2, x).Value = DataReaderBookMst(0).ToString
            '    DataGVList(3, x).Value = DataReaderBookMst(1).ToString & vbCrLf & DataReaderBookMst(2).ToString

            '    If DataReaderBookMst(6).ToString = "0" Then
            '        '貸出可なら
            '        DataGVList(4, x).Value = ""
            '    ElseIf DataReaderBookMst(6).ToString = "1" Then
            '        '貸出中なら
            '        DataGVList(4, x).Value = "○"
            '    Else
            '        '禁貸出なら
            '        DataGVList(4, x).Value = "禁"
            '    End If
            '    x += 1

            'End While

            DgvLoad()
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出処理画面押下")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 戻るボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Buttonreturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonreturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' テキストボックスでのエンター押下設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBoxISBNCDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxISBNCDSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                DgvLoad()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "関数"

    ''' <summary>
    ''' データグリッドビュー更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DgvLoad()
        Try
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sClassification As String = ""
            Dim sState As String = ""
            Dim sBookSearch As String = TextBoxISBNCDSearch.Text

            If ComboClassification.Text <> "-- 分類検索 --" And ComboClassification.Text <> "全て" Then
                sClassification = ComboClassification.Text
            End If

            If ComboState.Text <> "-- 状態検索 --" And ComboState.Text <> "全て" Then
                Select Case ComboState.Text
                    Case "貸出可"
                        sState = "0"
                    Case "貸出中"
                        sState = "1"
                    Case "禁貸出"
                        sState = "2"
                    Case Else
                        sState = ""
                End Select
            End If

            'sbSqlCmd.Append("SELECT TANA_NO || '-' ||DAN_NO AS 棚, BUNRUI_NAME AS 分類, ISBN_CD AS 書籍コード, BOOK1_NAME || CHR(13) || CHR(10) || BOOK2_NAME AS 書籍名,")
            'sbSqlCmd.Append(" DECODE(RENTAL_STATUS, 1, '○', 2, '禁', '') AS 貸出")
            'sbSqlCmd.Append(" FROM BOOK_MST JOIN BUNRUI_MST ON BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD")
            'sbSqlCmd.AppendFormat(" WHERE BUNRUI_NAME LIKE '%{0}%' AND RENTAL_STATUS LIKE '%{1}%'", sClassification, sState)
            'sbSqlCmd.AppendFormat(" AND BOOK1_NAME || BOOK2_NAME LIKE '%{0}%'", sBookSearch)

            sbSqlCmd.Append("       SELECT TANA_NO || '-' ||DAN_NO AS 棚, BUNRUI_NAME AS 分類, ISBN_CD AS 書籍コード,")
            sbSqlCmd.Append("              BOOK1_NAME || CHR(13) || CHR(10) || BOOK2_NAME AS 書籍名,")
            sbSqlCmd.Append("              DECODE(RENTAL_STATUS, 1, '○', 2, '禁', '') AS 貸出")
            sbSqlCmd.Append("       FROM BOOK_MST, BUNRUI_MST")
            sbSqlCmd.Append("       WHERE BOOK_MST.BUNRUI_CD = BUNRUI_MST.BUNRUI_CD")
            sbSqlCmd.AppendFormat("       AND BUNRUI_NAME LIKE '%{0}%'", sClassification)
            sbSqlCmd.AppendFormat("       AND RENTAL_STATUS LIKE '%{0}%'", sState)
            sbSqlCmd.AppendFormat("       AND BOOK1_NAME || BOOK2_NAME LIKE '%{0}%'", sBookSearch)
            Do
                CheckOdp(Me)
                DataGVList.DataSource = OraCla.OraDgvSetting(sbSqlCmd.ToString)
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect
            Dim sbSetting As System.Text.StringBuilder = New System.Text.StringBuilder
            sbSetting.AppendFormat("設定内容{0}", vbCrLf)
            sbSetting.AppendFormat("分類：{0}{1}", ComboClassification.Text, vbCrLf)
            sbSetting.AppendFormat("状態：{0}{1}", ComboState.Text, vbCrLf)
            sbSetting.AppendFormat("検索ワード：{0}", TextBoxISBNCDSearch.Text)
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, sbSetting.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region

    ''' <summary>
    ''' 印刷ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "印刷ボタン押下")
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
            Dim JanCode As ClassBarCode = New ClassBarCode(e.Graphics)
            JanCode.DrawBarCode("", , , , )

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class