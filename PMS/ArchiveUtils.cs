using System;
namespace PMS
{
	public static class ArchiveUtils
	{
        public static void ArchiveFiles(string inputFile1, string inputFile2)
        {
            string archiveFolderPath = Constants.ArchiveFolderPath;
            string admissionFileName = Path.GetFileName(inputFile1);
            string scholarshipFileName = Path.GetFileName(inputFile2);

            File.Move(inputFile1, archiveFolderPath + admissionFileName);
            File.Move(inputFile2, archiveFolderPath + scholarshipFileName);
        }
    }
}

