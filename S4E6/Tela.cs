using System;
using System.Collections.Generic;
using System.Globalization;
using S4E6.dominio;

namespace S4E6 {
    static class Tela {

        public static int ExibirMenu() {
            Console.Clear();
            Console.WriteLine("1 – Listar produtos ordenadamente");
            Console.WriteLine("2 – Cadastrar produto");
            Console.WriteLine("3 – Cadastrar pedido");
            Console.WriteLine("4 – Mostrar dados de um pedido");
            Console.WriteLine("5 – Sair");

            Console.WriteLine();
            Console.Write("Opção: ");

            return int.Parse(Console.ReadLine());
        }

        public static void ListarProdutos() {
            Console.WriteLine();
            Console.WriteLine("LISTAGEM DE PRODUTOS:");
            foreach (var item in Program.produtos) {
                Console.WriteLine(item);
            }
        }

        public static void CadastrarProduto() {
            Console.WriteLine();
            Console.WriteLine("Digite os dados do produto:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Program.produtos.Add(new Produto(codigo, descricao, preco));
            Program.produtos.Sort();
        }

        public static void CadastrarPedido() {
            Console.WriteLine();
            Console.WriteLine("Digite os dados do pedido:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Quantos itens tem o pedido: ");
            int itens = int.Parse(Console.ReadLine());

            Program.pedidos.Add(new Pedido(codigo, new DateTime(ano, mes, dia)));
            int index = Program.pedidos.FindIndex(obj => obj.codigo == codigo);

            for (int i = 0; i < itens; i++) {
                try {
                    CadastrarItemPedido(i, Program.pedidos[index]);
                }
                catch (Exception ex) {
                    Console.WriteLine("Erro inesperado: " + ex);
                }
            }
        }

        public static void CadastrarItemPedido(int i, Pedido pedido) {
            Console.WriteLine();
            Console.WriteLine("Digite os dados do " + (i + 1) + "º item:");
            Console.Write("Produto (código): ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.Write("Porcentagem de desconto: ");
            double desconto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            int index = Program.produtos.FindIndex(obj => obj.codigo == codigo);

            pedido.AdicionarItem(quantidade, desconto, Program.produtos[index]);
        }

        public static void ExibirPedido() {
            Console.WriteLine();
            Console.Write("Digite o código do pedido:");
            int codigo = int.Parse(Console.ReadLine());

            int index = Program.pedidos.FindIndex(obj => obj.codigo == codigo);

            Console.WriteLine(Program.pedidos[index]);
            Console.WriteLine("Itens:");
            foreach (var item2 in Program.pedidos[index].itens) {
                Console.WriteLine(item2);
            }
            Console.Write("Total do pedido: " 
                          + Program.pedidos[index].ValorTotal().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();
        }
    }
}