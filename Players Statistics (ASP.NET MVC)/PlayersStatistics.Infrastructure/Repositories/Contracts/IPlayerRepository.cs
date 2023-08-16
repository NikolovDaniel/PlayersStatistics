using System;
using PlayersStatistics.Infrastructure.Models;

namespace PlayersStatistics.Infrastructure.Repositories.Contracts
{
	public interface IPlayerRepository
	{

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
        /// Method to get all Players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public Task<ICollection<Player>> GetAllPlayers();

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        public Task DeletePlayer(Guid id);
    }
}

