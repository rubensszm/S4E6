using System;
using System.Globalization;

namespace S4E6.dominio {
    public class Produto : IComparable {
        public int codigo { get; private set; }
        public string descricao { get; private set; }
        public double preco { get; private set; }

        public Produto(int codigo, string descricao, double preco) {
            this.codigo = codigo;
            this.descricao = descricao;
            this.preco = preco;
        }

        public override string ToString() {
            return codigo.ToString() + ", " + descricao + ", " + preco.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj) {
            Produto outro = (Produto)obj;
            int resultado = string.Compare(descricao, outro.descricao, StringComparison.CurrentCulture);
            return resultado != 0 ? resultado : -preco.CompareTo(outro.preco);
        }
    }
}
