Imports System.IO
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
Imports System
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports Autodesk.AutoCAD.ApplicationServices.DocumentExtension
Imports Autodesk.AutoCAD.ApplicationServices.Document
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports Autodesk.AutoCAD.Colors
Imports Autodesk.AutoCAD.PlottingServices
Imports System.Runtime.InteropServices
' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Public Class FormMD_TuDung
    Private Sub btnVe_Click(sender As Object, e As EventArgs) Handles btnVe.Click
        'MsgBox(frmTTC_TuDung.BangChieuCaoDot.Rows(0).Cells(0).Value)
        Dim H As New List(Of Double)
        Dim Soroucout As Integer = frmTTC_TuDung.BangChieuCaoDot.RowCount - 1
        Dim SoDot As Integer = frmTTC_TuDung.BangChieuCaoDot.RowCount

        For i = Soroucout To 0 Step -1
            H.Add(Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(i).Cells(1).Value) * 1000)
        Next
        'MsgBox(mbVeMong.mb_TinhH_MatDung(H, H.Count - 1))
        Dim chieucao As Double = mbVeMong.mb_TinhH_MatDung(H, H.Count - 1)
        'Lib_Drawing.CreateLine(New Point3d(0, 0, 0), New Point3d(0, chieucao, 0))
        Dim Day, Dinh As Double
        Dim lg As Integer = frmTTC_TuDung.BangChieuCaoDot.RowCount
        For i = 0 To frmTTC_TuDung.BangChieuCaoDot.RowCount - 1 Step 1
            Day = (Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - 1 - i).Cells(2).Value) * 1000)
            Dinh = (Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - 1 - i).Cells(3).Value) * 1000)
            'MsgBox(mbVeMong.mb_TinhH_MatDung(H, i))
            Lib_Drawing.CreateLine(New Point3d(Day / 2, mbVeMong.mb_TinhH_MatDung(H, i - 1), 0), New Point3d(Dinh / 2, mbVeMong.mb_TinhH_MatDung(H, i), 0))
            Lib_Drawing.CreateLine(New Point3d(-Day / 2, mbVeMong.mb_TinhH_MatDung(H, i - 1), 0), New Point3d(-Dinh / 2, mbVeMong.mb_TinhH_MatDung(H, i), 0))
        Next
        For i = 1 To frmTTC_TuDung.BangChieuCaoDot.RowCount - 1 Step 1
            Day = (Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - 1 - i).Cells(2).Value) * 1000)
            Lib_Drawing.CreateLine(New Point3d(Day / 2, mbVeMong.mb_TinhH_MatDung(H, i - 1), 0), New Point3d(-Day / 2, mbVeMong.mb_TinhH_MatDung(H, i - 1), 0))
        Next
        Lib_Drawing.CreateLine(New Point3d((Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - (lg - 1)).Cells(3).Value) * 1000) / 2, mbVeMong.mb_TinhH_MatDung(H, H.Count - 1), 0), New Point3d(-(Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - (lg - 1)).Cells(3).Value) * 1000) / 2, mbVeMong.mb_TinhH_MatDung(H, H.Count - 1), 0))
        Dim diemmong As Double = (Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(lg - 1).Cells(2).Value) * 1000) / 2
        Dim B As New List(Of Double)
        For i = Soroucout To 0 Step -1
            B.Add(Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000)
        Next
        Dim BD As New List(Of Double)
        For i = Soroucout To 0 Step -1
            BD.Add(Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(i).Cells(3).Value) * 1000)
        Next
        Dim bmongmatdung, hmongmatdung As Double
        bmongmatdung = Convert.ToDouble(frmTTC_TuDung.txtbM1.Text)
        hmongmatdung = Convert.ToDouble(frmTTC_TuDung.txthM1.Text)
        Dim Mang_Toa_Do(3) As Point2d
        Mang_Toa_Do(0) = New Point2d(-B(0) / 2 - bmongmatdung / 2, 0)
        Mang_Toa_Do(1) = New Point2d(-B(0) / 2 + bmongmatdung / 2, 0)
        Mang_Toa_Do(2) = New Point2d(-B(0) / 2 + bmongmatdung / 2, -hmongmatdung)
        Mang_Toa_Do(3) = New Point2d(-B(0) / 2 - bmongmatdung / 2, -hmongmatdung)
        Dim id_Mong As ObjectId
        id_Mong = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do, True)

        Dim Mang_Toa_Do1(3) As Point2d
        Mang_Toa_Do1(0) = New Point2d(B(0) / 2 - bmongmatdung / 2, 0)
        Mang_Toa_Do1(1) = New Point2d(B(0) / 2 + bmongmatdung / 2, 0)
        Mang_Toa_Do1(2) = New Point2d(B(0) / 2 + bmongmatdung / 2, -hmongmatdung)
        Mang_Toa_Do1(3) = New Point2d(B(0) / 2 - bmongmatdung / 2, -hmongmatdung)
        Dim id_Mong1 As ObjectId
        id_Mong1 = Lib_Drawing.CreateNewPolyline(Mang_Toa_Do1, True)


        'Vedat
        Lib_Drawing.CreateLine(New Point3d(-B(0) - 10000, 0, 0), New Point3d(B(0) + 10000, 0, 0))
        Dim CaoDoChanDot(10) As Double
        CaoDoChanDot(0) = 0

        For i = 1 To SoDot
            CaoDoChanDot(i) = CaoDoChanDot(i - 1) + H(i - 1)
        Next

        For i = 0 To SoDot - 1
            If frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "K2" Then
                VeDot_K2(H(i), CaoDoChanDot(i), B(i), BD(i), 6)
            ElseIf frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "K1,M1" Then
                VeDot_K1_M1(H(i), CaoDoChanDot(i), B(i), BD(i), 2)
            ElseIf frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "DLM" Then
                VeDot_DLM(H(i), CaoDoChanDot(i), B(i), BD(i), 6)
            ElseIf frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "XMA,M" Then
                VeDot_XMA_M(H(i), CaoDoChanDot(i), B(i), BD(i), 6)
            ElseIf frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "XMA" Then
                VeDot_XMA(H(i), CaoDoChanDot(i), B(i), BD(i), 6)
            ElseIf frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clDoc").Value = "KMG" Then
                VeDot_KMG(H(i), CaoDoChanDot(i), B(i), BD(i), 6)
            End If
        Next
#Region "Text"
        Dim ToaDoXDimTong As Double = -B(0) - TiLeChu * 20
        Dim ToaDoXDim As Double = -B(0) - TiLeChu * 20
        Dim ToaDoXText As Double = -B(0) - TiLeChu * 4
        Dim ToaDoCaoDo As Double = -B(0) - TiLeChu * 17
        Dim Tongcaotext As Double = 0
        '' Text
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateNewMText(New Point3d(ToaDoXText, (H(i) + Tongcaotext + Tongcaotext) / 2, 0), "Đốt " & i + 1, TiLeChu)
            Tongcaotext = H(i) + Tongcaotext
        Next
#End Region
#Region "Dim"
        Dim Tongcaodim As Double = 0
        For i As Integer = 0 To SoDot - 1
            Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDim, Tongcaodim, 0), New Point3d(ToaDoXDim, H(i) + Tongcaodim, 0), New Point3d(ToaDoXDim, (H(i) + Tongcaodim + Tongcaodim) / 2, 0), 90, TiLeChu / 2) ' dim tung dot
            Tongcaodim = H(i) + Tongcaodim
        Next
        'Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, Tongcaodim, 0), New Point3d(ToaDoXDimTong - 500, (H(0) + H(SoDot - 1)) / 2, 0), 90, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(ToaDoXDimTong, 0, 0), New Point3d(ToaDoXDimTong, Tongcaodim, 0), New Point3d(ToaDoXDimTong - TiLeChu * 4, (H(0) + H(SoDot - 1)) / 2, 0), 90, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(-B(0) / 2, 0, 0), New Point3d(B(0) / 2, 0, 0), New Point3d(0, -TiLeChu * 3, 0), 0, TiLeChu / 2)
#End Region
#Region "CaoDo"

        Dim Tongcao As Double
        Dim Tongcaotile As Double
        Dim tile As Double = 80
        Dim cao As Integer = frmTTC_TuDung.BangChieuCaoDot.RowCount
        Dim CaoDo As String
        For i = 0 To cao - 1
            Tongcao = Tongcao + H(i)
            Tongcaotile = Tongcaotile + H(i) + frmTTC_TuDung.dgvToaDoMong.Rows(0).Cells(3).Value * 1000

            CaoDo = Format(Tongcaotile, "##,#")
            Lib_Drawing.insertBlock(New Point3d(ToaDoCaoDo + 100, Tongcao, 0), "ct", TiLeChu, "+" & CaoDo)
        Next
        Dim Kichthuoccaodo1 = Convert.ToDouble(frmTTC_TuDung.dgvToaDoMong.Rows(0).Cells(3).Value) * 1000
        CaoDo = Format(Kichthuoccaodo1, "##,#")
        Lib_Drawing.insertBlock(New Point3d(ToaDoCaoDo + 100, 0, 0), "ct", TiLeChu, "+" & Kichthuoccaodo1)
        'If frmTTC_TuDung.dgvToaDoMong.Rows(0).Cells(3).Value <> "0" Then
        '    Dim Kichthuoccaodo1 = Convert.ToDouble(frmTTC_TuDung.dgvToaDoMong.Rows(0).Cells(3).Value) * 1000
        '    If Kichthuoccaodo1 = 0 Then
        '        Lib_Drawing.insertBlock(New Point3d(B(0) / 2, -b_hMong1, 0), "ct", tile / 2, "%%p0.000")
        '    Else
        '        Dim Caodomong1 As String
        '        Caodomong1 = Format(Kichthuoccaodo1, "##,#")
        '        Lib_Drawing.insertBlock(New Point3d(B(0) / 2, -b_hMong1, 0), "ct", tile / 2, "+" & Caodomong1)
        '    End If

        '    Dim Kichthuoccaodo2 = Convert.ToDouble(frmTTC_TuDung.dgvToaDoMong.Rows(1).Cells(3).Value) * 1000
        '    If Kichthuoccaodo2 = 0 Then
        '        Lib_Drawing.insertBlock(New Point3d(-B(0) / 2, -b_hMong1, 0), "ct", tile / 2, "%%p0.000")
        '    Else
        '        Dim Caodomong2 As String
        '        Caodomong2 = Format(Kichthuoccaodo2, "##,#")
        '        Lib_Drawing.insertBlock(New Point3d(-B(0) / 2, -b_hMong1, 0), "ct", tile / 2, "+" & Caodomong2)
        '    End If
        'End If


#End Region
#Region "Ve MC Ngang"
        For i = 1 To SoDot - 1
            Dim TenMatCatNgang As String = frmTTC_TuDung.BangChieuCaoDot.Rows(SoDot - 1 - i).Cells("clNgang").Value
            VeMCNgang("PL2A", BD(i - 1), B(i), New Point3d(B(0) + 500, CaoDoChanDot(i), 0))
        Next

        'VeMCNgang("PL2A", BD(0), B(1), New Point3d(B(0) + 500, H(0), 0))

        'VeMCNgang("PL2A", BD(1), B(2), New Point3d(B(0) + 500, H(0) + H(1), 0))

        'VeMCNgang("PLD", BD(2), B(3), New Point3d(B(0) + 500, H(0) + H(1) + H(2), 0))

        'VeMCNgang("PL3S", BD(3), B(4), New Point3d(B(0) + 500, H(0) + H(1) + H(2) + H(3), 0))
#End Region
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
    End Sub
    Public Shared Sub VeDot_K2(Caodot As Double, caodotduoi As Double, Rongduoi As Double, rongtren As Double, Sodoan As Double)
        Lib_Drawing.CreateLine(New Point3d(-Rongduoi / 2, caodotduoi, 0), New Point3d(0, caodotduoi + Caodot, 0))
        Lib_Drawing.CreateLine(New Point3d(Rongduoi / 2, caodotduoi, 0), New Point3d(0, caodotduoi + Caodot, 0))
        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, caodotduoi, 0)
        Dim e1 As Point3d = New Point3d(-rongtren / 2, Caodot + caodotduoi, 0)
        Dim e2 As Point3d = New Point3d(0, caodotduoi + Caodot, 0)
#Region "Thanh Ngang"       '
        For i As Integer = 1 To Sodoan
            Ve(s1, e1, e2, Sodoan, i, i)
        Next
#End Region
#Region "Thanh Cheo"
        For i As Integer = 1 To Sodoan - 1
            Ve(s1, e1, e2, Sodoan, i + 1, i)
        Next
#End Region

    End Sub
    Public Shared Sub VeDot_K1_M1(caodot As Double, caodotduoi As Double, Rongduoi As Double, Rongtren As Double, sodoan As Integer)
        Dim td As Double = (Rongduoi + Rongtren) / 4
        Lib_Drawing.CreateLine(New Point3d(0, caodotduoi, 0), New Point3d(-td, caodotduoi + caodot / 2, 0))
        Lib_Drawing.CreateLine(New Point3d(0, caodotduoi, 0), New Point3d(td, caodotduoi + caodot / 2, 0))
        Lib_Drawing.CreateLine(New Point3d(0, caodotduoi + caodot, 0), New Point3d(-td, caodotduoi + caodot / 2, 0))
        Lib_Drawing.CreateLine(New Point3d(0, caodotduoi + caodot, 0), New Point3d(td, caodotduoi + caodot / 2, 0))

        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, caodotduoi, 0)
        Dim s2 As Point3d = New Point3d(0, caodotduoi, 0)
        Dim e As Point3d = New Point3d(-td, caodotduoi + caodot / 2, 0)
        Dim id_l1 As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s1, e, sodoan)(0), ChiaDoan.ChiaDoan(s2, e, sodoan)(1))
        Dim id_l2 As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s1, e, sodoan)(1), ChiaDoan.ChiaDoan(s2, e, sodoan)(1))
        Dim s3 As Point3d = New Point3d(-Rongtren / 2, caodotduoi + caodot, 0)
        Dim s4 As Point3d = New Point3d(0, caodotduoi + caodot, 0)

        Dim id_l3 As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s3, e, sodoan)(0), ChiaDoan.ChiaDoan(s4, e, sodoan)(1))
        Dim id_l4 As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s3, e, sodoan)(1), ChiaDoan.ChiaDoan(s4, e, sodoan)(1))
#Region "DoiXung"
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim line1 As New Line
        Dim line2 As New Line
        Dim line3 As New Line
        Dim line4 As New Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line1 = acTrans.GetObject(id_l1, OpenMode.ForWrite)
            line2 = acTrans.GetObject(id_l2, OpenMode.ForWrite)
            line3 = acTrans.GetObject(id_l3, OpenMode.ForWrite)
            line4 = acTrans.GetObject(id_l4, OpenMode.ForWrite)
            Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 1000000, 0), line1)
            Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 1000000, 0), line2)
            Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 1000000, 0), line3)
            Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 1000000, 0), line4)
            acTrans.Commit()
        End Using
#End Region
    End Sub
    Public Shared Sub VeDot_XMA_M(Caodot As Double, Caodotduoi As Double, Rongduoi As Double, rongtren As Double, Sodoan As Double)

        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, Caodotduoi, 0)
        Dim s2 As Point3d = New Point3d(Rongduoi / 2, Caodotduoi, 0)
        Dim e1 As Point3d = New Point3d(-rongtren / 2, Caodotduoi + Caodot, 0)
        Dim e2 As Point3d = New Point3d(rongtren / 2, Caodotduoi + Caodot, 0)
        Lib_Drawing.CreateLine(New Point3d(0, Caodotduoi, 0), ChiaDoan.ChiaDoan(s1, e1, Sodoan)(1))
        Lib_Drawing.CreateLine(New Point3d(0, Caodotduoi, 0), ChiaDoan.ChiaDoan(s2, e2, Sodoan)(1))
        For i = 1 To Sodoan - 1
            Ve1(s1, s2, e1, e2, Sodoan, i, i + 1)
            Ve1(s1, s2, e1, e2, Sodoan, i + 1, i)
        Next

    End Sub
    Public Shared Sub VeDot_XMA(Caodot As Double, Caodotduoi As Double, Rongduoi As Double, rongtren As Double, Sodoan As Double)
        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, Caodotduoi, 0)
        Dim s2 As Point3d = New Point3d(Rongduoi / 2, Caodotduoi, 0)
        Dim e1 As Point3d = New Point3d(-rongtren / 2, Caodotduoi + Caodot, 0)
        Dim e2 As Point3d = New Point3d(rongtren / 2, Caodotduoi + Caodot, 0)
        For i = 0 To Sodoan - 1
            Ve1(s1, s2, e1, e2, Sodoan, i, i + 1)
            Ve1(s1, s2, e1, e2, Sodoan, i + 1, i)
        Next
    End Sub
    Public Shared Sub VeDot_DLM(Caodot As Double, Caodotduoi As Double, Rongduoi As Double, rongtren As Double, Sodoan As Double)
        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, Caodotduoi, 0)
        Dim s2 As Point3d = New Point3d(Rongduoi / 2, Caodotduoi, 0)
        Dim e1 As Point3d = New Point3d(-rongtren / 2, Caodotduoi + Caodot, 0)
        Dim e2 As Point3d = New Point3d(rongtren / 2, Caodotduoi + Caodot, 0)
        For i = 0 To Sodoan - 1
            Ve1(s1, s2, e1, e2, Sodoan, i, i + 1)
            Ve1(s1, s2, e1, e2, Sodoan, i + 1, i)
            Ve1(s1, s2, e1, e2, Sodoan, i, i)
        Next
    End Sub
    Public Shared Sub VeDot_KMG(Caodot As Double, Caodotduoi As Double, Rongduoi As Double, Rongtren As Double, Sodoan As Double)
#Region ""
        Lib_Drawing.CreateLine(New Point3d(-Rongduoi / 2, Caodotduoi, 0), New Point3d(0, Caodotduoi + Caodot, 0))
        Lib_Drawing.CreateLine(New Point3d(Rongduoi / 2, Caodotduoi, 0), New Point3d(0, Caodotduoi + Caodot, 0))
        Lib_Drawing.CreateLine(New Point3d(-Rongduoi / 2, Caodotduoi, 0), New Point3d(-Rongtren / 2, Caodotduoi + Caodot, 0))
        Lib_Drawing.CreateLine(New Point3d(Rongduoi / 2, Caodotduoi, 0), New Point3d(Rongtren / 2, Caodotduoi + Caodot, 0))
        Dim s1 As Point3d = New Point3d(-Rongduoi / 2, Caodotduoi, 0)
        Dim e1 As Point3d = New Point3d(-Rongtren / 2, Caodotduoi + Caodot, 0)
        Dim e2 As Point3d = New Point3d(0, Caodotduoi + Caodot, 0)
#End Region
#Region "Ve ND"
#Region "Thanh Ngang"
        Dim listId As New List(Of ObjectId)
        For i = 1 To 6
            listId.Add(Ve(s1, e1, e2, Sodoan, i, i))
        Next

#End Region
#Region "Thanh Cheo"
        For i = 1 To 3
            Ve(s1, e1, e2, Sodoan, i + 1, i)
        Next
#End Region
#End Region
#Region "Ve NTR"
        Dim Duongthang As New List(Of Line)
        For i = 0 To 5
            Duongthang.Add(LayThucThe(listId(i)))
        Next
        Dim Diem1 = New Point3d((Duongthang(4).StartPoint.X + Duongthang(4).EndPoint.X) / 2, Duongthang(4).StartPoint.Y, 0)
        Dim Diem2 = New Point3d((Duongthang(5).StartPoint.X + Duongthang(5).EndPoint.X) / 2, Duongthang(5).StartPoint.Y, 0)

        Ve2(Duongthang(3).StartPoint, Diem1)
        Ve2(Duongthang(3).EndPoint, Diem1)
        Ve2(Duongthang(5).StartPoint, Diem1)
        Ve2(Diem1, Diem2)
        Ve2(Diem2, Duongthang(4).EndPoint)
        Ve2(New Point3d(0, Duongthang(4).StartPoint.Y, 0), Duongthang(4).EndPoint)
#End Region
    End Sub
    Public Shared Sub VeMCNgang(Tenmatcat As String, KichThuoc As Double, KichThuocPhu As Double, DiemVe As Point3d)
        Dim Id_1 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0))
        Dim Id_2 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0))
        Dim Id_3 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0))
        Dim Id_4 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0))
        Lib_Drawing.CreateRotatedDimension1(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2 - KichThuoc / 4, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2 - KichThuoc / 4, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2 - KichThuoc / 2, 0), 0, TiLeChu / 2)
        Lib_Drawing.CreateRotatedDimension1(New Point3d(DiemVe.X + KichThuoc / 2 + KichThuoc / 4, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuoc / 2 + KichThuoc / 4, DiemVe.Y - KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuoc / 2 + KichThuoc / 2, DiemVe.Y, 0), 90, TiLeChu / 2)

        If Tenmatcat = "PL2A" Then
            Dim Id_5 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0))
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))

            Dim Id_7 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))
            Dim Id_8 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_9 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_10 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))
        ElseIf Tenmatcat = "PLD" Then
            Dim Id_5 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0))
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            VeMCPhu(KichThuoc, DiemVe)
        ElseIf Tenmatcat = "PLX" Then
            Dim Id_5 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0))
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
        ElseIf Tenmatcat = "4" Then
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_7 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))
            Dim Id_8 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_9 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_10 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))
        ElseIf Tenmatcat = "5" Then
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            VeMCPhu(KichThuoc, DiemVe)
        ElseIf Tenmatcat = "6" Then
            Dim Id_6 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
        ElseIf Tenmatcat = "PL3S" Then
            Dim Id_7 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))
            Dim Id_8 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_9 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y - KichThuoc / 2, 0))
            Dim Id_10 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y, 0), New Point3d(DiemVe.X, DiemVe.Y + KichThuoc / 2, 0))

            Dim Id_11 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0), New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0))
            Dim Id_12 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0), New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0))
            Dim Id_13 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0), New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0))
            Dim Id_14 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0), New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0))

            Dim Id_15 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0))
            Dim Id_16 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0), New Point3d(DiemVe.X - KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0))
            Dim Id_17 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y - KichThuocPhu / 2, 0))
            Dim Id_18 As ObjectId = Lib_Drawing.CreateLine(New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0), New Point3d(DiemVe.X + KichThuocPhu / 2, DiemVe.Y + KichThuocPhu / 2, 0))
        End If
    End Sub
    Public Shared Sub VeMCPhu(KichThuoc As Double, DiemVe As Point3d)
        Dim s1 As Point3d = New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0)
        Dim e1 As Point3d = New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0)
        Dim p1 As List(Of Point3d) = ChiaDoan.ChiaDoan(s1, e1, 3)

        s1 = New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0)
        e1 = New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0)
        Dim p2 As List(Of Point3d) = ChiaDoan.ChiaDoan(s1, e1, 3)

        s1 = New Point3d(DiemVe.X - KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0)
        e1 = New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0)
        Dim p3 As List(Of Point3d) = ChiaDoan.ChiaDoan(s1, e1, 3)

        s1 = New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y - KichThuoc / 2, 0)
        e1 = New Point3d(DiemVe.X + KichThuoc / 2, DiemVe.Y + KichThuoc / 2, 0)
        Dim p4 As List(Of Point3d) = ChiaDoan.ChiaDoan(s1, e1, 3)

        Dim Id_1 As ObjectId = Lib_Drawing.CreateLine(p1(2), p2(1))
        Dim Id_2 As ObjectId = Lib_Drawing.CreateLine(p2(2), p3(1))
        Dim Id_3 As ObjectId = Lib_Drawing.CreateLine(p3(2), p4(1))
        Dim Id_4 As ObjectId = Lib_Drawing.CreateLine(p4(2), p1(1))
    End Sub
    Public Class ChiaDoan
        Public Shared Function ChiaDoan(startPoint As Point3d, endPoint As Point3d, TongSoDoan As Integer) As List(Of Point3d)
            Dim P As New List(Of Point3d)
            Dim midX As Single
            Dim midY As Single
            For i As Integer = 0 To TongSoDoan
                midX = (startPoint.X + (i * (endPoint.X - startPoint.X)) / TongSoDoan)
                midY = (startPoint.Y + (i * (endPoint.Y - startPoint.Y)) / TongSoDoan)
                P.Add(New Point3d(midX, midY, 0))
            Next
            Return (P)
        End Function
    End Class
    Private Shared Function Ve(s1 As Point3d, e1 As Point3d, e2 As Point3d, Sodoan As Double, i As Integer, j As Integer) As ObjectId
        Dim id As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s1, e1, Sodoan)(i), ChiaDoan.ChiaDoan(s1, e2, Sodoan)(j))
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Dim Line As Line
        Using tr
            Line = tr.GetObject(id, OpenMode.ForWrite)
            Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 1000000, 0), Line)
            tr.Commit()
        End Using
        Return id
    End Function
    Private Shared Sub Ve1(s1 As Point3d, s2 As Point3d, e1 As Point3d, e2 As Point3d, Sodoan As Double, i As Integer, j As Integer)
        Dim id As ObjectId = Lib_Drawing.CreateLine(ChiaDoan.ChiaDoan(s1, e1, Sodoan)(i), ChiaDoan.ChiaDoan(s2, e2, Sodoan)(j))
    End Sub
    Public Shared Function LayThucThe(Id As ObjectId) As Line
        Dim Duongthang As New Line
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            Duongthang = tr.GetObject(Id, OpenMode.ForWrite)
            tr.Commit()
        End Using
        Return Duongthang
    End Function
    Public Shared Sub Ve2(Diem1 As Point3d, Diem2 As Point3d)
        Dim ID1 = Lib_Drawing.CreateLine(Diem1, Diem2)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Dim Duongthang As New Line
        Using tr
            Duongthang = tr.GetObject(ID1, OpenMode.ForWrite)
            tr.Commit()
        End Using
        Lib_Drawing.DoiXung(New Point3d(0, 0, 0), New Point3d(0, 100000, 0), Duongthang)
    End Sub

End Class