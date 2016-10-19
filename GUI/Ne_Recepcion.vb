Public Class Ne_Recepcion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm_alta_cliente As Ne_Rec_AltaCl = Nothing
        frm_alta_cliente = New Ne_Rec_AltaCl
        frm_alta_cliente.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm_inscribir_cliente As Ne_Recepcion_Insc = Nothing
        frm_inscribir_cliente = New Ne_Recepcion_Insc
        frm_inscribir_cliente.ShowDialog()
    End Sub

End Class