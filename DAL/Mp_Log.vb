Imports System.Data.SqlClient
Public Class Mp_Log
    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar() As List(Of INFRA.Log)
        Dim logs As New List(Of INFRA.Log)
        Dim mp_user As New Mp_usuario(_acceso)
        Dim usuarios As List(Of INFRA.User) = mp_user.Seleccionar
        Dim tabla As DataTable = _acceso.Leer("Seleccionar_logs", Nothing)
        For Each reg In tabla.Rows
            Dim bitac As New INFRA.Log
            bitac.fechahora = reg("fecha_hora")
            bitac.TypeError = reg("type_event")
            bitac.descripcion = reg("detalles")
            bitac.dvh = reg("dvh")
            bitac.User = usuarios.Where(Function(usr) usr.name = reg("nickname")).FirstOrDefault
            logs.Add(bitac)
        Next
        Return logs
    End Function

    Public Function Seleccionar(log As INFRA.Log) As List(Of INFRA.Log)
        Dim logs As New List(Of INFRA.Log)
        Dim mp_user As New Mp_usuario(_acceso)
        Dim usuarios As List(Of INFRA.User) = mp_user.Seleccionar
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@datetimestart", log.fechahora)
        Dim tabla As DataTable = _acceso.Leer("Check_logs", parametros)
        For Each reg In tabla.Rows
            Dim bitac As New INFRA.Log
            bitac.fechahora = reg("fecha_hora")
            bitac.TypeError = reg("type_event")
            bitac.descripcion = reg("detalles")
            bitac.dvh = reg("dvh")
            bitac.User = usuarios.Where(Function(usr) usr.name = reg("nickname")).FirstOrDefault
            logs.Add(bitac)
        Next
        Return logs
    End Function


    Public Function Insertar(log As INFRA.Log) As Integer
        Dim parametros(4) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@date_time", log.fechahora)
        parametros(1) = _acceso.CrearParametros("@type_error", log.TypeError)
        parametros(2) = _acceso.CrearParametros("@detalle", log.descripcion)
        parametros(3) = _acceso.CrearParametros("@userid", log.User.name)
        parametros(4) = _acceso.CrearParametros("@dvh", log.dvh)
        Return _acceso.Escribir("Save_log", parametros)
    End Function
End Class
