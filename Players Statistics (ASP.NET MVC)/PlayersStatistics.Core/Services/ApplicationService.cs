using System;
using PlayersStatistics.Core.Contracts;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Core.Services
{
    /// <summary>
    /// Service Class to work with the Repository.
    /// </summary>
	public class ApplicationService : IApplicationService
    {
        /// <summary>
        /// Repository.
        /// </summary>
        private readonly IRepository repository;

        /// <summary>
        /// Constructor with DI to get the Repository.
        /// </summary>
        /// <param name="repository">Using DI to get the Repository.</param>
        public ApplicationService(IRepository repository)
        {
            this.repository = repository;
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
        /// Method to find a certain Match in the Database..
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        /// <returns>Match Entity.</returns>
        public async Task AddPlayer(Player player)
        {
            await this.repository.AddPlayer(player);
        }

        /// <summary>
        /// Method to add a Player Entity to the Database.
        /// </summary>
        /// <param name="player">Player Entity.</param>
        public async Task DeleteMatch(Guid id)
        {
            await this.repository.DeleteMatch(id);
        }

        /// <summary>
        /// Method to find a certain Player in the Database.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public async Task DeletePlayer(Guid id)
        {
            await this.repository.DeletePlayer(id);
        }

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
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
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="name">Identificator to find the Match Entity.</param>
        public Player GetPlayer(string name)
        {
            return this.repository.GetPlayer(name);
        }

        /// <summary>
        /// Method to get all Players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public async Task<ICollection<Player>> GetAllPlayers()
        {
            return await this.repository.GetAllPlayers();
        }

        /// <summary>
        /// Method to find a certain Player in the Database by Id.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public async Task<Player> GetPlayerById(Guid id)
        {
            return await this.repository.GetPlayerById(id);
        }
    }
}

