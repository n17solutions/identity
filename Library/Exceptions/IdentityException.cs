using System;
using AspNet.Security.OpenIdConnect.Primitives;

namespace N17Solutions.Identity.Library.Exceptions
{
    public class IdentityException : Exception
    {
        /// <summary>
        /// The response to return based on the given exception
        /// </summary>
        public OpenIdConnectResponse Response { get; set; }

        public IdentityException(string error, string message) : base(message)
        {
            Response = new OpenIdConnectResponse
            {
                Error = error,
                ErrorDescription = message
            };
        }
    }
}