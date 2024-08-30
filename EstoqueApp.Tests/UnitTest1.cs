namespace EstoqueApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AdicionarProduto_DeveAdicionarProdutoAoEstoque()
        {
            // Arrange
            var estoque = new Estoque();
            string nomeProduto = "PC";
            int quantidade = 10;

            // Action
            estoque.AdicionarProduto(nomeProduto, quantidade);

            // Assert
            Assert.Equal(quantidade, estoque.ObterQuantidade(nomeProduto));
        }

        [Fact]

        public void RemoverProduto_DeveDiminuirQuantidadeDoProduto()
        {
            // Arrange
            var estoque = new Estoque();
            string nomeProduto = "PC";

            estoque.AdicionarProduto(nomeProduto ,10);

            // Act
            estoque.RemoverProduto(nomeProduto, 5);

            // Assert
            Assert.Equal(5, estoque.ObterQuantidade(nomeProduto));

        }

        [Fact]

        public void RemoverProduto_QuandoQuantidadeInsuficiente_DeveLançarExeção()
        {
            // Arrange
            var estoque = new Estoque();
            string nomeProduto = "PC";
            estoque.AdicionarProduto(nomeProduto ,5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => estoque.RemoverProduto(nomeProduto, 10));
        }

        [Fact]

        public void VerificarEstoque_DeveRetornarProdutosEmEstoque()
        {
            // Arrange
            var estoque = new Estoque();
            estoque.AdicionarProduto("PC", 10);
            estoque.AdicionarProduto("Notebook", 20);

            // Act
            var produtosEmEstoque = estoque.VerificarEstoque();

            // Assert
            Assert.Contains("PC", produtosEmEstoque);
            Assert.Contains("Notebook", produtosEmEstoque);

        }
    }
}