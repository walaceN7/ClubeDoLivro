﻿namespace ClubeDoLivro.Domains
{
    public class Livro
    {
        public int Id { get; set; }
        public string NomeDoLivro { get; set; }
        public string Volume { get; set; }
        public string Edicao { get; set; }
        public string CodigoISBN { get; set; }
        public int Paginas { get; set; }
        private List<Autor> Autores { get; set; }
        public int QuantidadeDeAutores => Autores.Count;
        public bool FoiEscritoPor(Autor autor)
        {
            return Autores.Any(a => a.Id == autor.Id);
        }

        public Livro()
        {
            Autores = new List<Autor>();
        }

        public void AdicionarAutor(Autor autor)
        {
            if (!Autores.Any(a => a.Id == autor.Id))
            {
                Autores.Add(autor);
                autor.AdicionarLivro(this);
            }
        }

        public bool EhValido()
        {
            return !string.IsNullOrWhiteSpace(NomeDoLivro)
                && !string.IsNullOrWhiteSpace(Volume)
                && !string.IsNullOrWhiteSpace(Edicao)
                && !string.IsNullOrWhiteSpace(CodigoISBN)
                && Paginas > 0;
        }
    }
}
