Public Class Mp_lenguaje_msg
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Sub Seleccionar()
        Dim mp_lenguajes As New Mp_lenguaje(_acceso)
        Dim lenguajes As List(Of INFRA.Language) = mp_lenguajes.Seleccionar
        Dim tabla As DataTable = _acceso.Leer("Traer_mensajes", Nothing)
        For Each reg In tabla.Rows
            Dim msg As New INFRA.ExeprionMsg
            Dim lng As INFRA.Language = (lenguajes.Where(Function(ln) ln.id_idioma = reg("id_idioma"))).FirstOrDefault
            'Dim l As INFRA.Language = (From ln In lenguajes Where ln.id_idioma = reg("id_idioma") Select ln).FirstOrDefault
            msg.Language = lng
            msg.funcName = reg("function_name")
            msg.id_msg = reg("id_exepmsg")
            msg.text = reg("texto")
            INFRA.Sistema.msglanguages.Add(msg)
        Next
    End Sub
End Class
