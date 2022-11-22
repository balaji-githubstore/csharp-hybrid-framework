using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//will be deleted
namespace OrangeAutomation
{
    public class DemoTest
    {

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
            object[] allDataSet=new object[3];
            allDataSet[0] = dataSet1;
            allDataSet[1] = dataSet2;
            allDataSet[2] = dataSet3;

            return allDataSet;
        }

        [Test,TestCaseSource(typeof(DemoTest),nameof(ValidLoginData))]
        public void DemoValidLogin(string username, string password)
        {
            Console.WriteLine("valid" + username + password);
        }
    }
}
