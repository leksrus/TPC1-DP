Public Class MDI
    Dim gest_lng As BLL.GestorLenguaje = Nothing
    Dim frmlogin As Login = Nothing
    Dim frmbackup As Adm_Backups = Nothing
    Dim frmgrupo As Adm_Grupos = Nothing
    Dim frmpermiso As Adm_Permisos = Nothing
    Dim frmbitacora As Adm_Logs = Nothing
    Dim frmusuario As Adm_Usuarios = Nothing

    Private Sub RefrescarVar()
        frmbackup = Nothing
        frmgrupo = Nothing
        frmpermiso = Nothing
        frmbitacora = Nothing
        frmusuario = Nothing
    End Sub
    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gest_lng = New BLL.GestorLenguaje
        gest_lng.GetLanguages()
        gest_lng.GetMsgLanguages()
        If frmlogin Is Nothing Then
            frmlogin = New Login
        End If
        CambiarIdioma()
        Login.MdiParent = Me
        Login.Show()
    End Sub

    Private Sub PermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosToolStripMenuItem.Click
        If frmpermiso Is Nothing Then
            frmpermiso = New Adm_Permisos
        End If
        frmpermiso.MdiParent = Me
        frmpermiso.Show()
    End Sub

    Private Sub GestorUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorUsuariosToolStripMenuItem.Click
        If frmusuario Is Nothing Then
            frmusuario = New Adm_Usuarios
        End If
        frmusuario.MdiParent = Me
        frmusuario.Show()
    End Sub

    Private Sub GestorGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorGruposToolStripMenuItem.Click
        If frmgrupo Is Nothing Then
            frmgrupo = New Adm_Grupos
        End If
        frmgrupo.MdiParent = Me
        frmgrupo.Show()
        frmgrupo = Nothing
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        If frmbackup Is Nothing Then
            frmbackup = New Adm_Backups
        End If
        frmbackup.MdiParent = Me
        frmbackup.Show()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        If frmbitacora Is Nothing Then
            frmbitacora = New Adm_Logs
        End If
        frmbitacora.MdiParent = Me
        frmbitacora.Show()
    End Sub

    Private Sub SeleccionDeIdiomaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionDeIdiomaToolStripMenuItem.Click
        GlobalVar.tipodelenguaje = 2
        CambiarIdioma()
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishToolStripMenuItem.Click
        GlobalVar.tipodelenguaje = 1
        CambiarIdioma()
    End Sub

    Private Sub EspañolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspañolToolStripMenuItem.Click
        GlobalVar.tipodelenguaje = 3
        CambiarIdioma()
    End Sub


    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim fname As String = "SalirToolStripMenuItem_Click"
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg(fname, 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg(fname, 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ResetLang()
            LimpiarMemoria()
            Login.MdiParent = Me
            Login.Show()
        ElseIf result = DialogResult.No Then

        End If
    End Sub

    Private Sub LimpiarMemoria()
        INFRA.SesionManager.CrearSesion.User = Nothing
        INFRA.SesionManager.CerrarSesion()
        For Each frm In Me.MdiChildren
            If TypeOf frm IsNot Login Then
                frm.Close()
            End If
        Next
        RefrescarVar()
        GC.Collect()
    End Sub

    Private Sub ResetLang()
        GlobalVar.tipodelenguaje = 3
        CambiarIdioma()
    End Sub

    Private Sub CambiarIdioma()
        For Each item In Me.MenuStrip1.Items
            Dim it = DirectCast(item, ToolStripItem)
            it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
        Next
        For Each manitem In Me.MantenimientoToolStripMenuItem.DropDownItems
            Dim it = DirectCast(manitem, ToolStripMenuItem)
            it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
        Next
        For Each menuitem In Me.MenuToolStripMenuItem.DropDownItems
            If TypeOf menuitem IsNot ToolStripSeparator Then
                Dim it = DirectCast(menuitem, ToolStripMenuItem)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            End If
        Next
        For Each frm In Me.MdiChildren
            For Each ctrl In frm.Controls
                If TypeOf ctrl Is Label Then
                    Dim it = DirectCast(ctrl, Label)
                    it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, frm.Name, it.Name)
                ElseIf TypeOf ctrl Is Button Then
                    Dim it = DirectCast(ctrl, Button)
                    it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, frm.Name, it.Name)
                ElseIf TypeOf ctrl Is RadioButton Then
                    Dim it = DirectCast(ctrl, RadioButton)
                    it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, frm.Name, it.Name)
                End If
            Next
            frm.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, frm.Name, "Form")
        Next
    End Sub

    Private Sub RecepcionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecepcionToolStripMenuItem.Click

    End Sub
End Class
