Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Ne_Administrativo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmoferta As Ne_Administrativo_Oferta = Nothing
        frmoferta = New Ne_Administrativo_Oferta
        frmoferta.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gest_administ As New BL.Gestion_Administracion
        Dim gest_recep As New BL.Gestion_Recepcion
        Chart1.DataSource = gest_administ.HacerReporte(DateTimePicker1.Value, DateTimePicker2.Value)
        'Chart1.Series("Cantidad Total").XValueMember = "fecha_pago"
        'Chart1.Series("Cantidad Total").YValueMembers = "monto"
        Dim deportes As List(Of Negocio.Deporte) = gest_recep.ListarDeportes
        Chart1.DataSource = deportes
        Chart1.Series("Cantidad Total").XValueMember = "nombre"
        Chart1.Series("Cantidad Total").YValueMembers = "precio"



        Chart1.DataBind()

        'For Each tk In tickets
        '    Dim serie As Series = Chart1.Series.Add(tk.Deporte.nombre)
        '    serie.Points.Add(tk.monto)
        '    'Chart1.Series("Cantidad Total").Points.AddXY(tk.Deporte.nombre, tk.monto)

        'Next
        'Chart1.Series(0).XValueMember = "nombre"
        'Chart1.Series(0).YValueMembers = "monto"
        'Chart1.Titles.Add("Cantidad de Inscripciones")
        'Chart1.DataBind()

    End Sub

    Private Sub Ne_Administrativo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

End Class