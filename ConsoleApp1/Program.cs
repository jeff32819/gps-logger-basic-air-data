using Newtonsoft.Json;

var obj = GpsLoggerDll.Parse.FromDisk("T:\\test.gpx");
Console.WriteLine( Newtonsoft.Json.JsonConvert.SerializeObject(obj, Formatting.Indented));


