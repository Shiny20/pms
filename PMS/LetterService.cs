using System;
namespace PMS
{
	public class LetterService: ILetterService
    {
        public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
        {
            StreamReader admissionReader = new StreamReader(inputFile1);
            StreamReader scholarshipReader = new StreamReader(inputFile2);

            string admissionContent = admissionReader.ReadToEnd();
            string scholarshipContent = scholarshipReader.ReadToEnd();

            StreamWriter outputWriter = new StreamWriter(Constants.OutputFolderPath + resultFile);

            outputWriter.WriteLine(admissionContent);
            outputWriter.WriteLine(scholarshipContent);

            outputWriter.Close();
            scholarshipReader.Close();
            admissionReader.Close();

            ArchiveUtils.ArchiveFiles(inputFile1, inputFile2);
        }

        
    }
}

