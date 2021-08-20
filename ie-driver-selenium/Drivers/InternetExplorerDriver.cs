using FnzIeSeleniumDriver.Elementos;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Reflection;

namespace FnzIeSeleniumDriver
{
    public class InternetExplorerDriver : IDisposable
    {
        public IWebDriver Driver { get; }

        public string JanelaPrincipal { get; set; }

        /// <summary>
        /// Create new instance of InternetExplorerDriver
        /// </summary>
        /// <param name="pathOfDriver">Path of driver IE ( Currently version accept 3.150.1 )</param>
        public InternetExplorerDriver(string pathOfDriver)
        {
            var ieOptions = new InternetExplorerOptions
            {
                RequireWindowFocus = false,
                EnableNativeEvents = true,
                IgnoreZoomLevel = true,
                PageLoadStrategy = PageLoadStrategy.Eager,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = false,
                BrowserCommandLineArguments = "-noframemerging",
            };

            ieOptions.AddAdditionalCapability("disable-popup-blocking", true);
            ieOptions.AddAdditionalCapability("silent", true);

            var pathDriver = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + pathOfDriver;

            Driver = new OpenQA.Selenium.IE.InternetExplorerDriver(pathDriver,ieOptions);

            Driver.Manage().Window.Maximize();
        }

        public void Navegar(string url)
        {
            Driver.Navigate().GoToUrl(url);
            
            JanelaPrincipal = Driver.CurrentWindowHandle;
        }

        public IBotao GetBotao(string nomeElemento, BuscaPor procurarPor, string atributo = "",Navegacao navegacao = null)
        {
            return new Botao(CreateConfiguracaoElemento(TipoElemento.Botao,nomeElemento,procurarPor,atributo,navegacao));
        }

        public IAlerta GetAlerta(string nomeElemento, BuscaPor procurarPor, string atributo = "", Navegacao navegacao = null)
        {
            return new Alerta(CreateConfiguracaoElemento(TipoElemento.Alerta, nomeElemento, procurarPor, atributo, navegacao));
        }

        public IInputTexto GetInputTexto(string nomeElemento, BuscaPor procurarPor, string atributo = "", Navegacao navegacao = null)
        {
            return new InputTexto(CreateConfiguracaoElemento(TipoElemento.InputTexto, nomeElemento, procurarPor, atributo, navegacao));
        }

        public ISelect GetSelect(string nomeElemento, BuscaPor procurarPor, string atributo = "", Navegacao navegacao = null)
        {
            return new Select(CreateConfiguracaoElemento(TipoElemento.Select, nomeElemento,procurarPor, atributo, navegacao));
        }

        public ITable GetTable(string nomeElemento, BuscaPor procurarPor, string atributo = "", Navegacao navegacao = null)
        {
            return new Table(CreateConfiguracaoElemento(TipoElemento.Table, nomeElemento, procurarPor, atributo, navegacao));
        }

        public ITr GetTr(string nomeElemento, BuscaPor procurarPor, string atributo = "", Navegacao navegacao = null)
        {
            return new Tr(CreateConfiguracaoElemento(TipoElemento.Tr, nomeElemento, procurarPor, atributo, navegacao));
        }

        [Obsolete("GetElemento is deprecated, please use GetBotao,GetSelect,etc... instead.")]
        public Elemento GetElemento(ConfiguracaoElemento configuracaoElemento)
        {
            Elemento elemento = null;

            configuracaoElemento.Driver = Driver;

            configuracaoElemento.JanelaPrincipal = JanelaPrincipal;

            switch ((int)configuracaoElemento.TipoElemento)
            {
                case (int)TipoElemento.InputTexto: elemento = new InputTexto(configuracaoElemento); break;
                case (int)TipoElemento.Select: elemento = new Select(configuracaoElemento); break;
                case (int)TipoElemento.Botao: elemento = new Botao(configuracaoElemento); break;
                case (int)TipoElemento.Tr: elemento = new Tr(configuracaoElemento); break;
                case (int)TipoElemento.Table: elemento = new Table(configuracaoElemento); break;
                case (int)TipoElemento.Alerta: elemento = new Alerta(configuracaoElemento); break;
                default: break;
            }

            return elemento;
        }

        private ConfiguracaoElemento CreateConfiguracaoElemento(TipoElemento tipoElemento,string nomeElemento,
            BuscaPor procurarPor,string atributo = "", Navegacao navegacao = null)
        {
            return new ConfiguracaoElemento
            {
                Driver = Driver,
                JanelaPrincipal = JanelaPrincipal,
                TipoElemento = tipoElemento,
                NomeElemento = nomeElemento,
                ProcurarElementoPor = procurarPor,
                Atributo = procurarPor == BuscaPor.Atributo ? atributo : "",
                Navegacao = navegacao is null ? new Navegacao() : navegacao
            };
        }

        public void Dispose()
        {
            if (Driver != null)
                Driver.Quit();

            Driver.Dispose();
        }
    }
}
