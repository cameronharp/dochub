using System.Collections.Generic;

namespace Dochub.Console.Models
{
    public class CodeRepository
    {
        #region Properties

        public string Name { get; set; }

        public IList<string> Sources { get; set; }

        #endregion
    }
}