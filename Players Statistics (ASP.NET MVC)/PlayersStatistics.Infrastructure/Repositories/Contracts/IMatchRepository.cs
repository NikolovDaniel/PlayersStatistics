using System;
using PlayersStatistics.Infrastructure.Models;

namespace PlayersStatistics.Infrastructure.Repositories.Contracts
{
	public interface IMatchRepository
	{
        /// <summary>
        /// Method to add a Match Entity in the Database.
        /// </summary>
        /// <param name="match">Match Entity.</param>
        public Task AddMatch(Match match);

        /// <summary>
        /// Method to find certain Match in the Database.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        /// <returns>Match Entity.</returns>
        public Task<Match> GetMatch(Guid id);

        /// <summary>
        /// Method to get all Player's matches.
        /// </summary>
        /// <param name="id">Identificator to find the Player's Match Entities.</param>
        /// <returns>Collection of matches.</returns>
        public Task<ICollection<Match>> GetMatchesByPlayerId(Guid id);

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        public Task DeleteMatch(Guid id);

        /// <summary>
        /// Method to find certain Match with its players in the Database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Match Entity with the Players.</returns>
        public Task<Match> GetMatchWithPlayers(Guid id);
    }
}

