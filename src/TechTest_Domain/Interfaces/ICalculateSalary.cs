using System;
namespace TechTest_Domain.Interfaces
{
    public interface ICalculateSalary
    {
        void CalculateTaxRate();
        void CalculateSocialContribution();
        void CalculatePension();
        void CalculateNetAmount();
    }
}
