<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShelfMst
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
        Me.LblShelfMst = New System.Windows.Forms.Label
        Me.LblShelfNo = New System.Windows.Forms.Label
        Me.TextBoxShelf = New System.Windows.Forms.TextBox
        Me.LblStageNo = New System.Windows.Forms.Label
        Me.TextBoxStage = New System.Windows.Forms.TextBox
        Me.LblRemarks = New System.Windows.Forms.Label
        Me.TextBoxRemarks = New System.Windows.Forms.TextBox
        Me.ButtonSignup = New System.Windows.Forms.Button
        Me.ButtonDelete = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LblShelfMst
        '
        Me.LblShelfMst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblShelfMst.BackColor = System.Drawing.Color.Aquamarine
        Me.LblShelfMst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblShelfMst.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblShelfMst.Location = New System.Drawing.Point(162, 9)
        Me.LblShelfMst.Name = "LblShelfMst"
        Me.LblShelfMst.Size = New System.Drawing.Size(671, 30)
        Me.LblShelfMst.TabIndex = 2
        Me.LblShelfMst.Text = "棚マスタ管理画面"
        Me.LblShelfMst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShelfNo
        '
        Me.LblShelfNo.AutoSize = True
        Me.LblShelfNo.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblShelfNo.Location = New System.Drawing.Point(264, 254)
        Me.LblShelfNo.Name = "LblShelfNo"
        Me.LblShelfNo.Size = New System.Drawing.Size(93, 28)
        Me.LblShelfNo.TabIndex = 3
        Me.LblShelfNo.Text = "棚No. :"
        '
        'TextBoxShelf
        '
        Me.TextBoxShelf.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxShelf.Location = New System.Drawing.Point(363, 251)
        Me.TextBoxShelf.Name = "TextBoxShelf"
        Me.TextBoxShelf.Size = New System.Drawing.Size(100, 35)
        Me.TextBoxShelf.TabIndex = 4
        '
        'LblStageNo
        '
        Me.LblStageNo.AutoSize = True
        Me.LblStageNo.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStageNo.Location = New System.Drawing.Point(522, 254)
        Me.LblStageNo.Name = "LblStageNo"
        Me.LblStageNo.Size = New System.Drawing.Size(93, 28)
        Me.LblStageNo.TabIndex = 5
        Me.LblStageNo.Text = "段No. :"
        '
        'TextBoxStage
        '
        Me.TextBoxStage.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxStage.Location = New System.Drawing.Point(621, 251)
        Me.TextBoxStage.Name = "TextBoxStage"
        Me.TextBoxStage.Size = New System.Drawing.Size(100, 35)
        Me.TextBoxStage.TabIndex = 6
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(264, 343)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(83, 28)
        Me.LblRemarks.TabIndex = 7
        Me.LblRemarks.Text = "備考 :"
        '
        'TextBoxRemarks
        '
        Me.TextBoxRemarks.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRemarks.Location = New System.Drawing.Point(353, 340)
        Me.TextBoxRemarks.Name = "TextBoxRemarks"
        Me.TextBoxRemarks.Size = New System.Drawing.Size(286, 35)
        Me.TextBoxRemarks.TabIndex = 8
        '
        'ButtonSignup
        '
        Me.ButtonSignup.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSignup.Location = New System.Drawing.Point(23, 618)
        Me.ButtonSignup.Name = "ButtonSignup"
        Me.ButtonSignup.Size = New System.Drawing.Size(200, 100)
        Me.ButtonSignup.TabIndex = 9
        Me.ButtonSignup.Text = "登録"
        Me.ButtonSignup.UseVisualStyleBackColor = True
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonDelete.Location = New System.Drawing.Point(547, 618)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(200, 100)
        Me.ButtonDelete.TabIndex = 10
        Me.ButtonDelete.Text = "削除"
        Me.ButtonDelete.UseVisualStyleBackColor = True
        '
        'ButtonReturn
        '
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(796, 618)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(200, 100)
        Me.ButtonReturn.TabIndex = 11
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = True
        '
        'ShelfMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonSignup)
        Me.Controls.Add(Me.TextBoxRemarks)
        Me.Controls.Add(Me.LblRemarks)
        Me.Controls.Add(Me.TextBoxStage)
        Me.Controls.Add(Me.LblStageNo)
        Me.Controls.Add(Me.TextBoxShelf)
        Me.Controls.Add(Me.LblShelfNo)
        Me.Controls.Add(Me.LblShelfMst)
        Me.Name = "ShelfMst"
        Me.Text = "書籍管理システム - 棚マスタ管理画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblShelfMst As System.Windows.Forms.Label
    Friend WithEvents LblShelfNo As System.Windows.Forms.Label
    Friend WithEvents TextBoxShelf As System.Windows.Forms.TextBox
    Friend WithEvents LblStageNo As System.Windows.Forms.Label
    Friend WithEvents TextBoxStage As System.Windows.Forms.TextBox
    Friend WithEvents LblRemarks As System.Windows.Forms.Label
    Friend WithEvents TextBoxRemarks As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSignup As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
End Class
