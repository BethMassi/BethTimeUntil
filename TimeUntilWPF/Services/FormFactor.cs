using Root.Interfaces;

namespace TimeUntilWPF.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Windows - WPF";
        }
    }
}
