using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WP_Final_Project.Resources.db.model
{
    [Table]
    public class Ingrediente
    {
        [Column()]
        public string Descricao { get; set; }

        [Column()]
        public float Quantidade { get; set; }

        [Column()]
        public Produto Produto { get; set; }
    }
}
