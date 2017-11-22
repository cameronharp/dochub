using System.Collections.Generic;

namespace Dochub.Console.Models
{
    /// <summary>
    /// Configuration created at time of build. This configuration is used by the UI templates to dynamically generate the UI elements. 
    /// </summary>
    public class BuildConfiguration : BaseConfiguration
    {
        #region Properties

        /// <summary>
        /// The collection of configured topics.
        /// </summary>
        public IList<TopicConfiguration> Topics { get; set; } = new List<TopicConfiguration>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BuildConfiguration()
        {
            
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="obj">The object to copy.</param>
        public BuildConfiguration(BaseConfiguration obj)
        {
            SiteTitle = obj?.SiteTitle;
            LandingPageHeader = obj?.LandingPageHeader;
        }

        #endregion
    }
}