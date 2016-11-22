Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using usuario = New INFRA.User
            Dim ges_manten As New SL.GestorMantenimiento
            Dim ges_lng As New SL.GestorLenguaje
            usuario.name = TextBox1.Text
            usuario.password = TextBox2.Text
            If ValidarText(TextBox1) AndAlso ValidarText(TextBox2) Then
                If ges_manten.ValidarUsuario(usuario) Then
                    Dim gestsistema As New SL.GestorSistema
                    gestsistema.GrabarBitacora(INFRA.TypeError.login, Me.Name)
                    MessageBox.Show(ges_lng.ChangeLangMsg("Login", 1, GlobalVar.tipodelenguaje), ges_lng.ChangeLangMsg("Login", 4, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MDI.loginok = True
                    GlobalVar.tipodelenguaje = INFRA.SesionManager.CrearSesion.User.Language.id_idioma
                    Me.Close()
                    TextBox1.Focus()
                Else
                    MessageBox.Show(ges_lng.ChangeLangMsg("Login", 2, GlobalVar.tipodelenguaje), ges_lng.ChangeLangMsg("Login", 4, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Focus()
                End If
            Else
                MessageBox.Show(ges_lng.ChangeLangMsg("Login", 3, GlobalVar.tipodelenguaje), ges_lng.ChangeLangMsg("Login", 4, GlobalVar.tipodelenguaje), MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.BackColor = Color.Red
                TextBox2.BackColor = Color.Red
                Label1.Focus()
            End If
            TextBox1.Clear()
            TextBox2.Clear()
            'TextBox1.Focus()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
    End Sub

    Private Function ValidarText(text As TextBox) As Boolean
        If Not String.IsNullOrWhiteSpace(text.Text) Then
            Return True
        End If
        Return False
    End Function

End Class