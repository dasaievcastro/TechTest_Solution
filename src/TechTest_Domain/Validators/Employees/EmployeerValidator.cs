using System;
using FluentValidation;
using TechTest_Domain.Classes.Employees;

namespace TechTest_Domain.Validators.Employees
{
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
