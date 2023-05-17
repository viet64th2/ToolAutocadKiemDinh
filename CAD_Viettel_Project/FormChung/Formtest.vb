Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class Formtest
    Private Sub btnmb_Click(sender As Object, e As EventArgs) Handles btnmb.Click
        Dim b1, b2, b3, b4 As Double
        b1 = Convert.ToDouble(txtrong.Text) * 1000
        b2 = Convert.ToDouble(txtrong.Text) * 1000
        b3 = Convert.ToDouble(txtrong.Text) * 1000
        b4 = Convert.ToDouble(txtrong.Text) * 1000
        Dim i As Integer = dgv.RowCount - 1
        Dim Dinh As Double
        Dinh = Convert.ToDouble(dgv.Rows(i).Cells(1).Value) * 1000
        Dim Day As Double
        Day = Convert.ToDouble(dgv.Rows(0).Cells(1).Value) * 1000
        'MsgBox(Dinh.ToString)
        'MsgBox(Day.ToString)
        'MsgBox(b.ToString)
        Cot_TuDung.Ve_MB_TuDung(Dinh, Day, b1, b2, b3, b4)
        Dim toa_do(3) As Point2d
        toa_do(0) = New Point2d(-Dinh / 2, -Dinh / 2)
        toa_do(1) = New Point2d(-Dinh / 2, Dinh / 2)
        toa_do(2) = New Point2d(Dinh / 2, Dinh / 2)
        toa_do(3) = New Point2d(Dinh / 2, -Dinh / 2)
        Lib_Drawing.CreateNewPolyline(toa_do, True)

        Me.Close()
    End Sub

    Private Sub Formtest_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim i As Integer
        dgv.RowCount = 3
        For i = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells(0).Value = i + 1
        Next
        dgv.Rows(0).Cells(1).Value = 27
        dgv.Rows(1).Cells(1).Value = 20
        dgv.Rows(2).Cells(1).Value = 10

        dgv.Rows(0).Cells(2).Value = 0
        dgv.Rows(1).Cells(2).Value = 3.6
        dgv.Rows(2).Cells(2).Value = 3

    End Sub

    Private Sub btnmd_Click(sender As Object, e As EventArgs) Handles btnmd.Click

    End Sub
End Class