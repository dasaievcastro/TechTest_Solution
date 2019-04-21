using System;
using FluentValidation;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.ENums.Countries;

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

            RuleFor(p => p.Location)
            .Must(BeAValideLocation).WithMessage("Please choose a valid Location");
        }

        public bool BeAValideHourWorked(int _hourWorked)
        {
            return (_hourWorked > 0);
        }

        public bool BeAValideHourRate(int _hourRate)
        {
            return (_hourRate > 0);
        }


        public bool BeAValideLocation(Countries _country)
        {
            return (Enum.IsDefined(typeof(Countries), _country));
        }
    }
}
