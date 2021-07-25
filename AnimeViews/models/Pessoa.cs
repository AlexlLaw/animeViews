using System.Collections.Generic;

namespace AnimeViews.models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int AnimeId { get; set; }
        public List<Anime> AnimesViews { get; set; }
    }
}