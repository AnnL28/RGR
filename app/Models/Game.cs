using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    public partial class Game
    {
        public Game()
        {
            Shots = new HashSet<Shot>();

            Stats = new HashSet<Statistics>();
        }
        public string Id { get; set; }
        public long GameN { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public virtual ICollection<Shot> Shots { get; set; }
        public virtual ICollection<Statistics> Stats { get; set; }

    }
}
