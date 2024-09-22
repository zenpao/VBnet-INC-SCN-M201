<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
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
        Me.Box = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_SEARCH = New System.Windows.Forms.Button()
        Me.NAME_LAST = New System.Windows.Forms.TextBox()
        Me.lbl_NAME_LAST = New System.Windows.Forms.Label()
        Me.btn_RELOAD = New System.Windows.Forms.Button()
        Me.btn_UPDATE = New System.Windows.Forms.Button()
        Me.ltx_NOTE5 = New System.Windows.Forms.TextBox()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Box})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.GridColor = System.Drawing.Color.PeachPuff
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(601, 251)
        Me.DataGridView1.TabIndex = 11
        '
        'Box
        '
        Me.Box.HeaderText = "∃!1"
        Me.Box.Name = "Box"
        Me.Box.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Box.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Box.ToolTipText = "Select only (1) then press ""Edit""."
        Me.Box.Width = 37
        '
        'btn_SEARCH
        '
        Me.btn_SEARCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SEARCH.Location = New System.Drawing.Point(561, 24)
        Me.btn_SEARCH.Name = "btn_SEARCH"
        Me.btn_SEARCH.Size = New System.Drawing.Size(28, 23)
        Me.btn_SEARCH.TabIndex = 2
        Me.btn_SEARCH.Text = "🔍"
        Me.btn_SEARCH.UseVisualStyleBackColor = True
        '
        'NAME_LAST
        '
        Me.NAME_LAST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NAME_LAST.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NAME_LAST.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NAME_LAST.Location = New System.Drawing.Point(409, 26)
        Me.NAME_LAST.MaxLength = 50
        Me.NAME_LAST.Name = "NAME_LAST"
        Me.NAME_LAST.Size = New System.Drawing.Size(146, 21)
        Me.NAME_LAST.TabIndex = 1
        Me.NAME_LAST.Text = "USER'S SURNAME"
        Me.NAME_LAST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_NAME_LAST
        '
        Me.lbl_NAME_LAST.AutoSize = True
        Me.lbl_NAME_LAST.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NAME_LAST.Location = New System.Drawing.Point(354, 31)
        Me.lbl_NAME_LAST.Name = "lbl_NAME_LAST"
        Me.lbl_NAME_LAST.Size = New System.Drawing.Size(49, 16)
        Me.lbl_NAME_LAST.TabIndex = 1
        Me.lbl_NAME_LAST.Text = "Search:"
        Me.lbl_NAME_LAST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_RELOAD
        '
        Me.btn_RELOAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_RELOAD.Location = New System.Drawing.Point(15, 26)
        Me.btn_RELOAD.Name = "btn_RELOAD"
        Me.btn_RELOAD.Size = New System.Drawing.Size(28, 23)
        Me.btn_RELOAD.TabIndex = 1
        Me.btn_RELOAD.Text = "⟳"
        Me.btn_RELOAD.UseVisualStyleBackColor = True
        '
        'btn_UPDATE
        '
        Me.btn_UPDATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_UPDATE.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_UPDATE.Location = New System.Drawing.Point(501, 316)
        Me.btn_UPDATE.Name = "btn_UPDATE"
        Me.btn_UPDATE.Size = New System.Drawing.Size(88, 25)
        Me.btn_UPDATE.TabIndex = 3
        Me.btn_UPDATE.Text = "Edit"
        Me.btn_UPDATE.UseVisualStyleBackColor = True
        '
        'ltx_NOTE5
        '
        Me.ltx_NOTE5.BackColor = System.Drawing.SystemColors.Control
        Me.ltx_NOTE5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ltx_NOTE5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltx_NOTE5.ForeColor = System.Drawing.Color.Red
        Me.ltx_NOTE5.Location = New System.Drawing.Point(330, 316)
        Me.ltx_NOTE5.Multiline = True
        Me.ltx_NOTE5.Name = "ltx_NOTE5"
        Me.ltx_NOTE5.ReadOnly = True
        Me.ltx_NOTE5.Size = New System.Drawing.Size(169, 28)
        Me.ltx_NOTE5.TabIndex = 2
        Me.ltx_NOTE5.Text = "*SELECT  ONLY (1) else the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "first choice will only be accepted."
        '
        'frmView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(601, 355)
        Me.Controls.Add(Me.ltx_NOTE5)
        Me.Controls.Add(Me.btn_UPDATE)
        Me.Controls.Add(Me.btn_RELOAD)
        Me.Controls.Add(Me.lbl_NAME_LAST)
        Me.Controls.Add(Me.NAME_LAST)
        Me.Controls.Add(Me.btn_SEARCH)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmView"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SCAN Members"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_SEARCH As System.Windows.Forms.Button
    Friend WithEvents NAME_LAST As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NAME_LAST As System.Windows.Forms.Label
    Friend WithEvents btn_RELOAD As System.Windows.Forms.Button
    Friend WithEvents Box As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btn_UPDATE As System.Windows.Forms.Button
    Friend WithEvents ltx_NOTE5 As System.Windows.Forms.TextBox
End Class
