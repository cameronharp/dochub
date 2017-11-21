using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class GlobalConfiguration
    {
        #region Properties

        public string SiteTitle { get; set; }

        public string LandingPageHeader { get; set; }

        public IList<string> Topics { get; set; }

        #endregion
    }
}