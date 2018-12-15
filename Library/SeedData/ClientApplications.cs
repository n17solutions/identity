using System.Collections;
using System.Collections.Generic;
using OpenIddict.Abstractions;

namespace N17Solutions.Identity.Library.SeedData
{
    public class ClientApplications : IEnumerable<OpenIddictApplicationDescriptor>
    {
        public IEnumerator<OpenIddictApplicationDescriptor> GetEnumerator()
        {
            #region Identity

            yield return new OpenIddictApplicationDescriptor
            {
                ClientId = "98bc54dd-5816-42af-ae33-cd6bd1a1afac",
                ClientSecret = "aRARHLsEW^*pGl3#uoZHurXVEvMK1yKtEu£NSKnAli3CW*4etQsa%Av^4TeJPBrM",
                DisplayName = "N17Solutions Identity Service",
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.Endpoints.Introspection,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                    OpenIddictConstants.Permissions.GrantTypes.Password
                }
            };

            #endregion
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}