Imports System.Text
Public Class GestorSistema
    Dim id_dvv As List(Of String) = Nothing
#Region "Integridad DB"
    Public Sub GrabarDVV()
        Dim mp_dvv As New DAL.Mp_DVV
        Dim sb As StringBuilder = Nothing
        Dim crypto As New INFRA.CryptoManager
        Dim dvvlist As List(Of INFRA.DVV) = mp_dvv.Seleccionar
        For Each tmpdvv In dvvlist
            Select Case tmpdvv.id_tabla
                Case "user"
                    Dim mp_user As New DAL.Mp_usuario
                    Dim users As List(Of INFRA.User) = mp_user.Seleccionar
                    sb = New StringBuilder
                    For Each usr As INFRA.User In users
                        sb.Append(usr.dvh)
                    Next
                    Dim dvv = New INFRA.DVV
                    dvv.id_tabla = tmpdvv.id_tabla
                    dvv.code = crypto.ConvertToHash(sb.ToString)
                    mp_dvv.Modificar(dvv)
                    sb.Clear()
                Case "log"
                    Dim mp_log As New DAL.Mp_Log
                    Dim logs As List(Of INFRA.Log) = mp_log.Seleccionar
                    sb = New StringBuilder
                    For Each log As INFRA.Log In logs
                        sb.Append(log.dvh)
                    Next
                    Dim dvv = New INFRA.DVV
                    dvv.id_tabla = tmpdvv.id_tabla
                    dvv.code = crypto.ConvertToHash(sb.ToString)
                    mp_dvv.Modificar(dvv)
                    sb.Clear()
            End Select

        Next
    End Sub

    Public Function ValidarIntegridad() As Boolean
        If CompararDVV() Then
            Return True
        End If


        Try
            Dim writer As New System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory + "\log.txt", True)
            Dim errores As String = ""
        Catch ex As Exception

        End Try
        Return False
    End Function

    Private Function BuscarFalloIntegridad() As String
        For Each dvv As String In id_dvv
            Select Case dvv
                Case "user"

                Case "log"

            End Select
        Next
    End Function

    Private Function CompararDVV() As Boolean
        Dim mp_dvv As New DAL.Mp_DVV
        Dim sb As StringBuilder = Nothing
        id_dvv = Nothing
        Dim crypto As New INFRA.CryptoManager
        Dim listadvv As List(Of INFRA.DVV) = mp_dvv.Seleccionar
        'compara cada registro dvv de la tabla con la columna de dvh de cada tabla que trae y encripta de la base
        For Each tmpdvv As INFRA.DVV In listadvv
            id_dvv = New List(Of String)
            Select Case tmpdvv.id_tabla
                Case "user"
                    Dim mp_user As New DAL.Mp_usuario
                    Dim dv As New INFRA.DV
                    sb = New StringBuilder
                    Dim users As List(Of INFRA.User) = mp_user.Seleccionar
                    For Each usr In users
                        sb.Append(usr.dvh)
                    Next
                    dv.code = crypto.ConvertToHash(sb.ToString)
                    If tmpdvv.code <> dv.code Then
                        id_dvv.Add(tmpdvv.id_tabla)
                    End If
                    sb.Clear()
                Case "log"
                    Dim mp_log As New DAL.Mp_Log
                    Dim dv As New INFRA.DV
                    sb = New StringBuilder
                    Dim logs As List(Of INFRA.Log) = mp_log.Seleccionar
                    For Each log In logs
                        sb.Append(log.dvh)
                    Next
                    dv.code = crypto.ConvertToHash(sb.ToString)
                    If tmpdvv.code <> dv.code Then
                        id_dvv.Add(tmpdvv.id_tabla)
                    End If
                    sb.Clear()
            End Select
        Next
        If id_dvv.Count > 0 Then
            Return False
        End If
        Return True
    End Function

#End Region

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
