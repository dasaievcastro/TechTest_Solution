using System;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.Interfaces;

namespace TechTest_Domain.Classes.CalculateSalaries.Base
{
    /*This class was created for implement a pattern to calculate the salary
    in all countries. This is an abstract class so all countries have to 
    implement your definition for calculate your Taxes. I have implemented
    the main methods because they are the same in all countries, however 
    the children class can override them if it's necessary */
    public abstract class CalculateSalaryBase : ICalculateSalary
    {
        public double GrossAmount { get; protected set; }
        public double NetAmount { get; protected set; }
        public double TaxRateAmount { get; protected set; }
        public double SocialTaxAmount { get; protected set; }
        public double PensionAmount { get; protected set; }
        protected CalculateSalaryBase(Employee e)
        {
            this.GrossAmount = e.HourRate * e.HoursWorked;
        }

        public virtual void CalculateTaxRate() { this.TaxRateAmount = 0; }
        public virtual void CalculateSocialContribution() { this.SocialTaxAmount = 0; }
        public virtual void CalculatePension() { this.PensionAmount = 0; }
        public virtual void CalculateNetAmount()
        {
            CalculateTaxRate();
            CalculateSocialContribution();
            CalculatePension();
            NetAmount = this.GrossAmount - this.TaxRateAmount - this.SocialTaxAmount - this.PensionAmount;
        }
    }
}
