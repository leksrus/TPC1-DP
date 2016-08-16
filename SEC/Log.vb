Public Class Log

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
    Public ReadOnly Property TypeError As TypeError
        Get
            Return _typeError
        End Get
    End Property
End Class
