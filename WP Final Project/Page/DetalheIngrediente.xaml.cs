using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP_Final_Project.Resources.db.model;

namespace WP_Final_Project.Page
{
    public partial class DetalheIngrediente : PhoneApplicationPage
    {
        public DetalheIngrediente()
        {
            InitializeComponent();

            NomeIngrediente.Text = App.ingredienteSelecionado.Produto.Nome;
            DescritivoIngrediente.Text = App.ingredienteSelecionado.Produto.Descricao;

            List<Supermercado> supermercados = App.db.getAllSupermercados();

            foreach (var supermercado in supermercados)
            {
                if (supermercado.Produtos.ToList().Contains(App.ingredienteSelecionado.Produto))
                {
                    ListaDeSupermercados.Text += ListaDeSupermercados.Text + "\n" + supermercado.Nome;
                }
            }
        }


    }
}