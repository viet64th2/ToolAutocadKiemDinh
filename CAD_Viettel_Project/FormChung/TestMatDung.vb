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
Public Class TestMatDung

    Private Sub btnmd_Click(sender As Object, e As EventArgs) Handles btnmd.Click
        Dim H() As Double
        Dim Soroucout As Integer = dgv.RowCount - 1

        For i = Soroucout To 0 Step -1
            H(i) = Convert.ToDouble(dgv.Rows(i).Cells(1).Value) * 1000
        Next
    End Sub

    Private Sub btnmb_Click(sender As Object, e As EventArgs) Handles btnmb.Click

    End Sub
End Class