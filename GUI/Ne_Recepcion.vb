Imports System.ComponentModel

Public Class Ne_Recepcion
    Private cliente As Negocio.Cliente = Nothing
    Private deporte As Negocio.Deporte = Nothing

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
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_recep.ValidarIngreso(cliente)
            'Dim clientes As New List(Of Negocio.Cliente)
            'For Each tk As Negocio.Ticket In tickets
            '    clientes.Add(tk.Cliente)
            '    DataGridView1.DataSource = Nothing
            '    DataGridView1.DataSource = clientes
            'Next
            DataGridView1.ClearSelection()
            DataGridView2.ClearSelection()
            RemoveHandler gest_recep.ValidarPagoVencido, AddressOf ValidacionPagoVencido
            RemoveHandler gest_recep.ValidarPagoActivo, AddressOf ValidacionPagoActivo
            Button4.Enabled = Enabled
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

    Private Sub ValidacionPagoActivo(dep As List(Of Negocio.Deporte))
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = dep
        DataGridView2.Columns(0).Visible = False
    End Sub

    Private Sub ValidacionPagoVencido(msg As String)
        Button4.Enabled = False
        Dim gestor_leng As New SL.GestorLenguaje
        MessageBox.Show(msg, gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        gestor_leng = Nothing
    End Sub
    Private Sub Ne_Recepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Mask = "00000"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        ValidarPermisos()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            cliente = Nothing
            cliente = DirectCast(DataGridView1.DataSource(e.RowIndex), Negocio.Cliente)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ok As Boolean = False
        Dim gest_recep As New BL.Gestion_Recepcion
        Dim gestor_leng As New SL.GestorLenguaje
        Dim gest_sistem As New SL.GestorSistema
        AddHandler gest_recep.ValidarClasesDisp, AddressOf ValidarClasesDisp
        If cliente IsNot Nothing AndAlso deporte IsNot Nothing Then
            ok = gest_recep.ValidarCuota(cliente, deporte)
        Else
            MessageBox.Show(gestor_leng.ChangeLangMsg("MarcarIngreso", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If ok Then
            AddHandler gest_recep.ValidarIngresoRealizado, AddressOf ValidarIngresoRealizado
            Dim mem As New Negocio.Membresia
            mem.Cliente = cliente
            mem.Deporte = deporte
            mem.asistencia = DateTime.Now
            gest_sistem.GrabarBitacora(INFRA.TypeError.access_registry, Me.Name)
            MessageBox.Show(gest_recep.RegistrarIngreso(mem), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            RemoveHandler gest_recep.ValidarIngresoRealizado, AddressOf ValidarIngresoRealizado
        End If
        RemoveHandler gest_recep.ValidarClasesDisp, AddressOf ValidarClasesDisp
        cliente = Nothing
        deporte = Nothing
        gest_recep = Nothing
        gestor_leng = Nothing
        DataGridView1.DataSource = Nothing
        DataGridView2.DataSource = Nothing
    End Sub

    Private Sub ValidarClasesDisp(msg As String)
        Dim gestor_leng As New SL.GestorLenguaje
        MessageBox.Show(msg, gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        gestor_leng = Nothing
    End Sub

    Public Sub ValidarIngresoRealizado(vr As Negocio.VistaRecep)
        ListBox1.Items.Add(vr)
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            deporte = Nothing
            deporte = DirectCast(DataGridView2.DataSource(e.RowIndex), Negocio.Deporte)
        End If
    End Sub

    Private Sub ValidarPermisos()
        Dim gest_sistem As New SL.GestorSistema
        Dim p1 As New INFRA.Patente
        Dim p2 As New INFRA.Patente
        Dim p3 As New INFRA.Patente
        p1.codigo = "NR002"
        p1.descripcion = "Registrar Cliente"
        p2.codigo = "NR003"
        p2.descripcion = "Inscribir Cliente"
        p3.codigo = "NR004"
        p3.descripcion = "Marcar Ingreso"
        Button1.Enabled = gest_sistem.IsInRol(p1, INFRA.SesionManager.CrearSesion.User)
        Button2.Enabled = gest_sistem.IsInRol(p1, INFRA.SesionManager.CrearSesion.User)
        Button3.Enabled = gest_sistem.IsInRol(p1, INFRA.SesionManager.CrearSesion.User)
        gest_sistem = Nothing
    End Sub
End Class