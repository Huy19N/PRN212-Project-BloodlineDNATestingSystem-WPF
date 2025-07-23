using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class SampleRepository : Interface.ISampleRepository
    {
        SampleDAO sampleDAO = new SampleDAO();
        public bool AddSample(Sample sample)
        {
            return sampleDAO.AddSample(sample);
        }

        public bool DeleteSample(Sample sample)
        {
            return sampleDAO.DeleteSample(sample);
        }

        public List<Sample> GetAllSamples()
        {
            return sampleDAO.GetAllSamples();
        }

        public Sample GetSampleById(int id)
        {
            return sampleDAO.GetSampleById(id);
        }

        public bool UpdateSample(Sample sample)
        {
            return sampleDAO.UpdateSample(sample);
        }
    }
}
