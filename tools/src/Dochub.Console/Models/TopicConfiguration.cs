using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class TopicConfiguration
    {
        #region Properties

        public string Name { get; set; }

        public Articles Articles { get; set; }

        public IList<CodeRepository> CodeRepositories { get; set; }

        #endregion
    }
}