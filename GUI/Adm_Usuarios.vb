Public Class Adm_Usuarios
    Dim cargos As New List(Of String)
    Dim gestor_leng As New BLL.GestorLenguaje


    Private Sub CambiarIdioma()
        'For Each lbl In Me.Controls
        '    If TypeOf lbl Is Label Then
        '        Dim l = DirectCast(lbl, Label)
        '        l.Text = (From lng In lenguajes Where lng.id_control = l.Name AndAlso lng.Language.id_idioma = 2 Select lng.texto).First
        '    End If
        'Next
        'For Each btn In Me.Controls
        '    If TypeOf btn Is Button Then
        '        Dim b = DirectCast(btn, Button)
        '        b.Text = (From btns In lenguajes Where btns.id_control = b.Name AndAlso btns.Language.id_idioma = 2 Select btns.texto).FirstOrDefault
        '    End If
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Dim usuario As New INFRA.User
            Dim userdata As New INFRA.UserData
            Dim lenguaje As New INFRA.Language
            usuario.Language = lenguaje
            usuario.UserData = userdata
            Dim gest_manten As New BLL.GestorMantenimiento
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
                    MessageBox.Show("Seleccione idioma")
            End Select
            usuario.UserData.nombre = TextBox2.Text
            usuario.UserData.apellido = TextBox3.Text
            usuario.UserData.dni = TextBox4.Text
            usuario.UserData.telefono = TextBox5.Text
            usuario.UserData.cargo = ComboBox1.SelectedItem
            usuario.UserData.fecha_ingreso = DateTimePicker1.Value
            MessageBox.Show(gest_manten.RegistrarUsuario(usuario))
            Button1.Enabled = False
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button1.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button1.Enabled = False
    End Sub

    Private Sub Adm_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga()
    End Sub

    Private Sub carga()
        Dim lenguajes As List(Of INFRA.Language) = gestor_leng.ListarTipoIdioma
        cargos.Add("Administracion")
        cargos.Add("Coordinador")
        cargos.Add("Profesor")
        cargos.Add("Administrador")
        cargos.Add("Recepcion")
        cargos.Sort()
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = lenguajes
        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = cargos
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        carga()
        Me.Hide()
    End Sub
End Class