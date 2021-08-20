using OpenQA.Selenium;
using System;
using System.Linq;

namespace FnzIeSeleniumDriver.Elementos
{
    public class Table : Elemento,ITable
    {
        public Table(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {
        }

        public  string GetTextoPrimeiroTdByTextoFilhos(string[] textos)
        {
            if (!elemento.FindElements(By.TagName("tr")).Any())
                return string.Empty;

            int? count = textos?.Length;

            int amount = count ?? default(int);

            var retorno = new bool[amount];

            var indexTr = 0;
            
            var indexTrEncontrado = 0;

            var cont = 0;

            foreach (var tr in elemento.FindElements(By.TagName("tr")))
            {
                foreach(var conteudoTD in tr.FindElements(By.TagName("td")))
                {
                    cont = 0;
                    foreach (var texto in textos)
                    {
                        if (conteudoTD.Text.Replace("\r\n", "").Contains(texto.Replace(@"\r\n", "")))
                        {
                            retorno[cont] = true;
                            indexTrEncontrado = indexTr;
                        }
                        cont++;
                    }
                }

                indexTr++;
            }

            if(retorno.All(o => o == true))
            {
                return elemento
                        .FindElements(By.TagName("tr"))[indexTrEncontrado]
                        .FindElements(By.TagName("td"))[0].Text;

            }
            
            return string.Empty;

        }

        public  bool ExisteTextoNosFilhos(string[] textos)
        {
            int? count = textos?.Length;
            
            int amount = count ?? default(int);

            var retorno = new bool[amount];
            
            var cont = 0;

            foreach(var conteudoTD in elemento.FindElements(By.TagName("td")))
            {
                if (string.IsNullOrEmpty(conteudoTD.Text))
                    continue;

                cont = 0;
                foreach (var texto in textos)
                {
                    if (conteudoTD.Text.Replace("\r\n", "").Contains(texto.Replace(@"\r\n", "")))
                    {
                        retorno[cont] = true;
                    }
                    cont++;
                }
            }

            return retorno.All(o=> o == true);
        }

    }
}
