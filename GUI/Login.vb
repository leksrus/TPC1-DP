Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using usuario = New INFRA.User
            Dim ges_manten As New BLL.GestorMantenimiento
            Dim ges_lng As New BLL.GestorLenguaje
            usuario.name = TextBox1.Text
            usuario.password = TextBox2.Text
            If ValidarText(TextBox1) AndAlso ValidarText(TextBox2) Then
                If ges_manten.ValidarUsuario(usuario) Then
                    MessageBox.Show(ges_lng.ChangeLangMsg("Login", 1, GlobalVar.tipodelenguaje))
                    Me.Hide()
                Else
                    MessageBox.Show(ges_lng.ChangeLangMsg("Login", 2, GlobalVar.tipodelenguaje))
                End If
            Else
                MessageBox.Show(ges_lng.ChangeLangMsg("Login", 3, GlobalVar.tipodelenguaje))
            End If
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MdiParent.Close()
    End Sub

    Private Function ValidarText(text As TextBox) As Boolean
        If Not String.IsNullOrWhiteSpace(text.Text) Then
            Return True
        End If
        Return False
    End Function


End Class