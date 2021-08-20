using System.Linq;

namespace FnzIeSeleniumDriver
{
    public class Navegacao
    {
        public Navegacao()
        {
            ProximoWindow = false;
            PrimeiroIframe = false;
            PrimeiroFrame = false;
            Frame = new string[] { };
        }

        public string[] Frame { get; set; }
        
        public bool ProximoWindow { get; set; }

        public bool PrimeiroIframe { get; set; }

        public bool PrimeiroFrame { get; set; }

        public bool PorFrame() => (Frame ?? new string[] { }).Any();
    }
}
