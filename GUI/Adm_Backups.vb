Public Class Adm_Backups
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mantenimiento As New BLL.GestorMantenimiento
        Dim backupDB As New INFRA.BackupDB
        backupDB.fecha = DateTime.Now
        MessageBox.Show(mantenimiento.HacerBackup(backupDB.SetBackup, backupDB))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.InitialDirectory = "C:\Backup"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim backupDB As New INFRA.BackupDB
        Dim gestor_manten As New BLL.GestorMantenimiento
        gestor_manten.HacerRestore(backupDB.SetRestore(TextBox1.Text.ToString))
        TextBox1.Clear()
        Button3.Enabled = False
    End Sub

    Private Sub Adm_Backups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim gestor_manten As New BLL.GestorMantenimiento
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = gestor_manten.ListarBackups(Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gestor_manten As New BLL.GestorMantenimiento
        Dim bkplog As New INFRA.BackupDB
        bkplog.fecha = DateTimePicker1.Value
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = gestor_manten.ListarBackups(bkplog)
    End Sub
End Class