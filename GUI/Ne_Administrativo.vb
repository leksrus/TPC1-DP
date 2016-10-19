Public Class Ne_Administrativo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmoferta As Ne_Administrativo_Oferta = Nothing
        frmoferta = New Ne_Administrativo_Oferta
        frmoferta.ShowDialog()
    End Sub
End Class