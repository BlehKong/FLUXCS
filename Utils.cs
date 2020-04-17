using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FLUX
{
    public class Utils
    {
        public static Task<T> GetSerializedJson<T> (string url) where T : new()
        {
             Task<T> task = Task.Run<T>(async () => {
                using (var fetch = new HttpClient())
                {
                    var data = string.Empty;
                    try
                    {
                        data = await fetch.GetStringAsync(url);
                    }
                    catch (Exception) { }
                    return !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<T>(data) : new T();
                }
            });
            return task;
        }
    }
}
