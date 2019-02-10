using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace DesignMaterial
{
    /// <summary>
    /// Interação lógica para Registro.xam
    /// </summary>
    public partial class Registro : Page
    {
        

        public Registro()
        {
            InitializeComponent();
        }

        private void AbrirMostrarTodos(object sender, RoutedEventArgs e)
        {
            XElement Cadastro = XElement.Load(@"Cadastro.xml");

            Dados MeusDados = new Dados();
            boxMostra.Text = String.Empty;

            var Consulta = from Registros in Cadastro.Elements("Registro")
                           select new
                           {
                               Codigo = (string)Registros.Element("Codigo"),
                               Data = (string)Registros.Element("Data"),
                               Natureza = (string)Registros.Element("Natureza"),
                               Descricao = (string)Registros.Element("Descricao"),
                               Valor = (string)Registros.Element("Valor")
                           };
            //adicionar balanço no fim da consulta

            foreach (var x in Consulta)
            {

                boxMostra.Text += ($"Código => {x.Codigo} " + NL(1));
                boxMostra.Text += ($"Data => {x.Data}" + NL(1));
                boxMostra.Text += ($"Natureza => {x.Natureza}" + NL(1));
                boxMostra.Text += ($"Descrição => {x.Descricao}" + NL(1));
                boxMostra.Text += ($"Valor => {x.Valor}" + NL(1));
                boxMostra.Text += ("--------------------------------" + NL(2));
            }
        }

        private string NL(int TotalLinhas)        // Para NewLine no TextBox
        {
            string Linha = "";

            for (int i = 1; i <= TotalLinhas; i++)
                Linha += Environment.NewLine;

            return Linha;
        }

        private void Procurar(object sender, RoutedEventArgs e)
        {
            Operacoes NovaOperacao = new Operacoes();

            boxMostra.Text = String.Empty;
            if (NovaOperacao.ValidarData(boxData1.Text) == true && NovaOperacao.ValidarData(boxData2.Text) == true)
            {
                XElement Cadastro = XElement.Load(@"Cadastro.xml");

                Dados MeusDados = new Dados();

                var Busca = from Registros in Cadastro.Elements("Registro")
                            where DateTime.Parse((string)Registros.Element("Data")).Date >= DateTime.Parse(boxData1.Text).Date && DateTime.Parse((string)Registros.Element("Data")).Date <= DateTime.Parse(boxData2.Text).Date
                            select new
                            {
                                Codigo = (string)Registros.Element("Codigo"),
                                Data = (string)Registros.Element("Data"),
                                Natureza = (string)Registros.Element("Natureza"),
                                Descricao = (string)Registros.Element("Descricao"),
                                Valor = (string)Registros.Element("Valor")
                            };//Como adicionar um atributo derivado com o valor total de cada 4periodo?

                foreach (var x in Busca)
                {
                    boxMostra.Text += ($"Código => {x.Codigo} " + NL(1));
                    boxMostra.Text += ($"Data => {x.Data}" + NL(1));
                    boxMostra.Text += ($"Natureza => {x.Natureza}" + NL(1));
                    boxMostra.Text += ($"Descrição => {x.Descricao}" + NL(1));
                    boxMostra.Text += ($"Valor => {x.Valor}" + NL(1));
                    boxMostra.Text += ("--------------------------------" + NL(2));
                }
            }
            else
            {
                MessageBox.Show("Data incorreta! Por favor insira no formato DD/MM/AAAA", "Data incorreta", MessageBoxButton.OK);
            }
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            //Adicionar meio de testar o valor para que não seja um registro vazio

            XElement Cadastro = XElement.Load(@"Cadastro.xml");
            var Remove = from Registros in Cadastro.Elements("Registro")
                         where ((string)Registros.Element("Codigo")).Equals(boxCod.Text)
                         select Registros;

            foreach (var x in Remove)
            {
                x.Element("Codigo").Parent.Remove();
            }
            try
            {
                Cadastro.Save(@"Cadastro.xml");
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Windows.MessageBox.Show("Por favor, execute o programa como administrador para utilizar essa função!", ex.Message);
                System.Windows.Application.Current.Shutdown();
                
            }


            MessageBox.Show("Registro excluído com sucesso!", "Aviso", MessageBoxButton.OK);
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            boxData1.Text = String.Empty;
            boxData2.Text = String.Empty;
        }

        private void TxtSaldo_Initialized(object sender, EventArgs e)
        {
            txtSaldo.Text = Convert.ToString(Math.Round(double.Parse(txtEntrada.Text) - double.Parse(txtSaida.Text),2));
        }

        private void TxtSaida_Initialized(object sender, EventArgs e)
        {
            XElement Cadastro = XElement.Load(@"Cadastro.xml");
            double ValSaida = 0;

            var PegaSaida = from Registros in Cadastro.Elements("Registro")
                            where ((string)Registros.Element("Natureza")).Equals("Débito")
                            select new
                            {
                                Codigo = (string)Registros.Element("Codigo"),
                                Data = (string)Registros.Element("Data"),
                                Natureza = (string)Registros.Element("Natureza"),
                                Descricao = (string)Registros.Element("Descricao"),
                                Valor = (double)Registros.Element("Valor")
                            };

            foreach (var x in PegaSaida)
            {
                ValSaida += x.Valor;
            }

            txtSaida.Text = ValSaida.ToString();
        }

        private void TxtEntrada_Initialized(object sender, EventArgs e)
        {
            XElement Cadastro = XElement.Load(@"Cadastro.xml");
            double ValEntrada = 0;

            var PegaEntrada = from Registros in Cadastro.Elements("Registro")
                              where ((string)Registros.Element("Natureza")).Equals("Crédito")
                              select new
                              {
                                  Codigo = (string)Registros.Element("Codigo"),
                                  Data = (string)Registros.Element("Data"),
                                  Natureza = (string)Registros.Element("Natureza"),
                                  Descricao = (string)Registros.Element("Descricao"),
                                  Valor = (double)Registros.Element("Valor")
                              };

            foreach (var x in PegaEntrada)
            {
                ValEntrada += x.Valor;
            }

            txtEntrada.Text = ValEntrada.ToString();
        }
    }
}
