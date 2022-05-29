using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();

            Stats1 = new HashSet<Statistics>();

            Stats2 = new HashSet<Statistics>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LeagueId { get; set; }
        public virtual League? League { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Statistics> Stats1 { get; set; }
        public virtual ICollection<Statistics> Stats2 { get; set; }

    }
}

