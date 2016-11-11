Public Class VistaRecep
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _apellido As String
    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _dni As String
    Public Property dni() As String
        Get
            Return _dni
        End Get
        Set(ByVal value As String)
            _dni = value
        End Set
    End Property

    Private _fecha_ingreso As DateTime
    Public Property fecha_ingreso As DateTime
        Get
            Return _fecha_ingreso
        End Get
        Set(ByVal value As DateTime)
            _fecha_ingreso = value
        End Set
    End Property

    Private _nombre_clase As String
    Public Property nombre_clase() As String
        Get
            Return _nombre_clase
        End Get
        Set(ByVal value As String)
            _nombre_clase = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _nombre & " " & _apellido & " - Dni: " & _dni & " - " & _fecha_ingreso & " - " & _nombre_clase
    End Function
End Class
