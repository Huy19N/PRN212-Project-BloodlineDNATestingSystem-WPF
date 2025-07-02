using BusinessObjects;

namespace DataAccessLayer;

public class FeedbackDAO
{

    public List<Feedback> GetAllFeedbacks()
    {
        using var context = new GeneCareContext();
        return context.Feedbacks.ToList();
    }
    public bool CreateFeedback(Feedback feedback)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (feedback == null)
            {
                return false;
            }
            context.Feedbacks.Add(new Feedback
            {
                FeedbackId = feedback.FeedbackId,
                UserId = feedback.UserId,
                ServiceId = feedback.ServiceId,
                CreatedAt = feedback.CreatedAt,
                Comment = feedback.Comment,
                Rating = feedback.Rating
            });

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }

    }
    public bool UpdateFeedback(Feedback feedback)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (feedback == null)
            {
                return false;
            }

            var existingFeedback = context.Feedbacks.Find(feedback.FeedbackId);
            if (existingFeedback == null)
            {
                return false;
            }
            existingFeedback.UserId = feedback.UserId;
            existingFeedback.ServiceId = feedback.ServiceId;
            existingFeedback.CreatedAt = feedback.CreatedAt;
            existingFeedback.Comment = feedback.Comment;
            existingFeedback.Rating = feedback.Rating;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeleteFeedbackById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var feedback = context.Feedbacks.Find(id);
            if (feedback == null) return false;
            context.Feedbacks.Remove(feedback);

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
