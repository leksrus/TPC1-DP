﻿
Public Class Gestion_Administracion
#Region "Ofertas"
    Public Function VerOfertas(unaoferta As Negocio.Oferta, undeporte As Negocio.Deporte) As List(Of Negocio.Oferta)
        Dim mp_ofer As New DAL.Mp_oferta
        If unaoferta Is Nothing Then
            Dim ofertas As List(Of Negocio.Oferta) = mp_ofer.Seleccionar
            Return ofertas.Where(Function(ofe) ofe.Deporte.id_deporte = undeporte.id_deporte).ToList
        Else
            Dim ofertas As List(Of Negocio.Oferta) = mp_ofer.Seleccionar
            Return ofertas.Where(Function(ofe) ofe.Estado = unaoferta.Estado AndAlso ofe.fecha_fin > Date.Now AndAlso ofe.Deporte.id_deporte = undeporte.id_deporte).ToList
        End If
    End Function

    Public Function CambiarEstadoOferta(unaoferta As Negocio.Oferta) As String
        Dim estado As Integer = 0
        Dim gestorlng As New SL.GestorLenguaje
        Dim mp_ofer As New DAL.Mp_oferta
        estado = mp_ofer.Modificar(unaoferta)
        If estado > 0 Then
            Return gestorlng.ChangeLangMsg("CambiarEstadoOferta", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("CambiarEstadoOferta", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function CargarOferta(unaoferta As Negocio.Oferta) As String
        Dim mp_oferta As New DAL.Mp_oferta
        Dim gestorlng As New SL.GestorLenguaje
        Dim result As Integer = 0
        result = mp_oferta.Insertar(unaoferta)
        If result > 0 Then
            Return gestorlng.ChangeLangMsg("CargarOferta", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("CargarOferta", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function
#End Region

#Region "reportes"
    Public Function HacerReporteBarra(fech1 As DateTime, fech2 As DateTime) As Dictionary(Of Negocio.Deporte, Integer)
        Dim mp_tk As New DAL.Mp_ticket
        Dim mp_dep As New DAL.Mp_deporte
        Dim reporte As New Dictionary(Of Negocio.Deporte, Integer)
        Dim deportes As List(Of Negocio.Deporte) = mp_dep.Seleccionar
        Dim tickets As List(Of Negocio.Ticket) = mp_tk.Seleccionar(fech1, fech2)
        For Each dp As Negocio.Deporte In deportes
            Dim c = tickets.Where(Function(cant) cant.Deporte.id_deporte = dp.id_deporte).Count
            reporte.Add(dp, c)
        Next
        Return reporte
    End Function

    Public Function HacerReporteTorta(fech1 As DateTime, fech2 As DateTime) As Dictionary(Of Negocio.Deporte, Single)
        Dim mp_tk As New DAL.Mp_ticket
        Dim mp_dep As New DAL.Mp_deporte
        Dim reporte As New Dictionary(Of Negocio.Deporte, Single)
        Dim deportes As List(Of Negocio.Deporte) = mp_dep.Seleccionar
        Dim tickets As List(Of Negocio.Ticket) = mp_tk.Seleccionar(fech1, fech2)
        For Each dp As Negocio.Deporte In deportes
            Dim c = tickets.Where(Function(money) money.Deporte.id_deporte = dp.id_deporte).Sum(Function(cash) cash.monto)
            reporte.Add(dp, c)
        Next
        Return reporte
    End Function

#End Region

End Class
