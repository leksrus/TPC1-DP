Public Class Ejercicio
    Private _id_ejercicio As Integer
    Public Property id_ejercicio As Integer
        Get
            Return _id_ejercicio
        End Get
        Set(ByVal value As Integer)
            _id_ejercicio = value
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
