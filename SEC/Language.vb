Public Class Language
    Private _user As User

    Private _id_idioma As String
    Public Property id_idioma() As String
        Get
            Return _id_idioma
        End Get
        Set(ByVal value As String)
            _id_idioma = value
        End Set
    End Property
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return nombre
    End Function
End Class
