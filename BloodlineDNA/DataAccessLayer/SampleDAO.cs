using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class SampleDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();
            public List<Sample>? GetAllSamples()
            {
                return context.Samples.ToList();
            }
    
            public Sample GetSampleById(int id)
            {
                return context.Samples.FirstOrDefault(s => s.SampleId == id);
            }
    
            public bool AddSample(Sample sample)
            {
                context.Samples.Add(sample);
                return context.SaveChanges() > 0;
            }
    
            public bool DeleteSample(Sample sample)
            {
                context.Samples.Remove(sample);
                return context.SaveChanges() > 0;
            }
    
            public bool UpdateSample(Sample sample)
            {
                context.Samples.Update(sample);
                return context.SaveChanges() > 0;
            }
    
    }
}
