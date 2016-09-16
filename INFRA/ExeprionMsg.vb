Public Class ExeprionMsg
    Private _language As Language
    Public Property Language As Language
        Get
            Return _language
        End Get
        Set(value As Language)
            _language = value
        End Set
    End Property

    Private _funcName As String
    Public Property funcName() As String
        Get
            Return _funcName
        End Get
        Set(ByVal value As String)
            _funcName = value
        End Set
    End Property

    Private _id_msg As Integer
    Public Property id_msg() As Integer
        Get
            Return _id_msg
        End Get
        Set(ByVal value As Integer)
            _id_msg = value
        End Set
    End Property

    Private _text As String
    Public Property text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property
End Class
