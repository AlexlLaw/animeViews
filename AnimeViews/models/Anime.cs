using System.Collections.Generic;

namespace AnimeViews.models
{
    public class Anime
    {
        public int AnimeId { get; set; }
        public string Obra { get; set; }
        public string DataDeLanĂ§amento { get; set; }
        public int Temporadas { get; set; }
        public int QtdDeEpisodios { get; set; }
        public List<AnimePessoa> AnimePessoas { get; set; }
    }
}