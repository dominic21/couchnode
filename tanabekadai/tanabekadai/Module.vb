Imports System.Runtime.InteropServices



Module tanabekadaiModule

    Public OraCla As ClassOraOdp = New ClassOraOdp
    Public LogCla As ClassLogWrite = New ClassLogWrite


    Public Sub CheckOdp(ByVal OwnerForm As System.Windows.Forms.Form)
        If Not OraCla.Connect Then
            LogCla.WriteLog("Module" & System.Reflection.MethodBase.GetCurrentMethod.Name, "一覧押下" & OraCla.sErrMessage)
            Dim Relogin As ReLogin = New ReLogin
            Relogin.Owner = OwnerForm
            Relogin.StartPosition = FormStartPosition.CenterParent
            Relogin.ShowDialog()
        End If
    End Sub
End Module
