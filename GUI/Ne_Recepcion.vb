Imports System.ComponentModel

Public Class Ne_Recepcion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm_alta_cliente As Ne_Recepcion_AltaCli = Nothing
        frm_alta_cliente = New Ne_Recepcion_AltaCli
        frm_alta_cliente.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm_inscribir_cliente As Ne_Recepcion_Insc = Nothing
        frm_inscribir_cliente = New Ne_Recepcion_Insc
        frm_inscribir_cliente.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MaskedTextBox1.MaskCompleted Then
            Dim gest_recep As New BL.Gestion_Recepcion
            AddHandler gest_recep.ValidarPagoVencido, AddressOf ValidacionPagoVencido
            AddHandler gest_recep.ValidarPagoActivo, AddressOf ValidacionPagoActivo
            Dim cliente As New Negocio.Cliente
            cliente.idtarjeta = MaskedTextBox1.Text
            Dim tickets As List(Of Negocio.Ticket) = gest_recep.ValidarIngreso(cliente)
            Dim clientes As New List(Of Negocio.Cliente)
            For Each tk As Negocio.Ticket In tickets
                clientes.Add(tk.Cliente)
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = clientes
            Next
            DataGridView1.ClearSelection()
            RemoveHandler gest_recep.ValidarPagoVencido, AddressOf ValidacionPagoVencido
            RemoveHandler gest_recep.ValidarPagoActivo, AddressOf ValidacionPagoActivo
        Else
            Dim gestor_leng As New SL.GestorLenguaje
            MessageBox.Show(gestor_leng.ChangeLangMsg("BuscarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            gestor_leng = Nothing
        End If
        MaskedTextBox1.Clear()
    End Sub

    Private Sub Ne_Recepcion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = False
    End Sub

    Private Sub ValidacionPagoActivo(tks As List(Of Negocio.Ticket))
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = tks
        DataGridView2.Columns(0).Visible = False
    End Sub

    Private Sub ValidacionPagoVencido(msg As String)
        Button4.Enabled = False
        MessageBox.Show(msg)
    End Sub
    Private Sub Ne_Recepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Mask = "00000"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub
End Class