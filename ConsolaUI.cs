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
        MostrarAhorcado();
        Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
        Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

        if (_motor.MostrarPista)
            Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");

        Console.Write("Palabra: ");
        foreach (char c in _motor.PalabraSecreta)
            Console.Write(_motor.LetrasUsadas.Contains(c) ? c : '_');
        Console.WriteLine();
    }

    public char PedirLetra()
    {
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
