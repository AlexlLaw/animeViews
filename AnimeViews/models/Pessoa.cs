using System.Collections.Generic;

namespace AnimeViews.models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<AnimePessoa> AnimePessoas { get; set; }
    }
}