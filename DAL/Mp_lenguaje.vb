Public Class Mp_lenguaje
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(ac As Acceso)
        _acceso = ac
    End Sub

    Public Function Seleccionar() As List(Of INFRA.Language)
        Dim lenguajes As New List(Of INFRA.Language)
        Dim tabla As DataTable = _acceso.Leer("Traer_idiomas", Nothing)
        For Each row In tabla.Rows
            Dim leng As New INFRA.Language
            leng.id_idioma = row("id_idioma")
            leng.nombre = row("nombre")
            lenguajes.Add(leng)
        Next
        Return lenguajes
    End Function

End Class
