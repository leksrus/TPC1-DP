Public Class GestorSistema
    Public Sub GrabarDVV(id_tabla As Integer, cod As String)
        Dim mp_dvv As New DAL.Mp_DVV
        Dim crypt As New INFRA.CryptoManager
        Dim codesdvv As List(Of INFRA.DVV) = mp_dvv.Seleccionar
        Dim temp As INFRA.DVV = codesdvv.Where(Function(dvv) dvv.id_tabla = id_tabla).FirstOrDefault
        If temp IsNot Nothing Then
            temp.id_tabla = id_tabla
            mp_dvv.Modificar(temp)
        Else
            mp_dvv.Insertar(temp)
        End If
    End Sub

    Public Function ValidarIntegridad() As Boolean

    End Function

#Region "Bitacora"
    Public Sub GrabarBitacora(log As INFRA.Log)
        Dim mp_log As New DAL.Mp_Log
        mp_log.Insertar(log)
    End Sub
#End Region

End Class
