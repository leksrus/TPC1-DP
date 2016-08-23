Public Class Mp_Familia
    Private _acceso As Acceso

    Sub New()
        _acceso = New Acceso
    End Sub

    Friend Sub New(ac As Acceso)
        _acceso = ac
    End Sub

    Public Function Seleccionar() As List(Of INFRA.Familia)
        Dim familias As New List(Of INFRA.Familia)
        Dim tabla As DataTable = _acceso.Leer("Ver_grupos", Nothing)
        For Each reg In tabla.Rows
            Dim familia As New INFRA.Familia
            familia.codigo = reg("cod_familia")
            familia.codigo = reg("description")
            familias.Add(familia)
        Next
        Return familias
    End Function

    Public Function Modificar(familiar As INFRA.Familia) As Integer

    End Function

    Public Function Insertar(familia As INFRA.Familia) As Integer

    End Function
End Class
