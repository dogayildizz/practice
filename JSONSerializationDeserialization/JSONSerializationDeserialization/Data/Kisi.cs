using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSONSerializationDeserialization.Data
{
    public class Kisi
    {
        public string Ad { get; set; }

        //Serialize/Deserialize'a dahil etmemek için bunu yazarız.
        //  [JsonIgnore]
        public string Soyad { get; set; }
        public string Adres { get; set; }
    }
}
