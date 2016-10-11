Imports System.Data.SqlClient

Public Class Mp_familia
    Private _acceso As Acceso

    Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(ac As Acceso)
        _acceso = ac
    End Sub

    Public Function Seleccionar() As List(Of INFRA.Componente)
        Dim p As INFRA.Componente = Nothing
        Dim p1 As INFRA.Componente = Nothing
        Dim permisos As New List(Of INFRA.Componente)
        Dim tabla As DataTable = _acceso.Leer("SeleccionarFamilias", Nothing)
        For Each reg As DataRow In tabla.Rows
            p = New INFRA.Familia
            p.codigo = reg("id_familia")
            p.descripcion = reg("descripcion")
            p1 = Seleccionar(p)
            If p1 IsNot Nothing Then
                'p.Add(p1)
                permisos.Add(p)
            End If
        Next
        Return permisos
    End Function

    Private Function Seleccionar(per As INFRA.Componente) As INFRA.Componente
        Dim paramteros(0) As SqlParameter
        paramteros(0) = _acceso.CrearParametros("@id_familia", per.codigo)
        Dim permiso As INFRA.Componente = Nothing
        Dim permisoAdc As INFRA.Componente = Nothing
        Dim tabla As DataTable = _acceso.Leer("ContarPatentes", paramteros)
        If tabla.Rows.Count > 0 Then
            paramteros(0) = _acceso.CrearParametros("@id_familia", per.codigo)
            tabla = _acceso.Leer("SeleccionarPatentes", paramteros)
            For Each reg As DataRow In tabla.Rows
                paramteros(0) = _acceso.CrearParametros("@id_familia", reg(0).ToString)
                Dim tablahijos As DataTable = _acceso.Leer("ContarPatentes", paramteros)
                If tablahijos.Rows.Count > 0 Then
                    permiso = New INFRA.Familia
                    permiso.codigo = reg("id_familia")
                    permiso.descripcion = reg("descripcion")
                    permisoAdc = Seleccionar(permiso)
                    permiso.Add(permisoAdc)
                Else
                    permiso = New INFRA.Patente
                    permiso.codigo = reg("id_patente")
                    permiso.descripcion = reg("descripcion")
                End If
                per.Add(permiso)
            Next
        Else
            Return Nothing
        End If
        Return per
    End Function
End Class
