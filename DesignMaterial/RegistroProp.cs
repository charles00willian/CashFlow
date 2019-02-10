using System;
using System.Xml.Linq;
using System.Globalization;

namespace DesignMaterial
{
    class Movimentacao
    {
        XElement Cadastro = XElement.Load(@"Cadastro.xml");


        public string Codigo { get;}
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Natureza { get; set; }
        public string Cliente { get; set; }

        public Movimentacao()
        {
            Guid x = Guid.NewGuid();
            Codigo = x.ToString().Substring(14, 7);
        }
    }

    class Dados
    {
        XElement Cadastro = XElement.Load(@"Cadastro.xml");

        public void AdicionarNovo(Movimentacao x)
        {
            XElement NovoCad = new XElement("Registro",
                                new XElement("Codigo", x.Codigo),
                                new XElement("Data", x.Data),
                                new XElement("Natureza", x.Natureza),
                                new XElement("Descricao", x.Descricao),
                                new XElement("Valor", x.Valor)
                                );
            Cadastro.Add(NovoCad);

            try
            {
                Cadastro.Save(@"Cadastro.xml");
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Windows.MessageBox.Show("Por favor, execute o programa como administrador para utilizar essa função!", ex.Message);
                System.Windows.Application.Current.Shutdown();
                
            }
            
            
        }
    }

    class Operacoes
    {
        public bool ValidarData(string Date)
        {
            try
            {
                DateTime.ParseExact(Date, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void ValidarString(string x,string y, string z)
        {
            if (x == "" || y == "" || z == "")
            {
                throw new FormatException("O valor de algum campo está vazio");
            }
        }
    }
}
