using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace Doubi.Core.Utilities
{

    /// <summary>  
    ///NPOI操作Excel，这个例子是针对Excel 2007.   
    /// </summary>  
    public class ExcelHelper
    {
        IWorkbook hssfworkbook;

        public ExcelHelper(string excelfile)
        {
            this.hssfworkbook = LoadFromFile(excelfile);
        }

        public static IWorkbook LoadFromFile(string filepath)
        {
            IWorkbook result = null;
            try
            {
                using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    result = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return result;
        }

        public List<T> ExcelToList<T>()
        {
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            List<T> list = new List<T>();
            return list;           
        }

        public DataTable ExcelToDataTable()
        {   
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();

            //一行最后一个方格的编号 即总的列数  
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }

            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }

}
