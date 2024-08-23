using Microsoft.AspNetCore.Mvc;
using Keycloak.Integration.Example.Api.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Keycloak.Integration.Example.Api.Controllers.v1
{
    /// <summary>Game Controller</summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/")]
    public class GameController : ControllerBase
    {
        /// <summary>The list of games</summary>
        private readonly List<Game> _games =
        [
            new()
            {
                Id = 1,
                Name = "Darks Souls",
                Description = "Dark Souls is a 2011 action role-playing game developed by FromSoftware and published by Namco Bandai Games.",
                Genre = "Action RPG",
                Platform = "PlayStation 3, Xbox 360, Microsoft Windows",
                Publisher = "Namco Bandai Games",
                ReleaseDate = "September 22, 2011"
            },
            new()
            {
                Id = 2,
                Name = "Dark Souls II",
                Description = "Dark Souls II is a 2014 action role-playing game developed by FromSoftware and published by Bandai Namco Games.",
                Genre = "Action RPG",
                Platform = "PlayStation 3, Xbox 360, Microsoft Windows",
                Publisher = "Bandai Namco Games",
                ReleaseDate = "March 11, 2014"
            },
            new()
            {
                Id = 3,
                Name = "Dark Souls III",
                Description = "Dark Souls III is a 2016 action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment.",
                Genre = "Action RPG",
                Platform = "PlayStation 4, Xbox One, Microsoft Windows",
                Publisher = "Bandai Namco Entertainment",
                ReleaseDate = "April 12, 2016"
            },
            new()
            {
                Id = 4,
                Name = "The Legend of Zelda: Breath of the Wild",
                Description = "The Legend of Zelda: Breath of the Wild is an action-adventure game developed and published by Nintendo.",
                Genre = "Action-adventure",
                Platform = "Nintendo Switch, Wii U",
                Publisher = "Nintendo",
                ReleaseDate = "March 3, 2017"
            },
        ];

        /// <summary>Gets a list of games</summary>
        /// <returns>The list of games</returns>
        [HttpGet("games")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetGamesList()
        {
            return Ok(_games);
        }

        /// <summary>Gets a specific game by his id</summary>
        /// <param name="id">The game id</param>
        /// <returns>The game data</returns>
        [HttpGet("games/{id}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGameById([FromRoute] int id)
        {
            var game = _games.Find(game => game.Id == id);
            if (game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }
    }
}