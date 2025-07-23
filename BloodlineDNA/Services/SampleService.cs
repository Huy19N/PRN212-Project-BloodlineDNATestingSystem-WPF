using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class SampleService : Interface.ISampleService
    {
        ISampleRepository sampleRepository;

        public SampleService()
        {
            sampleRepository = new SampleRepository();
        }
        public bool AddSample(Sample sample)
        {
            return sampleRepository.AddSample(sample);
        }

        public bool DeleteSample(Sample sample)
        {
            return sampleRepository.DeleteSample(sample);
        }

        public List<Sample> GetAllSamples()
        {
            return sampleRepository.GetAllSamples();
        }

        public Sample GetSampleById(int id)
        {
            return sampleRepository.GetSampleById(id);
        }

        public bool UpdateSample(Sample sample)
        {
            return sampleRepository.UpdateSample(sample);
        }
    }
}
