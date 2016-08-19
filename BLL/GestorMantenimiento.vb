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

    Public Function HacerBackup(fullbk As Microsoft.SqlServer.Management.Smo.Backup, bklog As INFRA.BackupDB) As String
        Dim mp_backup As New DAL.Mp_backup
        Dim ok As String
        Dim oklog As Integer
        ok = mp_backup.Backup(fullbk)
        If ok.Equals("") Then
            oklog = mp_backup.Insertar(bklog)
            If oklog = 1 Then
                Return "Backup Completado y log guardado "
            Else
                Return "Backup Completado y guardado de log fallo "
            End If
        End If
        Return "Backup Fallo: " + ok
    End Function

    Public Function HacerRestore(restorefile As Microsoft.SqlServer.Management.Smo.Restore) As String

    End Function

    Public Function ListarBackups(bklog As INFRA.BackupDB) As List(Of INFRA.BackupDB)
        Dim mp_backup As New DAL.Mp_backup
        Dim logs As List(Of INFRA.BackupDB) = mp_backup.Seleccionar(bklog)
        Return logs
    End Function

End Class
