Public Class MenuForm

    Dim bReturnFlg As Boolean = True


    Private Sub MenuForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            '戻る時にこのフォームをクローズするけどプログラムは終了させたくないのでフラグ追加。
            If bReturnFlg Then
                'このフォームが(右上×などで)閉じられたときプログラムを終了させる。
                OraCla.DisConnect()
                End
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            'ログイン画面を見えるようにして自分を閉じる
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Owner.Visible = True
            bReturnFlg = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonRental_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRental.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "貸出処理画面押下")
            Dim ShowRental As Rental = New Rental
            ShowRental.Owner = Me
            ShowRental.StartPosition = FormStartPosition.CenterParent
            ShowRental.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBook.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "書籍マスタ管理画面押下")
            Dim ShowBookMst As BookMst = New BookMst()
            ShowBookMst.Owner = Me
            ShowBookMst.StartPosition = FormStartPosition.CenterParent
            ShowBookMst.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClassification.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "分類マスタ押下")
            Dim ShowClassification As ClassificationMst = New ClassificationMst
            ShowClassification.Owner = Me
            ShowClassification.StartPosition = FormStartPosition.CenterParent
            ShowClassification.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonShelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShelf.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "棚マスタ押下")
            Dim ShowShelf As ShelfMst = New ShelfMst
            ShowShelf.Owner = Me
            ShowShelf.StartPosition = FormStartPosition.CenterParent
            ShowShelf.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonInstore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInstore.Click
        Try
            'モーダルで開く
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "インストアコード生成押下")
            Dim ShowShelf As InStoreCode = New InStoreCode
            ShowShelf.Owner = Me
            ShowShelf.StartPosition = FormStartPosition.CenterParent
            ShowShelf.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MenuForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class