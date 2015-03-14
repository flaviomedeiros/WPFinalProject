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

namespace WP_Final_Project
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ListadeIngredientes.Children.Add(new ItemIngredienteBusca());
        }

        private void AdicionarIngrediente_Click(object sender, RoutedEventArgs e)
        {
            ListadeIngredientes.Children.Add(new ItemIngredienteBusca());
        }

        private void PesquisarReceitas_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/ListaDeReceitas.xaml", UriKind.Relative));
        }

        public void testeDb()
        {
            Debug.WriteLine("testeDb!");
            using (var db = new AppDataContext(AppDataContext.CN))
            {
                db.popularDb();

                List<Produto> produtos = db.getAllProdutos();

                Debug.WriteLine("produtos:" + produtos.Count);
            }
        }
    }
}