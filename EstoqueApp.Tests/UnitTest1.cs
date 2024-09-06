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

        public void VerificarEstoque_DeveRetornarListaDeProdutosEmEstoque()
        {
            // Arrange
            var estoque = new Estoque();
            estoque.AdicionarProduto("PC", 10);
            estoque.AdicionarProduto("Notebook", 20);

            // Act
            List<string> produtosEmEstoque = estoque.VerificarEstoque();

            // Assert
            Assert.Contains("Produto: PC, Quantidade: 10", produtosEmEstoque);
            Assert.Contains("Produto: Notebook, Quantidade: 20", produtosEmEstoque);

        }

        [Fact]
        public void AtualizarPreco_DeveAlterarPrecoDoProduto()
        {
            // Arrange
            var estoque = new Estoque();
            string nomeProduto = "PC";
            estoque.AdicionarProduto(nomeProduto, 10);
            decimal novoPreco = 1500.00m;

            // Act
            estoque.AtualizarPreco(nomeProduto, novoPreco);

            // Assert
            Assert.Equal(novoPreco, estoque.ObterPreco(nomeProduto));
        }

        [Fact]
        public void AtualizarPreco_QuandoProdutoNaoExistir_deveLancarExcecao()
        {
            // Arrange
            var estoque = new Estoque();
            string nomeProduto = "PC";
            decimal novoPreco = 1500.00m;

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => estoque.AtualizarPreco(nomeProduto, novoPreco));
        }

        [Fact]
        public void CalcularValorTotalEstoque_DeveRetornarValorTotal()
        {
            // Arrange
            var estoque = new Estoque();
            estoque.AdicionarProduto("Laptop", 10);
            estoque.AtualizarPreco("Laptop", 1500.00m);
            estoque.AdicionarProduto("Mouse", 50);
            estoque.AtualizarPreco("Mouse", 20.00m);

            // Act
            decimal valorTotal = estoque.CalcularValorTotalEstoque();

            // Assert
            Assert.Equal(16000.00m, valorTotal);

        }

        [Fact]
        public void RelatorioEstoque_DeveRetornarRelatorioDetalhado()
        {
            // Arrange
            var estoque = new Estoque();
            estoque.AdicionarProduto("PC", 10);
            estoque.AtualizarPreco("PC", 1500.00m);
            estoque.AdicionarProduto("Notebook", 20);
            estoque.AtualizarPreco("Notebook", 20.00m);

            // Act
            List<string> relatorio = estoque.RelatorioEstoque();

            // Assert
            Assert.Contains("Produto: PC, Quantidade: 10, " + "Preco Unitario: 1500,00, Valor total", produtosEmEstoque);
            Assert.Contains("Produto: Notebook, Quantidade: 20", produtosEmEstoque);
        }
    }
}