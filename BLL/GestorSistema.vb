Public Class GestorSistema
    Public Sub GrabarDVV(id_tabla As Integer, cod As String)
        'Dim mp_dvv As New DAL.Mp_DVV
        'Dim crypt As New INFRA.CryptoManager
        'Dim codesdvv As List(Of INFRA.DVV) = mp_dvv.Seleccionar
        'Dim temp As INFRA.DVV = codesdvv.Where(Function(dvv) dvv.id_tabla = id_tabla).FirstOrDefault
        'If temp IsNot Nothing Then
        '    temp.id_tabla = id_tabla
        '    mp_dvv.Modificar(temp)
        'Else
        '    mp_dvv.Insertar(temp)
        'End If
    End Sub

    Public Function ValidarIntegridad() As Boolean

    End Function

#Region "Bitacora"
    Public Sub GrabarBitacora(id_error As Integer, origen As String)
        Dim mp_log As New DAL.Mp_Log
        Dim log As New INFRA.Log
        Dim cadena(3) As String
        log.User = INFRA.SesionManager.CrearSesion.User
        log.fechahora = DateTime.Now
        log.TypeError = id_error
        log.descripcion = origen
        cadena(0) = log.User.name
        cadena(1) = log.descripcion
        cadena(2) = log.fechahora
        cadena(3) = log.TypeError
        log.dvh = INFRA.Sistema.ConcatString(cadena)
        mp_log.Insertar(log)
    End Sub

    Public Function VerBitacora(log As INFRA.Log) As List(Of INFRA.LogInterface)
        Dim mp_log As New DAL.Mp_Log
        Dim logs As List(Of INFRA.Log) = mp_log.Seleccionar(log)
        Dim intlogs As New List(Of INFRA.LogInterface)
        For Each lng As INFRA.Log In logs
            Dim lnginterface As New INFRA.LogInterface
            lnginterface.fecha_hora = lng.fechahora
            lnginterface.userId = lng.User.name
            lnginterface.descripcion = lng.descripcion
            lnginterface.actividad = SeleccionarIdiomaLog(lng.TypeError)
            intlogs.Add(lnginterface)
        Next
        Return intlogs
    End Function

    Private Function SeleccionarIdiomaLog(actividad As INFRA.TypeError) As String
        Dim tmp = INFRA.SesionManager.CrearSesion.User.Language.id_idioma
        Dim q = INFRA.Sistema.loglanguages.Where(Function(ln) ln.Language.id_idioma = tmp AndAlso ln.id_type_event = actividad).FirstOrDefault
        Return q.textodesc
    End Function


#End Region

End Class
