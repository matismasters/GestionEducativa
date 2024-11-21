using GestionEducativa.Data;

namespace GestionEducativa.Models
{
    public class Semestre
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int OrdenNumero { get; set; }

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public Semestre() { }

        public Semestre(string nombre, int ordenNumero, int carreraId)
        {
            Nombre = nombre;
            OrdenNumero = ordenNumero;
            CarreraId = carreraId;
        }

        public bool EsValido()
        {
            if (string.IsNullOrEmpty(Nombre) || OrdenNumero <= 0 || CarreraId <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
