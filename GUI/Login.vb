Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using usuario = New INFRA.User
            Dim ges_manten As New BLL.GestorMantenimiento
            usuario.name = TextBox1.Text
            usuario.password = TextBox2.Text
            If ges_manten.ValidarUsuario(usuario) Then
                MessageBox.Show("Login Ok")
                Me.Hide()
            Else
                MessageBox.Show("Login Invalido")
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MdiParent.Close()
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim ges_manten As New BLL.GestorMantenimiento
    '    Dim encriptador As New INFRA.CryptoManager
    '    Dim dvv As New INFRA.DVV
    '    Dim usuario As New INFRA.User
    '    usuario.name = TextBox1.Text
    '    usuario.password = encriptador.Encrypt(TextBox2.Text)
    '    usuario.estado = True
    '    Dim cadena(2) As String
    '    cadena(0) = usuario.name
    '    cadena(1) = usuario.password
    '    cadena(2) = usuario.estado
    '    usuario.dvh = dvv.ConcatString(cadena)
    '    If ges_manten.RegistrarUsuario(usuario) Then
    '        MessageBox.Show("Se Creo el Usuario")
    '    Else
    '        MessageBox.Show("Error")
    '    End If
    'End Sub
End Class