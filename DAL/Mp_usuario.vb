Imports System.Data.SqlClient

Public Class Mp_usuario

    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar() As List(Of INFRA.User)

    End Function

    Public Function Seleccionar(usuario As INFRA.User) As INFRA.User
        Dim nickname As New INFRA.User
        Dim userdate As New INFRA.UserData
        nickname.UserData = userdate
        Dim mp_lng As New Mp_lenguaje(_acceso)
        Dim lngmessages As List(Of INFRA.Language) = mp_lng.Seleccionar
        Dim tabla As DataTable
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        tabla = _acceso.Leer("Validar_usuario", parametros)
        For Each row In tabla.Rows
            nickname.name = row("nickname")
            nickname.password = row("password")
            nickname.estado = row("estado")
            nickname.Language = lngmessages.Where(Function(lng) lng.id_idioma = row("id_idioma")).FirstOrDefault
            'nickname.Language = (From lng In lngmessages Where lng.id_idioma = row("id_idioma")
            '                     Select lng).FirstOrDefault
            nickname.dvh = row("dvh")
            nickname.UserData.nombre = row("nombre")
            nickname.UserData.apellido = row("apellido")
            nickname.UserData.dni = row("DNI")
            nickname.UserData.telefono = row("telefono")
            nickname.UserData.cargo = row("cargo")
            nickname.UserData.fecha_ingreso = row("fecha_ingreso")
        Next
        Return nickname
    End Function

    Public Function Insertar(usuario As INFRA.User) As Integer
        Dim parametros(10) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        parametros(1) = _acceso.CrearParametros("@password", usuario.password)
        parametros(2) = _acceso.CrearParametros("@estado", usuario.estado)
        parametros(3) = _acceso.CrearParametros("@dvh", usuario.dvh)
        parametros(4) = _acceso.CrearParametros("@nombre", usuario.UserData.nombre)
        parametros(5) = _acceso.CrearParametros("@apellido", usuario.UserData.apellido)
        parametros(6) = _acceso.CrearParametros("@dni", usuario.UserData.dni)
        parametros(7) = _acceso.CrearParametros("@telefono", usuario.UserData.telefono)
        parametros(8) = _acceso.CrearParametros("@cargo", usuario.UserData.cargo)
        parametros(9) = _acceso.CrearParametros("@fecha_ingreso", usuario.UserData.fecha_ingreso)
        parametros(10) = _acceso.CrearParametros("@id_idioma", usuario.Language.id_idioma)
        Dim ok As Integer = _acceso.Escribir("Crear_usuario", parametros)
        If ok > 0 Then
            _acceso.ConfirmarTransaccion()
        Else
            _acceso.CancelarTransaccion()
        End If
        Return ok
    End Function

    Public Function Modificar(usuario As INFRA.User) As Integer

    End Function


End Class
