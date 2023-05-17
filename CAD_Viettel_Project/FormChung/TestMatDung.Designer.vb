<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestMatDung
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.txtcao = New System.Windows.Forms.TextBox()
        Me.txtrong = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnmd = New System.Windows.Forms.Button()
        Me.btnmb = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgv.Location = New System.Drawing.Point(190, 81)
        Me.dgv.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(274, 119)
        Me.dgv.TabIndex = 13
        '
        'txtcao
        '
        Me.txtcao.Location = New System.Drawing.Point(110, 150)
        Me.txtcao.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcao.Name = "txtcao"
        Me.txtcao.Size = New System.Drawing.Size(72, 22)
        Me.txtcao.TabIndex = 12
        '
        'txtrong
        '
        Me.txtrong.Location = New System.Drawing.Point(110, 107)
        Me.txtrong.Margin = New System.Windows.Forms.Padding(4)
        Me.txtrong.Name = "txtrong"
        Me.txtrong.Size = New System.Drawing.Size(72, 22)
        Me.txtrong.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 153)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Cao Mong"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 110)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Rong mong"
        '
        'btnmd
        '
        Me.btnmd.Location = New System.Drawing.Point(292, 279)
        Me.btnmd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnmd.Name = "btnmd"
        Me.btnmd.Size = New System.Drawing.Size(87, 31)
        Me.btnmd.TabIndex = 8
        Me.btnmd.Text = "Mat dung"
        Me.btnmd.UseVisualStyleBackColor = True
        '
        'btnmb
        '
        Me.btnmb.Location = New System.Drawing.Point(101, 279)
        Me.btnmb.Margin = New System.Windows.Forms.Padding(4)
        Me.btnmb.Name = "btnmb"
        Me.btnmb.Size = New System.Drawing.Size(87, 31)
        Me.btnmb.TabIndex = 7
        Me.btnmb.Text = "Mat bang"
        Me.btnmb.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Số đốt"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Chiều cao"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Rộng đáy"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Rộng đỉnh"
        Me.Column4.Name = "Column4"
        '
        'TestMatDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 402)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtcao)
        Me.Controls.Add(Me.txtrong)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnmd)
        Me.Controls.Add(Me.btnmb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TestMatDung"
        Me.Text = "TestMatDung"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtcao As System.Windows.Forms.TextBox
    Friend WithEvents txtrong As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnmd As System.Windows.Forms.Button
    Friend WithEvents btnmb As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
