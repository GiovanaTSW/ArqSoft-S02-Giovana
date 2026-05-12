namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo", "encapsulamiento", "herencia", "alienigena", "tilapia"
        };

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();
            return _palabras[random.Next(_palabras.Count)];
        }
    }
}