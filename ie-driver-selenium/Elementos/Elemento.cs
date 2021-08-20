using FnzIeSeleniumDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FnzIeSeleniumDriver.Elementos
{
    public abstract class Elemento
    {
        public IWebElement elemento;
        public ICollection<IWebElement> elementos;

        protected readonly SelectElement selectElement;
        protected readonly IAlert alertElement;
        protected readonly ConfiguracaoElemento _configuracaoElemento;

        public Elemento(ConfiguracaoElemento configuracaoElemento)
        {
            _configuracaoElemento = configuracaoElemento;
            var driver = configuracaoElemento.Driver;

            if (configuracaoElemento.TipoElemento == TipoElemento.Alerta)
            {
                alertElement = driver.SwitchAlertaOK();
                return;
            }

            var findElem = false;
            var cont = 0;

            do
            {
                try
                {
                    //Muda o driver para o conteúdo default
                    driver.SwitchDefault(configuracaoElemento.JanelaPrincipal);

                    if (configuracaoElemento.Navegacao.ProximoWindow)
                        driver.Popup(configuracaoElemento.JanelaPrincipal);

                    if (configuracaoElemento.Navegacao.PrimeiroIframe)
                        driver.PrimeiroIframe();

                    if (configuracaoElemento.Navegacao.PrimeiroFrame)
                        driver.Primeiroframe();

                    //Mudar o driver para a navegacao de Frames
                    if (configuracaoElemento.Navegacao.PorFrame())
                        foreach (var frame in configuracaoElemento.Navegacao.Frame)
                        {
                            driver.SwitchFrame(frame);
                        }

                    if (configuracaoElemento.ProcurarElementoPor == BuscaPor.Name)
                        SelecionarPorName(buscarTodosElementos: configuracaoElemento.TipoElemento == TipoElemento.Tr);
                    else if (configuracaoElemento.ProcurarElementoPor == BuscaPor.Atributo)
                        SelecionarPorAtributo(buscarTodosElementos: configuracaoElemento.TipoElemento == TipoElemento.Tr);

                    findElem = (this.elemento != null);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    cont++;
                }
            } while (!findElem && cont < 20);

            if (cont == 20)
                throw new Exception("Não foi encontrado elemento : " + configuracaoElemento.ToString());

            if (configuracaoElemento.TipoElemento == TipoElemento.Select)
            {
                this.selectElement = new SelectElement(elemento);
            }
        }

        private void SelecionarPorName(bool buscarTodosElementos = false)
        {
            this.elemento = _configuracaoElemento
                                        .Driver
                                        .FindElement(By.Name(_configuracaoElemento.NomeElemento), 30);

            if (buscarTodosElementos)
                this.elementos = _configuracaoElemento
                                            .Driver
                                            .FindElements(By.Name(_configuracaoElemento.NomeElemento), 30);
        }

        private void SelecionarPorAtributo(bool buscarTodosElementos = false)
        {
            this.elemento = _configuracaoElemento
                                .Driver
                                .FindElement(SelectorByAttributeValue(_configuracaoElemento.Atributo, _configuracaoElemento.NomeElemento), 30);

            if (buscarTodosElementos)
                this.elementos = _configuracaoElemento
                                .Driver
                                .FindElements(SelectorByAttributeValue(_configuracaoElemento.Atributo, _configuracaoElemento.NomeElemento), 30);
        }

        private By SelectorByAttributeValue(string p_strAttributeName, string p_strAttributeValue)
        {
            return (By.XPath(String.Format("//*[contains(@{0},'{1}')]",
                                           p_strAttributeName,
                                           p_strAttributeValue)));
        }

        public bool Existe() => elemento != null;
    }
}
