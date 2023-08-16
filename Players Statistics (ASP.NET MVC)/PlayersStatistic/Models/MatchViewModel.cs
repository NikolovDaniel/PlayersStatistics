using System;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace PlayersStatistic.Models
{
    public class MatchViewModel
    {
        public MatchViewModel()
        {
            this.Players = new List<SelectPlayerViewModel>();
        }

        [Comment("Identificator for the entity.")]
        public Guid Id { get; set; }

        [Comment("Sets won by player one.")]
        [Required]
        public int PlayerOneSets { get; set; }

        [Comment("Sets won by player two.")]
        [Required]
        public int PlayerTwoSets { get; set; }

        [Comment("Winner sets.")]
        public int WinnerSets { get; set; }

        [Comment("Loser sets.")]
        public int LoserSets { get; set; }

        [Comment("Player identificator.")]
        public Guid PlayerOneId { get; set; }

        [Comment("Player identificator.")]
        public Guid PlayerTwoId { get; set; }

        [Comment("Duration of the match.")]
        [Required]
        [Range(10, 180, ErrorMessage = "Duration must be between 10 and 180 minutes!")]
        public int Duration { get; set; }

        [Comment("Date of when the match has been played.")]
        [Required]
        public DateTime Date { get; set; }

        [Comment("Location where the match has been played.")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location name must be between 3 and 50 characters!")]
        public string Location { get; set; } = null!;

        [Comment("Name of the winner of the match.")]
        public string Winner { get; set; } = null!;

        [Comment("Collection of Players availale.")]
        public ICollection<SelectPlayerViewModel> Players { get; set; } = null!;
    }
}

