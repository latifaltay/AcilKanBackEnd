using FluentValidation; 
using MediatR;


namespace AcilKan.Application.ValidationRules.FluentValidation.AboutValidators
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // ValidationContext oluşturuluyor
            var context = new ValidationContext<TRequest>(request);

            // Senkron ve Asenkron validasyonları ele almak için 
            var validationTasks = _validators
                .Select(async validator =>
                {
                    // Asenkron validasyonları kontrol et
                    var result = await validator.ValidateAsync(context, cancellationToken);
                    return result.Errors;
                })
                .ToList();

            // Tüm validation işlemlerinin tamamlanmasını bekle
            var validationResults = await Task.WhenAll(validationTasks);

            // Hataları birleştir
            var failures = validationResults
                .SelectMany(result => result)
                .Where(f => f != null)
                .ToList();

            // Eğer hata varsa, ValidationException fırlat
            if (failures.Count > 0)
            {
                throw new ValidationException(failures);
            }

            // İşlem başarılıysa, işleme devam et
            return await next();
        }
    }
}


// Asenkron yapılarda çalışmayan kodlar aşağıda

//public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//{
//    private readonly IEnumerable<IValidator<TRequest>> _validators;

//    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//    {
//        _validators = validators;
//    }


//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        var context = new ValidationContext<TRequest>(request);

//        var failures = _validators
//            .Select(v => v.Validate(context))
//            .SelectMany(result => result.Errors)
//            .Where(f => f != null)
//            .ToList();

//        if (failures.Count != 0)
//        {
//            throw new ValidationException(failures);
//        }

//        return await next();
//    }
//}
