
Public Class Familia
    Inherits Componente


    Private _dvh As String
    Public Property dvh() As String
        Get
            Return _dvh
        End Get
        Set(ByVal value As String)
            _dvh = value
        End Set
    End Property

    Private listacomponentes As New List(Of Componente)

    Public Overrides Function List() As List(Of Componente)
        Return listacomponentes
    End Function

    Public Overrides Sub Add(p As Componente)
        listacomponentes.Add(p)
    End Sub

    Public Overrides Sub Remove(p As Componente)
        listacomponentes.Remove(p)
    End Sub
End Class
