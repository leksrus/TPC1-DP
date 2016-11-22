Public Class Gestion_Prof
    Public Function ListarRutina(uncleinte As Negocio.Cliente) As List(Of Negocio.Rutina)
        Dim mp_rutina As New DAL.Mp_rutina
        Dim rutinas As List(Of Negocio.Rutina) = mp_rutina.Seleccionar(uncleinte)
        Return rutinas
    End Function

    Public Function ListarEjercicios(unarutina As Negocio.Rutina) As List(Of Negocio.Ejercicio)
        Dim mp_ejercicio As New DAL.Mp_ejercicio
        Dim ejercicios As List(Of Negocio.Ejercicio) = mp_ejercicio.Seleccionar(unarutina)
        Return ejercicios
    End Function
    Public Function GuardarEjercicios(ejercicios As List(Of Negocio.Ejercicio), rutina As Negocio.Rutina) As String
        Dim ok As Integer = 0
        Dim gestorlng As New SL.GestorLenguaje
        Dim mp_ej As New DAL.Mp_ejercicio
        Dim mp_rutina As New DAL.Mp_rutina
        ok = mp_rutina.Insertar(rutina)
        For Each ej In ejercicios
            ok += mp_ej.Insertar(ej)
        Next
        If ok > 0 Then
            Return gestorlng.ChangeLangMsg("GuardarEjercicios", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("GuardarEjercicios", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function
    Public Function EleminarEjercicio(ejericios As Negocio.Ejercicio) As String
        Dim mp_ej As New DAL.Mp_ejercicio
        Dim gestorlng As New SL.GestorLenguaje
        Dim ok = mp_ej.Borrar(ejericios)
        If ok > 0 Then
            Return gestorlng.ChangeLangMsg("EleminarEjercicio", 1, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        Else
            Return gestorlng.ChangeLangMsg("EleminarEjercicio", 2, INFRA.SesionManager.CrearSesion.User.Language.id_idioma)
        End If
    End Function

End Class
