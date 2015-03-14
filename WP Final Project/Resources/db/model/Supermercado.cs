using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace WP_Final_Project.Resources.db.model
{
    [Table(Name = "Supermercado")]
    public class Supermercado
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int IdSupermercado { get; set; }

        [Column()]
        public string Nome { get; set; }

        private EntitySet<Produto> _Produtos;

        [Association(Storage = "_Produtos",
            ThisKey = "IdSupermercado", OtherKey = "IdSupermercado")]
        public EntitySet<Produto> Produtos
        {
            set
            {
                _Produtos = value;
            }
            get
            {
                return _Produtos;
            }
        }

        [Column()]
        public int Latitude { get; set; }

        [Column()]
        public int Longitude { get; set; }
    }
}
