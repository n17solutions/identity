using AspNet.Security.OpenIdConnect.Primitives;

namespace N17Solutions.Identity.Library.Exceptions
{
    public class InvalidClientApplicationException : IdentityException
    {
        public InvalidClientApplicationException(string clientId) 
            : base(OpenIdConnectConstants.Errors.InvalidClient, $"The Client Application with identifier '{clientId}' could not be found.")
        {}
    }
}