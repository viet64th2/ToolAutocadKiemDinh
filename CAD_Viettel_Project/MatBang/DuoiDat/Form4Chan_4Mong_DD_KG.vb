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
Public Class Form4Chan_4Mong_DD_KG
    Private Sub btnlai_Click(sender As Object, e As EventArgs) Handles btnlai.Click
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
        'Dim Diem_Chen As Point3d = PrPointRes.Value
        Dim TextHight As Double = TiLeChu
        Dim Linetylescale As Double = Tile
        Dim Dimscale As Double = TextHight
        mbVeMong.Ve_Mong_0_4Mong(b_b0mong, b_h0mong, 0, 0, "1", Linetylescale, TextHight)
        mbVeMong.Ve_Cot_Tu_Giac_Update(b_bchancot, b_hchancot, x2, y2, "5", "2", Linetylescale, Dimscale, TextHight, x1, y1, x2, y2, x3, y3, x4, y4, False)
        mbVeMong.VeMong(x1, y1, b_bMong1, b_hMong1, b_a, b_bmove, b_hmove, "Móng M1", TextHight, Linetylescale, "1", "Dưới đất", b_Mong1)
        mbVeMong.VeMong(x2, y2, b_bMong2, b_hMong2, b_a, b_bmove, b_hmove, "Móng M2", TextHight, Linetylescale, "1", "Dưới đất", b_Mong2)
        mbVeMong.VeMong(x3, y3, b_bMong3, b_hMong3, b_a, b_bmove, b_hmove, "Móng M3", TextHight, Linetylescale, "1", "Dưới đất", b_Mong3)
        mbVeMong.VeMong(x4, y4, b_bMong4, b_hMong4, b_a, b_bmove, b_hmove, "Móng M4", TextHight, Linetylescale, "1", "Dưới đất", b_Mong4)
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)
        mbVeMong.EraseAll()
        MsgBox("Đã xóa! Tắt bỏ để xem")
    End Sub
End Class