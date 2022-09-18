using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int UserId{ get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual WatchList WatchList { get; set; }
    }
}
