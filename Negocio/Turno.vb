Public Class Turno
    Private _deporte As Deporte
    Public Property Deporte As Deporte
        Get
            Return _deporte
        End Get
        Set(value As Deporte)
            _deporte = value
        End Set
    End Property

    Private _dia As String
    Public Property dia() As String
        Get
            Return _dia
        End Get
        Set(ByVal value As String)
            _dia = value
        End Set
    End Property

    Private _hora As TimeSpan
    Public Property hora As TimeSpan
        Get
            Return _hora
        End Get
        Set(value As TimeSpan)
            _hora = value
        End Set
    End Property
End Class
