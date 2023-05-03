using System;
using System.IO;

namespace BethTimeUntilWPF.Services
{
    public class LocalStorage : Root.Services.LocalStorage
    {

        static string storageFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + StorageKeyName + ".txt";

        protected override string ReadFromStorage()
        {
            if (File.Exists(storageFile)) {
                return File.ReadAllText(storageFile);                
            } else { 
                return ""; 
            }            
        }
        protected override void SaveToStorage(string jsonString)
        {
            if (!File.Exists(storageFile)) { File.Create(storageFile); }
            File.WriteAllText(storageFile, jsonString);
        }

    }
}
