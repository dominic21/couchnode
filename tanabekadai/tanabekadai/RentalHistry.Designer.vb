<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RentalHistry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RentalHistry))
        Me.LblShelfMst = New System.Windows.Forms.Label
        Me.ComboClassification = New System.Windows.Forms.ComboBox
        Me.ComboStateSearch = New System.Windows.Forms.ComboBox
        Me.LblBookSearch = New System.Windows.Forms.Label
        Me.TxtISBNcode = New System.Windows.Forms.TextBox
        Me.ButtonSearch = New System.Windows.Forms.Button
        Me.DataGVHistry = New System.Windows.Forms.DataGridView
        Me.ButtonPrint = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        CType(Me.DataGVHistry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblShelfMst
        '
        Me.LblShelfMst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblShelfMst.BackColor = System.Drawing.Color.Aquamarine
        Me.LblShelfMst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblShelfMst.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblShelfMst.Location = New System.Drawing.Point(228, 9)
        Me.LblShelfMst.Name = "LblShelfMst"
        Me.LblShelfMst.Size = New System.Drawing.Size(530, 30)
        Me.LblShelfMst.TabIndex = 3
        Me.LblShelfMst.Text = "貸出履歴管理画面"
        Me.LblShelfMst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboClassification
        '
        Me.ComboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboClassification.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboClassification.FormattingEnabled = True
        Me.ComboClassification.Location = New System.Drawing.Point(217, 76)
        Me.ComboClassification.Name = "ComboClassification"
        Me.ComboClassification.Size = New System.Drawing.Size(187, 27)
        Me.ComboClassification.TabIndex = 4
        '
        'ComboStateSearch
        '
        Me.ComboStateSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStateSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboStateSearch.FormattingEnabled = True
        Me.ComboStateSearch.Location = New System.Drawing.Point(445, 76)
        Me.ComboStateSearch.Name = "ComboStateSearch"
        Me.ComboStateSearch.Size = New System.Drawing.Size(187, 27)
        Me.ComboStateSearch.TabIndex = 5
        '
        'LblBookSearch
        '
        Me.LblBookSearch.AutoSize = True
        Me.LblBookSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookSearch.Location = New System.Drawing.Point(175, 119)
        Me.LblBookSearch.Name = "LblBookSearch"
        Me.LblBookSearch.Size = New System.Drawing.Size(95, 19)
        Me.LblBookSearch.TabIndex = 6
        Me.LblBookSearch.Text = "書籍検索 :"
        '
        'TxtISBNcode
        '
        Me.TxtISBNcode.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtISBNcode.Location = New System.Drawing.Point(276, 116)
        Me.TxtISBNcode.Name = "TxtISBNcode"
        Me.TxtISBNcode.Size = New System.Drawing.Size(356, 26)
        Me.TxtISBNcode.TabIndex = 7
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSearch.Location = New System.Drawing.Point(667, 54)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(183, 96)
        Me.ButtonSearch.TabIndex = 8
        Me.ButtonSearch.Text = "検索"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'DataGVHistry
        '
        Me.DataGVHistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGVHistry.Location = New System.Drawing.Point(49, 165)
        Me.DataGVHistry.Name = "DataGVHistry"
        Me.DataGVHistry.RowTemplate.Height = 21
        Me.DataGVHistry.Size = New System.Drawing.Size(900, 450)
        Me.DataGVHistry.TabIndex = 9
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPrint.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonPrint.Location = New System.Drawing.Point(612, 638)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(177, 80)
        Me.ButtonPrint.TabIndex = 10
        Me.ButtonPrint.Text = "印刷"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'ButtonReturn
        '
        Me.ButtonReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(819, 638)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(177, 80)
        Me.ButtonReturn.TabIndex = 11
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = True
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
        'RentalHistry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonPrint)
        Me.Controls.Add(Me.DataGVHistry)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.TxtISBNcode)
        Me.Controls.Add(Me.LblBookSearch)
        Me.Controls.Add(Me.ComboStateSearch)
        Me.Controls.Add(Me.ComboClassification)
        Me.Controls.Add(Me.LblShelfMst)
        Me.Name = "RentalHistry"
        Me.Text = "書籍管理システム - 貸出履歴管理画面"
        CType(Me.DataGVHistry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblShelfMst As System.Windows.Forms.Label
    Friend WithEvents ComboClassification As System.Windows.Forms.ComboBox
    Friend WithEvents ComboStateSearch As System.Windows.Forms.ComboBox
    Friend WithEvents LblBookSearch As System.Windows.Forms.Label
    Friend WithEvents TxtISBNcode As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents DataGVHistry As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
