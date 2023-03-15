using System.Diagnostics;
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
            try
            {
                string jsonString = ReadFromStorage();
                if (jsonString != null && jsonString != "")
                {
                    Items = JsonSerializer.Deserialize<List<LocalStorageItem>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not read Items" + ex.Message);
            }
        }
        private void Save() {
            try
            {
                string jsonString = JsonSerializer.Serialize(Items);
                SaveToStorage(jsonString);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not save Items" + ex.Message);
            }
        }
        public string GetItem(string key)
        {
            if (Items == null) { Read(); }
            if (Items != null)
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
            if (Items == null) { Items = new List<LocalStorageItem>(); }
            
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

