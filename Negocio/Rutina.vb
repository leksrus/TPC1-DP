Public Class Rutina
    Private _id_rutina As Integer
    Public Property id_rutina As Integer
        Get
            Return _id_rutina
        End Get
        Set(ByVal value As Integer)
            _id_rutina = value
        End Set
    End Property

    Private _nombre_profesor As String
    Public Property nombre_profesor As String
        Get
            Return _nombre_profesor
        End Get
        Set(ByVal value As String)
            _nombre_profesor = value
        End Set
    End Property

    Private _cliente As Cliente
    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Private _tipo_rutina As Tipo_rutina
    Public Property Tipo_rutina As Tipo_rutina
        Get
            Return _tipo_rutina
        End Get
        Set(value As Tipo_rutina)
            value = _tipo_rutina
        End Set
    End Property
End Class
