using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class Article : ArticleBase
    {
        #region Properties

        public string Extension { get; set; }

        public string Content { get; set; }

        #endregion
    }
}