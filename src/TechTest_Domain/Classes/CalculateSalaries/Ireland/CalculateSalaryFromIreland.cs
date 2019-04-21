using System;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Classes.CalculateSalaries.Ireland
{
    public class CalculateSalaryFromIreland
    {
        public double GrossAmount { get; protected set; }

        public CalculateSalaryFromIreland(Employee e)
        {
            this.GrossAmount = e.HourRate * e.HoursWorked;
        }
    }
}
