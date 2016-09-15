Public Class DV

    Protected _code As String
    Public Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
End Class
