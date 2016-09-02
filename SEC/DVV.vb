
Public Class DVV
    Private _id_tabla As Integer
    Public Property id_tabla() As Integer
        Get
            Return _id_tabla
        End Get
        Set(ByVal value As Integer)
            _id_tabla = value
        End Set
    End Property

    Private _dvv As String
    Public Property dvv() As String
        Get
            Return _dvv
        End Get
        Set(ByVal value As String)
            _dvv = value
        End Set
    End Property


End Class
