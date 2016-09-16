Imports System.Data.SqlClient

Public Class Mp_DVV
    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar() As List(Of INFRA.DVV)
        Dim codesdvv As New List(Of INFRA.DVV)
        Dim tabla As DataTable = _acceso.Leer("Seleccionar_DVV", Nothing)
        For Each reg In tabla.Rows
            Dim dvv As New INFRA.DVV
            dvv.id_tabla = reg("id_table")
            dvv.code = reg("hash")
            codesdvv.Add(dvv)
        Next
        Return codesdvv
    End Function

    'Public Function Insertar(dvv As INFRA.DVV) As Integer
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = _acceso.CrearParametros("@id_tabla", dvv.id_tabla)
    '    parametros(1) = _acceso.CrearParametros("@codigo", dvv.code)
    '    Return _acceso.Escribir("Insertar_DVV", parametros)
    'End Function

    Public Function Modificar(dvv As INFRA.DVV) As Integer
        Dim parametros(1) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_tabla", dvv.id_tabla)
        parametros(1) = _acceso.CrearParametros("@codigo", dvv.code)
        Return _acceso.Escribir("Modificar_DVV", parametros)
    End Function

End Class
