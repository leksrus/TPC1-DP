Public Class GestorLenguaje
    Public Function GetLanguages() As List(Of INFRA.InterfaceMsg)
        Dim mp_control As New DAL.Mp_lenguaje_interface
        Dim controles As List(Of INFRA.InterfaceMsg) = mp_control.Seleccionar
        Return controles
    End Function
End Class
