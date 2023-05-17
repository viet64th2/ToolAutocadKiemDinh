Public Class FormSetting
    Dim fcSPC As New mdSPCFunction_TA
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtDuongDan.Text <> "" Then
            If System.IO.Directory.Exists(txtDuongDan.Text) Then
                DuongDanThuVien = txtDuongDan.Text
                fcSPC.WirteText(DuongDanThuVien, "C:\ProgramData\PathThuVien.txt")
                Me.Close()
            End If
        Else
            MsgBox("Không được để trống thư viện!")
        End If

    End Sub

    Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        txtDuongDan.Text = DuongDanThuVien
    End Sub
End Class