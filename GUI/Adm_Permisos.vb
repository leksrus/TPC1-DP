Public Class Adm_Permisos
    Dim usuario As INFRA.User = Nothing
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadUsers()
    End Sub
#Region "eventos"
    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            usuario = Nothing
            ValidateNode()
            usuario = DirectCast(sender, ListBox).SelectedItem
        End If
    End Sub

    Private Sub ValidateNode()
        Dim gest_sistem As New SL.GestorSistema
        For Each nd As TreeNode In TreeView1.Nodes
            nd.Checked = gest_sistem.IsInRol(DirectCast(nd.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User))
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim permisos As List(Of INFRA.Componente) = checkPermiso()
        Dim gest_sistem As New SL.GestorSistema
        If permisos IsNot Nothing Then
            MessageBox.Show(gest_sistem.AsignarPermisos(permisos, usuario))
        End If

        gest_sistem = Nothing
    End Sub

    Private Function checkPermiso() As List(Of INFRA.Componente)
        Dim p As INFRA.Componente = Nothing
        Dim p1 As INFRA.Componente = Nothing
        Dim permisos As List(Of INFRA.Componente) = Nothing
        Dim gest_sistem As New SL.GestorSistema
        For Each node As TreeNode In TreeView1.Nodes
            If node.Checked AndAlso gest_sistem.IsInRol(DirectCast(node.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User)) = False Then
                permisos = New List(Of INFRA.Componente)
                p = New INFRA.Familia
                p.codigo = DirectCast(node.Tag, INFRA.Familia).codigo
                p.descripcion = DirectCast(node.Tag, INFRA.Familia).descripcion
                If node.Nodes.Count > 0 Then
                    p1 = (CheckPermisoRec(p, node, DirectCast(ListBox1.SelectedItem, INFRA.User)))
                End If
                If p1 IsNot Nothing Then
                    permisos.Add(p1)
                End If
            End If
        Next
        Return permisos
    End Function

    Private Function CheckPermisoRec(p As INFRA.Componente, node As TreeNode, user As INFRA.User) As INFRA.Componente
        Dim per As INFRA.Componente = Nothing
        Dim perad As INFRA.Componente = Nothing
        Dim gest_sistem As New SL.GestorSistema
        For Each nd As TreeNode In node.Nodes
            If nd.Checked AndAlso gest_sistem.IsInRol(DirectCast(node.Tag, INFRA.Componente), DirectCast(ListBox1.SelectedItem, INFRA.User)) = False Then
                If TypeOf nd.Tag Is INFRA.Familia Then
                    per = New INFRA.Familia
                    per.codigo = DirectCast(nd.Tag, INFRA.Familia).codigo
                    per.descripcion = DirectCast(nd.Tag, INFRA.Familia).descripcion
                    perad = CheckPermisoRec(per, nd, user)
                    p.Add(per)
                Else
                    per = New INFRA.Patente
                    per.codigo = DirectCast(nd.Tag, INFRA.Patente).codigo
                    per.descripcion = DirectCast(nd.Tag, INFRA.Patente).descripcion
                    p.Add(per)
                End If

            End If
        Next
        Return p
    End Function

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

    End Sub
End Class