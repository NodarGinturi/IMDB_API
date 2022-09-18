using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SuggesionMovies : ISuggestedMovieRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public SuggesionMovies(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<bool> SendUserSuggestedEmail()
        {
            var CurrentTime = DateTime.Now;
            var users = await _unitOfWork.MovieRepository.GetAllUsersAsync();
            if (CurrentTime.Hour == 19 && CurrentTime.Minute == 30 && CurrentTime.DayOfWeek == DayOfWeek.Sunday)
            {
                foreach (var user in users)
                {
                    var sentSuggestedEmail = await _unitOfWork.EmailService.GetSentEmailToUsers(user.Id);
                    if (sentSuggestedEmail.LastSentDate.Year != DateTime.Now.Year && sentSuggestedEmail.LastSentDate.Month != DateTime.Now.Month)
                    {
                        var watchLists = (await _unitOfWork.WatchListRepository.WatchedListAsync(user.Id)).ToList().Where(x => x.IsWatched == false).OrderByDescending(x=>x.Rating);

                        if (watchLists.Count() > 2)
                        {
                            foreach (var watchList in watchLists)
                            {
                                var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(watchList.MovieId);

                                await Task.Run(() => _emailService.SendEmail(user.Email,movie));
                                
                                await _unitOfWork.EmailService.UpdateEmailSentDate(user.Id);
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
