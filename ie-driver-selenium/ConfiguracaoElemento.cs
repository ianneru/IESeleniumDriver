using OpenQA.Selenium;

namespace FnzIeSeleniumDriver
{
    public class ConfiguracaoElemento
    {
        public ConfiguracaoElemento()
        {
            Navegacao = new Navegacao();
        }

        public string NomeElemento { get; set; }
        
        public TipoElemento TipoElemento { get;set;}
        
        public IWebDriver Driver { get; set; }
        
        public BuscaPor ProcurarElementoPor { get; set; }

        public string Atributo { get; set; }

        public Navegacao Navegacao { get; set; }

        public string JanelaPrincipal { get; set; }

        public override string ToString()
        {
            return $"{NomeElemento}";
        }
    }
}
