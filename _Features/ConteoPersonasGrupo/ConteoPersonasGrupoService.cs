using AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo.Entities;

namespace AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo
{
    public class ConteoPersonasGrupoService
    {
        public ConteoPersonasGrupoService()
        {

        }


        public List<string> ObtenerListadoPersonas(ConteoPersonas conteoPersonas)
        {
            if (conteoPersonas.PeopleNames.Count < conteoPersonas.DividirPor)
            {
                // Entidad Expuesta 
                throw new ArgumentOutOfRangeException("conteoPersonas.DividirPor", "Número de divisiones mayor que la cantidad de personas.");
            }

            List<string> personasRandomizado = RandomizarLista(conteoPersonas.PeopleNames);

            var personasAgrupadas = AgruparPersonas(personasRandomizado, conteoPersonas.DividirPor);

            return personasAgrupadas;
        }

        private List<string> RandomizarLista(List<string> list)
        {
            Random random = new();
            return [.. list.OrderBy(x => random.Next())];
        }

        private List<string> AgruparPersonas(List<string> personasRandomizado, int groupedCountParsed)
        {
            List<string> personasAgrupadas = [];
            int rowsPrinted = groupedCountParsed;
            int groupsFounded = 0;

            foreach (var persona in personasRandomizado)
            {
                if (rowsPrinted == groupedCountParsed)
                {
                    rowsPrinted = 0;
                    groupsFounded++;
                    personasAgrupadas.Add($"===================== Grupo {groupsFounded} =====================");
                }
                personasAgrupadas.Add(persona);
                rowsPrinted++;
            }

            return personasAgrupadas;
        }
    }
}
