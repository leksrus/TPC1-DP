Public Class Mp_lenguaje_log
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub
    Friend Sub New(_ac As Acceso)
        _acceso = _ac
    End Sub

    Public Sub Seleccionar()
        Dim mp_lang As New Mp_lenguaje(_acceso)
        Dim languages As List(Of INFRA.Language) = mp_lang.Seleccionar
        Dim tabla As DataTable = _acceso.Leer("Traer_idiomas_log", Nothing)
        For Each reg In tabla.Rows
            Dim logmsg As New INFRA.LogMsg
            logmsg.id_type_event = reg("type_event")
            logmsg.textodesc = reg("texto")
            logmsg.Language = languages.Where(Function(lng) lng.id_idioma = reg("id_idioma")).FirstOrDefault
            INFRA.Sistema.loglanguages.Add(logmsg)
        Next
    End Sub
End Class
