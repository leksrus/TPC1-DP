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

    Private _numero_dia As num_dia
    Public Property num_dia As num_dia
        Get
            Return _numero_dia
        End Get
        Set(value As num_dia)
            value = _numero_dia
        End Set
    End Property

    Private _rutina As Rutina
    Public Property Rutina As Rutina
        Get
            Return _rutina
        End Get
        Set(value As Rutina)
            value = _rutina
        End Set
    End Property
End Class
