using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WP_Final_Project.Resources.db.model
{
    [Table]
    public class Produto
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column()]
        public string Nome { get; set; }

        [Column()]
        public float Preco { get; set; }

        public Produto()
        {
            
        }

        public Produto(string nome, float preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
