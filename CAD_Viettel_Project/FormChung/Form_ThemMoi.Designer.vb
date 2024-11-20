<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ThemMoi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ThemMoi))
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txt_DK_KhoaCap = New System.Windows.Forms.ComboBox()
        Me.txtSoChan = New System.Windows.Forms.ComboBox()
        Me.txtChieuCaoCot = New System.Windows.Forms.ComboBox()
        Me.txtLoaiCot = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtChieuCaoDot = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSoTangDay = New System.Windows.Forms.ComboBox()
        Me.txtSoMong = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtViTriDat = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTietDienCot = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDiaDiem = New System.Windows.Forms.TextBox()
        Me.txtMaTram = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.la = New System.Windows.Forms.Label()
        Me.txtGaChongXoay = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSoDot = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_Taomoi = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 436)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 13)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "Khóa cáp:"
        '
        'txt_DK_KhoaCap
        '
        Me.txt_DK_KhoaCap.FormattingEnabled = True
        Me.txt_DK_KhoaCap.Items.AddRange(New Object() {"fi 8", "fi 10", "fi 12", "fi 20", "fi 22", "fi24", "fi26", "fi30"})
        Me.txt_DK_KhoaCap.Location = New System.Drawing.Point(100, 430)
        Me.txt_DK_KhoaCap.Name = "txt_DK_KhoaCap"
        Me.txt_DK_KhoaCap.Size = New System.Drawing.Size(103, 21)
        Me.txt_DK_KhoaCap.TabIndex = 81
        '
        'txtSoChan
        '
        Me.txtSoChan.FormattingEnabled = True
        Me.txtSoChan.Items.AddRange(New Object() {"3", "4"})
        Me.txtSoChan.Location = New System.Drawing.Point(325, 378)
        Me.txtSoChan.Name = "txtSoChan"
        Me.txtSoChan.Size = New System.Drawing.Size(123, 21)
        Me.txtSoChan.TabIndex = 77
        '
        'txtChieuCaoCot
        '
        Me.txtChieuCaoCot.FormattingEnabled = True
        Me.txtChieuCaoCot.Items.AddRange(New Object() {"36", "42", "48", "60"})
        Me.txtChieuCaoCot.Location = New System.Drawing.Point(100, 328)
        Me.txtChieuCaoCot.Name = "txtChieuCaoCot"
        Me.txtChieuCaoCot.Size = New System.Drawing.Size(103, 21)
        Me.txtChieuCaoCot.TabIndex = 70
        '
        'txtLoaiCot
        '
        Me.txtLoaiCot.FormattingEnabled = True
        Me.txtLoaiCot.Items.AddRange(New Object() {"Dây co", "Tự đứng", "Monopole"})
        Me.txtLoaiCot.Location = New System.Drawing.Point(100, 302)
        Me.txtLoaiCot.Name = "txtLoaiCot"
        Me.txtLoaiCot.Size = New System.Drawing.Size(103, 21)
        Me.txtLoaiCot.TabIndex = 69
        Me.txtLoaiCot.Text = "Dây co"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 284)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Địa điểm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Mã trạm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 335)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Chiều cao cột"
        '
        'txtChieuCaoDot
        '
        Me.txtChieuCaoDot.FormattingEnabled = True
        Me.txtChieuCaoDot.Items.AddRange(New Object() {"3", "6", "10"})
        Me.txtChieuCaoDot.Location = New System.Drawing.Point(325, 328)
        Me.txtChieuCaoDot.Name = "txtChieuCaoDot"
        Me.txtChieuCaoDot.Size = New System.Drawing.Size(123, 21)
        Me.txtChieuCaoDot.TabIndex = 75
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 361)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Tiết diện"
        '
        'txtSoTangDay
        '
        Me.txtSoTangDay.FormattingEnabled = True
        Me.txtSoTangDay.Items.AddRange(New Object() {"2", "3", "4", "5", "6"})
        Me.txtSoTangDay.Location = New System.Drawing.Point(100, 405)
        Me.txtSoTangDay.Name = "txtSoTangDay"
        Me.txtSoTangDay.Size = New System.Drawing.Size(103, 21)
        Me.txtSoTangDay.TabIndex = 73
        '
        'txtSoMong
        '
        Me.txtSoMong.FormattingEnabled = True
        Me.txtSoMong.Items.AddRange(New Object() {"3", "4", "5", "6"})
        Me.txtSoMong.Location = New System.Drawing.Point(325, 303)
        Me.txtSoMong.Name = "txtSoMong"
        Me.txtSoMong.Size = New System.Drawing.Size(123, 21)
        Me.txtSoMong.TabIndex = 72
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(234, 334)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Chiều cao đốt"
        '
        'txtViTriDat
        '
        Me.txtViTriDat.FormattingEnabled = True
        Me.txtViTriDat.Items.AddRange(New Object() {"Trên mái", "Dưới đất"})
        Me.txtViTriDat.Location = New System.Drawing.Point(100, 378)
        Me.txtViTriDat.Name = "txtViTriDat"
        Me.txtViTriDat.Size = New System.Drawing.Size(103, 21)
        Me.txtViTriDat.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 309)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Loại cột"
        '
        'txtTietDienCot
        '
        Me.txtTietDienCot.FormattingEnabled = True
        Me.txtTietDienCot.Items.AddRange(New Object() {"0.3x0.3x0.3", "0.4x0.4x0.4", "0.45x0.45x0.45", "0.5x0.5x0.5", "0.6x0.6x0.6", "1x1x1"})
        Me.txtTietDienCot.Location = New System.Drawing.Point(100, 354)
        Me.txtTietDienCot.Name = "txtTietDienCot"
        Me.txtTietDienCot.Size = New System.Drawing.Size(103, 21)
        Me.txtTietDienCot.TabIndex = 71
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 386)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Vị trí đặt"
        '
        'txtDiaDiem
        '
        Me.txtDiaDiem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiaDiem.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDiaDiem.Location = New System.Drawing.Point(101, 278)
        Me.txtDiaDiem.Name = "txtDiaDiem"
        Me.txtDiaDiem.Size = New System.Drawing.Size(346, 20)
        Me.txtDiaDiem.TabIndex = 51
        '
        'txtMaTram
        '
        Me.txtMaTram.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaTram.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaTram.Location = New System.Drawing.Point(101, 253)
        Me.txtMaTram.Name = "txtMaTram"
        Me.txtMaTram.Size = New System.Drawing.Size(346, 20)
        Me.txtMaTram.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btn_Taomoi)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.txt_DK_KhoaCap)
        Me.Panel1.Controls.Add(Me.txtSoChan)
        Me.Panel1.Controls.Add(Me.txtChieuCaoCot)
        Me.Panel1.Controls.Add(Me.txtLoaiCot)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtChieuCaoDot)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtSoTangDay)
        Me.Panel1.Controls.Add(Me.txtSoMong)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtViTriDat)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtTietDienCot)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtDiaDiem)
        Me.Panel1.Controls.Add(Me.txtMaTram)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.la)
        Me.Panel1.Controls.Add(Me.txtGaChongXoay)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtSoDot)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 500)
        Me.Panel1.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(236, 382)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Số chân cột"
        '
        'la
        '
        Me.la.AutoSize = True
        Me.la.Location = New System.Drawing.Point(9, 409)
        Me.la.Name = "la"
        Me.la.Size = New System.Drawing.Size(83, 13)
        Me.la.TabIndex = 61
        Me.la.Text = "Số tầng dây co"
        '
        'txtGaChongXoay
        '
        Me.txtGaChongXoay.Location = New System.Drawing.Point(325, 403)
        Me.txtGaChongXoay.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGaChongXoay.Name = "txtGaChongXoay"
        Me.txtGaChongXoay.Size = New System.Drawing.Size(123, 22)
        Me.txtGaChongXoay.TabIndex = 67
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(321, 425)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 13)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Các tầng dây co có gá cx"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(234, 409)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Gá chống xoay"
        '
        'txtSoDot
        '
        Me.txtSoDot.Location = New System.Drawing.Point(325, 354)
        Me.txtSoDot.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSoDot.Name = "txtSoDot"
        Me.txtSoDot.Size = New System.Drawing.Size(123, 22)
        Me.txtSoDot.TabIndex = 68
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(234, 359)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Số đốt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Số móng co:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.CAD_Viettel_Project.My.Resources.Resources.Screenshot_2020_11_06_165016
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 234)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btn_Taomoi
        '
        Me.btn_Taomoi.ActiveBorderThickness = 2
        Me.btn_Taomoi.ActiveCornerRadius = 20
        Me.btn_Taomoi.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btn_Taomoi.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btn_Taomoi.ActiveLineColor = System.Drawing.Color.DimGray
        Me.btn_Taomoi.BackColor = System.Drawing.Color.White
        Me.btn_Taomoi.BackgroundImage = CType(resources.GetObject("btn_Taomoi.BackgroundImage"), System.Drawing.Image)
        Me.btn_Taomoi.ButtonText = "Tạo mới trạm"
        Me.btn_Taomoi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Taomoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Taomoi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btn_Taomoi.IdleBorderThickness = 1
        Me.btn_Taomoi.IdleCornerRadius = 20
        Me.btn_Taomoi.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btn_Taomoi.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btn_Taomoi.IdleLineColor = System.Drawing.Color.DimGray
        Me.btn_Taomoi.Location = New System.Drawing.Point(87, 454)
        Me.btn_Taomoi.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_Taomoi.Name = "btn_Taomoi"
        Me.btn_Taomoi.Size = New System.Drawing.Size(272, 41)
        Me.btn_Taomoi.TabIndex = 83
        Me.btn_Taomoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form_ThemMoi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 500)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_ThemMoi"
        Me.Text = "Thêm mới trạm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label31 As Label
    Friend WithEvents txt_DK_KhoaCap As ComboBox
    Friend WithEvents txtSoChan As ComboBox
    Friend WithEvents txtChieuCaoCot As ComboBox
    Friend WithEvents txtLoaiCot As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtChieuCaoDot As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSoTangDay As ComboBox
    Friend WithEvents txtSoMong As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtViTriDat As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTietDienCot As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDiaDiem As TextBox
    Friend WithEvents txtMaTram As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents la As Label
    Friend WithEvents txtGaChongXoay As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSoDot As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_Taomoi As Bunifu.Framework.UI.BunifuThinButton2
End Class
