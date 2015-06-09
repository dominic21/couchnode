<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formlogin
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
        Me.LblLogin = New System.Windows.Forms.Label
        Me.LblStaff = New System.Windows.Forms.Label
        Me.TextBoxStaff = New System.Windows.Forms.TextBox
        Me.LblStaffName = New System.Windows.Forms.Label
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ButtonEnd = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LblLogin
        '
        Me.LblLogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLogin.BackColor = System.Drawing.Color.Aquamarine
        Me.LblLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblLogin.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblLogin.Location = New System.Drawing.Point(211, 9)
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(570, 30)
        Me.LblLogin.TabIndex = 0
        Me.LblLogin.Text = "ログイン画面"
        Me.LblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStaff
        '
        Me.LblStaff.AutoSize = True
        Me.LblStaff.Font = New System.Drawing.Font("MS UI Gothic", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStaff.Location = New System.Drawing.Point(114, 120)
        Me.LblStaff.Name = "LblStaff"
        Me.LblStaff.Size = New System.Drawing.Size(150, 31)
        Me.LblStaff.TabIndex = 1
        Me.LblStaff.Text = "社員コード:"
        '
        'TextBoxStaff
        '
        Me.TextBoxStaff.Font = New System.Drawing.Font("MS UI Gothic", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxStaff.Location = New System.Drawing.Point(289, 126)
        Me.TextBoxStaff.Name = "TextBoxStaff"
        Me.TextBoxStaff.Size = New System.Drawing.Size(249, 29)
        Me.TextBoxStaff.TabIndex = 2
        '
        'LblStaffName
        '
        Me.LblStaffName.AutoSize = True
        Me.LblStaffName.Font = New System.Drawing.Font("MS UI Gothic", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblStaffName.Location = New System.Drawing.Point(283, 206)
        Me.LblStaffName.Name = "LblStaffName"
        Me.LblStaffName.Size = New System.Drawing.Size(178, 31)
        Me.LblStaffName.TabIndex = 3
        Me.LblStaffName.Text = "社員名ラベル"
        '
        'ButtonStart
        '
        Me.ButtonStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonStart.Font = New System.Drawing.Font("MS UI Gothic", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonStart.Location = New System.Drawing.Point(45, 552)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(262, 139)
        Me.ButtonStart.TabIndex = 4
        Me.ButtonStart.Text = "開始"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonEnd
        '
        Me.ButtonEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEnd.Font = New System.Drawing.Font("MS UI Gothic", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonEnd.Location = New System.Drawing.Point(692, 552)
        Me.ButtonEnd.Name = "ButtonEnd"
        Me.ButtonEnd.Size = New System.Drawing.Size(262, 139)
        Me.ButtonEnd.TabIndex = 5
        Me.ButtonEnd.Text = "終了"
        Me.ButtonEnd.UseVisualStyleBackColor = True
        '
        'Formlogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.ButtonEnd)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.LblStaffName)
        Me.Controls.Add(Me.TextBoxStaff)
        Me.Controls.Add(Me.LblStaff)
        Me.Controls.Add(Me.LblLogin)
        Me.Name = "Formlogin"
        Me.Text = "書籍管理システム - ログイン画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblLogin As System.Windows.Forms.Label
    Friend WithEvents LblStaff As System.Windows.Forms.Label
    Friend WithEvents TextBoxStaff As System.Windows.Forms.TextBox
    Friend WithEvents LblStaffName As System.Windows.Forms.Label
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonEnd As System.Windows.Forms.Button

End Class
