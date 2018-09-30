using System;
using System.Collections.Generic;
using S4E6.dominio;

namespace S4E6 {
    class Program {

        public static List<Pedido> pedidos = new List<Pedido>();
        public static List<Produto> produtos = new List<Produto>();

        public static void Main(string[] args) {
            Program.produtos.Add(new Produto(1001, "Cadeira simples", 500.00));
            Program.produtos.Add(new Produto(1002, "Cadeira acolchoada", 900.00));
            Program.produtos.Add(new Produto(1003, "Sofá de três lugares", 2000.00));
            Program.produtos.Add(new Produto(1004, "Mesa retangular", 1500.00));
            Program.produtos.Add(new Produto(1005, "Mesa retangular", 2000.00));
            produtos.Sort();

            try {
                OpcaoMenu(Tela.ExibirMenu());
            }
            catch (Exception ex) {
                Console.WriteLine("Erro inesperado: " + ex);
            }
        }

        public static void OpcaoMenu(int opcao) {
            do {
                switch (opcao) {
                    case 1:
                        Tela.ListarProdutos();
                        break;
                    case 2:
                        try {
                            Tela.CadastrarProduto();
                        }
                        catch (ModelException ex) {
                            Console.WriteLine("Erro de negócio: " + ex);
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Erro inesperado: " + ex);
                        }
                        break;
                    case 3:
                        try {
                            Tela.CadastrarPedido();
                        }
                        catch (ModelException ex) {
                            Console.WriteLine("Erro de negócio: " + ex);
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Erro inesperado: " + ex);
                        }
                        break;
                    case 4:
                        try {
                            Tela.ExibirPedido();
                        }
                        catch (ModelException ex) {
                            Console.WriteLine("Erro de negócio: " + ex);
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Erro inesperado: " + ex);
                        }
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }

                try {
                    OpcaoMenu(Tela.ExibirMenu());
                }
                catch (Exception ex) {
                    Console.WriteLine("Erro inesperado: " + ex);
                }
            } while (opcao != 5);
        }
    }
}
