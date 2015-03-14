using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WP_Final_Project.Resources.db.model
{
    [Table]
    public class Supermercado
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column()]
        public string Nome { get; set; }

        [Column()]
        public List<Produto> Produtos { get; set; }

        [Column()]
        public int Latitude { get; set; }

        [Column()]
        public int Longitude { get; set; }
    }
}
