using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WatchList : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public decimal Rating { get; set; }
        public bool IsWatched { get; set; } = false;
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }

    }
}
