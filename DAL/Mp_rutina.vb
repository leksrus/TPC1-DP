Imports System.Data.SqlClient

Public Class Mp_rutina
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub
    Friend Sub New(_acc As Acceso)
        _acceso = _acc
    End Sub

    Public Function Seleccionar() As List(Of Negocio.Rutina)
        Dim rutinas As New List(Of Negocio.Rutina)
        Dim tabla As DataTable = _acceso.Leer("Traer_todas_rutinas", Nothing)
        For Each reg As DataRow In tabla.Rows
            Dim rt As New Negocio.Rutina
            rt.id_rutina = reg("id_rutina")
            rt.nombre_profesor = reg("nombre_prof")
            rt.Tipo_rutina = reg("nombre_rutina")
            rutinas.Add(rt)
        Next
        Return rutinas
    End Function

    Public Function Seleccionar(uncliente As Negocio.Cliente) As List(Of Negocio.Rutina)
        Dim rutinas As New List(Of Negocio.Rutina)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_tarjeta", uncliente.idtarjeta)
        Dim tabla As DataTable = _acceso.Leer("Traer_rutina", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim rt As New Negocio.Rutina
            rt.Cliente = uncliente
            rt.id_rutina = reg("id_rutina")
            rt.nombre_profesor = reg("nombre_prof")
            rt.Tipo_rutina = reg("nombre_rutina")
            rutinas.Add(rt)
        Next
        Return rutinas
    End Function

    Public Function Insertar(rutina As Negocio.Rutina) As Integer
        Dim parametros(2) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@idtarjeta", rutina.Cliente.idtarjeta)
        parametros(1) = _acceso.CrearParametros("@nombre_prof", rutina.nombre_profesor)
        parametros(2) = _acceso.CrearParametros("@nombre_rutina", rutina.Tipo_rutina)
        Return _acceso.Escribir("Crear_rutina", parametros)
    End Function
End Class
