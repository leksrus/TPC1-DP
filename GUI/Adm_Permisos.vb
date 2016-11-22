Imports System.ComponentModel

Public Class Adm_Permisos
    Dim usuario As INFRA.User = Nothing
    Dim estado As Boolean = False
    Private Sub LoadPermisos()
        Dim gestsistema As New SL.GestorSistema
        Dim nodo As TreeNode = Nothing
        'Dim percomponente As INFRA.Componente = Nothing
        'Dim familia As INFRA.Familia = Nothing
        'Dim patente As INFRA.Patente = Nothing
        Dim permisos As List(Of INFRA.Componente) = gestsistema.TraerPermisos
        For Each per As INFRA.Componente In permisos
            nodo = New TreeNode
            nodo.Text = per.descripcion
            nodo.Tag = per
            TreeView1.Nodes.Add(nodo)
            If per.List.Count > 0 Then
                LoadPermisoRecursivo(per, nodo)
            End If
            'If TypeOf per Is INFRA.Familia Then
            '    familia = DirectCast(per, INFRA.Familia)
            '    For Each leaf As INFRA.Componente In familia.List
            '        If TypeOf leaf Is INFRA.Patente Then
            '            nodo.Nodes.Add(leaf.descripcion)
            '        End If
            '    Next
            'End If

        Next
        gestsistema = Nothing
    End Sub

    Private Sub LoadPermisoRecursivo(p As INFRA.Componente, tr As TreeNode)
        For Each per In p.List
            Dim trn As New TreeNode
            trn.Text = per.descripcion
            trn.Tag = per
            tr.Nodes.Add(trn)
            If per.List.Count > 0 Then
                LoadPermisoRecursivo(per, trn)
            End If
        Next
    End Sub

    Private Sub LoadUsers()
        Dim gestmanten As New SL.GestorMantenimiento
        ListBox1.DataSource = Nothing
        ListBox1.DataSource = gestmanten.ListarUsuarios()
    End Sub

    Private Sub Adm_Permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPermisos()
        LoadUsers()
        TreeView1.ExpandAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TreeView1.Nodes.Clear()
        LoadUsers()
        LoadPermisos()
        TreeView1.ExpandAll()
    End Sub
#Region "eventos"
    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            usuario = Nothing
            ValidateNode(DirectCast(ListBox1.SelectedItem, INFRA.User))
            usuario = DirectCast(sender, ListBox).SelectedItem
        End If
    End Sub

    Private Sub ValidateNode(usr As INFRA.User)
        Dim gest_sistem As New SL.GestorSistema
        For Each nd As TreeNode In TreeView1.Nodes
            nd.Checked = gest_sistem.IsInRol(DirectCast(nd.Tag, INFRA.Componente), usr)
            If nd.Nodes.Count > 0 Then
                For Each nds In nd.Nodes
                    ValidateNodeRecursive(nd, DirectCast(ListBox1.SelectedItem, INFRA.User))
                Next
            End If
        Next
        gest_sistem = Nothing
    End Sub
    Private Sub ValidateNodeRecursive(nd As TreeNode, us As INFRA.User)
        Dim gest_sistem As New SL.GestorSistema
        For Each node As TreeNode In nd.Nodes
            node.Checked = gest_sistem.IsInRol(DirectCast(node.Tag, INFRA.Componente), us)
            If node.Nodes.Count > 0 Then
                ValidateNodeRecursive(node, us)
            End If
        Next
        gest_sistem = Nothing
    End Sub
#End Region

    'Private Function checkPermiso() As List(Of INFRA.Componente)
    '    Dim p As INFRA.Componente = Nothing
    '    Dim p1 As INFRA.Componente = Nothing
    '    Dim permisos As New List(Of INFRA.Componente)
    '    Dim gest_sistem As New SL.GestorSistema
    '    For Each node As TreeNode In TreeView1.Nodes
    '        If node.Checked Then
    '            p = New INFRA.Familia
    '            p.codigo = DirectCast(node.Tag, INFRA.Familia).codigo
    '            p.descripcion = DirectCast(node.Tag, INFRA.Familia).descripcion
    '            p.principal = DirectCast(node.Tag, INFRA.Familia).principal
    '            If node.Nodes.Count > 0 Then
    '                    p1 = (CheckPermisoRec(p, node, DirectCast(ListBox1.SelectedItem, INFRA.User)))
    '                End If
    '                If p1 IsNot Nothing Then
    '                    permisos.Add(p1)
    '                End If
    '            End If
    '    Next
    '    Return permisos
    'End Function

    'Private Function CheckPermisoRec(p As INFRA.Componente, node As TreeNode, user As INFRA.User) As INFRA.Componente
    '    Dim per As INFRA.Componente = Nothing
    '    Dim perad As INFRA.Componente = Nothing
    '    Dim gest_sistem As New SL.GestorSistema
    '    For Each nd As TreeNode In node.Nodes
    '        If nd.Checked Then
    '            If TypeOf nd.Tag Is INFRA.Familia Then
    '                per = New INFRA.Familia
    '                per.codigo = DirectCast(nd.Tag, INFRA.Familia).codigo
    '                per.descripcion = DirectCast(nd.Tag, INFRA.Familia).descripcion

    '                perad = CheckPermisoRec(per, nd, user)
    '                p.Add(perad)
    '            Else
    '                per = New INFRA.Patente
    '                per.codigo = DirectCast(nd.Tag, INFRA.Patente).codigo
    '                per.descripcion = DirectCast(nd.Tag, INFRA.Patente).descripcion
    '                p.Add(per)
    '            End If
    '            'ElseIf nd.Checked AndAlso gest_sistem.IsInRol(DirectCast(nd.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User)) = True Then
    '            '    If TypeOf nd.Tag Is INFRA.Familia Then
    '            '        per = New INFRA.Familia
    '            '        per.codigo = DirectCast(nd.Tag, INFRA.Familia).codigo
    '            '        per.descripcion = DirectCast(nd.Tag, INFRA.Familia).descripcion
    '            '        perad = CheckPermisoRec(per, nd, user)
    '            '        p.Add(perad)
    '            '    Else
    '            '        per = New INFRA.Patente
    '            '        per.codigo = DirectCast(nd.Tag, INFRA.Patente).codigo
    '            '        per.descripcion = DirectCast(nd.Tag, INFRA.Patente).descripcion
    '            '        p.Add(per)
    '            '    End If

    '        End If
    '    Next
    '    Return p
    'End Function

    'Private Function UncheckPermiso() As List(Of INFRA.Componente)
    '    Dim p As INFRA.Componente = Nothing
    '    Dim p1 As INFRA.Componente = Nothing
    '    Dim permisos As New List(Of INFRA.Componente)
    '    Dim gest_sistem As New SL.GestorSistema
    '    For Each node As TreeNode In TreeView1.Nodes
    '        If node.Checked = False AndAlso gest_sistem.IsInRol(DirectCast(node.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User)) = True Then
    '            p = New INFRA.Familia
    '            p.codigo = DirectCast(node.Tag, INFRA.Familia).codigo
    '            p.descripcion = DirectCast(node.Tag, INFRA.Familia).descripcion
    '            If node.Nodes.Count > 0 Then
    '                p1 = (UncheckPermisoRec(p, node, DirectCast(ListBox1.SelectedItem, INFRA.User)))
    '            End If
    '            If p1 IsNot Nothing Then
    '                permisos.Add(p1)
    '            End If
    '        End If
    '    Next
    '    Return permisos
    'End Function

    'Private Function UncheckPermisoRec(p As INFRA.Componente, node As TreeNode, user As INFRA.User) As INFRA.Componente
    '    Dim per As INFRA.Componente = Nothing
    '    Dim perad As INFRA.Componente = Nothing
    '    Dim gest_sistem As New SL.GestorSistema
    '    For Each nd As TreeNode In node.Nodes
    '        If nd.Checked = False AndAlso gest_sistem.IsInRol(DirectCast(node.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User)) = True Then
    '            If TypeOf nd.Tag Is INFRA.Familia Then
    '                per = New INFRA.Familia
    '                per.codigo = DirectCast(nd.Tag, INFRA.Familia).codigo
    '                per.descripcion = DirectCast(nd.Tag, INFRA.Familia).descripcion
    '                perad = UncheckPermisoRec(per, nd, user)
    '                p.Add(perad)
    '            Else
    '                per = New INFRA.Patente
    '                per.codigo = DirectCast(nd.Tag, INFRA.Patente).codigo
    '                per.descripcion = DirectCast(nd.Tag, INFRA.Patente).descripcion
    '                p.Add(per)
    '            End If

    '        End If
    '    Next
    '    Return p
    'End Function

    'Private Sub Unchecknodes()
    '    For Each nd As TreeNode In TreeView1.Nodes
    '        DirectCast(nd, TreeNode).Checked = False
    '        If nd.Nodes.Count > 0 Then
    '            uncheckChildren(nd, False)
    '        End If
    '    Next
    'End Sub

    'Private Sub uncheckChildren(node As TreeNode, check As Boolean)
    '    For Each nd In node.Nodes
    '        DirectCast(nd, TreeNode).Checked = check
    '        If DirectCast(nd, TreeNode).Nodes.Count > 0 Then
    '            uncheckChildren(nd, False)
    '        End If
    '    Next

    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim gest_lng As New SL.GestorLenguaje
        If estado = False Then
            Me.Hide()
        Else
            MessageBox.Show(gest_lng.ChangeLangMsg("GestorPermisos", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("MDI_Closing", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        gest_lng = Nothing
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If usuario IsNot Nothing Then
            Dim gest_sist As New SL.GestorSistema
            Dim gest_lng As New SL.GestorLenguaje
            If e.Node.Checked Then
                Dim q = usuario.permisos.Where(Function(comp) comp.codigo = DirectCast(e.Node.Tag, INFRA.Componente).codigo).FirstOrDefault
                If q Is Nothing Then
                    Dim p As New INFRA.Patente
                    p.codigo = DirectCast(e.Node.Tag, INFRA.Componente).codigo
                    p.descripcion = DirectCast(e.Node.Tag, INFRA.Componente).descripcion
                    p.principal = DirectCast(e.Node.Tag, INFRA.Componente).principal
                    MessageBox.Show(gest_sist.AsignarPermisos(usuario, p), gest_lng.ChangeLangMsg("MDI_Closing", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadUsers()
                    ValidateNode(usuario)
                    estado = True
                End If
            ElseIf e.Node.Checked = False Then
                Dim q = usuario.permisos.Where(Function(comp) comp.codigo = DirectCast(e.Node.Tag, INFRA.Componente).codigo).FirstOrDefault
                If q IsNot Nothing Then
                    Dim p As New INFRA.Patente
                    p.codigo = DirectCast(e.Node.Tag, INFRA.Componente).codigo
                    p.descripcion = DirectCast(e.Node.Tag, INFRA.Componente).descripcion
                    p.principal = DirectCast(e.Node.Tag, INFRA.Componente).principal
                    MessageBox.Show(gest_sist.RemoverPermisos(usuario, p), gest_lng.ChangeLangMsg("MDI_Closing", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadUsers()
                    ValidateNode(usuario)
                    estado = True
                End If
            End If
            gest_sist = Nothing
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gest_lng As New SL.GestorLenguaje
        Dim result As Integer = MessageBox.Show(gest_lng.ChangeLangMsg("GestorPermisos", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), gest_lng.ChangeLangMsg("MDI_Closing", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim gest_sistema As New SL.GestorSistema
            gest_sistema.GrabarDVV()
            Application.Exit()
        End If
        gest_lng = Nothing
    End Sub

    Private Sub Adm_Permisos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = False
    End Sub
End Class