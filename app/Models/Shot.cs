using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace curs.Models
{
    public partial class Shot
    {
        public Shot()
        {
        }
        public string Id { get; set; }
        public string Time { get; set; }
        public string? Type { get; set; }
        public string? ScorerId { get; set; }
        public string? Distance { get; set; }
        public string? GameId { get; set; }

        public virtual Player? Player { get; set; }
        public virtual Game? Game { get; set; }

    }
}
