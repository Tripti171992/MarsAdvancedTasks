using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskNUnit.Utilities
{
    public class JsonReader
    {
        public static List<T> GetData<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            List<T> objectList = JsonConvert.DeserializeObject<List<T>>(json);
            return objectList;
        }
    }
}
