Public Class Adm_Usuarios
    Dim gestor_leng As New BLL.GestorLenguaje
    Public lenguajes As List(Of INFRA.InterfaceMsg) = gestor_leng.GetLanguages

    Private Sub CambiarIdioma()
        For Each lbl In Me.Controls
            If TypeOf lbl Is Label Then
                Dim l = DirectCast(lbl, Label)
                l.Text = (From lng In lenguajes Where lng.id_control = l.Name AndAlso lng.Language.id_idioma = 2 Select lng.texto).First
            End If
        Next
        For Each btn In Me.Controls
            If TypeOf btn Is Button Then
                Dim b = DirectCast(btn, Button)
                b.Text = (From btns In lenguajes Where btns.id_control = b.Name AndAlso btns.Language.id_idioma = 2 Select btns.texto).FirstOrDefault
            End If
        Next
    End Sub

End Class