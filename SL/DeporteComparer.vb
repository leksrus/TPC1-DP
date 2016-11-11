Imports Negocio
Public Class DeporteComparer
    Inherits EqualityComparer(Of Deporte)
    Public Overrides Function Equals(x As Deporte, y As Deporte) As Boolean
        If Object.ReferenceEquals(x, y) Then
            Return True
        End If
        If Object.ReferenceEquals(x, Nothing) Then
            Return False
        End If
        Return x.nombre = y.nombre
    End Function

    Public Overrides Function GetHashCode(obj As Deporte) As Integer
        'If Object.ReferenceEquals(obj, Nothing) Then
        '    Return 0
        'End If

        Return obj.nombre.GetHashCode
    End Function
End Class
