using System;
using PlayersStatistics.Infrastructure.Models;

namespace PlayersStatistics.Infrastructure.Repositories.Contracts
{
    /// <summary>
    /// Interface of the Repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Method to add a Match Entity in the Database.
        /// </summary>
        /// <param name="match">Match Entity.</param>
        public Task AddMatch(Match match);

        /// <summary>
        /// Method to get all Players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public Task<ICollection<Player>> GetAllPlayers();

        /// <summary>
        /// Method to find a certain Match in the Database.
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
        /// Method to add a Player Entity in the Database.
        /// </summary>
        /// <param name="player">Player Entity.</param>
        public Task AddPlayer(Player player);

        /// <summary>
        /// Method to find a certain Player in the Database by Name.
        /// </summary>
        /// <param name="name">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public Player GetPlayer(string name);

        /// <summary>
        /// Method to find a certain Player in the Database by Id.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public Task<Player> GetPlayerById(Guid id);

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        public Task DeletePlayer(Guid id);

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        public Task DeleteMatch(Guid id);
    }
}

