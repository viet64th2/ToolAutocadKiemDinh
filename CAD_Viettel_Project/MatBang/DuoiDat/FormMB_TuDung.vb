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
Public Class FormMB_TuDung
    Private Sub btnlai_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        Dim b1, b2, b3, b4 As Double
        b1 = Convert.ToDouble(frmTTC_TuDung.txtbM1.Text)
        b2 = Convert.ToDouble(frmTTC_TuDung.txtbM2.Text)
        b3 = Convert.ToDouble(frmTTC_TuDung.txtbM3.Text)
        b4 = Convert.ToDouble(frmTTC_TuDung.txtbM4.Text)

        Dim i As Integer = frmTTC_TuDung.BangChieuCaoDot.RowCount - 1
        Dim b_day As Double
        b_day = Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(i).Cells(2).Value) * 1000
        Dim b_dinh As Double
        b_dinh = Convert.ToDouble(frmTTC_TuDung.BangChieuCaoDot.Rows(0).Cells(2).Value) * 1000

#Region "Than"
        VeVuong(b_dinh)
        VeVuong(b_day)
#End Region
#Region "Noi"
        VeNoi(-b_dinh, -b_dinh, -b_day, -b_day)
        VeNoi(-b_dinh, b_dinh, -b_day, b_day)
        VeNoi(b_dinh, b_dinh, b_day, b_day)
        VeNoi(b_dinh, -b_dinh, b_day, -b_day)
#End Region
#Region "VeMong"
        'Mong1
        Ve_MongMB(-b_day, b_day, b1)
        'Mong2
        Ve_MongMB(b_day, b_day, b2)
        'Mong3
        Ve_MongMB(b_day, -b_day, b3)
        'Mong4
        Ve_MongMB(-b_day, -b_day, b4)
#End Region
#Region "TaoDim"
        TaoDim(b_day, TiLeChu / 2)
#End Region
#Region "TaoText"
        TaoText(-b_day / 2 - b1 - TiLeChu * 12, b_day / 2 + b1 + TiLeChu * 2, TiLeChu, 1)
        TaoText(b_day / 2 + b2 + TiLeChu * 1, b_day / 2 + b2 + TiLeChu * 2, TiLeChu, 2)
        TaoText(b_day / 2 + b3 + TiLeChu * 1, -b_day / 2 - b3, TiLeChu, 3)
        TaoText(-b_day / 2 - b4 - TiLeChu * 12, -b_day / 2 - b4, TiLeChu, 4)

#End Region
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
    End Sub

    Public Shared Sub Ve_MongMB(GocX As Double, GocY As Double, KTMong As Double)
        GocX = GocX / 2
        GocY = GocY / 2
        KTMong = KTMong / 2
        Dim Toa_Do_Mong(3) As Point2d
        Toa_Do_Mong(0) = New Point2d(GocX - KTMong, GocY - KTMong)
        Toa_Do_Mong(1) = New Point2d(GocX - KTMong, GocY + KTMong)
        Toa_Do_Mong(2) = New Point2d(GocX + KTMong, GocY + KTMong)
        Toa_Do_Mong(3) = New Point2d(GocX + KTMong, GocY - KTMong)
        Dim Mong As ObjectId = Lib_Drawing.CreateNewPolyline(Toa_Do_Mong, True)
    End Sub

    Public Shared Sub VeVuong(KThuoc As Double)
        KThuoc = KThuoc / 2
        Dim Toa_Do(3) As Point2d
        Toa_Do(0) = New Point2d(-KThuoc, -KThuoc)
        Toa_Do(1) = New Point2d(-KThuoc, KThuoc)
        Toa_Do(2) = New Point2d(KThuoc, KThuoc)
        Toa_Do(3) = New Point2d(KThuoc, -KThuoc)
        Dim VeVuong As ObjectId = Lib_Drawing.CreateNewPolyline(Toa_Do, True)
    End Sub

    Public Shared Sub VeNoi(DinhX As Double, DinhY As Double, DayX As Double, DayY As Double)
        DayX = DayX / 2
        DinhX = DinhX / 2
        DayY = DayY / 2
        DinhY = DinhY / 2
        Dim Noi As ObjectId = Lib_Drawing.CreateLine(New Point3d(DinhX, DinhY, 0), New Point3d(DayX, DayY, 0))
    End Sub
    Public Shared Sub TaoDim(KichThuoc As Double, A As Double)
        KichThuoc = KichThuoc / 2
        Dim Dim1 As ObjectId = Lib_Drawing.CreateRotatedDimension1(New Point3d(-KichThuoc, -KichThuoc, 0), New Point3d(KichThuoc, -KichThuoc, 0), New Point3d(0, -KichThuoc - TiLeChu * 4, 0), 0, A)
        Dim Dim2 As ObjectId = Lib_Drawing.CreateRotatedDimension1(New Point3d(KichThuoc, -KichThuoc, 0), New Point3d(KichThuoc, KichThuoc, 0), New Point3d(KichThuoc + TiLeChu * 4, 0, 0), 90, A)
    End Sub
    Public Shared Sub TaoText(VitriX As Double, VitriY As Double, Docao As Double, i As Integer)
        Lib_Drawing.CreateNewMText(New Point3d(VitriX, VitriY, 0), "Móng M" & i, Docao)
    End Sub
End Class