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
        public static string CN = "isostore:/resto3.sdf";

        public Table<Produto> mProduto;
        public Table<Supermercado> mSupermercado;
        public Table<Receita> mReceita;
        public Table<Ingrediente> mIngrediente;

        public AppDataContext(string cn) : base(cn)
        {
            /*if (!DatabaseExists())
            {
                CreateDatabase();
            }*/
        }

        public void popularDb()
        {
            if (getAllProdutos().Count > 0)
                removeAll();

            Produto p1 = new Produto("Farinha", 10.5f, "Da marca da vovo");
            Produto p2 = new Produto("Chocolate em po", 5.99f, "Doce como a vida");

            add(p1);
            add(p2);

            Ingrediente i1 = new Ingrediente(p1, 1f);
            Ingrediente i2 = new Ingrediente(p2, 2f);

            add(i1);
            add(i2);
            
            Receita r1 = new Receita();
            r1.Ingredientes.Add(i1);

            Receita r2 = new Receita();
            r2.Ingredientes.Add(i1);
            r2.Ingredientes.Add(i2);

            add(r1);
            add(r2);
        }

        private void removeAll()
        {
            var deleteProduto = from p in mProduto select p;
            var deleteReceita = from r in mReceita select r;
            var deleteSupermercado = from s in mSupermercado select s;
            var deleteIngrediente = from i in mIngrediente select i;

            mProduto.DeleteAllOnSubmit(deleteProduto);
            mReceita.DeleteAllOnSubmit(deleteReceita);
            mSupermercado.DeleteAllOnSubmit(deleteSupermercado);
            mIngrediente.DeleteAllOnSubmit(deleteIngrediente);
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
