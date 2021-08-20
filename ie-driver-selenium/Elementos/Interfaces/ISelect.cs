namespace FnzIeSeleniumDriver.Elementos
{
    public interface ISelect
    {
        bool SelecionarPorTexto(string texto);

        bool Clicar();

        bool ExisteOptionPorTexto(string texto);
    }
}
