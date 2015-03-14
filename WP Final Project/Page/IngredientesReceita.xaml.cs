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
using WP_Final_Project.View;
using WP_Final_Project.Resources.db;

namespace WP_Final_Project.Page
{
    public partial class IngredientesReceita: PhoneApplicationPage
    {
        public static IngredientesReceita instance;

        public IngredientesReceita()
        {
            InitializeComponent();
            instance = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            foreach (Ingrediente ingrediente in App.receitaSelecionada.Ingredientes) 
            {
                ItemIngredienteReceita itemIngredienteReceita = new ItemIngredienteReceita(ingrediente);
                ListaDeIngredientes.Children.Add(itemIngredienteReceita);
            }
        }

        public void verIngredienteSelecionado()
        {
            NavigationService.Navigate(new Uri("/Page/DetalheIngrediente.xaml", UriKind.Relative));
        }

    }
}