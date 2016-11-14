Public Class dia
    Private _rutina As Rutina
    Public Property Rutina As Rutina
        Get
            Return _rutina
        End Get
        Set(value As Rutina)
            value = _rutina
        End Set
    End Property

    Private _ejercicio As Ejercicio
    Public Property Ejercicio As Ejercicio
        Get
            Return _ejercicio
        End Get
        Set(value As Ejercicio)
            value = _ejercicio
        End Set
    End Property

    Private _dia As num_dia
    Public Property num_dia As num_dia
        Get
            Return _dia
        End Get
        Set(value As num_dia)
            value = _dia
        End Set
    End Property
End Class
