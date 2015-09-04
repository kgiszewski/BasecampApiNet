using System;

namespace BasecampApiNet.Core
{
    internal class Constants
    {
        internal static string BASECAMP_URL = "https://basecamp.com/" + BasecampApiBase.AccountId + "/api/v{0}/{1}";

        internal static int MAX_RESULT_PER_PAGE = 25;
    }
}
