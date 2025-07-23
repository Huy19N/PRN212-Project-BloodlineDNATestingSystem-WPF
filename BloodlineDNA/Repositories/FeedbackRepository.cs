using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class FeedbackRepository : Interface.IFeedbackRepository
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

        public Feedback GetFeedbackById(int id)
        {
            return feedbackDAO.GetFeedbackById(id);
        }

        public List<Feedback> GetFeedbacksByUserId(int userId)
        {
            return feedbackDAO.GetFeedbacksByUserId(userId);
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            return feedbackDAO.UpdateFeedback(feedback);
        }
    }
}
