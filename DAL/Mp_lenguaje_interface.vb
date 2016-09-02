Public Class Mp_lenguaje_interface
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Sub Seleccionar()
        Dim mp_lenguajes As New Mp_lenguaje(_acceso)
        Dim lenguajes As List(Of INFRA.Language) = mp_lenguajes.Seleccionar
        Dim tabla As DataTable = _acceso.Leer("Traer_traduccion", Nothing)
        For Each reg In tabla.Rows
            Dim control As New INFRA.InterfaceMsg
            Dim lng As INFRA.Language = (lenguajes.Where(Function(ln) ln.id_idioma = reg("id_idioma"))).FirstOrDefault
            'Dim l As INFRA.Language = (From ln In lenguajes Where ln.id_idioma = reg("id_idioma") Select ln).FirstOrDefault
            control.Language = lng
            control.id_control = reg("id_control")
            control.id_form = reg("id_form")
            control.texto = reg("texto")
            INFRA.Sistema.interlanguages.Add(control)
        Next
    End Sub

End Class
