Public Class Deporte
    Private _id_deporte As Integer
    Public Property id_deporte() As Integer
        Get
            Return _id_deporte
        End Get
        Set(ByVal value As Integer)
            _id_deporte = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _precio As Single
    Public Property precio() As Single
        Get
            Return _precio
        End Get
        Set(ByVal value As Single)
            _precio = value
        End Set
    End Property

    Private _tipo As String
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _nombre
    End Function
End Class
