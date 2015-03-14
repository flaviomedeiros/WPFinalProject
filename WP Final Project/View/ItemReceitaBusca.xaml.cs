using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Navigation;
using WP_Final_Project.Page;

namespace WP_Final_Project.View
{
    public partial class ItemReceitaBusca : UserControl
    {
        
        public ItemReceitaBusca(Resources.db.model.Receita receita, int compatibilidade)
        {
            InitializeComponent();
            App.receitaSelecionada = receita;
            NomeReceita.Text = receita.Nome;
            Compatibilidade.Text = compatibilidade + "%";
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ResultadoBusca.instance.verReceitaSelecionada();
        }

    }
}
