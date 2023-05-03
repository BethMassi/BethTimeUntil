using Blazored.LocalStorage;

namespace TimeUntilWeb.Services
{
    public class LocalStorage : Root.Services.LocalStorage
    {
        private ISyncLocalStorageService LocalStorageService;

        public LocalStorage(ISyncLocalStorageService _localStorageService)
        {
            LocalStorageService = _localStorageService;
        }

        protected override string ReadFromStorage()
        {            
             return LocalStorageService.GetItem<string>(StorageKeyName);
        }

        protected override void SaveToStorage(string jsonString)
        {                
            LocalStorageService.SetItem(StorageKeyName, jsonString);            
        }
    }
}
