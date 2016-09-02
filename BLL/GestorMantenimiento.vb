Public Class GestorMantenimiento
    Public Function ValidarUsuario(usuario As INFRA.User) As Boolean
        Dim encriptador As New INFRA.CryptoManager
        Dim mp_usuario = New DAL.Mp_usuario
        Dim nickname As INFRA.User = mp_usuario.Seleccionar(usuario)
        If nickname IsNot Nothing Then
            If nickname.name = usuario.name AndAlso encriptador.Decrypt(nickname.password) = usuario.password _
                    AndAlso nickname.estado = True Then
                'se guarda el usuario logeado en el sesion manager
                INFRA.SesionManager.CrearSesion(nickname)
                Return True
            End If
        End If
        'devuelvo V anteriormente o F si no se cumple la condicion
        Return False
    End Function

    Public Function RegistrarUsuario(usuario As INFRA.User) As String
        Dim crypto As New INFRA.CryptoManager
        Dim sistema As New INFRA.Sistema
        Dim mp_user = New DAL.Mp_usuario
        Dim cadena(2) As String
        cadena(0) = usuario.name
        cadena(1) = usuario.password
        cadena(2) = usuario.estado.ToString
        usuario.dvh = crypto.ConvertToHash(sistema.ConcatString(cadena))
        usuario.password = crypto.Encrypt(usuario.password)
        Dim ok As Integer = 0
        ok = mp_user.Insertar(usuario)
        If ok = 2 Then
            Return "Usuario Registrado"
        Else
            Return "Registro de Usuario Fallo"
        End If
    End Function

    Public Function ModificarUsuario(usuario As INFRA.User) As String

    End Function

    Public Function BuscarUsuario(usuario As INFRA.User) As INFRA.User

    End Function

    Public Function RegistrarGrupo(ungrupo As INFRA.Familia) As String

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
                Return "Backup Completado pero guardado de log fallo "
            End If
        End If
        Return "Fallo: " + ok
    End Function

    Public Function HacerRestore(restorefile As Microsoft.SqlServer.Management.Smo.Restore) As String
        Dim mp_backup As New DAL.Mp_backup
        Dim ok As String
        ok = mp_backup.Restore(restorefile)
        If ok.Equals("") Then
            Return "Restore Completado con Exito "
        End If
        Return "Fallo: " + ok
    End Function

    Public Function ListarBackups(bklog As INFRA.BackupDB) As List(Of INFRA.BackupDB)
        Dim mp_backup As New DAL.Mp_backup
        Dim logs As List(Of INFRA.BackupDB) = mp_backup.Seleccionar(bklog)
        Return logs
    End Function

End Class
