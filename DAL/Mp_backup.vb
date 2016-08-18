Imports System.Data.SqlClient
Public Class Mp_backup
    Private _acceso As Acceso
    Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Insertar(bklog As INFRA.BackupDB) As Integer
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@fecha_hora", bklog.fecha)
        Return _acceso.Escribir("Crear_bkplog", parametros)
    End Function

    Public Function Seleccionar(bklog As INFRA.BackupDB) As List(Of INFRA.BackupDB)
        Dim logs As New List(Of INFRA.BackupDB)
        Dim parametros(0) As SqlParameter
        If bklog IsNot Nothing Then
            parametros(0) = _acceso.CrearParametros("@fecha_hora", bklog.fecha)
            Dim tabla As DataTable = _acceso.Leer("Seleccionar_bkplogs", parametros)
            For Each row In tabla.Rows
                Dim log As New INFRA.BackupDB
                log.fecha = row("fecha_hora")
                logs.Add(log)
            Next
        Else
            Dim tabla As DataTable = _acceso.Leer("Seleccionartodos_bkplogs", Nothing)
            For Each row In tabla.Rows
                Dim log As New INFRA.BackupDB
                log.fecha = row("fecha_hora")
                logs.Add(log)
            Next
        End If
        Return logs
    End Function

    Public Function Restore(restorefile As Microsoft.SqlServer.Management.Smo.Restore) As String

    End Function

    Public Function Backup(fullbk As Microsoft.SqlServer.Management.Smo.Backup) As String
        Try
            _acceso.GenerarConexion(fullbk, Nothing)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
End Class
