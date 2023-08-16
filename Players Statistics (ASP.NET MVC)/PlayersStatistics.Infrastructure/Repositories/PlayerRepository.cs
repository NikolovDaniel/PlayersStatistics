using System;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Infrastructure.Data;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Constructor with DI to get the Database context.
        /// </summary>
        /// <param name="context">Using DI to get the context.</param>
        public PlayerRepository (ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method to add a Player Entity in the Database.
        /// </summary>
        /// <param name="player">Player Entity.</param>
        public async Task AddPlayer(Player player)
        {
            await this.context.Players.AddAsync(player);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Method to find a certain Player in the Database by Name.
        /// </summary>
        /// <param name="name">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public Player GetPlayer(string name)
        {
            return this.context.Players.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Method to find a certain Player in the Database by Id.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public async Task<Player> GetPlayerById(Guid id)
        {
            return await this.context.Players.FindAsync(id);
        }

        /// <summary>
        /// Method to get all Players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public async Task<ICollection<Player>> GetAllPlayers()
        {
            return await this.context.Players.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Method to set the IsDeleted Flag to true.
        /// </summary>
        /// <param name="id">Identificator to find the Match Entity.</param>
        public async Task DeletePlayer(Guid id)
        {
            var player = await this.context.Players.FindAsync(id);

            if (player != null)
            {
                return;
            }

            player.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }
    }
}

