using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int HGrade { get; set; }
    public int LGrade { get; set; }

    public Student(string name, int hgrade, int lgrade)
    {
        Name = name;
        HGrade = hgrade;
        LGrade = lgrade;
    }
}

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Omen\Documents\students.txt";

        var students = ReadStudentsFromFile(filePath);

        var studentsByHGrade = students.Where(s => s.HGrade > 90).OrderByDescending(s => s.HGrade);

        var studentsByLGrade = students.Where(s => s.LGrade < 90).OrderByDescending(s => s.LGrade);


        Console.WriteLine("Студенти з високим балом:");
        foreach (var student in studentsByHGrade)
        {
            Console.WriteLine($"{student.Name} - {student.HGrade}");
        }

        Console.WriteLine();

        Console.WriteLine("Студенти з низьким балом:");
        foreach (var student in studentsByLGrade)
        {
            Console.WriteLine($"{student.Name} - {student.LGrade}");
        }
    }

    static List<Student> ReadStudentsFromFile(string filePath)
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var name = values[0];
                var hgrade = int.Parse(values[1]);
                var lgrade = int.Parse(values[1]);

                students.Add(new Student(name, hgrade, lgrade));
            }
        }

        return students;
    }
}


