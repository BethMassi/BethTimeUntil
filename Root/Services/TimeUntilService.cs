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
            if (myModel == null)
            {
                myModel = new TimeUntilModel();
                myModel.Name = "Beth's Retirement";
                myModel.CountdownDate = new DateTime(2027, 10, 20);
            }
            return myModel;
        }

        public static void SaveModel(TimeUntilModel myModel, ILocalStorage storage)
        {
            string jsonString = JsonSerializer.Serialize(myModel);
            storage.SetItem(ModelName, jsonString);
        }

    }
}
