namespace TimeUntilMAUI.Services
{
    public class LocalStorage : Root.Services.LocalStorage
    {
        protected override string ReadFromStorage()
        {
            return Preferences.Get(StorageKeyName, "");
        }
        protected override void SaveToStorage(string jsonString)
        {            
            Preferences.Set(StorageKeyName, jsonString);            
        }

    }
}
