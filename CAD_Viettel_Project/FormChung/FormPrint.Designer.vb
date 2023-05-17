<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrint
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbMatBang = New System.Windows.Forms.RadioButton()
        Me.rdbMatDung = New System.Windows.Forms.RadioButton()
        Me.txtDuongDan = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbMatBang)
        Me.GroupBox1.Controls.Add(Me.rdbMatDung)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 61)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chọn loại in"
        '
        'rdbMatBang
        '
        Me.rdbMatBang.AutoSize = True
        Me.rdbMatBang.Location = New System.Drawing.Point(101, 19)
        Me.rdbMatBang.Name = "rdbMatBang"
        Me.rdbMatBang.Size = New System.Drawing.Size(70, 17)
        Me.rdbMatBang.TabIndex = 0
        Me.rdbMatBang.TabStop = True
        Me.rdbMatBang.Text = "Mặt bằng"
        Me.rdbMatBang.UseVisualStyleBackColor = True
        '
        'rdbMatDung
        '
        Me.rdbMatDung.AutoSize = True
        Me.rdbMatDung.Location = New System.Drawing.Point(6, 19)
        Me.rdbMatDung.Name = "rdbMatDung"
        Me.rdbMatDung.Size = New System.Drawing.Size(71, 17)
        Me.rdbMatDung.TabIndex = 0
        Me.rdbMatDung.TabStop = True
        Me.rdbMatDung.Text = "Mặt đứng"
        Me.rdbMatDung.UseVisualStyleBackColor = True
        '
        'txtDuongDan
        '
        Me.txtDuongDan.Location = New System.Drawing.Point(12, 79)
        Me.txtDuongDan.Multiline = True
        Me.txtDuongDan.Name = "txtDuongDan"
        Me.txtDuongDan.Size = New System.Drawing.Size(285, 45)
        Me.txtDuongDan.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(208, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Save Image"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 136)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDuongDan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPrint"
        Me.Text = "FormPrint"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbMatBang As RadioButton
    Friend WithEvents rdbMatDung As RadioButton
    Friend WithEvents txtDuongDan As TextBox
    Friend WithEvents Button1 As Button
End Class
