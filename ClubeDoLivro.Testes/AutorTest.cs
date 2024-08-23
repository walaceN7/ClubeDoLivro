using ClubeDoLivro.Domains;
using FluentAssertions;

namespace ClubeDoLivro.Testes
{
    public class AutorTest
    {
        private readonly Autor _autor;
        public AutorTest()
        {
            _autor = new Autor();
        }

        [Fact]
        public void QuandoEuCrioUmAutor_OAutorDeveSerCriadoCorretamente()
        {
            Assert.NotNull(_autor);
            Assert.NotNull(_autor.Livros);
            Assert.Null(_autor.Nome);
            Assert.Null(_autor.Sobrenome);
            Assert.Equal(0, _autor.Id);
        }

        [Fact]
        public void QuandoEuAdicionoUmLivroNoAutor_AQuantidadeDeLivrosDoAutorDeveAumentarEm1Unidade()
        {
            //Arrange
            var livro = TesteLivroFacotry.ObterLivro();
            var quantiadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantiadeDeLivrosAntes + 1;

            //Act
            _autor.AdicionarLivro(livro);

            //Assert
            Assert.Equal(quantidadeEsperada, _autor.LivrosEscritos);
        }

       

        [Fact]
        public void QuandoEuAdicionoUmLivroNoAutor_OLivroPrecisaConterOAutorNaListaDeAutores()
        {
            //Arrange
            var livro = TesteLivroFacotry.ObterLivro();
            var quantiadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantiadeDeLivrosAntes + 1;

            //Act
            _autor.AdicionarLivro(livro);

            //Assert
            Assert.True(livro.QuantidadeDeAutores == 1);
            livro.FoiEscritoPor(_autor).Should().BeTrue();
        }

        [Fact]
        public void QuandoEuAdicionoDoisLivroNoAutor_OAutorPrecisaTerDoisLivros()
        {
            //Arrange
            var livro1 = TesteLivroFacotry.ObterLivro(1);
            var livro2 = TesteLivroFacotry.ObterLivro(2);
            var quantiadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantiadeDeLivrosAntes + 2;

            //Act
            _autor.AdicionarLivro(livro1);
            _autor.AdicionarLivro(livro2);

            //Assert
            Assert.Contains(livro1, _autor.Livros);
            Assert.Contains(livro2, _autor.Livros);

            _autor.LivrosEscritos.Should().Be(quantidadeEsperada);
        }

        [Fact]
        public void QuandoEuDigoQueUmAutorEscreveuUmLivro_EsseLivroDeveConterOAutorEmSuaListaDeAutores()
        {
            //Arrange
            var livro1 = TesteLivroFacotry.ObterLivro();

            //Act
            _autor.AdicionarLivro(livro1);

            //Assert
            _autor.Livros.Should().NotBeEmpty();
            _autor.Livros.Should().HaveCount(1);

            livro1.QuantidadeDeAutores.Should().Be(1);
        }

        
    }

    public class TesteLivroFacotry
    {
        public static Livro ObterLivro(int id = 0)
        {
            return new Livro { Id = id, CodigoISBN = "113121", Edicao = "1", NomeDoLivro = "C#", Paginas = 1, Volume = "1" };
        }
    }
}
