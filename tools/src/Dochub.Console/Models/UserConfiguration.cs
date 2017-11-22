using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class UserConfiguration : BaseConfiguration
    {
        #region Properties

        public IList<string> Topics { get; set; }

        #endregion
    }
}