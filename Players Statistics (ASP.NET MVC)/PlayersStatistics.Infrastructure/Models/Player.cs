using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlayersStatistics.Infrastructure.Models
{
    public class Player
    {
        [Comment("Identificator for the entity.")]
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Number identificator.")]
        public int NumberId { get; set; }

        [Comment("Name of the player.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters.")]
        [Required]
        public string Name { get; set; } = null!;

        [Comment("Age of the player.")]
        [Range(6, 90, ErrorMessage = "Age must be between 6 and 90 years old.")]
        [Required]
        public int Age { get; set; }

        [Comment("Height of the player.")]
        [Range(100, 230, ErrorMessage = "Height must be between 100 and 230 cm.")]
        [Required]
        public int Height { get; set; }

        [Comment("The hand with which the player plays.")]
        [Required]
        public string Hand { get; set; } = null!;

        [Comment("Place of birth.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Birth place must be between 3 and 100 characters.")]
        [Required]
        public string BirthPlace { get; set; } = null!;

        [Comment("Description of the player.")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 250 characters.")]
        [Required]
        public string Description { get; set; } = null!;

        [Comment("The player's wins.")]
        public int Wins { get; set; }

        [Comment("The player's loses.")]
        public int Loses { get; set; }

        [Comment("The player's total winrate.")]
        public int Winrate { get; set; }

        [Comment("All matches played by the player.")]
        public ICollection<Match> Matches { get; set; } = null!;

        [Comment("Flag to delete the entity.")]
        public bool IsDeleted { get; set; } = false;
    }
}