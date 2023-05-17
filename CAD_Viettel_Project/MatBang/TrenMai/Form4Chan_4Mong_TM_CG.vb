Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class Form4Chan_4Mong_TM_CG
    Private Sub btn4chan4mong_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        '4chan 4mong tren mai dam ngang co ga chong xoay
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        'If cmbLoaiDam.SelectedIndex = 0 Then
        'Dim PrPointPt As PromptPointOptions = New PromptPointOptions("")
        'PrPointPt.Message = vbLf & "Chọn điểm chèn mặt cắt: "
        'PrPointPt.AllowNone = False
        'Dim PrPointRes As PromptPointResult = ed.GetPoint(PrPointPt)
        ' Dim Diem_Chen As Point3d = PrPointRes.Value
        Dim TextHight As Double = TiLeChu
        Dim Linetylescale As Double = Tile
        Dim Dimscale As Double = TextHight
            mbVeMong.Ve_Mong_0trenmai(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
            mbVeMong.Ve_Cot_Tu_Giac_Trenmai(b_bchancot, b_hchancot, b_d, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, True)
            mbVeMong.Ga_Chong_Xoay_MB_Tu_Giac(b_bchancot, b_hchancot, b_d, 0, 0, "0", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4)
            mbVeMong.VeMong(x1, y1, b_bMong1, b_hMong1, b_a, b_bmove, b_hmove, "Móng 1", TextHight, Linetylescale, "1", "Trên mái", b_Mong1)
            mbVeMong.VeMong(x2, y2, b_bMong2, b_hMong2, b_a, b_bmove, b_hmove, "Móng 2", TextHight, Linetylescale, "1", "Trên mái", b_Mong2)
            mbVeMong.VeMong(x3, y3, b_bMong3, b_hMong3, b_a, b_bmove, b_hmove, "Móng 3", TextHight, Linetylescale, "1", "Trên mái", b_Mong3)
            mbVeMong.VeMong(x4, y4, b_bMong4, b_hMong4, b_a, b_bmove, b_hmove, "Móng 4", TextHight, Linetylescale, "1", "Trên mái", b_Mong4)
        'Dim id_dam1 As ObjectId
        'Dim id_dam2 As ObjectId
        'id_dam1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(x4, y4, 0))
        'id_dam2 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(x2, y2, 0))
        'Dim dam1 As Line
        'Dim dam2 As Line
        'Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
        '    dam1 = acTrans.GetObject(id_dam1, OpenMode.ForWrite)
        '    dam2 = acTrans.GetObject(id_dam2, OpenMode.ForWrite)
        '    dam1.Layer = "9"
        '    dam2.Layer = "9"
        '    dam1.LinetypeScale = Linetylescale
        '    dam2.LinetypeScale = Linetylescale
        '    acTrans.Commit()
        'End Using
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
        'ElseIf cmbLoaiDam.SelectedIndex = 1 Then
        '    b_d = 0
        '    'Dim PrPointPt As PromptPointOptions = New PromptPointOptions("")
        '    'PrPointPt.Message = vbLf & "Chọn điểm chèn mặt cắt: "
        '    'PrPointPt.AllowNone = False
        '    'Dim PrPointRes As PromptPointResult = ed.GetPoint(PrPointPt)
        '    ' Dim Diem_Chen As Point3d = PrPointRes.Value
        '    Dim TextHight As Double = TiLeChu
        '    Dim Linetylescale As Double = mbVeMong.mbTile(x3, y3) / 100
        '    Dim Dimscale As Double = TextHight
        '    mbVeMong.Ve_Mong_0trenmai(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
        '    mbVeMong.Ve_Cot_Tu_Giac_Trenmai(b_bchancot, b_hchancot, b_d, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, True)
        '    mbVeMong.Ga_Chong_Xoay_MB_Tu_Giac(b_bchancot, b_hchancot, b_d, 0, 0, "0", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4)
        '    mbVeMong.VeMong(x1, y1, b_bMong1, b_hMong1, b_a, b_bmove, b_hmove, "Móng 1", TextHight, Linetylescale, "1", "Trên mái", b_Mong1)
        '    mbVeMong.VeMong(x2, y2, b_bMong2, b_hMong2, b_a, b_bmove, b_hmove, "Móng 2", TextHight, Linetylescale, "1", "Trên mái", b_Mong2)
        '    mbVeMong.VeMong(x3, y3, b_bMong3, b_hMong3, b_a, b_bmove, b_hmove, "Móng 3", TextHight, Linetylescale, "1", "Trên mái", b_Mong3)
        '    mbVeMong.VeMong(x4, y4, b_bMong4, b_hMong4, b_a, b_bmove, b_hmove, "Móng 4", TextHight, Linetylescale, "1", "Trên mái", b_Mong4)
        '    Dim id_dam1 As ObjectId
        '    Dim id_dam2 As ObjectId
        '    id_dam1 = Lib_Drawing.CreateLine(New Point3d(x1, y1, 0), New Point3d(x2, y2, 0))
        '    id_dam2 = Lib_Drawing.CreateLine(New Point3d(x3, y3, 0), New Point3d(x4, y4, 0))
        '    Dim dam1 As Line
        '    Dim dam2 As Line
        '    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
        '        dam1 = acTrans.GetObject(id_dam1, OpenMode.ForWrite)
        '        dam2 = acTrans.GetObject(id_dam2, OpenMode.ForWrite)
        '        dam1.Layer = "9"
        '        dam2.Layer = "9"
        '        dam1.LinetypeScale = Linetylescale
        '        dam2.LinetypeScale = Linetylescale
        '        acTrans.Commit()
        '    End Using
        'MsgBox("Đã vẽ xong! Tắt bỏ để xem")


        'End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)
        mbVeMong.EraseAll()
        MsgBox("Đã xóa! Tắt bỏ để xem")
    End Sub
End Class