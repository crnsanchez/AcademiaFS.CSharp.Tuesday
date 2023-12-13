namespace AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio.Entities
{
    public class Estudiante
    {
        public required int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double PromedioNotas { get; set; }


        public Estudiante()
        {
            Id = 0;
            Nombre = "";
            Edad = 0;
            PromedioNotas = 0.00;
        }
    }
}
