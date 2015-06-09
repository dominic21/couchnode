Public Class Form1
    'Dim g As Bitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
    'Dim g As Bitmap = New Bitmap(200, 100)
    Private drawRectangle As Rectangle
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim g As Bitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Dim gra As Graphics = Graphics.FromImage(g)
            Dim BarCode As BarCodeClass = New BarCodeClass(gra)



            Dim Code As String = TextBoxCode.Text

            Dim iX As Integer = CInt(TextBoxX.Text)
            Dim iY As Integer = CInt(TextBoxY.Text)
            Dim Width As Integer = CInt(TextBoxWidth.Text)
            Dim Height As Integer = CInt(TextBoxHeight.Text)

            'Dim canvas As Bitmap = New Bitmap(200, 100)
            'Dim NewGra As Graphics = Graphics.FromImage(canvas)
            'Dim BarCode As BarCodeClass = New BarCodeClass(g)



            'Dim Line As Single = 1

            'Dim i As Integer = 0

            'While i <= 112
            '    gra.FillRectangle(Brushes.Black, 10 + Line * i, 20, Line, 50)
            '    gra.FillRectangle(Brushes.White, 10 + Line * i + 1, 20, Line, 50)
            '    i += 2
            'End While
            'gra.Dispose()
            'PictureBox1.Image = g

            If Code = "" Or Code.Length <> 13 Then
                Code = "4902054104443"
            End If


            BarCode.DrawBarCode(Code)
            'Dim img As System.Drawing.Image = g
            'gra.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            'gra.DrawImage(canvas, 10, 20, Width, Height)
            'gra.Dispose()
            PictureBox1.Image = g

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub

    'Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

    '    If Not (g Is Nothing) Then
    '        e.Graphics.DrawImage(g, drawRectangle)
    '    End If


    'End Sub
End Class
