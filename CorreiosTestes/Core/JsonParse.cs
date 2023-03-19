using Newtonsoft.Json;

namespace CorreiosTestes.Core
{
    [Binding]
    public class JsonParse
    {
        public dynamic ToDynamic(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}
