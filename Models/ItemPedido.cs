using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal SubTotal { get
            {
                return Quantidade * PrecoUnitario;
            }
        }

        public ItemPedido(int id,Produto produto,int quantidade) : this(produto,quantidade)
        {
            Id = id;
        }
        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = produto.Preco;
        }
        public ItemPedido()
        {

        }
    }
}
