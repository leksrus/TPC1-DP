Public Class MDI
    'Dim forms As List(Of Form) = Nothing
    Dim gest_lng As BLL.GestorLenguaje = Nothing
    Dim login As Login = Nothing
    Dim idioma As Adm_Idiomas = Nothing
    Dim backup As Adm_Backups = Nothing
    Dim grupo As Adm_Grupos = Nothing
    Dim permiso As Adm_Permisos = Nothing
    Dim bitacora As Adm_Logs = Nothing
    Dim usuario As Adm_Usuarios = Nothing
    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gest_lng = New BLL.GestorLenguaje
        gest_lng.GetLanguages()
        gest_lng.GetMsgLanguages()
        If login Is Nothing Then
            login = New Login
        End If
        CambiarIdioma()
        login.MdiParent = Me
        login.Show()
    End Sub

    Private Sub IdiomasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IdiomasToolStripMenuItem1.Click
        If idioma Is Nothing Then
            idioma = New Adm_Idiomas
        End If
        idioma.MdiParent = Me
        idioma.Show()
    End Sub

    Private Sub PermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosToolStripMenuItem.Click
        If permiso Is Nothing Then
            permiso = New Adm_Permisos
        End If
        permiso.MdiParent = Me
        permiso.Show()
    End Sub

    Private Sub GestorUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorUsuariosToolStripMenuItem.Click
        If usuario Is Nothing Then
            usuario = New Adm_Usuarios
        End If
        usuario.MdiParent = Me
        usuario.Show()
    End Sub

    Private Sub GestorGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorGruposToolStripMenuItem.Click
        If grupo Is Nothing Then
            grupo = New Adm_Grupos

        End If
        grupo.MdiParent = Me
        grupo.Show()
        grupo = Nothing
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        If backup Is Nothing Then
            backup = New Adm_Backups
        End If
        backup.MdiParent = Me
        backup.Show()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        If bitacora Is Nothing Then
            bitacora = New Adm_Logs
        End If
        bitacora.MdiParent = Me
        bitacora.Show()
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

    Private Sub CerrarTodo()
        usuario.Close()
        grupo.Close()
        permiso.Close()
        bitacora.Close()
        idioma.Close()
        backup.Close()
        usuario = Nothing
        grupo = Nothing

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim fname As String = "SalirToolStripMenuItem_Click"
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg(fname, 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg(fname, 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ResetLang()
            LimpiarMemoria()
            login.MdiParent = Me
            login.Show()
        ElseIf result = DialogResult.No Then

        End If
    End Sub

    Private Sub LimpiarMemoria()
        INFRA.SesionManager.CrearSesion.User = Nothing
        INFRA.SesionManager.CerrarSesion()
        'For Each frm In forms
        '    If TypeOf frm IsNot Login Then
        '        frm.Close()
        '        frm = Nothing
        '    End If
        'Next
        For Each frm In Me.MdiChildren
            If TypeOf frm IsNot Login Then
                frm.Close()

            End If
        Next
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
