using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    [NotMapped]
    public partial class Player
    {
        public Player()
        {
            Shots = new HashSet<Shot>();
        }
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Position { get; set; }
        public string? TeamId { get; set; }

        public virtual Team? Team { get; set; }
        public virtual ICollection<Shot> Shots { get; set; }
    }
}
