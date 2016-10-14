Public Class Oferta
    Private _tipoOferta As TipoOferta
    Public Property TipoOferta As TipoOferta
        Get
            Return _tipoOferta
        End Get
        Set(value As TipoOferta)
            value = _tipoOferta
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
End Class
