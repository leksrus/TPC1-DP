Imports System.ComponentModel

Public Class Ne_Recepcion_Insc
    Dim gest_recep As BL.Gestion_Recepcion = Nothing
    Dim cliente As Negocio.Cliente = Nothing

#Region "Cambio de Idioma"
    Private Sub CambioIdioma()
        Dim gest_lng As New SL.GestorLenguaje
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is TabControl Then
                Dim c = DirectCast(ctrl, TabControl)
                For Each ctr As TabPage In c.Controls
                    For Each ct In ctr.Controls
                        If TypeOf ct Is Label Then
                            Dim it = DirectCast(ct, Label)
                            it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
                        ElseIf TypeOf ct Is Button Then
                            Dim it = DirectCast(ct, Button)
                            it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
                        End If
                    Next
                    ctr.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, ctr.Name)
                Next

            Else
                Dim it = DirectCast(ctrl, Button)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            End If
        Next
        Me.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, "Form")
    End Sub

#End Region

#Region "Eventos"
    Private Sub Ne_Rec_Insc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambioIdioma()
        Button6.Enabled = False
        TabControl1.TabPages.Remove(TabPage2)
        MaskedTextBox1.Mask = "00000"
        gest_recep = New BL.Gestion_Recepcion
        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = gest_recep.ListarDeportes
        ComboBox4.Enabled = False
        AddClases()
        gest_recep = Nothing
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub AddClases()
        ComboBox4.Items.Add(0)
        ComboBox4.Items.Add(4)
        ComboBox4.Items.Add(6)
        ComboBox4.Items.Add(8)
        ComboBox4.Items.Add(10)
        ComboBox4.Items.Add(12)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Button6.Enabled = True
        If e.RowIndex >= 0 Then
            cliente = DirectCast(sender, DataGridView).DataSource(e.RowIndex)
        End If
    End Sub

    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        Dim gest_adm As New BL.Gestion_Administracion
        Dim oferta As New Negocio.Oferta
        oferta.Estado = Negocio.Estado.aprobado
        ComboBox3.DataSource = Nothing
        If ComboBox2.SelectedItem IsNot Nothing Then
            ComboBox3.DataSource = gest_adm.VerOfertas(oferta, DirectCast(ComboBox2.SelectedItem, Negocio.Deporte))
            If DirectCast(ComboBox2.SelectedItem, Negocio.Deporte).tipo.Equals("Fitness") Then
                ComboBox4.Enabled = True
                ComboBox4.SelectedIndex = 0
            Else
                ComboBox4.Enabled = False
            End If
        End If
        oferta = Nothing
        gest_adm = Nothing
    End Sub
#End Region

#Region "limpiar contoles"
    Private Sub CleanControlsTb1()
        DataGridView2.DataSource = Nothing
    End Sub

    Private Sub CleanControlsTb2()
        DataGridView2.DataSource = Nothing
        Button6.Enabled = False
    End Sub
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gest_recep = New BL.Gestion_Recepcion
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = gest_recep.ListarHorarios(DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
        DataGridView2.Columns.Remove("Deporte")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MaskedTextBox1.MaskCompleted Then
            gest_recep = New BL.Gestion_Recepcion
            Dim cliente As New Negocio.Cliente
            cliente.idtarjeta = MaskedTextBox1.Text
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_recep.BuscarCliente(cliente)
            DataGridView1.ClearSelection()
            cliente = Nothing
            gest_recep = Nothing
        Else
            Dim gestor_leng As SL.GestorLenguaje = Nothing
            gestor_leng = New SL.GestorLenguaje
            MessageBox.Show(gestor_leng.ChangeLangMsg("BuscarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            gestor_leng = Nothing
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gest_recep = New BL.Gestion_Recepcion
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = gest_recep.ListarDeportes
        TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2
        TabControl1.TabPages.Remove(TabPage1)
        CleanControlsTb1()
        gest_recep = Nothing
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CleanControlsTb2()
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Insert(0, TabPage1)
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_adm As New BL.Gestion_Administracion
        Dim oferta As New Negocio.Oferta
        oferta.Estado = Negocio.Estado.aprobado
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = gest_adm.VerOfertas(oferta, DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
        oferta = Nothing
        gest_adm = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gest_recep = New BL.Gestion_Recepcion
        Dim tk As Negocio.Ticket = Nothing
        tk = New Negocio.Ticket
        tk.Cliente = cliente
        tk.Deporte = DirectCast(ComboBox2.SelectedItem, Negocio.Deporte)
        tk.fecha_pago = Date.Now
        tk.cantidad_clases = ComboBox4.SelectedItem
        tk.monto = gest_recep.CalcularMonto(tk, DirectCast(ComboBox3.SelectedItem, Negocio.Oferta))
        Dim frmconfirm As New Ne_Recepcion_Insc_Conf(tk)
        frmconfirm.ShowDialog()
        frmconfirm = Nothing
        cliente = Nothing
        CleanControlsTb2()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class