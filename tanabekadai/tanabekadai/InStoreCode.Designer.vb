<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InStoreCode
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
        Me.ButtonReturn = New System.Windows.Forms.Button
        Me.ButtonSignup = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonReturn
        '
        Me.ButtonReturn.BackColor = System.Drawing.Color.Aquamarine
        Me.ButtonReturn.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonReturn.Location = New System.Drawing.Point(796, 618)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(200, 100)
        Me.ButtonReturn.TabIndex = 23
        Me.ButtonReturn.Text = "戻る"
        Me.ButtonReturn.UseVisualStyleBackColor = False
        '
        'ButtonSignup
        '
        Me.ButtonSignup.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonSignup.Font = New System.Drawing.Font("MS UI Gothic", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonSignup.Location = New System.Drawing.Point(12, 618)
        Me.ButtonSignup.Name = "ButtonSignup"
        Me.ButtonSignup.Size = New System.Drawing.Size(200, 100)
        Me.ButtonSignup.TabIndex = 24
        Me.ButtonSignup.Text = "生成"
        Me.ButtonSignup.UseVisualStyleBackColor = False
        '
        'InStoreCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonSignup)
        Me.Controls.Add(Me.ButtonReturn)
        Me.Name = "InStoreCode"
        Me.Text = "インストアコード生成"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonReturn As System.Windows.Forms.Button
    Friend WithEvents ButtonSignup As System.Windows.Forms.Button
End Class
