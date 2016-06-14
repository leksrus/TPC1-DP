<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecepcionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProfesoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoordinacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdiomasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionDeIdiomaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.IdiomasToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(938, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecepcionToolStripMenuItem, Me.ToolStripMenuItem2, Me.ProfesoresToolStripMenuItem, Me.CoordinacionToolStripMenuItem, Me.ToolStripMenuItem3, Me.SalirToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'RecepcionToolStripMenuItem
        '
        Me.RecepcionToolStripMenuItem.Name = "RecepcionToolStripMenuItem"
        Me.RecepcionToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RecepcionToolStripMenuItem.Text = "&Recepcion"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem2.Text = "&Administrativos"
        '
        'ProfesoresToolStripMenuItem
        '
        Me.ProfesoresToolStripMenuItem.Name = "ProfesoresToolStripMenuItem"
        Me.ProfesoresToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ProfesoresToolStripMenuItem.Text = "&Profesores"
        '
        'CoordinacionToolStripMenuItem
        '
        Me.CoordinacionToolStripMenuItem.Name = "CoordinacionToolStripMenuItem"
        Me.CoordinacionToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CoordinacionToolStripMenuItem.Text = "&Coordinacion"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(154, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'IdiomasToolStripMenuItem
        '
        Me.IdiomasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionDeIdiomaToolStripMenuItem})
        Me.IdiomasToolStripMenuItem.Name = "IdiomasToolStripMenuItem"
        Me.IdiomasToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.IdiomasToolStripMenuItem.Text = "Idiomas"
        '
        'SeleccionDeIdiomaToolStripMenuItem
        '
        Me.SeleccionDeIdiomaToolStripMenuItem.Name = "SeleccionDeIdiomaToolStripMenuItem"
        Me.SeleccionDeIdiomaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SeleccionDeIdiomaToolStripMenuItem.Text = "&Seleccion de Idioma"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 632)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MDI"
        Me.Text = "CCCP GYM & Fitness"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecepcionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ProfesoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CoordinacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IdiomasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionDeIdiomaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
End Class
