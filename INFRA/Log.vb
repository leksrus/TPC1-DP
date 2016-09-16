Public Class Log
    Private _dvh As String
    Public Property dvh() As String
        Get
            Return _dvh
        End Get
        Set(ByVal value As String)
            _dvh = value
        End Set
    End Property

    Private _user As User
    Public Property User As User
        Get
            Return _user
        End Get
        Set(value As User)
            _user = value
        End Set
    End Property

    Private _typeError As TypeError
    Public Property TypeError As TypeError
        Get
            Return _typeError
        End Get
        Set(ByVal value As TypeError)
            _typeError = value
        End Set
    End Property

    Private _fechahora As DateTime
    Public Property fechahora() As DateTime
        Get
            Return _fechahora
        End Get
        Set(ByVal value As DateTime)
            _fechahora = value
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
