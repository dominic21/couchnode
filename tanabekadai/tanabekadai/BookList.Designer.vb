<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookList
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookList))
        Me.LblBook = New System.Windows.Forms.Label
        Me.ComboClassification = New System.Windows.Forms.ComboBox
        Me.ComboState = New System.Windows.Forms.ComboBox
        Me.ButtonSearch = New System.Windows.Forms.Button
        Me.LblBookSearch = New System.Windows.Forms.Label
        Me.TextBoxISBNCDSearch = New System.Windows.Forms.TextBox
        Me.DataGVList = New System.Windows.Forms.DataGridView
        Me.ButtonPrint = New System.Windows.Forms.Button
        Me.Buttonreturn = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        CType(Me.DataGVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblBook
        '
        Me.LblBook.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBook.BackColor = System.Drawing.Color.Aquamarine
        Me.LblBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBook.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBook.Location = New System.Drawing.Point(199, 9)
        Me.LblBook.Name = "LblBook"
        Me.LblBook.Size = New System.Drawing.Size(579, 30)
        Me.LblBook.TabIndex = 1
        Me.LblBook.Text = "書籍一覧画面"
        Me.LblBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboClassification
        '
        Me.ComboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboClassification.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboClassification.FormattingEnabled = True
        Me.ComboClassification.Location = New System.Drawing.Point(172, 98)
        Me.ComboClassification.Name = "ComboClassification"
        Me.ComboClassification.Size = New System.Drawing.Size(192, 27)
        Me.ComboClassification.TabIndex = 2
        '
        'ComboState
        '
        Me.ComboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboState.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboState.FormattingEnabled = True
        Me.ComboState.Location = New System.Drawing.Point(403, 98)
        Me.ComboState.Name = "ComboState"
        Me.ComboState.Size = New System.Drawing.Size(192, 27)
        Me.ComboState.TabIndex = 3
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSearch.Location = New System.Drawing.Point(649, 98)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(250, 100)
        Me.ButtonSearch.TabIndex = 4
        Me.ButtonSearch.Text = "検索"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'LblBookSearch
        '
        Me.LblBookSearch.AutoSize = True
        Me.LblBookSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookSearch.Location = New System.Drawing.Point(184, 166)
        Me.LblBookSearch.Name = "LblBookSearch"
        Me.LblBookSearch.Size = New System.Drawing.Size(95, 19)
        Me.LblBookSearch.TabIndex = 5
        Me.LblBookSearch.Text = "書籍検索 :"
        '
        'TextBoxISBNCDSearch
        '
        Me.TextBoxISBNCDSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxISBNCDSearch.Location = New System.Drawing.Point(285, 163)
        Me.TextBoxISBNCDSearch.Name = "TextBoxISBNCDSearch"
        Me.TextBoxISBNCDSearch.Size = New System.Drawing.Size(310, 26)
        Me.TextBoxISBNCDSearch.TabIndex = 6
        '
        'DataGVList
        '
        Me.DataGVList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGVList.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGVList.Location = New System.Drawing.Point(57, 236)
        Me.DataGVList.Name = "DataGVList"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGVList.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGVList.RowTemplate.Height = 40
        Me.DataGVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGVList.Size = New System.Drawing.Size(900, 350)
        Me.DataGVList.TabIndex = 7
        '
        'ButtonPrint
        '
        Me.ButtonPrint.BackColor = System.Drawing.Color.LimeGreen
        Me.ButtonPrint.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonPrint.Location = New System.Drawing.Point(490, 618)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(250, 100)
        Me.ButtonPrint.TabIndex = 8
        Me.ButtonPrint.Text = "印刷"
        Me.ButtonPrint.UseVisualStyleBackColor = False
        '
        'Buttonreturn
        '
        Me.Buttonreturn.BackColor = System.Drawing.Color.Aquamarine
        Me.Buttonreturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Buttonreturn.Location = New System.Drawing.Point(746, 618)
        Me.Buttonreturn.Name = "Buttonreturn"
        Me.Buttonreturn.Size = New System.Drawing.Size(250, 100)
        Me.Buttonreturn.TabIndex = 9
        Me.Buttonreturn.Text = "戻る"
        Me.Buttonreturn.UseVisualStyleBackColor = False
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'BookList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.Buttonreturn)
        Me.Controls.Add(Me.ButtonPrint)
        Me.Controls.Add(Me.DataGVList)
        Me.Controls.Add(Me.TextBoxISBNCDSearch)
        Me.Controls.Add(Me.LblBookSearch)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.ComboState)
        Me.Controls.Add(Me.ComboClassification)
        Me.Controls.Add(Me.LblBook)
        Me.Name = "BookList"
        Me.Text = "書籍管理システム - 書籍一覧画面"
        CType(Me.DataGVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblBook As System.Windows.Forms.Label
    Friend WithEvents ComboClassification As System.Windows.Forms.ComboBox
    Friend WithEvents ComboState As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents LblBookSearch As System.Windows.Forms.Label
    Friend WithEvents TextBoxISBNCDSearch As System.Windows.Forms.TextBox
    Friend WithEvents DataGVList As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents Buttonreturn As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
