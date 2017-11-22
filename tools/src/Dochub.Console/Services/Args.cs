using System.Linq;
using Dochub.Console.Constants;
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

            commands.Init = args.Contains(InputArgs.InitShort) || args.Contains(InputArgs.InitLong);
            commands.Build = args.Contains(InputArgs.BuildShort) || args.Contains(InputArgs.BuildLong);

            return commands;
        }

        #endregion
    }
}