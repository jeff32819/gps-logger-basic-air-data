using Newtonsoft.Json;
namespace GpsLoggerDll
{
    public class Model
    {
        [JsonProperty("?xml")] public Xml xml { get; set; }

        [JsonProperty("#comment")] public List<object> comment { get; set; }

        public Gpx gpx { get; set; }

        public class Bounds
        {
            [JsonProperty("@minlat")] public string minlat { get; set; }

            [JsonProperty("@minlon")] public string minlon { get; set; }

            [JsonProperty("@maxlat")] public string maxlat { get; set; }

            [JsonProperty("@maxlon")] public string maxlon { get; set; }
        }

        public class Gpx
        {
            [JsonProperty("@version")] public string version { get; set; }

            [JsonProperty("@creator")] public string creator { get; set; }

            [JsonProperty("@xmlns")] public string xmlns { get; set; }

            [JsonProperty("@xmlns:xsi")] public string xmlnsxsi { get; set; }

            [JsonProperty("@xsi:schemaLocation")] public string xsischemaLocation { get; set; }

            public string name { get; set; }
            public string desc { get; set; }
            public DateTime time { get; set; }
            public string keywords { get; set; }
            public Bounds bounds { get; set; }
            [JsonConverter(typeof(SingleOrArrayConverter<Model.Wpt>))]
            public List<Wpt> wpt { get; set; }
            public Trk trk { get; set; }
        }


        public class Trk
        {
            public string name { get; set; }
            public Trkseg trkseg { get; set; }
        }

        public class Trkpt
        {
            [JsonProperty("@lat")] public string lat { get; set; }

            [JsonProperty("@lon")] public string lon { get; set; }

            public string ele { get; set; }
            public DateTime time { get; set; }
            public string speed { get; set; }
            public string sat { get; set; }
        }

        public class Trkseg
        {
            public List<Trkpt> trkpt { get; set; }
        }

        public class Wpt
        {
            [JsonProperty("@lat")] public string lat { get; set; }

            [JsonProperty("@lon")] public string lon { get; set; }

            public string ele { get; set; }
            public DateTime time { get; set; }
            public string name { get; set; }
            public string sat { get; set; }
        }

        public class Xml
        {
            [JsonProperty("@version")] public string version { get; set; }

            [JsonProperty("@encoding")] public string encoding { get; set; }
        }
    }
}
