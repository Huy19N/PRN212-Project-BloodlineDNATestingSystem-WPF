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
    public class TestResultService : Interface.ITestResultService
    {
        ITestResultRepository testResultRepository;

        public TestResultService()
        {
            testResultRepository = new TestResultRepository();
        }
        public bool AddTestResult(TestResult testResult)
        {
            return testResultRepository.AddTestResult(testResult);
        }

        public bool DeleteTestResult(TestResult testResult)
        {
            return testResultRepository.DeleteTestResult(testResult);
        }

        public List<TestResult> GetAllTestResults()
        {
            return testResultRepository.GetAllTestResults();
        }

        public TestResult GetTestResultById(int id)
        {
            return testResultRepository.GetTestResultById(id);
        }

        public bool UpdateTestResult(TestResult testResult)
        {
            return testResultRepository.UpdateTestResult(testResult);
        }
    }
}
