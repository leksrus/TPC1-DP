Public Class Ne_Profesores
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MaskedTextBox1.MaskCompleted Then
            Dim gest_recep As New BL.Gestion_Recepcion
            Dim cliente As New Negocio.Cliente
            cliente.idtarjeta = MaskedTextBox1.Text
            DataGridView1.DataSource = Nothing
            Dim tmp = gest_recep.BuscarCliente(cliente)
            DataGridView1.DataSource = tmp
            DataGridView1.ClearSelection()
            gest_recep = Nothing
        Else
            Dim gestor_leng As New SL.GestorLenguaje
            MessageBox.Show(gestor_leng.ChangeLangMsg("BuscarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            gestor_leng = Nothing
        End If
        MaskedTextBox1.Clear()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim gest_prof As New BL.Gestion_Prof
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = gest_prof.ListarRutina(DataGridView1.DataSource(e.RowIndex))
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView2.ClearSelection()
        End If
    End Sub

    Private Sub Ne_Profesores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Mask = "00000"
        Button3.Enabled = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ComboBox1.Items.Add(Negocio.Tipo_rutina.crossfit)
        ComboBox1.Items.Add(Negocio.Tipo_rutina.gym)
        ComboBox1.SelectedIndex = 0
    End Sub
End Class