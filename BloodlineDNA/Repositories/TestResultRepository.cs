using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class TestResultRepository : Interface.ITestResultRepository
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

        public TestResult GetTestResultById(int id)
        {
            return testResultDAO.GetTestResultById(id);
        }

        public bool UpdateTestResult(TestResult testResult)
        {
            return testResultDAO.UpdateTestResult(testResult);
        }
    }
}
