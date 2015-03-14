using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WP_Final_Project.Resources.db.model
{
    [Table(Name = "Produto")]
    public class Produto
    {
        [Column()]
        public int IdIngrediente { get; set; }

        [Column()]
        public int IdSupermercado { get; set; }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int IdProduto { get; set; }

        [Column()]
        public string Nome { get; set; }

        [Column()]
        public float Preco { get; set; }

        [Column()]
        public string Descricao { get; set; }

        public Produto()
        {
            
        }

        public Produto(string nome, float preco, string descricao)
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
        }
    }
}
