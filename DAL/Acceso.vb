Imports System.Data
Imports System.Data.SqlClient

Public Class Acceso
    Private CN As SqlConnection
    Private TX As SqlTransaction

    Public Sub AbrirConeccion()
        If CN Is Nothing Then
            CN = New SqlConnection("data source=.\UAI_LUG; initial catalog=CCCP Gym && Fitness; integrated security=SSPI")
            CN.Open()
        End If
    End Sub

    Public Sub CerrarConeccion()
        If TX IsNot Nothing Then
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
        CerrarConeccion()
    End Sub

    Public Sub CancelarTransaccion()
        TX.Rollback()
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
                Catch ex As Exception
                    filas = -1
                End Try
            End With
        End Using
        CerrarConeccion()
        Return filas
    End Function

    Public Function CrearParametros(name As String, value As String) As SqlParameter
        Dim parametros As New SqlParameter
        parametros.ParameterName = name
        parametros.SqlDbType = SqlDbType.VarChar
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
End Class