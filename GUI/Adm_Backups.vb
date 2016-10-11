Public Class Adm_Backups
    Dim tmpdbname As String = Nothing
    Dim tmpdbsize As Integer = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = Nothing
        Dim gest_lng As New SL.GestorLenguaje
        Dim log As New INFRA.BackupDB
        Dim gest_manten As New SL.GestorMantenimiento
        If RadioButton1.Checked Then
            log.fecha = DateTimePicker1.Value
            DataGridView1.DataSource = gest_manten.ListarBackups(log)
        ElseIf RadioButton2.Checked Then
            DataGridView1.DataSource = gest_manten.ListarBackups(Nothing)
        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("Backup", 3, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("Backup", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_lng As New SL.GestorLenguaje
        If Not tmpdbname Is Nothing AndAlso ValidarTextbox(TextBox2) Then
            Dim gest_manten As New SL.GestorMantenimiento
            Dim bk As New INFRA.BackupDB
            bk.dbname = tmpdbname
            bk.dbsize = tmpdbsize
            bk.fecha = DateTime.Now
            MessageBox.Show(gest_manten.HacerBackup(bk, TextBox2.Text & "\"))
            DataGridView1.DataSource = Nothing
            TextBox2.Clear()
            Button2.Enabled = False

        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("Backup", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("Backup", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim gestor_manten As New SL.GestorMantenimiento
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = gestor_manten.ListarBases
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            With FolderBrowserDialog1
                .SelectedPath = "C:\"
                Dim result As DialogResult = .ShowDialog
                If result = DialogResult.OK Then
                    TextBox2.Text = .SelectedPath
                    Button2.Enabled = True
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Adm_Backups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Button2.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        tmpdbsize = Nothing
        tmpdbname = Nothing
        If e.RowIndex >= 0 Then
            Dim dr As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            tmpdbname = dr.Cells(0).Value.ToString
            tmpdbsize = dr.Cells(2).Value
        End If
    End Sub

    Private Function ValidarTextbox(textbox As TextBox) As Boolean
        If Not String.IsNullOrWhiteSpace(textbox.Text) Then
            Return True
        End If
        Return False
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ValidarTextbox(TextBox1) Then
            Dim restore As New INFRA.BackupDB
            Dim gest_manten As New SL.GestorMantenimiento
            Dim tmp() = TextBox1.Text.Split("_"c)
            restore.dbname = tmp(tmp.Length - 1).Replace(".bak", "")
            Dim path As String = TextBox1.Text
            MessageBox.Show(gest_manten.HacerRestore(restore, path))
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "Backups de Base SQL"
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.DefaultExt = "bak"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
            Button3.Enabled = True
        End If
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    'Dim mantenimiento As New BLL.GestorMantenimiento
    '    'Dim backupDB As New INFRA.BackupDB
    '    'backupDB.fecha = DateTime.Now
    '    'MessageBox.Show(mantenimiento.HacerBackup(backupDB.SetBackup, backupDB))
    'End Sub

    'Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button5.Click
    '    'OpenFileDialog1.InitialDirectory = "C:\Backup"
    '    'OpenFileDialog1.Title = "Backups de Base SQL"
    '    'OpenFileDialog1.CheckFileExists = True
    '    'OpenFileDialog1.CheckPathExists = True
    '    'OpenFileDialog1.DefaultExt = "bak"
    '    'OpenFileDialog1.FilterIndex = 1
    '    'OpenFileDialog1.RestoreDirectory = True
    '    'If OpenFileDialog1.ShowDialog = DialogResult.OK Then
    '    '    TextBox1.Text = OpenFileDialog1.FileName
    '    '    Button3.Enabled = True
    '    'End If
    'End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    'Dim backupDB As New INFRA.BackupDB
    '    'Dim gestor_manten As New BLL.GestorMantenimiento
    '    'gestor_manten.HacerRestore(backupDB.SetRestore(TextBox1.Text.ToString))
    '    'TextBox1.Clear()
    '    'Button3.Enabled = False
    'End Sub

    'Private Sub Adm_Backups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Button3.Enabled = False
    'End Sub

    'Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    Me.Hide()
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    Dim gestor_manten As New BLL.GestorMantenimiento
    '    DataGridView1.DataSource = Nothing
    '    DataGridView1.DataSource = gestor_manten.ListarBackups(Nothing)
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim gestor_manten As New BLL.GestorMantenimiento
    '    Dim bkplog As New INFRA.BackupDB
    '    bkplog.fecha = DateTimePicker1.Value
    '    DataGridView1.DataSource = Nothing
    '    DataGridView1.DataSource = gestor_manten.ListarBackups(bkplog)
    'End Sub


End Class