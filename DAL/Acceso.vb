Imports System.Data
Imports System.Data.SqlClient
'Imports Microsoft.SqlServer.Management.Common
'Imports Microsoft.SqlServer.Management.Smo

Public Class Acceso
    Private CN As SqlConnection
    Private TX As SqlTransaction
    'Private servcon As ServerConnection
    'Private srv As Server

    Public Sub AbrirConeccion()
        If CN Is Nothing Then
            CN = New SqlConnection("data source=.\UAI_LUG; initial catalog=CCCP Gym && Fitness; integrated security=SSPI")
            CN.Open()
        End If
    End Sub

    Public Sub CerrarConeccion()
        If TX Is Nothing Then
            CN.Close()
            CN = Nothing
            GC.Collect()
        End If
    End Sub

    Public Sub AbrirTransaccion()
        If CN Is Nothing OrElse CN.State <> ConnectionState.Open Then
            AbrirConeccion()
        End If
        TX = CN.BeginTransaction
    End Sub

    Public Sub ConfirmarTransaccion()
        TX.Commit()
        TX = Nothing
        CerrarConeccion()
    End Sub

    Public Sub CancelarTransaccion()
        TX.Rollback()
        TX = Nothing
        CerrarConeccion()
    End Sub

    Public Function Leer(name As String, paramiters() As SqlParameter) As DataTable
        AbrirConeccion()
        Dim tabla As New DataTable
        Using DA = New SqlDataAdapter
            DA.SelectCommand = New SqlCommand
            With DA.SelectCommand
                .CommandText = name
                .CommandType = CommandType.StoredProcedure
                If paramiters IsNot Nothing Then
                    .Parameters.AddRange(paramiters)
                End If
                .Connection = CN
                If TX IsNot Nothing Then
                    .Transaction = TX
                End If
            End With
            DA.Fill(tabla)
        End Using
        CerrarConeccion()
        Return tabla
    End Function

    Public Function Escribir(name As String, paramiters() As SqlParameter) As Integer
        Dim filas As Integer = 0
        AbrirConeccion()
        Using cmd = New SqlCommand
            With cmd
                .CommandText = name
                .CommandType = CommandType.StoredProcedure
                cmd.Connection = CN
                .Parameters.AddRange(paramiters)
                If TX IsNot Nothing Then
                    .Transaction = TX
                End If
                Try
                    filas = .ExecuteNonQuery
                Catch ex As SqlException
                    filas = -1
                End Try
            End With
        End Using
        CerrarConeccion()
        Return filas
    End Function

    'Public Sub GenerarConexion(backup As Backup, restore As Restore)
    '    'genero la conexion a SQL para DDL
    '    AbrirConeccion()
    '    If servcon Is Nothing AndAlso srv Is Nothing Then
    '        servcon = New ServerConnection(CN)
    '        srv = New Server(servcon)
    '    End If
    '    'tomo backup o ejecuto restore segun el objeto en el parametro
    '    If backup IsNot Nothing Then
    '        backup.SqlBackup(srv)
    '    ElseIf restore IsNot Nothing Then
    '        restore.SqlRestore(srv)
    '    End If
    '    MatarConexion()
    'End Sub

    'Private Sub MatarConexion()
    '    'cierro la conexion a SQL para DDL y limpio la memoria
    '    If servcon IsNot Nothing AndAlso srv IsNot Nothing Then
    '        servcon = Nothing
    '        srv = Nothing
    '        CerrarConeccion()
    '    End If
    'End Sub


    'creacion de diferentes parametros para pasarlos a la base de datos
#Region "Creacion de parametros"
    Public Function CrearParametros(name As String, value As DateTime) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.DateTime
        parametros.Value = value
        Return parametros
    End Function

    Public Function CrearParametros(name As String, value As String) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.NVarChar
        parametros.Value = value
        Return parametros
    End Function

    Public Function CrearParametros(name As String, value As Integer) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.Int
        parametros.Value = value
        Return parametros
    End Function

    Public Function CrearParametros(name As String, value As Char) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.Char
        parametros.Value = value
        Return parametros
    End Function

    Public Function CrearParametros(name As String, value As Boolean) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.Bit
        parametros.Value = value
        Return parametros
    End Function
#End Region

End Class