using ClubeDoLivro.Domains;
using FluentAssertions;

namespace ClubeDoLivro.Testes
{
    public class LivroTest
    {
        private readonly Livro _livro;

        public LivroTest()
        {
            _livro = new Livro();
        }

        [Fact]
        public void QuandoEuCrioUmLivro_OLivroDeveSerCriadoCorretamente()
        {
            Assert.NotNull(_livro);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_AQuantidadeDeAutoresDeveSerZero()
        {
            _livro.QuantidadeDeAutores.Should().Be(0);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadePaginasDeveSerNula()
        {
            _livro.Paginas.Should().Be(0);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeEdicaoDeveSerNula()
        {
            Assert.Null(_livro.Edicao);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeNomeDoLivroDeveSerNula()
        {
            Assert.Null(_livro.NomeDoLivro);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeCodigoISBNDeveSerNula()
        {
            Assert.Null(_livro.CodigoISBN);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeVolumeDeveSerNula()
        {
            Assert.Null(_livro.Volume);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeIdDeveSerZero()
        {
            Assert.Equal(0, _livro.Id);
        }

        [Fact]
        public void QuandoEudAdicionoUmAutorParaOLivro_EsseAutorPrecisaAtualizarAListaDeLivrosEscritos()
        {
            //Arrange
            var autor = new Autor();
            var livro = TesteLivroFacotry.ObterLivro(1);

            //Act
            livro.AdicionarAutor(autor);

            //Assert
            livro.QuantidadeDeAutores.Should().Be(1);

            autor.Livros.Should().NotBeEmpty();
            autor.Livros.Should().HaveCount(1);
        }
    }
}