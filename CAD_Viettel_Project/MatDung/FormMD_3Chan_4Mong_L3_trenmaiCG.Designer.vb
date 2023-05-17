<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMD_3Chan_4Mong_L3_trenmaiCG
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMD_3Chan_4Mong_L3_trenmaiCG))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuElipse2 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuElipse3 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuElipse4 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BunifuElipse5 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuElipse6 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbmat = New System.Windows.Forms.ComboBox()
        Me.btnlai = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuElipse2
        '
        Me.BunifuElipse2.ElipseRadius = 5
        Me.BunifuElipse2.TargetControl = Me
        '
        'BunifuElipse3
        '
        Me.BunifuElipse3.ElipseRadius = 5
        Me.BunifuElipse3.TargetControl = Me
        '
        'BunifuElipse4
        '
        Me.BunifuElipse4.ElipseRadius = 5
        Me.BunifuElipse4.TargetControl = Me
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'BunifuElipse5
        '
        Me.BunifuElipse5.ElipseRadius = 5
        Me.BunifuElipse5.TargetControl = Me
        '
        'BunifuElipse6
        '
        Me.BunifuElipse6.ElipseRadius = 5
        Me.BunifuElipse6.TargetControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbmat)
        Me.GroupBox1.Controls.Add(Me.btnlai)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(435, 430)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hình minh họa mặt bằng:"
        '
        'cmbmat
        '
        Me.cmbmat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbmat.FormattingEnabled = True
        Me.cmbmat.Items.AddRange(New Object() {"X-Z", "Y-Z"})
        Me.cmbmat.Location = New System.Drawing.Point(297, 55)
        Me.cmbmat.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbmat.Name = "cmbmat"
        Me.cmbmat.Size = New System.Drawing.Size(85, 23)
        Me.cmbmat.TabIndex = 58
        Me.cmbmat.Text = "X-Z"
        '
        'btnlai
        '
        Me.btnlai.ActiveBorderThickness = 2
        Me.btnlai.ActiveCornerRadius = 20
        Me.btnlai.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnlai.ActiveForecolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnlai.ActiveLineColor = System.Drawing.Color.DimGray
        Me.btnlai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlai.BackColor = System.Drawing.Color.White
        Me.btnlai.BackgroundImage = CType(resources.GetObject("btnlai.BackgroundImage"), System.Drawing.Image)
        Me.btnlai.ButtonText = "Vẽ mặt đứng"
        Me.btnlai.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlai.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlai.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnlai.IdleBorderThickness = 1
        Me.btnlai.IdleCornerRadius = 20
        Me.btnlai.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnlai.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.btnlai.IdleLineColor = System.Drawing.Color.DimGray
        Me.btnlai.Location = New System.Drawing.Point(220, 381)
        Me.btnlai.Margin = New System.Windows.Forms.Padding(5)
        Me.btnlai.Name = "btnlai"
        Me.btnlai.Size = New System.Drawing.Size(201, 42)
        Me.btnlai.TabIndex = 57
        Me.btnlai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(2, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(431, 411)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 430)
        Me.Panel1.TabIndex = 39
        '
        'FormMD_3Chan_4Mong_L3_trenmaiCG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 430)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormMD_3Chan_4Mong_L3_trenmaiCG"
        Me.Text = "FormMD_3Chan_4Mong_L3_trenmaiKG"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BunifuElipse2 As Bunifu.Framework.UI.BunifuElipse
    Public WithEvents BunifuElipse3 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuElipse4 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents BunifuElipse5 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuElipse6 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents btnlai As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents cmbmat As ComboBox
End Class
