﻿Imports System.ComponentModel

Public Class MDI

#Region "Declaracion de Variables"
    Dim gest_sistem As New BLL.GestorSistema
    Public loginok As Boolean = False
    Dim gest_lng As BLL.GestorLenguaje = Nothing
    Dim gestor_mant As BLL.GestorMantenimiento = Nothing
    Dim frmlogin As Login = Nothing
    Dim frmbackup As Adm_Backups = Nothing
    Dim frmgrupo As Adm_Grupos = Nothing
    Dim frmpermiso As Adm_Permisos = Nothing
    Dim frmbitacora As Adm_Logs = Nothing
    Dim frmusuario As Adm_Usuarios = Nothing
#End Region

#Region "Cerrar Sesion"
    Private Sub RefrescarVar()
        frmbackup = Nothing
        frmgrupo = Nothing
        frmpermiso = Nothing
        frmbitacora = Nothing
        frmusuario = Nothing
        loginok = False
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


#End Region

#Region "Eventos"
    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gest_sistem.ValidarIntegridad Then
            gest_lng = New BLL.GestorLenguaje
            gest_lng.GetLanguages()
            gest_lng.GetMsgLanguages()
            Me.Hide()
            Dim splash As New WelcomeForm
            splash.ShowDialog()
            If frmlogin Is Nothing Then
                frmlogin = New Login
            End If
            CambiarIdioma()
            frmlogin.ShowDialog()
            'frmlogin.MdiParent = Me
            If loginok Then
                CambiarIdioma()
                ValidarPermisos()
                Me.Show()
            Else
                Application.Exit()
            End If
        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("MDI_Load", 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("MDI_Load", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Question)
            Application.Exit()
        End If
    End Sub

    Private Sub MDI_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg("MDI_Closing", 2, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("MDI_Closing", 1, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            GC.Collect()
        ElseIf result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ValidarPermisos()

    End Sub

#End Region

#Region "MenuTool Mantenimiento"
    Private Sub PermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosToolStripMenuItem.Click
        If frmpermiso Is Nothing Then
            frmpermiso = New Adm_Permisos
            frmpermiso.MdiParent = Me
            CambiarIdioma()
        End If
        frmpermiso.Show()
    End Sub

    Private Sub GestorUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorUsuariosToolStripMenuItem.Click
        If frmusuario Is Nothing Then
            frmusuario = New Adm_Usuarios
            frmusuario.MdiParent = Me
            CambiarIdioma()
        End If
        frmusuario.Show()
    End Sub

    Private Sub GestorGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestorGruposToolStripMenuItem.Click
        If frmgrupo Is Nothing Then
            frmgrupo = New Adm_Grupos
            frmgrupo.MdiParent = Me
            CambiarIdioma()
        End If
        frmgrupo.Show()
        frmgrupo = Nothing
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        If frmbackup Is Nothing Then
            frmbackup = New Adm_Backups
            frmbackup.MdiParent = Me
            CambiarIdioma()
        End If
        frmbackup.Show()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        If frmbitacora Is Nothing Then
            frmbitacora = New Adm_Logs
            frmbitacora.MdiParent = Me
            CambiarIdioma()
        End If
        frmbitacora.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim fname As String = "SalirToolStripMenuItem_Click"
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg(fname, 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg(fname, 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            gest_sistem.GrabarDVV()
            LimpiarMemoria()
            If frmlogin Is Nothing Then
                frmlogin = New Login
            End If
            ResetLang()
            Me.Hide()
            frmlogin.ShowDialog()
            If loginok Then
                CambiarIdioma()
                Me.Show()
            Else
                Application.Exit()
            End If
            'Login.MdiParent = Me
            'Login.Show()

        End If
    End Sub



#Region "MenuTool Negocio"

    Private Sub RecepcionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecepcionToolStripMenuItem.Click

    End Sub
#End Region
#End Region

#Region "Idioma"

    Private Function SetUser(id_idioma As Integer) As INFRA.User
        Dim user As INFRA.User
        user = INFRA.SesionManager.CrearSesion.User
        user.Language.id_idioma = id_idioma
        Dim q = INFRA.SesionManager.CrearSesion.User
        Return user
    End Function

    Private Sub SeleccionDeIdiomaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionDeIdiomaToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If GlobalVar.tipodelenguaje <> INFRA.SesionManager.CrearSesion.User.Language.id_idioma Then
                GlobalVar.tipodelenguaje = 2
                CambiarIdioma()
                gestor_mant = New BLL.GestorMantenimiento
                MessageBox.Show(gestor_mant.ModificarUsuario(SetUser(GlobalVar.tipodelenguaje)))
            End If
            MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 3, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If GlobalVar.tipodelenguaje <> INFRA.SesionManager.CrearSesion.User.Language.id_idioma Then
                GlobalVar.tipodelenguaje = 1
                CambiarIdioma()
                gestor_mant = New BLL.GestorMantenimiento
                MessageBox.Show(gestor_mant.ModificarUsuario(SetUser(GlobalVar.tipodelenguaje)))
            End If
            MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 3, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EspañolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspañolToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 1, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If GlobalVar.tipodelenguaje <> INFRA.SesionManager.CrearSesion.User.Language.id_idioma Then
                GlobalVar.tipodelenguaje = 3
                CambiarIdioma()
                gestor_mant = New BLL.GestorMantenimiento
                MessageBox.Show(gestor_mant.ModificarUsuario(SetUser(GlobalVar.tipodelenguaje)))
            End If
            MessageBox.Show(gest_lng.ChangeLangMsg("CambioIdioma", 3, GlobalVar.tipodelenguaje), gest_lng.ChangeLangMsg("CambioIdioma", 2, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
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

#End Region

End Class
