using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasecampApiNet.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<T> AsListModel<T>(this string input)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(input);
        }

        public static T AsModel<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
