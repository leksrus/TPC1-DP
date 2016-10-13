Public Class Membresia
    Private _asistencia As DateTime
    Public Property asistencia() As DateTime
        Get
            Return _asistencia
        End Get
        Set(ByVal value As DateTime)
            _asistencia = value
        End Set
    End Property

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
End Class
