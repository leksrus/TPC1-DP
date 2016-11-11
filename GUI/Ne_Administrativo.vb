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
        Dim reporteBar As Dictionary(Of Negocio.Deporte, Integer) = gest_administ.HacerReporteBarra(DateTimePicker1.Value, DateTimePicker2.Value)
        For Each rp As KeyValuePair(Of Negocio.Deporte, Integer) In reporteBar
            Chart1.Series("Cantidad Total").Points.AddXY(rp.Key.nombre, rp.Value)
            Chart1.Series("Cantidad Total")("PixelPointWidth") = "20"
            Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        Next
        Dim reporteTor As Dictionary(Of Negocio.Deporte, Single) = gest_administ.HacerReporteTorta(DateTimePicker1.Value, DateTimePicker2.Value)
        For Each rep As KeyValuePair(Of Negocio.Deporte, Single) In reporteTor
            Chart2.Series("Recaudo").Points.AddXY(rep.Key.nombre, rep.Value)
            Chart2.Series("Recaudo").IsValueShownAsLabel = True
        Next
    End Sub

    Private Sub Ne_Administrativo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

End Class