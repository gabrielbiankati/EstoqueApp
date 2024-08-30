using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp
{
    public class Estoque
    {
        private Dictionary<string, int> _produtos = new Dictionary<string, int>();

        public void AdicionarProduto(string nomeProduto, int quantidade)
        {
            if (_produtos.ContainsKey(nomeProduto))
            {
                _produtos[nomeProduto] += quantidade;
            }
            else
            {
                _produtos[nomeProduto] = quantidade; 
            }
        }

        public int ObterQuantidade(string nomeProduto)
        {
            return _produtos.ContainsKey(nomeProduto) ? _produtos[nomeProduto] : 0;
        }

        public void RemoverProduto(string nomeProduto, int quantidade)
        {
            if (_produtos.ContainsKey(nomeProduto) && _produtos[nomeProduto] >= quantidade)
            {
                _produtos[nomeProduto] -= quantidade;
            }
            else
            {
                throw new InvalidOperationException("Quantidade insuficiente em estoque");
            }

        }

        public List<string> VerificarEstoque()
        {
            return new List<string>(_produtos.Keys);
        }

    }
}
