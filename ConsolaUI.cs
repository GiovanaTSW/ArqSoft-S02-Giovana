namespace AhorcadoTSW;

public class ConsolaUI
{
    private readonly MotorAhorcado _motor;

    public ConsolaUI(MotorAhorcado motor)
    {
        _motor = motor;
    }

    public void MostrarTablero()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║         AHORCADO           ║");
        Console.WriteLine("╚════════════════════════════╝");

        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        MostrarAhorcado();

        // TEXTO INFERIOR CYAN
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine($"\nIntentos restantes: {_motor.IntentosRestantes}");
        Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

        if (_motor.MostrarPista)
            Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write("\nPalabra: ");


        foreach (char c in _motor.PalabraSecreta)
        {
            if (_motor.LetrasUsadas.Contains(c))
                Console.Write(c + " ");
            else
                Console.Write("_ ");
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    public char PedirLetra()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\nIngresa una letra: ");
        return Console.ReadLine()[0];
    }

    public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);

    public bool PreguntarOtraVez()
    {
        Console.Write("\n¿Jugar otra vez? (s/n): ");
        return Console.ReadLine()?.ToLower() == "s";
    }

    private void MostrarAhorcado()
    {
        string[] etapas = new string[]
        {
    " -----\n |   |\n     |\n     |\n     |\n     |\n=========",
    " -----\n |   |\n O   |\n     |\n     |\n     |\n=========",
    " -----\n |   |\n O   |\n |   |\n     |\n     |\n=========",
    " -----\n |   |\n O   |\n/|   |\n     |\n     |\n=========",
    " -----\n |   |\n O   |\n/|\\  |\n     |\n     |\n=========",
    " -----\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=========",
    " -----\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n========="
        };
        Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
    }
}
