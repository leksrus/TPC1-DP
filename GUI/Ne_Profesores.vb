Imports System.ComponentModel

Public Class Ne_Profesores
    Dim rutina As Negocio.Rutina = Nothing
    Dim cliente As Negocio.Cliente = Nothing
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
            cliente = New Negocio.Cliente
            cliente = DataGridView1.DataSource(e.RowIndex)
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = gest_prof.ListarRutina(DataGridView1.DataSource(e.RowIndex))
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView1.ClearSelection()
            Button2.Enabled = True
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            rutina = New Negocio.Rutina
            rutina = DataGridView2.DataSource(e.RowIndex)
            rutina.Cliente = cliente
            Dim gest_prof As New BL.Gestion_Prof
            DataGridView3.DataSource = Nothing
            DataGridView3.DataSource = gest_prof.ListarEjercicios(DataGridView2.DataSource(e.RowIndex))
            Button3.Enabled = True
            'DataGridView2.Columns(0).Visible = False
            'DataGridView2.Columns(2).Visible = False
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
        Button2.Enabled = False
        Label4.Text = INFRA.SesionManager.CrearSesion.User.UserData.nombre & " " & INFRA.SesionManager.CrearSesion.User.UserData.apellido
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_sistem As New SL.GestorSistema
        Dim rutina As New Negocio.Rutina
        If cliente IsNot Nothing AndAlso ComboBox1.SelectedItem IsNot Nothing Then
            rutina.Cliente = cliente
            rutina.nombre_profesor = INFRA.SesionManager.CrearSesion.User.UserData.nombre & " " & INFRA.SesionManager.CrearSesion.User.UserData.apellido
            rutina.Tipo_rutina = ComboBox1.SelectedItem
            Dim frmprof_carga_ej As New Ne_Profesores_Rutina(rutina)
            frmprof_carga_ej.ShowDialog()
            frmprof_carga_ej = Nothing
            gest_sistem.GrabarBitacora(INFRA.TypeError.routine_reg, Me.Name)
            DataGridView1.DataSource = Nothing
            DataGridView2.DataSource = Nothing
            DataGridView3.DataSource = Nothing
            rutina = Nothing
            cliente = Nothing
        End If
        gest_sistem = Nothing
        Button2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If rutina IsNot Nothing Then
            Dim frmprof_carga_ej As New Ne_Profesores_Rutina(rutina)
            frmprof_carga_ej.ShowDialog()
            frmprof_carga_ej = Nothing
            DataGridView1.DataSource = Nothing
            DataGridView2.DataSource = Nothing
            DataGridView3.DataSource = Nothing
            rutina = Nothing
            cliente = Nothing
        End If
    End Sub

    Private Sub Ne_Profesores_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = False
    End Sub
End Class