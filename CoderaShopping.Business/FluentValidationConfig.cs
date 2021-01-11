using FluentValidation.Mvc;

namespace CoderaShopping.Business
{
    public class FluentValidationConfig
    {
        public static void Configure()
        {
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
