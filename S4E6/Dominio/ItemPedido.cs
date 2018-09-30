using System;
using System.Globalization;

namespace S4E6.dominio {
    public class ItemPedido {
        public int quantidade { get; private set; }
        public double porcentagemDesconto { get; private set; }
        public Produto produto { get; private set; }
        public Pedido pedido { get; private set; }

        public ItemPedido(int quantidade, double porcentagemDesconto, Produto produto) {
            this.quantidade = quantidade;
            this.porcentagemDesconto = porcentagemDesconto;
            this.produto = produto;
        }

        public override string ToString() {
            return produto.descricao
                          + ", Preço: " + produto.preco.ToString("F2", CultureInfo.InvariantCulture) 
                          + ", Qte: " + quantidade 
                          + ", Desconto: " + porcentagemDesconto.ToString("F2", CultureInfo.InvariantCulture)
                          + "%, Subtotal: " + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }

        public double SubTotal() {
            return produto.preco * quantidade * ((100 - porcentagemDesconto) / 100);
        }
    }
}
