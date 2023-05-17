<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formtest
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
        Me.btnmb = New System.Windows.Forms.Button()
        Me.btnmd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtrong = New System.Windows.Forms.TextBox()
        Me.txtcao = New System.Windows.Forms.TextBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnmb
        '
        Me.btnmb.Location = New System.Drawing.Point(43, 190)
        Me.btnmb.Name = "btnmb"
        Me.btnmb.Size = New System.Drawing.Size(65, 25)
        Me.btnmb.TabIndex = 0
        Me.btnmb.Text = "Mat bang"
        Me.btnmb.UseVisualStyleBackColor = True
        '
        'btnmd
        '
        Me.btnmd.Location = New System.Drawing.Point(186, 190)
        Me.btnmd.Name = "btnmd"
        Me.btnmd.Size = New System.Drawing.Size(65, 25)
        Me.btnmd.TabIndex = 1
        Me.btnmd.Text = "Mat dung"
        Me.btnmd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Rong mong"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cao Mong"
        '
        'txtrong
        '
        Me.txtrong.Location = New System.Drawing.Point(95, 50)
        Me.txtrong.Name = "txtrong"
        Me.txtrong.Size = New System.Drawing.Size(55, 20)
        Me.txtrong.TabIndex = 4
        '
        'txtcao
        '
        Me.txtcao.Location = New System.Drawing.Point(95, 85)
        Me.txtcao.Name = "txtcao"
        Me.txtcao.Size = New System.Drawing.Size(55, 20)
        Me.txtcao.TabIndex = 5
        '
        'dgv
        '
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgv.Location = New System.Drawing.Point(162, 39)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(115, 97)
        Me.dgv.TabIndex = 6
        '
        'Column1
        '
        Me.Column1.HeaderText = "STT"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Rong"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cao"
        Me.Column3.Name = "Column3"
        '
        'Formtest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtcao)
        Me.Controls.Add(Me.txtrong)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnmd)
        Me.Controls.Add(Me.btnmb)
        Me.Name = "Formtest"
        Me.Text = "Formtest"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnmb As Button
    Friend WithEvents btnmd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtrong As TextBox
    Friend WithEvents txtcao As TextBox
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
