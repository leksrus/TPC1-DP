Public Class Mp_deporte
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub
    Friend Sub New(_ac As Acceso)
        _acceso = _ac
    End Sub

    Public Function Seleccionar() As List(Of Negocio.Deporte)
        Dim deportes As New List(Of Negocio.Deporte)
        Dim tabla As DataTable = _acceso.Leer("Listar_deportes", Nothing)
        For Each reg As DataRow In tabla.Rows
            Dim dep As New Negocio.Deporte
            dep.id_deporte = reg("id_deporte")
            dep.nombre = reg("nombre")
            dep.precio = reg("precio")
            dep.tipo = reg("tipo")
            deportes.Add(dep)
        Next
        Return deportes
    End Function
End Class
