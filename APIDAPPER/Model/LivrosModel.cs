namespace APIDAPPER.Model
{
    public class LivrosModel 
    {
        public int IdLivro { get; set; }

        public string NomeLivro { get; set; } = string.Empty;

        public string NomeAutor {  get; set; } = string.Empty;  

        public DateTime DataLancamento { get; set; }

        public int IdAutor { get; set; } 
    }
}
