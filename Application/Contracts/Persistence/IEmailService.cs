using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IEmailService : IAsyncRepository<SentEmailsForUsers>
    {
        bool SendEmail(string Email, Movie movie);
        Task<SentEmailsForUsers> GetSentEmailToUsers(int UserId);

        Task UpdateEmailSentDate(int userId);
    }
}
