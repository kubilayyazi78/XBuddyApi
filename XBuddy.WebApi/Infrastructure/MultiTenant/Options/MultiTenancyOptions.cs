namespace XBuddy.WebApi.Infrastructure.MultiTenant.Options
{
    public class MultiTenancyOptions
    {
        internal bool InternalUseCookieResolver { get; private set; }
        internal bool InternalUseHeaderResolver { get; private set; }
        internal bool InternalUseQueryStringResolver { get; private set; }
        internal bool InternalUseRouteResolver { get; private set; }

        public MultiTenancyOptions UseCookieResolver()
        {
            InternalUseCookieResolver = true;
            return this;
        }
        public MultiTenancyOptions UseHeaderResolver()
        {
            InternalUseHeaderResolver = true;
            return this;
        }
        public MultiTenancyOptions UseQueryStringResolver()
        {
            InternalUseQueryStringResolver = true;
            return this;
        }
        public MultiTenancyOptions UseRouteResolver()
        {
            InternalUseRouteResolver = true;
            return this;
        }

        public bool AtLeastOneActive =>
            InternalUseCookieResolver |
            InternalUseHeaderResolver |
            InternalUseQueryStringResolver |
            InternalUseRouteResolver;
    }
}
