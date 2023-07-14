using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AuthressStarterKit.Controllers;

/// <summary>
/// An example resource for this starter kit. Replace this DTO with one that matches your application needs
/// </summary>
[DataContract]
public class ExampleResource
{
    /// <summary>
    /// Gets or Sets ResourceId
    /// </summary>
    [DataMember(Name = "resourceId", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "resourceId")]
    public string? ResourceId { get; set; }
}
