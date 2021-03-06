﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Navigation;
using WP_Final_Project.Page;
using WP_Final_Project.Resources.db.model;

namespace WP_Final_Project.View
{
    public partial class ItemReceitaBusca : UserControl
    {
        private Receita mReceita;

        public ItemReceitaBusca(Resources.db.model.Receita receita, float compatibilidade)
        {
            InitializeComponent();
            mReceita = receita;
            NomeReceita.Text = receita.Nome;
            Compatibilidade.Text = (int) compatibilidade + "%";
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.receitaSelecionada = mReceita;
            ResultadoBusca.instance.verReceitaSelecionada();
        }

    }
}
