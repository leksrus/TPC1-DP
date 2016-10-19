Public Class Ne_Recepcion_Insc
    Dim gest_recep As BL.Gestion_Recepcion = Nothing

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


    Private Sub Ne_Rec_Insc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambioIdioma()
        TabControl1.TabPages.Remove(TabPage2)
        MaskedTextBox1.Mask = "00000"
        gest_recep = New BL.Gestion_Recepcion
        ComboBox1.DataSource = Nothing
        ComboBox1.DataSource = gest_recep.ListarDeportes
        gest_recep = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gest_recep = New BL.Gestion_Recepcion
        DataGridView2.DataSource = Nothing
        DataGridView2.DataSource = gest_recep.ListarHorarios(DirectCast(ComboBox1.SelectedItem, Negocio.Deporte))
        DataGridView2.Columns.Remove("Deporte")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MaskedTextBox1.MaskCompleted Then
            gest_recep = New BL.Gestion_Recepcion
            Dim cliente As New Negocio.Cliente
            cliente.idtarjeta = MaskedTextBox1.Text
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = gest_recep.BuscarCliente(cliente)
            DataGridView1.Columns.Remove("Rutina")
            cliente = Nothing
            gest_recep = Nothing
        Else
            MessageBox.Show("ingrese id de tarjeta del cliente")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TabControl1.TabPages.Insert(1, TabPage2)
        TabControl1.SelectedTab = TabPage2
    End Sub
End Class