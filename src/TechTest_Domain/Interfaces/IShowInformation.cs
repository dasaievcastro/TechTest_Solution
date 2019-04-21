using System;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Interfaces
{
    public interface IShowInformation
    {
        void Sucess(Employee employee, CalculateSalaryBase calculate);
        void Error(string erro);
    }
}
