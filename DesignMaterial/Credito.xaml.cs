using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace DesignMaterial
{
    /// <summary>
    /// Interação lógica para Credito.xam
    /// </summary>
    public partial class Credito : Page
    {
        public Credito()
        {
            InitializeComponent();
        }

        /*private void SalvarCredito(object sender, RoutedEventArgs e)
        {
            //tratar exceções
            //Deixar botao de salvar inativo até que todos os campos sejam preenchidos

            Movimentacao NovaMovimentacao = new Movimentacao();
            Dados MeusDados = new Dados();
            Operacoes NovaOperacao = new Operacoes();

            if (NovaOperacao.ValidarData(boxDataC.Text) == true)
            {
                NovaMovimentacao.Descricao = boxDescricaoC.Text;
                NovaMovimentacao.Cliente = boxFonteC.Text;
                NovaMovimentacao.Data = boxDataC.Text;
                NovaMovimentacao.Valor = double.Parse(boxValorC.Text);

                NovaMovimentacao.Natureza = "Crédito";
                MeusDados.AdicionarNovo(NovaMovimentacao);

                MessageBox.Show($"Registro Salvo com sucesso!\nCódigo {NovaMovimentacao.Codigo}", "Sucesso!", MessageBoxButton.OK);

                boxDescricaoC.Text = String.Empty;
                boxFonteC.Text = String.Empty;
                boxDataC.Text = String.Empty;
                boxValorC.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Data em formato inválido! Verifique o formato DD/MM/AAAA", "Data inválida", MessageBoxButton.OK);
                boxDataC.Text = String.Empty;
            }*/
        private void SalvarCredito(object sender, RoutedEventArgs e)
            {
                //tratar exceções
                //Deixar botao de salvar inativo até que todos os campos sejam preenchidos

                Movimentacao NovaMovimentacao = new Movimentacao();
                Dados MeusDados = new Dados();
                Operacoes NovaOperacao = new Operacoes();
                bool valido = true;

                try
                {
                    valido = true;
                    NovaMovimentacao.Valor = double.Parse(boxValorC.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Informe um número válido!", "Número fora de padrão", MessageBoxButton.OK);
                    valido = false;
                }

                if (NovaOperacao.ValidarData(boxDataC.Text) == true && valido == true)
                {
                    NovaMovimentacao.Descricao = boxDescricaoC.Text;
                    NovaMovimentacao.Cliente = boxFonteC.Text;
                    NovaMovimentacao.Data = boxDataC.Text;


                    NovaMovimentacao.Natureza = "Crédito";
                    MeusDados.AdicionarNovo(NovaMovimentacao);

                    MessageBox.Show($"Registro Salvo com sucesso!\nCódigo {NovaMovimentacao.Codigo}", "Sucesso!", MessageBoxButton.OK);

                    boxDescricaoC.Text = String.Empty;
                    boxFonteC.Text = String.Empty;
                    boxDataC.Text = String.Empty;
                    boxValorC.Text = String.Empty;
                }
            }

        private void LimparCampos(object sender, RoutedEventArgs e)
        {
            boxDescricaoC.Text = String.Empty;
            boxFonteC.Text = String.Empty;
            boxDataC.Text = String.Empty;
            boxValorC.Text = String.Empty;
        }
    }
}
