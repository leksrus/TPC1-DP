Imports System.Data.SqlClient
Public Class Mp_backup
    Private _acceso As Acceso
    Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Insertar(bklog As INFRA.BackupDB) As Integer
        'graba el log al momento de hacer el bk con datos como fecha, nomre de base y tamaño
        Dim parametros(2) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@fecha_hora", bklog.fecha)
        parametros(1) = _acceso.CrearParametros("@dbname", bklog.dbname)
        parametros(2) = _acceso.CrearParametros("@dbsize", bklog.dbsize)
        Return _acceso.Escribir("Crear_bkplog", parametros)
    End Function

    Public Function Seleccionar(bklog As INFRA.BackupDB) As List(Of INFRA.BackupDB)
        Dim logs As New List(Of INFRA.BackupDB)
        Dim tabla As DataTable
        If bklog IsNot Nothing Then
            Dim parametros(0) As SqlParameter
            parametros(0) = _acceso.CrearParametros("@fecha_hora", bklog.fecha)
            tabla = _acceso.Leer("Seleccionar_bkplogs", parametros)
        Else
            tabla = _acceso.Leer("Seleccionartodos_bkplogs", Nothing)
        End If
        For Each row In tabla.Rows
            Dim log As New INFRA.BackupDB
            log.fecha = row("fecha_hora")
            log.dbname = row("dbname")
            log.dbsize = row("dbsize")
            logs.Add(log)
        Next
        Return logs
    End Function

    Public Function Seleccionar() As List(Of INFRA.BackupDB)
        Dim databases As New List(Of INFRA.BackupDB)
        Dim tablas As DataTable = _acceso.Leer("sp_databases", Nothing)
        For Each reg As DataRow In tablas.Rows
            Dim db As New INFRA.BackupDB
            db.dbname = reg("DATABASE_NAME")
            db.dbsize = reg("DATABASE_SIZE")
            databases.Add(db)
        Next
        Return databases
    End Function

    Public Sub Restore(restorefile As INFRA.BackupDB, path As String, instancia As String)
        _acceso.Restore(path, instancia)
    End Sub

    Public Function Backup(bk As INFRA.BackupDB, path As String) As Boolean
        Dim parametros(1) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@DBName", bk.dbname)
        parametros(1) = _acceso.CrearParametros("@Location", path)
        'se realiza el backup usando store procedure y pasandole la ruta a dejar el file .bak y el nombre de la base
        Dim tabla As DataTable = _acceso.Leer("sp_Backup_Database", parametros)
        If tabla.Rows.Count > 0 Then
            'el store devuelve el nombre de la base a la que se realizo el backup, por lo tanto si hay registros en datatable entonces termino Ok
            Return True
        End If
        Return False
    End Function
End Class
