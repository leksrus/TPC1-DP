
Public Class Patente
    Inherits Componente

    Public Overrides Sub Add(p As Componente)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Remove(p As Componente)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function List() As List(Of Componente)
        Return New List(Of Componente)
    End Function
End Class
