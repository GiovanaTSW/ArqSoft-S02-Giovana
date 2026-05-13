namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo", "encapsulamiento", "herencia"
        };
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            while (_intentosRestantes > 0)
            {
                MostrarTablero();
                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    Console.Write("\n¿Jugar otra vez? (s/n): ");
                    if (Console.ReadLine()?.ToLower() == "s") new Juego().Jugar();
                    return;
                }
                Console.Write("\nIngresa una letra: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;
                char letra = input[0];
                if (_letrasUsadas.Contains(letra)) { Console.WriteLine("Ya usaste esa letra."); continue; }
                _letrasUsadas.Add(letra);
                if (!_palabraSecreta.Contains(letra)) _intentosRestantes--;
            }
            MostrarTablero();
            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s") new Juego().Jugar();
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
                if (!_letrasUsadas.Contains(c)) return false;
            return true;
        }

        private void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            if (_intentosRestantes <= 3)
                Console.WriteLine($"Pista: la palabra empieza con '{_palabraSecreta[0]}'");
            Console.Write("Palabra: ");
            foreach (char c in _palabraSecreta)
                Console.Write(_letrasUsadas.Contains(c) ? c : '_');
            Console.WriteLine();
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
            Console.WriteLine(etapas[6 - _intentosRestantes]);
        }
    }
}