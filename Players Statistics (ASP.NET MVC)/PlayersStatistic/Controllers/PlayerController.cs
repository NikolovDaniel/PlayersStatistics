using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayersStatistic.Models;
using PlayersStatistics.Core.Contracts;
using PlayersStatistics.Infrastructure.Models;
using static System.Formats.Asn1.AsnWriter;

namespace PlayersStatistic.Controllers
{
    /// <summary>
    /// Provides functionality to the /Player/ route.
    /// </summary>
    public class PlayerController : Controller
    {
        /// <summary>
        /// Application Services.
        /// </summary>
        private readonly IPlayerService playerService;
        private readonly IMatchService matchService;

        /// <summary>
        /// Constructor using DI to get Application Services.
        /// </summary>
        /// <param name="playerService">Player service.</param>
        /// <param name="matchService">Match service.</param>
        public PlayerController(IPlayerService playerService, IMatchService matchService)
        {
            this.playerService = playerService;
            this.matchService = matchService;
        }

        /// <summary>
        /// Displays Player/All page with all available Players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            // Gets all Player Entities.
            var players = await this.playerService.GetAllPlayers();

            // Check if there are any Players in the DB.
            if (players == null)
            {
                return View(new StatisticsViewModel());
            }

            // Using DTO to change the shape of the data send to the user.
            var allPlayers = players
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    NumberId = p.NumberId,
                    Name = p.Name,
                    Age = p.Age,
                    Height = p.Height,
                    Hand = p.Hand,
                    Description = p.Description,
                    Wins = p.Wins,
                    Loses = p.Loses,
                    Winrate = p.Winrate,
                    MatchesPlayed = p.Wins + p.Loses
                })
                .OrderByDescending(p => p.MatchesPlayed)
                .ToList();

            // Selects the 3 players with the highest winrate.
            var bestPlayers = allPlayers.OrderByDescending(p => p.Winrate).Take(4).ToList();

            // Define the model for the view.
            var model = new StatisticsViewModel()
            {
                Players = allPlayers,
                BestPlayers = bestPlayers
            };

            return View(model);
        }

        /// <summary>
        /// Display a Player/Details/Id page.
        /// </summary>
        /// <param name="id">Guid id used to retrieve a Player.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            // Finds the Player and its Matches.
            var player = await this.playerService.GetPlayerById(id);
            var matches = await this.matchService.GetMatchesByPlayerId(id);

            // Using DTO to change the shape of the data send to the user.
            var model = new PlayerMatchesViewModel()
            {
                Name = player.Name,
                Age = player.Age,
                Height = player.Height,
                Hand = player.Hand,
                BirthPlace = player.BirthPlace,
                Description = player.Description,
                Wins = player.Wins,
                Loses = player.Loses,
                Winrate = player.Winrate,
                MatchesPlayed = player.Wins + player.Loses,
                Matches = matches
                .Select(m => new MatchDetailsViewModel()
                {
                    Id = m.Id,
                    Winner = m.Winner,
                    Date = m.Date,
                    Players = m.Players
                    .Select(p => new PlayerViewModel()
                    {
                        Name = p.Name
                    })
                    .ToList()
                })
                .ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Displays a Create page.
        /// </summary>
        /// <returns>A Create page with model used for form submitting.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            //  Model used for retrieving data through the form.
            PlayerViewModel model = new PlayerViewModel();

            return View(model);
        }

        /// <summary>
        /// Adds new Player Entity, when the User submits the form with correct data.
        /// </summary>
        /// <param name="model">PlayerViewModel received when User submits the form.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(PlayerViewModel model)
        {
            // Creates new Player Entity using model data.
            var player = new Player()
            {
                Name = model.Name,
                Age = model.Age,
                Height = model.Height,
                Hand = model.Hand,
                BirthPlace = model.BirthPlace,
                Description = model.Description,
                IsDeleted = false
            };

            // Adds the Player to the DB.
            await playerService.AddPlayer(player);

            // Redirect to Player/All page.
            return RedirectToAction(nameof(All));
        }
    }
}

