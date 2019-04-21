using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Interfaces
{
    public interface ICalculateStrategy
    {
        CalculateSalaryBase CalculateNetAmount();
    }
}
