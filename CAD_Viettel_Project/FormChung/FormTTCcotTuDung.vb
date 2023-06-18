Public Class FormTTCcotTuDung
    Dim intRowIndex As Integer = -1




    Private Sub btnlai_Click(sender As Object, e As EventArgs) Handles btnlai.Click
        TiLeChu = Convert.ToDouble(txtCoChu.Text)
        ThongTinChung.DiaDiem = BangTTC.Rows(0).Cells(1).Value
        ThongTinChung.MaTram = BangTTC.Rows(1).Cells(1).Value
        ThongTinChung.LoaiCot = BangTTC.Rows(2).Cells(1).Value
        ThongTinChung.ChieuCao = BangTTC.Rows(3).Cells(1).Value
        ThongTinChung.ViTriDat = BangTTC.Rows(6).Cells(1).Value
        ThongTinChung.BeTongMong = BangTTC.Rows(7).Cells(1).Value
        ThongTinChung.SoDot = BangTTC.Rows(8).Cells(1).Value
        ThongTinChung.SoMong = "4"
        ThongTinChung.SoChanCot = "4"
        '
        x1 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y1 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z1 = (0) * 1000

        x2 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y2 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z2 = (0) * 1000

        x3 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y3 = (-ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z3 = (0) * 1000

        x4 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        y4 = (ThongTinChung.KichThuocChanCot.ToString.Split("x")(0) / 2) * 1000
        z4 = (0) * 1000
        frmTTC_TuDung.dgvToaDoMong.Rows.Clear()
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M1", x1 / 1000, y1 / 1000, z1 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M2", x2 / 1000, y2 / 1000, z2 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M3", x3 / 1000, y3 / 1000, z3 / 1000})
        frmTTC_TuDung.dgvToaDoMong.Rows.Add({"Móng M4", x4 / 1000, y4 / 1000, z4 / 1000})
        '
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
        b_bMong4 = Convert.ToDouble(txtbM4.Text)
        b_hMong4 = Convert.ToDouble(txthM4.Text)
        b_zMong4 = Convert.ToDouble(txtzM4.Text)



        MsgBox("Lưu thành công")
    End Sub
#Region "FACE"

    Private Sub FormTTCcotTuDung_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbMatCat.Visible = False
        Panel1.Width = frmTTC_TuDung.Width - 50
    End Sub

    Private Sub DLM_Click(sender As Object, e As EventArgs) Handles DLM.Click
        setFACE(sender)

    End Sub

    Private Sub XMA_Click(sender As Object, e As EventArgs) Handles XMA.Click
        setFACE(sender)

    End Sub

    Private Sub XMA_M_Click(sender As Object, e As EventArgs) Handles XMA_M.Click
        setFACE(sender)

    End Sub

    Private Sub K1_M1_Click(sender As Object, e As EventArgs) Handles K1_M1.Click
        setFACE(sender)

    End Sub

    Private Sub K2_Click(sender As Object, e As EventArgs) Handles K2.Click
        setFACE(sender)

    End Sub
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        tbMatCat.Visible = False
        Panel1.Width = frmTTC_TuDung.Width
    End Sub

#End Region
#Region "PLAN"
    Private Sub PLX_Click(sender As Object, e As EventArgs) Handles PLX.Click
        setPLAN(sender)
    End Sub

    Private Sub PL3S_Click(sender As Object, e As EventArgs) Handles PL3S.Click
        setPLAN(sender)

    End Sub

    Private Sub PL2A_Click(sender As Object, e As EventArgs) Handles PL2A.Click
        setPLAN(sender)

    End Sub

    Private Sub PLD_Click(sender As Object, e As EventArgs) Handles PLD.Click
        setPLAN(sender)

    End Sub
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        tbMatCat.Visible = False
        Panel1.Width = frmTTC_TuDung.Width
    End Sub
#End Region
    Public Sub setFACE(sender As Object)
        BangChieuCaoDot.Rows(intRowIndex).Cells("clDoc").Value = sender.Name.ToString.Replace("_", ",")
        tbMatCat.Visible = False
        Panel1.Width = frmTTC_TuDung.Width - 50
    End Sub
    Public Sub setPLAN(sender As Object)
        BangChieuCaoDot.Rows(intRowIndex).Cells("clNgang").Value = sender.Name.ToString
        tbMatCat.Visible = False
        Panel1.Width = frmTTC_TuDung.Width - 50

    End Sub

    Private Sub KMG_Click(sender As Object, e As EventArgs) Handles KMG.Click
        setFACE(sender)
    End Sub

    Private Sub btnThemDot_Click(sender As Object, e As EventArgs) Handles btnThemDot.Click
        BangChieuCaoDot.RowCount = BangChieuCaoDot.RowCount + 1
        For r = BangChieuCaoDot.RowCount - 1 To 1 Step -1
            For c = 0 To BangChieuCaoDot.ColumnCount - 1
                BangChieuCaoDot.Rows(r).Cells(c).Value = BangChieuCaoDot.Rows(r - 1).Cells(c).Value
            Next
        Next
        BangChieuCaoDot.Rows(0).Cells(0).Value = "Đốt" + BangChieuCaoDot.RowCount.ToString
    End Sub

    Private Sub BangChieuCaoDot_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BangChieuCaoDot.CellMouseClick
        intRowIndex = e.RowIndex
        If intRowIndex >= 0 Then
            If e.ColumnIndex = 4 Then
                tbMatCat.Visible = True
                Panel1.Width = frmTTC_TuDung.Width - tbMatCat.Width
                tbMatCat.SelectTab(0)
            ElseIf e.ColumnIndex = 5 Then
                tbMatCat.Visible = True
                Panel1.Width = frmTTC_TuDung.Width - tbMatCat.Width

                tbMatCat.SelectTab(1)
            End If
        End If
    End Sub

    Private Sub btnXoaDot_Click(sender As Object, e As EventArgs) Handles btnXoaDot.Click
        BangChieuCaoDot.Rows.RemoveAt(0)
    End Sub
End Class