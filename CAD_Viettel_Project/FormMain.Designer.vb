<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbTenTram = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton10 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.menusave = New System.Windows.Forms.MenuStrip()
        Me.bntOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnTTC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLuu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.slider = New System.Windows.Forms.Panel()
        Me.btnMatBang = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnMatDung = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.bangtinh = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnsave = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.btn_TaoMoi = New Bunifu.Framework.UI.BunifuImageButton()
        Me.btnOpenDA = New Bunifu.Framework.UI.BunifuImageButton()
        Me.btnXuatBaoCao = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Panel2.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.BunifuImageButton10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menusave.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_TaoMoi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOpenDA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnXuatBaoCao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lbTenTram)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(687, 23)
        Me.Panel2.TabIndex = 16
        '
        'lbTenTram
        '
        Me.lbTenTram.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTenTram.AutoSize = True
        Me.lbTenTram.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTenTram.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.lbTenTram.Location = New System.Drawing.Point(6, 1)
        Me.lbTenTram.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbTenTram.Name = "lbTenTram"
        Me.lbTenTram.Size = New System.Drawing.Size(72, 20)
        Me.lbTenTram.TabIndex = 2
        Me.lbTenTram.Text = "Tên trạm"
        Me.lbTenTram.Visible = False
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.Control
        Me.Panel12.Controls.Add(Me.Panel2)
        Me.Panel12.Controls.Add(Me.BunifuImageButton10)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(0, 754)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(687, 23)
        Me.Panel12.TabIndex = 15
        '
        'BunifuImageButton10
        '
        Me.BunifuImageButton10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuImageButton10.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton10.Image = CType(resources.GetObject("BunifuImageButton10.Image"), System.Drawing.Image)
        Me.BunifuImageButton10.ImageActive = Nothing
        Me.BunifuImageButton10.Location = New System.Drawing.Point(710, 2)
        Me.BunifuImageButton10.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuImageButton10.Name = "BunifuImageButton10"
        Me.BunifuImageButton10.Size = New System.Drawing.Size(19, 19)
        Me.BunifuImageButton10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton10.TabIndex = 7
        Me.BunifuImageButton10.TabStop = False
        Me.BunifuImageButton10.Zoom = 10
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BunifuDragControl2
        '
        Me.BunifuDragControl2.Fixed = True
        Me.BunifuDragControl2.Horizontal = True
        Me.BunifuDragControl2.TargetControl = Nothing
        Me.BunifuDragControl2.Vertical = True
        '
        'menusave
        '
        Me.menusave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.menusave.Dock = System.Windows.Forms.DockStyle.Left
        Me.menusave.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menusave.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bntOpen, Me.btnTTC, Me.btnLuu})
        Me.menusave.Location = New System.Drawing.Point(0, 58)
        Me.menusave.Name = "menusave"
        Me.menusave.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.menusave.Size = New System.Drawing.Size(120, 549)
        Me.menusave.TabIndex = 16
        Me.menusave.Text = "MenuStrip1"
        Me.menusave.Visible = False
        '
        'bntOpen
        '
        Me.bntOpen.Image = CType(resources.GetObject("bntOpen.Image"), System.Drawing.Image)
        Me.bntOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntOpen.Name = "bntOpen"
        Me.bntOpen.Size = New System.Drawing.Size(126, 24)
        Me.bntOpen.Text = "Mở thư mục data"
        '
        'btnTTC
        '
        Me.btnTTC.Image = CType(resources.GetObject("btnTTC.Image"), System.Drawing.Image)
        Me.btnTTC.Name = "btnTTC"
        Me.btnTTC.Size = New System.Drawing.Size(126, 24)
        Me.btnTTC.Text = "Thông tin chung"
        '
        'btnLuu
        '
        Me.btnLuu.Image = CType(resources.GetObject("btnLuu.Image"), System.Drawing.Image)
        Me.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(126, 24)
        Me.btnLuu.Text = "Lưu cài đặt"
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.slider)
        Me.Panel1.Controls.Add(Me.btnMatBang)
        Me.Panel1.Controls.Add(Me.btnMatDung)
        Me.Panel1.Controls.Add(Me.bangtinh)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.BunifuImageButton2)
        Me.Panel1.Controls.Add(Me.btn_TaoMoi)
        Me.Panel1.Controls.Add(Me.btnOpenDA)
        Me.Panel1.Controls.Add(Me.btnXuatBaoCao)
        Me.Panel1.Controls.Add(Me.BunifuImageButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 58)
        Me.Panel1.TabIndex = 14
        '
        'slider
        '
        Me.slider.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.slider.Location = New System.Drawing.Point(2, 54)
        Me.slider.Margin = New System.Windows.Forms.Padding(2)
        Me.slider.Name = "slider"
        Me.slider.Size = New System.Drawing.Size(113, 8)
        Me.slider.TabIndex = 4
        '
        'btnMatBang
        '
        Me.btnMatBang.Activecolor = System.Drawing.Color.Transparent
        Me.btnMatBang.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMatBang.BackColor = System.Drawing.Color.Transparent
        Me.btnMatBang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMatBang.BorderRadius = 0
        Me.btnMatBang.ButtonText = "Mặt bằng"
        Me.btnMatBang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMatBang.DisabledColor = System.Drawing.Color.Gray
        Me.btnMatBang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMatBang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnMatBang.Iconcolor = System.Drawing.Color.Transparent
        Me.btnMatBang.Iconimage = Nothing
        Me.btnMatBang.Iconimage_right = Nothing
        Me.btnMatBang.Iconimage_right_Selected = Nothing
        Me.btnMatBang.Iconimage_Selected = Nothing
        Me.btnMatBang.IconMarginLeft = 0
        Me.btnMatBang.IconMarginRight = 0
        Me.btnMatBang.IconRightVisible = True
        Me.btnMatBang.IconRightZoom = 0R
        Me.btnMatBang.IconVisible = True
        Me.btnMatBang.IconZoom = 90.0R
        Me.btnMatBang.IsTab = True
        Me.btnMatBang.Location = New System.Drawing.Point(117, 33)
        Me.btnMatBang.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMatBang.Name = "btnMatBang"
        Me.btnMatBang.Normalcolor = System.Drawing.Color.Transparent
        Me.btnMatBang.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.btnMatBang.OnHoverTextColor = System.Drawing.Color.Black
        Me.btnMatBang.selected = False
        Me.btnMatBang.Size = New System.Drawing.Size(113, 24)
        Me.btnMatBang.TabIndex = 4
        Me.btnMatBang.Text = "Mặt bằng"
        Me.btnMatBang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnMatBang.Textcolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnMatBang.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnMatDung
        '
        Me.btnMatDung.Activecolor = System.Drawing.Color.Transparent
        Me.btnMatDung.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnMatDung.BackColor = System.Drawing.Color.Transparent
        Me.btnMatDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMatDung.BorderRadius = 0
        Me.btnMatDung.ButtonText = "Mặt đứng"
        Me.btnMatDung.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMatDung.DisabledColor = System.Drawing.Color.Gray
        Me.btnMatDung.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMatDung.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnMatDung.Iconcolor = System.Drawing.Color.Transparent
        Me.btnMatDung.Iconimage = Nothing
        Me.btnMatDung.Iconimage_right = Nothing
        Me.btnMatDung.Iconimage_right_Selected = Nothing
        Me.btnMatDung.Iconimage_Selected = Nothing
        Me.btnMatDung.IconMarginLeft = 0
        Me.btnMatDung.IconMarginRight = 0
        Me.btnMatDung.IconRightVisible = True
        Me.btnMatDung.IconRightZoom = 0R
        Me.btnMatDung.IconVisible = True
        Me.btnMatDung.IconZoom = 90.0R
        Me.btnMatDung.IsTab = True
        Me.btnMatDung.Location = New System.Drawing.Point(233, 33)
        Me.btnMatDung.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMatDung.Name = "btnMatDung"
        Me.btnMatDung.Normalcolor = System.Drawing.Color.Transparent
        Me.btnMatDung.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.btnMatDung.OnHoverTextColor = System.Drawing.Color.Black
        Me.btnMatDung.selected = False
        Me.btnMatDung.Size = New System.Drawing.Size(113, 24)
        Me.btnMatDung.TabIndex = 4
        Me.btnMatDung.Text = "Mặt đứng"
        Me.btnMatDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnMatDung.Textcolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnMatDung.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'bangtinh
        '
        Me.bangtinh.Activecolor = System.Drawing.Color.Transparent
        Me.bangtinh.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bangtinh.BackColor = System.Drawing.Color.Transparent
        Me.bangtinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bangtinh.BorderRadius = 0
        Me.bangtinh.ButtonText = "Thông tin chung"
        Me.bangtinh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bangtinh.DisabledColor = System.Drawing.Color.Gray
        Me.bangtinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bangtinh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.bangtinh.Iconcolor = System.Drawing.Color.Transparent
        Me.bangtinh.Iconimage = Nothing
        Me.bangtinh.Iconimage_right = Nothing
        Me.bangtinh.Iconimage_right_Selected = Nothing
        Me.bangtinh.Iconimage_Selected = Nothing
        Me.bangtinh.IconMarginLeft = 0
        Me.bangtinh.IconMarginRight = 0
        Me.bangtinh.IconRightVisible = True
        Me.bangtinh.IconRightZoom = 0R
        Me.bangtinh.IconVisible = True
        Me.bangtinh.IconZoom = 90.0R
        Me.bangtinh.IsTab = True
        Me.bangtinh.Location = New System.Drawing.Point(2, 33)
        Me.bangtinh.Margin = New System.Windows.Forms.Padding(4)
        Me.bangtinh.Name = "bangtinh"
        Me.bangtinh.Normalcolor = System.Drawing.Color.Transparent
        Me.bangtinh.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.bangtinh.OnHoverTextColor = System.Drawing.Color.Black
        Me.bangtinh.selected = True
        Me.bangtinh.Size = New System.Drawing.Size(113, 24)
        Me.bangtinh.TabIndex = 4
        Me.bangtinh.Text = "Thông tin chung"
        Me.bangtinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bangtinh.Textcolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.bangtinh.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnsave
        '
        Me.btnsave.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnsave.BackColor = System.Drawing.Color.Transparent
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageActive = Nothing
        Me.btnsave.Location = New System.Drawing.Point(117, 5)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(20, 22)
        Me.btnsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnsave.TabIndex = 7
        Me.btnsave.TabStop = False
        Me.btnsave.Zoom = 10
        '
        'BunifuImageButton2
        '
        Me.BunifuImageButton2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BunifuImageButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton2.Image = CType(resources.GetObject("BunifuImageButton2.Image"), System.Drawing.Image)
        Me.BunifuImageButton2.ImageActive = Nothing
        Me.BunifuImageButton2.Location = New System.Drawing.Point(153, 4)
        Me.BunifuImageButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuImageButton2.Name = "BunifuImageButton2"
        Me.BunifuImageButton2.Size = New System.Drawing.Size(19, 20)
        Me.BunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton2.TabIndex = 7
        Me.BunifuImageButton2.TabStop = False
        Me.BunifuImageButton2.Zoom = 10
        '
        'btn_TaoMoi
        '
        Me.btn_TaoMoi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_TaoMoi.BackColor = System.Drawing.Color.Transparent
        Me.btn_TaoMoi.Image = Global.CAD_Viettel_Project.My.Resources.Resources.new_copy_52px
        Me.btn_TaoMoi.ImageActive = Nothing
        Me.btn_TaoMoi.Location = New System.Drawing.Point(11, 4)
        Me.btn_TaoMoi.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_TaoMoi.Name = "btn_TaoMoi"
        Me.btn_TaoMoi.Size = New System.Drawing.Size(19, 20)
        Me.btn_TaoMoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btn_TaoMoi.TabIndex = 7
        Me.btn_TaoMoi.TabStop = False
        Me.btn_TaoMoi.Zoom = 10
        '
        'btnOpenDA
        '
        Me.btnOpenDA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOpenDA.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenDA.Image = CType(resources.GetObject("btnOpenDA.Image"), System.Drawing.Image)
        Me.btnOpenDA.ImageActive = Nothing
        Me.btnOpenDA.Location = New System.Drawing.Point(50, 5)
        Me.btnOpenDA.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOpenDA.Name = "btnOpenDA"
        Me.btnOpenDA.Size = New System.Drawing.Size(19, 20)
        Me.btnOpenDA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnOpenDA.TabIndex = 7
        Me.btnOpenDA.TabStop = False
        Me.btnOpenDA.Zoom = 10
        '
        'btnXuatBaoCao
        '
        Me.btnXuatBaoCao.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnXuatBaoCao.BackColor = System.Drawing.Color.Transparent
        Me.btnXuatBaoCao.Image = CType(resources.GetObject("btnXuatBaoCao.Image"), System.Drawing.Image)
        Me.btnXuatBaoCao.ImageActive = Nothing
        Me.btnXuatBaoCao.Location = New System.Drawing.Point(84, 5)
        Me.btnXuatBaoCao.Margin = New System.Windows.Forms.Padding(2)
        Me.btnXuatBaoCao.Name = "btnXuatBaoCao"
        Me.btnXuatBaoCao.Size = New System.Drawing.Size(19, 20)
        Me.btnXuatBaoCao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnXuatBaoCao.TabIndex = 7
        Me.btnXuatBaoCao.TabStop = False
        Me.btnXuatBaoCao.Zoom = 10
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(659, 5)
        Me.BunifuImageButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(19, 20)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 7
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 777)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.menusave)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FormMain"
        Me.Text = "Form1"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.BunifuImageButton10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menusave.ResumeLayout(False)
        Me.menusave.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_TaoMoi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOpenDA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnXuatBaoCao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbTenTram As Label
    Friend WithEvents BunifuImageButton10 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents menusave As MenuStrip
    Friend WithEvents bntOpen As ToolStripMenuItem
    Friend WithEvents btnTTC As ToolStripMenuItem
    Friend WithEvents btnLuu As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents slider As Panel
    Friend WithEvents btnMatBang As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnMatDung As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents bangtinh As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnsave As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents btnOpenDA As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents btnXuatBaoCao As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents btn_TaoMoi As Bunifu.Framework.UI.BunifuImageButton
End Class
