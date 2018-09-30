using System;
using System.Collections.Generic;

namespace S4E6.dominio {
    public class Pedido {
        public int codigo { get; private set; }
        public DateTime data { get; private set; }
        public List<ItemPedido> itens { get; private set; }

        public Pedido(int codigo, DateTime data) {
            this.codigo = codigo;
            this.data = data;
            itens = new List<ItemPedido>();
        }

        public override string ToString() {
            return "Pedido " + codigo.ToString() +  ", data: " + data.Date.ToString("dd/MM/yyyy");
        }

        public void AdicionarItem(int quantidade, double porcentagemDesconto, Produto produto) {
            itens.Add(new ItemPedido(quantidade, porcentagemDesconto, produto));
        }

        public double ValorTotal() {
            double soma = 0.00;
            foreach (var item in itens) {
                soma += item.SubTotal();
            }
            return soma;
        }
    }
}
