Public Class LogMsg
    Private _language As Language
    Public Property Language As Language
        Get
            Return _language
        End Get
        Set(value As Language)
            _language = value
        End Set
    End Property

    Private _id_type_event As Integer
    Public Property id_type_event As Integer
        Get
            Return _id_type_event
        End Get
        Set(ByVal value As Integer)
            _id_type_event = value
        End Set
    End Property

    Private _textodesc As String
    Public Property textodesc As String
        Get
            Return _textodesc
        End Get
        Set(ByVal value As String)
            _textodesc = value
        End Set
    End Property
End Class
