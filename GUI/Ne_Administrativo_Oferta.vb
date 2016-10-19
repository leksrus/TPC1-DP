Public Class Ne_Administrativo_Oferta

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

#Region "Eventos"
    Private Sub Ne_Administrativo_Oferta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarTipoOferta()
        Dim gest_recep As New BL.Gestion_Recepcion
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = gest_recep.ListarDeportes
        DateTimePicker1.MaxDate = Date.Now
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SL.GestorSistema.ValidarEspacio(TextBox1.Text) Then
            Dim oferta As New Negocio.Oferta
            Dim gest_coor As New BL.Gestion_Coordinacion
            oferta.fechavigencia = DateTimePicker1.Value
            oferta.fecha_fin = DateTimePicker2.Value
            oferta.TipoOferta = ComboBox1.SelectedItem
            oferta.Estado = Negocio.Estado.pendiente
            oferta.detalles = TextBox1.Text
            oferta.Deporte = DirectCast(ComboBox2.SelectedItem, Negocio.Deporte)
            MessageBox.Show(gest_coor.CargarOferta(oferta))
        End If
    End Sub
End Class