Public Class MDI
    Dim login As Login
    Dim idioma As Adm_Idiomas
    Dim backup As Adm_Backups
    Dim grupo As Adm_Grupos
    Dim permiso As Adm_Permisos
    Dim bitacora As Adm_Logs
    Dim usuarios As Adm_Usuarios
    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If login Is Nothing Then
            login = New Login
        End If
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
        If usuarios Is Nothing Then
            usuarios = New Adm_Usuarios
        End If
        usuarios.MdiParent = Me
        usuarios.Show()
    End Sub

    Private Sub GestorGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorGruposToolStripMenuItem.Click
        If grupo Is Nothing Then
            grupo = New Adm_Grupos
        End If
        grupo.MdiParent = Me
        grupo.Show()
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
End Class
