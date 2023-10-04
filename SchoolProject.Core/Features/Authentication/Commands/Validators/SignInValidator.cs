using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators
{
	public class SignInValidator : AbstractValidator<SignInCommand>
	{

		public SignInValidator()
		{
			ApplyValidationRules();
		}


		public void ApplyValidationRules()
		{


			RuleFor(i => i.UserName)
				.NotEmpty().WithMessage("Username Not Empty..")
				.NotNull().WithMessage("Username is null..")
				.MaximumLength(50).WithMessage("Max length is 50..");


			RuleFor(i => i.Password)
				.NotEmpty().WithMessage("Password is empty..")
				.NotNull().WithMessage("Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");

		}
	}
}
