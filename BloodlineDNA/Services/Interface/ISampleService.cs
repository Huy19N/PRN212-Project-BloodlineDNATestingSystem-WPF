using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interface
{
    public interface ISampleService
    {
        public List<Sample> GetAllSamples();
        public Sample GetSampleById(int id);
        public bool AddSample(Sample sample);
        public bool DeleteSample(Sample sample);
        public bool UpdateSample(Sample sample);
    }
}
