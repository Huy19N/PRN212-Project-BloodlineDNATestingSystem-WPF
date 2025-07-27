using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        FeedbackDAO feedbackDAO = new FeedbackDAO();
        public bool AddFeedback(Feedback feedback)
        {
            return feedbackDAO.AddFeedback(feedback);
        }

        public bool DeleteFeedback(Feedback feedback)
        {
            return feedbackDAO.DeleteFeedback(feedback);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return feedbackDAO.GetAllFeedbacks();
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            return feedbackDAO.UpdateFeedback(feedback);
        }
    }
}
