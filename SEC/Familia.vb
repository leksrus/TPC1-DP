Public Class Familia
    Inherits Componente
    Private listacomponentes As New List(Of Componente)
    Private _componente As Componente
    Public Property Componente As Componente
        Get
            Return _componente
        End Get
        Set(value As Componente)
            _componente = value
        End Set
    End Property
End Class
