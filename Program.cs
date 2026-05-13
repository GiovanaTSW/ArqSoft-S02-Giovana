using Ahorcado;

Console.WriteLine("Elige una categoria:");
Console.WriteLine("1. Arquitectura");
Console.WriteLine("2. POO");
Console.WriteLine("3. .NET");
Console.Write("Opcion: ");

string categoria = Console.ReadLine() switch
{
    "1" => "Arquitectura",
    "2" => "POO",
    "3" => ".NET",
    _ => "POO"
};

var repositorio = new PalabrasEnMemoria(categoria);
bool continuar = true;

while (continuar)
{
    var motor = new MotorAhorcado(repositorio);
    var ui = new ConsolaUI(motor);

    Console.WriteLine("=== AHORCADO ===");

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            continue;
        }
        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

    continuar = ui.PreguntarOtraVez();
}