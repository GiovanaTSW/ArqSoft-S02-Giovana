namespace AhorcadoTSW
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"=== VIBORITA ===   Puntos: {_motor.Puntos}");
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.Write("|");

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    if (_motor.Cuerpo.First() == pos)
                        Console.Write("@");           // cabeza
                    else if (_motor.Cuerpo.Contains(pos))
                        Console.Write("o");           // cuerpo
                    else if (_motor.Comida == pos)
                        Console.Write("*");           // comida
                    else
                        Console.Write(" ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.WriteLine("Flechas: mover   |   Q: salir");
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje) =>
            Console.WriteLine(mensaje);  // igual que en ConsolaUI ← reutiliza la idea
    }
}