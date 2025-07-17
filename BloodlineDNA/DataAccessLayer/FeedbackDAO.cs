using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FeedbackDAO
    {
        private readonly GeneCareContext _context;
        public FeedbackDAO()
        {
            _context = new GeneCareContext();
        }
        public FeedbackDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Feedback?> GetFeedbackByIdAsync(int feedbackId)
        {
            try
            {
                return await _context.Feedbacks.FindAsync(feedbackId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the feedback.", ex);
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            try
            {
                return await _context.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all feedback.", ex);
            }
        }

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback)
        {
            try
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the feedback.", ex);
            }
        }

        public async Task<Feedback> UpdateFeedbackAsync(Feedback feedback)
        {
            try
            {
                _context.Entry(feedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the feedback.", ex);
            }
        }

        public async Task<bool> DeleteFeedbackAsync(int feedbackId)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(feedbackId);
                if (feedback == null)
                {
                    return false; // Feedback not found
                }
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the feedback.", ex);
            }
        }
    }
}
