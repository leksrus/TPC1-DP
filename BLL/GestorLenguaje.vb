Public Class GestorLenguaje
    Public Shared Function GetLanguages() As List(Of INFRA.InterfaceMsg)
        Dim mp_control As New DAL.Mp_lenguaje_interface
        Dim controles As List(Of INFRA.InterfaceMsg) = mp_control.Seleccionar
        Return controles
    End Function

    Public Function ListarTipoIdioma() As List(Of INFRA.Language)
        Dim mp_idioma As New DAL.Mp_lenguaje
        Dim tipodelenguajes As List(Of INFRA.Language) = mp_idioma.Seleccionar
        Return tipodelenguajes
    End Function
End Class
