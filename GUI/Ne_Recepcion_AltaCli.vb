Public Class Ne_Rec_AltaCl
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cliente As Negocio.Cliente = Nothing
        Dim gest_recep As BL.Gestion_Recepcion = Nothing
        Dim gestor_leng As New SL.GestorLenguaje
        If SL.GestorSistema.ValidarNombreApellido(TextBox1.Text) AndAlso SL.GestorSistema.ValidarNombreApellido(TextBox2.Text) Then
            If MaskedTextBox1.MaskCompleted AndAlso MaskedTextBox2.MaskCompleted Then
                If SL.GestorSistema.ValidarEspacio(TextBox3.Text) Then
                    If SL.GestorSistema.ValidarEmail(TextBox4.Text) Then
                        cliente = New Negocio.Cliente
                        gest_recep = New BL.Gestion_Recepcion
                        If RadioButton1.Checked Then
                            If MaskedTextBox3.MaskCompleted Then
                                cliente.idtarjeta = MaskedTextBox3.Text
                                cliente.nombre = TextBox1.Text
                                cliente.apellido = TextBox2.Text
                                cliente.direccion = TextBox3.Text
                                cliente.email = TextBox4.Text
                                cliente.fecha_nacimiento = DateTimePicker1.Value
                                cliente.telefono = MaskedTextBox2.Text
                                cliente.dni = MaskedTextBox1.Text
                                MessageBox.Show(gest_recep.RegistrarCliente(cliente))
                            Else
                                MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 6, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        ElseIf RadioButton2.Checked Then
                            cliente.idtarjeta = MaskedTextBox3.Text
                            cliente.nombre = TextBox1.Text
                            cliente.apellido = TextBox2.Text
                            cliente.direccion = TextBox3.Text
                            cliente.email = TextBox4.Text
                            cliente.fecha_nacimiento = DateTimePicker1.Value
                            cliente.telefono = MaskedTextBox2.Text
                            cliente.dni = MaskedTextBox1.Text
                            MessageBox.Show(gest_recep.ModificarCliente(cliente))
                        Else
                            MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 5, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        cliente = Nothing
                        gest_recep = Nothing
                    Else
                        MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 7, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show(gestor_leng.ChangeLangMsg("CargarCliente", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        LimpiarControles()
        DesactivarControles()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_recep As BL.Gestion_Recepcion = Nothing
        Dim gestor_leng As SL.GestorLenguaje = Nothing
        Dim cliente As Negocio.Cliente = Nothing
        If MaskedTextBox3.MaskCompleted Then
            gest_recep = New BL.Gestion_Recepcion
            cliente = New Negocio.Cliente
            cliente.idtarjeta = MaskedTextBox3.Text
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_recep.BuscarCliente(cliente)
        Else
            gestor_leng = New SL.GestorLenguaje
            MessageBox.Show(gestor_leng.ChangeLangMsg("BuscarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        gest_recep = Nothing
        gestor_leng = Nothing
        cliente = Nothing
    End Sub

#Region "Manejo de controles"

    Private Sub LimpiarControles()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()
        MaskedTextBox3.Clear()
        DateTimePicker1.Value = Date.Today
    End Sub

    Private Sub ActivarControles()
        If RadioButton1.Checked Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            MaskedTextBox1.Enabled = True
            MaskedTextBox2.Enabled = True
            MaskedTextBox3.Enabled = True
            Button1.Enabled = True
            DateTimePicker1.Enabled = True
        ElseIf RadioButton2.Checked Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            MaskedTextBox1.Enabled = True
            MaskedTextBox2.Enabled = True
            MaskedTextBox3.Enabled = False
            DateTimePicker1.Enabled = True
        End If
    End Sub

    Private Sub DesactivarControles()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        MaskedTextBox1.Enabled = False
        MaskedTextBox2.Enabled = False
        Button1.Enabled = False
        DateTimePicker1.Enabled = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        LimpiarControles()
        ActivarControles()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ActivarControles()
    End Sub
#End Region


#Region "Cambio de Idioma"
    Private Sub CambioIdioma()
        Dim gest_lng As New SL.GestorLenguaje
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Label Then
                Dim it = DirectCast(ctrl, Label)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            ElseIf TypeOf ctrl Is Button Then
                Dim it = DirectCast(ctrl, Button)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            ElseIf TypeOf ctrl Is RadioButton Then
                Dim it = DirectCast(ctrl, RadioButton)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            End If
        Next
        Me.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, "Form")
    End Sub



#End Region

#Region "Eventos"
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DesactivarControles()
        If e.RowIndex >= 0 Then
            Dim dr As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            MaskedTextBox3.Text = dr.Cells(0).Value.ToString
            TextBox1.Text = dr.Cells(1).Value.ToString
            TextBox2.Text = dr.Cells(2).Value.ToString
            MaskedTextBox1.Text = dr.Cells(3).Value.ToString
            DateTimePicker1.Value = dr.Cells(4).Value
            MaskedTextBox2.Text = dr.Cells(5).Value.ToString
            TextBox4.Text = dr.Cells(6).Value.ToString
            TextBox3.Text = dr.Cells(7).Value.ToString
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Ne_Rec_AltaCl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MaskedTextBox1.Mask = "00,000,000"
        MaskedTextBox2.Mask = "0-000-00-00"
        MaskedTextBox3.Mask = "00000"
        DateTimePicker1.MaxDate = Date.Now
        DesactivarControles()
        CambioIdioma()
    End Sub


#End Region

End Class