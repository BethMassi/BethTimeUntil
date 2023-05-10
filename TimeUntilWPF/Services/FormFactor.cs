using Root.Interfaces;
using System;

namespace TimeUntilWPF.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Desktop - WPF";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
