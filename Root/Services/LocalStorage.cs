using System.Text.Json;

namespace Root.Services
{
    internal class LocalStorageItem
    {
        //Model Name (i.e. TimeUntilModel)
        public string Key { get; set; }

        //JsonSerialized properties of the model 
        public string Value { get; set; }
    }

    public abstract class LocalStorage : Interfaces.ILocalStorage
    {
        private List<LocalStorageItem> Items;
        protected const string StorageKeyName = "TimeUntilItems";

        //Each implementation has a different way of storing local.
        //Maui storage takes care of everything but web. For WebAsm, use Blazored. 
        protected abstract void SaveToStorage(string jsonString);
        protected abstract string ReadFromStorage();

        private void Read()
        {
            string jsonString = ReadFromStorage();
            if (jsonString != null)
            {
                Items = JsonSerializer.Deserialize<List<LocalStorageItem>>(jsonString);
            }
        }
        private void Save() {
            string jsonString = JsonSerializer.Serialize(Items);
            SaveToStorage(jsonString);
        }

        public string GetItem(string key)
        {
            if (this.Items == null) { Read(); }
            if (this.Items != null)
            {
                var item = Items.FirstOrDefault(i => i.Key == key);
                if (item != null)
                {
                    return item.Value;
                }
            }
            return null;
        }
        public void SetItem(string key, string value)
        {
            if (this.Items != null)
            {
                var item = Items.FirstOrDefault(i => i.Key == key);
                if (item != null)
                {
                    item.Value = value;
                }
                else
                {
                    Items.Add(new LocalStorageItem { Key = key, Value = value });
                }
                Save();
            }
        }
        public void RemoveItem(string key)
        {
            if (this.Items != null)
            {
                var item = Items.FirstOrDefault(i => i.Key == key);
                if (item != null)
                {
                    Items.Remove(item);
                }
                Save();    
            }
        }
    }
}

