namespace FnzIeSeleniumDriver.Elementos
{
    public interface ITable
    {
        string GetTextoPrimeiroTdByTextoFilhos(string[] textos);

        bool ExisteTextoNosFilhos(string[] textos);
    }
}
