Imports System.Drawing
Public Class BarCodeClass

#Region "共通変数"
    Private Canvas As Bitmap = New Bitmap(113, 76)
    Private Graphic As Graphics = Graphics.FromImage(Canvas)
    Private ScalingGraphic As Graphics
    Private sum As Integer = 0
    Private iX As Integer = 0
    Private iY As Integer = 0
    Private Width As Integer = 1
    Private Height As Integer = 69
#End Region


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="g">描画したいGraphicsオブジェクト System.Drawing.Graphics</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal g As System.Drawing.Graphics)
        ScalingGraphic = g
    End Sub

    ''' <summary>
    ''' バーコード描画
    ''' </summary>
    ''' <param name="Code">Jan桁13 String</param>
    ''' <param name="iX">表示したいX座標,記述無しなら0（左上起点）Int</param>
    ''' <param name="iY">表示したいY座標,記述無しなら0（左上起点）Int</param>
    ''' <param name="Width">バーコードの幅、記述無しなら113 Int</param>
    ''' <param name="Height">バーコードの高さ、記述無しなら69 Int</param>
    ''' <remarks></remarks>
    Public Sub DrawBarCode(ByVal Code As String, Optional ByVal iX As Integer = 0, Optional ByVal iY As Integer = 0, _
                           Optional ByVal Width As Integer = 113, Optional ByVal Height As Integer = 69)
        Try
            DrawBarCodeLine(Code, iX, iY, Width, Height)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    ''' <summary>
    ''' チェックディジット有バーコード描画
    ''' </summary>
    ''' <param name="Code">Jan桁13 String</param>
    ''' <param name="iX">表示したいX座標,記述無しなら0（左上起点）Int</param>
    ''' <param name="iY">表示したいY座標,記述無しなら0（左上起点）Int</param>
    ''' <param name="Width">バーコードの幅、記述無しなら113 Int</param>
    ''' <param name="Height">バーコードの高さ、記述無しなら69 Int</param>
    ''' <remarks></remarks>
    Public Sub CheckDrawBarCode(ByVal Code As String, Optional ByVal iX As Integer = 0, Optional ByVal iY As Integer = 0, _
                           Optional ByVal Width As Integer = 113, Optional ByVal Height As Integer = 69)
        Try
            If JANCheckDigit(Code) Then
                DrawBarCodeLine(Code, iX, iY, Width, Height)
            Else
                MsgBox("チェックディジットが一致しません")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' バーコード線描画
    ''' </summary>
    ''' <param name="Code">Jan桁13 String</param>
    ''' <param name="iX">表示したいX座標 Int</param>
    ''' <param name="iY">表示したいY座標 Int</param>
    ''' <param name="Width">バーコードの幅 Int</param>
    ''' <param name="Height">バーコードの高さ Int</param>
    ''' <remarks></remarks>
    Private Sub DrawBarCodeLine(ByVal Code As String, ByVal iX As Integer, ByVal iY As Integer, _
                           ByVal Width As Integer, ByVal Height As Integer)
        Try
            Margin(11)
            GuardBar()
            LeftDrawCode(Code)
            CenterBar()
            RightDrawCode(Code)
            GuardBar()
            Margin(7)
            Graphic.Dispose()
            ScalingGraphic.DrawImage(Canvas, iX, iY, Width, Height)
            Canvas.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' チェックディジット検査
    ''' </summary>
    ''' <param name="Code">JAN13桁 String</param>
    ''' <returns>Bool True or False</returns>
    ''' <remarks></remarks>
    Private Function JANCheckDigit(ByVal Code As String) As Boolean

        Try
            Dim sorting As String = ""
            Dim i As Integer = 11
            Dim sum As Integer = 0
            Dim flg As Boolean = False
            'While i >= 0
            '    sorting &= Code.Substring(i, 1)
            '    i -= 1
            'End While
            sorting = Code.Substring(0, 12)
            i = 0

            While i < sorting.Length
                sum += CInt(sorting.Substring(i, 1))
                sum += CInt(sorting.Substring(i + 1, 1)) * 3
                i += 2
            End While
            sum = 10 - CInt(sum.ToString.Substring(sum.ToString.Length - 1))

            If Code.Substring(Code.Length - 1, 1) = sum.ToString.Substring(sum.ToString.Length - 1, 1) Then
                flg = True
            End If

            Return flg
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    ''' <summary>
    ''' クワイエットゾーン描画
    ''' </summary>
    ''' <param name="Width">幅指定 Int</param>
    ''' <remarks></remarks>
    Private Sub Margin(ByVal Width As Integer)
        Try
            Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width + Me.Width, CInt(Height * 1.1))
            sum += Width + Me.Width
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' ガードバー描画
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GuardBar()
        Try
            Graphic.FillRectangle(Brushes.Black, sum + iX, iY, Width, CInt(Height * 1.1))
            sum += Width
            Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width, CInt(Height * 1.1))
            sum += Width
            Graphic.FillRectangle(Brushes.Black, sum + iX, iY, Width, CInt(Height * 1.1))
            sum += Width
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' センターバー描画
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CenterBar()
        Try
            Dim i As Integer = 0
            While i < 2
                Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width, CInt(Height * 1.1))
                sum += Width
                Graphic.FillRectangle(Brushes.Black, sum + iX, iY, Width, CInt(Height * 1.1))
                sum += Width
                i += 1
            End While
            Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width, CInt(Height * 1.1))
            sum += Width
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' JAN左キャラクタ描画
    ''' </summary>
    ''' <param name="Code">JAN13桁 String</param>
    ''' <remarks></remarks>
    Private Sub LeftDrawCode(ByVal Code As String)
        Try
            Dim iFirstDigit As Integer = CInt(Code.Substring(0, 1))
            Dim sSecondDigit As String = Code.Substring(1, 6)

            'Dim iCheckDigit As Integer = CInt(Code.Substring(12, 1))
            Dim iEvenOddPattern() As Integer

            '最初の数字で左キャラクタコードの偶奇分け
            Select Case iFirstDigit
                '0偶数 1奇数
                Case 1
                    iEvenOddPattern = New Integer() {1, 1, 0, 1, 0, 0}
                Case 2
                    iEvenOddPattern = New Integer() {1, 1, 0, 0, 1, 0}
                Case 3
                    iEvenOddPattern = New Integer() {1, 1, 0, 0, 0, 1}
                Case 4
                    iEvenOddPattern = New Integer() {1, 0, 1, 1, 0, 0}
                Case 5
                    iEvenOddPattern = New Integer() {1, 0, 0, 1, 1, 0}
                Case 6
                    iEvenOddPattern = New Integer() {1, 0, 0, 0, 1, 1}
                Case 7
                    iEvenOddPattern = New Integer() {1, 0, 1, 0, 1, 0}
                Case 8
                    iEvenOddPattern = New Integer() {1, 0, 1, 0, 0, 1}
                Case 9
                    iEvenOddPattern = New Integer() {1, 0, 0, 1, 0, 1}
                Case 0
                    iEvenOddPattern = New Integer() {1, 1, 1, 1, 1, 1}
                Case Else
                    MsgBox("FirstDigitエラー")
                    Exit Sub
            End Select

            Dim i As Integer = 0
            While i < 6

                Dim iSplit(,) As Integer = SplitDigit(sSecondDigit.Substring(i, 1))

                Dim x As Integer = 0
                While x < 4
                    Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width * iSplit(iEvenOddPattern(i), x), Height)
                    sum += Width * iSplit(iEvenOddPattern(i), x)
                    Graphic.FillRectangle(Brushes.Black, sum + iX, iY, Width * iSplit(iEvenOddPattern(i), x + 1), Height)
                    sum += Width * iSplit(iEvenOddPattern(i), x + 1)
                    x += 2
                End While

                i += 1
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' JAN右キャラクタ描画
    ''' </summary>
    ''' <param name="Code">JAN13桁 String</param>
    ''' <remarks></remarks>
    Private Sub RightDrawCode(ByVal Code As String)
        Try
            Dim sThirdDigit As String = Code.Substring(7, 6)
            Dim i As Integer = 0
            While i < 6

                Dim iSplit(,) As Integer = SplitDigit(sThirdDigit.Substring(i, 1))

                Dim x As Integer = 0
                While x < 4
                    Graphic.FillRectangle(Brushes.Black, sum + iX, iY, Width * iSplit(1, x), Height)
                    sum += Width * iSplit(1, x)
                    Graphic.FillRectangle(Brushes.White, sum + iX, iY, Width * iSplit(1, x + 1), Height)
                    sum += Width * iSplit(1, x + 1)
                    x += 2
                End While

                i += 1
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' キャラクタの描画法則
    ''' </summary>
    ''' <param name="Codex">キャラクタ１つ String</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SplitDigit(ByVal Codex As String) As Integer(,)
        Try
            Dim iSplit(,) As Integer

            '     偶数           奇数（右側もこっち）
            '{{1, 1, 2, 3}, {3, 2, 1, 1}}
            '{{1, 2, 2, 2}, {2, 2, 2, 1}}
            '{{2, 2, 1, 2}, {2, 1, 2, 2}}
            '{{1, 1, 4, 1}, {1, 4, 1, 1}}
            '{{2, 3, 1, 1}, {1, 1, 3, 2}}
            '{{1, 3, 2, 1}, {1, 2, 3, 1}}
            '{{4, 1, 1, 1}, {1, 1, 1, 4}}
            '{{2, 1, 3, 1}, {1, 3, 1, 2}}
            '{{3, 1, 2, 1}, {1, 2, 1, 3}}
            '{{2, 1, 1, 3}, {3, 1, 1, 2}}

            Select Case Codex
                Case "1"
                    iSplit = New Integer(,) {{1, 2, 2, 2}, {2, 2, 2, 1}}
                Case "2"
                    iSplit = New Integer(,) {{2, 2, 1, 2}, {2, 1, 2, 2}}
                Case "3"
                    iSplit = New Integer(,) {{1, 1, 4, 1}, {1, 4, 1, 1}}
                Case "4"
                    iSplit = New Integer(,) {{2, 3, 1, 1}, {1, 1, 3, 2}}
                Case "5"
                    iSplit = New Integer(,) {{1, 3, 2, 1}, {1, 2, 3, 1}}
                Case "6"
                    iSplit = New Integer(,) {{4, 1, 1, 1}, {1, 1, 1, 4}}
                Case "7"
                    iSplit = New Integer(,) {{2, 1, 3, 1}, {1, 3, 1, 2}}
                Case "8"
                    iSplit = New Integer(,) {{3, 1, 2, 1}, {1, 2, 1, 3}}
                Case "9"
                    iSplit = New Integer(,) {{2, 1, 1, 3}, {3, 1, 1, 2}}
                Case "0"
                    iSplit = New Integer(,) {{1, 1, 2, 3}, {3, 2, 1, 1}}
                Case Else
                    MsgBox("FirstDigitエラー")
                    iSplit = New Integer(,) {{}, {}}
                    Return iSplit
            End Select

            Return iSplit
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

End Class
