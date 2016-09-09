Imports System.Text
Public Class Sistema
    Private Shared _msglanguages As List(Of ExeprionMsg) = Nothing
    Public Shared Property msglanguages As List(Of ExeprionMsg)
        Get
            If _msglanguages Is Nothing Then
                _msglanguages = New List(Of ExeprionMsg)
            End If
            Return _msglanguages
        End Get
        Set(ByVal value As List(Of ExeprionMsg))
            _msglanguages = value
        End Set
    End Property

    Private Shared _interlanguages As List(Of InterfaceMsg) = Nothing
    Public Shared Property interlanguages() As List(Of InterfaceMsg)
        Get
            If _interlanguages Is Nothing Then
                _interlanguages = New List(Of InterfaceMsg)
            End If
            Return _interlanguages
        End Get
        Set(ByVal value As List(Of InterfaceMsg))
            _interlanguages = value
        End Set
    End Property

    Private Shared _loglanguages As List(Of LogMsg)
    Public Shared Property loglanguages As List(Of LogMsg)
        Get
            If _loglanguages Is Nothing Then
                _loglanguages = New List(Of LogMsg)
            End If
            Return _loglanguages
        End Get
        Set(ByVal value As List(Of LogMsg))
            _loglanguages = value
        End Set
    End Property

    Public Shared Function ConcatString(cadena() As String) As String
        Dim sb As New StringBuilder
        Dim encriptador As New CryptoManager
        For i = 0 To cadena.Length - 1
            sb.Append(cadena(i))
        Next
        Return encriptador.ConvertToHash(sb.ToString)
    End Function

End Class
