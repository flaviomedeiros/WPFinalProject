using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;
using System.Windows.Input;
using WP_Final_Project.Resources.db.model;
using WP_Final_Project.Page;

namespace WP_Final_Project.View
{
    public partial class ItemIngredienteReceita : UserControl
    {
        private Ingrediente ingrediente;

        public ItemIngredienteReceita(Ingrediente ingrediente)
        {
            InitializeComponent();
            this.ingrediente = ingrediente;

            NomeIngrediente.Text = ingrediente.Produto.Nome;
        }
        
        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.ingredienteSelecionado = ingrediente;
            IngredientesReceita.instance.verIngredienteSelecionado();
        }

    }
}
