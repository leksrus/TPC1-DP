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

    Private _principal As Boolean
    Public Property principal As Boolean
        Get
            Return _principal
        End Get
        Set(ByVal value As Boolean)
            _principal = value
        End Set
    End Property

    Public MustOverride Function List() As List(Of Componente)

    Public MustOverride Sub Add(p As Componente)

    Public MustOverride Sub Remove(p As Componente)

End Class
