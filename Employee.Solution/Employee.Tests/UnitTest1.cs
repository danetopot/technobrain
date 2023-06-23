using Employee.Service;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Data;

namespace Employee.Service.UnitTests
{
    [TestFixture]
    public class Tests
    {
        private EmployeeService employeeService;

        //public Tests(EmployeeService employeeService)
        //{
        //    this.employeeService = employeeService;
        //}

        [SetUp]
        public void Setup()
        {
            // TODO: Setup code to create a connection to the test database
            // and initialize the data access layer
            // 5 Records will be inserted by the SQL/SqlInsert.sql script

            employeeService = new EmployeeService();
            var result = employeeService.PopulateTable();
            Assert.That(result == 5);
        }

        [Test]
        public void TestUpdateEmployeeSalary()
        {
            // TODO: Write test cases to ensure that the UpdateEmployeeSalary
            employeeService = new EmployeeService();

            /* NB:
            1. All Employee Original Salaries when SetUp is done will be 100,000
            2. This Test Case will ALWAYS return 100,000
            3. See SqlInsert.sql for the Employees Salary Set Up
                */
            var result = employeeService.UpdateTable(1, 5000);
            Assert.That(result == 100000);

        }


        [TearDown]
        public void TearDown()
        {
            // TODO: Teardown code to clean up the test database 
            // 0 records should be returned after this operation
            var result = employeeService.DeleteTable();
            Assert.That(result == 0);
        }
    }
}