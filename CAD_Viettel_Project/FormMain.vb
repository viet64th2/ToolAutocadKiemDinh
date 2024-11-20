Imports System.IO
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
Imports System
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports Autodesk.AutoCAD.ApplicationServices.DocumentExtension
Imports Autodesk.AutoCAD.ApplicationServices.Document
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports Autodesk.AutoCAD.Colors
Imports Autodesk.AutoCAD.PlottingServices
Imports System.Runtime.InteropServices
' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Imports Microsoft.WindowsAPICodePack.Dialogs
Public Class FormMain

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        frmSetting.Show()
    End Sub

    Private Sub bangtinh_Click(sender As Object, e As EventArgs) Handles bangtinh.Click

        slider.Left = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Left
        slider.Width = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Width
        If ThongTinChung.LoaiCot = ("Dây co") Then
            ShowForm(frmTTC)
        Else
            ShowForm(frmTTC_TuDung)
        End If

    End Sub

    Private Sub bangvatlieu_Click(sender As Object, e As EventArgs)

        slider.Left = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Left
        slider.Width = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Width

    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click

        If menusave.Visible = False Then
            menusave.Visible = True
        Else
            menusave.Visible = False
        End If

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
        Lib_Drawing.ZoomExtent()

    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShowForm(frmTTC)

    End Sub

    Private Sub btnTTC_Click(sender As Object, e As EventArgs) Handles btnTTC.Click
        If menusave.Visible = False Then
            menusave.Visible = True
        Else
            menusave.Visible = False
        End If
        ShowForm(frmTTC)
    End Sub
    Private Sub ShowForm(frm As Form)
        Me.CenterToScreen()
        frm.MdiParent = Me
        frm33d_DD_KG.Hide()
        frmTTC.Hide()
        frm.Show()
        frm.Left = 0
        frm.Top = 0
        frm.Width = Me.Width - 5
        frm.Height = Me.Height - Panel1.Height - Panel12.Height - 5
    End Sub

    Private Sub btnOpenDA_Click(sender As Object, e As EventArgs) Handles btnOpenDA.Click
        Dim dlg As New CommonOpenFileDialog()
        dlg.IsFolderPicker = True
        Dim DefaultProjectFolder As String = ""
        Dim TenTram As String = ""
        DefaultProjectFolder = ReadText("C:\ProgramData\PathSupport.txt")
        dlg.DefaultDirectory = DefaultProjectFolder.ToString

        If dlg.ShowDialog() = DialogResult.OK Then
            TaoMoiTram(dlg.FileName)
            'DefaultProjectFolder = dlg.FileName
            'WirteText(dlg.FileName, "C:\ProgramData\PathSupport.txt")
            'Dim List() As String = DefaultProjectFolder.Split("\")
            'TenTram = List(List.Length - 1)
            ''Hiển thị tên trạm
            'Dim list2() As String = TenTram.Split("_")
            'lbTenTram.Visible = True
            'lbTenTram.Text = list2(0).ToString
            'DuongDanData = dlg.FileName & "\Data" & TenTram
            'If (Not System.IO.File.Exists(DefaultProjectFolder & "\Data" & TenTram & "\TABLEBia.txt")) Then
            '    MsgBox("Không tìm thấy data thông tin bìa!")
            '    Exit Sub
            'End If
            'Dim listThongTinChung = getText(DefaultProjectFolder & "\Data" & TenTram & "\TABLEBia.txt")
            'Dim li As List(Of String) = LayThongTinChung(listThongTinChung)
            'b_somong = Convert.ToInt32(ThongTinChung.SoMong)
            ''lấy móng nối chung
            'If ThongTinChung.SoMong = 4 And ThongTinChung.SoChanCot = 3 Then
            '    If File.Exists(DefaultProjectFolder & "\Data" & TenTram & "\MongNoiChung.txt") Then
            '        ThongTinChung.MongNoiChung = ReadText(DefaultProjectFolder & "\Data" & TenTram & "\MongNoiChung.txt")
            '    End If
            'End If
            'If File.Exists(DefaultProjectFolder & "\Data" & TenTram & "\NoiDayCo.txt") Then
            '    ThongTinChung.NoiDayCo = ReadText(DefaultProjectFolder & "\Data" & TenTram & "\NoiDayCo.txt")

            'End If
            '' DuongDanData + "\" + "NoiDayCo.txt"
            'If ThongTinChung.LoaiCot = ("Dây co") Then
            '    insertDataCotDayCo()
            'Else
            '    ShowForm(frmTTC_TuDung)
            '    insertDataCotTuDung()
            'End If

            'If Not System.IO.Directory.Exists(dlg.FileName & "\Data" & TenTram) Then
            '    MsgBox("Thư mục dự án không hợp lệ!")
            '    Exit Sub
            'End If
        ElseIf DialogResult.Cancel Then
            Exit Sub
        End If
    End Sub

    Private Sub btnMatBang_Click(sender As Object, e As EventArgs) Handles btnMatBang.Click
        Try
            mbVeMong.EraseAll()
            slider.Left = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Left
            slider.Width = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Width
            If ThongTinChung.LoaiCot = "Dây co" Then
                If ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 3 And ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frm33d_DD_KG)
                ElseIf ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 3 And ThongTinChung.GaChongXoay <> "" Then
                    ShowForm(frm33d_DD_CG)
                ElseIf ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frm34d_DD_KG)
                ElseIf ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 3 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay <> "" Then
                    ShowForm(frm34d_DD_CG)
                ElseIf ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 4 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frm44d_DD_KG)
                ElseIf ThongTinChung.ViTriDat = "Dưới đất" And ThongTinChung.SoChanCot = 4 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay <> "" Then
                    ShowForm(frm44d_DD_CG)
                ElseIf ThongTinChung.ViTriDat = "Trên mái" And ThongTinChung.SoChanCot = 4 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frm44d_TM_KG)
                ElseIf ThongTinChung.ViTriDat = "Trên mái" And ThongTinChung.SoChanCot = 4 And ThongTinChung.SoMong = 4 And ThongTinChung.GaChongXoay <> "" Then
                    ShowForm(frm44d_TM_CG)
                End If
            Else
                ShowForm(frmMB_TuDung)
            End If

        Catch ex As Autodesk.AutoCAD.Runtime.Exception

        End Try
    End Sub

    Private Sub btnMatDung_Click(sender As Object, e As EventArgs) Handles btnMatDung.Click

        slider.Left = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Left
        slider.Width = DirectCast(sender, Bunifu.Framework.UI.BunifuFlatButton).Width
        If ThongTinChung.LoaiCot = "Tự đứng" Then
            ShowForm(frmMD_TuDung)
        Else
            If ThongTinChung.ViTriDat = "Dưới đất" Then
                If ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frmMD_34d_L3_KG)
                Else
                    ShowForm(frmMD_34d_L3_CG)
                End If
            Else
                If ThongTinChung.GaChongXoay = "" Then
                    ShowForm(frmMD_34d_L3_Trenmai_KG)
                Else
                    ShowForm(frmMD_34d_l3_Trenmai_CG)
                End If
            End If
        End If


    End Sub

    Private Sub btnXuatBaoCao_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCao.Click
        Dim frmFormPrint As New FormPrint
        frmFormPrint.Show()
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        If MsgBox("Bạn có muốn lưu lại thông tin của trạm này không?", vbYesNo) = vbYes Then
            If ThongTinChung.LoaiCot = "Dây co" Then
                SaveFile(frmTTC.BangTTC, "TableBia")
                SaveFile(frmTTC.BangChieuCaoDot, "TABLEMstower")
                SaveFile(frmTTC.dgvToaDoMong, "TABLECot")
                SaveFile(frmTTC.dgvCaoDoDayCo, "TABLECaoDoDayCo")
                SaveFile(frmTTC.dgvCanhCanhCanh, "TABLECanhCanhCanh")
                SaveFile(frmTTC.dgvCanhGocCanh, "TABLECanhGocCanh")
                WirteText(ThongTinChung.NoiDayCo, DuongDanData + "\" + "NoiDayCo.txt")
                SaveFile(frmTTC.dgvToaDoMongMstower, "TABLEToaDoMstower")
            Else
                SaveFile(frmTTC_TuDung.BangTTC, "TableBia")
                SaveFile(frmTTC_TuDung.BangChieuCaoDot, "TABLEMstower")
            End If
      
        Else
            MsgBox("False!")
        End If


    End Sub

    Private Sub btn_TaoMoi_Click(sender As Object, e As EventArgs) Handles btn_TaoMoi.Click
        Dim frm As New Form_ThemMoi
        Dim dlg = frm.ShowDialog
        If dlg = DialogResult.OK Then
            TaoMoiTram(ThongTinChung.DuongDanLuu)
        End If
    End Sub
End Class
