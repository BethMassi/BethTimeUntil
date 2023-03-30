﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Interfaces;

namespace BethTimeUntil.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return DeviceInfo.Idiom.ToString();
        }
    }
}
