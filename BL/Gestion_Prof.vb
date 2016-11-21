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
End Class
