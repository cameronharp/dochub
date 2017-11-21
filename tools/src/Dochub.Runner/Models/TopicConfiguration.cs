using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class TopicConfiguration
    {
        #region Properties

        public IList<TopicArticleSection> Articles { get; set; }

        public IList<CodeRepository> CodeRepositories { get; set; }

        #endregion
    }
}