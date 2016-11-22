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
            _numero_dia = value
        End Set
    End Property

    Private _rutina As Rutina
    Public Property Rutina As Rutina
        Get
            Return _rutina
        End Get
        Set(value As Rutina)
            _rutina = value
        End Set
    End Property

    Private _tipo_ejercicio As tipo_ejercicio
    Public Property tipo_ejercicio As tipo_ejercicio
        Get
            Return _tipo_ejercicio
        End Get
        Set(value As tipo_ejercicio)
            _tipo_ejercicio = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _tipo_ejercicio.ToString & " - " & _numero_dia.ToString & " - " & _observacion
    End Function
End Class
