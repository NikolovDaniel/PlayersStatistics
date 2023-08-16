using System;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Infrastructure.Data;
using PlayersStatistics.Infrastructure.Models;
using PlayersStatistics.Infrastructure.Repositories.Contracts;

namespace PlayersStatistics.Infrastructure.Repositories
{
	public class MatchRepository : IMatchRepository
	{
        /// <summary>
        /// Database context.
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Constructor with DI to get the Database context.
        /// </summary>
        /// <param name="context">Using DI to get the context.</param>
        public MatchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method to find certain Match with its players in the Database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Match Entity with the Players.</returns>
        public async Task<Match> GetMatchWithPlayers(Guid id)
        {
            var match = await context.Matches.Include("Players").FirstAsync(m => m.Id == id);

            return match;
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
        /// Method to get all Player's matches.
        /// </summary>
        /// <param name="id">Identificator to find the Player's Match Entities.</param>
        /// <returns>Collection of matches.</returns>
        public async Task<ICollection<Match>> GetMatchesByPlayerId(Guid id)
        {
            var matches = await this.context.Matches.Include("Players").AsNoTracking().ToListAsync();

            return matches.Where(m => m.Players.Where(p => p.Id == id).ToList().Count() > 0).ToList();
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
    }
}

