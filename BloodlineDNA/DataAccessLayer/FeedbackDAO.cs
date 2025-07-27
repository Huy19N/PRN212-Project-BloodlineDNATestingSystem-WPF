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
    
    }
}

