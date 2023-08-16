using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Infrastructure.Data;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Infrastructure.Repositories
{
    /// <summary>
    /// Repository Class to work with the Database.
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Constructor with DI to get the Database context.
        /// </summary>
        /// <param name="context">Using DI to get the context.</param>
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method to add a Match Entity in the Database.
        /// </summary>
        /// <param name="match">Match Entity.</param>
        public async Task AddMatch(Match match)
        {
            await this.context.Matches.AddAsync(match);
            await this.context.SaveChangesAsync();
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
        public async Task DeleteMatch(Guid id)
        {
            var match = await this.context.Matches.FindAsync(id);

            if (match != null)
            {
                return;
            }

            match.IsDeleted = true;

            await this.context.SaveChangesAsync();
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

        /// <summary>
        /// Method to find a certain Player in the Database.
        /// </summary>
        /// <param name="id">Identificator to find the Player Entity.</param>
        /// <returns>Player Entity.</returns>
        public async Task<Match> GetMatch(Guid id)
        {
            return await this.context.Matches.FindAsync(id);
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
        /// Method to get all Player's matches.
        /// </summary>
        /// <param name="id">Identificator to find the Player's Match Entities.</param>
        /// <returns>Collection of matches.</returns>
        public async Task<ICollection<Match>> GetMatchesByPlayerId(Guid id)
        {
            var matches = await this.context.Matches.Include(m => m.Players).AsNoTracking().ToListAsync();

            return matches.Where(m => m.Players.Where(p => p.Id == id).ToList().Count() > 0).ToList();
        }
    }
}

