Public Class Oferta
    Private _id_oferta As Integer
    Public Property id_oferta() As Integer
        Get
            Return _id_oferta
        End Get
        Set(ByVal value As Integer)
            _id_oferta = value
        End Set
    End Property

    Private _tipoOferta As TipoOferta
    Public Property TipoOferta As TipoOferta
        Get
            Return _tipoOferta
        End Get
        Set(value As TipoOferta)
            _tipoOferta = value
        End Set
    End Property

    Private _fecha_vigencia As DateTime
    Public Property fechavigencia As DateTime
        Get
            Return _fecha_vigencia
        End Get
        Set(ByVal value As DateTime)
            _fecha_vigencia = value
        End Set
    End Property

    Private _fecha_fin As DateTime
    Public Property fecha_fin As DateTime
        Get
            Return _fecha_fin
        End Get
        Set(ByVal value As DateTime)
            _fecha_fin = value
        End Set
    End Property

    Private _detalles As String
    Public Property detalles As String
        Get
            Return _detalles
        End Get
        Set(ByVal value As String)
            _detalles = value
        End Set
    End Property

    Private _estado As Estado
    Public Property Estado As Estado
        Get
            Return _estado
        End Get
        Set(value As Estado)
            _estado = value
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

    Public Overrides Function ToString() As String
        Return _tipoOferta.ToString
    End Function

End Class
