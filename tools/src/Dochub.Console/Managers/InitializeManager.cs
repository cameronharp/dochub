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

        private string _siteFolderPath { get; }

        private string _topicsFolderPath { get; }

        #endregion

        #region Properties



        #endregion

        #region Constructors

        public InitializeManager()
            : this ($"{Directory.GetCurrentDirectory()}/{FileName.Config}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}/{FolderName.Topics}")
        {

        }

        public InitializeManager(string configFilePath, string siteFolderPath, string topicsFolderPath)
        {
            _configFilePath = !String.IsNullOrEmpty(configFilePath) 
                ? configFilePath 
                : throw new ArgumentNullException(nameof(configFilePath));

            _siteFolderPath = !String.IsNullOrEmpty(siteFolderPath)
                ? siteFolderPath
                : throw new ArgumentNullException(nameof(siteFolderPath));

            _topicsFolderPath = !String.IsNullOrEmpty(topicsFolderPath)
                ? topicsFolderPath
                : throw new ArgumentNullException(nameof(topicsFolderPath));
        }

        #endregion

        #region Methods

        public void Init()
        {
            FileUtility.EnsureFile(_configFilePath);

            var config = JsonConvert.DeserializeObject<GlobalConfiguration>(File.ReadAllText(_configFilePath));

            if (!Directory.Exists(_siteFolderPath))
            {
                Directory.CreateDirectory(_siteFolderPath);
            }

            if (!Directory.Exists(_topicsFolderPath))
            {
                Directory.CreateDirectory(_topicsFolderPath);
            }

            if (config.Topics != null)
            {
                foreach (var topic in config.Topics)
                {
                    var topicFolderPath = $"{_topicsFolderPath}\\{topic}";
                    var articlesFolderPath = $"{topicFolderPath}\\articles";

                    if (!Directory.Exists(topicFolderPath))
                    {
                        Directory.CreateDirectory(topicFolderPath);

                        createSingleTopicsArticlesFolder(articlesFolderPath);
                    }
                    else
                    {
                        createSingleTopicsArticlesFolder(articlesFolderPath);
                    }
                }
            }
        }

        private void createSingleTopicsArticlesFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        #endregion
    }
}