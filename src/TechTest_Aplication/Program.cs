using System;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.Classes.ReadData;
using TechTest_Domain.Validators.Employees;

namespace TechTest_Aplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //print and read data. 
            /*I don't implement a unit test for this class.
            I have priorizited the calc tests*/
            ReadData data = new ReadData();

            //Using Building Pattern to create an employee
            Employee employee = BuilderEmployee.Create().EarnsForHour(data._hourRate)
                .WorkedFor(data._hoursWorked)
                .LivesIn(data._location).Build();

            //validate objects
            EmployeeValidator employeeValidator = new EmployeeValidator();
        }
    }
}
