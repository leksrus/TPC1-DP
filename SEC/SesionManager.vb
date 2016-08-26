Public Class SesionManager
    Private Shared _sesion As SesionManager = Nothing

    Private Sub New(usr As User)
        _user = usr
    End Sub

    Private _user As User
    Public Property User As User
        Get
            Return _user
        End Get
        Set(value As User)
            _user = value
        End Set
    End Property

    Public Shared Function CrearSesion(Optional user As User = Nothing) As SesionManager
        If _sesion Is Nothing Then
            _sesion = New SesionManager(user)
        End If
        Return _sesion
    End Function

    Public Shared Sub CerrarSesion()
        If _sesion IsNot Nothing Then
            _sesion = Nothing
        End If
    End Sub
End Class
