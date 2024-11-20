
Imports MS.WindowsAPICodePack.Internal

Public Class Form_ThemMoi
    Private Sub btn_Taomoi_Click(sender As Object, e As EventArgs) Handles btn_Taomoi.Click
        Dim dlg As New FolderBrowserDialog()
        dlg.ShowDialog()
        If DialogResult.OK Then
            'Tạo Thư mục chứa
            Dim path As String = dlg.SelectedPath
            If txtMaTram.Text <> "" And txtDiaDiem.Text <> "" And txtChieuCaoCot.Text <> "" And txtSoMong.Text <> "" Then

                ThongTinChung = New clsThongTinChung
                ThongTinChung.MaTram = txtMaTram.Text
                ThongTinChung.DiaDiem = txtDiaDiem.Text
                ThongTinChung.LoaiCot = txtLoaiCot.Text
                ThongTinChung.ChieuCao = txtChieuCaoCot.Text
                ThongTinChung.ChieuCaoDot = txtChieuCaoDot.Text
                ThongTinChung.ViTriDat = txtViTriDat.Text
                ThongTinChung.SoDot = txtSoDot.Text
                ThongTinChung.SoMong = txtSoMong.Text
                ThongTinChung.SoChanCot = txtSoChan.Text
                ThongTinChung.TietDienCot = txtTietDienCot.Text
                ThongTinChung.SoTangDay = txtSoTangDay.Text
                ThongTinChung.GaChongXoay = txtGaChongXoay.Text
                ThongTinChung.DuongDanLuu = path + "\" + ThongTinChung.MaTram + "_" + ThongTinChung.DiaDiem

                System.IO.Directory.CreateDirectory(ThongTinChung.DuongDanLuu)
                System.IO.Directory.CreateDirectory(ThongTinChung.DuongDanLuu + "\" + ThongTinChung.MaTram + "_" + ThongTinChung.DiaDiem)
                Dim dataPath As String = ThongTinChung.DuongDanLuu + "\Data" + ThongTinChung.MaTram + "_" + ThongTinChung.DiaDiem
                System.IO.Directory.CreateDirectory(dataPath)

                ' Lấy thông tin từ các textbox
                Dim MaTram As String = txtMaTram.Text
                Dim DiaDiem As String = txtDiaDiem.Text
                Dim LoaiCot As String = txtLoaiCot.Text
                Dim ChieuCaoCot As String = txtChieuCaoCot.Text
                Dim ChieuCaoDot As String = txtChieuCaoDot.Text
                Dim ViTriDat As String = txtViTriDat.Text
                Dim SoDot As String = txtSoDot.Text
                Dim SoMong As String = txtSoMong.Text
                Dim SoChanCot As String = txtSoChan.Text
                Dim TietDienCot As String = txtTietDienCot.Text
                Dim SoTangDay As String = txtSoTangDay.Text
                Dim GaChongXoay As String = txtGaChongXoay.Text
                ' Tạo nội dung file
                Dim content As String = $"@Địa điểm:_{DiaDiem}" & vbCrLf &
                            $"@Mã trạm:_{MaTram}" & vbCrLf &
                            $"@Loại cột:_{LoaiCot}" & vbCrLf &
                            $"@Chiều cao cột (m):_{ChieuCaoCot}" & vbCrLf &
                            $"@Kích thước thân cột:_{TietDienCot}" & vbCrLf &
                            $"@Vị trí đặt:_{ViTriDat}" & vbCrLf &
                            $"@Bê tông móng:_B20" & vbCrLf &
                            $"@Số móng co:_{SoMong}" & vbCrLf &
                            $"@Số chân cột:_{SoChanCot}" & vbCrLf &
                            $"@Chiều cao đốt (m):_{ChieuCaoDot}" & vbCrLf &
                            $"@Số tầng dây co:_{SoTangDay}" & vbCrLf &
                            $"@Số đốt:_{SoDot}" & vbCrLf &
                            $"@Vị trí có gá cx (Tầng)_{GaChongXoay}"

                ' Tạo file văn bản
                Dim filePath As String = dataPath + "\" + "TABLEBia.txt"
                System.IO.File.WriteAllText(filePath, content)


                'TABLEMsTower
                Dim result As New Text.StringBuilder()
                For i As Integer = 1 To ThongTinChung.SoDot
                    ' Các đoạn còn lại không có "CT"
                    result.AppendLine($"@{i}_{ChieuCaoCot}_0.4286_DRM_16-M18_0_0_7_D42x3.9_D12")
                Next
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLEMsTower.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))

                'TABLECot
                result = New Text.StringBuilder()
                For i As Integer = 1 To SoMong
                    ' Sinh tọa độ giả lập cho móng (có thể thay đổi theo yêu cầu)
                    Dim x As Double = 0
                    Dim y As Double = 0
                    Dim z As Integer = 0

                    ' Thêm thông tin móng vào nội dung
                    result.AppendLine($"@Móng M{i}_{x}_{y}_{z}")
                Next
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLECot.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLEToaDoMstower.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))
                'TABLECaoDoDayCo
                result = New Text.StringBuilder()
                For i As Integer = 1 To SoTangDay
                    ' Sinh tọa độ giả lập cho móng (có thể thay đổi theo yêu cầu)
                    Dim x As Double = 0

                    ' Thêm thông tin móng vào nội dung
                    result.AppendLine($"@Tầngco{i}_{x}__")
                Next
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLECaoDoDayCo.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))

                'TABLECanhCanhCanh
                result = New Text.StringBuilder()
                For i As Integer = 1 To SoMong
                    ' Sinh tọa độ giả lập cho móng (có thể thay đổi theo yêu cầu)
                    Dim x As Double = 0

                    ' Thêm thông tin móng vào nội dung
                    result.AppendLine($"@{i}_{x}_{x}_{x}")
                Next
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLECanhCanhCanh.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))

                'TABLECanhGocCanh
                result = New Text.StringBuilder()
                For i As Integer = 1 To SoMong
                    ' Sinh tọa độ giả lập cho móng (có thể thay đổi theo yêu cầu)
                    Dim x As Double = 0

                    ' Thêm thông tin móng vào nội dung
                    result.AppendLine($"@{i}_{x}_{x}")
                Next
                ' Tạo file văn bản
                filePath = dataPath + "\" + "TABLECanhGocCanh.txt"
                System.IO.File.WriteAllText(filePath, result.ToString().Replace(vbCrLf, String.Empty))

                DialogResult = DialogResult.OK
                Me.Close()
            End If
        ElseIf DialogResult.Cancel Then
            Exit Sub
        ElseIf dlg.SelectedPath = "" Then
            Exit Sub
        End If

    End Sub
End Class