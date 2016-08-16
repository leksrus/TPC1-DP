Imports System.Text
Public Class DVV

    Public Function ConcatString(cadena() As String) As String
        Dim sb As New StringBuilder
        Dim encriptador As New CryptoManager
        For i = 0 To cadena.Length - 1
            sb.Append(cadena(i))
        Next
        Return encriptador.ConvertToHash(sb.ToString)
    End Function
End Class
