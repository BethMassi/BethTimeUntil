using Root.Interfaces;

namespace BethTimeUntilWeb.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Web";
        }
    }
}
