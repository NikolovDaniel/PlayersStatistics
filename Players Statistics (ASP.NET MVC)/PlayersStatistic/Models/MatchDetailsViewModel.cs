using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PlayersStatistic.Models
{
	public class MatchDetailsViewModel
	{
        [Comment("Identificator for the entity.")]
        public Guid Id { get; set; }
      
        [Comment("Match date.")]
        public DateTime Date { get; set; }

        [Comment("Name of the winner of the match.")]
        public string Winner { get; set; } = null!;

        [Comment("Collection of the players participating in the match.")]
        public ICollection<PlayerViewModel> Players { get; set; } = null!;
    }
}

