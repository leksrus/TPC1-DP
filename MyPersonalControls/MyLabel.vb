Public Class MyLabel
    Inherits Label
    Public Property IdiomaEtiquet As String
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return IdiomaEtiquet
    End Function

End Class
