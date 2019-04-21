using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Classes.CalculateSalaries.Italy
{
    public class CalculateSalaryFromItaly : CalculateSalaryBase
    {
        public CalculateSalaryFromItaly(Employee e) : base(e)
        {
        }

        public override void CalculateTaxRate()
        {
            TaxRateAmount = GrossAmount * .25;
        }
    }
}
