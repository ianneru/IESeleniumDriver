using OpenQA.Selenium;

namespace FnzIeSeleniumDriver.Elementos
{
    public class Tr : Elemento,ITr
    {
        public Tr(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {
        }

        public  bool Clicar()
        {
            elemento.Click();

            return true;
        }

        public  IWebElement FindTDPorTextoConteudo(string texto)
        {
            IWebElement retorno = null;

            foreach (var elemento in elementos)
            {
                foreach (var conteudoTD in elemento.FindElements(By.TagName("td")))
                {
                    //Implementar por cada tagName
                    foreach (var font in conteudoTD.FindElements(By.TagName("font")))
                    {
                        if (font.Text.IndexOf(texto) >= 0)
                        {
                            retorno = conteudoTD;
                            break;
                        }
                    }

                    if (conteudoTD.Text.IndexOf(texto) > 0)
                        retorno = conteudoTD;

                    if (retorno != null)
                        break;
                }

                if (retorno != null)
                    break;
            }

            return retorno;
        }

        public  bool ClicarEventoJavascript()
        {
            IJavaScriptExecutor executor = _configuracaoElemento
                                            .Driver as IJavaScriptExecutor;

            return executor.ExecuteScript("arguments[0].click();", elemento) != null;
        }
    }
}
