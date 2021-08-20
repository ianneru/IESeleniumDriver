using OpenQA.Selenium;
using System;
using System.Linq;

namespace FnzIeSeleniumDriver.Elementos
{
    public class Select : Elemento,ISelect
    {
        public Select(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {
        }

        public  bool Clicar()
        {
            elemento.Click();

            return true;
        }

        public  bool SelecionarPorTexto(string texto)
        {
            try
            { 
                selectElement.SelectByText(texto);
            }
            catch(Exception ex)
            {
                elemento.SendKeys(texto + Keys.Enter);
            }

            return true;
        }

        public  bool ExisteOptionPorTexto(string texto) => selectElement
                                                            .Options
                                                            .Any(o => o.Text == texto);
    }
}
