<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrForm
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
        Me.OKButton = New System.Windows.Forms.Button
        Me.LblErr = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("MS UI Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.OKButton.Location = New System.Drawing.Point(116, 95)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(158, 65)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'LblErr
        '
        Me.LblErr.Font = New System.Drawing.Font("MS UI Gothic", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblErr.Location = New System.Drawing.Point(96, 21)
        Me.LblErr.Name = "LblErr"
        Me.LblErr.Size = New System.Drawing.Size(190, 53)
        Me.LblErr.TabIndex = 1
        Me.LblErr.Text = "正しい社員コードを入力してください。"
        '
        'ErrForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblErr)
        Me.Controls.Add(Me.OKButton)
        Me.Name = "ErrForm"
        Me.Text = "エラー"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LblErr As System.Windows.Forms.Label
End Class
