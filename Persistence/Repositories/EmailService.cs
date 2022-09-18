using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmailService : BaseRepository<SentEmailsForUsers>, IEmailService
    {
        readonly IConfiguration _configuration;
        public EmailService(IConfiguration Configuration, ApplicationDbContext applicationDb) : base(applicationDb)
        {
            _configuration = Configuration;
        }
        public bool SendEmail(string Email, Movie movie)
        {
            var Msg = new MailMessage();
            var Smtp = new SmtpClient();

            Msg.From = new MailAddress("nodariginturi8@gmail.com");
            Msg.To.Add(Email);
            Msg.Subject = "Best rated film from your watchlist";
            Msg.Body = $"Title: {movie.Title}\n {movie.Rating}\n {(movie.Image)}\n{movie.Description}";

            Smtp.Port = 587;
            Smtp.Host = "smtp.gmail.com";
            Smtp.EnableSsl = true;
            Smtp.UseDefaultCredentials = false;
            Smtp.Credentials = new NetworkCredential(_configuration["FromEmail"], _configuration["FromEmailPassword"]);
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Send(Msg);
            return true;
        }

        public async Task<SentEmailsForUsers> GetSentEmailToUsers(int UserId)
        {
            return await _dbContext.SentEmailsForUsers.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
        }

        public async Task UpdateEmailSentDate(int userId)
        {
            var emailData = await _dbContext.SentEmailsForUsers.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            emailData.LastSentDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }
    }
}
