﻿Public Class GestorMantenimiento
#Region "Gestion de usuario"
    Public Function ValidarUsuario(usuario As INFRA.User) As Boolean
        Dim encriptador As New INFRA.CryptoManager
        Dim mp_usuario = New DAL.Mp_usuario
        Dim users As List(Of INFRA.User) = mp_usuario.Seleccionar(usuario)
        For Each usr In users
            If usr IsNot Nothing Then
                If usr.name = usuario.name AndAlso encriptador.Decrypt(usr.password) = usuario.password _
                        AndAlso usr.estado = True Then
                    Dim mp_fam As New DAL.Mp_familia
                    Dim permisosusr As List(Of INFRA.Componente) = mp_fam.Seleccionar(usr)
                    usr.permisos = ValidarPerUsr(permisosusr)
                    'se guarda el usuario logeado en el sesion manager
                    INFRA.SesionManager.CrearSesion(usr)
                    Return True
                End If
            End If
        Next
        'devuelvo V anteriormente o F si no se cumple la condicion
        Return False
    End Function


    Private Function ValidarPerUsr(pusr As List(Of INFRA.Componente)) As List(Of INFRA.Componente)
        Dim mp_fam As New DAL.Mp_familia
        Dim permisossusr As New List(Of INFRA.Componente)
        Dim permisos As List(Of INFRA.Componente) = mp_fam.Seleccionar
        For Each per As INFRA.Componente In permisos
            Dim q = pusr.Where(Function(compare) compare.codigo = per.codigo).FirstOrDefault
            If q IsNot Nothing Then
                permisos.Remove(q)
            End If

            If per.List.Count > 0 Then
                'permisos = ValidarPerUsrRec(permisos, per, perusr)
            End If

        Next
        Return permisos

    End Function


    Private Function ValidarPerUsrRec(permisos As List(Of INFRA.Componente), per As INFRA.Componente, pusr As INFRA.Componente) As List(Of INFRA.Componente)
        For Each perm As INFRA.Componente In per.List
            If TypeOf perm Is INFRA.Patente Then
                If DirectCast(perm, INFRA.Patente).codigo.Equals(pusr.codigo) Then
                    permisos.Remove(perm)
                End If
            Else
                If perm.List.Count > 0 Then
                    ValidarPerUsrRec(permisos, perm, pusr)
                End If
            End If
        Next
        Return permisos
    End Function

    Public Function RegistrarUsuario(usuario As INFRA.User) As String
        Dim crypto As New INFRA.CryptoManager
        Dim mp_user = New DAL.Mp_usuario
        Dim gestorlng As New GestorLenguaje
        Dim dv As New INFRA.DV
        usuario.password = crypto.Encrypt(usuario.password)
        dv.code = crypto.ConvertToHash(usuario.name & usuario.password & usuario.estado & usuario.Language.id_idioma)
        usuario.dvh = dv.code
        Dim ok As Integer = 0
        ok = mp_user.Insertar(usuario)
        If ok = 2 Then
            Return gestorlng.ChangeLangMsg("RegistrarUsuario", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("RegistrarUsuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function ModificarUsuario(usuario As INFRA.User) As String
        Dim crypto As New INFRA.CryptoManager
        Dim mp_user = New DAL.Mp_usuario
        Dim gestorlng As New GestorLenguaje
        Dim dv As New INFRA.DV
        dv.code = crypto.ConvertToHash(usuario.name & usuario.password & usuario.estado & usuario.Language.id_idioma)
        usuario.dvh = dv.code
        Dim ok As Integer = 0
        ok = mp_user.Modificar(usuario)
        If ok = 2 Then
            Return gestorlng.ChangeLangMsg("ModificarUsuario", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("ModificarUsuario", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function BuscarUsuario(usuario As INFRA.User) As List(Of INFRA.User)
        Dim mp_user As New DAL.Mp_usuario
        Dim users As List(Of INFRA.User) = mp_user.Seleccionar(usuario)
        Return users
    End Function

    Public Function ListarUsuarios() As List(Of INFRA.User)
        Dim mp_user As New DAL.Mp_usuario
        Dim users As List(Of INFRA.User) = mp_user.Seleccionar
        Return users
    End Function

#End Region

    'Public Function RegistrarGrupo(ungrupo As INFRA.Familia) As String

    'End Function

#Region "Gestion de Backup/Restore"
    Public Function HacerBackup(bk As INFRA.BackupDB, path As String) As String
        Dim mp_backup As New DAL.Mp_backup
        Dim gest_lng As New GestorLenguaje
        Dim res = mp_backup.Backup(bk, path)
        If res Then
            mp_backup.Insertar(bk)
            Return gest_lng.ChangeLangMsg("HacerBackup", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gest_lng.ChangeLangMsg("HacerBackup", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function HacerRestore(restorefile As INFRA.BackupDB, path As String) As String
        Dim mp_backup As New DAL.Mp_backup
        Dim gest_lng As New GestorLenguaje
        Dim res = mp_backup.Restore(restorefile, path)
        If res Then
            Return ""
        Else
            Return ""
        End If
    End Function

    Public Function ListarBases() As List(Of INFRA.BackupDB)
        Dim mp_bk As New DAL.Mp_backup
        Dim dbs As List(Of INFRA.BackupDB) = mp_bk.Seleccionar
        Return dbs
    End Function

    Public Function ListarBackups(bklog As INFRA.BackupDB) As List(Of INFRA.BackupDB)
        Dim mp_backup As New DAL.Mp_backup
        Dim logs As List(Of INFRA.BackupDB) = mp_backup.Seleccionar(bklog)
        Return logs
    End Function


#End Region

End Class
