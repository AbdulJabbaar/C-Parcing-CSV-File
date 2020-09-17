using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Parsing_CSV_File
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Class { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"Full Name, {FirstName + " " + LastName}, Class = {Class}, Marks={Marks}";
        }

        public static Student ParseFideCsv(string line)
        {
            string[] parts = line.Split(',');
            return new Student
            {
                FirstName = parts[0].Trim(),
                LastName = parts[1].Trim(),
                Class = int.Parse(parts[2].Trim()),
                Marks = int.Parse(parts[3].Trim())
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Students.csv");
            ParseCsv(fileLocation);
            Console.ReadLine();
        }

        private static void ParseCsv(string fileLocation)
        {
            File.ReadAllLines(fileLocation)
                .Select(Student.ParseFideCsv)
                .Where(a => a.Class > 5)
                .OrderByDescending(o => o.Marks)
                .Take(10).ForEach(item => Console.WriteLine(item.ToString()));
        }
    }
}