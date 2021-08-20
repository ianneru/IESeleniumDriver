namespace FnzIeSeleniumDriver.Elementos
{
    public class Alerta : Elemento, IAlerta
    {
        public Alerta(ConfiguracaoElemento configuracaoElemento)
            : base(configuracaoElemento)
        {

        }

        public bool Clicar()
        {
            alertElement.Accept();

            return true;
        }
    }
}
