<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookMst
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
        Me.LblBookmst = New System.Windows.Forms.Label
        Me.TextBoxISBN = New System.Windows.Forms.TextBox
        Me.Lblflg = New System.Windows.Forms.Label
        Me.Lblgroup = New System.Windows.Forms.Label
        Me.LblPublisher = New System.Windows.Forms.Label
        Me.LblBook = New System.Windows.Forms.Label
        Me.LblCD = New System.Windows.Forms.Label
        Me.TextBoxFlg = New System.Windows.Forms.TextBox
        Me.TextBoxGroup = New System.Windows.Forms.TextBox
        Me.TextBoxPublisher = New System.Windows.Forms.TextBox
        Me.TextBoxBook = New System.Windows.Forms.TextBox
        Me.TextBoxCD = New System.Windows.Forms.TextBox
        Me.ComboClassification = New System.Windows.Forms.ComboBox
        Me.ComboShelf = New System.Windows.Forms.ComboBox
        Me.CheckLendingban = New System.Windows.Forms.CheckBox
        Me.LblBookName1 = New System.Windows.Forms.Label
        Me.LblBookName2 = New System.Windows.Forms.Label
        Me.TextBoxBookName1 = New System.Windows.Forms.TextBox
        Me.TextBoxBookName2 = New System.Windows.Forms.TextBox
        Me.ButtonSignUp = New System.Windows.Forms.Button
        Me.ButtonDelete = New System.Windows.Forms.Button
        Me.ButtonList = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.LblRemarks = New System.Windows.Forms.Label
        Me.TextBoxRemarks = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'LblBookmst
        '
        Me.LblBookmst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblBookmst.BackColor = System.Drawing.Color.Aquamarine
        Me.LblBookmst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBookmst.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookmst.Location = New System.Drawing.Point(192, 9)
        Me.LblBookmst.Name = "LblBookmst"
        Me.LblBookmst.Size = New System.Drawing.Size(593, 30)
        Me.LblBookmst.TabIndex = 1
        Me.LblBookmst.Text = "書籍マスタ管理画面"
        Me.LblBookmst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxISBN
        '
        Me.TextBoxISBN.Font = New System.Drawing.Font("MS UI Gothic", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxISBN.Location = New System.Drawing.Point(318, 104)
        Me.TextBoxISBN.Name = "TextBoxISBN"
        Me.TextBoxISBN.Size = New System.Drawing.Size(327, 29)
        Me.TextBoxISBN.TabIndex = 3
        '
        'Lblflg
        '
        Me.Lblflg.AutoSize = True
        Me.Lblflg.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lblflg.Location = New System.Drawing.Point(315, 164)
        Me.Lblflg.Name = "Lblflg"
        Me.Lblflg.Size = New System.Drawing.Size(50, 19)
        Me.Lblflg.TabIndex = 4
        Me.Lblflg.Text = "フラグ"
        '
        'Lblgroup
        '
        Me.Lblgroup.AutoSize = True
        Me.Lblgroup.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lblgroup.Location = New System.Drawing.Point(399, 164)
        Me.Lblgroup.Name = "Lblgroup"
        Me.Lblgroup.Size = New System.Drawing.Size(70, 19)
        Me.Lblgroup.TabIndex = 5
        Me.Lblgroup.Text = "グループ"
        '
        'LblPublisher
        '
        Me.LblPublisher.AutoSize = True
        Me.LblPublisher.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblPublisher.Location = New System.Drawing.Point(493, 164)
        Me.LblPublisher.Name = "LblPublisher"
        Me.LblPublisher.Size = New System.Drawing.Size(66, 19)
        Me.LblPublisher.TabIndex = 6
        Me.LblPublisher.Text = "出版社"
        '
        'LblBook
        '
        Me.LblBook.AutoSize = True
        Me.LblBook.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBook.Location = New System.Drawing.Point(598, 164)
        Me.LblBook.Name = "LblBook"
        Me.LblBook.Size = New System.Drawing.Size(47, 19)
        Me.LblBook.TabIndex = 7
        Me.LblBook.Text = "書籍"
        '
        'LblCD
        '
        Me.LblCD.AutoSize = True
        Me.LblCD.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCD.Location = New System.Drawing.Point(696, 164)
        Me.LblCD.Name = "LblCD"
        Me.LblCD.Size = New System.Drawing.Size(44, 19)
        Me.LblCD.TabIndex = 8
        Me.LblCD.Text = "C/D"
        '
        'TextBoxFlg
        '
        Me.TextBoxFlg.Location = New System.Drawing.Point(304, 192)
        Me.TextBoxFlg.Name = "TextBoxFlg"
        Me.TextBoxFlg.Size = New System.Drawing.Size(61, 19)
        Me.TextBoxFlg.TabIndex = 9
        '
        'TextBoxGroup
        '
        Me.TextBoxGroup.Location = New System.Drawing.Point(403, 192)
        Me.TextBoxGroup.Name = "TextBoxGroup"
        Me.TextBoxGroup.Size = New System.Drawing.Size(61, 19)
        Me.TextBoxGroup.TabIndex = 10
        '
        'TextBoxPublisher
        '
        Me.TextBoxPublisher.Location = New System.Drawing.Point(497, 192)
        Me.TextBoxPublisher.Name = "TextBoxPublisher"
        Me.TextBoxPublisher.Size = New System.Drawing.Size(61, 19)
        Me.TextBoxPublisher.TabIndex = 11
        '
        'TextBoxBook
        '
        Me.TextBoxBook.Location = New System.Drawing.Point(594, 192)
        Me.TextBoxBook.Name = "TextBoxBook"
        Me.TextBoxBook.Size = New System.Drawing.Size(61, 19)
        Me.TextBoxBook.TabIndex = 12
        '
        'TextBoxCD
        '
        Me.TextBoxCD.Location = New System.Drawing.Point(679, 192)
        Me.TextBoxCD.Name = "TextBoxCD"
        Me.TextBoxCD.Size = New System.Drawing.Size(61, 19)
        Me.TextBoxCD.TabIndex = 13
        '
        'ComboClassification
        '
        Me.ComboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboClassification.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboClassification.FormattingEnabled = True
        Me.ComboClassification.Location = New System.Drawing.Point(418, 247)
        Me.ComboClassification.Name = "ComboClassification"
        Me.ComboClassification.Size = New System.Drawing.Size(173, 27)
        Me.ComboClassification.TabIndex = 14
        '
        'ComboShelf
        '
        Me.ComboShelf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboShelf.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboShelf.FormattingEnabled = True
        Me.ComboShelf.Location = New System.Drawing.Point(619, 247)
        Me.ComboShelf.Name = "ComboShelf"
        Me.ComboShelf.Size = New System.Drawing.Size(121, 27)
        Me.ComboShelf.TabIndex = 15
        '
        'CheckLendingban
        '
        Me.CheckLendingban.AutoSize = True
        Me.CheckLendingban.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckLendingban.ForeColor = System.Drawing.Color.Red
        Me.CheckLendingban.Location = New System.Drawing.Point(813, 249)
        Me.CheckLendingban.Name = "CheckLendingban"
        Me.CheckLendingban.Size = New System.Drawing.Size(85, 23)
        Me.CheckLendingban.TabIndex = 16
        Me.CheckLendingban.Text = "禁貸出"
        Me.CheckLendingban.UseVisualStyleBackColor = True
        '
        'LblBookName1
        '
        Me.LblBookName1.AutoSize = True
        Me.LblBookName1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookName1.Location = New System.Drawing.Point(161, 331)
        Me.LblBookName1.Name = "LblBookName1"
        Me.LblBookName1.Size = New System.Drawing.Size(67, 19)
        Me.LblBookName1.TabIndex = 17
        Me.LblBookName1.Text = "書名1 :"
        '
        'LblBookName2
        '
        Me.LblBookName2.AutoSize = True
        Me.LblBookName2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblBookName2.Location = New System.Drawing.Point(161, 373)
        Me.LblBookName2.Name = "LblBookName2"
        Me.LblBookName2.Size = New System.Drawing.Size(67, 19)
        Me.LblBookName2.TabIndex = 18
        Me.LblBookName2.Text = "書名2 :"
        '
        'TextBoxBookName1
        '
        Me.TextBoxBookName1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxBookName1.Location = New System.Drawing.Point(245, 328)
        Me.TextBoxBookName1.Name = "TextBoxBookName1"
        Me.TextBoxBookName1.Size = New System.Drawing.Size(653, 26)
        Me.TextBoxBookName1.TabIndex = 19
        '
        'TextBoxBookName2
        '
        Me.TextBoxBookName2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxBookName2.Location = New System.Drawing.Point(245, 366)
        Me.TextBoxBookName2.Name = "TextBoxBookName2"
        Me.TextBoxBookName2.Size = New System.Drawing.Size(653, 26)
        Me.TextBoxBookName2.TabIndex = 20
        '
        'ButtonSignUp
        '
        Me.ButtonSignUp.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonSignUp.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSignUp.Location = New System.Drawing.Point(28, 618)
        Me.ButtonSignUp.Name = "ButtonSignUp"
        Me.ButtonSignUp.Size = New System.Drawing.Size(200, 100)
        Me.ButtonSignUp.TabIndex = 22
        Me.ButtonSignUp.Text = "登録"
        Me.ButtonSignUp.UseVisualStyleBackColor = False
        '
        'ButtonDelete
        '
        Me.ButtonDelete.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ButtonDelete.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonDelete.Location = New System.Drawing.Point(289, 618)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(200, 100)
        Me.ButtonDelete.TabIndex = 23
        Me.ButtonDelete.Text = "削除"
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'ButtonList
        '
        Me.ButtonList.BackColor = System.Drawing.Color.LawnGreen
        Me.ButtonList.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonList.Location = New System.Drawing.Point(540, 618)
        Me.ButtonList.Name = "ButtonList"
        Me.ButtonList.Size = New System.Drawing.Size(200, 100)
        Me.ButtonList.TabIndex = 24
        Me.ButtonList.Text = "一覧"
        Me.ButtonList.UseVisualStyleBackColor = False
        '
        'ButtonReturn
        '
        Me.ButtonReturn.BackColor = System.Drawing.Color.Aquamarine
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(779, 618)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(200, 100)
        Me.ButtonReturn.TabIndex = 25
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = False
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(171, 476)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(57, 19)
        Me.LblRemarks.TabIndex = 26
        Me.LblRemarks.Text = "備考 :"
        '
        'TextBoxRemarks
        '
        Me.TextBoxRemarks.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRemarks.Location = New System.Drawing.Point(245, 441)
        Me.TextBoxRemarks.Multiline = True
        Me.TextBoxRemarks.Name = "TextBoxRemarks"
        Me.TextBoxRemarks.Size = New System.Drawing.Size(653, 115)
        Me.TextBoxRemarks.TabIndex = 21
        '
        'BookMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.TextBoxRemarks)
        Me.Controls.Add(Me.LblRemarks)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonList)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonSignUp)
        Me.Controls.Add(Me.TextBoxBookName2)
        Me.Controls.Add(Me.TextBoxBookName1)
        Me.Controls.Add(Me.LblBookName2)
        Me.Controls.Add(Me.LblBookName1)
        Me.Controls.Add(Me.CheckLendingban)
        Me.Controls.Add(Me.ComboShelf)
        Me.Controls.Add(Me.ComboClassification)
        Me.Controls.Add(Me.TextBoxCD)
        Me.Controls.Add(Me.TextBoxBook)
        Me.Controls.Add(Me.TextBoxPublisher)
        Me.Controls.Add(Me.TextBoxGroup)
        Me.Controls.Add(Me.TextBoxFlg)
        Me.Controls.Add(Me.LblCD)
        Me.Controls.Add(Me.LblBook)
        Me.Controls.Add(Me.LblPublisher)
        Me.Controls.Add(Me.Lblgroup)
        Me.Controls.Add(Me.Lblflg)
        Me.Controls.Add(Me.TextBoxISBN)
        Me.Controls.Add(Me.LblBookmst)
        Me.Name = "BookMst"
        Me.Text = "書籍管理システム - 書籍マスタ管理画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblBookmst As System.Windows.Forms.Label
    Friend WithEvents TextBoxISBN As System.Windows.Forms.TextBox
    Friend WithEvents Lblflg As System.Windows.Forms.Label
    Friend WithEvents Lblgroup As System.Windows.Forms.Label
    Friend WithEvents LblPublisher As System.Windows.Forms.Label
    Friend WithEvents LblBook As System.Windows.Forms.Label
    Friend WithEvents LblCD As System.Windows.Forms.Label
    Friend WithEvents TextBoxFlg As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxGroup As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPublisher As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxBook As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCD As System.Windows.Forms.TextBox
    Friend WithEvents ComboClassification As System.Windows.Forms.ComboBox
    Friend WithEvents ComboShelf As System.Windows.Forms.ComboBox
    Friend WithEvents CheckLendingban As System.Windows.Forms.CheckBox
    Friend WithEvents LblBookName1 As System.Windows.Forms.Label
    Friend WithEvents LblBookName2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBookName1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxBookName2 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSignUp As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonList As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
    Friend WithEvents LblRemarks As System.Windows.Forms.Label
    Friend WithEvents TextBoxRemarks As System.Windows.Forms.TextBox
End Class
