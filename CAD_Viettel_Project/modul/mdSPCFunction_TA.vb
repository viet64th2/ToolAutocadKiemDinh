Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO


' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Imaging
Imports System.Windows

Public Module mdSPCFunction_TA

    Public Function XoayPoint3D(ToaDox As Double, ToaDoy As Double, ToaDoz As Double, Goc As Double) As Point3d
        Dim point3d As Point3d
        Dim Diem(1) As Double
        Diem(0) = ToaDox * Math.Cos(Goc) - ToaDoy * Math.Sin(Goc)
        Diem(1) = ToaDox * Math.Sin(Goc) + ToaDoy * Math.Cos(Goc)
        point3d = New Point3d(Diem(0), Diem(1), ToaDoz)
        Return point3d
    End Function
    Public Function Xoay(DiemXoay As Double(), Goc As Double) As Double()
        Dim Diem(1) As Double
        Diem(0) = DiemXoay(0) * Math.Cos(Goc) - DiemXoay(1) * Math.Sin(Goc)
        Diem(1) = DiemXoay(0) * Math.Sin(Goc) + DiemXoay(1) * Math.Cos(Goc)
        Return Diem
    End Function
    Public Function TinhGoc(canha As Double, canhb As Double, canhc As Double)
        Dim Goc As Double
        Goc = Math.Acos((canha * canha + canhb * canhb - canhc * canhc) / (2 * canha * canhb))
        Return Goc
    End Function

    Public Function getText(path As String)
        Dim list As ArrayList = New ArrayList
        If (System.IO.File.Exists(path)) Then
            Dim text As String = ReadText(path)
            Dim li() As String = text.Split("@")
            list.AddRange(li)
        End If
        Return list
    End Function
    Public Function LayThongTinChung(arl As ArrayList)
        Dim li As List(Of String) = New List(Of String)
        For i = 1 To arl.Count - 1
            Dim itemDam As String = arl.Item(i)
            Dim b As String() = itemDam.Split("_")
            li.Add(b(1))
        Next
        If li(2) = "Dây co" Then
            ThongTinChung.DiaDiem = li(0)
            ThongTinChung.MaTram = li(1)
            ThongTinChung.LoaiCot = li(2)
            ThongTinChung.ChieuCao = li(3)
            ThongTinChung.TietDienCot = li(4)
            ThongTinChung.ViTriDat = li(5)
            ThongTinChung.BeTongMong = li(6)
            ThongTinChung.SoMong = li(7)
            ThongTinChung.SoChanCot = li(8)
            ThongTinChung.ChieuCaoDot = li(9)
            ThongTinChung.SoTangDay = li(10)
            ThongTinChung.SoDot = li(11)
            ThongTinChung.GaChongXoay = li(12)
        Else
            ThongTinChung.DiaDiem = li(0)
            ThongTinChung.MaTram = li(1)
            ThongTinChung.LoaiCot = li(2)
            ThongTinChung.ChieuCao = li(3)
            ThongTinChung.KichThuocChanCot = li(5)
            ThongTinChung.ViTriDat = li(6)
            ThongTinChung.BeTongMong = li(7)
            ThongTinChung.SoDot = li(8)
            ThongTinChung.SoMong = "4"
            ThongTinChung.SoChanCot = "4"
        End If
        Return li
    End Function
    Public Function TinhKhoangCach(X1 As Double, Y1 As Double, X2 As Double, Y2 As Double) As Double
        Return Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1))
    End Function
    Public Sub InsertData(Table As DataGridView, arl As ArrayList)
        Table.Rows.Clear()
        For i = 1 To arl.Count - 1
            Dim itemDam As String = arl.Item(i)
            Dim b As String() = itemDam.Split("_")
            Table.Rows.Add(b)
        Next
    End Sub
    Public Function ReadText(path As String)
        Dim text As String = ""
        If System.IO.File.Exists(path) = True Then
            Dim f As System.IO.StreamReader
            f = My.Computer.FileSystem.OpenTextFileReader(path)
            text = f.ReadToEnd()
            f.Close()
        End If
        Return text
    End Function
    Public Sub WirteText(text As String, path As String)
        System.IO.File.WriteAllText(path, text)
        If System.IO.File.Exists(path) = True Then
            'MsgBox("Đã lưu dữ liệu!")
        End If
    End Sub
    Public Sub SaveFile(table As DataGridView, name As String)
        Dim textData As String = "@"
        For i = 0 To table.RowCount - 1
            'textData = textData + "@"
            For j = 0 To table.ColumnCount - 1
                Try
                    If (IsNothing(table.Rows(i).Cells(j).Value)) Then
                        table.Rows(i).Cells(j).Value = ""
                    End If
                    Dim data As String = table.Rows(i).Cells(j).Value.ToString
                    If j = table.ColumnCount - 1 Then
                        If i = table.RowCount - 1 Then
                            textData = textData + data
                        Else
                            textData = textData + data + "@"
                        End If
                    Else
                        textData = textData + data + "_"
                    End If
                Catch ex As System.Exception
                    If j = table.ColumnCount - 1 Then
                        textData = textData + ""
                    Else
                        textData = textData + "" + "_"
                    End If
                End Try
            Next
        Next

        WirteText(textData, DuongDanData + "\" + name + ".txt")
    End Sub
    Public Sub TaoMoiTram(path As String)
        Dim TenTram As String = ""
        WirteText(path, "C:\ProgramData\PathSupport.txt")
        Dim List() As String = path.Split("\")
        TenTram = List(List.Length - 1)
        'Hiển thị tên trạm
        Dim list2() As String = TenTram.Split("_")
        'frmMain.lbTenTram.Visible = True
        'frmMain.lbTenTram.Text = list2(0).ToString
        DuongDanData = path & "\Data" & TenTram
        If (Not System.IO.File.Exists(path & "\Data" & TenTram & "\TABLEBia.txt")) Then
            MsgBox("Không tìm thấy data thông tin bìa!")
            Exit Sub
        End If
        Dim listThongTinChung = getText(path & "\Data" & TenTram & "\TABLEBia.txt")
        Dim li As List(Of String) = LayThongTinChung(listThongTinChung)
        b_somong = Convert.ToInt32(ThongTinChung.SoMong)
        'lấy móng nối chung
        If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 Then
            If File.Exists(path & "\Data" & TenTram & "\MongNoiChung.txt") Then
                ThongTinChung.MongNoiChung = ReadText(path & "\Data" & TenTram & "\MongNoiChung.txt")
            End If
        End If
        If File.Exists(path & "\Data" & TenTram & "\NoiDayCo.txt") Then
            ThongTinChung.NoiDayCo = ReadText(path & "\Data" & TenTram & "\NoiDayCo.txt")

        End If
        ' DuongDanData + "\" + "NoiDayCo.txt"
        If ThongTinChung.LoaiCot = ("Dây co") Then
            insertDataCotDayCo()
        Else
            insertDataCotTuDung()
        End If

        If Not System.IO.Directory.Exists(path & "\Data" & TenTram) Then
            MsgBox("Thư mục dự án không hợp lệ!")
            Exit Sub
        End If
    End Sub

    Private Sub insertDataCotTuDung()
        listThongTinChung = getText(DuongDanData & "\TABLEBia.txt")
        InsertData(frmTTC_TuDung.BangTTC, listThongTinChung)
        Try
            textdauvao = ReadText(DuongDanData & "\TABLE2.txt")
            Dim daura As String()
            daura = mbVeMong.TachChuoi(textdauvao, 1, 1)
            daura = mbVeMong.TachChuoi(textdauvao, 4, 1)
            frmTTC_TuDung.txtbM1.Text = daura(1) * 1000
            frmTTC_TuDung.txthM1.Text = daura(0) * 1000
            frmTTC_TuDung.txtzM1.Text = daura(2) * 1000
            frmTTC_TuDung.txtbM2.Text = daura(1) * 1000
            frmTTC_TuDung.txthM2.Text = daura(0) * 1000
            frmTTC_TuDung.txtzM2.Text = daura(2) * 1000
            frmTTC_TuDung.txtbM3.Text = daura(1) * 1000
            frmTTC_TuDung.txthM3.Text = daura(0) * 1000
            frmTTC_TuDung.txtzM3.Text = daura(2) * 1000
            frmTTC_TuDung.txtbM4.Text = daura(1) * 1000
            frmTTC_TuDung.txthM4.Text = daura(0) * 1000
            frmTTC_TuDung.txtzM4.Text = daura(2) * 1000
        Catch ex As System.Exception
            frmTTC_TuDung.txtbM1.Text = 500
            frmTTC_TuDung.txthM1.Text = 500
            frmTTC_TuDung.txtzM1.Text = 500
            frmTTC_TuDung.txtbM2.Text = 500
            frmTTC_TuDung.txthM2.Text = 500
            frmTTC_TuDung.txtzM2.Text = 500
            frmTTC_TuDung.txtbM3.Text = 500
            frmTTC_TuDung.txthM3.Text = 500
            frmTTC_TuDung.txtzM3.Text = 500
            frmTTC_TuDung.txtbM4.Text = 500
            frmTTC_TuDung.txthM4.Text = 500
            frmTTC_TuDung.txtzM4.Text = 500
        End Try


        Dim listChieuCao As ArrayList = New ArrayList
        listChieuCao = getText(DuongDanData & "\TABLEMstower.txt")
        InsertData(frmTTC_TuDung.BangChieuCaoDot, listChieuCao)

        x1 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y1 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z1 = (0) * 1000

        x2 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y2 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z2 = (0) * 1000

        x3 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y3 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z3 = (0) * 1000

        x4 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y4 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z4 = (0) * 1000

        frmTTC_TuDung.dgvToaDoMong.Rows.Clear()
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M1", x1 / 1000, y1 / 1000, z1 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M2", x2 / 1000, y2 / 1000, z2 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M3", x3 / 1000, y3 / 1000, z3 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M4", x4 / 1000, y4 / 1000, z4 / 1000})

    End Sub
    Private Sub insertDataCotDayCo()
        listThongTinChung = getText(DuongDanData & "\TABLEBia.txt")
        InsertData(frmTTC.BangTTC, listThongTinChung)

        'Try
        textdauvao = ReadText(DuongDanData & "\TABLE2.txt")
        Dim daura As String()
        daura = mbVeMong.TachChuoi(textdauvao, 1, 1)
        If daura.Length < 2 Then
            daura = New String() {0.4, 0.4, 0.3}
        End If
        Dim daura11 As String()
        daura11 = mbVeMong.TachChuoi(textdauvao, 2, 1)
        If daura11.Length < 2 Then
            daura11 = New String() {0.4, 0.4, 0.3}
        End If
        Dim daura22 As String()
        daura22 = mbVeMong.TachChuoi(textdauvao, 3, 1)
        If daura22.Length < 2 Then
            daura22 = New String() {0.4, 0.4, 0.3}
        End If
        Dim daura33 As String()
        daura33 = mbVeMong.TachChuoi(textdauvao, 4, 1)
        If daura33.Length < 2 Then
            daura33 = New String() {0.4, 0.4, 0.3}
        End If
        'MÓNG M0
        If IsNumeric(daura(0)) Then
            frmTTC.txtbM0.Text = Val(daura(0)) * 1000
        Else
            frmTTC.txtbM0.Text = Val(daura(0)(0) + daura(0)(1) + daura(0)(2) + daura(0)(3)) * 1000
        End If
        If IsNumeric(daura(1)) Then
            frmTTC.txthM0.Text = Val(daura(0)) * 1000
        Else
            frmTTC.txthM0.Text = Val(daura(1)(0) + daura(1)(1) + daura(1)(2) + daura(1)(3)) * 1000
        End If
        If IsNumeric(daura(2)) Then
            frmTTC.txtzM0.Text = daura(2) * 1000
        Else
            frmTTC.txtzM0.Text = Val(daura(2)(0) + daura(2)(1) + daura(2)(2) + daura(2)(3)) * 1000
        End If

        'MÓNG M1
        If IsNumeric(daura11(0)) Then
            frmTTC.txtbM1.Text = Val(daura11(0)) * 1000
        Else
            frmTTC.txtbM1.Text = Val(daura11(0)(0) + daura11(0)(1) + daura11(0)(2) + daura11(0)(3)) * 1000
        End If
        If IsNumeric(daura11(1)) Then
            frmTTC.txthM1.Text = Val(daura11(0)) * 1000
        Else
            frmTTC.txthM1.Text = Val(daura11(1)(0) + daura11(1)(1) + daura11(1)(2) + daura11(1)(3)) * 1000
        End If
        If IsNumeric(daura11(2)) Then
            frmTTC.txtzM1.Text = daura11(2) * 1000
        Else
            frmTTC.txtzM1.Text = Val(daura11(2)(0) + daura11(2)(1) + daura11(2)(2) + daura11(2)(3)) * 1000
        End If

        'MÓNG M2
        If IsNumeric(daura22(0)) Then
            frmTTC.txtbM2.Text = Val(daura22(0)) * 1000
        Else
            frmTTC.txtbM2.Text = Val(daura22(0)(0) + daura22(0)(1) + daura22(0)(2) + daura22(0)(3)) * 1000
        End If
        If IsNumeric(daura22(1)) Then
            frmTTC.txthM2.Text = Val(daura22(0)) * 1000
        Else
            frmTTC.txthM2.Text = Val(daura22(1)(0) + daura22(1)(1) + daura22(1)(2) + daura22(1)(3)) * 1000
        End If
        If IsNumeric(daura22(2)) Then
            frmTTC.txtzM2.Text = daura22(2) * 1000
        Else
            frmTTC.txtzM2.Text = Val(daura22(2)(0) + daura22(2)(1) + daura22(2)(2) + daura22(2)(3)) * 1000
        End If

        'MÓNG M2
        If IsNumeric(daura33(0)) Then
            frmTTC.txtbM3.Text = Val(daura33(0)) * 1000
        Else
            frmTTC.txtbM3.Text = Val(daura33(0)(0) + daura33(0)(1) + daura33(0)(2) + daura33(0)(3)) * 1000
        End If
        If IsNumeric(daura33(1)) Then
            frmTTC.txthM3.Text = Val(daura33(0)) * 1000
        Else
            frmTTC.txthM3.Text = Val(daura33(1)(0) + daura33(1)(1) + daura33(1)(2) + daura33(1)(3)) * 1000
        End If
        If IsNumeric(daura33(2)) Then
            frmTTC.txtzM3.Text = daura33(2) * 1000
        Else
            frmTTC.txtzM3.Text = Val(daura33(2)(0) + daura33(2)(1) + daura33(2)(2) + daura33(2)(3)) * 1000
        End If

        If ThongTinChung.SoMong = 4 Then
            Dim daura44 As String()
            daura44 = mbVeMong.TachChuoi(textdauvao, 5, 1)
            If IsNumeric(daura44(0)) Then
                frmTTC.txtbM4.Text = Val(daura44(0)) * 1000
            Else
                frmTTC.txtbM4.Text = Val(daura44(0)(0) + daura44(0)(1) + daura44(0)(2) + daura44(0)(3)) * 1000
            End If
            If IsNumeric(daura44(1)) Then
                frmTTC.txthM4.Text = Val(daura44(0)) * 1000
            Else
                frmTTC.txthM4.Text = Val(daura44(1)(0) + daura44(1)(1) + daura44(1)(2) + daura44(1)(3)) * 1000
            End If
            If IsNumeric(daura44(2)) Then
                frmTTC.txtzM4.Text = daura44(2) * 1000
            Else
                frmTTC.txtzM4.Text = Val(daura44(2)(0) + daura44(2)(1) + daura44(2)(2) + daura44(2)(3)) * 1000
            End If

        End If
        'lấy móng nối chung
        If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 Then
            If IsNothing(ThongTinChung.MongNoiChung) Then
                ThongTinChung.MongNoiChung = "M1_M4"
            End If

            If ThongTinChung.MongNoiChung.Contains("M1") And ThongTinChung.MongNoiChung.Contains("M2") Then
                frmTTC.cbMongNoiChung1.SelectedIndex = 0
            ElseIf ThongTinChung.MongNoiChung.Contains("M2") And ThongTinChung.MongNoiChung.Contains("M3") Then
                frmTTC.cbMongNoiChung1.SelectedIndex = 1
            ElseIf ThongTinChung.MongNoiChung.Contains("M3") And ThongTinChung.MongNoiChung.Contains("M4") Then
                frmTTC.cbMongNoiChung1.SelectedIndex = 2
            Else
                frmTTC.cbMongNoiChung1.SelectedIndex = 3
            End If
        End If
        frmTTC.cmb_NoiDayCo.Text = ThongTinChung.NoiDayCo
        Dim pathCaoDoChanCot = DuongDanData & "\CaoDoChanCot.txt"
        Dim pathGocXoay = DuongDanData & "\GocMoc.txt"
        If ReadText(pathGocXoay) <> "" Then
            frmTTC.txtGocXoay.Text = ReadText(pathGocXoay)
        Else
            frmTTC.txtGocXoay.Text = "0"
        End If
        If ReadText(pathCaoDoChanCot) <> "" Then
            frmTTC.txtCaoDoMong.Text = ReadText(pathCaoDoChanCot)
        Else
            frmTTC.txtCaoDoMong.Text = "0"
        End If

        Dim listThongTinCot As ArrayList = New ArrayList
        listThongTinCot = getText(DuongDanData & "\TABLEMsTower.txt")
        frmTTC.BangChieuCaoDot.Rows.Clear()
        If listThongTinCot.Count > 1 Then
            InsertData(frmTTC.BangChieuCaoDot, listThongTinCot)
        Else
            If IsNumeric(ThongTinChung.SoDot) Then
                Dim chieucaodot = ThongTinChung.ChieuCaoDot
                Dim modul = ThongTinChung.TietDienCot.Split("x")(0)
                Dim space = chieucaodot / modul
                For i = 0 To ThongTinChung.SoDot - 1
                    frmTTC.BangChieuCaoDot.Rows.Add(i + 1, chieucaodot, modul, "DLM", "", "", "", space)
                Next
            End If
        End If
        'Đảo ngược lại bảng Mstower
        Dim lstRow As New List(Of DataGridViewRow)
        For i As Integer = frmTTC.BangChieuCaoDot.Rows.Count - 1 To 0 Step -1
            lstRow.Add(frmTTC.BangChieuCaoDot.Rows(i))
        Next
        frmTTC.BangChieuCaoDot.Rows.Clear()
        For i = 0 To lstRow.Count - 1
            frmTTC.BangChieuCaoDot.Rows.Add(lstRow(i))
        Next
        'Toa do mong
        Dim listChieuCao As ArrayList = New ArrayList
        listChieuCao = getText(DuongDanData & "\TABLECot.txt")
        frmTTC.dgvToaDoMong.Rows.Clear()
        If listChieuCao.Count > 2 Then
            InsertData(frmTTC.dgvToaDoMong, listChieuCao)
        Else
            If IsNumeric(ThongTinChung.SoMong) Then
                For i = 0 To ThongTinChung.SoMong - 1
                    frmTTC.dgvToaDoMong.Rows.Add("Móng " & (i + 1), 0, 0, 0)
                Next
            End If
        End If
        For i = 0 To frmTTC.dgvToaDoMong.RowCount - 1
            frmTTC.dgvToaDoMong.Rows(i).Cells("clSuaToaDo").Value = "Sửa"
        Next
        'Toa do mong Mstoer
        listChieuCao = New ArrayList
        listChieuCao = getText(DuongDanData & "\TABLEToaDoMstower.txt")
        frmTTC.dgvToaDoMongMstower.Rows.Clear()
        If listChieuCao.Count > 2 Then
            InsertData(frmTTC.dgvToaDoMongMstower, listChieuCao)
        Else
            If IsNumeric(ThongTinChung.SoMong) Then
                For i = 0 To ThongTinChung.SoMong - 1
                    frmTTC.dgvToaDoMongMstower.Rows.Add("Móng " & (i + 1), 0, 0, 0)
                Next
            End If
        End If
        'For i = 0 To frmTTC.dgvToaDoMongMstower.RowCount - 1
        '    frmTTC.dgvToaDoMongMstower.Rows(i).Cells("clSuaToaDo").Value = "Sửa"
        'Next
        'Cao do day co
        Dim listCaoDo As ArrayList = New ArrayList
        listCaoDo = getText(DuongDanData & "\TABLECaoDoDayCo.txt")
        frmTTC.dgvCaoDoDayCo.Rows.Clear()
        If listCaoDo.Count > 2 Then
            InsertData(frmTTC.dgvCaoDoDayCo, listCaoDo)
        Else
            If IsNumeric(ThongTinChung.SoTangDay) Then
                For i = 0 To ThongTinChung.SoTangDay - 1
                    frmTTC.dgvCaoDoDayCo.Rows.Add("Tầng " & (i + 1))
                Next
            End If
        End If


        Dim listChiTiet As ArrayList = New ArrayList
        listChiTiet = getText(DuongDanData & "\TABLEChiTietCot.txt")
        If listChiTiet.Count = 0 Then
            Dim chitiet = "@Loai mặt bằng_L1@Loai đốt_L1@Loai móng_L1@Loai móng_L1@Loai móng_L1@Loai móng_L1"
            Dim li() As String = chitiet.Split("@")
            listChiTiet.AddRange(li)
        End If
        If ThongTinChung.SoMong = 4 Then
            Dim text1 As String() = listChiTiet.Item(3).ToString.Split("_")
            Dim text2 As String() = listChiTiet.Item(4).ToString.Split("_")
            Dim text3 As String() = listChiTiet.Item(5).ToString.Split("_")
            Dim text4 As String() = listChiTiet.Item(6).ToString.Split("_")
            'MsgBox(listChiTiet.Item(6).ToString)
            If text1(1).Equals("L1") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 0
            ElseIf text1(1).Equals("L2") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 1
            ElseIf text1(1).Equals("L3") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 2
            End If
            If text2(1).Equals("L1") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 0
            ElseIf text2(1).Equals("L2") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 1
            ElseIf text2(1).Equals("L3") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 2
            End If
            If text3(1).Equals("L1") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 0
            ElseIf text3(1).Equals("L2") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 1
            ElseIf text3(1).Equals("L3") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 2
            End If

            If text4(1).Equals("L1") Then
                frmTTC.cmbLoaiMong4.SelectedIndex = 0
            ElseIf text4(1).Equals("L2") Then
                frmTTC.cmbLoaiMong4.SelectedIndex = 1
            ElseIf text4(1).Equals("L3") Then
                frmTTC.cmbLoaiMong4.SelectedIndex = 2
            End If
        ElseIf ThongTinChung.SoMong = 3 Then
            Dim text1 As String() = listChiTiet.Item(3).ToString.Split("_")
            Dim text2 As String() = listChiTiet.Item(4).ToString.Split("_")
            Dim text3 As String() = listChiTiet.Item(5).ToString.Split("_")
            If text1(1).Equals("L1") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 0
            ElseIf text1(1).Equals("L2") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 1
            ElseIf text1(1).Equals("L3") Then
                frmTTC.cmbLoaiMong1.SelectedIndex = 2
            End If
            If text2(1).Equals("L1") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 0
            ElseIf text2(1).Equals("L2") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 1
            ElseIf text2(1).Equals("L3") Then
                frmTTC.cmbLoaiMong2.SelectedIndex = 2
            End If
            If text3(1).Equals("L1") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 0
            ElseIf text3(1).Equals("L2") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 1
            ElseIf text3(1).Equals("L3") Then
                frmTTC.cmbLoaiMong3.SelectedIndex = 2
            End If
        End If
        'lOAD BẢNG ĐO CANH CANH
        Dim listKhoangCach As ArrayList = New ArrayList
        listKhoangCach = getText(DuongDanData & "\TABLECanhCanhCanh.txt")
        frmTTC.dgvCanhCanhCanh.Rows.Clear()
        If listKhoangCach.Count > 2 Then
            InsertData(frmTTC.dgvCanhCanhCanh, listKhoangCach)
        Else
            If IsNumeric(ThongTinChung.SoMong) Then
                For i = 0 To ThongTinChung.SoMong - 1
                    frmTTC.dgvCanhCanhCanh.Rows.Add("Móng " & (i + 1), "")
                Next
            End If
        End If
        Dim listDoGoc As ArrayList = New ArrayList
        listDoGoc = getText(DuongDanData & "\TABLECanhGocCanh.txt")
        frmTTC.dgvCanhGocCanh.Rows.Clear()
        If listDoGoc.Count > 2 Then
            InsertData(frmTTC.dgvCanhGocCanh, listDoGoc)
        Else
            If IsNumeric(ThongTinChung.SoMong) Then
                For i = 0 To ThongTinChung.SoMong - 1
                    frmTTC.dgvCanhGocCanh.Rows.Add("Móng " & (i + 1), "")
                Next
            End If
        End If


        If frmTTC.dgvToaDoMong.RowCount = 3 Then
            x1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
            y1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
            z1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

            x2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
            y2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
            z2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

            x3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
            y3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
            z3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000
        ElseIf frmTTC.dgvToaDoMong.RowCount = 4 Then
            x1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
            y1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
            z1 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

            x2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
            y2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
            z2 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

            x3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
            y3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
            z3 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000

            x4 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(3).Cells(1).Value)) * 1000
            y4 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(3).Cells(2).Value)) * 1000
            z4 = (Convert.ToDouble(frmTTC.dgvToaDoMong.Rows(3).Cells(3).Value)) * 1000
        End If
        If ThongTinChung.SoMong = 4 Then
            frmTTC.cmbLoaiMong4.DropDownStyle = ComboBoxStyle.DropDownList
            frmTTC.cmbLoaiMong4.Width = frmTTC.ImageList1.ImageSize.Width + 30
            frmTTC.cmbLoaiMong4.MaxDropDownItems = frmTTC.ImageList1.Images.Count
            frmTTC.cmbLoaiMong4.Visible = True
            frmTTC.lbMong4.Visible = True
            frmTTC.lbbM4.Visible = True
            frmTTC.lbhM4.Visible = True
            frmTTC.lbzM4.Visible = True
            frmTTC.txtbM4.Visible = True
            frmTTC.txthM4.Visible = True
            frmTTC.txtzM4.Visible = True
        ElseIf ThongTinChung.SoMong = 3 Then
            frmTTC.cmbLoaiMong4.DropDownStyle = ComboBoxStyle.DropDownList
            frmTTC.cmbLoaiMong4.Width = frmTTC.ImageList1.ImageSize.Width + 30
            frmTTC.cmbLoaiMong4.MaxDropDownItems = frmTTC.ImageList1.Images.Count
            frmTTC.cmbLoaiMong4.Visible = False
            frmTTC.lbMong4.Visible = False
            frmTTC.lbbM4.Visible = False
            frmTTC.lbhM4.Visible = False
            frmTTC.lbzM4.Visible = False
            frmTTC.txtbM4.Visible = False
            frmTTC.txthM4.Visible = False
            frmTTC.txtzM4.Visible = False
        End If
        If ThongTinChung.ViTriDat = "Dưới đất" Then
            frmTTC.cmbMoneo.Visible = False
            frmTTC.lbSoMocNeo.Visible = False
        Else

        End If
        If ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 4 Then
            frmTTC.cbMongNoiChung1.Visible = True

            frmTTC.lbMongNoiChungCot.Visible = True
        Else
            frmTTC.cbMongNoiChung1.Visible = False

            frmTTC.lbMongNoiChungCot.Visible = False
        End If
        frmTTC.txttile.Text = Math.Round((mbVeMong.mbTile()), 3)
        frmTTC.txtCoChu.Text = ChieuCaoChu
    End Sub
End Module
