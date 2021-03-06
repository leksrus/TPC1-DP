﻿Imports System.Text
Public Class GestorSistema
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
        Dim dvvlist As List(Of String) = CompararDVV()
        If dvvlist.Count = 0 Then
            Return True
        End If
        Dim errorsintegrity As List(Of String) = BuscarFalloIntegridad(dvvlist)
        If errorsintegrity.Count > 0 Then
            Try
                Dim path As String = System.IO.Directory.GetCurrentDirectory + "\log_integridad.txt"
                If Not System.IO.File.Exists(path) Then
                    System.IO.File.Create(path).Dispose()
                End If
                Using writer = New System.IO.StreamWriter(path, True)
                    For Each er As String In errorsintegrity
                        Dim myerror As String = "Fallo de integridad en registro: " & er
                        writer.WriteLine(myerror)
                    Next
                    writer.Close()
                End Using
                errorsintegrity = Nothing
            Catch ex As Exception
            End Try
        End If
        Return False
    End Function

    Private Function BuscarFalloIntegridad(dvvlist As List(Of String)) As List(Of String)
        Dim crypto As New INFRA.CryptoManager
        Dim errorsintegrity As New List(Of String)
        For Each dvv As String In dvvlist
            Select Case dvv
                Case "user"
                    Dim mp_user As New DAL.Mp_usuario
                    Dim users As List(Of INFRA.User) = mp_user.Seleccionar
                    For Each usr As INFRA.User In users
                        Dim dv As New INFRA.DV
                        dv.code = crypto.ConvertToHash(usr.name & usr.password & usr.estado & usr.Language.id_idioma)
                        If usr.dvh <> dv.code Then
                            errorsintegrity.Add(dvv & "; " & usr.name & "; " & usr.password & "; " & usr.estado & "; " & usr.Language.id_idioma & "; " & usr.dvh)
                        End If
                        dv = Nothing
                    Next
                    users = Nothing
                Case "log"
                    Dim mp_log As New DAL.Mp_Log
                    Dim logs As List(Of INFRA.Log) = mp_log.Seleccionar
                    For Each log In logs
                        Dim dv As New INFRA.DV
                        dv.code = crypto.ConvertToHash(log.fechahora & log.descripcion & log.TypeError & log.User.name)
                        If log.dvh <> dv.code Then
                            errorsintegrity.Add(dvv & "; " & log.fechahora & "; " & log.descripcion & "; " & log.TypeError & "; " & log.User.name & "; " & log.dvh)
                        End If
                        dv = Nothing
                    Next
                    logs = Nothing
            End Select
        Next
        Return errorsintegrity
    End Function

    Private Function CompararDVV() As List(Of String)
        Dim mp_dvv As New DAL.Mp_DVV
        Dim sb As StringBuilder = Nothing
        Dim id_dvv As New List(Of String)
        Dim crypto As New INFRA.CryptoManager
        Dim listadvv As List(Of INFRA.DVV) = mp_dvv.Seleccionar
        'compara cada registro dvv de la tabla con la columna de dvh de cada tabla que trae y encripta de la base
        For Each tmpdvv As INFRA.DVV In listadvv
            Select Case tmpdvv.id_tabla
                Case "user"
                    Dim mp_user As New DAL.Mp_usuario
                    Dim dv As New INFRA.DV
                    sb = New StringBuilder
                    Dim users As List(Of INFRA.User) = mp_user.Seleccionar
                    'se verifica dvv recorriendo registro por registro y encriptando nuevamente todos los dvh
                    For Each usr In users
                        Dim dv2 As New INFRA.DV
                        dv2.code = crypto.ConvertToHash(usr.name & usr.password & usr.estado & usr.Language.id_idioma)
                        sb.Append(dv2.code)
                        dv2 = Nothing
                    Next
                    'se encripta el total obtenido de dvh para hacer dvv y comprar el actual de la base
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
                        Dim dv2 As New INFRA.DV
                        dv2.code = crypto.ConvertToHash(log.User.name & log.descripcion & log.fechahora & log.TypeError)
                        sb.Append(dv2.code)
                        dv2 = Nothing
                    Next
                    dv.code = crypto.ConvertToHash(sb.ToString)
                    If tmpdvv.code <> dv.code Then
                        id_dvv.Add(tmpdvv.id_tabla)
                    End If
                    sb.Clear()
            End Select
        Next
        Return id_dvv
    End Function

#End Region

#Region "Bitacora"
    Public Sub GrabarBitacora(id_error As Integer, origen As String)
        Dim mp_log As New DAL.Mp_Log
        Dim log As New INFRA.Log
        Dim dv As New INFRA.DV
        Dim crypto As New INFRA.CryptoManager
        log.User = INFRA.SesionManager.CrearSesion.User
        log.fechahora = DateTime.Now
        log.TypeError = id_error
        log.descripcion = origen
        dv.code = crypto.ConvertToHash(log.User.name & log.descripcion & log.fechahora & log.TypeError)
        log.dvh = dv.code
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
