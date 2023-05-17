Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO

Public Class Cot_TuDung
    Public Shared Sub Ve_MD_TuDung(listrong As List(Of Double), listcao As List(Of Double), soDot As String)
        For i As Integer = 0 To soDot - 1
            Dim h As Double = 0
            Dim Toa_Do_Panel(3) As Point2d
            Toa_Do_Panel(0) = New Point2d(-listrong(i) / 2, h + listcao(i))
            Toa_Do_Panel(1) = New Point2d(-listrong(i) / 2, listcao(i + 1))
            Toa_Do_Panel(2) = New Point2d(listrong(i) / 2, listcao(i + 1))
            Toa_Do_Panel(3) = New Point2d(listrong(i) / 2, listcao(i))
        Next
    End Sub
    Public Shared Sub Ve_MB_TuDung(b_dinh As Double, b_day As Double, b_mong1 As Double, b_mong2 As Double, b_mong3 As Double, b_mong4 As Double)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        'Dinh
        VeVuong(b_dinh)
        'Day
        VeVuong(b_day)
        'Noi
        VeNoi(-b_dinh, -b_dinh, -b_day, -b_day)
        VeNoi(-b_dinh, b_dinh, -b_day, b_day)
        VeNoi(b_dinh, b_dinh, b_day, b_day)
        VeNoi(b_dinh, -b_dinh, b_day, -b_day)
        'Mong1
        Ve_MongMB(-b_day, b_day, b_mong1)
        'Mong2
        Ve_MongMB(b_day, b_day, b_mong2)
        'Mong3
        Ve_MongMB(b_day, -b_day, b_mong3)
        'Mong4
        Ve_MongMB(-b_day, -b_day, b_mong4)
        'Dim Dim1 As ObjectId = Lib_Drawing.CreateRotatedDimension(New Point3d(b_day + b_mong1, b_day, 0), New Point3d(b_day + b_mong1, -b_day, 0), New Point3d(b_day + b_mong1 + b_mong1, 0, 0), 90)
        'Dim Dim2 As ObjectId = Lib_Drawing.CreateRotatedDimension(New Point3d(-b_day, -b_day - b_mong1, 0), New Point3d(b_day, -b_day - b_mong1, 0), New Point3d(0, -b_day - b_mong1 - b_mong1, 0), 0)
    End Sub
    Public Shared Sub Ve_MongMB(GocX As Double, GocY As Double, KTMong As Double)
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
End Class
