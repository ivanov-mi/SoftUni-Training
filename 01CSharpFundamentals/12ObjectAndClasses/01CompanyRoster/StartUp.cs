using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        int numberOfEmployees = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < numberOfEmployees; i++)
        {
            string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
            Employee cureentEmployee = new Employee(inputLine[0], double.Parse(inputLine[1]), inputLine[2]);
        
            employees.Add(cureentEmployee);
        }

        string highestSalaryDepartment = employees.GroupBy(x => x.Department)
            .OrderByDescending(x => x.Average(x => x.Salary))
            .Select(x => x.Key)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment}");
                
        List<Employee> bestDepartmentSalaries = employees.Where(x => x.Department == highestSalaryDepartment)
            .OrderByDescending(x => x.Salary)
            .ToList();
        
        foreach (var employee in bestDepartmentSalaries)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
        }
    }
}