Public Class MDI
    Dim login As Login
    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If login Is Nothing Then
            login = New Login
        End If
        login.MdiParent = Me
        login.Show()
    End Sub
End Class
