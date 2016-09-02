Public Class GestorLenguaje
    Public Sub GetLanguages()
        Dim mp_control As New DAL.Mp_lenguaje_interface
        mp_control.Seleccionar()
    End Sub

    Public Sub GetMsgLanguages()
        Dim mp_msg As New DAL.Mp_lenguaje_msg
        mp_msg.Seleccionar()
    End Sub

    Public Function ListarTipoIdioma() As List(Of INFRA.Language)
        Dim mp_idioma As New DAL.Mp_lenguaje
        Dim tipodelenguajes As List(Of INFRA.Language) = mp_idioma.Seleccionar
        Return tipodelenguajes
    End Function

    Public Function ChangeLanguage(id_idioma As Integer, id_form As String, id_control As String) As String
        Dim temp As INFRA.InterfaceMsg = INFRA.Sistema.interlanguages.Where(Function(lng) lng.Language.id_idioma = id_idioma AndAlso lng.id_form = id_form AndAlso lng.id_control = id_control).FirstOrDefault

        'Dim tmp As String = (From ln In INFRA.Sistema.interlanguages Where id = ln.Language.id_idioma AndAlso
        '                     id_form = ln.id_form AndAlso id_control = ln.id_control
        '                     Select ln.texto).FirstOrDefault
        Return temp.texto
    End Function

    Public Function ChangeLangMsg(funcname As String, id_msg As Integer, id_idioma As Integer) As String
        Dim temp As INFRA.ExeprionMsg = INFRA.Sistema.msglanguages.Where(Function(msg) msg.funcName = funcname AndAlso msg.id_msg = id_msg AndAlso msg.Language.id_idioma = id_idioma).FirstOrDefault

        'Dim tmp As String = (From lnmsg In INFRA.Sistema.msglanguages Where lnmsg.funcName = funcname AndAlso
        '                     lnmsg.id_msg = id_msg AndAlso lnmsg.Language.id_idioma = id_idioma
        '                     Select lnmsg.text).FirstOrDefault
        Return temp.text
    End Function
End Class
