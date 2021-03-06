﻿Imports System.ComponentModel

Public Class Adm_Usuarios

#Region "variables"
    'Dim cargos As New List(Of String)
    Dim gestor_leng As New SL.GestorLenguaje
    Dim pass As String = String.Empty
#End Region

#Region "botones"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim usuario As New INFRA.User
            Dim userdata As New INFRA.UserData
            Dim lenguaje As New INFRA.Language
            Dim gest_manten As New SL.GestorMantenimiento
            Dim gest_sistem As New SL.GestorSistema
            If RadioButton1.Checked Then
                usuario.Language = lenguaje
                usuario.UserData = userdata
                'valida si los datos son ingresados correctamente
                If ValidarTextbox(TextBox1) AndAlso ValidarTextbox(TextBox2) AndAlso ValidarTextbox(TextBox3) AndAlso MaskedTextBox1.MaskCompleted AndAlso MaskedTextBox2.MaskCompleted Then
                    usuario.name = TextBox1.Text
                    usuario.password = "password"
                    usuario.estado = True
                    Select Case ComboBox2.SelectedIndex
                        Case 0
                            usuario.Language.id_idioma = 1
                        Case 1
                            usuario.Language.id_idioma = 2
                        Case 2
                            usuario.Language.id_idioma = 3
                        Case Else
                            MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Select
                    usuario.UserData.nombre = TextBox2.Text
                    usuario.UserData.apellido = TextBox3.Text
                    usuario.UserData.dni = MaskedTextBox1.Text
                    usuario.UserData.telefono = MaskedTextBox2.Text
                    usuario.UserData.cargo = ComboBox1.SelectedItem
                    usuario.UserData.fecha_ingreso = DateTimePicker1.Value
                    gest_sistem.GrabarBitacora(INFRA.TypeError.create_user, Me.Name)
                    MessageBox.Show(gest_manten.RegistrarUsuario(usuario), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                RadioButton1.Checked = False
                gest_sistem = Nothing
            ElseIf RadioButton2.Checked Then
                If ValidarTextbox(TextBox1) AndAlso ValidarTextbox(TextBox2) AndAlso ValidarTextbox(TextBox3) AndAlso MaskedTextBox1.MaskCompleted AndAlso MaskedTextBox2.MaskCompleted Then
                    usuario.Language = lenguaje
                    usuario.UserData = userdata
                    usuario.name = TextBox1.Text
                    usuario.password = pass
                    usuario.estado = False
                    Select Case ComboBox2.SelectedIndex
                        Case 0
                            usuario.Language.id_idioma = 1
                        Case 1
                            usuario.Language.id_idioma = 2
                        Case 2
                            usuario.Language.id_idioma = 3
                        Case Else
                            MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Select
                    usuario.UserData.nombre = TextBox2.Text
                    usuario.UserData.apellido = TextBox3.Text
                    usuario.UserData.dni = MaskedTextBox1.Text
                    usuario.UserData.telefono = MaskedTextBox2.Text
                    usuario.UserData.cargo = ComboBox1.SelectedItem
                    usuario.UserData.fecha_ingreso = DateTimePicker1.Value
                    gest_sistem.GrabarBitacora(INFRA.TypeError.disable_user, Me.Name)
                    MessageBox.Show(gest_manten.ModificarUsuario(usuario), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                RadioButton2.Checked = False
                gest_sistem = Nothing
            ElseIf RadioButton3.Checked Then
                If ValidarTextbox(TextBox1) AndAlso ValidarTextbox(TextBox2) AndAlso ValidarTextbox(TextBox3) AndAlso MaskedTextBox1.MaskCompleted AndAlso MaskedTextBox2.MaskCompleted Then
                    usuario.Language = lenguaje
                    usuario.UserData = userdata
                    usuario.name = TextBox1.Text
                    usuario.password = pass
                    usuario.estado = True
                    Select Case ComboBox2.SelectedIndex
                        Case 0
                            usuario.Language.id_idioma = 1
                        Case 1
                            usuario.Language.id_idioma = 2
                        Case 2
                            usuario.Language.id_idioma = 3
                        Case Else
                            MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Select
                    usuario.UserData.nombre = TextBox2.Text
                    usuario.UserData.apellido = TextBox3.Text
                    usuario.UserData.dni = MaskedTextBox1.Text
                    usuario.UserData.telefono = MaskedTextBox2.Text
                    usuario.UserData.cargo = ComboBox1.SelectedItem
                    usuario.UserData.fecha_ingreso = DateTimePicker1.Value
                    gest_sistem.GrabarBitacora(INFRA.TypeError.disable_user, Me.Name)
                    MessageBox.Show(gest_manten.ModificarUsuario(usuario), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(gestor_leng.ChangeLangMsg("Carga_usuario", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("Carga_usuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                RadioButton3.Checked = False
                gest_sistem = Nothing
            End If
            DataGridView1.DataSource = Nothing
            DataGridView2.DataSource = Nothing
            Button1.Enabled = False
            Limpiarcontrols()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        carga()
        Me.Hide()
    End Sub
#End Region

#Region "carga y funciones aux"
    Private Sub Adm_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga()
    End Sub

    'lipia los controles
    Private Sub Limpiarcontrols()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()
        TextBox1.Focus()
    End Sub

    'valido que los textbox no sean vacios
    Private Function ValidarTextbox(textbox As TextBox) As Boolean
        If Not String.IsNullOrWhiteSpace(textbox.Text) Then
            Return True
        End If
        Return False
    End Function

    'funcion de inicio en la carga
    Private Sub carga()
        Dim lenguajes As List(Of INFRA.Language) = gestor_leng.ListarTipoIdioma
        Dim cargos As New List(Of String)
        Select Case INFRA.SesionManager.CrearSesion.User.Language.id_idioma
            Case 1
                cargos.Add("Administrator")
                cargos.Add("Coordinator")
                cargos.Add("Gym Trainer")
                cargos.Add("Sysadmin")
                cargos.Add("Administrative Reception")
            Case 2
                cargos.Add("Администрация")
                cargos.Add("Координирование")
                cargos.Add("Тренер")
                cargos.Add("Сисадмин")
                cargos.Add("Менеджер")
            Case Else
                cargos.Add("Administrativo")
                cargos.Add("Coordinador")
                cargos.Add("Entrenador")
                cargos.Add("Administrador")
                cargos.Add("Administrativo de Recepcion")
        End Select
        cargos.Sort()
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = lenguajes
        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = cargos
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Button1.Enabled = False
        MaskedTextBox1.Mask = "00,000,000"
        MaskedTextBox2.Mask = "0-000-00-00"
        DateTimePicker1.MaxDate = Date.Now
        DateTimePicker1.Value = Date.Now
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim usuario As New INFRA.User
        Dim gestormanten As New SL.GestorMantenimiento
        If ValidarTextbox(TextBox1) Then
            usuario.name = TextBox1.Text
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gestormanten.BuscarUsuario(usuario)
            'DataGridView1.Columns(2).Visible = False
            'DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
        End If

    End Sub

#End Region

#Region "Eventos"
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim dr As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            pass = dr.Cells(1).Value.ToString
            Dim usersdata As New List(Of INFRA.UserData)
            For Each usr In DataGridView1.DataSource
                usersdata.Add(DirectCast(usr, INFRA.User).UserData)
            Next
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = usersdata
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            Dim dr As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            TextBox2.Text = dr.Cells(0).Value.ToString
            TextBox3.Text = dr.Cells(1).Value.ToString
            MaskedTextBox1.Text = dr.Cells(2).Value.ToString
            MaskedTextBox2.Text = dr.Cells(3).Value.ToString
            DateTimePicker1.Value = dr.Cells(5).Value
            ComboBox1.SelectedItem = dr.Cells(4).Value
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Adm_Usuarios_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = False
    End Sub



#End Region

End Class