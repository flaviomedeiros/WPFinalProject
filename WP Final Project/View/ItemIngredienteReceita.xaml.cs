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
            NomeIngrediente.Text = ingrediente.Quantidade + " x " + ingrediente.Produto.Nome;
        }
        
        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.ingredienteSelecionado = ingrediente;
            IngredientesReceita.instance.verIngredienteSelecionado();
        }

        private void CheckPossuo_Tap(object sender, RoutedEventArgs e)
        {
            if (CheckPossuo.IsChecked.Value)
            {
                SupermercadoMaisProximo.Visibility = System.Windows.Visibility.Visible;
                SupermercadoMaisProximo.Text = getNomeSupermercadoMaisProximo();
            }
            else
            {
                SupermercadoMaisProximo.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private string getNomeSupermercadoMaisProximo()
        {
            String supermercadoNome = "";
            List<Supermercado> supermercadosComProduto = getSuperMercadosComProduto();
            int myLat = (int)(new Random().NextDouble() * 180);
            int myLon = (int)(new Random().NextDouble() * 360);
            //calcula supermercado mais proximo
            int distMaisProximo = int.MaxValue;
            foreach (Supermercado supermercado in supermercadosComProduto)
            {
                int dist = (int) Math.Sqrt(Math.Pow(supermercado.Latitude - myLat, 2) + Math.Pow(supermercado.Longitude - myLon, 2));
                if (dist < distMaisProximo)
                {
                    distMaisProximo = dist;
                    supermercadoNome = supermercado.Nome;
                }
            }
            return supermercadoNome;
        }

        private List<Supermercado> getSuperMercadosComProduto()
        {
            List<Supermercado> supermercadosComProduto = new List<Supermercado>();
            List<Supermercado> supermercados = App.db.getAllSupermercados().ToList<Supermercado>();
            foreach (Supermercado supermercado in supermercados)
            {
                //checa se supermercado tem o produto do ingrediente
                foreach (Produto produto in supermercado.Produtos)
                {
                    if (produto.Nome.Equals(ingrediente.Produto.Nome))
                    {
                        supermercadosComProduto.Add(supermercado);
                        break;
                    }
                }
            }
            return supermercadosComProduto;
        }

    }
}
