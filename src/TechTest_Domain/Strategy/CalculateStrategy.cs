using System;
using System.Collections.Generic;
using TechTest_Domain.Classes.CalculateSalaries.Base;
using TechTest_Domain.Classes.CalculateSalaries.Germany;
using TechTest_Domain.Classes.CalculateSalaries.Ireland;
using TechTest_Domain.Classes.CalculateSalaries.Italy;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.ENums.Countries;
using TechTest_Domain.Interfaces;

namespace TechTest_Domain.Strategy
{
    public class CalculateStrategy : ICalculateStrategy
    {
        private static Dictionary<Countries, ICalculateSalary> _strategies =
            new Dictionary<Countries, ICalculateSalary>();
        private Employee _e;

        public CalculateStrategy(Employee e)
        {
            _e = e;
            _strategies.Add(Countries.Ireland, new CalculateSalaryFromIreland(_e));
            _strategies.Add(Countries.Italy, new CalculateSalaryFromItaly(_e));
            _strategies.Add(Countries.Germany, new CalculateSalaryFromGermany(_e));
        }


        public CalculateSalaryBase CalculateNetAmount()
        {
            CalculateSalaryBase calculate = (CalculateSalaryBase)_strategies[_e.Location];
            calculate.CalculateNetAmount();
            return calculate;
        }
    }
}
