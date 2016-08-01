Imports System.Data.SqlClient

Public Class Mp_usuario

    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar(usuario As BE.User) As List(Of BE.User)
        Dim nickname As New BE.User
        Dim listausuarios As New List(Of BE.User)
        Dim tabla As DataTable
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        tabla = _acceso.Leer("Validar_usuario", parametros)
        For Each row In tabla.Rows
            nickname.name = row("nickname")
            nickname.password = row("password")
            listausuarios.Add(nickname)
        Next
        Return listausuarios
    End Function


    Public Function Actualizar(usuario As BE.User) As Integer


    End Function

    Public Function Insertar(usuario As BE.User) As Integer
        Dim seguridad As New SEC.CryptoManager
        Dim parametros(1) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        parametros(1) = _acceso.CrearParametros("@password", seguridad.Encrypt(usuario.password))
        Return _acceso.Escribir("Crear_usuario", parametros)
    End Function
End Class
