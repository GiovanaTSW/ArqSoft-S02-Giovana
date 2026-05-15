using AhorcadoTSW;

Console.WriteLine($"╔═════════════════════════════╗");
Console.WriteLine($"║BIENVENIDO A LA SÚPERCONSOLA ║");
Console.WriteLine($"╚═════════════════════════════╝");
Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");

var opcion = Console.ReadLine();

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
    Console.WriteLine("\nElige una categoria:");
    Console.WriteLine("1. Arquitectura");
    Console.WriteLine("2. POO");
    Console.WriteLine("3. .NET");
    Console.WriteLine("4. Animales");
    Console.Write("Opcion: ");

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
        Console.WriteLine("=== AHORCADO ===");

        while (!motorAhorcado.Ganado() && !motorAhorcado.Perdido())
        {
            uiAhorcado.MostrarTablero();
            char letra = uiAhorcado.PedirLetra();

            if (motorAhorcado.LetraYaUsada(letra))
            {
                uiAhorcado.MostrarMensaje("Ya usaste esa letra.");
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