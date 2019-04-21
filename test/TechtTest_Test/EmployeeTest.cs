using System;
using ExpectedObjects;
using FluentValidation;
using FluentValidation.TestHelper;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.ENums.Countries;
using Xunit;

namespace TechtTest_Test
{
    public class EmployeeTest
    {
        private int _HoursWorked;
        private int _HourRate;
        private int _Location;

        public EmployeeTest()
        {
            _HoursWorked = 10;
            _HourRate = 40;
            _Location = 1;
        }

        [Fact]
        public void Should_have_create_an_employee()
        {
            var EmployeeTemplate = new
            {
                HoursWorked = 10,
                HourRate = 40,
                Location = (Countries)1

            };
            var EmployeeObject = BuilderEmployee.Create().WorkedFor(_HoursWorked).EarnsForHour(_HourRate).LivesIn(_Location).Build();
            //I make a simple compare just to check if the EmployeeTemplate are equal to Employee.
            EmployeeTemplate.ToExpectedObject().ShouldMatch(EmployeeObject);
        }

        [Fact]
        public void Should_have_error_when_HourWorked_is_null_or_Negative()
        {
            EmployeeValidator validator = new EmployeeValidator();

            Employee EmployeeObjTest = BuilderEmployee.Create().WorkedFor(-1).Build();
            validator.ShouldHaveValidationErrorFor(e => e.HoursWorked, EmployeeObjTest);

        }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.HoursWorked)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Please enter a Hour Worked")
            .Must(BeAValideHourWorked).WithMessage("Please enter a valid Hour Worked");

        }
        public bool BeAValideHourWorked(int _hourWorked)
        {
            return (_hourWorked > 0);
        }
    }
}
