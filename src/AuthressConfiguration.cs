using System.Collections.Generic;
using System.Runtime.Serialization;

using Authress.SDK;
using Authress.SDK.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AuthressStarterKit;

/// <summary>
/// Configuration used to connect to Authress. Don't have an Authress account, get one at https://authress.io/app/#/signup
/// </summary>
public static class AuthressConfiguration
{
    /// <summary>
    /// IF USING AUTHRESS AUTHENTICATION
    /// Your custom domain specified in Authress configured to sign your users JWTs. This is used for Authress Authentication.
    /// * For Production this must be switched to your custom domain, for development the login.authress.io domain can be used.
    /// * This url is set in your Authress account: https://authress.io/app/#/api?route=overview
    /// * A custom URL can be configured in the custom domain settings: https://authress.io/app/#/settings?focus=domain
    /// ELSE
    /// * Set this to the relevant issuer from your third party
    /// </summary>
    public const string AuthenticationProviderOAuthIssuerUrl = "login.authress.io";

    /// <summary>
    /// The URL used to connect to Authress. If you use a custom domain then this can be the custom domain.
    /// * This url is set in your Authress account. API Host: https://authress.io/app/#/api?route=overview
    /// </summary>
    public const string AuthressApiHostUrl = "https://ACCOUNT_ID.api-eu-west.authress.io";

    /// <summary>
    /// Your Authress Service Client Access Key, generate one at https://authress.io/app/#/settings?focus=clients
    /// * Or see the documentation here: https://authress.io/knowledge-base/docs/authorization/service-clients
    /// </summary>
    public const string ServiceClientAccessKey = "sc_aaa.acc-001.secret";

    public static AuthressClient? authressClient = null;

    public static AuthressClient GetAuthressClient() {
        if (authressClient != null)
        {
            return authressClient;
        }

        var clientSettings = new HttpClientSettings { ApiBasePath = AuthressApiHostUrl };
        authressClient = new AuthressClient(new AuthressClientTokenProvider(ServiceClientAccessKey, null), clientSettings);
        return authressClient;
    }

    public static void VerifyConfiguration()
    {
        if (string.IsNullOrEmpty(AuthressConfiguration.AuthenticationProviderOAuthIssuerUrl)) {
            throw new Exception("The AuthressConfiguration for your Custom Domain must be specified. The URL used to verify authentication tokens. This url is set in your Authress account: https://authress.io/app/#/api?route=overview * A custom URL can be configured in the custom domain settings: https://authress.io/app/#/settings?focus=domain");
        }

        if (string.IsNullOrEmpty(AuthressConfiguration.AuthressApiHostUrl) || AuthressConfiguration.AuthressApiHostUrl.Contains("ACCOUNT_ID")) {
            throw new Exception("The AuthressConfiguration for your API Host URL must be specified. The URL used to connect to Authress. This url is set in your Authress account: https://authress.io/app/#/api?route=overview");
        }

        if (string.IsNullOrEmpty(AuthressConfiguration.ServiceClientAccessKey) || AuthressConfiguration.ServiceClientAccessKey.Contains(".secret")) {
            throw new Exception("The AuthressConfiguration Service Client Access Key must be specified to interact with Authress. Generate an access key at: https://authress.io/app/#/settings?focus=clients");
        }
    }
}
