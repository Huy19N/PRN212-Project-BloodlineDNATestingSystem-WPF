using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IFeedbackRepository
    {
        public List<Feedback> GetAllFeedbacks();
        public bool AddFeedback(Feedback feedback);
        public bool DeleteFeedback(Feedback feedback);
        public bool UpdateFeedback(Feedback feedback);
    }
}
