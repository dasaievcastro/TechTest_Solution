using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Classes.CalculateSalaries.Ireland
{
    public class CalculateSalaryFromIreland : CalculateSalaryBase
    {

        public CalculateSalaryFromIreland(Employee e) : base(e)
        {
        }

        public override void CalculateTaxRate()
        {
            TaxRateAmount = (GrossAmount > 600) ? GrossAmount * .4 : GrossAmount * .25;
        }

        public override void CalculateSocialContribution()
        {
            SocialTaxAmount = (GrossAmount > 500) ? GrossAmount * .08 : GrossAmount * .07;
        }

        public override void CalculatePension()
        {
            PensionAmount = GrossAmount * .04;
        }
    }
}
