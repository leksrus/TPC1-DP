Public Class Gestion_Prof
    Public Function ListarRutina(uncleinte As Negocio.Cliente) As List(Of Negocio.Rutina)
        Dim mp_rutina As New DAL.Mp_rutina
        Dim rutinas As List(Of Negocio.Rutina) = mp_rutina.Seleccionar(uncleinte)
        Return rutinas
    End Function
End Class
