Public Class GestorMantenimiento
    Public Function ValidarUsuario(usuario As INFRA.User) As Boolean
        Dim acceso As Boolean = False
        Dim encriptador As New INFRA.CryptoManager
        Using mp_usuario = New DAL.Mp_usuario
            Dim nickname As INFRA.User = mp_usuario.Seleccionar(usuario)
            If nickname IsNot Nothing Then
                If nickname.name = usuario.name AndAlso encriptador.Decrypt(nickname.password) = usuario.password _
                    AndAlso nickname.estado = True Then
                    acceso = True
                End If
            End If
        End Using
        Return acceso
    End Function

    Public Function RegistrarUsuario(usuario As INFRA.User) As Boolean
        Dim estado As Boolean = False
        Dim ok As Integer = 0
        Using mp_user = New DAL.Mp_usuario
            ok = mp_user.Insertar(usuario)
            If ok = 1 Then
                estado = True
            End If
        End Using
        Return estado
    End Function
End Class
