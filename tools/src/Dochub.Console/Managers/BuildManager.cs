using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dochub.Console.Constants;
using Dochub.Console.Models;
using Newtonsoft.Json;

namespace Dochub.Console.Managers
{
    public class BuildManager
    {
        #region Fields

        private string UserConfigFilePath { get; }

        private string SiteFolderPath { get; }

        private string TopicsFolderPath { get; }

        private string BuildCongifFilePath { get; }

        #endregion

        #region Constructors

        public BuildManager()
            : this($"{Directory.GetCurrentDirectory()}/{FileName.UserConfig}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}",
                $"{Directory.GetCurrentDirectory()}/{FolderName.Site}/{FolderName.Topics}",
                $"{Directory.GetCurrentDirectory()}/{FileName.BuildConfig}")
        {
            
        }

        public BuildManager(string userConfigFilePath, string siteFolderPath, string topicsFolderPath, string buildConfigFilePath)
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

            BuildCongifFilePath = !String.IsNullOrEmpty(buildConfigFilePath)
                ? buildConfigFilePath
                : throw new ArgumentNullException(nameof(buildConfigFilePath));
        }

        #endregion

        #region Methods

        public void Build()
        {
            if (!Directory.Exists(SiteFolderPath))
            {
                System.Console.WriteLine(Message.Error.NoSiteFolderOnBuild);
            }

            var userConfig = JsonConvert.DeserializeObject<UserConfiguration>(File.ReadAllText(UserConfigFilePath));
            var buildConfiguration = new BuildConfiguration(userConfig);

            if (Directory.Exists(TopicsFolderPath))
            {
                var topics = Directory.GetDirectories(TopicsFolderPath);

                foreach (var topic in topics)
                {
                    var info = new DirectoryInfo(topic);

                    buildConfiguration.Topics.Add(new TopicConfiguration
                    {
                        Name = info.Name,
                        Articles = buildArticles(info),
                        CodeRepositories = buildCodeRepositories(info)
                    });
                }
            }

            using (var sw = File.CreateText(BuildCongifFilePath))
            {
                sw.WriteLine($"var config = {JsonConvert.SerializeObject(buildConfiguration)}");
            }
        }

        private Articles buildArticles(DirectoryInfo topicInfo)
        {
            var articleFolderPath = $"{topicInfo.FullName}/{FolderName.Articles}";

            if (!Directory.Exists(articleFolderPath))
            {
                return null;
            }

            var files = Directory.GetFiles(articleFolderPath);

            if (files == null || !files.Any())
            {
                return null;
            }

            var articles = new Articles();

            // Get standalone files
            foreach (var file in files)
            {
                var article = createStandAloneArticle(file);

                articles.StandAloneArticles.Add(article);
            }

            // Get sub articles
            var subArticles = Directory.GetDirectories(articleFolderPath);

            foreach (var subArticle in subArticles)
            {
                var subArticleInfo = new DirectoryInfo(subArticle);

                articles.SubArticles.Add(new SubArticle
                {
                    Name = subArticleInfo.Name,
                    SubArticles = subArticleInfo.GetFiles().Select(m => createStandAloneArticle(m.FullName)).ToList()
                });
            }

            return articles;
        }

        private static Article createStandAloneArticle(string file)
        {
            var fileInfo = new FileInfo(file);

            if (!String.Equals(fileInfo.Extension, ".md"))
            {
                System.Console.WriteLine(String.Format(Message.Warning.NotVaildArticleExtension, fileInfo.Name));
            }

            var article = new Article
            {
                Name = fileInfo.Name.Replace(fileInfo.Extension, ""),
                Extension = fileInfo.Extension,
                Content = File.ReadAllText(fileInfo.FullName)
            };

            return article;
        }

        private IList<CodeRepository> buildCodeRepositories(DirectoryInfo info)
        {
            return null;
        }

        #endregion
    }
}