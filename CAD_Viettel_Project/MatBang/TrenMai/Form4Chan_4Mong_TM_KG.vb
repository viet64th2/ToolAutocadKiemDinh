Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class Form4Chan_4Mong_TM_KG
    Private Sub btn4chan4mongl1cg_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        'If cmbLoaiDam.SelectedIndex = 0 Then
        '4chan 4mong tren mai dam ngang
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database
            Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
            Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d

            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database
            Dim ed As Editor = doc.Editor

        'Dim PrPointPt As PromptPointOptions = New PromptPointOptions("")
        'PrPointPt.Message = vbLf & "Chọn điểm chèn mặt cắt: "
        'PrPointPt.AllowNone = False
        'Dim PrPointRes As PromptPointResult = ed.GetPoint(PrPointPt)
        ' Dim Diem_Chen As Point3d = PrPointRes.Value
        Dim TextHight As Double = TiLeChu
        Dim Linetylescale As Double = Tile
        Dim Dimscale As Double = TextHight
            mbVeMong.Ve_Mong_0trenmai(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
            mbVeMong.Ve_Cot_Tu_Giac_Trenmai(b_bchancot, b_hchancot, b_d, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, False)
            b_bmove = 0
            b_hmove = 0
            mbVeMong.VeMong(x1, y1, b_bMong1, b_hMong1, b_bmove, b_hmove, b_a, "Móng 1", TextHight, Linetylescale, "1", "Trên mái", b_Mong1)
            mbVeMong.VeMong(x2, y2, b_bMong2, b_hMong2, b_bmove, b_hmove, b_a, "Móng 2", TextHight, Linetylescale, "1", "Trên mái", b_Mong2)
            mbVeMong.VeMong(x3, y3, b_bMong3, b_hMong3, b_bmove, b_hmove, b_a, "Móng 3", TextHight, Linetylescale, "1", "Trên mái", b_Mong3)
            mbVeMong.VeMong(x4, y4, b_bMong4, b_hMong4, b_bmove, b_hmove, b_a, "Móng 4", TextHight, Linetylescale, "1", "Trên mái", b_Mong4)
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
        'ElseIf cmbLoaiDam.SelectedIndex = 1 Then
        '    Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        '    Dim acCurDb As Database = acDoc.Database
        '    Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        '    Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d

        '    Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        '    Dim db As Database = doc.Database
        '    Dim ed As Editor = doc.Editor
        '    b_d = 100
        '    'Dim PrPointPt As PromptPointOptions = New PromptPointOptions("")
        '    'PrPointPt.Message = vbLf & "Chọn điểm chèn mặt cắt: "
        '    'PrPointPt.AllowNone = False
        '    'Dim PrPointRes As PromptPointResult = ed.GetPoint(PrPointPt)
        '    ' Dim Diem_Chen As Point3d = PrPointRes.Value
        '    Dim TextHight As Double = TiLeChu
        '    Dim Linetylescale As Double = mbVeMong.mbTile(x3, y3) / 100
        '    Dim Dimscale As Double = TextHight
        '    mbVeMong.Ve_Mong_0trenmai(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
        '    mbVeMong.Ve_Cot_Tu_Giac_Trenmai(b_bchancot, b_hchancot, b_d, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, False)
        '    b_bmove = 0
        '    b_hmove = 0
        '    mbVeMong.VeMong(x1, y1, b_bmong, b_hmong, b_a, b_bmove, b_hmove, "Móng 1", TextHight, Linetylescale, "1", "Trên mái", b_Mong1)
        '    mbVeMong.VeMong(x2, y2, b_bmong, b_hmong, b_a, b_bmove, b_hmove, "Móng 2", TextHight, Linetylescale, "1", "Trên mái", b_Mong2)
        '    mbVeMong.VeMong(x3, y3, b_bmong, b_hmong, b_a, b_bmove, b_hmove, "Móng 3", TextHight, Linetylescale, "1", "Trên mái", b_Mong3)
        '    mbVeMong.VeMong(x4, y4, b_bmong, b_hmong, b_a, b_bmove, b_hmove, "Móng 4", TextHight, Linetylescale, "1", "Trên mái", b_Mong4)
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
        'End If
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
    End Sub


    Private Sub Form4Chan_4Mong_L3n_KG_Load(sender As Object, e As EventArgs) Handles Me.Load
        'cmbLoaiDam.SelectedIndex = 0
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)
        mbVeMong.EraseAll()
        MsgBox("Đã xóa! Tắt bỏ để xem")
    End Sub
End Class