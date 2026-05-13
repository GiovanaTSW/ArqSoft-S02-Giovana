namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            ["Arquitectura"] = new() { "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento" },
            ["POO"] = new() { "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase" },
            [".NET"] = new() { "ensamblado", "namespace", "interfaz", "delegado", "middleware" }
        };

        private readonly string _categoriaElegida;

        public PalabrasEnMemoria(string categoria)
        {
            _categoriaElegida = categoria;
        }

        public string ObtenerPalabraAleatoria()
        {
            var palabras = _categorias[_categoriaElegida];
            var random = new Random();
            return palabras[random.Next(palabras.Count)];
        }
    }
}