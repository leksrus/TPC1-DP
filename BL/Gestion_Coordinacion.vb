Public Class Gestion_Coordinacion
    Public Function VerOfertas(unaoferta As Negocio.Oferta, undeporte As Negocio.Deporte) As List(Of Negocio.Oferta)
        Dim mp_ofer As New DAL.Mp_oferta
        If unaoferta Is Nothing Then
            Dim ofertas As List(Of Negocio.Oferta) = mp_ofer.Seleccionar
            Return ofertas.Where(Function(ofe) ofe.Deporte.id_deporte = undeporte.id_deporte).ToList
        Else
            Dim ofertas As List(Of Negocio.Oferta) = mp_ofer.Seleccionar
            Return ofertas.Where(Function(ofe) ofe.Estado = unaoferta.Estado AndAlso ofe.Deporte.id_deporte = undeporte.id_deporte).ToList
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
        Dim result As Integer = 0
        result = mp_oferta.Insertar(unaoferta)
        If result > 0 Then
            Return ""
        Else
            Return ""
        End If
    End Function
End Class
