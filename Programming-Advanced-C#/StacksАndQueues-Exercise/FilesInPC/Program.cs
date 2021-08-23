using System;
using System.IO;

namespace FilesInPC
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Softuni";

            Printderectory(path, string.Empty);
        }

        static void Printderectory(string path, string prefix) 
        {
            string [] directories = Directory.GetDirectories(path);

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            Console.WriteLine($"{prefix} Dir: {directoryInfo.Name}");

            foreach (var directory in directories)
            {
                Printderectory(directory, prefix += "--");
            }

            string [] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                Console.WriteLine($"{prefix}- File: {fileInfo.Name}");
            }
        }
    }
}
