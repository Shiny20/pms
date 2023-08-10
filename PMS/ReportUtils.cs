using System;
namespace PMS
{
	public static class ReportUtils
	{
		public static void GenerateReport(DateTime date, string[] studentIds)
		{
            StreamWriter sw = new StreamWriter(Constants.OutputFolderPath + "/" + "Report_" + date.ToString("yyyyMMdd") + ".txt");

            sw.WriteLine(date.ToString("MM/dd/yyyy") + " Report");
            sw.WriteLine("-------------------");

            sw.WriteLine("Number of combined letters: " + studentIds.Count());

            foreach (var id in studentIds)
            {
                sw.WriteLine(id);
            }

            sw.Close();
        }
	}
}

