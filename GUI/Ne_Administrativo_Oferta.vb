Public Class Ne_Administrativo_Oferta

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

#Region "Eventos"
    Private Sub Ne_Administrativo_Oferta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambioIdioma()
        CargarTipoOferta()
        Dim gest_recep As New BL.Gestion_Recepcion
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = gest_recep.ListarDeportes
        DateTimePicker1.MinDate = Date.Now
        DateTimePicker2.MinDate = Date.Now
        gest_recep = Nothing
    End Sub

    Private Sub CargarTipoOferta()
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento_2x1)
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento10)
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento20)
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento30)
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento40)
        ComboBox1.Items.Add(Negocio.TipoOferta.descuento50)
        ComboBox1.SelectedIndex = 0
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
            End If
        Next
        Me.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, "Form")
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gestor_leng As New SL.GestorLenguaje
        Dim gest_sistem As New SL.GestorSistema
        If SL.GestorSistema.ValidarEspacio(TextBox1.Text) Then
            Dim oferta As New Negocio.Oferta
            Dim gest_coor As New BL.Gestion_Administracion
            oferta.fechavigencia = DateTimePicker1.Value
            oferta.fecha_fin = DateTimePicker2.Value
            oferta.TipoOferta = ComboBox1.SelectedItem
            oferta.Estado = Negocio.Estado.pendiente
            oferta.detalles = TextBox1.Text
            oferta.Deporte = DirectCast(ComboBox2.SelectedItem, Negocio.Deporte)
            gest_sistem.GrabarBitacora(INFRA.TypeError.desc_registry, Me.Name)
            MessageBox.Show(gest_coor.CargarOferta(oferta))
        Else
            MessageBox.Show(gestor_leng.ChangeLangMsg("CargarOferta", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        gestor_leng = Nothing
        gest_sistem = Nothing
    End Sub
End Class