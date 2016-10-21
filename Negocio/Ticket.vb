Public Class Ticket
    Private _cliente As Cliente
    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Private _deporte As Deporte
    Public Property Deporte As Deporte
        Get
            Return _deporte
        End Get
        Set(value As Deporte)
            _deporte = value
        End Set
    End Property

    Private _fecha_pago As DateTime
    Public Property fecha_pago() As DateTime
        Get
            Return _fecha_pago
        End Get
        Set(ByVal value As DateTime)
            _fecha_pago = value
        End Set
    End Property

    Private _monto As Single
    Public Property monto() As Single
        Get
            Return _monto
        End Get
        Set(ByVal value As Single)
            _monto = value
        End Set
    End Property

    Private _cantidad_clases As Integer
    Public Property cantidad_clases() As Integer
        Get
            Return _cantidad_clases
        End Get
        Set(ByVal value As Integer)
            _cantidad_clases = value
        End Set
    End Property
End Class
