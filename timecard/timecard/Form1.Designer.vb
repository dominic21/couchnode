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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TypeARadio = New System.Windows.Forms.RadioButton
        Me.TypeBRadio = New System.Windows.Forms.RadioButton
        Me.TypeCRadio = New System.Windows.Forms.RadioButton
        Me.NyuuFileTxt = New System.Windows.Forms.TextBox
        Me.NyuuFileButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SyutsuhouhouBox = New System.Windows.Forms.ComboBox
        Me.SyutsuFileTxt = New System.Windows.Forms.TextBox
        Me.SyutsuFileButton = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.KyuukeiS1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.KyuukeiS2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.KyuukeiE1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.KyuukeiE2 = New System.Windows.Forms.TextBox
        Me.StartButton = New System.Windows.Forms.Button
        Me.ExitButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ファイルタイプ　："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "入力ファイル　："
        '
        'TypeARadio
        '
        Me.TypeARadio.AutoSize = True
        Me.TypeARadio.Checked = True
        Me.TypeARadio.Location = New System.Drawing.Point(100, 25)
        Me.TypeARadio.Name = "TypeARadio"
        Me.TypeARadio.Size = New System.Drawing.Size(57, 16)
        Me.TypeARadio.TabIndex = 2
        Me.TypeARadio.TabStop = True
        Me.TypeARadio.Text = "タイプA"
        Me.TypeARadio.UseVisualStyleBackColor = True
        '
        'TypeBRadio
        '
        Me.TypeBRadio.AutoSize = True
        Me.TypeBRadio.Location = New System.Drawing.Point(187, 25)
        Me.TypeBRadio.Name = "TypeBRadio"
        Me.TypeBRadio.Size = New System.Drawing.Size(57, 16)
        Me.TypeBRadio.TabIndex = 3
        Me.TypeBRadio.Text = "タイプB"
        Me.TypeBRadio.UseVisualStyleBackColor = True
        '
        'TypeCRadio
        '
        Me.TypeCRadio.AutoSize = True
        Me.TypeCRadio.Location = New System.Drawing.Point(274, 25)
        Me.TypeCRadio.Name = "TypeCRadio"
        Me.TypeCRadio.Size = New System.Drawing.Size(57, 16)
        Me.TypeCRadio.TabIndex = 4
        Me.TypeCRadio.Text = "タイプC"
        Me.TypeCRadio.UseVisualStyleBackColor = True
        '
        'NyuuFileTxt
        '
        Me.NyuuFileTxt.Location = New System.Drawing.Point(92, 57)
        Me.NyuuFileTxt.Name = "NyuuFileTxt"
        Me.NyuuFileTxt.Size = New System.Drawing.Size(257, 19)
        Me.NyuuFileTxt.TabIndex = 5
        '
        'NyuuFileButton
        '
        Me.NyuuFileButton.Location = New System.Drawing.Point(355, 55)
        Me.NyuuFileButton.Name = "NyuuFileButton"
        Me.NyuuFileButton.Size = New System.Drawing.Size(24, 23)
        Me.NyuuFileButton.TabIndex = 6
        Me.NyuuFileButton.Text = "..."
        Me.NyuuFileButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "出力方法 ："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "出力ファイル　："
        '
        'SyutsuhouhouBox
        '
        Me.SyutsuhouhouBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SyutsuhouhouBox.FormattingEnabled = True
        Me.SyutsuhouhouBox.Location = New System.Drawing.Point(91, 18)
        Me.SyutsuhouhouBox.Name = "SyutsuhouhouBox"
        Me.SyutsuhouhouBox.Size = New System.Drawing.Size(121, 20)
        Me.SyutsuhouhouBox.TabIndex = 9
        '
        'SyutsuFileTxt
        '
        Me.SyutsuFileTxt.Location = New System.Drawing.Point(91, 59)
        Me.SyutsuFileTxt.Name = "SyutsuFileTxt"
        Me.SyutsuFileTxt.Size = New System.Drawing.Size(257, 19)
        Me.SyutsuFileTxt.TabIndex = 10
        '
        'SyutsuFileButton
        '
        Me.SyutsuFileButton.Location = New System.Drawing.Point(354, 57)
        Me.SyutsuFileButton.Name = "SyutsuFileButton"
        Me.SyutsuFileButton.Size = New System.Drawing.Size(24, 23)
        Me.SyutsuFileButton.TabIndex = 11
        Me.SyutsuFileButton.Text = "..."
        Me.SyutsuFileButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "休憩時刻設定　："
        '
        'KyuukeiS1
        '
        Me.KyuukeiS1.Location = New System.Drawing.Point(165, 230)
        Me.KyuukeiS1.Name = "KyuukeiS1"
        Me.KyuukeiS1.Size = New System.Drawing.Size(24, 19)
        Me.KyuukeiS1.TabIndex = 13
        Me.KyuukeiS1.Text = "12"
        Me.KyuukeiS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(195, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(7, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = ":"
        '
        'KyuukeiS2
        '
        Me.KyuukeiS2.Location = New System.Drawing.Point(208, 230)
        Me.KyuukeiS2.Name = "KyuukeiS2"
        Me.KyuukeiS2.Size = New System.Drawing.Size(24, 19)
        Me.KyuukeiS2.TabIndex = 15
        Me.KyuukeiS2.Text = "00"
        Me.KyuukeiS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(238, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "～"
        '
        'KyuukeiE1
        '
        Me.KyuukeiE1.Location = New System.Drawing.Point(261, 230)
        Me.KyuukeiE1.Name = "KyuukeiE1"
        Me.KyuukeiE1.Size = New System.Drawing.Size(24, 19)
        Me.KyuukeiE1.TabIndex = 17
        Me.KyuukeiE1.Text = "13"
        Me.KyuukeiE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(291, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(7, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = ":"
        '
        'KyuukeiE2
        '
        Me.KyuukeiE2.Location = New System.Drawing.Point(304, 230)
        Me.KyuukeiE2.Name = "KyuukeiE2"
        Me.KyuukeiE2.Size = New System.Drawing.Size(24, 19)
        Me.KyuukeiE2.TabIndex = 19
        Me.KyuukeiE2.Text = "00"
        Me.KyuukeiE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StartButton
        '
        Me.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.StartButton.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.StartButton.Location = New System.Drawing.Point(105, 327)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(122, 44)
        Me.StartButton.TabIndex = 20
        Me.StartButton.Text = "実行"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ExitButton.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(274, 327)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(122, 44)
        Me.ExitButton.TabIndex = 21
        Me.ExitButton.Text = "終了"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TypeARadio)
        Me.GroupBox1.Controls.Add(Me.TypeBRadio)
        Me.GroupBox1.Controls.Add(Me.TypeCRadio)
        Me.GroupBox1.Controls.Add(Me.NyuuFileTxt)
        Me.GroupBox1.Controls.Add(Me.NyuuFileButton)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 92)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.SyutsuhouhouBox)
        Me.GroupBox2.Controls.Add(Me.SyutsuFileTxt)
        Me.GroupBox2.Controls.Add(Me.SyutsuFileButton)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 92)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(71, 261)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(47, 12)
        Me.lblStartDate.TabIndex = 24
        Me.lblStartDate.Text = "開始日："
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(123, 256)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(205, 19)
        Me.dtpStart.TabIndex = 25
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(71, 289)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(47, 12)
        Me.lblEndDate.TabIndex = 26
        Me.lblEndDate.Text = "終了日："
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(123, 284)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(205, 19)
        Me.dtpEnd.TabIndex = 27
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 396)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.KyuukeiE2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.KyuukeiE1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.KyuukeiS2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.KyuukeiS1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "Form1"
        Me.Text = "タイムカードデータ集計ツール"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TypeARadio As System.Windows.Forms.RadioButton
    Friend WithEvents TypeBRadio As System.Windows.Forms.RadioButton
    Friend WithEvents TypeCRadio As System.Windows.Forms.RadioButton
    Friend WithEvents NyuuFileTxt As System.Windows.Forms.TextBox
    Friend WithEvents NyuuFileButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SyutsuhouhouBox As System.Windows.Forms.ComboBox
    Friend WithEvents SyutsuFileTxt As System.Windows.Forms.TextBox
    Friend WithEvents SyutsuFileButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents KyuukeiS1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KyuukeiS2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents KyuukeiE1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents KyuukeiE2 As System.Windows.Forms.TextBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker

End Class
