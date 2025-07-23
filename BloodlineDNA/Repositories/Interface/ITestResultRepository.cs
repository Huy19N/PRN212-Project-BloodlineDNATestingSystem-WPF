using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface ITestResultRepository
    {
        public List<TestResult> GetAllTestResults();
        public TestResult GetTestResultById(int id);
        public bool AddTestResult(TestResult testResult);
        public bool DeleteTestResult(TestResult testResult);
        public bool UpdateTestResult(TestResult testResult);

    }
}
