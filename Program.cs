using AhorcadoTSW;

Console.ForegroundColor = ConsoleColor.Magenta;

Console.WriteLine(@"
██████╗ ██╗███████╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗██╗██████╗  ██████╗ 
██╔══██╗██║██╔════╝████╗  ██║██║   ██║██╔════╝████╗  ██║██║██╔══██╗██╔═══██╗
██████╔╝██║█████╗  ██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║██║██║  ██║██║   ██║
██╔══██╗██║██╔══╝  ██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║██║  ██║██║   ██║
██████╔╝██║███████╗██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║██║██████╔╝╚██████╔╝
╚═════╝ ╚═╝╚══════╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═╝╚═════╝  ╚═════╝ 
");

Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"╔═════════════════════════════╗");
Console.WriteLine($"║     >>> SÚPERCONSOLA <<<    ║");
Console.WriteLine($"╠═════════════════════════════╣");
Console.WriteLine($"║ ¿Qué juego quieres jugar?   ║");
Console.WriteLine($"╠═════════════════════════════╣");
Console.WriteLine($"║ [1] > Ahorcado              ║");
Console.WriteLine($"╠═════════════════════════════╣");
Console.WriteLine($"║ [2] > Viborita              ║");
Console.WriteLine($"╚═════════════════════════════╝");

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.Write("Selecciona un juego: ");
Console.Write("");


var opcion = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Green;

string[] frames =
{
    "[    ]",
    "[=   ]",
    "[==  ]",
    "[=== ]",
    "[====]"
};

foreach (var frame in frames)
{
    Console.Clear();
    Console.WriteLine("CARGANDO " + frame);
    Thread.Sleep(250);
    Console.ResetColor();
}


if (opcion == "2")
{
    Console.CursorVisible = false;
    bool seguirJugando = true;

    while (seguirJugando)
    {
        // Se crea instancia nueva cada partida para reiniciar el estado
        var motorVibora = new MotorViborita();
        var uiVibora = new ConsolaUIViborita(motorVibora);

        Console.Clear();

        while (!motorVibora.Ganado() && !motorVibora.Perdido())
        {
            uiVibora.MostrarTablero();

            var tecla = uiVibora.LeerTecla();

            if (tecla == ConsoleKey.Q)
                break;

            if (tecla != ConsoleKey.NoName)
                motorVibora.CambiarDireccion(tecla);

            motorVibora.Avanzar();

            Thread.Sleep(150);
        }

        uiVibora.MostrarTablero();

        uiVibora.MostrarMensaje(motorVibora.Ganado()
            ? "\n¡Ganaste! Llegaste a 100 puntos."
            : $"\nGame over. Puntos: {motorVibora.Puntos}");

        Console.Write("\n¿Quieres jugar otra vez? (s/n): ");
        var respuesta = Console.ReadLine()?.ToLower();
        seguirJugando = respuesta == "s";
    }

    Console.CursorVisible = true;
    Console.WriteLine("\n¡Hasta luego!");
}
else
{
    // Tu lógica original del Ahorcado con Categorías
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"╔════════════════════════╗");
    Console.WriteLine($"║  Elige una categoria:  ║");
    Console.WriteLine($"╠════════════════════════╣");
    Console.WriteLine($"║ [1] > Arquitectura     ║");
    Console.WriteLine($"╠════════════════════════╣");
    Console.WriteLine($"║ [2] > POO              ║");
    Console.WriteLine($"╠════════════════════════╣");            
    Console.WriteLine($"║ [3] > .NET             ║");
    Console.WriteLine($"╠════════════════════════╣");
    Console.WriteLine($"║ [4] > Animales         ║");
    Console.WriteLine($"╚════════════════════════╝");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("Selecciona una opción: ");

    string categoria = Console.ReadLine() switch
    {
        "1" => "Arquitectura",
        "2" => "POO",
        "3" => ".NET",
        "4" => "Animales",
        _ => "POO"
    };

    var repositorio = new PalabrasEnMemoria(categoria);
    bool continuar = true;

    while (continuar)
    {
        var motorAhorcado = new MotorAhorcado(repositorio);
        var uiAhorcado = new ConsolaUI(motorAhorcado);

        Console.Clear();
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("=== AHORCADO ===");

        while (!motorAhorcado.Ganado() && !motorAhorcado.Perdido())
        {
            uiAhorcado.MostrarTablero();
            char letra = uiAhorcado.PedirLetra();

            if (motorAhorcado.LetraYaUsada(letra))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                uiAhorcado.MostrarMensaje(" [!] Ya usaste esa letra.");
                continue;
            }
            motorAhorcado.RegistrarLetra(letra);
        }

        uiAhorcado.MostrarTablero();

        if (motorAhorcado.Ganado())
        uiAhorcado.MostrarMensaje($"\n¡Ganaste! La palabra era: {motorAhorcado.PalabraSecreta}");
        else
            uiAhorcado.MostrarMensaje($"\nPerdiste. La palabra era: {motorAhorcado.PalabraSecreta}");

        continuar = uiAhorcado.PreguntarOtraVez();
    }
}