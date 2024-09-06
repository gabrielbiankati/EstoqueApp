using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp
{
    public class Estoque
    {
        private Dictionary<string, Produto> _produtos = 
            new Dictionary<string, Produto>();

        public void AdicionarProduto(string nomeProduto, int quantidade)
        {
            if (_produtos.ContainsKey(nomeProduto))
            {
                _produtos[nomeProduto].Quantidade += quantidade;
            }
            else
            {
                _produtos[nomeProduto] = new Produto(nomeProduto, quantidade); 
            }
        }

        public int ObterQuantidade(string nomeProduto)
        {
            return _produtos.ContainsKey(nomeProduto) ? _produtos[nomeProduto].Quantidade : 0;
        }

        public void RemoverProduto(string nomeProduto, int quantidade)
        {
            if (_produtos.ContainsKey(nomeProduto) && _produtos[nomeProduto].Quantidade >= quantidade)
            {
                _produtos[nomeProduto].Quantidade -= quantidade;
            }
            else
            {
                throw new InvalidOperationException("Quantidade insuficiente em estoque");
            }

        }

        public List<string> VerificarEstoque()
        {
            var listaEstoque = new List<string>();
            foreach (var item in _produtos)
            {
                listaEstoque.Add($"Produto: {item.Key}, + Quantidade: {item.Value.Quantidade}");
            }
            return new List<string>(_produtos.Keys);
        }

        public decimal ObterPreco(string nomeProduto)
        {
            return _produtos.ContainsKey(nomeProduto) ? _produtos[nomeProduto].Preco : 0;
        }

        public void AtualizarPreco(string nomeProduto, decimal preco)
        {
            if (_produtos.ContainsKey(nomeProduto))
            {
                _produtos[nomeProduto].Preco = preco;
            }
            else
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }
        }

        public decimal CalcularValorTotalEstoque()
        {
            decimal valorTotal = 0;
            foreach (var item in _produtos.Values)
            {
                valorTotal += item.Quantidade * item.Preco;
            }
            return valorTotal;
        }

        public List<string> RelatorioEstoque()
        {
            var relatorio = new List<string>();
            foreach(var item in _produtos.Values)
            {
                relatorio.Add($"Produto: {item.Nome}, Quantidade: {item.Quantidade}, Preço Unitário: {item.Preco}, " +
                    $"Valor total: {item.Quantidade * item.Preco:F2}");
            }
            return relatorio;
        }
    }
}
