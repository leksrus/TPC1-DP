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
            ej.nombre_ejercicio = reg("nombre_ejercicio")
            ej.num_dia = reg("dia_entrenamiento")
            ej.observacion = reg("observacion")
            ejercicios.Add(ej)
        Next
        Return ejercicios
    End Function
End Class
