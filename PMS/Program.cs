using System.Globalization;
using PMS;

try
{
    Console.WriteLine("Welcome to Printing and Mailing Service!!!");

    Console.Write("Please enter a date(MM-dd-yyyy) to process:");
    string date = Console.ReadLine();

    DateTime currentDate = new DateTime();
    currentDate = Convert.ToDateTime(date);

    var processedDate = currentDate.ToString("yyyyMMdd");

    LetterService letterService = new LetterService();

    string _admissionFolderPath = Constants.AdmissionFolderPath + processedDate + "/";
    string _scholarshipFolderPath = Constants.ScholarshipFolderPath + processedDate + "/";
    string _outputFolderPath = Constants.OutputFolderPath + "/";

    string[] admissionFiles = LetterServiceUtils.GetAllAdmissionFiles(_admissionFolderPath);
    string[] scholarshipFiles = LetterServiceUtils.GetAllScholarshipFiles(_scholarshipFolderPath);

    var studentIds = CheckForStudentSubmissions(admissionFiles, scholarshipFiles);

    foreach (var id in studentIds)
    {
        string _admissionFile = admissionFiles.Where(x => x.Contains(id)).SingleOrDefault();
        string _scholarshipFile = scholarshipFiles.Where(x => x.Contains(id)).SingleOrDefault();

        string _outputFile = "output-" + id + ".txt";

        letterService.CombineTwoLetters(Constants.AdmissionFolderPath + processedDate + "/" + _admissionFile,
                                        Constants.ScholarshipFolderPath + processedDate + "/" + _scholarshipFile,
                                        _outputFile);
    }


    ReportUtils.GenerateReport(currentDate, studentIds);
    
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}

string[] CheckForStudentSubmissions(string[] admissionFiles, string[] scholarshipFiles)
{
    string[] studentIdsFromAdmissionFiles = StudentServiceUtils.GetStudentIdsFromFileName(admissionFiles, "admission");
    string[] studentIdsFromScholarshipFiles = StudentServiceUtils.GetStudentIdsFromFileName(scholarshipFiles, "scholarship");

    string[] studentIds = studentIdsFromAdmissionFiles.Intersect(studentIdsFromScholarshipFiles).ToArray();

    return studentIds;
}

void ProcessFiles(string[] studentIds, string inputFile1, string inputFile2, string resultFile)
{
    throw new NotImplementedException();
}