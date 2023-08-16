using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace PlayersStatistics.Infrastructure.Models
{
    public class Match
    {
        public Match()
        {
            this.Players = new List<Player>();
        }

        [Comment("Identificator for the entity.")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Sets won by player one.")]
        [Required]
        public int PlayerOneSets { get; set; }

        [Comment("Sets won by player two.")]
        [Required]
        public int PlayerTwoSets { get; set; }

        [Comment("Duration of the match.")]
        [Required]
        public int Duration { get; set; }

        [Comment("Date of when the match has been played.")]
        [Required]
        public DateTime Date { get; set; }

        [Comment("Location where the match has been played.")]
        [Required]
        public string Location { get; set; } = null!;

        [Comment("Name of the winner of the match.")]
        [Required]
        public string Winner { get; set; } = null!;

        [Comment("Flag to delete the entity.")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Collection of players which participate in the match.")]
        public ICollection<Player> Players { get; set; } = null!;
    }
}

