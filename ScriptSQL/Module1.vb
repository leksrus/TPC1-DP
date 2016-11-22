Imports System.Diagnostics
Module Module1

    Sub Main()
        Dim comando As String = String.Empty
        Dim servidor As String = String.Empty
        Dim instancia As String = String.Empty
        Console.WriteLine("Ingrese el nombre de servidor o q para salir")
        servidor = Console.ReadLine()
        Do While Not servidor.Equals("q")
            If Not String.IsNullOrWhiteSpace(servidor) Then
                Console.WriteLine("Ingrese el nombre de la instancia de SQL")
                instancia = Console.ReadLine
                If Not String.IsNullOrWhiteSpace(instancia) Then
                    Dim ruta As String = AppDomain.CurrentDomain.BaseDirectory
                    Dim process As New Process()
                    Dim startInfo As New System.Diagnostics.ProcessStartInfo()
                    startInfo.FileName = "cmd.exe"
                    startInfo.Arguments = "/c sqlcmd -S " & servidor & "\" & instancia & " -i " & "C:\Backup" & "\script.sql -o C:\Backup\log.txt"
                    startInfo.UseShellExecute = True
                    process.StartInfo = startInfo
                    process.Start()
                End If
            End If
            Console.WriteLine("Ingrese el nombre de servidor o q para salir")
            servidor = Console.ReadLine()
        Loop
    End Sub

End Module
