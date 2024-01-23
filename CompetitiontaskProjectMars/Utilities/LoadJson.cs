using Newtonsoft.Json;
using OpenQA.Selenium.DevTools.V118.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompetitiontaskProjectMars.Utilities
{
    public class LoadJson
    {

        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(text);

        }
    }

}
//Or, if you prefer something simpler/synchronous:

//class Program
//{
//    static void Main()
//    {
//        Item item = JsonFileReader.Read<Item>(@"C:\myFile.json");
//    }
//}

//public static class JsonFileReader
//{
//    public static T Read<T>(string filePath)
//    {
//        string text = File.ReadAllText(filePath);
//        return JsonSerializer.Deserialize<T>(text);
//    }
//}
//List<type> list = new List<type>() 
//https://code-maze.com/csharp-read-and-process-json-file/#:~:text=First%2C%20we%20use%20a%20StreamReader,data%20in%20the%20JSON%20file.