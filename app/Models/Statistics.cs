using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    public partial class Statistics
    {
        public Statistics()
        {
        }

        public string Id { get; set; }
        public string? GameId { get; set; }
        public long Score_team1 { get; set; }
        public long? Assists_team1 { get; set; }
        public long? Plus_minus_team1 { get; set; }
        public long? Penalties_team1 { get; set; }
        public long Score_team2 { get; set; }
        public long? Assists_team2 { get; set; }
        public long? Plus_minus_team2 { get; set; }
        public long? Penalties_team2 { get; set; }

        public string? Team1Id { get; set; }
        public string? Team2Id { get; set; }
        



        public virtual Team? Team1 { get; set; }
        public virtual Team? Team2 { get; set; }
        public virtual Game? Game { get; set; }


    }
}
