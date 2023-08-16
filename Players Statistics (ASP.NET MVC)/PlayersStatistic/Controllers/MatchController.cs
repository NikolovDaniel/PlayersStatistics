using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PlayersStatistic.Models;
using PlayersStatistics.Core.Contracts;
using PlayersStatistics.Infrastructure.Models;

namespace PlayersStatistic.Controllers
{
    /// <summary>
    /// Provides functionality to the /Match/ route.
    /// </summary>
    public class MatchController : Controller
    {
        /// <summary>
        /// Application Services.
        /// </summary>
        private readonly IMatchService matchService;
        private readonly IPlayerService playerService;

        /// <summary>
        /// Constructor using DI to get Application Services.
        /// </summary>
        /// <param name="matchService">Match service.</param>
        /// <param name="playerService">Player service.</param>
        public MatchController(IMatchService matchService, IPlayerService playerService)
        {
            this.matchService = matchService;
            this.playerService = playerService;
        }

        /// <summary>
        /// Displays a Details page about particular match.
        /// </summary>
        /// <param name="id">Identificator to find the correct Match Entity.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var match = await matchService.GetMatchWithPlayers(id);

            var model = new MatchViewModel()
            {
                PlayerOneSets = match.PlayerOneSets,
                PlayerTwoSets = match.PlayerTwoSets,
                WinnerSets = match.PlayerOneSets > match.PlayerTwoSets ? match.PlayerOneSets : match.PlayerTwoSets,
                LoserSets = match.PlayerOneSets > match.PlayerTwoSets ? match.PlayerTwoSets : match.PlayerOneSets,
                Winner = match.Winner,
                Location = match.Location,
                Date = match.Date,
                Duration = match.Duration,
                Players = match.Players
                .Select(p => new SelectPlayerViewModel()
                {
                    Name = p.Name
                })
                .ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Displays an Add page.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            MatchViewModel model = new MatchViewModel();

            // Gets all available Players.
            var players = await playerService.GetAllPlayers();

            // Using DTO to change the shape of the data send to the user.
            model.Players = players
                .Select(p => new SelectPlayerViewModel()
                {
                    Id = p.Id,
                    NumberId = p.NumberId,
                    Name = p.Name
                })
                .ToList();

            return View(model);
        }

        /// <summary>
        /// Adds new Match Entity, when the User submits the form with correct data.
        /// </summary>
        /// <param name="model">MatchViewModel received when User submits the form.</param>
        [HttpPost]
        public async Task<IActionResult> Create(MatchViewModel model)
        {
            // Check if User has submitted correct match score.
            if (model.PlayerOneSets == model.PlayerTwoSets)
            {
                return RedirectToAction("All", "Player");
            }

            // Check if User has submitted correct match score.
            if (model.PlayerOneSets != 2 && model.PlayerTwoSets != 2)
            {
                return RedirectToAction("All", "Player");
            }

            var playerOne = await playerService.GetPlayerById(model.PlayerOneId);
            var playerTwo = await playerService.GetPlayerById(model.PlayerTwoId);

            // Check if User has submitted correct Players.
            if (playerOne.NumberId == playerTwo.NumberId)
            {
                ModelState.AddModelError("", "Users should be different!");
                model.Players = new List<SelectPlayerViewModel>()
                {
                    new SelectPlayerViewModel {Id = playerOne.Id, NumberId = playerOne.NumberId, Name = playerOne.Name},
                    new SelectPlayerViewModel {Id = playerTwo.Id, NumberId = playerTwo.NumberId, Name = playerTwo.Name},
                };

                    return View(model);
            }

            ModelState.Remove("Id");
            ModelState.Remove("Winner");

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            // Defines who has won and who has lost.
            if (model.PlayerOneSets > model.PlayerTwoSets)
            {
                playerOne.Wins++;
                playerTwo.Loses++;
            }
            else
            {
                playerOne.Loses++;
                playerTwo.Wins++;
            }

            // Calculates Player One and Two winrates.
            double playerOneWinRate = (playerOne.Wins / (double)(playerOne.Wins + playerOne.Loses)) * 100;
            playerOne.Winrate = (int)playerOneWinRate;

            double playerTwoWinRate = (playerTwo.Wins / (double)(playerTwo.Wins + playerTwo.Loses)) * 100;
            playerTwo.Winrate = (int)playerTwoWinRate;

            // Create new Match Entity and saves it to the DB.
            Match match = new Match()
            {
                PlayerOneSets = model.PlayerOneSets,
                PlayerTwoSets = model.PlayerTwoSets,
                Location = model.Location,
                Duration = model.Duration,
                Date = model.Date,
                Winner = model.PlayerOneSets > model.PlayerTwoSets
                ? playerOne.Name
                : playerTwo.Name,
                Players = { playerOne, playerTwo },
                IsDeleted = false
            };

            await matchService.AddMatch(match);

            return RedirectToAction("All", "Player");
        }
    }
}

