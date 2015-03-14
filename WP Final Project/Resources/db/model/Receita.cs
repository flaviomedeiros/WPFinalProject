using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace WP_Final_Project.Resources.db.model
{
    [Table(Name = "Receita")]
    public class Receita
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int IdReceita { get; set; }

        [Column()]
        public string Nome { get; set; }

        [Column()]
        public string Preparo { get; set; }

        private EntitySet<Ingrediente> _Ingredientes;

        [Association(Storage = "_Ingredientes", ThisKey = "IdReceita", OtherKey = "IdReceita")]
        public EntitySet<Ingrediente> Ingredientes
        {
            set
            {
                _Ingredientes = value;
            }
            get
            {
                return _Ingredientes;
            }
        }

        public Receita()
        {
            Ingredientes = new EntitySet<Ingrediente>();
        }
    }
}
