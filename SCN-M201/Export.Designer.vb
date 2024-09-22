<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ltx_NOTE6 = New System.Windows.Forms.TextBox()
        Me.btn_EXPORT = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Goldenrod
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.GridColor = System.Drawing.Color.PeachPuff
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 70)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(601, 251)
        Me.DataGridView1.TabIndex = 12
        '
        'ltx_NOTE6
        '
        Me.ltx_NOTE6.BackColor = System.Drawing.SystemColors.Control
        Me.ltx_NOTE6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ltx_NOTE6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltx_NOTE6.ForeColor = System.Drawing.Color.Red
        Me.ltx_NOTE6.Location = New System.Drawing.Point(392, 13)
        Me.ltx_NOTE6.Multiline = True
        Me.ltx_NOTE6.Name = "ltx_NOTE6"
        Me.ltx_NOTE6.ReadOnly = True
        Me.ltx_NOTE6.Size = New System.Drawing.Size(105, 57)
        Me.ltx_NOTE6.TabIndex = 13
        Me.ltx_NOTE6.Text = "*DOUBLE CHECK data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "before proceeding." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*DO NOT save to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UAC-enabled paths."
        '
        'btn_EXPORT
        '
        Me.btn_EXPORT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EXPORT.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EXPORT.Location = New System.Drawing.Point(501, 39)
        Me.btn_EXPORT.Name = "btn_EXPORT"
        Me.btn_EXPORT.Size = New System.Drawing.Size(88, 25)
        Me.btn_EXPORT.TabIndex = 14
        Me.btn_EXPORT.Text = "Proceed"
        Me.btn_EXPORT.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 344)
        Me.Controls.Add(Me.ltx_NOTE6)
        Me.Controls.Add(Me.btn_EXPORT)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ltx_NOTE6 As System.Windows.Forms.TextBox
    Friend WithEvents btn_EXPORT As System.Windows.Forms.Button
End Class
