using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Root.Models;
using Root.Interfaces;

namespace Root.Services
{
    internal class TimeUntilService
    {
        private static TimeUntilModel myModel;
        private static TimeUntilImages images = new TimeUntilImages();
        private const string ModelName = "TimeUntilModel";

        public static TimeUntilModel GetModel(ILocalStorage storage)
        {
            if (myModel == null)
            {
                string jsonString = storage.GetItem(ModelName);
                if (jsonString != null)
                {
                    myModel = JsonSerializer.Deserialize<TimeUntilModel>(jsonString);
                }
            }
            myModel ??= new TimeUntilModel();
            return myModel;
        }
        public static void SaveModel(TimeUntilModel myModel, ILocalStorage storage)
        {
            string jsonString = JsonSerializer.Serialize(myModel);
            storage.SetItem(ModelName, jsonString);
        }
        
        public static TimeUntilImages GetImages()
        {
            return images;
        }
        
    }
}
