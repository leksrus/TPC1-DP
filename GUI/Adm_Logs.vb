Public Class Adm_Logs
    Dim gestorlng As BLL.GestorLenguaje = Nothing
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim log As New INFRA.Log
        Dim gestorsistema As New BLL.GestorSistema
        log.fechahora = DateTimePicker1.Value
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = gestorsistema.VerBitacora(log)
    End Sub

    Private Sub Adm_Logs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gestorlng = New BLL.GestorLenguaje
        gestorlng.GetLogLng()
        DateTimePicker1.MaxDate = Date.Now
        DateTimePicker1.Value = Date.Now
    End Sub
End Class