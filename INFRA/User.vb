Public Class User
    Implements IDisposable
    Private _permisos As New List(Of INFRA.Componente)
    Public Property permisos() As List(Of INFRA.Componente)
        Get
            Return _permisos
        End Get
        Set(ByVal value As List(Of INFRA.Componente))
            _permisos = value
        End Set
    End Property
    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _password As String
    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _estado As Boolean
    Public Property estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _dvh As String
    Public Property dvh() As String
        Get
            Return _dvh
        End Get
        Set(ByVal value As String)
            _dvh = value
        End Set
    End Property

    Private _userdata As UserData
    Public Property UserData As UserData
        Get
            Return _userdata
        End Get
        Set(value As UserData)
            _userdata = value
        End Set
    End Property

    Private _lenguage As Language
    Public Property Language As Language
        Get
            Return _lenguage
        End Get
        Set(value As Language)
            _lenguage = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _name
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
