namespace AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo.Entities
{
    public class ConteoPersonas
    {
        public required List<string> PeopleNames { get; set; }

        public required int DividirPor { get; set; }

        public ConteoPersonas()
        {
            PeopleNames = [];
            DividirPor = 0;
        }
    }
}
