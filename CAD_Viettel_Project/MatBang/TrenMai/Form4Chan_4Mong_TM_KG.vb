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

        '4chan 4mong tren mai dam ngang
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor

        Dim TextHight As Double = TiLeChu
        Dim Linetylescale As Double = Tile
        Dim Dimscale As Double = TextHight
        mbVeMong.Ve_Mong_0trenmai(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
        mbVeMong.Ve_Cot_Tu_Giac(b_bchancot, b_hchancot, b_d, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, True)
        b_bmove = 0
        b_hmove = 0
        mbVeMong.VeMong(x1, y1, b_bMong1, b_hMong1, b_bmove, b_hmove, b_a, "Móng 1", TextHight, Linetylescale, "1", "Trên mái", b_Mong1)
        mbVeMong.VeMong(x2, y2, b_bMong2, b_hMong2, b_bmove, b_hmove, b_a, "Móng 2", TextHight, Linetylescale, "1", "Trên mái", b_Mong2)
        mbVeMong.VeMong(x3, y3, b_bMong3, b_hMong3, b_bmove, b_hmove, b_a, "Móng 3", TextHight, Linetylescale, "1", "Trên mái", b_Mong3)
        mbVeMong.VeMong(x4, y4, b_bMong4, b_hMong4, b_bmove, b_hmove, b_a, "Móng 4", TextHight, Linetylescale, "1", "Trên mái", b_Mong4)

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