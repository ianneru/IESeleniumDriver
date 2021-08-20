using OpenQA.Selenium;
using System.Threading;

namespace FnzIeSeleniumDriver.Elementos
{
    public class Botao : Elemento,IBotao
    {
        public Botao(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {
        }

        public bool Clicar()
        {
            Thread.Sleep(500);

            elemento.Click();

            return true;
        }

        public bool ClicarEventoJavascript()
        {
            IJavaScriptExecutor executor = _configuracaoElemento
                                            .Driver as IJavaScriptExecutor;

            return executor.ExecuteScript("arguments[0].click();", elemento) != null;
        }
    }
}
