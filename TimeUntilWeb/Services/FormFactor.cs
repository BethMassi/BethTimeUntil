using Root.Interfaces;

namespace TimeUntilWeb.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Web Server";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
