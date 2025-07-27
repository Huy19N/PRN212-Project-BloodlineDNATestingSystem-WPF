using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        TestResultDAO testResultDAO = new TestResultDAO();
        public bool AddTestResult(TestResult testResult)
        {
            return testResultDAO.AddTestResult(testResult);
        }

        public bool DeleteTestResult(TestResult testResult)
        {
            return testResultDAO.DeleteTestResult(testResult);
        }

        public List<TestResult> GetAllTestResults()
        {
            return testResultDAO.GetAllTestResults();
        }

        public bool UpdateTestResult(TestResult testResult)
        {
            return testResultDAO.UpdateTestResult(testResult);
        }
    }
}
