using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AuthressStarterKit;

/// <summary>
/// Configuration used to connect to Authress. Don't have an Authress account, get one at https://authress.io/app/#/signup
/// </summary>
public static class AuthressConfiguration
{
    /// <summary>
    /// The URL used to connect to Authress. This url is set in your Authress account: https://authress.io/app/#/api?route=overview
    /// * A custom URL can be configured in the custom domain settings: https://authress.io/app/#/settings?focus=domain
    /// </summary>
    public const string CustomDomain = "https://login.company.com";
}
