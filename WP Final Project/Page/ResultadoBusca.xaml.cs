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
            List<Receita> receitas = getReceitasFromDB();
            foreach (Receita receita in receitas)
            {
                int compatibilidade = getReceitaCompatibilidade(receita);
                if (compatibilidade > 0)
                {
                    receitasEncontradas.Add(new ReceitaEncontrada(receita, compatibilidade));
                }
            }
            ordenarEExibirResultado();
        }

        private static List<Receita> getReceitasFromDB()
        {
            List<Receita> receitas;
            using (var db = new AppDataContext(AppDataContext.CN))
            {
                receitas = db.getAllReceitas();
                if (receitas == null)
                {
                    receitas = new List<Receita>();
                }
            }
            return receitas;
        }

        private int getReceitaCompatibilidade(Receita receita)
        {
            int compatibilidade = 0;
            int compatibilidadePesoPorIngrediente = 100 / App.listaDeIngredientes.Count;
            //Calc compatibilidade por ingrediente
            foreach (Ingrediente ingrediente in App.listaDeIngredientes)
            {
                if (receita.Ingredientes.Contains(ingrediente))
                {
                    compatibilidade += compatibilidadePesoPorIngrediente;
                }
            }
            //Calc compatibilidade
            /*foreach (Ingrediente ingrediente in App.listaDeIngredientes)
            {

            }*/
            return compatibilidade;
        }

        private void ordenarEExibirResultado()
        {
            List<ReceitaEncontrada> receitasOrdenada = receitasEncontradas.OrderBy(o => o.compatibilidade).ToList();
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