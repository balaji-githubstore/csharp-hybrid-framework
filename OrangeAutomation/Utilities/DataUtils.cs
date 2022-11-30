using Fujitsu.AutomationWrapperProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Utilities
{
    /// <summary>
    /// All TestCase Source will be kept in this class
    /// </summary>
    public class DataUtils
    {
        public static object[] ValidLoginData()
        {
            object[] allDataSet = ExcelUtils.GetSheetIntoObjectArray
                ("C:\\automation_work\\HybridFrameworkSln\\OrangeAutomation\\TestData\\orangehrm_data.xlsx", "ValidLoginTest");

            return allDataSet;
        }

        /// <summary>
        /// supply test data to InvalidLoginTest in LoginTest class
        /// </summary>
        /// <returns>object[]</returns>
        public static object[] InvalidLoginData()
        {
            object[] allDataSet=ExcelUtils.GetSheetIntoObjectArray
                ("C:\\automation_work\\HybridFrameworkSln\\OrangeAutomation\\TestData\\orangehrm_data.xlsx", "InvalidLoginTest");

            return allDataSet;
        }

        /// <summary>
        /// supply test data to AddValidEmployeeTest in EmployeeTest class
        /// </summary>
        /// <returns>object[]</returns>
        public static object[] AddValidEmployeeData()
        {
            string[] dataSet1 = new string[6];
            dataSet1[0] = "admin";
            dataSet1[1] = "admin123";
            dataSet1[2] = "John";
            dataSet1[3] = "U";
            dataSet1[4] = "Wick";
            dataSet1[5] = "John Wick";

            string[] dataSet2 = new string[6];
            dataSet2[0] = "admin";
            dataSet2[1] = "admin123";
            dataSet2[2] = "Paul";
            dataSet2[3] = "k";
            dataSet2[4] = "Peter";
            dataSet2[5] = "Paul Peter";

            object[] allDataSet = new object[2];
            allDataSet[0] = dataSet1;
            allDataSet[1] = dataSet2;

            return allDataSet;
        }
    }
}
