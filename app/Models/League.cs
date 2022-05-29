using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    public partial class League
    {
        public League()
        {
            Teams = new HashSet<Team>();
        }
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}
