Public Class Ne_Profesores_Rutina
    Private nuevarutina As Negocio.Rutina = Nothing
    Dim gest_prof As New BL.Gestion_Prof
    Dim ejerciciosviejos As List(Of Negocio.Ejercicio) = Nothing
    Dim ejerciciosnuevos As List(Of Negocio.Ejercicio) = Nothing
    Public Sub New(rutinas As Negocio.Rutina)
        ejerciciosviejos = New List(Of Negocio.Ejercicio)
        ejerciciosnuevos = New List(Of Negocio.Ejercicio)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        nuevarutina = rutinas
    End Sub

    Private Sub Ne_Profesores_Rutina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambioIdioma()
        ComboBox1.Items.Add(Negocio.num_dia.N1)
        ComboBox1.Items.Add(Negocio.num_dia.N2)
        ComboBox1.Items.Add(Negocio.num_dia.N2)
        ComboBox1.Items.Add(Negocio.num_dia.N4)
        ComboBox1.Items.Add(Negocio.num_dia.N5)
        ComboBox1.Items.Add(Negocio.num_dia.N6)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.abdomen)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.antebrazo)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.bicep)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.burpees)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.dominadas)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.espalda)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.flexiones_brazos)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.gluteos)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.hombros)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.pecho)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.piernas)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.sentadillas)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.sprawls)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.tabata)
        ComboBox2.Items.Add(Negocio.tipo_ejercicio.tricep)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ListBox1.DataSource = Nothing
        ejerciciosviejos = gest_prof.ListarEjercicios(nuevarutina)
        RefrescarListbox()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub RefrescarListbox()
        ListBox1.DataSource = Nothing
        ListBox1.DataSource = ejerciciosviejos
    End Sub

    Private Sub RefrescarLisbox2()
        ListBox2.DataSource = Nothing
        ListBox2.DataSource = ejerciciosnuevos
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing And ComboBox2.SelectedItem IsNot Nothing AndAlso String.IsNullOrWhiteSpace(TextBox1.Text) = False Then
            Dim ejercicio As New Negocio.Ejercicio
            ejercicio.num_dia = ComboBox1.SelectedItem
            ejercicio.tipo_ejercicio = ComboBox2.SelectedItem
            ejercicio.Rutina = nuevarutina
            ejercicio.observacion = TextBox1.Text
            ejerciciosnuevos.Add(ejercicio)
            RefrescarLisbox2()
            TextBox1.Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ejerciciosnuevos.Count > 0 Then
            Dim gestor_leng As New SL.GestorLenguaje
            Dim gest_prof As New BL.Gestion_Prof
            MessageBox.Show(gest_prof.GuardarEjercicios(ejerciciosnuevos, nuevarutina), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
            gestor_leng = Nothing
            gest_prof = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            Dim gestor_leng As New SL.GestorLenguaje
            Dim gest_prof As New BL.Gestion_Prof
            MessageBox.Show(gest_prof.EleminarEjercicio(ListBox1.SelectedItem), gestor_leng.ChangeLangMsg("CargarCliente", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListBox1.DataSource = Nothing
            ejerciciosviejos = gest_prof.ListarEjercicios(nuevarutina)
            gest_prof = Nothing
            gest_prof = Nothing
        End If
    End Sub

#Region "Cambio de Idioma"
    Private Sub CambioIdioma()
        Dim gest_lng As New SL.GestorLenguaje
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Label Then
                Dim it = DirectCast(ctrl, Label)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            ElseIf TypeOf ctrl Is Button Then
                Dim it = DirectCast(ctrl, Button)
                it.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, it.Name)
            End If
        Next
        Me.Text = gest_lng.ChangeLanguage(GlobalVar.tipodelenguaje, Me.Name, "Form")
    End Sub
#End Region

End Class