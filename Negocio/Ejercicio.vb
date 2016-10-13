Public Class Ejercicio
    Private _rutina As Rutina
    Public Property Rutina As Rutina
        Get
            Return Nothing
        End Get
        Set(value As Rutina)
        End Set
    End Property

    Private _dia As String
    Public Property dia() As String
        Get
            Return _dia
        End Get
        Set(ByVal value As String)
            _dia = value
        End Set
    End Property

    Private _nombre_ejercicio As String
    Public Property nombre_ejercicio() As String
        Get
            Return _nombre_ejercicio
        End Get
        Set(ByVal value As String)
            _nombre_ejercicio = value
        End Set
    End Property

    Private _observacion As String
    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
        End Set
    End Property
End Class
