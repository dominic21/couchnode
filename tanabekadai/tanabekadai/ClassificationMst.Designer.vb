<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClassificationMst
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
        Me.LblClassification = New System.Windows.Forms.Label
        Me.LblClassificationCode = New System.Windows.Forms.Label
        Me.LblClassificationName = New System.Windows.Forms.Label
        Me.TextBoxClassificationCD = New System.Windows.Forms.TextBox
        Me.TextBoxClassificationName = New System.Windows.Forms.TextBox
        Me.ButtonSignup = New System.Windows.Forms.Button
        Me.ButtonDelete = New System.Windows.Forms.Button
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LblClassification
        '
        Me.LblClassification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClassification.BackColor = System.Drawing.Color.Aquamarine
        Me.LblClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblClassification.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassification.Location = New System.Drawing.Point(196, 9)
        Me.LblClassification.Name = "LblClassification"
        Me.LblClassification.Size = New System.Drawing.Size(585, 30)
        Me.LblClassification.TabIndex = 1
        Me.LblClassification.Text = "分類マスタ管理画面"
        Me.LblClassification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClassificationCode
        '
        Me.LblClassificationCode.AutoSize = True
        Me.LblClassificationCode.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassificationCode.Location = New System.Drawing.Point(269, 272)
        Me.LblClassificationCode.Name = "LblClassificationCode"
        Me.LblClassificationCode.Size = New System.Drawing.Size(145, 28)
        Me.LblClassificationCode.TabIndex = 2
        Me.LblClassificationCode.Text = "分類コード :"
        '
        'LblClassificationName
        '
        Me.LblClassificationName.AutoSize = True
        Me.LblClassificationName.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblClassificationName.Location = New System.Drawing.Point(303, 330)
        Me.LblClassificationName.Name = "LblClassificationName"
        Me.LblClassificationName.Size = New System.Drawing.Size(111, 28)
        Me.LblClassificationName.TabIndex = 3
        Me.LblClassificationName.Text = "分類名 :"
        '
        'TextBoxClassificationCD
        '
        Me.TextBoxClassificationCD.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxClassificationCD.Location = New System.Drawing.Point(431, 269)
        Me.TextBoxClassificationCD.Name = "TextBoxClassificationCD"
        Me.TextBoxClassificationCD.Size = New System.Drawing.Size(88, 35)
        Me.TextBoxClassificationCD.TabIndex = 4
        '
        'TextBoxClassificationName
        '
        Me.TextBoxClassificationName.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxClassificationName.Location = New System.Drawing.Point(431, 327)
        Me.TextBoxClassificationName.Name = "TextBoxClassificationName"
        Me.TextBoxClassificationName.Size = New System.Drawing.Size(272, 35)
        Me.TextBoxClassificationName.TabIndex = 5
        '
        'ButtonSignup
        '
        Me.ButtonSignup.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonSignup.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSignup.Location = New System.Drawing.Point(45, 618)
        Me.ButtonSignup.Name = "ButtonSignup"
        Me.ButtonSignup.Size = New System.Drawing.Size(200, 100)
        Me.ButtonSignup.TabIndex = 6
        Me.ButtonSignup.Text = "登録"
        Me.ButtonSignup.UseVisualStyleBackColor = False
        '
        'ButtonDelete
        '
        Me.ButtonDelete.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ButtonDelete.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonDelete.Location = New System.Drawing.Point(273, 618)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(200, 100)
        Me.ButtonDelete.TabIndex = 7
        Me.ButtonDelete.Text = "削除"
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'ButtonReturn
        '
        Me.ButtonReturn.BackColor = System.Drawing.Color.Aquamarine
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(782, 618)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(200, 100)
        Me.ButtonReturn.TabIndex = 8
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = False
        '
        'ClassificationMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonSignup)
        Me.Controls.Add(Me.TextBoxClassificationName)
        Me.Controls.Add(Me.TextBoxClassificationCD)
        Me.Controls.Add(Me.LblClassificationName)
        Me.Controls.Add(Me.LblClassificationCode)
        Me.Controls.Add(Me.LblClassification)
        Me.Name = "ClassificationMst"
        Me.Text = "書籍管理システム - 分類マスタ管理画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblClassification As System.Windows.Forms.Label
    Friend WithEvents LblClassificationCode As System.Windows.Forms.Label
    Friend WithEvents LblClassificationName As System.Windows.Forms.Label
    Friend WithEvents TextBoxClassificationCD As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxClassificationName As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSignup As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
End Class
