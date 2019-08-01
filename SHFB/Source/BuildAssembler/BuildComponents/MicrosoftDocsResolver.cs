using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Ddue.Tools.BuildComponent
{
    /// <summary>
    /// This is used to create urls to docs.microsoft.com using
    /// .NET Framework member IDs.
    /// </summary>
    public class MicrosoftDocsResolver
    {
        /// <summary>
        /// This is used to get or set the locale for the reference links
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>The default constructor creates a simple dictionary to hold the cached MSDN content IDs</remarks>
        public MicrosoftDocsResolver()
        {
            this.Locale = "en-us";
        }

        /// <summary>
        /// This is used to get the docs.microsoft.com URL for the given .NET Framework member ID
        /// </summary>
        /// <param name="id">The member ID to look up</param>
        /// <returns>The docs.microsoft.com URL for the member ID or null if not found</returns>
        public string GetMicrosoftDocsUrl(string id)
        {
            // TODO: Get these values from shfbproj.
            string dotnetType = "netframework";
            string dotnetVersion = "4.8";

            string baseUrl = "https://docs.microsoft.com";
            string url = $@"{baseUrl}/{this.Locale}/dotnet/api/{id}?view={dotnetType}-{dotnetVersion}";

            // Only checking for https. We could add an option to check for http as well.
            bool uriExists = Uri.TryCreate(url, UriKind.Absolute, out Uri result) && result.Scheme == Uri.UriSchemeHttps;

            if(uriExists)
            {
                return url;
            }

            return null;
        }
    }
}
