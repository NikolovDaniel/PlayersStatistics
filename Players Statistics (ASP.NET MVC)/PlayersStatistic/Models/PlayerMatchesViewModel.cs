using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PlayersStatistic.Models
{
	public class PlayerMatchesViewModel
	{
        [Comment("Identificator for the entity.")]
        public Guid Id { get; set; }

        [Comment("Name of the player.")]
        public string Name { get; set; } = null!;

        [Comment("Age of the player.")]
        public int Age { get; set; }

        [Comment("Height of the player.")]
        public int Height { get; set; }

        [Comment("The hand with which the player plays.")]
        public string Hand { get; set; } = null!;

        [Comment("Place of birth.")]
        public string BirthPlace { get; set; } = null!;

        [Comment("Description of the player.")]
        public string Description { get; set; } = null!;

        [Comment("The player's wins.")]
        public int Wins { get; set; }

        [Comment("The player's loses.")]
        public int Loses { get; set; }

        [Comment("The player's total winrate.")]
        public int Winrate { get; set; }

        [Comment("Total matches played.")]
        public int MatchesPlayed { get; set; }

        [Comment("Collection of matches in which the player has won.")]
        public ICollection<MatchDetailsViewModel> Matches { get; set; } = null!;
    }
}

