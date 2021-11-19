namespace RedirectMiddleware
{
    public interface IRedirectTargetRegistry
    {
        string FindDestinationRootAddress(string sourceRootAddress);
    }
}
