using FluentValidation;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Commands.Validators
{
	public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommmand>
	{

		public ChangeUserPasswordValidator()
		{
			ApplyValidationRules();
		}


		public void ApplyValidationRules()
		{
			RuleFor(i => i.Id)
				.NotEmpty().WithMessage("Id must be not empty")
				.NotNull().WithMessage("Id must be not null");


			RuleFor(i => i.CurrentPassword)
				.NotEmpty().WithMessage("Password is empty..")
				.NotNull().WithMessage("Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");

			RuleFor(i => i.NewPassword)
				.Equal(m => m.NewPassword).WithMessage("Password must equal confirm password")
				.NotEmpty().WithMessage("Confirm Password is empty..")
				.NotNull().WithMessage("Confirm Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");



			RuleFor(i => i.ConfirmNewPassword)
				.Equal(m => m.NewPassword).WithMessage("confirm password must equal password")
				.NotEmpty().WithMessage("Confirm Password is empty..")
				.NotNull().WithMessage("Confirm Password is null..")
				.MaximumLength(100).WithMessage("Max length is 100..");
		}
	}
}
