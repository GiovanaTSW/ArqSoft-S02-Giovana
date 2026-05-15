namespace AhorcadoTSW
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        // Colores arcoíris para el cuerpo de la víbora
        private static readonly ConsoleColor[] ColoresArcoiris = new[]
        {
            ConsoleColor.Red,
            ConsoleColor.DarkYellow,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Blue,
            ConsoleColor.Magenta
        };

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);

            // Encabezado más grande
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╔════════════════════════════╗");
            Console.WriteLine($"║ VÍBORITA   Puntos: {_motor.Puntos,-8}║");
            Console.WriteLine($"╚════════════════════════════╝");
            Console.ResetColor();

            // Borde superior de la caja de juego (más grande)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔" + new string('═', _motor.Ancho) + "╗");

            var cuerpoLista = _motor.Cuerpo.ToList();

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("║");

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    if (cuerpoLista[0] == pos)
                    {
                        // Cabeza siempre en verde brillante
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▓");
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        // Cuerpo en arcoíris según índice
                        int indice = cuerpoLista.IndexOf(pos);
                        Console.ForegroundColor = ColoresArcoiris[indice % ColoresArcoiris.Length];
                        Console.Write("▓");
                    }
                    else if (_motor.Comida == pos)
                    {
                        // Comida en rojo brillante
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("║");
            }

            // Borde inferior
            Console.WriteLine("╚" + new string('═', _motor.Ancho) + "╝");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Flechas: mover   |   Q: salir");
            Console.ResetColor();
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje) =>
            Console.WriteLine(mensaje);
    }
}