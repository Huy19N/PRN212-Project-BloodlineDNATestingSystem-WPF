using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class FeedbackDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
            public List<Feedback> GetAllFeedbacks()
            {
                return context.Feedbacks.ToList();
            }
    
            public Feedback GetFeedbackById(int id)
            {
                return context.Feedbacks.FirstOrDefault(f => f.FeedbackId == id);
            }
    
            public bool AddFeedback(Feedback feedback)
            {
                context.Feedbacks.Add(feedback);
                return context.SaveChanges() > 0;
            }
    
            public bool DeleteFeedback(Feedback feedback)
            {
                context.Feedbacks.Remove(feedback);
                return context.SaveChanges() > 0;
            }
    
            public bool UpdateFeedback(Feedback feedback)
            {
                context.Feedbacks.Update(feedback);
                return context.SaveChanges() > 0;
            }
    
            public List<Feedback> GetFeedbacksByUserId(int userId)
            {
                return context.Feedbacks
                    .Where(f => f.UserId == userId)
                    .ToList();
        }
    }
}
