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
                float compatibilidade = getReceitaCompatibilidade(receita);
                if (compatibilidade > 0)
                {
                    receitasEncontradas.Add(new ReceitaEncontrada(receita, compatibilidade));
                }
            }

            ordenarEExibirResultado();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ListaDeReceitas.Children.Clear();
        }
        
        private float getReceitaCompatibilidade(Receita receita)
        {
            float compatibilidade = 0;
            int compatibilidadePesoPorIngrediente = 100 / App.listaDeIngredientes.Count;
            int qtdDeIngredientesNaReceita = getQtdDeIngredientesNaReceita(receita);
            //Calc compatibilidade por ingrediente
            foreach (Ingrediente ingrediente in App.listaDeIngredientes)
            {
                Ingrediente ingredienteNaReceita = getIngredienteNaReceita(receita, ingrediente);
                if (ingredienteNaReceita != null)
                {
                    compatibilidade += compatibilidadePesoPorIngrediente;
                    //Calc compatibilidade da quantidade
                    float difQt = ingredienteNaReceita.Quantidade - ingrediente.Quantidade;
                    int difQtAbsRounded = (int) Math.Round(Math.Abs(difQt));
                    compatibilidade -= difQtAbsRounded / ingredienteNaReceita.Quantidade * 100;
                }
            }
            return compatibilidade;
        }

        private int getQtdDeIngredientesNaReceita(Receita receita)
        {
            int qtd = 0;
            foreach (Ingrediente ingrediente in receita.Ingredientes)
            {
                qtd += (int) ingrediente.Quantidade;
            }
            return qtd;
        }

        private Ingrediente getIngredienteNaReceita(Receita receita, Ingrediente ingrediente)
        {
            foreach(Ingrediente ingredienteReceita in receita.Ingredientes){
                if (ingredienteReceita.Produto.Nome.ToLower().Contains(ingrediente.Produto.Nome.ToLower()))
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
                float compatibilidade = receitaEncontrada.compatibilidade;
                ListaDeReceitas.Children.Add(new ItemReceitaBusca(receita, compatibilidade));
            }
        }

        public void verReceitaSelecionada()
        {
            NavigationService.Navigate(new Uri("/Page/IngredientesReceita.xaml", UriKind.Relative));
        }

        private class ReceitaEncontrada
        {
            public Receita receita;
            public float compatibilidade;

            public ReceitaEncontrada(Receita receita, float compatibilidade)
            {
                this.receita = receita;
                this.compatibilidade = compatibilidade;
            }
        }
    }
}