Imports System.Data.SqlClient
Public Class Mp_membresia
    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(_acc As Acceso)
        _acceso = _acc
    End Sub

    Public Function Seleccionar(uncliente As Negocio.Cliente) As List(Of Negocio.Membresia)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_tarjeta", uncliente.idtarjeta)
        Dim membresias As New List(Of Negocio.Membresia)
        Dim tabla As DataTable = _acceso.Leer("Validar_asistencia", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim mem As New Negocio.Membresia
            mem.Cliente = New Negocio.Cliente
            mem.Deporte = New Negocio.Deporte
            mem.asistencia = reg("asistencia")
            mem.Cliente.nombre = reg(1)
            mem.Cliente.apellido = reg("apellido")
            mem.Cliente.dni = reg("dni")
            mem.Cliente.fecha_nacimiento = reg("fecha_nacimiento")
            mem.Cliente.direccion = reg("direccion")
            mem.Cliente.email = reg("email")
            mem.Cliente.idtarjeta = reg("idtarjeta")
            mem.Cliente.telefono = reg("telefono")
            mem.Deporte.id_deporte = reg("id_deporte")
            mem.Deporte.nombre = reg(11)
            mem.Deporte.precio = reg("precio")
            mem.Deporte.tipo = reg("tipo")
            membresias.Add(mem)
        Next
        Return membresias
    End Function

    Public Function Insertar(unmem As Negocio.Membresia) As Integer
        Dim parametros(2) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_cliente", unmem.Cliente.idtarjeta)
        parametros(1) = _acceso.CrearParametros("@id_deporte", unmem.Deporte.id_deporte)
        parametros(2) = _acceso.CrearParametros("@fecha", unmem.asistencia)
        Return _acceso.Escribir("Marcar_ingreso", parametros)
    End Function

End Class
