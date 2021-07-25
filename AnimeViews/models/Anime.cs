using System.Collections.Generic;

namespace AnimeViews.models
{
    public class Anime
    {
        public int AnimeId { get; set; }
        public string Obra { get; set; }
        public string DataDeLançamento { get; set; }
        public int Temporadas { get; set; }
        public int QtdDeEpisodios { get; set; }
        public List<Pessoa> PessoasViews { get; set; }
    }
}