Public Class Mp_lenguaje_interface
    Private _acceso As Acceso
    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar() As List(Of INFRA.InterfaceMsg)
        Dim mp_lenguajes As New Mp_lenguaje(_acceso)
        Dim lenguajes As List(Of INFRA.Language) = mp_lenguajes.Seleccionar
        Dim controles As New List(Of INFRA.InterfaceMsg)
        Dim tabla As DataTable = _acceso.Leer("Traer_traduccion", Nothing)
        For Each reg In tabla.Rows
            Dim control As New INFRA.InterfaceMsg
            Dim l As INFRA.Language = (From ln In lenguajes Where ln.id_idioma = reg("id_idioma") Select ln).FirstOrDefault
            control.Language = l
            control.id_control = reg("id_control")
            control.id_form = reg("id_form")
            'control.dvh = reg("dvh")
            control.texto = reg("texto")
            controles.Add(control)
        Next
        Return controles
    End Function

End Class
