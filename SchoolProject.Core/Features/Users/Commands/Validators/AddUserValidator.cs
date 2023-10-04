using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validators
{
	public class AddUserValidator : AbstractValidator<AddUserCommand>
	{

		public AddUserValidator()
		{
			ApplyValidationRules();
		}


		public void ApplyValidationRules()
		{
			RuleFor(i => i.FirstName)
				.NotEmpty().WithMessage("First Name Not Empty..")
				.NotNull().WithMessage("First Name is null..")
				.MaximumLength(30).WithMessage("Max length is 30..");

			RuleFor(i => i.LastName)
				.NotEmpty().WithMessage("Last Name Not Empty..")
				.NotNull().WithMessage("Last Name is null..")
				.MaximumLength(30).WithMessage("Max length is 30..");

			RuleFor(i => i.UserName)
				.NotEmpty().WithMessage("Username Not Empty..")
				.NotNull().WithMessage("Username is null..")
				.MaximumLength(50).WithMessage("Max length is 50..");

			RuleFor(i => i.Email)
				.NotEmpty().WithMessage("Email is empty..")
				.NotNull().WithMessage("Email is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");

			RuleFor(i => i.Password)
				.NotEmpty().WithMessage("Password is empty..")
				.NotNull().WithMessage("Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");

			RuleFor(i => i.ConfirmPassword)
				.Equal(m => m.Password).WithMessage("Password must equal confirm password")
				.NotEmpty().WithMessage("Confirm Password is empty..")
				.NotNull().WithMessage("Confirm Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");
		}
	}
}
