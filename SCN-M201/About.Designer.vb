<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.rchAbout = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rchAbout
        '
        Me.rchAbout.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rchAbout.ForeColor = System.Drawing.Color.Black
        Me.rchAbout.Location = New System.Drawing.Point(10, 14)
        Me.rchAbout.Name = "rchAbout"
        Me.rchAbout.ReadOnly = True
        Me.rchAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rchAbout.Size = New System.Drawing.Size(267, 178)
        Me.rchAbout.TabIndex = 1
        Me.rchAbout.Text = resources.GetString("rchAbout.Text")
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.ClientSize = New System.Drawing.Size(287, 207)
        Me.Controls.Add(Me.rchAbout)
        Me.Cursor = System.Windows.Forms.Cursors.Help
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rchAbout As System.Windows.Forms.RichTextBox
End Class
