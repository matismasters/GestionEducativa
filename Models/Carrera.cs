namespace GestionEducativa.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Requerimientos { get; set; }
        public List<Semestre> Semestres { get; set; }

        public Carrera() { }

        public Carrera(string nombre, string descripcion, string requerimientos)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Requerimientos = requerimientos;
        }

        public bool EsValido()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Descripcion) || string.IsNullOrEmpty(Requerimientos))
            {
                return false;
            }

            return true;
        }

        public string AsOption(int selectedId)
        {
            string optionStr = "<option value='";
            optionStr += Id;
            optionStr += "'";

            if (Id == selectedId)
            {
                optionStr += " selected";
            }
            
            optionStr += ">";
            optionStr += Nombre;
            optionStr += "</option>";

            return optionStr;
        }

        /*
         * protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Carrera
        modelBuilder.Entity<Carrera>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Carrera>()
            .HasMany(c => c.Semestres)
            .WithOne(s => s.Carrera)
            .HasForeignKey(s => s.CarreraId);

        // Configuración de Semestre
        modelBuilder.Entity<Semestre>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Semestre>()
            .HasOne(s => s.Carrera)
            .WithMany(c => c.Semestres)
            .HasForeignKey(s => s.CarreraId);

        base.OnModelCreating(modelBuilder);
    }*/
    }
}
