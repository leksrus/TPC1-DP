Public Class LogInterface
    Private _userId As String
    Public Property userId As String
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property

    Private _fecha_hora As DateTime
    Public Property fecha_hora As DateTime
        Get
            Return _fecha_hora
        End Get
        Set(ByVal value As DateTime)
            _fecha_hora = value
        End Set
    End Property

    Private _actividad As String
    Public Property actividad As String
        Get
            Return _actividad
        End Get
        Set(ByVal value As String)
            _actividad = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

End Class
