Public Class Rutina
    Private _nombre_rutina As String
    Public Property nombre_rutina() As String
        Get
            Return _nombre_rutina
        End Get
        Set(ByVal value As String)
            _nombre_rutina = value
        End Set
    End Property

End Class
