Imports System.Data.SqlClient
Public Class Mp_cliente
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar(uncliente As Negocio.Cliente) As List(Of Negocio.Cliente)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@idtarjeta", uncliente.idtarjeta)
        Dim clientes As New List(Of Negocio.Cliente)
        Dim tabla As DataTable = _acceso.Leer("Buscar_Cliente", parametros)
        For Each row As DataRow In tabla.Rows
            Dim cliente As New Negocio.Cliente
            cliente.idtarjeta = row("idtarjeta")
            cliente.nombre = row("nombre")
            cliente.apellido = row("apellido")
            cliente.dni = row("dni")
            cliente.direccion = row("direccion")
            cliente.email = row("email")
            cliente.fecha_nacimiento = row("fecha_nacimiento")
            cliente.telefono = row("telefono")
            clientes.Add(cliente)
        Next
        Return clientes
    End Function

    Public Function Insertar(uncliente As Negocio.Cliente) As Integer
        Dim parametros(7) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@idtarjeta", uncliente.idtarjeta)
        parametros(1) = _acceso.CrearParametros("@nombre", uncliente.nombre)
        parametros(2) = _acceso.CrearParametros("@apellido", uncliente.apellido)
        parametros(3) = _acceso.CrearParametros("@dni", uncliente.dni)
        parametros(4) = _acceso.CrearParametros("@direccion", uncliente.direccion)
        parametros(5) = _acceso.CrearParametros("@email", uncliente.email)
        parametros(6) = _acceso.CrearParametros("@fecha_nacimiento", uncliente.fecha_nacimiento)
        parametros(7) = _acceso.CrearParametros("@telefono", uncliente.telefono)
        Return _acceso.Escribir("Registrar_Cliente", parametros)
    End Function

    Public Function Modificar(uncliente As Negocio.Cliente) As Integer
        Dim parametros(7) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@idtarjeta", uncliente.idtarjeta)
        parametros(1) = _acceso.CrearParametros("@nombre", uncliente.nombre)
        parametros(2) = _acceso.CrearParametros("@apellido", uncliente.apellido)
        parametros(3) = _acceso.CrearParametros("@dni", uncliente.dni)
        parametros(4) = _acceso.CrearParametros("@direccion", uncliente.direccion)
        parametros(5) = _acceso.CrearParametros("@email", uncliente.email)
        parametros(6) = _acceso.CrearParametros("@fecha_nacimiento", uncliente.fecha_nacimiento)
        parametros(7) = _acceso.CrearParametros("@telefono", uncliente.telefono)
        Return _acceso.Escribir("Modificar_Cliente", parametros)
    End Function
End Class
