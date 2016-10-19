Imports System.Data.SqlClient
Public Class Mp_oferta
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub
    Friend Sub New(_acc As Acceso)
        _acceso = _acc
    End Sub

    Public Function Seleccionar() As List(Of Negocio.Oferta)
        Dim ofertas As New List(Of Negocio.Oferta)
        Dim mp_deporte As New Mp_deporte(_acceso)
        Dim deportes As List(Of Negocio.Deporte) = mp_deporte.Seleccionar
        Dim tabla As DataTable = _acceso.Leer("Listar_todas_ofertas", Nothing)
        For Each reg As DataRow In tabla.Rows
            Dim ofe As New Negocio.Oferta
            ofe.Deporte = (deportes.Where(Function(dp) dp.id_deporte = reg("id_deporte"))).FirstOrDefault
            ofe.fechavigencia = reg("fecha_vigencia")
            ofe.fecha_fin = reg("fecha_fin")
            ofe.Estado = reg("estado")
            ofe.TipoOferta = reg("tipo")
            ofe.detalles = reg("descripcion")
            ofe.id_oferta = reg("id_oferta")
            ofertas.Add(ofe)
        Next
        Return ofertas
    End Function


    Public Function Modificar(unaoferta As Negocio.Oferta) As Integer
        Dim res As Integer = 0
        Dim parametros(6) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@fecha_vigencia", unaoferta.fechavigencia)
        parametros(1) = _acceso.CrearParametros("@fecha_fin", unaoferta.fecha_fin)
        parametros(2) = _acceso.CrearParametros("@estado", unaoferta.Estado)
        parametros(3) = _acceso.CrearParametros("@tipo ", unaoferta.TipoOferta)
        parametros(4) = _acceso.CrearParametros("@detalles", unaoferta.detalles)
        parametros(5) = _acceso.CrearParametros("@id_deporte", unaoferta.Deporte.id_deporte)
        parametros(6) = _acceso.CrearParametros("@id_oferta", unaoferta.id_oferta)
        res = _acceso.Escribir("Modificar_oferta", parametros)
        Return res
    End Function

    Public Function Insertar(unaoferta As Negocio.Oferta) As Integer
        Dim res As Integer = 0
        Dim parametros(5) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@fecha_vigencia", unaoferta.fechavigencia)
        parametros(1) = _acceso.CrearParametros("@fecha_fin", unaoferta.fecha_fin)
        parametros(2) = _acceso.CrearParametros("@estado", unaoferta.Estado)
        parametros(3) = _acceso.CrearParametros("@tipo ", unaoferta.TipoOferta)
        parametros(4) = _acceso.CrearParametros("@detalles", unaoferta.detalles)
        parametros(5) = _acceso.CrearParametros("@id_deporte", unaoferta.Deporte.id_deporte)
        res = _acceso.Escribir("Insertar_oferta", parametros)
        Return res
    End Function
End Class
