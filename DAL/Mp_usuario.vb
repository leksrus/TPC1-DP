Imports System.Data.SqlClient

Public Class Mp_usuario
    Implements IDisposable

    Private _acceso As Acceso

    Public Sub New()
        _acceso = New Acceso
    End Sub

    Public Function Seleccionar(usuario As INFRA.User) As INFRA.User
        Dim nickname As New INFRA.User
        Dim tabla As DataTable
        Dim parametros(0) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        tabla = _acceso.Leer("Validar_usuario", parametros)
        For Each row In tabla.Rows
            nickname.name = row("nickname")
            nickname.password = row("password")
            nickname.estado = row("estado")
        Next
        Return nickname
    End Function

    Public Function Insertar(usuario As INFRA.User) As Integer
        Dim parametros(3) As SqlParameter
        parametros(0) = _acceso.CrearParametros("@user", usuario.name)
        parametros(1) = _acceso.CrearParametros("@password", usuario.password)
        parametros(2) = _acceso.CrearParametros("@estado", usuario.estado)
        parametros(3) = _acceso.CrearParametros("@dvh", usuario.dvh)
        Return _acceso.Escribir("Crear_usuario", parametros)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
