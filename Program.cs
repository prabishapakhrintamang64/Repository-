        using System;
        using System.Linq;
        using models;

        namespace AuraApplication
        {
            public class Data
            {
            public static void Main()
        {
            using var db = new EmployeeContext();
            db.Database.EnsureCreated();  
            Console.WriteLine($"DatabasePath: {db.Dbpath}");

            Employee employee = new Employee { Employeeid = 1, EmployeeName = "Street Dog", Departid = 101 };
            Employee employee1 = new Employee { Employeeid = 2, EmployeeName = "Rottweiler", Departid = 102 };
            Employee employee2 = new Employee { Employeeid = 3, EmployeeName = "Siberian Husky", Departid = 103 };
            Employee employee3 = new Employee { Employeeid = 4, EmployeeName = "German Shepherd", Departid = 104 };
            Employee employee4 = new Employee { Employeeid = 5, EmployeeName = "Bull Dogs", Departid = 105 };
            Employee employee5 = new Employee { Employeeid = 6, EmployeeName = "Dachshund", Departid = 106 };
            Employee employee6 = new Employee { Employeeid = 7, EmployeeName = "Golden Retriever", Departid = 107 };
            Employee employee7 = new Employee { Employeeid = 8, EmployeeName = "Beagle", Departid = 108 };
            Employee employee8 = new Employee { Employeeid = 9, EmployeeName = "Poodle", Departid = 109 };
            Employee employee9 = new Employee { Employeeid = 10, EmployeeName = "Labrador Retriever", Departid = 110 };
            Employee employee0 = new Employee { Employeeid = 11, EmployeeName = "French Bulldogs", Departid = 111 };
            Employee employee11 = new Employee { Employeeid = 12, EmployeeName = "Corgi", Departid = 112 };
            Employee employee12 = new Employee { Employeeid = 13, EmployeeName = "Great Dane", Departid = 113 };
            Employee employee13 = new Employee { Employeeid = 14, EmployeeName = "Chihuahua", Departid = 114 };
            Employee employee14 = new Employee { Employeeid = 15, EmployeeName = "Boxer", Departid = 115 };
            Employee employee15 = new Employee { Employeeid = 16, EmployeeName = "Border Collie", Departid = 116 };

            db.AddRange(employee, employee1, employee2, employee3, employee4, employee5, employee6, 
                        employee7, employee8, employee9, employee0, employee11, employee12, 
                        employee13, employee14, employee15);

            db.SaveChanges();

            Console.WriteLine("Employees added to the database:");
            var allEmployees = db.Employees.ToList();
            foreach (var emp in allEmployees)
            {
                Console.WriteLine($"Employee ID: {emp.Employeeid}, Name: {emp.EmployeeName}, Department ID: {emp.Departid}");
            }

            Employee firstEmployee = allEmployees.First();

            EmployeeLeave employeeLeave = new EmployeeLeave { Leaveid = 1, Employeeid = firstEmployee.Employeeid, NumOfDays = 7 };
            db.Add(employeeLeave);
            db.SaveChanges();

            EmployeeLeave firstLeave = db.EmployeeLeaves
                .Where(el => el.Employeeid == firstEmployee.Employeeid)
                .First();

            Console.WriteLine($"Leave applied by first employee for {firstLeave.NumOfDays} days");

            db.Remove(firstLeave);
            Console.WriteLine($"First EmployeeID : {firstEmployee.Employeeid} with Name : {firstEmployee.EmployeeName}");

            db.RemoveRange(allEmployees);
            db.SaveChanges();
            }
        }
    }