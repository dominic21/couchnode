Public Class InStoreCode

    Private Sub ButtonSignup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSignup.Click
        Try
            Dim sInstoreCode As String
            Dim i As Integer = 11
            Dim sum As Integer = 0
            Dim sbSqlCmd As System.Text.StringBuilder = New System.Text.StringBuilder

            sbSqlCmd.Append("SELECT INSTORE_CODE.NEXTVAL FROM DUAL")
            Do
                CheckOdp(Me)
                sInstoreCode = Format(CInt(OraCla.GetStrValue(sbSqlCmd.ToString)), "200000000000")
                OraCla.CheckInstance()
            Loop While Not OraCla.Connect


            i = 0

            While i < sInstoreCode.Length
                sum += CInt(sInstoreCode.Substring(i, 1))
                sum += CInt(sInstoreCode.Substring(i + 1, 1)) * 3
                i += 2
            End While
            sum = 10 - CInt(sum.ToString.Substring(sum.ToString.Length - 1))
            sInstoreCode &= sum.ToString
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "インストアコード生成 : " & sInstoreCode)


            '書籍マスタに値を渡して開く
            'Showをオーバーライドするのとどっちがいいのだろう
            Dim ShowBookMst As BookMst = New BookMst(sInstoreCode)
            ShowBookMst.Owner = MenuForm
            ShowBookMst.StartPosition = FormStartPosition.CenterParent
            ShowBookMst.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReturn.Click
        Try
            LogCla.WriteLog(Me.[GetType]().Name & System.Reflection.MethodBase.GetCurrentMethod.Name, "戻る押下")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


End Class