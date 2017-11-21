using System;
using System.IO;

namespace Dochub.Console.Utilities
{
    public static class FileUtility
    {
        #region Methods

        public static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"The file '{path}' does not exist.");
            }
        }

        #endregion
    }
}