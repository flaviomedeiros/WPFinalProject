using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using WP_Final_Project.Resources.db.model;
using System.Diagnostics;

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

            Produto p1 = new Produto("Farinha", 10.5f, "1kg. Da marca da vovo");
            Produto p2 = new Produto("Chocolate em po", 5.99f, "1kg. Doce como a vida");
            Produto p3 = new Produto("Ovo", 4.99f, "12unit. De granja");
            Produto p4 = new Produto("Manteiga", 4.99f, "500g. Light");
            Produto p5 = new Produto("Agua", 2.99f, "1L. Indaia");
            Produto p6 = new Produto("Leite", 6.99f, "1L. Betania");
            Produto p7 = new Produto("Coco", 223.75f, "Colhido por freiras cegas das montanhas");

            add(p1);
            add(p2);
            add(p3);
            add(p4);
            add(p5);
            add(p6);

            Ingrediente i1 = new Ingrediente(p1, 1f);
            Ingrediente i2 = new Ingrediente(p2, 2f);
            Ingrediente i3 = new Ingrediente(p3, 1f);
            Ingrediente i4 = new Ingrediente(p4, 4f);
            Ingrediente i5 = new Ingrediente(p1, 8f);
            Ingrediente i6 = new Ingrediente(p1, 3f);
            Ingrediente i7 = new Ingrediente(p5, 2f);
            Ingrediente i8 = new Ingrediente(p6, 3f);
            Ingrediente i9 = new Ingrediente(p7, 2f);

            add(i1);
            add(i2);
            add(i3);
            add(i4);
            add(i5);
            add(i6);
            add(i7);
            add(i8);
            add(i9);

            Receita r1 = new Receita();
            r1.Nome = "Doce de chocolate";
            r1.Ingredientes.Add(i2);
            r1.Ingredientes.Add(i6);
            r1.Preparo = "Junte tudo, mexa um pouco e pronto!\nColeque no forno ate queimar.";

            Receita r2 = new Receita();
            r2.Nome = "Bolo";
            r2.Ingredientes.Add(i5);
            r2.Ingredientes.Add(i2);
            r2.Ingredientes.Add(i3);
            r2.Ingredientes.Add(i4);
            r2.Preparo = "Junte tudo, mexa um pouco e pronto!\nColeque no forno ate queimar.\nVai ser um super bolo";

            Receita r3 = new Receita();
            r3.Nome = "Picole";
            r3.Ingredientes.Add(i2);
            r3.Ingredientes.Add(i7);
            r3.Ingredientes.Add(i8);
            r3.Preparo = "Junte tudo, mexa um pouco e pronto!\nColeque no forno ate queimar.\nO resultado eh uma palheta mexicana";

            Receita r4 = new Receita();
            r4.Nome = "Cocada suprema";
            r4.Ingredientes.Add(i7);
            r4.Ingredientes.Add(i9);
            r4.Preparo = "Junte tudo, mexa um pouco e pronto!\nColeque no forno ate queimar.\nO mlehor do mundo";

            add(r1);
            add(r2);
            add(r3);
            add(r4);

            Supermercado s1 = new Supermercado();
            s1.Nome = "Cometa";
            s1.Latitude = 10;
            s1.Longitude = 25;
            s1.Produtos.Add(p1);
            s1.Produtos.Add(p2);
            s1.Produtos.Add(p3);
            s1.Produtos.Add(p4);
            s1.Produtos.Add(p5);

            Supermercado s2 = new Supermercado();
            s2.Nome = "Pao de acucar";
            s2.Latitude = 50;
            s2.Longitude = 75;
            s2.Produtos.Add(p6);
            s2.Produtos.Add(p3);
            s2.Produtos.Add(p4);
            s2.Produtos.Add(p5);
            s2.Produtos.Add(p7);

            add(s1);
            add(s2);

            //teste();
        }

        public void teste()
        {
            Debug.WriteLine("teste/appData");
           List<Receita> receitas = getAllReceitas();
           List<Ingrediente> ingredientes = receitas.ElementAt(0).Ingredientes.ToList();

           Debug.WriteLine("receitas:" + receitas.Count);
           Debug.WriteLine("ingredientes:" + ingredientes.Count);
           Debug.WriteLine("ingrediente.nome:" + ingredientes.ElementAt(0).Produto.Nome);
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
