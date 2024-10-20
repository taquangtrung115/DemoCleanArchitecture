using Hanssens.Net;
using HR.LeaveManagement.MVC.Contracts;

namespace HR.LeaveManagement.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage localStorage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.LEAVEMGMT"
            };
            localStorage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var item in keys)
            {
                localStorage.Remove(item);
            }
        }

        public bool Exists(string key)
        {
            return localStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return localStorage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            localStorage.Store(key, value);
            localStorage.Persist();
        }
    }
}