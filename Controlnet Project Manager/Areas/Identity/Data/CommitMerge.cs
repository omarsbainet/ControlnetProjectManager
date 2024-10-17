namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class CommitMerge : IComparable<CommitMerge>
    {
        private string autor;
        private string comentario; // NOTA: En el caso de ser un Merge, será su título.
        private DateTimeOffset fecha;
        private bool esCommit;

        public CommitMerge(string autor, string comentario, DateTimeOffset fecha, bool esCommit)
        {
            Autor = autor;
            Comentario = comentario;
            Fecha = fecha;
            EsCommit = esCommit;
        }

        public string Autor { get => autor; set => autor = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public DateTimeOffset Fecha { get => fecha; set => fecha = value; }
        public bool EsCommit { get => esCommit; set => esCommit = value; }

        public int CompareTo(CommitMerge other)
        {
            // Comparamos las fechas en orden descendente
            return other.Fecha.CompareTo(this.Fecha);
        }
    }
}
