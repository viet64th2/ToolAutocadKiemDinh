Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class FormTTCcotDayCo
    Dim fc As New mdSPCFunction_TA

    Private Sub cmbLoaiMong1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbLoaiMong1.DrawItem
        Try
            If e.Index <> -1 Then
                e.Graphics.DrawImage(Me.ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub cmbLoaiMong2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbLoaiMong2.DrawItem
        Try
            If e.Index <> -1 Then
                e.Graphics.DrawImage(Me.ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub cmbLoaiMong3_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbLoaiMong4.DrawItem
        Try
            If e.Index <> -1 Then
                e.Graphics.DrawImage(Me.ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub cmbLoaiMong4_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbLoaiMong3.DrawItem
        Try
            If e.Index <> -1 Then
                e.Graphics.DrawImage(Me.ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbLoaiMong1_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles cmbLoaiMong1.MeasureItem
        e.ItemHeight = Me.ImageList1.ImageSize.Height
        e.ItemWidth = Me.ImageList1.ImageSize.Width
    End Sub
    Private Sub cmbLoaiMong2_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles cmbLoaiMong2.MeasureItem
        e.ItemHeight = Me.ImageList1.ImageSize.Height
        e.ItemWidth = Me.ImageList1.ImageSize.Width
    End Sub
    Private Sub cmbLoaiMong3_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles cmbLoaiMong4.MeasureItem
        e.ItemHeight = Me.ImageList1.ImageSize.Height
        e.ItemWidth = Me.ImageList1.ImageSize.Width
    End Sub
    Private Sub cmbLoaiMong4_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles cmbLoaiMong3.MeasureItem
        e.ItemHeight = Me.ImageList1.ImageSize.Height
        e.ItemWidth = Me.ImageList1.ImageSize.Width
    End Sub

    Private Sub FormThongTinChung_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim img(Me.ImageList1.Images.Count - 1)
        For i As Integer = 0 To Me.ImageList1.Images.Count - 1
            img(i) = "Loại móng " & i.ToString
        Next
        Me.cmbLoaiMong1.Items.AddRange(img)
        Me.cmbLoaiMong1.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbLoaiMong1.Width = Me.ImageList1.ImageSize.Width + 30
        Me.cmbLoaiMong1.MaxDropDownItems = Me.ImageList1.Images.Count
        cmbLoaiMong1.SelectedIndex = 0

        Me.cmbLoaiMong2.Items.AddRange(img)
        Me.cmbLoaiMong2.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbLoaiMong2.Width = Me.ImageList1.ImageSize.Width + 30
        Me.cmbLoaiMong2.MaxDropDownItems = Me.ImageList1.Images.Count
        cmbLoaiMong2.SelectedIndex = 0

        Me.cmbLoaiMong3.Items.AddRange(img)
        Me.cmbLoaiMong3.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbLoaiMong3.Width = Me.ImageList1.ImageSize.Width + 30
        Me.cmbLoaiMong3.MaxDropDownItems = Me.ImageList1.Images.Count
        cmbLoaiMong3.SelectedIndex = 0

        Me.cmbLoaiMong4.Items.AddRange(img)
        Me.cmbLoaiMong4.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbLoaiMong4.Width = Me.ImageList1.ImageSize.Width + 30
        Me.cmbLoaiMong4.MaxDropDownItems = Me.ImageList1.Images.Count
        cmbLoaiMong4.SelectedIndex = 0
        'Dim daura As String()
        'daura = mbVeMong.TachChuoi(textdauvao, 1, "")
        'txtbM0.Text = daura(1)
        'txthM0.Text = daura(0)
        'txtbM.Text = daura(1)
        'txthM.Text = daura(0)
        If ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 4 Then
            Me.cbMongNoiChung1.Visible = True
            Me.lbMongNoiChungCot.Visible = True
        Else
            Me.cbMongNoiChung1.Visible = False
            Me.lbMongNoiChungCot.Visible = False
        End If
    End Sub

    'Private Sub cmbLoaiGa_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If cmbLoaiGa.SelectedIndex = 0 Then
    '        CR.Visible = True
    '        CT.Visible = False
    '        CT1.Visible = False
    '    ElseIf cmbLoaiGa.SelectedIndex = 1 Then
    '        CR.Visible = False
    '        CT.Visible = True
    '        CT1.Visible = False
    '    ElseIf cmbLoaiGa.SelectedIndex = 2 Then
    '        CR.Visible = False
    '        CT.Visible = False
    '        CT1.Visible = True
    '    End If
    'End Sub

    Private Sub btnlai_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        TiLeChu = Convert.ToDouble(txtCoChu.Text)
        Try
            If BangTTC.Rows(2).Cells(1).Value = "Dây co" Then
                ThongTinChung.DiaDiem = BangTTC.Rows(0).Cells(1).Value
                ThongTinChung.MaTram = BangTTC.Rows(1).Cells(1).Value
                ThongTinChung.LoaiCot = BangTTC.Rows(2).Cells(1).Value
                ThongTinChung.ChieuCao = BangTTC.Rows(3).Cells(1).Value
                ThongTinChung.TietDienCot = BangTTC.Rows(4).Cells(1).Value
                ThongTinChung.ViTriDat = BangTTC.Rows(5).Cells(1).Value
                ThongTinChung.BeTongMong = BangTTC.Rows(6).Cells(1).Value
                ThongTinChung.SoMong = BangTTC.Rows(7).Cells(1).Value
                ThongTinChung.SoChanCot = BangTTC.Rows(8).Cells(1).Value
                ThongTinChung.ChieuCaoDot = BangTTC.Rows(9).Cells(1).Value
                ThongTinChung.SoTangDay = BangTTC.Rows(10).Cells(1).Value
                ThongTinChung.SoDot = BangTTC.Rows(11).Cells(1).Value
                ThongTinChung.GaChongXoay = BangTTC.Rows(12).Cells(1).Value

                If cmbLoaiMong1.SelectedIndex = 0 Then
                    ThongTinChung.LoaiMong1 = "L1"
                ElseIf cmbLoaiMong1.SelectedIndex = 1 Then
                    ThongTinChung.LoaiMong1 = "L2"
                ElseIf cmbLoaiMong1.SelectedIndex = 2 Then
                    ThongTinChung.LoaiMong1 = "L3"
                End If
                If cmbLoaiMong2.SelectedIndex = 0 Then
                    ThongTinChung.LoaiMong2 = "L1"
                ElseIf cmbLoaiMong2.SelectedIndex = 1 Then
                    ThongTinChung.LoaiMong2 = "L2"
                ElseIf cmbLoaiMong2.SelectedIndex = 2 Then
                    ThongTinChung.LoaiMong2 = "L3"
                End If
                If cmbLoaiMong3.SelectedIndex = 0 Then
                    ThongTinChung.LoaiMong3 = "L1"
                ElseIf cmbLoaiMong3.SelectedIndex = 1 Then
                    ThongTinChung.LoaiMong3 = "L2"
                ElseIf cmbLoaiMong3.SelectedIndex = 2 Then
                    ThongTinChung.LoaiMong3 = "L3"
                End If

                If ThongTinChung.SoMong = "4" Then
                    If cmbLoaiMong4.SelectedIndex = 0 Then
                        ThongTinChung.LoaiMong4 = "L1"
                    ElseIf cmbLoaiMong4.SelectedIndex = 1 Then
                        ThongTinChung.LoaiMong4 = "L2"
                    ElseIf cmbLoaiMong4.SelectedIndex = 2 Then
                        ThongTinChung.LoaiMong4 = "L3"
                    End If
                    b_bMong4 = Convert.ToDouble(txtbM4.Text)
                    b_hMong4 = Convert.ToDouble(txthM4.Text)
                    b_zMong4 = Convert.ToDouble(txtzM4.Text)
                    b_Mong4 = cmbLoaiMong4.SelectedIndex
                End If

                'MsgBox(ThongTinChung.LoaiMong)
                'Luu thong tin bien
                b_b0mong = Convert.ToDouble(txtbM0.Text)
                b_h0mong = Convert.ToDouble(txthM0.Text)
                b_z0mong = Convert.ToDouble(txtzM0.Text)
                b_bmong = Convert.ToDouble(txtbM1.Text)
                b_hmong = Convert.ToDouble(txthM1.Text)
                b_zmong = Convert.ToDouble(txtzM1.Text)
                b_bMong1 = Convert.ToDouble(txtbM1.Text)
                b_hMong1 = Convert.ToDouble(txthM1.Text)
                b_zMong1 = Convert.ToDouble(txtzM1.Text)
                b_bMong2 = Convert.ToDouble(txtbM2.Text)
                b_hMong2 = Convert.ToDouble(txthM2.Text)
                b_zMong2 = Convert.ToDouble(txtzM2.Text)
                b_bMong3 = Convert.ToDouble(txtbM3.Text)
                b_hMong3 = Convert.ToDouble(txthM3.Text)
                b_zMong3 = Convert.ToDouble(txtzM3.Text)

                If b_b0mong = 0 Or b_h0mong = 0 Or b_z0mong = 0 Or b_bmong = 0 Or b_hmong = 0 Or b_zmong = 0 Or b_bMong1 = 0 _
                     Or b_hMong1 = 0 Or b_zMong1 = 0 Or b_bMong2 = 0 Or b_hMong2 = 0 Or b_zMong2 = 0 _
                     Or b_bMong3 = 0 Or b_hMong3 = 0 Or b_zMong3 = 0 Then
                    MsgBox("Kích thước móng chưa chính xác!")
                    Exit Sub
                End If
                'If ThongTinChung.SoMong = 4 Then
                '    b_bMong4 = Convert.ToDouble(txtbM4.Text)
                '    b_hMong4 = Convert.ToDouble(txthM4.Text)
                '    b_zMong4 = Convert.ToDouble(txtzM4.Text)
                'End If
                If txtGocXoay.Text = Nothing Then
                Else
                    GocXoayMatBang = -(Convert.ToDouble(txtGocXoay.Text))
                End If
                If cmbMoneo.SelectedIndex = 1 Then
                    b_d = 100
                Else
                    b_d = 0
                End If
                If ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 4 Then
                    MongNoiChung1 = "."
                    IndexNoiDay1 = -1
                    If cbMongNoiChung1.SelectedIndex = 0 Then
                        MongNoiChung1 = "Móng 1, Móng 2"
                        IndexNoiDay1 = 0
                    ElseIf cbMongNoiChung1.SelectedIndex = 1 Then
                        MongNoiChung1 = "Móng 2, Móng 3"
                        IndexNoiDay1 = 1
                    ElseIf cbMongNoiChung1.SelectedIndex = 2 Then
                        MongNoiChung1 = "Móng 3, Móng 4"
                        IndexNoiDay1 = 2
                    ElseIf cbMongNoiChung1.SelectedIndex = 3 Then
                        MongNoiChung1 = "Móng 4, Móng 1"
                        IndexNoiDay1 = 3
                    End If
                Else

                End If
                'chkBeTongCoMoc
                'Me.txttile.Text = mbVeMong.mbTile(x3, y3) / 100
                Tile = Convert.ToDouble(Me.txttile.Text)
                b_Mong1 = cmbLoaiMong1.SelectedIndex
                b_Mong2 = cmbLoaiMong2.SelectedIndex
                b_Mong3 = cmbLoaiMong3.SelectedIndex
                'If ThongTinChung.SoMong = 4 Then
                '    b_Mong4 = cmbLoaiMong4.SelectedIndex
                'End If
                Dim text As String() = ThongTinChung.TietDienCot.Replace("×", "x").Split("x")
                'txtzM0.Text = text(2)
                ' txtzM.Text = text(2)
                b_a = Convert.ToDouble(text(0)) * 1000
                b_bchancot = b_a
                b_hchancot = b_bchancot
                'Dim TDCotTamGiac As String() = ThongTinChung.TietDienCot.ToString.Split("x")
                'b_a = Convert.ToDouble(TDCotTamGiac(0))
                'ThongTinChung.LoaiGaChongXoay = cmbLoaiGa.Text
                listThongTinChung.Clear()
                listThongTinChung.AddRange({ThongTinChung.DiaDiem, ThongTinChung.MaTram, ThongTinChung.LoaiCot, ThongTinChung.ChieuCao, ThongTinChung.TietDienCot, ThongTinChung.ViTriDat,
                ThongTinChung.BeTongMong, ThongTinChung.SoMong, ThongTinChung.SoChanCot, ThongTinChung.ChieuCaoDot, ThongTinChung.SoTangDay, ThongTinChung.SoDot, ThongTinChung.GaChongXoay, ThongTinChung.LoaiMong1, ThongTinChung.LoaiMong2, ThongTinChung.LoaiMong3, ThongTinChung.LoaiMong4, ThongTinChung.LoaiGaChongXoay})
                If dgvToaDoMong.RowCount = 3 Then
                    x1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
                    y1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
                    z1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

                    x2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
                    y2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
                    z2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

                    x3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
                    y3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
                    z3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000
                ElseIf dgvToaDoMong.RowCount = 4 Then
                    x1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
                    y1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
                    z1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

                    x2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
                    y2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
                    z2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

                    x3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
                    y3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
                    z3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000

                    x4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(1).Value)) * 1000
                    y4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(2).Value)) * 1000
                    z4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(3).Value)) * 1000
                End If
            Else
                ThongTinChung.DiaDiem = BangTTC.Rows(0).Cells(1).Value
                ThongTinChung.MaTram = BangTTC.Rows(1).Cells(1).Value
                ThongTinChung.LoaiCot = BangTTC.Rows(2).Cells(1).Value
                ThongTinChung.ChieuCao = BangTTC.Rows(3).Cells(1).Value
                ThongTinChung.ViTriDat = BangTTC.Rows(6).Cells(1).Value
                ThongTinChung.BeTongMong = BangTTC.Rows(7).Cells(1).Value
                ThongTinChung.SoDot = BangTTC.Rows(8).Cells(1).Value
                ThongTinChung.SoMong = "4"
                ThongTinChung.SoChanCot = "4"
            End If


            MsgBox("Lưu thành công")
        Catch ex As Exception
            MsgBox("Không lưu được")
        End Try
    End Sub

    Private Sub TinhLaiToaDo()
        If Not IsNothing(dgvCanhCanhCanh.Rows(0).Cells(1).Value) And dgvCanhCanhCanh.Rows(0).Cells(1).Value.ToString <> "" Then
            Dim canhtruc1 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(0).Cells(1).Value)
            Dim canhtruc2 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(1).Cells(1).Value)
            Dim canhtruc3 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(2).Cells(1).Value)
            Dim canh1 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(0).Cells(2).Value)
            Dim canh2 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(1).Cells(2).Value)
            Dim canh3 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(2).Cells(2).Value)
            If b_somong = 3 Then
                CanhraTD.CanhCanhraTD_3Mong(canhtruc1, canhtruc2, canhtruc3, canh1, canh2, canh3)
            Else
                Dim canhtruc4 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(3).Cells(1).Value)
                Dim canh4 As Double = Convert.ToDouble(dgvCanhCanhCanh.Rows(3).Cells(2).Value)
                CanhraTD.CanhCanhraTD_4Mong(canhtruc1, canhtruc2, canhtruc3, canhtruc4, canh1, canh2, canh3, canh4)
            End If
        ElseIf dgvCanhCanhCanh.Rows(0).Cells(1).Value.ToString = "" Then
            Dim canhtruc1 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(0).Cells(1).Value)
            Dim canhtruc2 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(1).Cells(1).Value)
            Dim canhtruc3 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(2).Cells(1).Value)
            Dim Goc1 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(0).Cells(2).Value)
            Dim Goc2 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(1).Cells(2).Value)
            Dim Goc3 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(2).Cells(2).Value)
            If b_somong = 3 Then
                CanhraTD.CanhGocraTD_3Mong(canhtruc1, canhtruc2, canhtruc3, Goc1, Goc2, Goc3)
            Else
                Dim canhtruc4 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(3).Cells(1).Value)
                Dim Goc4 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(3).Cells(2).Value)
                CanhraTD.CanhGocraTD_4Mong(canhtruc1, canhtruc2, canhtruc3, canhtruc4, Goc1, Goc2, Goc3, Goc4)
            End If
        End If
        If dgvToaDoMong.RowCount = 3 Then
            x1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
            y1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
            z1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

            x2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
            y2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
            z2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

            x3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
            y3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
            z3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000
        ElseIf dgvToaDoMong.RowCount = 4 Then
            x1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(1).Value)) * 1000
            y1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(2).Value)) * 1000
            z1 = (Convert.ToDouble(dgvToaDoMong.Rows(0).Cells(3).Value)) * 1000

            x2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(1).Value)) * 1000
            y2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(2).Value)) * 1000
            z2 = (Convert.ToDouble(dgvToaDoMong.Rows(1).Cells(3).Value)) * 1000

            x3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(1).Value)) * 1000
            y3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(2).Value)) * 1000
            z3 = (Convert.ToDouble(dgvToaDoMong.Rows(2).Cells(3).Value)) * 1000

            x4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(1).Value)) * 1000
            y4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(2).Value)) * 1000
            z4 = (Convert.ToDouble(dgvToaDoMong.Rows(3).Cells(3).Value)) * 1000
        End If
        If dgvCanhCanhCanh.Rows(0).Cells(1).Value.ToString = "" Then
            If dgvToaDoMong.RowCount = 3 Then
                Dim canhtruc1 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(0).Cells(1).Value)
                Dim canhtruc2 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(1).Cells(1).Value)
                Dim canhtruc3 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(2).Cells(1).Value)

                Dim M1M2 = fc.TinhKhoangCach(x1, y1, x2, y2) / 1000
                Dim M2M3 = fc.TinhKhoangCach(x3, y3, x2, y2) / 1000
                Dim M1M3 = fc.TinhKhoangCach(x3, y3, x1, y1) / 1000
                dgvCanhCanhCanh.Rows(0).Cells(1).Value = canhtruc1
                dgvCanhCanhCanh.Rows(1).Cells(1).Value = canhtruc2
                dgvCanhCanhCanh.Rows(2).Cells(1).Value = canhtruc3
                dgvCanhCanhCanh.Rows(0).Cells(2).Value = M1M2
                dgvCanhCanhCanh.Rows(1).Cells(2).Value = M2M3
                dgvCanhCanhCanh.Rows(2).Cells(2).Value = M1M3
            ElseIf dgvToaDoMong.RowCount = 4 Then
                Dim M3M4 = fc.TinhKhoangCach(x3, y3, x4, y4) / 1000
                Dim canhtruc4 As Double = Convert.ToDouble(dgvCanhGocCanh.Rows(3).Cells(1).Value)
                dgvCanhCanhCanh.Rows(3).Cells(1).Value = canhtruc4
                dgvCanhCanhCanh.Rows(3).Cells(2).Value = M3M4
            End If
        End If
    End Sub
    Private Sub btnTinhLaiToaDo_Click(sender As Object, e As EventArgs) Handles btnTinhLaiToaDo.Click
        TinhLaiToaDo()

        frmTTC.txttile.Text = Math.Round((mbVeMong.mbTile(x3, y3) / 100), 3)
        frmTTC.txtCoChu.Text = Math.Round((mbVeMong.mbTile(x3, y3) / 3), 3)
    End Sub

    Private Sub dgvToaDoMong_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvToaDoMong.CellContentClick
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        If e.ColumnIndex = 4 Then
            'MsgBox("Rows:" + e.RowIndex.ToString + "column:" + e.ColumnIndex.ToString)
            Try
                Dim peo As PromptEntityOptions = New PromptEntityOptions(vbLf & "Chọn đường thẳng cần tìm tạo độ")
                Dim pdr As PromptEntityResult = ed.GetEntity(peo)
                Dim Diem = TimToaDo(pdr.ObjectId)
                dgvToaDoMong.Rows(e.RowIndex).Cells(1).Value = Math.Round(Diem.X / 1000, 2)
                dgvToaDoMong.Rows(e.RowIndex).Cells(2).Value = Math.Round(Diem.Y / 1000, 2)
            Catch ex As Exception
                MsgBox("Không có đối tượng")
            End Try

        End If
    End Sub
    Public Shared Function TimToaDo(ID As ObjectId) As Point3d
        Dim Point As New Point3d
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = doc.TransactionManager.StartTransaction
        Dim DuongThang As New Line()
        Using tr
            Dim bt As BlockTable = CType(tr.GetObject(db.BlockTableId, OpenMode.ForRead), BlockTable)
            Dim btr As BlockTableRecord = CType(tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)
            DuongThang = tr.GetObject(ID, OpenMode.ForWrite)
            tr.Commit()
        End Using

        If (DuongThang.StartPoint.X = 0) And (DuongThang.StartPoint.Y = 0) Then
            Point = DuongThang.EndPoint
        Else
            Point = DuongThang.StartPoint
        End If
        Return Point
    End Function


    Private Sub cmbLoaiMong1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoaiMong1.SelectedIndexChanged
        If cmbLoaiMong1.SelectedIndex = 2 Then
            cmbMoneo.Visible = True
            lbSoMocNeo.Visible = True
        End If
    End Sub

    Private Sub cmbLoaiMong2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoaiMong2.SelectedIndexChanged
        If cmbLoaiMong2.SelectedIndex = 2 Then
            cmbMoneo.Visible = True
            lbSoMocNeo.Visible = True
        End If
    End Sub

    Private Sub cmbLoaiMong3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoaiMong3.SelectedIndexChanged
        If cmbLoaiMong3.SelectedIndex = 2 Then
            cmbMoneo.Visible = True
            lbSoMocNeo.Visible = True
        End If
    End Sub

    Private Sub cmbLoaiMong4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoaiMong4.SelectedIndexChanged
        If cmbLoaiMong4.SelectedIndex = 2 Then
            cmbMoneo.Visible = True
            lbSoMocNeo.Visible = True
        End If
    End Sub
End Class