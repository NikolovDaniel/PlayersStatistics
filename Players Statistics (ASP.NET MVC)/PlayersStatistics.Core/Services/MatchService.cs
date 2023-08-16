using System;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Core.Contracts;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Core.Services
{
    /// <summary>
    /// Service Class to work with the Repository.
    /// </summary>
    public class MatchService : IMatchService
	{
        /// <summary>
        /// Match Repository Interface.
        /// </summary>
        private readonly IMatchRepository repository;

        /// <summary>
        /// Constructor with DI to get the Repository.
        /// </summary>
        /// <param name="repo">Using DI to get the Repository.</param>
        public MatchService(IMatchRepository repo)
        {
            this.repository = repo;
        }


        /// <summary>
        /// Method to find certain Match with its players in the Database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Match> GetMatchWithPlayers(Guid id)
        {
            return await this.repository.GetMatchWithPlayers(id);
        }

        /// <summary>
        /// Method to add a Match Entity to the Database.
        /// </summary>
        /// <param name="match">Match Entity</param>
        public async Task AddMatch(Match match)
        {
            await this.repository.AddMatch(match);
        }

        /// <summary>
        /// Method to retrieve a single Match Entity using Identificator.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        public async Task<Match> GetMatch(Guid id)
        {
            return await this.repository.GetMatch(id);
        }

        /// <summary>
        /// Method to get all Player's matches.
        /// </summary>
        /// <param name="id">Identificator to find the Player's Match Entities.</param>
        /// <returns>Collection of matches.</returns>
        public async Task<ICollection<Match>> GetMatchesByPlayerId(Guid id)
        {
            return await this.repository.GetMatchesByPlayerId(id);
        }

        /// <summary>
        /// Method to delete a Mathc Entity using Delete Flag.
        /// </summary>
        /// <param name="id">Identificator for the Match Entity.</param>
        public async Task DeleteMatch(Guid id)
        {
            await this.repository.DeleteMatch(id);
        }
    }
}

