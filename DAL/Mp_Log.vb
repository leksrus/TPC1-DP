Imports System.Data.SqlClient
Public Class Mp_Log
    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar(log As INFRA.Log) As List(Of INFRA.Log)

    End Function


    Public Function Insertar(log As INFRA.Log) As Integer
        Dim parametros(4) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@date_time", log.fechahora)
        parametros(1) = _acceso.CrearParametros("@type_error", log.TypeError.ToString)
        parametros(2) = _acceso.CrearParametros("@detalle", log.descripcion)
        parametros(3) = _acceso.CrearParametros("@userid", log.User.name)
        parametros(4) = _acceso.CrearParametros("@dvh", log.dvh)
        Return _acceso.Escribir("Save_log", parametros)
    End Function
End Class
