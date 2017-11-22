using System;
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

        private string UserConfigFilePath { get; }

        private string SiteFolderPath { get; }

        private string TopicsFolderPath { get; }

        #endregion

        #region Properties



        #endregion

        #region Constructors

        public InitializeManager()
            : this ($"{Directory.GetCurrentDirectory()}/{FileName.UserConfig}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}/{FolderName.Topics}")
        {
        }

        public InitializeManager(string userConfigFilePath, string siteFolderPath, string topicsFolderPath)
        {
            UserConfigFilePath = !String.IsNullOrEmpty(userConfigFilePath) 
                ? userConfigFilePath 
                : throw new ArgumentNullException(nameof(userConfigFilePath));

            SiteFolderPath = !String.IsNullOrEmpty(siteFolderPath)
                ? siteFolderPath
                : throw new ArgumentNullException(nameof(siteFolderPath));

            TopicsFolderPath = !String.IsNullOrEmpty(topicsFolderPath)
                ? topicsFolderPath
                : throw new ArgumentNullException(nameof(topicsFolderPath));
        }

        #endregion

        #region Methods

        public void Init()
        {
            FileUtility.EnsureFile(UserConfigFilePath);

            var config = JsonConvert.DeserializeObject<UserConfiguration>(File.ReadAllText(UserConfigFilePath));

            ensureSiteFolder();

            ensureTopicsFolder();

            ensureTopicSubFolders(config);
        }

        private void ensureSiteFolder()
        {
            if (!Directory.Exists(SiteFolderPath))
            {
                Directory.CreateDirectory(SiteFolderPath);
            }
        }

        private void ensureTopicsFolder()
        {
            if (!Directory.Exists(TopicsFolderPath))
            {
                Directory.CreateDirectory(TopicsFolderPath);
            }
        }

        private void ensureTopicSubFolders(UserConfiguration config)
        {
            if (config.Topics != null)
            {
                foreach (var topic in config.Topics)
                {
                    var topicFolderPath = $"{TopicsFolderPath}\\{topic}";
                    var articlesFolderPath = $"{topicFolderPath}\\{FolderName.Articles}";

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