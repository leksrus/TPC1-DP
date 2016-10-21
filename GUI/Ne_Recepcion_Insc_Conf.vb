Public Class Ne_Recepcion_Insc_Conf
    Private _ticket As Negocio.Ticket
    Public Sub New(unticket As Negocio.Ticket)
        _ticket = unticket
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Label1.Text = _ticket.Cliente.nombre
        Label2.Text = _ticket.Cliente.apellido
        Label3.Text = _ticket.Cliente.dni
        Label4.Text = _ticket.Deporte.nombre
        Label5.Text = _ticket.cantidad_clases
        Label6.Text = _ticket.fecha_pago
        Label7.Text = _ticket.monto
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gestor_recep As BL.Gestion_Recepcion = Nothing
        Dim ges_lng As SL.GestorLenguaje = Nothing
        ges_lng = New SL.GestorLenguaje
        gestor_recep = New BL.Gestion_Recepcion
        MessageBox.Show(gestor_recep.RegistrarPago(_ticket), ges_lng.ChangeLangMsg("Login", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ges_lng = Nothing
        gestor_recep = Nothing
        _ticket = Nothing
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class