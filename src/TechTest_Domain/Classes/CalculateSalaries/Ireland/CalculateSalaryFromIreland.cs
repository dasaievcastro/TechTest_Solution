using System;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Classes.CalculateSalaries.Ireland
{
    public class CalculateSalaryFromIreland
    {
        public double GrossAmount { get; protected set; }
        public double TaxRateAmount { get; protected set; }

        public CalculateSalaryFromIreland(Employee e)
        {
            this.GrossAmount = e.HourRate * e.HoursWorked;
        }

        public void CalculateTaxRate()
        {
            TaxRateAmount = (GrossAmount > 600) ? GrossAmount * .4 : GrossAmount * .25;
        }
    }
}
