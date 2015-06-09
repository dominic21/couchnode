<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rental
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
        Me.LblRental = New System.Windows.Forms.Label
        Me.TextBoxISBN = New System.Windows.Forms.TextBox
        Me.LblClassification = New System.Windows.Forms.Label
        Me.LblClassificationTxt = New System.Windows.Forms.Label
        Me.LblShelf = New System.Windows.Forms.Label
        Me.LblShelfTxt = New System.Windows.Forms.Label
        Me.LblBookName1 = New System.Windows.Forms.Label
        Me.LblBookName2 = New System.Windows.Forms.Label
        Me.LblBookNameTxt1 = New System.Windows.Forms.Label
        Me.LblBookNameTxt2 = New System.Windows.Forms.Label
        Me.LblStock = New System.Windows.Forms.Label
        Me.LblStockTxt = New System.Windows.Forms.Label
        Me.LblLastRent = New System.Windows.Forms.Label
        Me.LblRentalDate = New System.Windows.Forms.Label
        Me.LblReturnDate = New System.Windows.Forms.Label
        Me.LblStaffName = New System.Windows.Forms.Label
        Me.ComboStaffSelect = New System.Windows.Forms.ComboBox
        Me.ButtonRental = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.ButtonHistry = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LblRental
        '
        Me.LblRental.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRental.BackColor = System.Drawing.Color.Aquamarine
        Me.LblRental.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRental.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRental.Location = New System.Drawing.Point(239, 9)
        Me.LblRental.Name = "LblRental"
        Me.LblRental.Size = New System.Drawing.Size(511, 30)
        Me.LblRental.TabIndex = 4
        Me.LblRental.Text = "貸出処理画面"
        Me.LblRental.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxISBN
        '
        Me.TextBoxISBN.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxISBN.Location = New System.Drawing.Point(239, 118)
        Me.TextBoxISBN.Name = "TextBoxISBN"
        Me.TextBoxISBN.Size = New System.Drawing.Size(511, 35)
        Me.TextBoxISBN.TabIndex = 5
        '
        'LblClassification
        '
        Me.LblClassification.AutoSize = True
        Me.LblClassification.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassification.Location = New System.Drawing.Point(122, 191)
        Me.LblClassification.Name = "LblClassification"
        Me.LblClassification.Size = New System.Drawing.Size(57, 19)
        Me.LblClassification.TabIndex = 6
        Me.LblClassification.Text = "分類 :"
        '
        'LblClassificationTxt
        '
        Me.LblClassificationTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblClassificationTxt.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassificationTxt.Location = New System.Drawing.Point(185, 185)
        Me.LblClassificationTxt.Name = "LblClassificationTxt"
        Me.LblClassificationTxt.Size = New System.Drawing.Size(181, 31)
        Me.LblClassificationTxt.TabIndex = 7
        Me.LblClassificationTxt.Text = "Label1"
        Me.LblClassificationTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShelf
        '
        Me.LblShelf.AutoSize = True
        Me.LblShelf.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblShelf.Location = New System.Drawing.Point(569, 191)
        Me.LblShelf.Name = "LblShelf"
        Me.LblShelf.Size = New System.Drawing.Size(38, 19)
        Me.LblShelf.TabIndex = 8
        Me.LblShelf.Text = "棚 :"
        '
        'LblShelfTxt
        '
        Me.LblShelfTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblShelfTxt.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblShelfTxt.Location = New System.Drawing.Point(621, 185)
        Me.LblShelfTxt.Name = "LblShelfTxt"
        Me.LblShelfTxt.Size = New System.Drawing.Size(181, 31)
        Me.LblShelfTxt.TabIndex = 9
        Me.LblShelfTxt.Text = "Label1"
        Me.LblShelfTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBookName1
        '
        Me.LblBookName1.AutoSize = True
        Me.LblBookName1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookName1.Location = New System.Drawing.Point(111, 240)
        Me.LblBookName1.Name = "LblBookName1"
        Me.LblBookName1.Size = New System.Drawing.Size(67, 19)
        Me.LblBookName1.TabIndex = 10
        Me.LblBookName1.Text = "書名1 :"
        '
        'LblBookName2
        '
        Me.LblBookName2.AutoSize = True
        Me.LblBookName2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookName2.Location = New System.Drawing.Point(111, 297)
        Me.LblBookName2.Name = "LblBookName2"
        Me.LblBookName2.Size = New System.Drawing.Size(67, 19)
        Me.LblBookName2.TabIndex = 11
        Me.LblBookName2.Text = "書名2 :"
        '
        'LblBookNameTxt1
        '
        Me.LblBookNameTxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBookNameTxt1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookNameTxt1.Location = New System.Drawing.Point(185, 234)
        Me.LblBookNameTxt1.Name = "LblBookNameTxt1"
        Me.LblBookNameTxt1.Size = New System.Drawing.Size(618, 31)
        Me.LblBookNameTxt1.TabIndex = 12
        Me.LblBookNameTxt1.Text = "Label1"
        Me.LblBookNameTxt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBookNameTxt2
        '
        Me.LblBookNameTxt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBookNameTxt2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookNameTxt2.Location = New System.Drawing.Point(185, 291)
        Me.LblBookNameTxt2.Name = "LblBookNameTxt2"
        Me.LblBookNameTxt2.Size = New System.Drawing.Size(618, 31)
        Me.LblBookNameTxt2.TabIndex = 13
        Me.LblBookNameTxt2.Text = "Label1"
        Me.LblBookNameTxt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStock
        '
        Me.LblStock.BackColor = System.Drawing.Color.Lime
        Me.LblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStock.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStock.Location = New System.Drawing.Point(185, 343)
        Me.LblStock.Name = "LblStock"
        Me.LblStock.Size = New System.Drawing.Size(132, 48)
        Me.LblStock.TabIndex = 14
        Me.LblStock.Text = "在庫有"
        Me.LblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStockTxt
        '
        Me.LblStockTxt.AutoSize = True
        Me.LblStockTxt.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte), True)
        Me.LblStockTxt.ForeColor = System.Drawing.Color.Blue
        Me.LblStockTxt.Location = New System.Drawing.Point(339, 358)
        Me.LblStockTxt.Name = "LblStockTxt"
        Me.LblStockTxt.Size = New System.Drawing.Size(130, 19)
        Me.LblStockTxt.TabIndex = 15
        Me.LblStockTxt.Text = "貸出可能です。"
        '
        'LblLastRent
        '
        Me.LblLastRent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblLastRent.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblLastRent.Location = New System.Drawing.Point(185, 422)
        Me.LblLastRent.Name = "LblLastRent"
        Me.LblLastRent.Size = New System.Drawing.Size(160, 27)
        Me.LblLastRent.TabIndex = 16
        Me.LblLastRent.Text = "最終貸出"
        Me.LblLastRent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRentalDate
        '
        Me.LblRentalDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRentalDate.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRentalDate.Location = New System.Drawing.Point(344, 422)
        Me.LblRentalDate.Name = "LblRentalDate"
        Me.LblRentalDate.Size = New System.Drawing.Size(192, 27)
        Me.LblRentalDate.TabIndex = 17
        Me.LblRentalDate.Text = "YYYY/MM/DD"
        Me.LblRentalDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblReturnDate
        '
        Me.LblReturnDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblReturnDate.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblReturnDate.Location = New System.Drawing.Point(535, 422)
        Me.LblReturnDate.Name = "LblReturnDate"
        Me.LblReturnDate.Size = New System.Drawing.Size(192, 27)
        Me.LblReturnDate.TabIndex = 18
        Me.LblReturnDate.Text = "YYYY/MM/DD"
        Me.LblReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStaffName
        '
        Me.LblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStaffName.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStaffName.Location = New System.Drawing.Point(726, 422)
        Me.LblStaffName.Name = "LblStaffName"
        Me.LblStaffName.Size = New System.Drawing.Size(215, 27)
        Me.LblStaffName.TabIndex = 19
        Me.LblStaffName.Text = "山田　太郎"
        Me.LblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboStaffSelect
        '
        Me.ComboStaffSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStaffSelect.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboStaffSelect.FormattingEnabled = True
        Me.ComboStaffSelect.Location = New System.Drawing.Point(185, 484)
        Me.ComboStaffSelect.Name = "ComboStaffSelect"
        Me.ComboStaffSelect.Size = New System.Drawing.Size(236, 27)
        Me.ComboStaffSelect.TabIndex = 20
        '
        'ButtonRental
        '
        Me.ButtonRental.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonRental.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRental.Location = New System.Drawing.Point(12, 618)
        Me.ButtonRental.Name = "ButtonRental"
        Me.ButtonRental.Size = New System.Drawing.Size(200, 100)
        Me.ButtonRental.TabIndex = 21
        Me.ButtonRental.Text = "貸出"
        Me.ButtonRental.UseVisualStyleBackColor = False
        '
        'ButtonReturn
        '
        Me.ButtonReturn.BackColor = System.Drawing.Color.Aquamarine
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(796, 618)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(200, 100)
        Me.ButtonReturn.TabIndex = 22
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = False
        '
        'ButtonHistry
        '
        Me.ButtonHistry.BackColor = System.Drawing.Color.LawnGreen
        Me.ButtonHistry.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonHistry.Location = New System.Drawing.Point(573, 618)
        Me.ButtonHistry.Name = "ButtonHistry"
        Me.ButtonHistry.Size = New System.Drawing.Size(200, 100)
        Me.ButtonHistry.TabIndex = 24
        Me.ButtonHistry.Text = "履歴"
        Me.ButtonHistry.UseVisualStyleBackColor = False
        '
        'Rental
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonHistry)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonRental)
        Me.Controls.Add(Me.ComboStaffSelect)
        Me.Controls.Add(Me.LblStaffName)
        Me.Controls.Add(Me.LblReturnDate)
        Me.Controls.Add(Me.LblRentalDate)
        Me.Controls.Add(Me.LblLastRent)
        Me.Controls.Add(Me.LblStockTxt)
        Me.Controls.Add(Me.LblStock)
        Me.Controls.Add(Me.LblBookNameTxt2)
        Me.Controls.Add(Me.LblBookNameTxt1)
        Me.Controls.Add(Me.LblBookName2)
        Me.Controls.Add(Me.LblBookName1)
        Me.Controls.Add(Me.LblShelfTxt)
        Me.Controls.Add(Me.LblShelf)
        Me.Controls.Add(Me.LblClassificationTxt)
        Me.Controls.Add(Me.LblClassification)
        Me.Controls.Add(Me.TextBoxISBN)
        Me.Controls.Add(Me.LblRental)
        Me.Name = "Rental"
        Me.Text = "書籍管理システム - 貸出処理画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblRental As System.Windows.Forms.Label
    Friend WithEvents TextBoxISBN As System.Windows.Forms.TextBox
    Friend WithEvents LblClassification As System.Windows.Forms.Label
    Friend WithEvents LblClassificationTxt As System.Windows.Forms.Label
    Friend WithEvents LblShelf As System.Windows.Forms.Label
    Friend WithEvents LblShelfTxt As System.Windows.Forms.Label
    Friend WithEvents LblBookName1 As System.Windows.Forms.Label
    Friend WithEvents LblBookName2 As System.Windows.Forms.Label
    Friend WithEvents LblBookNameTxt1 As System.Windows.Forms.Label
    Friend WithEvents LblBookNameTxt2 As System.Windows.Forms.Label
    Friend WithEvents LblStock As System.Windows.Forms.Label
    Friend WithEvents LblStockTxt As System.Windows.Forms.Label
    Friend WithEvents LblLastRent As System.Windows.Forms.Label
    Friend WithEvents LblRentalDate As System.Windows.Forms.Label
    Friend WithEvents LblReturnDate As System.Windows.Forms.Label
    Friend WithEvents LblStaffName As System.Windows.Forms.Label
    Friend WithEvents ComboStaffSelect As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonRental As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
    Friend WithEvents ButtonHistry As System.Windows.Forms.Button
End Class
