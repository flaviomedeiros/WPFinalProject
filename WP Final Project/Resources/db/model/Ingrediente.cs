using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace WP_Final_Project.Resources.db.model
{
    [Table(Name = "Ingrediente")]
    public class Ingrediente
    {
        [Column()]
        public int IdReceita { get; set; }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int IdIngrediente { get; set; }

        [Column()]
        public float Quantidade { get; set; }

        private EntityRef<Produto> _Produto;

        [Association(Storage = "_Produto",
            ThisKey = "IdIngrediente", OtherKey = "IdIngrediente")]
        public Produto Produto
        {
            set
            {
                _Produto.Entity = value;
            }
            get
            {
                return _Produto.Entity;
            }
        }

        public Ingrediente()
        {

        }

        public Ingrediente(Produto produto, float quantidade)
        {
            Quantidade = quantidade;
            Produto = produto;
        }
    }
}
