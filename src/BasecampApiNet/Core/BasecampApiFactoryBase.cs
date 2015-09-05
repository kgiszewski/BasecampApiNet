using BasecampApiNet.Interfaces;

namespace BasecampApiNet.Core
{
    public abstract class BasecampApiFactoryBase
    {
        public abstract BasecampApiBase GetApi(string accountId, string username, string password);
    }
}
