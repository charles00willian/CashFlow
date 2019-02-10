using System;
using System.Linq;
using System.Windows.Controls;
using System.Xml.Linq;

namespace DesignMaterial
{
    /// <summary>
    /// Interação lógica para MostraTodos.xam
    /// </summary>
    public partial class MostraTodos : Page
    {
        public MostraTodos()
        {
            InitializeComponent();

            XElement Cadastro = XElement.Load(@"Cadastro.xml");

            Dados MeusDados = new Dados();

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
                boxMostra.Text = ($"Código => {x.Codigo}") + NL(1);
                boxMostra.Text = ($"Data => {x.Data}") + NL(1);
                boxMostra.Text = ($"Natureza => {x.Natureza}" + NL(1));
                boxMostra.Text = ($"Descrição => {x.Descricao}" + NL(1));
                boxMostra.Text = ($"Valor => {x.Valor}" + NL(1));
                boxMostra.Text = ("---------------------------------------") + NL(2);
            }
        }


        /*private void Exibir(object sender, EventArgs e)
        {
            XElement Cadastro = XElement.Load(@"C:\Users\nchar\Desktop\DesignMaterial\Cadastro.xml");

            Dados MeusDados = new Dados();

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
                boxMostra.Text = ($"Código => {x.Codigo}") + NL(1);
                boxMostra.Text = ($"Data => {x.Data}") + NL(1);
                boxMostra.Text = ($"Natureza => {x.Natureza}" + NL(1));
                boxMostra.Text = ($"Descrição => {x.Descricao}" + NL(1));
                boxMostra.Text = ($"Valor => {x.Valor}" + NL(1));
                boxMostra.Text = ("---------------------------------------") + NL(2);
            }

        }*/

        private string NL(int TotalLinhas)        // Para NewLine no TextBox
        {
            string Linha = "";

            for (int i = 1; i <= TotalLinhas; i++)
                Linha += Environment.NewLine;

            return Linha;
        }

        private void Exibir(object sender, EventArgs e)
        {
        
        }
    }
}
