using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP_Final_Project.Resources;
using WP_Final_Project.Resources.db;
using WP_Final_Project.Resources.db.model;
using System.Diagnostics;
using WP_Final_Project.View;
using System.Globalization;

namespace WP_Final_Project
{
    public partial class BuscarReceita : PhoneApplicationPage
    {
        public BuscarReceita()
        {
            InitializeComponent();
            ListadeIngredientes.Children.Add(new ItemIngredienteBusca());
        }

        private void AdicionarIngrediente_Click(object sender, RoutedEventArgs e)
        {
            if (verificaPreenchimentoDosIngredientes())
            {
                ListadeIngredientes.Children.Add(new ItemIngredienteBusca());
            }
            else
            {
                MessageBox.Show("Preencha todos os compos da lista de ingredientes");
            }
        }

        private void PesquisarReceitas_Click(object sender, RoutedEventArgs e)
        {
            if (verificaPreenchimentoDosIngredientes())
            {
                preencheListaDeIngredientes();
                NavigationService.Navigate(new Uri("/Page/ResultadoBusca.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Preencha todos os compos da lista de ingredientes");
            }
        }

        private bool verificaPreenchimentoDosIngredientes()
        {
            foreach (var children in ListadeIngredientes.Children)
            {
                ItemIngredienteBusca ingrediente = children as ItemIngredienteBusca;

                if (ingrediente.NomeIngrediente.Text.Equals("") || ingrediente.QuantidadeIngrediente.Text.Equals(""))
                {
                    return false;
                }
            }

            return true;
        }

        private bool preencheListaDeIngredientes()
        {
            foreach (var children in ListadeIngredientes.Children)
            {
                ItemIngredienteBusca ingredienteView = children as ItemIngredienteBusca;

                Produto produtoModel = new Produto();
                produtoModel.Nome = ingredienteView.NomeIngrediente.Text;

                Ingrediente ingredienteModel = new Ingrediente();
                ingredienteModel.Produto = produtoModel;
                ingredienteModel.Quantidade = float.Parse(ingredienteView.QuantidadeIngrediente.Text, CultureInfo.InvariantCulture.NumberFormat);

                App.listaDeIngredientes.Add(ingredienteModel);
            }

            return true;
        }
    }
}