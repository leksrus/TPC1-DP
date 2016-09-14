'Imports Microsoft.SqlServer.Management.Smo
Public Class BackupDB

    Private _dbname As String
    Public Property dbname() As String
        Get
            Return _dbname
        End Get
        Set(ByVal value As String)
            _dbname = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property fecha As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _dbsize As Integer
    Public Property dbsize As Integer
        Get
            Return _dbsize
        End Get
        Set(ByVal value As Integer)
            _dbsize = value
        End Set
    End Property

    'Public Function SetBackup() As Backup
    '    Dim fullbk As New Backup
    '    Dim filename As String = "C:\Backup\Full_bkp" + (DateTime.Now.ToShortDateString().Replace("/"c, "."c)) + ".bak"
    '    Dim bkdevice As New BackupDeviceItem(filename, DeviceType.File)
    '    fullbk.Action = BackupActionType.Database
    '    fullbk.Initialize = False
    '    fullbk.Database = "CCCP Gym && Fitness"
    '    fullbk.BackupSetDescription = "CCCP Gym && Fitness - Full Backup"
    '    fullbk.Devices.Add(bkdevice)
    '    Return fullbk
    'End Function

    'Public Function SetRestore(filename As String) As Restore
    '    Dim restorebk As New Restore
    '    Dim bkdevice As New BackupDeviceItem(filename, DeviceType.File)
    '    restorebk.Action = RestoreActionType.Database
    '    restorebk.Database = "CCCP Gym && Fitness"
    '    restorebk.ReplaceDatabase = True
    '    restorebk.Devices.Add(bkdevice)
    '    Return restorebk
    'End Function
End Class
