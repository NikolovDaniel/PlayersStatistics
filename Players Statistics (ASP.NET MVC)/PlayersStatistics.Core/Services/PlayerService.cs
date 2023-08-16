using System;
using PlayersStatistics.Core.Contracts;
using PlayersStatistics.Infrastructure.Data;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Core.Services
{
    /// <summary>
    /// Player Service Class to work with the Repository.
    /// </summary>
    public class PlayerService : IPlayerService
	{
        /// <summary>
        /// Player Repository Interface.
        /// </summary>
        private readonly IPlayerRepository repository;

        /// <summary>
        /// Constructor with DI to get the Repository.
        /// </summary>
        /// <param name="repo">Using DI to get the Repository.</param>
        public PlayerService(IPlayerRepository repo)
		{
            this.repository = repo;
		}

        /// <summary>
        /// Method to add a Player Entity in the Database.
        /// </summary>
        /// <param name="player">Player Entity.</param>
        public async Task AddPlayer(Player player)
        {
            await this.repository.AddPlayer(player);
        }

        /// <summary>
        /// Method to find a certain Player in the Database by Name.
        /// </summary>
        /// <param name="name">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public Player GetPlayer(string name)
        {
            return this.repository.GetPlayer(name);
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

        /// <summary>
        /// Method to get all Players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public async Task<ICollection<Player>> GetAllPlayers()
        {
            return await this.repository.GetAllPlayers();
        }

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        public async Task DeletePlayer(Guid id)
        {
            await this.repository.DeletePlayer(id);
        }
    }
}

