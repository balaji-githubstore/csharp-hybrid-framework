using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Utilities
{
    public class ExcelUtils
    {
        public static object[] GetSheetIntoObjectArray(string file, string sheetname)
        {
            using (XLWorkbook book = new XLWorkbook(file))
            {
                var sheet = book.Worksheet(sheetname);

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

                return allDataSet;
            }
        }
    }
}
