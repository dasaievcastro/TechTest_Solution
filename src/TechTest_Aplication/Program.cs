using System;
using FluentValidation;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.Classes.ReadData;
using TechTest_Domain.Classes.ShowInformation;
using TechTest_Domain.Strategy;
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

            ShowInformation information = new ShowInformation();

            //verify if it a valid employee
            try
            {
                employeeValidator.ValidateAndThrow(employee);

                /*
                I have used the Strategy patter to implement Open closed principle.
                With this pattern I can associate countries and their relative Calculcate class.

                I don't implement a unit test for this class.
                I have priorizited the calc tests
                */
                CalculateStrategy calculate = new CalculateStrategy(employee);

                //this method exec all calcs from an employe
                var calcInformations = calculate.CalculateNetAmount();
                information.Sucess(employee, calcInformations);
            }
            catch (ValidationException ex)
            {
                information.Error(ex.Message);
            }
        }
    }
}
