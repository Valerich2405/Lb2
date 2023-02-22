using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Experience { get; set; }
}

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Omen\Documents\employees.txt";

        List<Employee> employees = ReadEmployeesFromFile(filePath);


        List<Employee> sortedBySalary = employees.OrderBy(e => e.Salary).ToList();

        Console.WriteLine("Список спiвробiтникiв за зарплатою:");
        foreach (Employee e in sortedBySalary)
        {
            Console.WriteLine($"Iм'я: {e.Name}, Зарплата: {e.Salary}");
        }


        List<Employee> sortedByExperience = employees.OrderBy(e => e.Experience).ToList();

        Console.WriteLine("\nСписок спiвробiтникiв за роками досвiду:");
        foreach (Employee e in sortedByExperience)
        {
            Console.WriteLine($"Iм'я: {e.Name}, Роки досвiду: {e.Experience}");
        }
    }

    static List<Employee> ReadEmployeesFromFile(string filePath)
    {
        List<Employee> employees = new List<Employee>();

        using (StreamReader streamReader = new StreamReader(filePath))
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] fields = line.Split(' ');

                Employee employee = new Employee
                {
                    Name = fields[0],
                    Salary = int.Parse(fields[1]),
                    Experience = int.Parse(fields[2])
                };

                employees.Add(employee);
            }
        }

        return employees;
    }
}