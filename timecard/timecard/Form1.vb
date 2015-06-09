Public Class Form1
#Region "共通変数"
    Dim LogWrite As System.IO.StreamWriter
    Dim sPrintName() As String
    Dim sPrintDate(5, 0) As String
    Dim sPrintGoukei(2, 0) As String
    Dim iDateTimes As Integer
    Dim iNameTimes As Integer
    Dim iSumTimes As Integer
    Dim iStaffcode() As Integer
    Dim iErr As Integer
    Dim sErrgyou As String
#End Region

#Region "内部関数"

    ''' <summary>
    ''' ファイルタイプAの場合の処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Afileload()
        'Private Sub Afileload(ByRef sMyPrintname() As String, ByRef sMyPrintdate(,) As String, ByRef sMyPrintgoukei(,) As String)
        Const Myname As String = "Afileload"
        Try
            '初期設定
            Dim sLine(1) As String
            Dim sItems() As String
            Dim sItems2() As String
            Dim iStaffCodeComparison(1) As Integer
            Dim iGyousuu(1) As Integer
            Dim sStaffname As String
            Dim dSyukkin(1) As Date
            Dim dTaikin As Date
            Dim iRoudou As Integer




            Dim dAttendanceTime As Date
            Dim RestFlg As Boolean
            Dim iZitsuroudou As Integer
            Dim sZitsuroudou As String
            Dim iZangyouZikan As Integer
            Dim sZangyouZikan As String
            Dim iSinyaZikan As Integer
            Dim sSinyaZikan As String
            Dim iKyuukeiZikan As Integer

            Dim iJgoukei As Integer
            Dim sJgoukei As String
            Dim iZgoukei As Integer
            Dim sZgoukei As String
            Dim iSgoukei As Integer
            Dim sSgoukei As String

            Dim sHrecord As String
            Dim sDrecord As String
            Dim sTrecord As String
            Dim sAllTxt As String

            Dim iMyNameTimes As Integer = 0
            Dim iMyDateTimes As Integer = 0
            Dim iMyGoukeiTimes As Integer = 0
            sPrintName = New String() {}
            sPrintDate = New String(5, 0) {}
            sPrintGoukei = New String(2, 0) {}
            iStaffcode = New Integer() {}
            iErr = 0
            Dim iStartFlg As Integer = 1

            Dim Reader As New IO.StreamReader(NyuuFileTxt.Text, System.Text.Encoding.Default)
            sErrgyou = ""
            iGyousuu(0) = 1
            iGyousuu(1) = 2

            iStaffCodeComparison(0) = 9999999
            sStaffname = ""
            sHrecord = ""
            sDrecord = ""
            sTrecord = ""
            sAllTxt = ""
            iJgoukei = 0
            iZgoukei = 0
            iSgoukei = 0
            sJgoukei = ""
            sZgoukei = ""
            sSgoukei = ""
            sZitsuroudou = ""
            sZangyouZikan = ""
            sSinyaZikan = ""

            sLine(0) = Reader.ReadLine
            'ファイルの中身がNothingになるまでループ
            Do While sLine(0) IsNot Nothing

                If iStartFlg <> 1 Then
                    sLine(0) = Reader.ReadLine
                    iGyousuu(0) += 1
                    iGyousuu(1) += 1
                End If
                If sLine(0) Is Nothing Then
                    sErrgyou = sErrgyou & iGyousuu(0) & ","
                    MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                    LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                    sErrgyou = ""
                    iErr = 1
                    Reader.Close()
                    Exit Sub
                End If
                sItems = sLine(0).Split(",")
                If sItems.Length = 6 Then

                    '退勤からデータが始まっていたら次の行を読み込む
                    While sItems(3) <> 1
                        If iStartFlg = 1 Then
                            sErrgyou = sErrgyou & iGyousuu(0) & ","
                        End If
                        If Reader.Peek <= 0 Then
                            MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            iErr = 1
                            Reader.Close()
                            Exit Sub
                        End If
                        sLine(0) = Reader.ReadLine
                        sItems = sLine(0).Split(",")
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                        If iStartFlg <> 1 Then
                            sErrgyou = sErrgyou & iGyousuu(0) & ","
                        End If
                    End While

                    sLine(1) = Reader.ReadLine

                    If iStartFlg <> 1 Then
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                    End If

                    If sLine(1) Is Nothing Then
                        sErrgyou = sErrgyou & iGyousuu(1) & ","
                        MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                        LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                        sErrgyou = ""
                        iErr = 1
                        Reader.Close()
                        Exit Sub
                    End If
                    sItems2 = sLine(1).Split(",")

                    '出勤のデータならば次の行を読み込む
                    While sItems2(3) <> 2
                        sErrgyou = sErrgyou & iGyousuu(1) & ","
                        If Reader.Peek <= 0 Then
                            MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            iErr = 1
                            Reader.Close()
                            Exit Sub
                        End If
                        sLine(1) = Reader.ReadLine
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                        sItems2 = sLine(1).Split(",")
                    End While

                    'もしスタッフコードが違うのならTレコードを入れる
                    If iStartFlg <> 1 Then
                        iStaffCodeComparison(1) = Integer.Parse(sItems(0))
                        If iStaffCodeComparison(0) <> iStaffCodeComparison(1) Then

                            iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                            iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                            iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                            getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                            sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei & vbCrLf & vbCrLf)
                            sAllTxt = sAllTxt & sTrecord

                            ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                            sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                            sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                            sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei
                            iMyGoukeiTimes += 1
                            iMyDateTimes += 1

                            iJgoukei = 0
                            iZgoukei = 0
                            iSgoukei = 0
                        End If
                    End If

                    '今までのスタッフコードと新行列スタッフコードが違うなら実行

                    If CInt(sItems(0)) <> iStaffCodeComparison(0) Then

                        iStaffCodeComparison(0) = Integer.Parse(sItems(0))
                        sStaffname = sItems(1)


                        ReDim Preserve sPrintName(iMyNameTimes)
                        ReDim Preserve iStaffcode(iMyNameTimes)
                        sPrintName(iMyNameTimes) = sItems(1)
                        iStaffcode(iMyNameTimes) = Integer.Parse(sItems(0))
                        iMyNameTimes += 1
                        

                        sHrecord = ("H," & iStaffCodeComparison(0) & "," & sStaffname & vbCrLf)
                        sAllTxt = sAllTxt & sHrecord
                    End If

                    iKyuukeiZikan = 0
                    iZangyouZikan = 0
                    iZitsuroudou = 0
                    iSinyaZikan = 0

                    '出勤と退勤がきちんと入っていれば実行
                    If sItems(3) = 1 And sItems2(3) = 2 Then
                        dSyukkin(0) = CDate((sItems(4) & " " & sItems(5)))
                        dSyukkin(1) = CDate(sItems(4))
                        dTaikin = CDate((sItems2(4) & " " & sItems2(5)))
                        iRoudou = DateDiff("n", dSyukkin(0), dTaikin)

                        'ini取込
                        Dim sIniRoot As String = ".\INI\Staff.ini"
                        dAttendanceTime = CDate(GetINIValue("StaffCode_" & Integer.Parse(sItems(0)), "Setting", sIniRoot))

                        '休憩時間が出勤時間と退勤時間の中に入っていて、フラグありなら実行
                        RestFlg = CBool(GetINIValue("StaffRest_" & Integer.Parse(sItems(0)), "Setting", sIniRoot))
                        If RestFlg Then
                            iKyuukeiZikan = getKyuukeiZikan(dSyukkin(0), dTaikin, dSyukkin(1))
                        End If
                        iZitsuroudou = iRoudou - iKyuukeiZikan

                        '労働時間が２２時～５時の間なら実行
                        iSinyaZikan = getSinyaZikan(dSyukkin(0), dTaikin, dSyukkin(1))


                        '設定時間より15分前に来ていたら実行
                        If dAttendanceTime.AddMinutes(-15) > CDate(sItems(5)) Then
                            iJgoukei = iJgoukei + iZitsuroudou
                        ElseIf dAttendanceTime > CDate(sItems(5)) Then
                            Dim i As Integer
                            i = DateDiff("n", CDate(sItems(5)), dAttendanceTime)
                            iJgoukei = iJgoukei + iZitsuroudou - i
                            iZitsuroudou += -i
                        Else
                            iJgoukei = iJgoukei + iZitsuroudou
                        End If

                        '実労働時間が８時間を超えていたら実行
                        If 60 * 8 <= iZitsuroudou Then
                            iZangyouZikan = iZitsuroudou - (60 * 8)
                        End If

                        iZgoukei = iZgoukei + iZangyouZikan
                        iSgoukei = iSgoukei + iSinyaZikan

                        getZikanHyouki(iZitsuroudou, iZangyouZikan, iSinyaZikan, sZitsuroudou, sZangyouZikan, sSinyaZikan)
                        sDrecord = ("D," & sItems(4) & "," & sItems(5) & "," & sItems2(5) & "," & sZitsuroudou & "," & sZangyouZikan & "," & sSinyaZikan & vbCrLf)
                        sAllTxt = sAllTxt & sDrecord

                        Dim dPrintDate As Date = CDate(sItems(4))


                        ReDim Preserve sPrintDate(5, iMyDateTimes)
                        sPrintDate(0, iMyDateTimes) = Format(dPrintDate, "yyyy/MM/dd (ddd)")
                        sPrintDate(1, iMyDateTimes) = sItems(5)
                        sPrintDate(2, iMyDateTimes) = sItems2(5)
                        sPrintDate(3, iMyDateTimes) = sZitsuroudou
                        sPrintDate(4, iMyDateTimes) = sZangyouZikan
                        sPrintDate(5, iMyDateTimes) = sSinyaZikan
                        iMyDateTimes += 1

                        '今回が最後の行ならばTレコードを入れる
                        If Reader.Peek <= 0 Then
                            getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                            iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                            iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                            iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                            sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei)
                            sAllTxt = sAllTxt & sTrecord

                            ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                            sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                            sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                            sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei

                            If SyutsuhouhouBox.Text = "テキストファイル" Then
                                My.Computer.FileSystem.WriteAllText(SyutsuFileTxt.Text, sAllTxt, False, System.Text.Encoding.Default)
                                MsgBox("出力しました")
                                LogWrite_pro(Myname & "出力しました")
                            End If
                            Reader.Close()
                            If sErrgyou <> "" Then
                                MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                                LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                                sErrgyou = ""
                                iErr = 1
                            Else
                                iErr = 0
                            End If
                            Exit Do
                        End If

                    ElseIf Reader.Peek <= 0 Then
                        sErrgyou = ""
                        MsgBox("例外エラー")
                        LogWrite_pro(Myname & "例外エラー")
                        iErr = 1
                        Exit Do
                    End If
                Else
                    MsgBox("ファイルタイプが間違っています")
                    LogWrite_pro(Myname & "ファイルタイプが間違っています")
                    iErr = 1
                    Exit Do
                End If
                iStartFlg = 0
            Loop
            Reader.Close()
        Catch ex As Exception
            MsgBox("エラーが発生しました。" & sErrgyou & "行目を直してください" & vbLf & "ログを確認してください")
            iErr = 1
            LogWrite_pro(Myname & ex.ToString)
        End Try

    End Sub

    ''' <summary>
    '''ファイルタイプBの場合の処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub Bfileload()
        Const Myname As String = "Bfileload"
        Try
            '初期設定
            Dim sLine As String
            Dim sItems() As String
            Dim staffcode As Integer
            Dim staffcode2 As Integer
            Dim syukkin As Date
            Dim syukkin2 As Date
            Dim dTaikin As Date
            Dim iRoudou As Integer

            Dim dAttendanceTime As Date
            Dim iGyousuu As Integer
            Dim sErrgyou As String
            Dim iZitsuroudou As Integer
            Dim sZitsuroudou As String
            Dim iZangyouZikan As Integer
            Dim sZangyouZikan As String
            Dim iSinyaZikan As Integer
            Dim sSinyaZikan As String
            Dim iKyuukeiZikan As Integer

            Dim iJgoukei As Integer
            Dim sJgoukei As String
            Dim iZgoukei As Integer
            Dim sZgoukei As String
            Dim iSgoukei As Integer
            Dim sSgoukei As String

            Dim sHrecord As String
            Dim sDrecord As String
            Dim sTrecord As String
            Dim sAllTxt As String

            Dim iMyNameTimes As Integer = 0
            Dim iMyDateTimes As Integer = 0
            Dim iMyGoukeiTimes As Integer = 0
            sPrintName = New String() {}
            sPrintDate = New String(5, 0) {}
            sPrintGoukei = New String(2, 0) {}
            iStaffcode = New Integer() {}
            iErr = 0

            Dim Reader As New IO.StreamReader(NyuuFileTxt.Text, System.Text.Encoding.Default)
            '最初の行はいらないため2回読込
            sLine = Reader.ReadLine
            sErrgyou = ""
            iGyousuu = 2

            sLine = Reader.ReadLine
            If sLine Is Nothing Then
                sErrgyou = sErrgyou & iGyousuu & ","
                MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                sErrgyou = ""
                iErr = 1
                Reader.Close()
                Exit Sub
            End If
            sItems = sLine.Split(",")
            If sItems.Length = 4 Then
                staffcode = Integer.Parse(sItems(0))
                sHrecord = ""
                sDrecord = ""
                sTrecord = ""
                sAllTxt = ""
                iJgoukei = 0
                iZgoukei = 0
                iSgoukei = 0
                sJgoukei = ""
                sZgoukei = ""
                sSgoukei = ""
                sZitsuroudou = ""
                sZangyouZikan = ""
                sSinyaZikan = ""

                'ファイルの中身がNothingになるまでループ
                Do While sLine IsNot Nothing

                    iKyuukeiZikan = 0
                    iZangyouZikan = 0
                    iZitsuroudou = 0
                    iSinyaZikan = 0

                    syukkin = CDate(sItems(1) & " " & sItems(2))
                    syukkin2 = CDate(sItems(1))
                    dTaikin = CDate(sItems(1) & " " & sItems(3))
                    iRoudou = DateDiff("n", syukkin, dTaikin)

                    '休憩時間が出勤時間と退勤時間の中に入っていれば実行
                    iKyuukeiZikan = getKyuukeiZikan(syukkin, dTaikin, syukkin2)
                    iZitsuroudou = iRoudou - iKyuukeiZikan



                    '労働時間が２２時～５時の間なら実行
                    iSinyaZikan = getSinyaZikan(syukkin, dTaikin, syukkin2)

                    Dim sIniRoot As String = ".\INI\Staff.ini"
                    dAttendanceTime = CDate(GetINIValue("StaffCode_" & Integer.Parse(sItems(0)), "Setting", sIniRoot))

                    '設定時間より15分前に来ていたら実行
                    If dAttendanceTime.AddMinutes(-15) > CDate(sItems(2)) Then
                        iJgoukei = iJgoukei + iZitsuroudou
                    ElseIf dAttendanceTime > CDate(sItems(2)) Then
                        Dim i As Integer
                        i = DateDiff("n", CDate(sItems(2)), dAttendanceTime)
                        iJgoukei = iJgoukei + iZitsuroudou - i
                        iZitsuroudou += -i
                    Else
                        iJgoukei = iJgoukei + iZitsuroudou
                    End If
                    '実労働時間が８時間を超えていたら実行
                    If 60 * 8 <= iZitsuroudou Then
                        iZangyouZikan = iZitsuroudou - (60 * 8)
                    End If

                    iZgoukei = iZgoukei + iZangyouZikan
                    iSgoukei = iSgoukei + iSinyaZikan

                    getZikanHyouki(iZitsuroudou, iZangyouZikan, iSinyaZikan, sZitsuroudou, sZangyouZikan, sSinyaZikan)

                    sDrecord = ("D," & sItems(1) & "," & sItems(2) & "," & sItems(3) & "," & sZitsuroudou & "," & sZangyouZikan & "," & sSinyaZikan & vbCrLf)
                    sAllTxt = sAllTxt & sDrecord

                    Dim dPrintDate As Date = sItems(1).Substring(2)

                    ReDim Preserve sPrintDate(5, iMyDateTimes)
                    sPrintDate(0, iMyDateTimes) = Format(dPrintDate, "yyyy/MM/dd (ddd)")
                    sPrintDate(1, iMyDateTimes) = sItems(2)
                    sPrintDate(2, iMyDateTimes) = sItems(3)
                    sPrintDate(3, iMyDateTimes) = sZitsuroudou
                    sPrintDate(4, iMyDateTimes) = sZangyouZikan
                    sPrintDate(5, iMyDateTimes) = sSinyaZikan
                    iMyDateTimes += 1

                    '今回が最後の行ならばTレコードを読み込む

                    If Reader.Peek <= 0 Then
                        getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                        iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                        iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                        iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                        sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei & vbCrLf & vbCrLf)
                        sAllTxt = sAllTxt & sTrecord

                        ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                        sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                        sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                        sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei
                        iMyGoukeiTimes += 1

                        ReDim Preserve sPrintName(iMyNameTimes)
                        ReDim Preserve iStaffcode(iMyNameTimes)
                        sPrintName(iMyNameTimes) = ""
                        iStaffcode(iMyNameTimes) = staffcode

                        If SyutsuhouhouBox.Text = "テキストファイル" Then
                            My.Computer.FileSystem.WriteAllText(SyutsuFileTxt.Text, sAllTxt, False, System.Text.Encoding.Default)
                            MsgBox("出力しました")
                            LogWrite_pro(Myname & "出力しました")
                        End If
                        Reader.Close()
                        If sErrgyou <> "" Then
                            MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                            sErrgyou = ""
                            iErr = 1
                        End If
                    Else
                        iErr = 0
                        Exit Do
                    End If

                    sLine = Reader.ReadLine
                    iGyousuu += 1
                    If sLine Is Nothing Then
                        sErrgyou = sErrgyou & iGyousuu & ","
                        MsgBox("ファイルにエラーがあります、" & sErrgyou & "行目を直してください")
                        LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                        sErrgyou = ""
                        iErr = 1
                        Reader.Close()
                        Exit Sub
                    End If
                    sItems = sLine.Split(",")
                    staffcode2 = Integer.Parse(sItems(0))

                    'もしスタッフコードが違うのならTレコードを入れる
                    If staffcode <> staffcode2 Then

                        getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                        iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                        iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                        iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                        sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei & vbCrLf & vbCrLf)
                        sAllTxt = sAllTxt & sTrecord

                        ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                        sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                        sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                        sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei
                        iMyGoukeiTimes += 1
                        iMyDateTimes += 1

                        ReDim Preserve sPrintName(iMyNameTimes)
                        ReDim Preserve iStaffcode(iMyNameTimes)
                        sPrintName(iMyNameTimes) = ""
                        iStaffcode(iMyNameTimes) = staffcode
                        iMyNameTimes += 1

                        iJgoukei = 0
                        iZgoukei = 0
                        iSgoukei = 0

                        staffcode = Integer.Parse(sItems(0))

                    End If

                Loop
                Reader.Close()
            Else
                MsgBox("ファイルタイプが間違っています")
                LogWrite_pro(Myname & "ファイルタイプが間違っています")
                iErr = 1
                Reader.Close()
            End If
        Catch ex As Exception
            MsgBox("エラーが発生しました。" & sErrgyou & "行目を直してください" & vbLf & "ログを確認してください")
            iErr = 1
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' ファイルタイプCの場合の処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cfileload()
        Const Myname As String = "Cfileload"
        '初期設定
        Try
            Dim sLine(1) As String
            Dim sItems() As String
            Dim sItems2() As String
            Dim iStaffCodeComparison(1) As Integer
            Dim dSyukkin(1) As Date
            Dim dTaikin As Date
            Dim iRoudou As Integer

            Dim dAttendanceTime As Date
            Dim iGyousuu(1) As Integer
            Dim sErrgyou As String
            Dim iZitsuroudou As Integer
            Dim sZitsuroudou As String
            Dim iZangyouZikan As Integer
            Dim sZangyouZikan As String
            Dim iSinyaZikan As Integer
            Dim sSinyaZikan As String
            Dim iKyuukeiZikan As Integer

            Dim iJgoukei As Integer
            Dim sJgoukei As String
            Dim iZgoukei As Integer
            Dim sZgoukei As String
            Dim iSgoukei As Integer
            Dim sSgoukei As String

            Dim sHrecord As String
            Dim sDrecord As String
            Dim sTrecord As String
            Dim sAllTxt As String
            Dim iStartFlg As Integer = 1

            Dim iMyNameTimes As Integer = 0
            Dim iMyDateTimes As Integer = 0
            Dim iMyGoukeiTimes As Integer = 0
            sPrintName = New String() {}
            sPrintDate = New String(5, 0) {}
            sPrintGoukei = New String(2, 0) {}
            iStaffcode = New Integer() {}
            iErr = 0

            Dim Reader As New IO.StreamReader(NyuuFileTxt.Text, System.Text.Encoding.Default)
            '最初の行はいらないため2回読込
            sErrgyou = ""
            iGyousuu(0) = 1
            iGyousuu(1) = 2
            sLine(0) = Reader.ReadLine
            If sLine(0) Is Nothing Then
                sErrgyou = sErrgyou & iGyousuu(0) & ","
                MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                sErrgyou = ""
                iErr = 1
                Reader.Close()
                Exit Sub
            End If

            sHrecord = ""
            sDrecord = ""
            sTrecord = ""
            sAllTxt = ""
            iJgoukei = 0
            iZgoukei = 0
            iSgoukei = 0
            sJgoukei = ""
            sZgoukei = ""
            sSgoukei = ""
            sZitsuroudou = ""
            sZangyouZikan = ""
            sSinyaZikan = ""

            'ファイルの中身がNothingになるまでループ
            Do While sLine(0) IsNot Nothing
                sLine(0) = Reader.ReadLine
                iGyousuu(0) += 1
                iGyousuu(1) += 1
                If sLine(0) Is Nothing Then
                    sErrgyou = sErrgyou & iGyousuu(0) & ","
                    MsgBox("ファイルにエラーがあります、" & sErrgyou & "行目を直してください")
                    LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                    sErrgyou = ""
                    iErr = 1
                    Exit Do
                End If
                sItems = sLine(0).Split(",")
                If sItems.Length = 8 Then

                    '退勤からデータが始まっていたら次の行を読み込む
                    While sItems(6) <> 0
                        If iStartFlg = 1 Then
                            sErrgyou = sErrgyou & iGyousuu(0) & ","
                        End If
                        If Reader.Peek <= 0 Then
                            Exit Sub
                        End If
                        sLine(0) = Reader.ReadLine
                        sItems = sLine(0).Split(",")
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                        If iStartFlg <> 1 Then
                            sErrgyou = sErrgyou & iGyousuu(0) & ","
                        End If
                    End While

                    sLine(1) = Reader.ReadLine
                    If iStartFlg <> 1 Then
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                    End If

                    If sLine(1) Is Nothing Then
                        sErrgyou = sErrgyou & iGyousuu(1) & ","
                        MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                        LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                        sErrgyou = ""
                        iErr = 1
                        Exit Do
                    End If
                    sItems2 = sLine(1).Split(",")

                    '出勤のデータならば次の行を読み込む
                    While sItems2(6) <> 1
                        sErrgyou = sErrgyou & iGyousuu(1) & ","
                        If Reader.Peek <= 0 Then
                            Exit Sub
                        End If
                        sLine(1) = Reader.ReadLine
                        sItems2 = sLine(1).Split(",")
                        iGyousuu(0) += 1
                        iGyousuu(1) += 1
                    End While

                    If iStartFlg = 1 Then
                        iStaffCodeComparison(0) = Integer.Parse(sItems(5))
                    End If

                    iStaffCodeComparison(1) = Integer.Parse(sItems(5))

                    'もしスタッフコードが違うのならTレコードを入れる
                    If iStaffCodeComparison(0) <> iStaffCodeComparison(1) Then
                        iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                        iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                        iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                        getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                        sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei & vbCrLf & vbCrLf)
                        sAllTxt = sAllTxt & sTrecord

                        ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                        sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                        sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                        sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei
                        iMyGoukeiTimes += 1
                        iMyDateTimes += 1

                        ReDim Preserve sPrintName(iMyNameTimes)
                        ReDim Preserve iStaffcode(iMyNameTimes)
                        sPrintName(iMyNameTimes) = ""
                        iStaffcode(iMyNameTimes) = iStaffCodeComparison(0)
                        iMyNameTimes += 1

                        iJgoukei = 0
                        iZgoukei = 0
                        iSgoukei = 0
                        iStaffCodeComparison(0) = Integer.Parse(sItems(5))
                    End If

                    iKyuukeiZikan = 0
                    iZangyouZikan = 0
                    iZitsuroudou = 0
                    iSinyaZikan = 0

                    '出勤と退勤がきちんと入っていれば実行
                    If sItems(6) = 0 And sItems2(6) = 1 Then
                        dSyukkin(0) = CDate(sItems(0) & "/" & sItems(1) & "/" & sItems(2) & " " & sItems(3) & ":" & sItems(4))
                        dSyukkin(1) = CDate(sItems(0) & "/" & sItems(1) & "/" & sItems(2))
                        dTaikin = CDate(sItems2(0) & "/" & sItems2(1) & "/" & sItems2(2) & " " & sItems2(3) & ":" & sItems2(4))
                        iRoudou = DateDiff("n", dSyukkin(0), dTaikin)

                        '休憩時間が出勤時間と退勤時間の中に入っていれば実行
                        iKyuukeiZikan = getKyuukeiZikan(dSyukkin(0), dTaikin, dSyukkin(1))
                        iZitsuroudou = iRoudou - iKyuukeiZikan



                        '労働時間が２２時～５時の間なら実行
                        iSinyaZikan = getSinyaZikan(dSyukkin(0), dTaikin, dSyukkin(1))
                        Dim sIniRoot As String = ".\INI\Staff.ini"
                        dAttendanceTime = GetINIValue("StaffCode_" & Integer.Parse(sItems(5)), "Setting", sIniRoot)

                        '設定時間より15分前に来ていたら実行
                        If dAttendanceTime.AddMinutes(-15) > CDate(sItems(3) & ":" & sItems(4)) Then
                            iJgoukei = iJgoukei + iZitsuroudou
                        ElseIf dAttendanceTime > CDate(sItems(3) & ":" & sItems(4)) Then
                            Dim i As Integer
                            i = DateDiff("n", CDate(sItems(3) & ":" & sItems(4)), dAttendanceTime)
                            iJgoukei = iJgoukei + iZitsuroudou - i
                            iZitsuroudou += -i
                        Else
                            iJgoukei = iJgoukei + iZitsuroudou
                        End If

                        '実労働時間が８時間を超えていたら実行
                        If 60 * 8 <= iZitsuroudou Then
                            iZangyouZikan = iZitsuroudou - 60 * 8
                        End If

                        iZgoukei = iZgoukei + iZangyouZikan
                        iSgoukei = iSgoukei + iSinyaZikan

                        getZikanHyouki(iZitsuroudou, iZangyouZikan, iSinyaZikan, sZitsuroudou, sZangyouZikan, sSinyaZikan)

                        sDrecord = ("D," & sItems(0) & "/" & sItems(1) & "/" & sItems(2) & "," & sItems(3) & ":" & sItems(4) & "," & sItems2(3) & ":" & sItems2(4) & "," & sZitsuroudou & "," & sZangyouZikan & "," & sSinyaZikan & vbCrLf)
                        sAllTxt = sAllTxt & sDrecord

                        Dim dPrintDate As Date = sItems(0) & "/" & sItems(1) & "/" & sItems(2)

                        ReDim Preserve sPrintDate(5, iMyDateTimes)
                        sPrintDate(0, iMyDateTimes) = Format(dPrintDate, "yyyy/MM/dd (ddd)")
                        sPrintDate(1, iMyDateTimes) = sItems(3) & ":" & sItems(4)
                        sPrintDate(2, iMyDateTimes) = sItems2(3) & ":" & sItems2(4)
                        sPrintDate(3, iMyDateTimes) = sZitsuroudou
                        sPrintDate(4, iMyDateTimes) = sZangyouZikan
                        sPrintDate(5, iMyDateTimes) = sSinyaZikan
                        iMyDateTimes += 1

                        '今回が最後の行ならばTレコードを読み込む

                        If Reader.Peek <= 0 Then
                            iJgoukei = ((iJgoukei \ 60) * 60) + (((iJgoukei Mod 60) \ 15) * 15)
                            iZgoukei = ((iZgoukei \ 60) * 60) + (((iZgoukei Mod 60) \ 15) * 15)
                            iSgoukei = ((iSgoukei \ 60) * 60) + (((iSgoukei Mod 60) \ 15) * 15)
                            getZikanHyouki(iJgoukei, iZgoukei, iSgoukei, sJgoukei, sZgoukei, sSgoukei)
                            sTrecord = ("T," & sJgoukei & "," & sZgoukei & "," & sSgoukei & vbCrLf & vbCrLf)
                            sAllTxt = sAllTxt & sTrecord

                            ReDim Preserve sPrintGoukei(2, iMyGoukeiTimes)
                            sPrintGoukei(0, iMyGoukeiTimes) = sJgoukei
                            sPrintGoukei(1, iMyGoukeiTimes) = sZgoukei
                            sPrintGoukei(2, iMyGoukeiTimes) = sSgoukei

                            ReDim Preserve sPrintName(iMyNameTimes)
                            ReDim Preserve iStaffcode(iMyNameTimes)
                            sPrintName(iMyNameTimes) = ""
                            iStaffcode(iMyNameTimes) = iStaffCodeComparison(0)

                            If SyutsuhouhouBox.Text = "テキストファイル" Then
                                My.Computer.FileSystem.WriteAllText(SyutsuFileTxt.Text, sAllTxt, False, System.Text.Encoding.Default)
                                MsgBox("出力しました")
                                LogWrite_pro(Myname & "出力しました")
                            End If
                            Reader.Close()
                            If sErrgyou <> "" Then
                                MsgBox("ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                                LogWrite_pro(Myname & "ファイルにエラーがあります" & sErrgyou & "行目を直してください")
                                sErrgyou = ""
                                iErr = 1
                            End If
                        Else
                            iErr = 0
                            Exit Do
                        End If

                    Else
                        If Reader.Peek <= 0 Then
                            sErrgyou = ""
                            MsgBox("例外エラー")
                            LogWrite_pro(Myname & "例外エラー")
                            Exit Do
                        End If
                    End If
                Else
                    MsgBox("ファイルタイプが間違っています")
                    LogWrite_pro(Myname & "ファイルタイプが間違っています")
                    Exit Do
                End If
                iStartFlg = 0
            Loop
            Reader.Close()

        Catch ex As Exception
            MsgBox("エラーが発生しました。" & sErrgyou & "行目を直してください" & vbLf & "ログを確認してください")
            iErr = 1
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 深夜時間の処理
    ''' </summary>
    ''' <param name="dSyukkin">date 出勤時間(YY/MM/DD HH:MM)</param>
    ''' <param name="dTaikin">date 退勤時間(YY/MM/DD HH:MM)</param>
    ''' <param name="dSyukkinbi">date 出勤日(YY/MM/DD)</param>
    ''' <returns>合計（分表記）</returns>
    ''' <remarks></remarks>
    Function getSinyaZikan(ByVal dSyukkin As Date, ByVal dTaikin As Date, ByVal dSyukkinbi As Date) As Integer
        Const Myname As String = "getSinyaZikan"
        Try
            Dim dSinyaHanni As Date = CDate(dSyukkinbi & " " & "22:00")
            Dim dSinyaHanni2 As Date = CDate(dSyukkinbi & " " & "05:00")
            Dim dReizi As Date = CDate(dSyukkinbi & " " & "00:00")
            Dim iGoukei As Integer = 0

            '出勤時間が05:00前なら
            If dSyukkin < dSinyaHanni2 Then
                iGoukei = DateDiff("n", dSyukkin, dSinyaHanni2)

                '出勤時間が22:00後なら
            ElseIf dSyukkin > dSinyaHanni Then
                iGoukei -= DateDiff("n", dSinyaHanni, dSyukkin)
            End If

            '日付が変わっていた文だけループ
            Dim x As Integer = 1
            Dim iDay As Integer = DateDiff("d", dSyukkinbi, dTaikin)
            Do While x <= iDay
                iGoukei += DateDiff("n", dSinyaHanni, dReizi.AddDays(1))
                dReizi = dReizi.AddDays(1)
                dSinyaHanni = dSinyaHanni.AddDays(1)
                dSinyaHanni2 = dSinyaHanni2.AddDays(1)
                If dSinyaHanni2 <= dTaikin Then
                    iGoukei += DateDiff("n", dReizi, dSinyaHanni2)
                End If
                x += 1
            Loop

            '退勤時間が05:00前なら
            If dTaikin < dSinyaHanni2 Then
                iGoukei += DateDiff("n", dReizi, dTaikin)
                '退勤時間が22:00後なら
            ElseIf dTaikin > dSinyaHanni Then
                iGoukei += DateDiff("n", dSinyaHanni, dTaikin)
            End If
            Return iGoukei
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' 休憩時間の処理
    ''' </summary>
    ''' <param name="dSyukkin">date 出勤時間(YY/MM/DD HH:MM)</param>
    ''' <param name="dTaikin">date 退勤時間(YY/MM/DD HH:MM)</param>
    ''' <param name="dSyukkinbi">date 出勤日(YY/MM/DD)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getKyuukeiZikan(ByVal dSyukkin As Date, ByVal dTaikin As Date, ByVal dSyukkinbi As Date) As Integer
        Const Myname As String = "getKyuukeiZikan"
        Try
            Dim iGoukei As Integer = 0
            Dim dKyuukeiS As Date = CDate(dSyukkinbi & " " & CInt(KyuukeiS1.Text) & ":" & KyuukeiS2.Text)
            Dim dKyuukeiE As Date = CDate(dSyukkinbi & " " & KyuukeiE1.Text & ":" & KyuukeiE2.Text)


            '休憩時間が日をまたぐ場合
            If dKyuukeiE < dKyuukeiS Then
                dKyuukeiE = dKyuukeiE.AddDays(1)
            End If

            '休憩時間が出勤時間内にかぶっている場合
            If dKyuukeiE < dTaikin And dKyuukeiS > dSyukkin Then
                iGoukei += DateDiff("n", dKyuukeiS, dKyuukeiE)

                '出勤時間が休憩時間内なら
            ElseIf dKyuukeiS < dSyukkin And dKyuukeiE > dSyukkin Then
                '出勤時間も退勤時間も休憩時間内なら
                If dTaikin < dKyuukeiE Then
                    iGoukei += DateDiff("n", dSyukkin, dTaikin)
                    '退勤時間が休憩時間を超えていたら
                Else
                    iGoukei += DateDiff("n", dSyukkin, dKyuukeiE)
                End If
                '退勤時間が休憩時間内なら
            ElseIf dTaikin < dKyuukeiE And dTaikin > dKyuukeiS Then
                iGoukei += DateDiff("n", dKyuukeiS, dTaikin)
            End If

            Dim x As Integer = 1
            Dim iDay As Integer = DateDiff("d", dSyukkinbi, dTaikin)
            While x <= iDay
                '次の日の休憩開始時間を退勤時間が超えていたら
                If dKyuukeiS.AddDays(x) < dTaikin Then
                    '休憩時間内に退勤しているなら
                    If dTaikin < dKyuukeiE.AddDays(x) Then
                        iGoukei += DateDiff("n", dKyuukeiS.AddDays(x), dTaikin)
                        '退勤時間が休憩時間を超えているなら
                    Else
                        iGoukei += DateDiff("n", dKyuukeiS.AddDays(x), dKyuukeiE.AddDays(x))
                    End If
                End If
                x += 1
            End While

            Return iGoukei
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' 時間表記へ変換
    ''' </summary>
    ''' <param name="iZitsu">int 実労働(分)</param>
    ''' <param name="iZan">int 残業(分)</param>
    ''' <param name="iSin">int 深夜(分)</param>
    ''' <param name="sZitsu">str 実労働</param>
    ''' <param name="sZan">str 残業</param>
    ''' <param name="sSin">str 深夜</param>
    ''' <remarks></remarks>
    Private Sub getZikanHyouki(ByVal iZitsu As Integer, ByVal iZan As Integer, ByVal iSin As Integer, ByRef sZitsu As String, ByRef sZan As String, ByRef sSin As String)
        Const Myname As String = "getZikanHyouki"
        Try
            Dim sZikan As String
            Dim sFun As String
            '実労働時間をHH:MM表記へ
            sZikan = Format(iZitsu \ 60, "00")
            sFun = Format(iZitsu Mod 60, "00")
            sZitsu = (sZikan & ":" & sFun)
            '残業時間をHH:MM表記へ
            sZikan = Format(iZan \ 60, "00")
            sFun = Format(iZan Mod 60, "00")
            sZan = (sZikan & ":" & sFun)
            '深夜時間をHH:MM表記へ
            sZikan = Format(iSin \ 60, "00")
            sFun = Format(iSin Mod 60, "00")
            sSin = (sZikan & ":" & sFun)

            '実労働時間と残業時間と深夜時間が０分なら空白にする
            If sZitsu = "00:00" Then
                sZitsu = ""
            End If
            If sZan = "00:00" Then
                sZan = ""
            End If
            If sSin = "00:00" Then
                sSin = ""
            End If
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' LOGへの書き込み処理
    ''' </summary>
    ''' <param name="name">イベント名(const)</param>
    ''' <remarks></remarks>
    Private Sub LogWrite_pro(ByVal name As String)
        Const MyName As String = "LogWrite_pro"
        Try
            Dim sFileName As String = ".\LOG\" & DateTime.Today.ToString("dd") & ".log"
            'LOGフォルダがなければカレントディレクトリにLOGフォルダを作る
            If System.IO.Directory.Exists(".\LOG") = False Then
                System.IO.Directory.CreateDirectory(".\LOG")
            End If

            '日付が同じで1ヶ月前のファイルなら削除
            If System.IO.File.Exists(sFileName) And System.IO.File.GetCreationTime(sFileName) < DateTime.Today.AddDays(-1) Then
                System.IO.File.Delete(sFileName)
            End If

            LogWrite = New System.IO.StreamWriter(".\LOG\" & DateTime.Today.ToString("dd") & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
            LogWrite.Write(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff") & vbTab & vbTab & name & vbCrLf)
            LogWrite.Close()

        Catch ex As Exception
            MsgBox("実行時エラー" & MyName & vbCrLf & ex.ToString)
            LogWrite.Close()
        End Try
    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' 起動時設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Const Myname As String = "form1_Load"
        Try
            LogWrite_pro("Start" & vbTab & Myname)
            SyutsuhouhouBox.Items.Clear()
            SyutsuhouhouBox.Items.Add("テキストファイル")
            For Each myprint As String In Printing.PrinterSettings.InstalledPrinters
                SyutsuhouhouBox.Items.Add(myprint)
            Next
            SyutsuhouhouBox.SelectedIndex = 0     '初期選択を一行目に設定
            Me.Show()
            TypeARadio.Focus()
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' コンボボックス設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyutsuhouhouBox.SelectedIndexChanged
        Const Myname As String = "ComboBox1_SelectedIndexChanged"
        Try
            LogWrite_pro("Start" & vbTab & Myname & vbTab & SyutsuhouhouBox.Text)
            'コンボボックスがテキストファイル以外を選択した時テキストボックスと出力ボタンを使えなくする
            If SyutsuhouhouBox.Text <> "テキストファイル" Then

                SyutsuFileTxt.Enabled = False
                SyutsuFileButton.Enabled = False
                SyutsuFileTxt.Text = ""
                dtpStart.Enabled = True
                dtpEnd.Enabled = True

            End If
            If SyutsuhouhouBox.Text = "テキストファイル" Then

                SyutsuFileTxt.Enabled = True
                SyutsuFileButton.Enabled = True
                dtpStart.Enabled = False
                dtpEnd.Enabled = False

            End If
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try


    End Sub

    ''' <summary>
    ''' 実行ボタンを押したときの動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        Const Myname As String = "Start_click"
        Try
            LogWrite_pro("Start" & vbTab & Myname)
            iDateTimes = 0
            iNameTimes = 0
            iSumTimes = 0
            '入力ファイルに何かが入っていたら実行

            If NyuuFileTxt.Text <> "" Then

                If SyutsuFileTxt.Text <> "" Or SyutsuhouhouBox.Text <> "テキストファイル" Then

                    If KyuukeiS1.Text = "" Or KyuukeiS1.Text = "-" Then
                        MsgBox("休憩時間を設定してください")
                        KyuukeiS1.Focus()
                        Exit Sub
                    End If
                    If KyuukeiS2.Text = "" Or KyuukeiS2.Text = "-" Then
                        MsgBox("休憩時間を設定してください")
                        KyuukeiS2.Focus()
                        Exit Sub
                    End If
                    If KyuukeiE1.Text = "" Or KyuukeiE1.Text = "-" Then
                        MsgBox("休憩時間を設定してください")
                        KyuukeiE1.Focus()
                        Exit Sub
                    End If
                    If KyuukeiE2.Text = "" Or KyuukeiE2.Text = "-" Then
                        MsgBox("休憩時間を設定してください")
                        KyuukeiE1.Focus()
                        Exit Sub
                    End If


                    If CDate(dtpStart.Text) > CDate(dtpEnd.Text) Then
                        MsgBox("開始日と終了日が逆ではないですか？")
                        Exit Sub
                    End If


                    If DateDiff("d", CDate(dtpStart.Text), CDate(dtpEnd.Text)) > 31 Then
                        MsgBox("開始日から終了日を31日より大きくしないでください")
                        Exit Sub
                    End If


                    Select Case True

                        'ラジオボタンAが選択されていたら実行
                        Case TypeARadio.Checked
                            'Afileload(sPrintName, sPrintDate, sPrintGoukei)
                            Afileload()
                            If SyutsuhouhouBox.Text <> "テキストファイル" And iErr = 0 Then
                                PrintDocument1.PrinterSettings.PrinterName = SyutsuhouhouBox.Text
                                PrintPreviewDialog1.ShowDialog()
                            End If
                            'ラジオボタンBが選択されていたら実行
                        Case TypeBRadio.Checked
                            Bfileload()
                            If SyutsuhouhouBox.Text <> "テキストファイル" And iErr = 0 Then
                                PrintDocument1.PrinterSettings.PrinterName = SyutsuhouhouBox.Text
                                PrintPreviewDialog1.ShowDialog()
                            End If
                            'ラジオボタンCが選択されていたら実行
                        Case TypeCRadio.Checked
                            Cfileload()
                            If SyutsuhouhouBox.Text <> "テキストファイル" And iErr = 0 Then
                                PrintDocument1.PrinterSettings.PrinterName = SyutsuhouhouBox.Text
                                PrintPreviewDialog1.ShowDialog()
                            End If
                    End Select


                Else
                    MsgBox("出力ファイルを選択してください")
                    LogWrite_pro(Myname & "出力ファイルを選択してください")
                End If
            Else
                MsgBox("入力ファイルを選択してください")
                LogWrite_pro(Myname & "入力ファイルを選択してください")
            End If
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 終了ボタンを押したときの動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Const Myname As String = "Exit_Click"
        Try
            LogWrite_pro("Start" & vbTab & Myname & vbCrLf)

            'LogWrite = New System.IO.StreamWriter(".\LOG\" & DateTime.Today.ToString("dd") & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
            'LogWrite.Write(vbCrLf)
            'LogWrite.Close()

            End
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 入力ファイル側の[...]ボタンを押したときの動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NyuuFileButton.Click
        Const Myname As String = "NyuuFile_Click"
        Try
            Dim sNyuuMyFile As String
            sNyuuMyFile = ""
            OpenFileDialog1.Filter = "csvファイル(*.csv)|*.csv|All Files(*.*)|*.*"

            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sNyuuMyFile = OpenFileDialog1.FileName
            End If
            NyuuFileTxt.Text = sNyuuMyFile
            LogWrite_pro("Start" & vbTab & Myname & vbTab & sNyuuMyFile)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 出力ファイル側の[...]ボタンを押したときの動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyutsuFileButton.Click
        Const Myname As String = "SyutsuFile_Click"
        Try
            Dim sSyutsuMyFile As String
            sSyutsuMyFile = ""
            SaveFileDialog1.Filter = "txtファイル(*.txt)|*.txt|AllFile(*.*)|*.*"

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sSyutsuMyFile = SaveFileDialog1.FileName
            End If

            SyutsuFileTxt.Text = sSyutsuMyFile
            LogWrite_pro("Start" & vbTab & Myname & vbTab & sSyutsuMyFile)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオボタンをAに変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TypeARadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeARadio.CheckedChanged
        Const Myname As String = "CheckedARadio"
        Try
            LogWrite_pro("Start" & vbTab & Myname)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオボタンをBに変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TypeBRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeBRadio.CheckedChanged
        Const Myname As String = "CheckedBRadio"
        Try
            LogWrite_pro("Start" & vbTab & Myname)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオボタンをCに変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TypeCRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeCRadio.CheckedChanged
        Const Myname As String = "CheckedCRadio"
        Try
            LogWrite_pro("Start" & vbTab & Myname)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 休憩時間開始のHHを変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KyuukeiS1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KyuukeiS1.TextChanged
        Const Myname As String = "KyuukeiS1Change"
        Try
            Dim sTime As String = KyuukeiS1.Text
            If sTime = "" Or sTime = "-" Then
            ElseIf IsNumeric(sTime) Then
                If CInt(sTime) > 23 Then
                    MsgBox("23より大きくしないでください")
                    KyuukeiS1.Text = "12"
                End If

                If CInt(sTime) < 0 Then
                    MsgBox("0より小さくしないでください")
                    KyuukeiS1.Text = "12"
                End If

            Else
                MsgBox("数値以外を入力しないでください")
                KyuukeiS1.Text = "12"
            End If
            LogWrite_pro("Start" & vbTab & Myname & KyuukeiS1.Text)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 休憩時間開始のMMを変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KyuukeiS2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KyuukeiS2.TextChanged
        Const Myname As String = "KyuukeiS2Change"
        Try
            Dim sTime As String = KyuukeiS2.Text
            If sTime = "" Or sTime = "-" Then
            ElseIf IsNumeric(sTime) Then
                If CInt(sTime) > 59 Then
                    MsgBox("59より大きい数字に設定しないでください")
                    KyuukeiS2.Text = "00"
                End If

                If CInt(sTime) < 0 Then
                    MsgBox("0より小さくしないでください")
                    KyuukeiS2.Text = "00"
                End If
            Else
                MsgBox("数値以外を入力しないでください")
                KyuukeiS2.Text = "00"
            End If
            LogWrite_pro("Start" & vbTab & Myname & KyuukeiS2.Text)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 休憩時間終了のHHを変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KyuukeiE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KyuukeiE1.TextChanged
        Const Myname As String = "KyuukeiE1Change"
        Try
            Dim sTime As String = KyuukeiE1.Text
            If sTime = "" Or sTime = "-" Then
            ElseIf IsNumeric(sTime) Then
                If CInt(sTime) > 23 Then
                    MsgBox("23より大きい数字に設定しないでください")
                    KyuukeiE1.Text = "12"
                End If

                If CInt(sTime) < 0 Then
                    MsgBox("0より小さくしないでください")
                    KyuukeiE1.Text = "12"
                End If
            Else
                MsgBox("数値以外を入力しないでください")
                KyuukeiE1.Text = "12"
            End If
            LogWrite_pro("Start" & vbTab & Myname & KyuukeiE1.Text)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 休憩時間終了のMMを変更した時の動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KyuukeiE2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KyuukeiE2.TextChanged
        Const Myname As String = "KyuukeiE2Change"
        Try
            Dim sTime As String = KyuukeiE2.Text
            If sTime = "" Or sTime = "-" Then
            ElseIf IsNumeric(sTime) Then
                If CInt(sTime) > 59 Then
                    MsgBox("59より大きい数字に設定しないでください")
                    KyuukeiE2.Text = "00"
                End If

                If CInt(sTime) < 0 Then
                    MsgBox("0より小さくしないでください")
                    KyuukeiE2.Text = "00"
                End If
            Else
                MsgBox("数値以外を入力しないでください")
                KyuukeiE2.Text = "00"
            End If
            LogWrite_pro("Start" & vbTab & Myname & KyuukeiE2.Text)
        Catch ex As Exception
            MsgBox("実行時エラー" & Myname & vbCrLf & ex.ToString)
            LogWrite_pro(Myname & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 印刷の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Const MyName As String = "PrintDocument1_PrintPage"
        Try
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim iX As Integer = e.MarginBounds.X
            Dim iY As Integer = e.MarginBounds.Y
            Dim iDateSum As Integer = 0
            Dim iTimes As Integer = 0
            Dim fMyFont As New Font("MS 明朝", 9)
            Dim fGoukeiFont As New Font("MS 明朝", 11)
            Dim fMonthlyFont As New Font("MS 明朝", 16, FontStyle.Bold)
            Dim iFontHeight As Integer = CInt(fMyFont.GetHeight(e.Graphics))
            Dim brMyBrush As New SolidBrush(Color.Black)
            Dim doPrintWorkTime As Double = 0
            Dim doPrintOverTime As Double = 0
            Dim doPrintNightTime As Double = 0


            '判子用
            e.Graphics.DrawRectangle(Pens.Black, iX + 420, iY, 180, 80)
            e.Graphics.DrawLine(Pens.Black, iX + 480, iY, iX + 480, iY + 80)
            e.Graphics.DrawLine(Pens.Black, iX + 540, iY, iX + 540, iY + 80)
            e.Graphics.DrawLine(Pens.Black, iX + 420, iY + 20, iX + 600, iY + 20)

            'ID下と日付下の横線を描画
            e.Graphics.DrawLine(Pens.Black, iX, iY + 130, iX + 600, iY + 130)
            e.Graphics.DrawLine(Pens.Black, iX, iY + 160, iX + 600, iY + 160)


            Do While sPrintDate.Length / 6 >= iDateTimes + 1

                If sPrintDate(0, iDateTimes) = Nothing Then
                    e.HasMorePages = True
                    Exit Do
                End If

                Do While CDate(dtpStart.Text).AddDays(iTimes) <= CDate(dtpEnd.Text)

                    If Format(CDate(dtpStart.Text).AddDays(iTimes), "yyyy/MM/dd (ddd)") = sPrintDate(0, iDateTimes) Then

                        e.Graphics.DrawString(sPrintDate(0, iDateTimes), fMyFont, brMyBrush, iX + ((150 / 2) - (iFontHeight * 3)), ((20 - iFontHeight) / 2) + (iY + 159 + (20 * iTimes)))
                        Dim x As Integer = 1
                        Do While x <= 5
                            e.Graphics.DrawString(sPrintDate(x, iDateTimes), fMyFont, brMyBrush, iX + 60 + (x * 90) + ((90 / 2) - iFontHeight - 3), ((20 - iFontHeight) / 2) + (iY + 160 + (20 * iTimes)))
                            x += 1
                        Loop

                        '表記した時間の合計計算(分表記)
                        If sPrintDate(3, iDateTimes) <> "" Then
                            Dim ts As TimeSpan = TimeSpan.Parse(sPrintDate(3, iDateTimes))
                            doPrintWorkTime += ts.TotalMinutes
                        End If
                        If sPrintDate(4, iDateTimes) <> "" Then
                            Dim ts As TimeSpan = TimeSpan.Parse(sPrintDate(4, iDateTimes))
                            doPrintOverTime += ts.TotalMinutes
                        End If
                        If sPrintDate(5, iDateTimes) <> "" Then
                            Dim ts As TimeSpan = TimeSpan.Parse(sPrintDate(5, iDateTimes))
                            doPrintNightTime += ts.TotalMinutes
                        End If

                        iDateSum += 1
                        iTimes += 1
                        e.Graphics.DrawLine(Pens.Black, iX, iY + 160 + (20 * iTimes), iX + 600, iY + 160 + (20 * iTimes))
                        Exit Do
                    ElseIf CDate(sPrintDate(0, iDateTimes)) > CDate(dtpStart.Text).AddDays(iTimes) Then
                        e.Graphics.DrawString(Format(CDate(dtpStart.Text).AddDays(iTimes), "yyyy/MM/dd (ddd)"), fMyFont, brMyBrush, iX + ((150 / 2) - (iFontHeight * 3)), ((20 - iFontHeight) / 2) + (iY + 160 + (20 * iTimes)))

                        iTimes += 1
                        e.Graphics.DrawLine(Pens.Black, iX, iY + 160 + (20 * iTimes), iX + 600, iY + 160 + (20 * iTimes))
                    Else
                        Exit Do
                    End If
                Loop

                iDateTimes += 1

            Loop
            iDateTimes += 1
            Dim i As Integer = 0

            Do While CDate(dtpEnd.Text) > CDate(sPrintDate(0, iDateTimes - 2)).AddDays(i) And CDate(dtpStart.Text).AddDays(iTimes) <= CDate(dtpEnd.Text)
                e.Graphics.DrawString(Format(CDate(dtpStart.Text).AddDays(iTimes), "yyyy/MM/dd (ddd)"), fMyFont, brMyBrush, iX + ((150 / 2) - (iFontHeight * 3)), ((20 - iFontHeight) / 2) + (iY + 160 + (20 * iTimes)))
                iTimes += 1
                i += 1
                e.Graphics.DrawLine(Pens.Black, iX, iY + 160 + (20 * iTimes), iX + 600, iY + 160 + (20 * iTimes))
            Loop




            iTimes += 2
            e.Graphics.DrawString("ＩＤ：", fMyFont, brMyBrush, iX + 5, iY + 100 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString(iStaffcode(iSumTimes), fMyFont, brMyBrush, iX + 5 + (iFontHeight * 2), iY + 100 + (30 - iFontHeight) / 2)

            If sPrintName(iNameTimes) <> "" Then
                e.Graphics.DrawString("名前：", fMyFont, brMyBrush, iX + 245, iY + 100 + (30 - iFontHeight) / 2)
                e.Graphics.DrawString(sPrintName(iNameTimes), fMyFont, brMyBrush, iX + 245 + (iFontHeight * 3), iY + 100 + (30 - iFontHeight) / 2)
                iNameTimes += 1
            End If
            e.Graphics.DrawString("日付", fMyFont, brMyBrush, iX + ((150 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("出勤", fMyFont, brMyBrush, iX + 150 + ((90 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("退勤", fMyFont, brMyBrush, iX + 240 + ((90 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("実労", fMyFont, brMyBrush, iX + 330 + ((90 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("残業", fMyFont, brMyBrush, iX + 420 + ((90 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("深夜", fMyFont, brMyBrush, iX + 510 + ((90 / 2) - iFontHeight - 3), iY + 130 + (30 - iFontHeight) / 2)
            e.Graphics.DrawString("合計：　" & iDateSum & "日", fGoukeiFont, brMyBrush, iX + ((330 / 2) - (iFontHeight * 2)), iY + 130 + (iTimes * 20) + ((20 - iFontHeight) / 2))
            e.Graphics.DrawString(Format(CDate(dtpEnd.Text), "yyyy 年　MM 月度"), fMonthlyFont, brMyBrush, iX + 50, iY + 50)




            '合計時間描画
            doPrintWorkTime = ((doPrintWorkTime \ 60) * 60) + (((doPrintWorkTime Mod 60) \ 15) * 15)
            doPrintOverTime = ((doPrintOverTime \ 60) * 60) + (((doPrintOverTime Mod 60) \ 15) * 15)
            doPrintNightTime = ((doPrintNightTime \ 60) * 60) + (((doPrintNightTime Mod 60) \ 15) * 15)

            getZikanHyouki(CInt(doPrintWorkTime), CInt(doPrintOverTime), CInt(doPrintNightTime), sPrintGoukei(0, iSumTimes), sPrintGoukei(1, iSumTimes), sPrintGoukei(2, iSumTimes))

            e.Graphics.DrawString(sPrintGoukei(0, iSumTimes), fMyFont, brMyBrush, iX + 330 + ((90 / 2) - iFontHeight - 3), iY + 130 + (iTimes * 20) + ((20 - iFontHeight) / 2))
            e.Graphics.DrawString(sPrintGoukei(1, iSumTimes), fMyFont, brMyBrush, iX + 420 + ((90 / 2) - iFontHeight - 3), iY + 130 + (iTimes * 20) + ((20 - iFontHeight) / 2))
            e.Graphics.DrawString(sPrintGoukei(2, iSumTimes), fMyFont, brMyBrush, iX + 510 + ((90 / 2) - iFontHeight - 3), iY + 130 + (iTimes * 20) + ((20 - iFontHeight) / 2))
            iSumTimes += 1

            e.Graphics.DrawLine(Pens.Black, iX + 150, iY + 130, iX + 150, iY + 100 + (iTimes * 20) + 20)
            e.Graphics.DrawLine(Pens.Black, iX + 240, iY + 100, iX + 240, iY + 100 + (iTimes * 20) + 20)
            e.Graphics.DrawLine(Pens.Black, iX + 330, iY + 130, iX + 330, iY + 100 + (iTimes * 20) + 60)
            e.Graphics.DrawLine(Pens.Black, iX + 420, iY + 130, iX + 420, iY + 100 + (iTimes * 20) + 60)
            e.Graphics.DrawLine(Pens.Black, iX + 510, iY + 130, iX + 510, iY + 100 + (iTimes * 20) + 60)
            e.Graphics.DrawRectangle(Pens.Black, iX, iY + 100, 600, (20 * iTimes) + 60)

            '判子用
            'e.Graphics.DrawRectangle(Pens.Black, iX + 420, iY + ((iTimes + 2) * 30), 180, 60)
            'e.Graphics.DrawLine(Pens.Black, iX + 480, iY + ((iTimes + 2) * 30), iX + 480, iY + ((iTimes + 4) * 30))
            'e.Graphics.DrawLine(Pens.Black, iX + 540, iY + ((iTimes + 2) * 30), iX + 540, iY + ((iTimes + 4) * 30))
            If sPrintDate.Length / 6 <= iDateTimes + 1 Then
                iDateTimes = 0
                iNameTimes = 0
                iSumTimes = 0
            End If
        Catch ex As Exception
            MsgBox("実行時エラー" & MyName & vbCrLf & ex.ToString)
            LogWrite_pro(MyName & ex.ToString)
        End Try
    End Sub

#End Region

End Class

