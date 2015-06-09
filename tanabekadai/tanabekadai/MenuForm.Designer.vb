<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.Lblmenu = New System.Windows.Forms.Label
        Me.ButtonRental = New System.Windows.Forms.Button
        Me.ButtonBook = New System.Windows.Forms.Button
        Me.ButtonClassification = New System.Windows.Forms.Button
        Me.ButtonShelf = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.ButtonInstore = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Lblmenu
        '
        Me.Lblmenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lblmenu.BackColor = System.Drawing.Color.Aquamarine
        Me.Lblmenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lblmenu.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lblmenu.Location = New System.Drawing.Point(211, 9)
        Me.Lblmenu.Name = "Lblmenu"
        Me.Lblmenu.Size = New System.Drawing.Size(578, 30)
        Me.Lblmenu.TabIndex = 1
        Me.Lblmenu.Text = "メニュー画面"
        Me.Lblmenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonRental
        '
        Me.ButtonRental.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonRental.Location = New System.Drawing.Point(55, 99)
        Me.ButtonRental.Name = "ButtonRental"
        Me.ButtonRental.Size = New System.Drawing.Size(395, 533)
        Me.ButtonRental.TabIndex = 2
        Me.ButtonRental.Text = "貸出処理画面"
        Me.ButtonRental.UseVisualStyleBackColor = True
        '
        'ButtonBook
        '
        Me.ButtonBook.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonBook.Location = New System.Drawing.Point(514, 99)
        Me.ButtonBook.Name = "ButtonBook"
        Me.ButtonBook.Size = New System.Drawing.Size(456, 80)
        Me.ButtonBook.TabIndex = 3
        Me.ButtonBook.Text = "書籍マスタ管理画面"
        Me.ButtonBook.UseVisualStyleBackColor = True
        '
        'ButtonClassification
        '
        Me.ButtonClassification.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonClassification.Location = New System.Drawing.Point(514, 357)
        Me.ButtonClassification.Name = "ButtonClassification"
        Me.ButtonClassification.Size = New System.Drawing.Size(456, 80)
        Me.ButtonClassification.TabIndex = 4
        Me.ButtonClassification.Text = "分類マスタ管理画面"
        Me.ButtonClassification.UseVisualStyleBackColor = True
        '
        'ButtonShelf
        '
        Me.ButtonShelf.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonShelf.Location = New System.Drawing.Point(514, 271)
        Me.ButtonShelf.Name = "ButtonShelf"
        Me.ButtonShelf.Size = New System.Drawing.Size(456, 80)
        Me.ButtonShelf.TabIndex = 5
        Me.ButtonShelf.Text = "棚マスタ管理画面"
        Me.ButtonShelf.UseVisualStyleBackColor = True
        '
        'ButtonReturn
        '
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(514, 475)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(456, 157)
        Me.ButtonReturn.TabIndex = 7
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = True
        '
        'ButtonInstore
        '
        Me.ButtonInstore.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonInstore.Location = New System.Drawing.Point(514, 185)
        Me.ButtonInstore.Name = "ButtonInstore"
        Me.ButtonInstore.Size = New System.Drawing.Size(456, 80)
        Me.ButtonInstore.TabIndex = 6
        Me.ButtonInstore.Text = "インストアコード生成"
        Me.ButtonInstore.UseVisualStyleBackColor = True
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonInstore)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonShelf)
        Me.Controls.Add(Me.ButtonClassification)
        Me.Controls.Add(Me.ButtonBook)
        Me.Controls.Add(Me.ButtonRental)
        Me.Controls.Add(Me.Lblmenu)
        Me.Name = "MenuForm"
        Me.Text = "書籍管理システム - メニュー画面"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lblmenu As System.Windows.Forms.Label
    Friend WithEvents ButtonRental As System.Windows.Forms.Button
    Friend WithEvents ButtonBook As System.Windows.Forms.Button
    Friend WithEvents ButtonClassification As System.Windows.Forms.Button
    Friend WithEvents ButtonShelf As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
    Friend WithEvents ButtonInstore As System.Windows.Forms.Button
End Class
