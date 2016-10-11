Public Class Adm_Permisos

    Private Sub LoadPermisos()
        Dim gestsistema As New SL.GestorSistema
        Dim nodo As TreeNode = Nothing
        Dim percomponente As INFRA.Componente = Nothing
        Dim familia As INFRA.Familia = Nothing
        Dim patente As INFRA.Patente = Nothing
        Dim permisos As List(Of INFRA.Componente) = gestsistema.TraerPermisos
        For Each per As INFRA.Componente In permisos
            nodo = New TreeNode
            nodo.Text = per.descripcion
            If TypeOf per Is INFRA.Familia Then
                familia = DirectCast(per, INFRA.Familia)
                For Each leaf As INFRA.Componente In familia.List
                    If TypeOf leaf Is INFRA.Patente Then
                        nodo.Nodes.Add(leaf.descripcion)
                    End If
                Next
            End If
            TreeView1.Nodes.Add(nodo)
        Next

    End Sub

    Private Sub Adm_Permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPermisos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class