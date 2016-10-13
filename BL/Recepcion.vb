Public Class Recepcion

#Region "Cliente"
    Public Function RegistrarCliente(uncliente As Negocio.Cliente) As String
        Dim mp_cliente As New DAL.Mp_cliente
        Dim gestorlng As New SL.GestorLenguaje
        Dim ok = mp_cliente.Insertar(uncliente)
        If ok > 0 Then
            Return gestorlng.ChangeLangMsg("RegistrarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("RegistrarCliente", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function ModificarCliente(uncliente As Negocio.Cliente) As String
        Dim mp_cliente As New DAL.Mp_cliente
        Dim gestorlng As New SL.GestorLenguaje
        Dim ok = mp_cliente.Modificar(uncliente)
        If ok > 0 Then
            Return gestorlng.ChangeLangMsg("RegistrarCliente", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("RegistrarCliente", 4, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function BuscarCliente(uncliente As Negocio.Cliente) As List(Of Negocio.Cliente)
        Dim mp_cliete As New DAL.Mp_cliente
        Dim clientes As List(Of Negocio.Cliente) = mp_cliete.Seleccionar(uncliente)
        Return clientes
    End Function
#End Region


#Region "Deporte"
    Public Function ListarDeportes() As List(Of Negocio.Deporte)
        Dim mp_deporte As New DAL.Mp_deporte
        Dim deportes As List(Of Negocio.Deporte) = mp_deporte.Seleccionar
        Return deportes
    End Function

    Public Function ListarHorarios(deporte As Negocio.Deporte) As List(Of Negocio.Turno)
        Dim mp_turno As New DAL.Mp_turno
        Dim horarios As List(Of Negocio.Turno) = mp_turno.Seleccionar(deporte)
        Return horarios
    End Function
#End Region
End Class
