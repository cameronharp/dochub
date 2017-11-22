using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class Articles
    {
        #region Properties

        public IList<Article> StandAloneArticles { get; set; } = new List<Article>();
        
        public IList<SubArticle> SubArticles { get; set; } = new List<SubArticle>();

        #endregion
    }
}