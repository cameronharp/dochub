using System;
using System.IO;
using System.Reflection;
using Dochub.Console.Models;
using Newtonsoft.Json;

namespace Dochub.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Here!");

            var config = JsonConvert.DeserializeObject<GlobalConfiguration>(File.ReadAllText("config.json"));

            if (!Directory.Exists("_site"))
            {
                Directory.CreateDirectory("_site");
            }

            if (!Directory.Exists("_site\\topics"))
            {
                Directory.CreateDirectory("_site\\topics");
            }

            foreach (var topic in config?.Topics)
            {
                if (!Directory.Exists($"_site\\topics\\{topic}"))
                {
                    Directory.CreateDirectory($"_site\\topics\\{topic}");
                    Directory.CreateDirectory($"_site\\topics\\{topic}\\articles");

                    using (var sw = File.CreateText($"_site\\topics\\{topic}\\config.json"))
                    {
                        sw.WriteLine("{");

                        sw.WriteLine("}");
                    }
                }
            }
        }
    }
}