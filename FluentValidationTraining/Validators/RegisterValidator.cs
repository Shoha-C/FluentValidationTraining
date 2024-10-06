using FluentValidation;
using FluentValidationTraining.Models;

namespace FluentValidationTraining.Validators;

public class RegisterValidator:
    AbstractValidator<CreateUserModel>
{

    public RegisterValidator()
    {
        RuleFor(u => u.FirstName)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(17);

        string role = "admin";


        RuleFor(u => u.Username)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(17)
            .WithErrorCode("17tadan ko'p")
            .Must(u => u != "admin")
            .WithErrorCode("admin is a invalid username")
            ;


        When(u => u.Adress != null, () =>
        {
            RuleFor(u => u.Adress)
                .SetValidator(new AdressValidator()!);
            
        });


        RuleFor(u => 
                Convert.ToInt32(u.Age))
            .GreaterThan(8)
            .WithErrorCode("kamida 8 yosh bollishi kk"); 

        When(u => u.Age < 18 && u.Age > 8, () =>
        {
            RuleFor(u => u.Contacts).NotNull()
                .Must(c => c.Count >= 2)
                .WithErrorCode("kamida 2 kontakt kerak");
        })
        .Otherwise(() =>
        {
            When(u => u.Age < 18 && u.Age < 40,
                () => 
                {
                    RuleFor(u => u.Contacts)
                        .NotNull()
                        .Must(c => c.Count > 0);
                })
                .Otherwise(
                    () =>
                    {
                        RuleFor(u => u.Contacts)
                            .Null();
                    }
                    );
        });

        /*var userAge = 15;
        if (userAge < 18)
        {

        }
        else
        {
            if (userAge > 18 && userAge < 40)
            {
                //action
            }
            else
            {
                
            }
        }*/


    }

}


public class AdressValidator : AbstractValidator<Adress>
{
    public AdressValidator()
    {
        RuleFor(a => a.ZipCode)
            .GreaterThan(100000)
            .LessThan(101000);

        RuleFor(a => a.Country)
            .Must(c => c == "Uzbekistan");

        RuleFor(a => a.City)
            .Must(c => c != "dsf000");

    }
}
