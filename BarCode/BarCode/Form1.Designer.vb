<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBoxX = New System.Windows.Forms.TextBox
        Me.TextBoxY = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxHeight = New System.Windows.Forms.TextBox
        Me.TextBoxWidth = New System.Windows.Forms.TextBox
        Me.TextBoxCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "描画"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(64, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBoxX
        '
        Me.TextBoxX.Location = New System.Drawing.Point(171, 14)
        Me.TextBoxX.Name = "TextBoxX"
        Me.TextBoxX.Size = New System.Drawing.Size(45, 19)
        Me.TextBoxX.TabIndex = 2
        Me.TextBoxX.Text = "0"
        '
        'TextBoxY
        '
        Me.TextBoxY.Location = New System.Drawing.Point(171, 45)
        Me.TextBoxY.Name = "TextBoxY"
        Me.TextBoxY.Size = New System.Drawing.Size(45, 19)
        Me.TextBoxY.TabIndex = 3
        Me.TextBoxY.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Height"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Width"
        '
        'TextBoxHeight
        '
        Me.TextBoxHeight.Location = New System.Drawing.Point(282, 16)
        Me.TextBoxHeight.Name = "TextBoxHeight"
        Me.TextBoxHeight.Size = New System.Drawing.Size(40, 19)
        Me.TextBoxHeight.TabIndex = 8
        Me.TextBoxHeight.Text = "60"
        '
        'TextBoxWidth
        '
        Me.TextBoxWidth.Location = New System.Drawing.Point(282, 45)
        Me.TextBoxWidth.Name = "TextBoxWidth"
        Me.TextBoxWidth.Size = New System.Drawing.Size(40, 19)
        Me.TextBoxWidth.TabIndex = 9
        Me.TextBoxWidth.Text = "100"
        '
        'TextBoxCode
        '
        Me.TextBoxCode.Location = New System.Drawing.Point(415, 45)
        Me.TextBoxCode.Name = "TextBoxCode"
        Me.TextBoxCode.Size = New System.Drawing.Size(306, 19)
        Me.TextBoxCode.TabIndex = 10
        Me.TextBoxCode.Text = "4902054104443"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(378, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Code"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(760, 480)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxCode)
        Me.Controls.Add(Me.TextBoxWidth)
        Me.Controls.Add(Me.TextBoxHeight)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxY)
        Me.Controls.Add(Me.TextBoxX)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBoxX As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxY As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxHeight As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxWidth As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
