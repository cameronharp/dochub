using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class TopicArticleSection : TopicArticle
    {
        #region Properties

        public IList<TopicArticle> SubArticles { get; set; }

        #endregion
    }
}