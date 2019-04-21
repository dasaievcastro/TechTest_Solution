using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Classes.CalculateSalaries.Germany
{
    public class CalculateSalaryFromGermany : CalculateSalaryBase
    {
        public CalculateSalaryFromGermany(Employee e) : base(e)
        {
        }

        public override void CalculateTaxRate()
        {
            TaxRateAmount = (GrossAmount > 400) ? GrossAmount * .32 : GrossAmount * .25;
        }

        public override void CalculatePension()
        {
            PensionAmount = GrossAmount * .02;
        }
    }
}
