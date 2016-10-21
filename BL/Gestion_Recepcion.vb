﻿Public Class Gestion_Recepcion
    Public Event ValidarPagoVencido(msg As String)
    Public Event ValidarPagoActivo(dep As List(Of Negocio.Deporte))


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

#Region "Pagos"
    Public Function RegistrarPago(untk As Negocio.Ticket) As String
        Dim mp_tk As New DAL.Mp_ticket
        Dim gestorlng As New SL.GestorLenguaje
        Dim result As Integer = 0
        result = mp_tk.Insertar(untk)
        If result > 0 Then
            Return gestorlng.ChangeLangMsg("RegistrarPago", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("RegistrarPago", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

    Public Function CalcularMonto(untk As Negocio.Ticket, unaoferta As Negocio.Oferta) As Single
        Dim precio As Single = 0
        Select Case untk.Deporte.nombre
            Case "cross fit"
                If unaoferta IsNot Nothing Then
                    precio = untk.Deporte.precio - (untk.Deporte.precio * EvaluarPromo(unaoferta))
                Else
                    precio = untk.Deporte.precio
                End If
            Case "gimnasio"
                If unaoferta IsNot Nothing Then
                    precio = untk.Deporte.precio - (untk.Deporte.precio * EvaluarPromo(unaoferta))
                Else
                    precio = untk.Deporte.precio
                End If
            Case "aerobic"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "aerodance"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "yoga"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "boxeo"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "Tae bo"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "may thai"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "aikido"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case "tbc"
                If unaoferta IsNot Nothing Then
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk)) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarPromo(unaoferta))
                Else
                    precio = (untk.Deporte.precio * untk.cantidad_clases) - (untk.Deporte.precio * untk.cantidad_clases * EvaluarClases(untk))
                End If
            Case Else
                Return precio
        End Select
        Return precio
    End Function

    Private Function EvaluarPromo(unaoferta As Negocio.Oferta) As Single
        Dim percent As Single = 0
        Select Case unaoferta.TipoOferta
            Case 1
                percent = 0.1
            Case 2
                percent = 0.2
            Case 3
                percent = 0.3
            Case 4
                percent = 0.4
            Case 5
                percent = 0.5
            Case Else
                percent = 1
        End Select
        Return percent
    End Function

    Private Function EvaluarClases(untk As Negocio.Ticket) As Single
        Dim precio As Single = 0
        Select Case untk.cantidad_clases
            Case 6
                precio = 0.1
            Case 8
                precio = 0.15
            Case 10
                precio = 0.2
            Case 12
                precio = 0.25
            Case Else
                precio = 0
        End Select
        Return precio
    End Function
#End Region

#Region "Ingreso a Clases"
    Public Function ValidarIngreso(uncliente As Negocio.Cliente) As List(Of Negocio.Ticket)
        Dim mp_tk As New DAL.Mp_ticket
        Dim tickets As List(Of Negocio.Ticket) = mp_tk.Seleccionar(uncliente)
        If tickets.Count > 0 Then
            Dim tmp = tickets.Where(Function(tkv) tkv.fecha_pago.Month = DateTime.Now.Month AndAlso tkv.fecha_pago.Year = DateTime.Now.Year).ToList
            If tmp.Count > 0 Then
                For Each tk As Negocio.Ticket In tmp

                Next
                RaiseEvent ValidarPagoActivo(tmp)
                Return tmp
            Else
                RaiseEvent ValidarPagoVencido("Todos los pagos estan vencidos")
            End If
        End If
        Return tickets
    End Function

    Public Function ValidarCuota() As String

    End Function

    Public Function RegistrarIngreso() As String

    End Function
#End Region

End Class
