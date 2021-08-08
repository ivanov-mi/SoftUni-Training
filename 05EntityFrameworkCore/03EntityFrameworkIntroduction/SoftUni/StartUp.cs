namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;

    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static IFormatProvider cultureInfo;

        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesFullInformation(context);

            Console.WriteLine(result);
        }

        //3.	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine(
                    $"{emp.FirstName} " +
                    $"{emp.LastName} " +
                    $"{emp.MiddleName} " +
                    $"{emp.JobTitle} " +
                    $"{emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4.	Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50_000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5.	Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    deparmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.deparmentName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //6.	Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeNakov = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            
            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .Select(a => a.Address.AddressText)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        //7.	Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            //DateTime startDate = new DateTime(2001, 01, 01, 00, 00, 00);
            //DateTime endDate = new DateTime(2003, 12, 31, 23, 59, 59);

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && 
                                                          ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new 
                        { 
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project
                                .StartDate
                                .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project
                                .EndDate.HasValue 
                                    ? ep.Project
                                        .EndDate
                                        .Value
                                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                    : "not finished"
                        })
                        .ToList()
                })
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");
                
                foreach (var project in emp.Project)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //8.	Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeeAddresses = context
                .Addresses
                .Select(e => new 
                {
                    AddressText = e.AddressText,
                    TownName = e.Town.Name,
                    EmployeeCount = e.Employees.Count
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToList();

            foreach (var emp in employeeAddresses)
            {
                sb.AppendLine($"{emp.AddressText}, {emp.TownName} - {emp.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //9.	Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    jobTitle = e.JobTitle,
                    projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.firstName} {employee.lastName} - {employee.jobTitle}");

            foreach (var projects in employee.projects)
            {
                sb.AppendLine($"{projects}");
            }

            return sb.ToString().TrimEnd();
        }

        //10.	Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var deparmentsInfo = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    departmentName = d.Name,
                    managerFirstName = d.Manager.FirstName,
                    managerLastName = d.Manager.LastName,
                    deparmentEmployees = d.Employees
                        .Select(de => new 
                        {
                            employeeFistName = de.FirstName,
                            employeeLasName = de.LastName,
                            employeeJobTitle = de.JobTitle
                        })
                        .OrderBy(de => de.employeeFistName)
                        .ThenBy(de => de.employeeLasName)
                        .ToList()
                })
                .ToList();

            foreach (var dep in deparmentsInfo)
            {
                sb.AppendLine($"{dep.departmentName} - {dep.managerFirstName} {dep.managerLastName}");
            
                foreach (var emp in dep.deparmentEmployees)
                {
                    sb.AppendLine($"{emp.employeeFistName} {emp.employeeLasName} - {emp.employeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //11.	Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    projectName = p.Name,
                    projectDescription = p.Description,
                    projectStartDate = p.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.projectName)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.projectName}");
                sb.AppendLine($"{p.projectDescription}");
                sb.AppendLine($"{p.projectStartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //12.	Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesToIncreaseSalary = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services");

            foreach (var employee in employeesToIncreaseSalary)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            foreach (var employee in employeesToIncreaseSalary
                                        .OrderBy(e => e.FirstName)
                                        .ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //13.	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.ToLower().StartsWith("Sa"))
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();


            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14.	Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectId = 2;

            var projectToRemove = context
                .Projects
                .Find(projectId);

            var employeesToRemove = context
                .EmployeesProjects
                .Where(e => e.ProjectId == projectId);

            context.EmployeesProjects.RemoveRange(employeesToRemove);
            context.Projects.Remove(projectToRemove);
            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p}");
            }

            return sb.ToString().TrimEnd();
        }

        //15.	Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDeleteName = "Seattle";

            var townToRemove = context
                .Towns
                .Where(t => t.Name == townToDeleteName)
                .FirstOrDefault();

            var addressesToDelete = context
                .Addresses
                .Where(e => e.TownId == townToRemove.TownId);
            var addressToDeleteCount = addressesToDelete.Count();

            var employeesToDeleteAddress = context
                .Employees
                .Where(e => e.Address.TownId == townToRemove.TownId);

            foreach (var employee in employeesToDeleteAddress)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToRemove);
            context.SaveChanges();

            return $"{addressToDeleteCount} addresses in {townToDeleteName} were deleted";
        }
    }
}
