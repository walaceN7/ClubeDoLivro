﻿
namespace ClubeDoLivro.Domains
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<Livro> Livros { get; set; }
        public int LivrosEscritos => Livros.Count;

        public Autor()
        {
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            if (!Livros.Any(l => l.Id == livro.Id) && livro.EhValido())
            {
                Livros.Add(livro);
                livro.AdicionarAutor(this);
            }
        }

        public bool EhValido()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(Sobrenome);                
        }
    }
}
