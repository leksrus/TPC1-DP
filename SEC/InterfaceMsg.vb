Public Class InterfaceMsg
    Private _language As Language
    Public Property Language As Language
        Get
            Return _language
        End Get
        Set(value As Language)
            _language = value
        End Set
    End Property

    Private _id_control As String
    Public Property id_control() As String
        Get
            Return _id_control
        End Get
        Set(ByVal value As String)
            _id_control = value
        End Set
    End Property

    Private _texto As String
    Public Property texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property

    Private _dvh As String
    Public Property dvh() As String
        Get
            Return _dvh
        End Get
        Set(ByVal value As String)
            _dvh = value
        End Set
    End Property

    Private _id_form As String
    Public Property id_form() As String
        Get
            Return _id_form
        End Get
        Set(ByVal value As String)
            _id_form = value
        End Set
    End Property
End Class
