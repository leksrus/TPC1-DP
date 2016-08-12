Public Class UserManagement
    'Public Function CreateUser(usuario As BE.User) As String
    '    Dim login As New DAL.Mp_usuario
    '    Dim ok As Integer
    '    ok = login.Insertar(usuario)
    '    If ok = 1 Then
    '        Return "Usuario Registrado"
    '    Else
    '        Return "Usuario no se pudo registrar"
    '    End If
    'End Function

    'Public Function ComparTo(ususario As BE.User) As String
    '    Dim q As BE.User
    '    Dim mp_user As New DAL.Mp_usuario
    '    Dim seg As New SEC.CryptoManager
    '    Dim tmpuser As List(Of BE.User) = mp_user.Seleccionar(ususario)
    '    Try
    '        q = (From usr In tmpuser Where usr.name = ususario.name AndAlso seg.Decrypt(usr.password) = ususario.password
    '             Select usr).FirstOrDefault
    '        If q IsNot Nothing Then
    '            Return "Login Correcto"
    '        End If
    '    Catch ex As Exception
    '        q = Nothing
    '    End Try
    '    Return "Login Invalido"
    'End Function
End Class
