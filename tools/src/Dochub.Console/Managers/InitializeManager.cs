using System;
using System.Dynamic;
using System.IO;
using Dochub.Console.Constants;
using Dochub.Console.Models;
using Dochub.Console.Utilities;
using Newtonsoft.Json;

namespace Dochub.Console.Managers
{
    public class InitializeManager
    {
        #region Fields

        private string _configFilePath { get; }

        private string _siteFilePath { get; }

        #endregion

        #region Properties



        #endregion

        #region Constructors

        public InitializeManager()
            : this ($"{Directory.GetCurrentDirectory()}/{FileName.Config}",
                $"{Directory.GetCurrentDirectory()}/{FileName.Site}")
        {

        }

        public InitializeManager(string configFilePath, string siteFilePath)
        {
            _configFilePath = !String.IsNullOrEmpty(configFilePath) 
                ? configFilePath 
                : throw new ArgumentNullException(nameof(configFilePath));

            _siteFilePath = !String.IsNullOrEmpty(siteFilePath)
                ? siteFilePath
                : throw new ArgumentNullException(nameof(siteFilePath));
        }

        #endregion

        #region Methods

        public void Init()
        {
            FileUtility.EnsureFile(_configFilePath);

            var config = JsonConvert.DeserializeObject<GlobalConfiguration>(File.ReadAllText(_configFilePath));

            if (!Directory.Exists(_siteFilePath))
            {
                Directory.CreateDirectory(_siteFilePath);
            }

            //if (!Directory.Exists("_site\\topics"))
            //{
            //    Directory.CreateDirectory("_site\\topics");
            //}

            //foreach (var topic in config?.Topics)
            //{
            //    if (!Directory.Exists($"_site\\topics\\{topic}"))
            //    {
            //        Directory.CreateDirectory($"_site\\topics\\{topic}");
            //        Directory.CreateDirectory($"_site\\topics\\{topic}\\articles");

            //        using (var sw = File.CreateText($"_site\\topics\\{topic}\\config.json"))
            //        {
            //            sw.WriteLine("{");

            //            sw.WriteLine("}");
            //        }
            //    }
            //}
        }

        #endregion
    }
}