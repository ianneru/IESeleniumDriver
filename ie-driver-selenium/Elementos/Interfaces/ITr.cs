using OpenQA.Selenium;

namespace FnzIeSeleniumDriver.Elementos
{
    public interface ITr
    {
        IWebElement FindTDPorTextoConteudo(string texto);

        bool ClicarEventoJavascript();
    }
}
