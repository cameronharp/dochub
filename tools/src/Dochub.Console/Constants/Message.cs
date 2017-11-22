namespace Dochub.Console.Constants
{
    public static class Message
    {
        #region Properties

        #region Errors

        public static class Error
        {
            private const string PreFix = "**ERROR:";

            public static string NoSiteFolderOnBuild = $"{PreFix} Please run {InputArgs.InitShort} or {InputArgs.InitLong} first before trying to build.";
        }

        #endregion

        #region Warnings

        public static class Warning
        {
            private const string Prefix = "**WARNING:";

            public static string NotVaildArticleExtension =
                Prefix + " Article '{0}' has been skipped due tp not being a valid extension. Please only use .md files.";
        }

        #endregion

        #endregion
    }
}