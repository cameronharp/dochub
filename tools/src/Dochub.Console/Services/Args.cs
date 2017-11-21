using System.Linq;
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
            var commands = new Commands();

            if (args == null || args.Length == 0)
            {
                return commands;
            }

            commands.Init = args.Contains("-i") || args.Contains("-init");

            return commands;
        }

        #endregion
    }
}