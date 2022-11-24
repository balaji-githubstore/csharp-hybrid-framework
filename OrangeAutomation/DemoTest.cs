using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//will be deleted
namespace OrangeAutomation
{
    /// <summary>
    /// will be deleted - not part of framework 
    /// </summary>
    public class DemoTest
    {

        [Test]
        public void ExtentReportDemo()
        {
            //report init - should runs only once in the before all [Test] 
            //[OneTimeSetup]
            ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\index.html");
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(reporter);

            //should run before each [Test] method - [Setup]
            ExtentTest test= extent.CreateTest("MyFirstTest");

            //run the [Test] method

            //should run after each [Test] method - [TearDown]
            test.Log(Status.Fail, "MyFirstTestCasePassed");

            //[OneTimeTearDown]
            //report flush - should run after execution of all [Test] 
            extent.Flush();

        }


        [Test]
        public void ReadExcel()
        {
            XLWorkbook book = new XLWorkbook("C:\\automation_work\\HybridFrameworkSln\\OrangeAutomation\\TestData\\orangehrm_data.xlsx");
            var sheet = book.Worksheet("InvalidLoginTest");

            var range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            //size of allDataSet object[] is based on number of testcase=(rowcount-1)
            object[] allDataSet = new object[rowCount - 1];

            for (int r = 2; r <= rowCount; r++)
            {
                //size of dataSet array is based on number of parameters = (columncount)
                string[] dataSet = new string[colCount];
                for (int c = 1; c <= colCount; c++)
                {
                    dataSet[c - 1] = range.Cell(r, c).GetString();
                }
                allDataSet[r - 2] = dataSet;
            }

            Console.WriteLine();

        }

        [Test]
        public void varAndDynamicType()
        {
            //var - type is decided during compile time
            var a = 10; //a is reserved for int 
            var b = "hello"; //b will be reserver for string 
            var c = 10.2;

            b = "world";
            a = 100;

            //dynamic - type is decided during run time
            dynamic d = 10.2; //double
            d = "hel"; //string
            d = 10; //int

        }



        public static object[] ValidLoginData()
        {
            //create dataSet object[] - 3 object[] - number of testcase
            //size of each dataSet object[] - number of arguments
            object[] dataSet1 = new object[2];
            dataSet1[0] = "peter";
            dataSet1[1] = "peter123";

            object[] dataSet2 = new object[2];
            dataSet2[0] = "paul";
            dataSet2[1] = "paul123";

            object[] dataSet3 = new object[2];
            dataSet3[0] = "mark";
            dataSet3[1] = "mark123";

            //add all dataset into one object[]
            //allDataSet - size depends on number of testcase
            object[] allDataSet = new object[3];
            allDataSet[0] = dataSet1;
            allDataSet[1] = dataSet2;
            allDataSet[2] = dataSet3;

            return allDataSet;
        }

        [Test, TestCaseSource(typeof(DemoTest), nameof(ValidLoginData))]
        public void DemoValidLogin(string username, string password)
        {
            Console.WriteLine("valid" + username + password);
        }
    }
}
