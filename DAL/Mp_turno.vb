Imports System.Data.SqlClient
Public Class Mp_turno
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(_ac As Acceso)
        _acceso = _ac
    End Sub

    Public Function Seleccionar(undeporte As Negocio.Deporte) As List(Of Negocio.Turno)
        Dim horarios As New List(Of Negocio.Turno)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@nombre_deporte", undeporte.nombre)
        Dim tabla As DataTable = _acceso.Leer("Turnos_deporte", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim turno As New Negocio.Turno
            turno.dia = reg("dia")
            turno.hora = reg("hora")
            horarios.Add(turno)
        Next
        Return horarios
    End Function
End Class
