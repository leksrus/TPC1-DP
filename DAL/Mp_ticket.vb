Imports System.Data.SqlClient
Public Class Mp_ticket
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(_acc As Acceso)
        _acceso = _acc
    End Sub

    Public Function Seleccionar(uncliente As Negocio.Cliente) As List(Of Negocio.Ticket)
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_tarjeta", uncliente.idtarjeta)
        Dim tickets As New List(Of Negocio.Ticket)
        Dim tabla As DataTable = _acceso.Leer("Validar_pago", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim tk As New Negocio.Ticket
            tk.Cliente = New Negocio.Cliente
            tk.Deporte = New Negocio.Deporte
            tk.fecha_pago = reg("fecha_pago")
            tk.monto = reg("monto")
            tk.cantidad_clases = reg("cantidad_clases")
            tk.Cliente.nombre = reg(1)
            tk.Cliente.apellido = reg("apellido")
            tk.Cliente.dni = reg("dni")
            tk.Cliente.fecha_nacimiento = reg("fecha_nacimiento")
            tk.Cliente.direccion = reg("direccion")
            tk.Cliente.email = reg("email")
            tk.Cliente.idtarjeta = reg("idtarjeta")
            tk.Cliente.telefono = reg("telefono")
            tk.Deporte.id_deporte = reg("id_deporte")
            tk.Deporte.nombre = reg(11)
            tk.Deporte.precio = reg("precio")
            tk.Deporte.tipo = reg("tipo")
            tickets.Add(tk)
        Next
        Return tickets
    End Function


    Public Function Seleccionar(fech1 As DateTime, fech2 As DateTime) As List(Of Negocio.Ticket)
        Dim parametros(1) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@fecha_desde", fech1)
        parametros(1) = _acceso.CrearParametros("@fecha_hasta", fech2)
        Dim tickets As New List(Of Negocio.Ticket)
        Dim tabla As DataTable = _acceso.Leer("Listar_DeporteCliente", parametros)
        For Each reg As DataRow In tabla.Rows
            Dim tk As New Negocio.Ticket
            tk.Cliente = New Negocio.Cliente
            tk.Deporte = New Negocio.Deporte
            tk.Deporte.id_deporte = reg("id_deporte")
            tk.Deporte.nombre = reg(0)
            tk.Deporte.precio = reg("precio")
            tk.Deporte.tipo = reg("tipo")
            tk.fecha_pago = reg("fecha_pago")
            tk.monto = reg("monto")
            tk.cantidad_clases = reg("cantidad_clases")
            tk.Cliente.nombre = reg(7)
            tk.Cliente.apellido = reg("apellido")
            tk.Cliente.dni = reg("dni")
            tk.Cliente.fecha_nacimiento = reg("fecha_nacimiento")
            tk.Cliente.direccion = reg("direccion")
            tk.Cliente.email = reg("email")
            tk.Cliente.idtarjeta = reg("idtarjeta")
            tk.Cliente.telefono = reg("telefono")
            tickets.Add(tk)
        Next
        Return tickets
    End Function

    Public Function Insertar(untk As Negocio.Ticket) As Integer
        Dim parametros(4) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@id_tarjeta", untk.Cliente.idtarjeta)
        parametros(1) = _acceso.CrearParametros("@id_deporte", untk.Deporte.id_deporte)
        parametros(2) = _acceso.CrearParametros("@fecha_pago", untk.fecha_pago)
        parametros(3) = _acceso.CrearParametros("@cantidad_clases", untk.cantidad_clases)
        parametros(4) = _acceso.CrearParametros("@monto", untk.monto)
        Return _acceso.Escribir("Registrar_pago", parametros)
    End Function
End Class
