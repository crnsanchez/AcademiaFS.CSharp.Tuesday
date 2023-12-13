using AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio.Entities;

namespace AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio
{
    public class EstudiantePromedioService
    {
        private static readonly List<Estudiante> Estudiantes = [];
        public EstudiantePromedioService()
        {

        }

        public Estudiante ObtenerPromedioEstudiante(int estudianteID)
        {
            List<Estudiante> estudiantes = Estudiantes;

            if (estudianteID.Equals(0))
            {
                throw new ArgumentNullException(nameof(estudianteID), "Estudiantes Invalido");
            }
            Estudiante? estudiante = estudiantes.Find(x => x.Id == estudianteID);

            return estudiante is null ?
                   throw new InvalidOperationException($"No se encontro estudiante con Id: {estudianteID}") :
                   estudiante;
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            if (estudiante is null)
            {
                throw new ArgumentNullException(nameof(estudiante), "Estudiantes Invalido");
            }

            Estudiantes.Add(estudiante);
        }

        public void AgregarEstudiante(List<Estudiante> estudiantes)
        {
            if (estudiantes is null)
            {
                throw new ArgumentNullException(nameof(estudiantes), "Estudiantes Invalido");
            }


        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            List<Estudiante> estudiantes = Estudiantes;

            if (estudiantes.Count == 0)
            {
                throw new InvalidOperationException("No hay estudiantes registrados");
            }

            return estudiantes;
        }

        public string ObtenesEdadPromedioEstudiantes()
        {
            List<Estudiante> estudiantes = ObtenerEstudiantes();

            int promedioEdad = 0;
            if (estudiantes.Count > 0)
            {
                int sumaEdades = estudiantes.Sum(e => e.Edad);
                promedioEdad = sumaEdades / estudiantes.Count;
            }
            return $"El promedio de edades de los estudiantes es: {promedioEdad}";

        }

        public bool CalificacionEsAprobatoria(int calificacion)
        {
            if (calificacion < 70)
            {
                return false;
            }
            return true;
        }

        public List<Estudiante> BuscarEstudiantePorNombre(string nombreEstudiante)
        {

            List<Estudiante> estudiantesFiltrados = Estudiantes
                .Where(estudiante => estudiante.Nombre.Contains(nombreEstudiante))
                .ToList();

            if (estudiantesFiltrados.Count == 0)
            {
                throw new InvalidOperationException($"No se encontro estudiante con nombre: {nombreEstudiante}");
            }

            return estudiantesFiltrados;
        }

    }
}
