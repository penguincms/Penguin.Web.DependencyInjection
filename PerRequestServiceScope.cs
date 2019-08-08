using Penguin.DependencyInjection.ServiceScopes;

namespace Penguin.Web.DependencyInjection
{
    /// <summary>
    /// All instances in this scope are disposed when the scope is disposed. May represent a single web request, or be used in other ways. All instances are Engine instance specific
    /// </summary>
    public class PerRequestServiceScope : ScopedServiceScope
    {
    }
}