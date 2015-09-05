using System.Collections.Generic;
using BasecampApiNet.Models;

namespace BasecampApiNet.Interfaces
{
    public interface IResponseCache
    {
        T Get<T>(string url);

        void ClearCache();

        int CacheCount();

        Dictionary<string, CacheWrapperModel> CacheDump();
    }
}
