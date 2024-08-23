using System.Diagnostics.CodeAnalysis;

namespace Keycloak.Integration.Example.Api.Domain
{
    [ExcludeFromCodeCoverage]
    public class Game
    {
        /// <summary>The game id</summary>
        public int Id { get; set; }

        /// <summary>The game name</summary>
        public string Name { get; set; }

        /// <summary>The game description</summary>
        public string Description { get; set; }

        /// <summary>The game genre</summary>
        public string Genre { get; set; }

        /// <summary>The list of game platforms</summary>
        public List<Platform> Platforms { get; set; }

        /// <summary>The game publisher</summary>
        public string Publisher { get; set; }

        /// <summary>The game release date</summary>
        public string ReleaseDate { get; set; }
    }
}