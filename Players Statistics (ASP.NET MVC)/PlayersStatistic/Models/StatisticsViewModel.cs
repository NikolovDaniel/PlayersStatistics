using System;
namespace PlayersStatistic.Models
{
    public class StatisticsViewModel
    {
        public ICollection<PlayerViewModel> Players { get; set; } = null!;
        public ICollection<PlayerViewModel> BestPlayers { get; set; } = null!;
    }
}

