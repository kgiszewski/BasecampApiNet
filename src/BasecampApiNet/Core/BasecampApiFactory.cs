namespace BasecampApiNet.Core
{
    public class BasecampApiFactory : BasecampApiFactoryBase
    {
        public override BasecampApiBase GetApi(string accountId, string username, string password)
        {
            return new BasecampApi(accountId, username, password);
        }
    }
}
