using Dochub.Console.Models;

namespace Dochub.Console.Services
{
    public class Args
    {
        #region Fields

        private static Args _instance;

        #endregion

        #region Properties

        public static Args Instance => _instance ?? (_instance = new Args());

        #endregion

        #region Constructor

        private Args()
        {
            
        }

        #endregion

        #region Methods

        public static Commands GetCommands(string[] args)
        {
            return null;
        }

        #endregion
    }
}