using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class FeedbackService : IFeedbackService
    {
        IFeedbackRepository feedbackRepository;

        public FeedbackService()
        {
            feedbackRepository = new FeedbackRepository();
        }
        public bool AddFeedback(Feedback feedback)
        {
            return feedbackRepository.AddFeedback(feedback);
        }

        public bool DeleteFeedback(Feedback feedback)
        {
            return feedbackRepository.DeleteFeedback(feedback);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return feedbackRepository.GetAllFeedbacks();
        }


        public bool UpdateFeedback(Feedback feedback)
        {
            return feedbackRepository.UpdateFeedback(feedback);
        }
    }
}
