using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Penguin.Web.Testing;

namespace Penguin.Web.DependencyInjection
{
    /// <summary>
    /// Generates a new PerRequestScope for web request scoped DI
    /// </summary>
    public class PerRequestScopeFactory : IServiceScopeFactory
    {
        #region Constructors

        /// <summary>
        /// Constructs a new instance of this factory
        /// </summary>
        public PerRequestScopeFactory()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns a Dummy request scope for use in unit testing, with mock objects representing things like Session
        /// </summary>
        /// <returns>A Dummy request scope for use in unit testing, with mock objects representing things like Session</returns>
        public static PerRequestServiceScope CreateDummy()
        {
            PerRequestServiceScope ServiceScope = new PerRequestServiceScope();
            DefaultHttpContext context = new DefaultHttpContext
            {
                Session = new MockHttpSession()
            };
            ServiceScope.RequestProvider.Add(context);
            context.RequestServices = ServiceScope.ServiceProvider;
            return ServiceScope;
        }

        /// <summary>
        /// Constructs a new Request based service scope
        /// </summary>
        /// <returns>A new Request based service scope</returns>
        public IServiceScope CreateScope()
        {
            return new PerRequestServiceScope();
        }

        #endregion Methods
    }
}