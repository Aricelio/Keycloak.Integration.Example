using System.Diagnostics.CodeAnalysis;

namespace Keycloak.Integration.Example.Api.Domain
{
    [ExcludeFromCodeCoverage]
    public class Platform
    {
        /// <summary>The platform id</summary>
        public int Id { get; set; }

        /// <summary>The platform name</summary>
        public string? Name { get; set; }
    }
}