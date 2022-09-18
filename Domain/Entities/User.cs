using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int SentEmailForUserId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual SentEmailsForUsers SentEmailsForUsers { get; set; }
        public virtual WatchList WatchList { get; set; }
    }
}
