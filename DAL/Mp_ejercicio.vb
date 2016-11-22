Imports System.Data.SqlClient

Public Class Mp_ejercicio
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(_acc As Acceso)
        _acceso = _acc
    End Sub

    Public Function Seleccionar(rutina As Negocio.Rutina) As List(Of Negocio.Ejercicio)
        Dim ejercicios As New List(Of Negocio.Ejercicio)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_rutina", rutina.id_rutina)
        Dim tabla As DataTable = _acceso.Leer("Traer_Ejercicios", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim ej As New Negocio.Ejercicio
            ej.Rutina = rutina
            ej.id_ejercicio = reg("id_ejercicio")
            ej.tipo_ejercicio = reg("nombre_ejercicio")
            ej.num_dia = reg("dia_entrenamiento")
            ej.observacion = reg("observacion")
            ejercicios.Add(ej)
        Next
        Return ejercicios
    End Function

    Public Function Insertar(ej As Negocio.Ejercicio) As Integer
        _acceso.AbrirTransaccion()
        Dim ok As Integer = 0
        Dim mp_ruitina As New Mp_rutina(_acceso)
        Dim rutinas As List(Of Negocio.Rutina) = mp_ruitina.Seleccionar
        Dim q = rutinas.Max(Function(id) id.id_rutina)
        Dim parametros(3) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_rutina", q)
        parametros(1) = _acceso.CrearParametros("@dia_entrenamiento", ej.num_dia)
        parametros(2) = _acceso.CrearParametros("@nombre_ejercicio", ej.tipo_ejercicio)
        parametros(3) = _acceso.CrearParametros("@observacion", ej.observacion)
        ok += _acceso.Escribir("Cargar_ejercicios", parametros)
        If ok > 0 Then
            _acceso.ConfirmarTransaccion()
        Else
            _acceso.CancelarTransaccion()
        End If
        Return ok
    End Function

    Public Function Borrar(ej As Negocio.Ejercicio) As Integer
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_ejercicio", ej.id_ejercicio)
        Return _acceso.Escribir("Quitar_ejercicio", parametros)
    End Function
End Class
