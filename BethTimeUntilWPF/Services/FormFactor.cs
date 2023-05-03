using Root.Interfaces;

namespace BethTimeUntilWPF.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Windows - WPF";
        }
    }
}
