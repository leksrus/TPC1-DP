
Public Class DVV
    Inherits DV
    Private _id_tabla As String
    Public Property id_tabla() As String
        Get
            Return _id_tabla
        End Get
        Set(ByVal value As String)
            _id_tabla = value
        End Set
    End Property

End Class
