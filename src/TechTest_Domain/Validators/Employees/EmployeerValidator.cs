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

            RuleFor(p => p.HourRate)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Please enter a Hour Rate")
            .Must(BeAValideHourRate).WithMessage("Please enter a valid Hour Rate");
        }

        public bool BeAValideHourWorked(int _hourWorked)
        {
            return (_hourWorked > 0);
        }

        public bool BeAValideHourRate(int _hourRate)
        {
            return (_hourRate > 0);
        }
    }
}
