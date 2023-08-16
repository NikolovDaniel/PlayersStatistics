using System;
using Microsoft.EntityFrameworkCore;

namespace PlayersStatistic.Models
{
    public class SelectPlayerViewModel
    {
        [Comment("Identificator.")]
        public Guid Id { get; set; }

        [Comment("Player's name.")]
        public string Name { get; set; } = null!;

        [Comment("Number identificator to represent a unquie entity.")]
        public int NumberId { get; set; }

        [Comment("The Player's sets.")]
        public int Sets { get; set; }
    }
}

