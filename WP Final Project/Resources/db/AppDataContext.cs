using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using WP_Final_Project.Resources.db.model;

namespace WP_Final_Project.Resources.db
{
    public class AppDataContext : DataContext
    {
        public static string CN = "isostore:/resto.sdf";

        public Table<Produto> mProduto;
        public Table<Supermercado> mSupermercado;
        public Table<Receita> mReceita;
        public Table<Ingrediente> mIngrediente;

        public AppDataContext(string cn) : base(cn)
        {

        }

        public void popularDb()
        {
            //removeAll();

            if(getAllProdutos().Count == 0)
            {
                add(new Produto("Farinha", 10.5f));
                add(new Produto("Arroz", 5.99f));

                
            }
        }

        private void removeAll()
        {
            mProduto.DeleteAllOnSubmit(mProduto);
            mReceita.DeleteAllOnSubmit(mReceita);
            mSupermercado.DeleteAllOnSubmit(mSupermercado);
            mIngrediente.DeleteAllOnSubmit(mIngrediente);
        }

        //getAll

        public List<Produto> getAllProdutos()
        {
            List<Produto> lista = (from p in mProduto
                                 select p).ToList();

            return lista;
        }

        public List<Supermercado> getAllSupermercados()
        {
            List<Supermercado> lista = (from s in mSupermercado
                                   select s).ToList();

            return lista;
        }

        public List<Receita> getAllReceitas()
        {
            List<Receita> lista = (from r in mReceita
                                        select r).ToList();

            return lista;
        }

        public List<Ingrediente> getAllIngredientes()
        {
            List<Ingrediente> lista = (from i in mIngrediente
                                   select i).ToList();

            return lista;
        }

        //add

        public void add(Produto produto)
        {
            mProduto.InsertOnSubmit(produto);
            commit();
        }

        public void add(Supermercado supermercado)
        {
            mSupermercado.InsertOnSubmit(supermercado);
            commit();
        }

        public void add(Receita receita)
        {
            mReceita.InsertOnSubmit(receita);
            commit();
        }

        public void add(Ingrediente ingrediente)
        {
            mIngrediente.InsertOnSubmit(ingrediente);
            commit();
        }

        //remove

        public void remove(Produto produto)
        {
            mProduto.Attach(produto);
            mProduto.DeleteOnSubmit(produto);
            commit();
        }

        public void remove(Supermercado supermercado)
        {
            mSupermercado.Attach(supermercado);
            mSupermercado.DeleteOnSubmit(supermercado);
            commit();
        }

        public void remove(Receita receita)
        {
            mReceita.Attach(receita);
            mReceita.DeleteOnSubmit(receita);
            commit();
        }

        public void remove(Ingrediente ingrediente)
        {
            mIngrediente.Attach(ingrediente);
            mIngrediente.DeleteOnSubmit(ingrediente);
            commit();
        }

        //

        public void commit()
        {
            SubmitChanges();
            
        }
    }
}
