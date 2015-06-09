Imports System.Runtime.InteropServices

Module GetIniModule

    ''' <summary>
    ''' ini取り込み
    ''' </summary>
    ''' <param name="lpAppName"></param>
    ''' <param name="lpKeyName"></param>
    ''' <param name="lpDefault"></param>
    ''' <param name="lpReturnedString"></param>
    ''' <param name="nSize"></param>
    ''' <param name="lpFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)> _
Public Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, _
ByVal lpFileName As String) As Integer
    End Function

    ''' <summary>
    ''' ini取り込み内容設定
    ''' </summary>
    ''' <param name="KEY"></param>
    ''' <param name="Section"></param>
    ''' <param name="ININame"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetINIValue(ByVal KEY As String, ByVal Section As String, ByVal ININame As String) As String
        Dim value As New System.Text.StringBuilder
        value.Capacity = 256    'バッファーのサイズを指定
        Call GetPrivateProfileString(Section, KEY, "ERROR", value, value.Capacity, ININame)
        Return value.ToString
    End Function
End Module
