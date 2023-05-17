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
Imports Autodesk.AutoCAD.PlottingServices
Imports System.Runtime.InteropServices
Public Class FormMD_3Chan_4Mong_L3_CG
    Public Sub setDauVao()

        If frmTTC.cmbLoaiMong1.SelectedIndex = 0 Then
            ThongTinChung.LoaiMong1 = "L1"
        ElseIf frmTTC.cmbLoaiMong1.SelectedIndex = 1 Then
            ThongTinChung.LoaiMong1 = "L2"
        ElseIf frmTTC.cmbLoaiMong1.SelectedIndex = 2 Then
            ThongTinChung.LoaiMong1 = "L3"
        End If


    End Sub

    Private Sub btnlai_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        clsMatDung.EraseAll()
        setDauVao()
        Dim listViTriGaChongXay As New List(Of Integer)
        If frmTTC.dgvCaoDoDayCo.RowCount > 0 Then
            For i = 0 To frmTTC.dgvCaoDoDayCo.RowCount - 1
                If frmTTC.dgvCaoDoDayCo.Rows(i).Cells("GCX").Value <> "" Then
                    listViTriGaChongXay.Add(i)
                End If
            Next
        End If
        Dim ViTriCoGa As Integer = 2
        Dim SoTangDay As Integer = 3
        Dim listCaoDo As IList(Of Double) = New List(Of Double)
        For i As Integer = 0 To frmTTC.dgvCaoDoDayCo.RowCount - 1
            listCaoDo.Add(Convert.ToDouble(frmTTC.dgvCaoDoDayCo.Rows(i).Cells(1).Value))
        Next
        Dim LoaiDot As New List(Of String)
        For i As Integer = 0 To frmTTC.BangChieuCaoDot.RowCount - 1
            LoaiDot.Add(Convert.ToString(frmTTC.BangChieuCaoDot.Rows(i).Cells(3).Value))
        Next
        'Tinh be rong ngang
        Dim rongMB As Single = Math.Sqrt(((x1 - x2) ^ 2) + ((y1 - y2) ^ 2))
        Dim daiMB As Single = Math.Sqrt(((x2 - x3) ^ 2) + ((y2 - y3) ^ 2))
        Dim c As Double = ThongTinChung.ChieuCao
        If cmbmat.Text = "X-Z" Then
            If ThongTinChung.SoChanCot <> 3 Then
                clsMatDung.MatX_Z_CoGa(c, b_a, rongMB / 2, rongMB / 2, listCaoDo, LoaiDot, b_zMong1, b_zMong2, b_bMong1, b_bMong2, b_z0mong, b_b0mong, ThongTinChung.LoaiMong1, z1, z2, ThongTinChung.ViTriDat, listViTriGaChongXay, frmTTC.dgvCaoDoDayCo.RowCount)
                clsMatDung.VeCaoDo(listCaoDo, 2, 3, z1, z3, rongMB / 2, rongMB / 2, b_hmong, b_hmong, 0, TiLeChu * 2)
                clsMatDung.VeCaoDoDot(rongMB / 2, TiLeChu * 2)

            Else
                clsMatDung.MatX_Z_CoGa(c, b_a, daiMB / 2, daiMB / 2, listCaoDo, LoaiDot, b_zMong1, b_zMong2, b_bMong1, b_bMong2, b_z0mong, b_b0mong, ThongTinChung.LoaiMong1, z1, z2, ThongTinChung.ViTriDat, listViTriGaChongXay, frmTTC.dgvCaoDoDayCo.RowCount)
                clsMatDung.VeCaoDo(listCaoDo, 2, 3, z2, z3, daiMB / 2, daiMB / 2, b_hmong, b_hmong, 0, TiLeChu * 2)
                clsMatDung.VeCaoDoDot(rongMB / 2, TiLeChu * 2)

            End If
        ElseIf cmbmat.Text = "Y-Z" Then
            clsMatDung.MatY_Z_CoGa(c, b_a, daiMB / 2, daiMB / 2, listCaoDo, LoaiDot, b_zMong2, b_zMong3, b_bMong2, b_bMong3, b_z0mong, b_b0mong, ThongTinChung.LoaiMong1, z2, z3, ThongTinChung.ViTriDat, listViTriGaChongXay, frmTTC.dgvCaoDoDayCo.RowCount)
            clsMatDung.VeCaoDo(listCaoDo, 2, 3, z2, z3, daiMB / 2, daiMB / 2, b_hmong, b_hmong, 0, TiLeChu * 2)
            clsMatDung.VeCaoDoDot(daiMB / 2, TiLeChu * 2)

        End If
        MsgBox("Đã vẽ xong! Tắt bỏ để xem")
    End Sub
End Class