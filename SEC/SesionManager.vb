Public Class SesionManager


    Private Shared _sesion As SesionManager = Nothing


    Private Sub New()

    End Sub

    Public Shared Function CreateSesion(oneuser As User) As SesionManager
        If _sesion Is Nothing Then
            _sesion = New SesionManager

        End If
        Return _sesion
    End Function


End Class
