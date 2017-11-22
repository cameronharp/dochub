using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class SubArticle : ArticleBase
    {
        #region Properties

        public IList<Article> SubArticles { get; set; }

        #endregion
    }
}