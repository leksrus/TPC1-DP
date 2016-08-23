Public MustInherit Class Componente
    Private _user As User
    Public Property User As User
        Get
            Return _user
        End Get
        Set(value As User)
            _user = value
        End Set
    End Property

    Private _codigo As String
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
End Class
