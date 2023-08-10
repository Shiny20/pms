using System;
namespace PMS
{
	public static class StudentServiceUtils
	{
		public static string[] GetStudentIdsFromFileName(string[] files, string placeHolder)
		{
			List<string> studentIds = new List<string>();

			foreach (var fileName in files)
			{
				string studentID = fileName.Substring(fileName.IndexOf("-") + 1).Split('.')[0];
				studentIds.Add(studentID);
            }
			return studentIds.ToArray();
		}
	}
}

