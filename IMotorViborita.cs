using AhorcadoTSW;

namespace AhorcadoTSW
{
    public class MotorViborita : IMotorJuego
    {
        // — Tamaño del tablero —
        public int Ancho { get; } = 28;
        public int Alto { get; } = 20;

        // — Estado de la víbora —
        private readonly LinkedList<(int x, int y)> _cuerpo = new();
        private (int x, int y) _direccion = (1, 0); // empieza moviéndose a la derecha
        private (int x, int y) _comida;
        private bool _perdido = false;

        public int Puntos { get; private set; } = 0;

        // Propiedades de solo lectura para la UI
        public IEnumerable<(int x, int y)> Cuerpo => _cuerpo;
        public (int x, int y) Comida => _comida;

        public MotorViborita()
        {
            // Víbora inicial en el centro con 3 segmentos
            _cuerpo.AddFirst((Ancho / 2, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 1, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 2, Alto / 2));

            GenerarComida();
        }

        public void CambiarDireccion(ConsoleKey tecla)
        {
            _direccion = tecla switch
            {
                ConsoleKey.UpArrow when _direccion.y != 1 => (0, -1),
                ConsoleKey.DownArrow when _direccion.y != -1 => (0, 1),
                ConsoleKey.LeftArrow when _direccion.x != 1 => (-1, 0),
                ConsoleKey.RightArrow when _direccion.x != -1 => (1, 0),
                _ => _direccion
            };
        }

        public void Avanzar()
        {
            var cabeza = _cuerpo.First!.Value;

            var nueva = (cabeza.x + _direccion.x,
                         cabeza.y + _direccion.y);

            // Colisión con paredes
            if (nueva.Item1 < 0 || nueva.Item1 >= Ancho ||
                nueva.Item2 < 0 || nueva.Item2 >= Alto)
            {
                _perdido = true;
                return;
            }

            // Colisión con sí misma
            if (_cuerpo.Contains(nueva))
            {
                _perdido = true;
                return;
            }

            _cuerpo.AddFirst(nueva);

            if (nueva == _comida)
            {
                Puntos++;
                GenerarComida();

                // No quitamos la cola → la víbora crece
            }
            else
            {
                _cuerpo.RemoveLast(); // movimiento normal
            }
        }

        private void GenerarComida()
        {
            var random = new Random();

            do
            {
                _comida = (random.Next(Ancho), random.Next(Alto));
            }
            while (_cuerpo.Contains(_comida));
        }

        public bool Ganado() => Puntos >= 100;   // gana al llegar a 100 puntos

        public bool Perdido() => _perdido;
    }
}