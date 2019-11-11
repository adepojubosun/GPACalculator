using System;
using System.IO;


namespace GPACalculator.Controller
{
    public class FileOperation
    {
        private static readonly string _currentDirectory = Directory.GetCurrentDirectory();

        public static void FileSave(string inputStream)
        {
            try{
                StreamWriter writer = new StreamWriter(_currentDirectory+"/gpa_results.txt");
                writer.WriteLine(inputStream);
                writer.Flush();
                writer.Close();
                Console.WriteLine("File successfully saved in the "+_currentDirectory+" directory");


            }catch(Exception ex)
            {
                Console.WriteLine("Error saving to file, Please try again later");
            }
        }


    }
}