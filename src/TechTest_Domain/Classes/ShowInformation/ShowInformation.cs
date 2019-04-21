using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.Interfaces;

namespace TechTest_Domain.Classes.ShowInformation
{
    public class ShowInformation : IShowInformation
    {
        public void Error(string erro)
        {
            Console.WriteLine(erro);
        }

        public void Sucess(Employee employee, CalculateSalaryBase calculate)
        {
            Console.WriteLine("Employee location: {0}", employee.Location);
            Console.WriteLine("");
            Console.WriteLine("Gross Amount: €{0}", calculate.GrossAmount);
            Console.WriteLine("");
            Console.WriteLine("Less deductions");
            Console.WriteLine("Income Tax: €{0}", calculate.TaxRateAmount);
            Console.WriteLine("Universal Social Charge: €{0}", calculate.SocialTaxAmount);
            Console.WriteLine("Pension: €{0}", calculate.PensionAmount);
            Console.WriteLine("Net Amount: €{0}", calculate.NetAmount);
        }
    }
}
