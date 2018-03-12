using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
      
        [DataMember]
        public Produto Produto { get; private set; }
        [DataMember]
        public int Quantidade { get; private set; }
        [DataMember]
        public decimal PrecoUnitario { get; private set; }
        
        public decimal SubTotal { get
            {
                return Quantidade * PrecoUnitario;
            }
        }
        public void AtualizaQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }
        public ItemPedido(int id,Produto produto,int quantidade) : this(produto,quantidade)
        {
            this.Id = id;
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
