using Blazored.LocalStorage;

namespace TimeUntilWeb.Services
{
    public class LocalStorage : Root.Services.LocalStorage
    {
        private ILocalStorageService LocalStorageService;

        public LocalStorage(ILocalStorageService _localStorageService)
        {
            LocalStorageService = _localStorageService;
        }

        protected override string ReadFromStorage()
        {
            ValueTask<string?> task = LocalStorageService.GetItemAsync<string>(StorageKeyName);
            return task.GetAwaiter().GetResult() ?? string.Empty;

        }

        protected override void SaveToStorage(string jsonString)
        {                
            LocalStorageService.SetItemAsync(StorageKeyName, jsonString);            
        }
    }
}
