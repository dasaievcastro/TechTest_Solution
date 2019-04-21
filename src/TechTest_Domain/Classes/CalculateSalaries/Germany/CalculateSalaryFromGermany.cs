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
    }
}
