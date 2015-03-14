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
    public partial class ResultadoBusca : PhoneApplicationPage
    {
        public static ResultadoBusca instance;
        private List<ReceitaEncontrada> receitasEncontradas;

        public ResultadoBusca()
        {
            InitializeComponent();
            instance = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            receitasEncontradas = new List<ReceitaEncontrada>();

            foreach (Receita receita in App.db.getAllReceitas())
            {
                int compatibilidade = getReceitaCompatibilidade(receita);
                if (compatibilidade > 0)
                {
                    receitasEncontradas.Add(new ReceitaEncontrada(receita, compatibilidade));
                }
            }

            ordenarEExibirResultado();
        }
        
        private int getReceitaCompatibilidade(Receita receita)
        {
            int compatibilidade = 0;
            int compatibilidadePesoPorIngrediente = 100 / App.listaDeIngredientes.Count;
            //Calc compatibilidade por ingrediente
            foreach (Ingrediente ingrediente in App.listaDeIngredientes)
            {
                Ingrediente ingredienteNaReceita = getIngredienteNaReceita(receita, ingrediente);
                if (ingredienteNaReceita != null)
                {
                    compatibilidade += compatibilidadePesoPorIngrediente;
                    //Calc compatibilidade da quantidade
                    float difQt = ingrediente.Quantidade - ingredienteNaReceita.Quantidade;
                    int difQtAbsRounded = (int) Math.Round(Math.Abs(difQt));
                    compatibilidade -= difQtAbsRounded;
                }
            }
            return compatibilidade;
        }

        private Ingrediente getIngredienteNaReceita(Receita receita, Ingrediente ingrediente)
        {
            foreach(Ingrediente ingredienteReceita in receita.Ingredientes){
                if (ingredienteReceita.Produto.Nome.Equals(ingrediente.Produto.Nome))
                {
                    return ingredienteReceita;
                }
            }
            return null;
        }

        private void ordenarEExibirResultado()
        {
            List<ReceitaEncontrada> receitasOrdenada = receitasEncontradas.OrderBy(o => o.compatibilidade).ToList();
            receitasOrdenada.Reverse();
            foreach (ReceitaEncontrada receitaEncontrada in receitasOrdenada)
            {
                Receita receita = receitaEncontrada.receita;
                int compatibilidade = receitaEncontrada.compatibilidade;
                ListaDeReceitas.Children.Add(new ItemReceitaBusca(receita, compatibilidade));
            }
        }

        public void verReceitaSelecionada()
        {
            NavigationService.Navigate(new Uri("/Page/VerReceita.xaml", UriKind.Relative));
        }

        private class ReceitaEncontrada
        {
            public Receita receita;
            public int compatibilidade;

            public ReceitaEncontrada(Receita receita, int compatibilidade)
            {
                this.receita = receita;
                this.compatibilidade = compatibilidade;
            }
        }
    }
}