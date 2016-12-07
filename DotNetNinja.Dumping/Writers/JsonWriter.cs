using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNetNinja.Dumping
{
    public class JsonWriter : IJsonWriter
    {
        JsonSerializerSettings _settings;

        public JsonWriter(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public string Write(ObjectDump dump)
            => JsonConvert.SerializeObject(dump, _settings);
    }
}
