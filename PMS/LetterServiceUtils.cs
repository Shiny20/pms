using System;
namespace PMS
{
	public static class LetterServiceUtils
	{
        internal static string[] GetAllAdmissionFiles(string folderPath)
        {
            List<string> admissionFiles = new List<string>();
            var files = Directory.GetFiles(folderPath).Where(x => Path.GetFileName(x.ToLower()).Contains("admission"));
            foreach (var file in files)
            {
                admissionFiles.Add(Path.GetFileName(file));
            }
            return admissionFiles.ToArray();
        }

        internal static string[] GetAllScholarshipFiles(string folderPath)
        {
            List<string> scholarshipFiles = new List<string>();
            var files = Directory.GetFiles(folderPath).Where(x => Path.GetFileName(x.ToLower()).Contains("scholarship"));
            foreach (var file in files)
            {
                scholarshipFiles.Add(Path.GetFileName(file));
            }
            return scholarshipFiles.ToArray();
        }
    }
}

