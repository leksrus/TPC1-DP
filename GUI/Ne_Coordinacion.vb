Imports System.ComponentModel

Public Class Ne_Coordinacion
    Dim oferta As Negocio.Oferta = Nothing

#Region "Eventos"
    Private Sub Ne_Coord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim ges_rec As New BL.Gestion_Recepcion
        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = ges_rec.ListarDeportes
        Button1.Enabled = False
        Button3.Enabled = False
        ges_rec = Nothing
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Button1.Enabled = True
        Button3.Enabled = True
        If e.RowIndex >= 0 Then
            Dim dr As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            oferta = New Negocio.Oferta
            oferta.Deporte = dr.Cells(6).Value
            oferta.fechavigencia = dr.Cells(2).Value
            oferta.fecha_fin = dr.Cells(3).Value
            oferta.TipoOferta = dr.Cells(1).Value
            oferta.id_oferta = dr.Cells(0).Value
            oferta.detalles = dr.Cells(4).Value
            oferta.Estado = dr.Cells(5).Value
        End If
    End Sub

#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_coor As New BL.Gestion_Administracion
        Dim ges_lng As New SL.GestorLenguaje
        If RadioButton1.Checked Then
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_coor.VerOfertas(Nothing, DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
            DataGridView1.Columns(0).Visible = False
        ElseIf RadioButton2.Checked Then
            Dim ofe As New Negocio.Oferta
            ofe.Estado = Negocio.Estado.pendiente
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_coor.VerOfertas(ofe, DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
            DataGridView1.Columns(0).Visible = False
            ofe = Nothing
        ElseIf RadioButton3.Checked Then
            Dim ofe As New Negocio.Oferta
            ofe.Estado = Negocio.Estado.suspendido
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_coor.VerOfertas(ofe, DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
            DataGridView1.Columns(0).Visible = False
            ofe = Nothing
        Else
            MessageBox.Show(ges_lng.ChangeLangMsg("Coordinacion", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), ges_lng.ChangeLangMsg("Login", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        gest_coor = Nothing
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gest_lng As New SL.GestorLenguaje
        Dim gest_sistem As New SL.GestorSistema
        If oferta.Estado = Negocio.Estado.pendiente OrElse oferta.Estado = Negocio.Estado.suspendido Then
            Dim gest_coor As New BL.Gestion_Administracion
            oferta.Estado = Negocio.Estado.aprobado
            gest_sistem.GrabarBitacora(INFRA.TypeError.desc_aprobe, Me.Name)
            MessageBox.Show(gest_coor.CambiarEstadoOferta(oferta))
            gest_coor = Nothing
        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("Coordinacion", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("Login", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        oferta = Nothing
        gest_lng = Nothing
        Button1.Enabled = False
        Button3.Enabled = False
        DataGridView1.DataSource = Nothing
        gest_sistem = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim gest_lng As New SL.GestorLenguaje
        If oferta.Estado <> Negocio.Estado.suspendido Then
            Dim gest_coor As New BL.Gestion_Administracion
            oferta.Estado = Negocio.Estado.suspendido
            MessageBox.Show(gest_coor.CambiarEstadoOferta(oferta))
            gest_coor = Nothing
        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("Coordinacion", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("Login", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        oferta = Nothing
        gest_lng = Nothing
        Button1.Enabled = False
        Button3.Enabled = False
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub Ne_Coordinacion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class