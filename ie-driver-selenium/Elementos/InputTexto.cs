using System.Threading;

namespace FnzIeSeleniumDriver.Elementos
{
    public class InputTexto : Elemento,IInputTexto
    {
        public InputTexto(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {
        }

        public bool Digitar(string termo)
        {
            if (!elemento.Enabled)
                return false;

            elemento.Clear();

            elemento.SendKeys(termo);

            Thread.Sleep(500);

            return true;
        }
    }
}
